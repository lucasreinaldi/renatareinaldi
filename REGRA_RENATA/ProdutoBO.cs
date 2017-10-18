using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Configuration;
using DAL_RENATA;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using REGRA_RENATA;
using System.Data.Linq;

namespace REGRA_RENATA
{
    public class ProdutoBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public bool Inserir(Produto produto, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                produto.CaminhoImagem = " ";
                DataContext.BeginTransaction();
                DataContext.DataContext.Produtos.InsertOnSubmit(produto);
                DataContext.DataContext.SubmitChanges();

                string caminhoCompleto = pastaDestino + "Produto_" + produto.IdProduto + extensao;
                if (fup.HasFile)
                {
                    Util.UploadArquivo(fup, caminhoCompleto);

                    if (Util.ArquivoExists(caminhoCompleto, null, null))
                    {
                        Produto produtoAlterar = this.ConsultarPorId(produto.IdProduto, idUsuarioLogado);
                        produtoAlterar.CaminhoImagem = "Produto_" + produto.IdProduto + extensao;
                        DataContext.DataContext.SubmitChanges();
                    }
                    else
                    {
                        DataContext.RollbackTransaction();
                    }
                }
                else
                {
                    Produto produtoAlterar = this.ConsultarPorId(produto.IdProduto, idUsuarioLogado);
                    produtoAlterar.CaminhoImagem = "Default.jpg";
                    DataContext.DataContext.SubmitChanges();
                }

                DataContext.CommitTransaction();
                msg = "Produto inserido com sucesso. id: " + produto.IdProduto;

                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao inserir o produto. [" + e.Message + "][" + e.Source + "]";

                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                logBO.Salvar(log);
                DataContext.RollbackTransaction();
                return false;
            }
        }

        private bool Alterar(Produto produto, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";
            bool ok = false;
            string oldPath;

            try
            {
                DataContext.BeginTransaction();

                Produto novoObj = this.ConsultarPorId(produto.IdProduto, idUsuarioLogado);
                novoObj.Nome = produto.Nome;
                novoObj.Descricao = produto.Descricao;
                novoObj.Estoque = produto.Estoque;
                novoObj.Preco = produto.Preco;


                oldPath = produto.CaminhoImagem;

                if (fup.HasFile)
                {
                    novoObj.CaminhoImagem = novoObj.CaminhoImagem;

                    if ((fup.FileName != null) && (fup.FileName != "") && (pastaDestino != null) && (pastaDestino != ""))
                    {

                        if (Util.ExcluirArquivo(pastaDestino + oldPath, null, null))
                        {
                            ok = true;
                        }
                        if (Util.UploadArquivo(fup, pastaDestino + "Produto_" + produto.IdProduto + extensao))
                        {
                            ok = true;
                            novoObj.CaminhoImagem = "Produto_" + produto.IdProduto + extensao;
                            DataContext.DataContext.SubmitChanges();
                        }
                        else
                        {
                            ok = false;
                        }
                    }
                }
                else
                {
                    ok = true;
                }

                if (ok)
                {
                    DataContext.DataContext.SubmitChanges();
                    DataContext.CommitTransaction();
                    msg = "O produto foi alterado com sucesso.";

                    log = new Log()
                    {

                        IdUsuario = idUsuarioLogado,
                        Mensagem = msg
                    };
                    logBO.Salvar(log);

                    return true;
                }

                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o produto.";

                log = new Log()
                {

                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                return false;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o produto. [Erro ao carregar servico do bd]";
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return false;
            }
        }

        private bool AtualizarEstoqueBanco(Produto produto, int estoque)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";            
            try
            {
                Produto novoObj = this.ConsultarPorId(produto.IdProduto, null);
                novoObj.Nome = produto.Nome;
                novoObj.Descricao = produto.Descricao;
                novoObj.Estoque = estoque;
                novoObj.Preco = produto.Preco;
                novoObj.CaminhoImagem = produto.CaminhoImagem;
                DataContext.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o produto. [Erro ao carregar servico do bd]";
                log = new Log()
                {
                    IdUsuario = null,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return false;
            }
        }

        public bool Salvar(Produto produto, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            if (produto.IdProduto <= 0)
                return this.Inserir(produto, pastaDestino, extensao, fup, idUsuarioLogado);
            else
                return this.Alterar(produto, pastaDestino, extensao, fup, idUsuarioLogado);
        }

        public bool Excluir(Produto produto, string pastaDestino, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";

            try
            {
                DataContext.BeginTransaction();
                Produto produtoExcluir = this.ConsultarPorId(produto.IdProduto, idUsuarioLogado);
                string caminhoCompleto = pastaDestino + produtoExcluir.CaminhoImagem;
                DataContext.DataContext.Produtos.DeleteOnSubmit(produtoExcluir);

                if (produto.CaminhoImagem != null)
                {
                    if (Util.ExcluirArquivo(caminhoCompleto, null, null))
                    {
                        DataContext.DataContext.SubmitChanges();
                        DataContext.CommitTransaction();

                        msg = "Produto excluído com sucesso. " + produtoExcluir.IdProduto;
                        log = new Log()
                        {
                            IdUsuario = idUsuarioLogado,
                            Mensagem = msg
                        };

                        return true;
                    }
                    else
                    {
                        DataContext.RollbackTransaction();
                        msg = "Erro ao excluir o produto. " + produto.IdProduto;

                        return false;
                    }
                }
                DataContext.DataContext.SubmitChanges();
                DataContext.CommitTransaction();

                msg = "Produto excluído com sucesso. " + produtoExcluir.IdProduto;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                return true;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao excluir o produto. " + produto.IdProduto + "Erro: " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    DataHora = DateTime.Now,
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                return false;
            }
        }

        public Produto ConsultarPorId(int id, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                return DataContext.DataContext.Produtos.Single(Produto => Produto.IdProduto == id);
            }

            catch (Exception e)
            {
                msg = "Erro ao consultar produto por ID. " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return null;
            }
        }

        public List<Produto> ConsultarTodos(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {
                var consulta = from Produto in DataContext.DataContext.Produtos select Produto;
                return consulta.ToList();
            }
            catch (Exception e)
            {
                msg = "Erro ao consultar todos produtos. Erro: " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    DataHora = DateTime.Now,
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                logBO.Salvar(log);

                return null;
            }
        }

        public bool AlterarEstoque(List<Produto> estoqueSession)
        {
            List<Produto> estoqueBanco = ConsultarTodos(null);
            DataContext.BeginTransaction();

            foreach (Produto banco in estoqueBanco)
            {
                foreach (Produto session in estoqueSession)
                {
                    if (session.IdProduto == banco.IdProduto)
                    {
                        AtualizarEstoqueBanco(banco, session.Estoque);
                        
                    }
                }
            }
            DataContext.CommitTransaction();
            return true;
        }
    }
}