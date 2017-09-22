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



namespace REGRA_RENATA
{
    public class ServicoBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public bool Inserir(Servico servico, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                servico.CaminhoImagem = " ";
                DataContext.BeginTransaction();
                DataContext.DataContext.Servicos.InsertOnSubmit(servico);
                DataContext.DataContext.SubmitChanges();

                string caminhoCompleto = pastaDestino + "Servico_" + servico.IdServicos + extensao;
                if (fup.HasFile)
                {
                    Util.UploadArquivo(fup, caminhoCompleto);

                    if (Util.ArquivoExists(caminhoCompleto, null, null))
                    {
                        Servico servicoAlterar = this.ConsultarPorId(servico.IdServicos, idUsuarioLogado);
                        servicoAlterar.CaminhoImagem = "Servico_" + servico.IdServicos + extensao;
                        DataContext.DataContext.SubmitChanges();
                    }
                    else
                    {
                        DataContext.RollbackTransaction();
                    }
                }
                else
                {
                    Servico servicoAlterar = this.ConsultarPorId(servico.IdServicos, idUsuarioLogado);
                    servicoAlterar.CaminhoImagem = "Default.jpg";
                    DataContext.DataContext.SubmitChanges();
                }
                DataContext.CommitTransaction();
                msg = "Serviço inserido com sucesso. id: " + servico.IdServicos;

                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao inserir o serviço. [" + e.Message + "][" + e.Source + "]";

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

        private bool Alterar(Servico servico, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";
            bool ok = false;
            string oldPath;

            try
            {
                DataContext.BeginTransaction();

                Servico novoServico = this.ConsultarPorId(servico.IdServicos, idUsuarioLogado);
                novoServico.Nome = servico.Nome;
                novoServico.Descricao = servico.Descricao;
                novoServico.Valor = servico.Valor;
                oldPath = servico.CaminhoImagem;


                if (fup.HasFile)
                {
                    novoServico.CaminhoImagem = servico.CaminhoImagem;

                    if ((fup.FileName != null) && (fup.FileName != "") && (pastaDestino != null) && (pastaDestino != ""))
                    {

                        if (Util.ExcluirArquivo(pastaDestino + oldPath, null, null))
                        {
                            ok = true;
                        }
                        if (Util.UploadArquivo(fup, pastaDestino + "Servico_" + servico.IdServicos + extensao))
                        {
                            ok = true;
                            novoServico.CaminhoImagem = "Servico_" + servico.IdServicos + extensao;
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
                    msg = "O serviço foi alterado com sucesso.";

                    log = new Log()
                    {

                        IdUsuario = idUsuarioLogado,
                        Mensagem = msg
                    };
                    logBO.Salvar(log);

                    return true;
                }

                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o serviço.";

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
                msg = "Erro ao alterar o serviço. [Erro ao carregar servico do bd]";
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return false;
            }
        }

        public bool Salvar(Servico servico, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            if (servico.IdServicos <= 0)
                return this.Inserir(servico, pastaDestino, extensao, fup, idUsuarioLogado);
            else
                return this.Alterar(servico, pastaDestino, extensao, fup, idUsuarioLogado);
        }

        public bool Excluir(Servico servico, string pastaDestino, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";

            try
            {
                DataContext.BeginTransaction();
                Servico servicoExcluir = this.ConsultarPorId(servico.IdServicos, idUsuarioLogado);
                string caminhoCompleto = pastaDestino + servicoExcluir.CaminhoImagem;
                DataContext.DataContext.Servicos.DeleteOnSubmit(servicoExcluir);

                if (servico.CaminhoImagem != null)
                {

                    if (Util.ExcluirArquivo(caminhoCompleto, null, null))
                    {
                        DataContext.DataContext.SubmitChanges();
                        DataContext.CommitTransaction();

                        msg = "Serviço excluído com sucesso. " + servico.IdServicos;
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
                        msg = "Erro ao excluir o serviço. " + servicoExcluir.IdServicos;

                        return false;
                    }
                }
                DataContext.DataContext.SubmitChanges();
                DataContext.CommitTransaction();

                msg = "Serviço excluído com sucesso. " + servicoExcluir.IdServicos;
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
                msg = "Erro ao excluir o serviço. " + servico.IdServicos + "Erro: " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    DataHora = DateTime.Now,
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                return false;
            }
        }

        public Servico ConsultarPorId(int id, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                return DataContext.DataContext.Servicos.Single(Servico => Servico.IdServicos == id);
            }

            catch (Exception e)
            {
                msg = "Erro ao consultar serviço. " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return null;
            }
        }

        public List<Servico> ConsultarTodos(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Servico in DataContext.DataContext.Servicos select Servico;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar serviço. Erro: " + e.Message + " - " + e.Source;
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

        


    }
}