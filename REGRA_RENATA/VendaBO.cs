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
using REGRA_RENATA;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace REGRA_RENATA
{
    public class VendaBO
    {

        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public Venda ConsultarPorId(int id, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                return DataContext.DataContext.Vendas.Single(Venda => Venda.IdVenda == id);
            }

            catch (Exception e)
            {
                msg = "Erro ao consultar venda por id. " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return null;
            }
        }

        public List<Venda> ConsultarTodos(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Venda in DataContext.DataContext.Vendas select Venda;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar todas vendas. Erro: " + e.Message + " - " + e.Source;
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

        public bool Finalizar(Venda venda)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";
            try
            {
                DataContext.BeginTransaction();
                DataContext.DataContext.Vendas.InsertOnSubmit(venda);
                DataContext.DataContext.SubmitChanges();
                DataContext.CommitTransaction();
                msg = "Venda efetuada. " + venda.IdVenda;
                log = new Log()
                {
                     
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao efetuar venda. [" + e.Message + "][" + e.Source + "]";
                log = new Log()
                {
                     
                    Mensagem = msg
                };
                logBO.Salvar(log);
                DataContext.RollbackTransaction();
                return false;
            }
        }

        private bool Alterar(Produto produto, int estoque)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";
            bool ok = false;
            
            try
            {
                ProdutoBO produtoBO = new ProdutoBO();

                DataContext.BeginTransaction();

                Produto novoObj = produtoBO.ConsultarPorId(produto.IdProduto, null);
                novoObj.Nome = produto.Nome;
                novoObj.Descricao = produto.Descricao;
                novoObj.Estoque = estoque;
                novoObj.Preco = produto.Preco;

                ok = true;

                if (ok)
                {
                    DataContext.DataContext.SubmitChanges();
                    DataContext.CommitTransaction();
                    msg = "Estoque alterado com sucesso.";

                    log = new Log()
                    {

                        Mensagem = msg
                    };
                    logBO.Salvar(log);

                    return true;
                }

                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o estoque.";

                log = new Log()
                {
                    Mensagem = msg
                };

                return false;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o estoque. [Erro ao carregar servico do bd]";
                log = new Log()
                {
                    
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return false;
            }
        }

    }
}