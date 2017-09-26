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
    public class AtendimentoBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public Atendimento ConsultarPorId(int id, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                return DataContext.DataContext.Atendimentos.Single(Atendimento => Atendimento.IdAtendimento == id);
            }

            catch (Exception e)
            {
                msg = "Erro ao consultar atendimentos por id. " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return null;
            }
        }

        public List<Atendimento> ConsultarTodos(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Atendimento in DataContext.DataContext.Atendimentos where Atendimento.Estado == 0 select Atendimento;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar todos atendimento. Erro: " + e.Message + " - " + e.Source;
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

        public List<Atendimento> ConsultarAprovados(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Atendimento in DataContext.DataContext.Atendimentos where Atendimento.Estado == 1 select Atendimento;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar todos atendimentos aprovados. Erro: " + e.Message + " - " + e.Source;
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

        public List<Atendimento> ConsultarDesaprovados(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Atendimento in DataContext.DataContext.Atendimentos where Atendimento.Estado == 2 select Atendimento;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar todos atendimentos aprovados. Erro: " + e.Message + " - " + e.Source;
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

        public bool Agendar(Atendimento atendimento, Servico servico, int? idUsuarioLogado, int estado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            
            try
            {

                DataContext.BeginTransaction();
                DataContext.DataContext.Atendimentos.InsertOnSubmit(atendimento);
                DataContext.DataContext.SubmitChanges();


                DataContext.CommitTransaction();
                msg = "Serviço " + servico.IdServicos + "consumido! Usuário: " + idUsuarioLogado;

                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao consumir o serviço. [" + e.Message + "][" + e.Source + "]";

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

        public bool Aprovar(Atendimento atendimento, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            
            try
            {

                DataContext.BeginTransaction();

                Atendimento novo = this.ConsultarPorId(atendimento.IdAtendimento, null);
                novo.Comentario = atendimento.Comentario;
                novo.Data = atendimento.Data;
                novo.DataAtendimento = atendimento.DataAtendimento;
                novo.Estado = 1;
                novo.FkAdmin = atendimento.FkAdmin;
                novo.FkServico = atendimento.FkServico;
                novo.FkUsuario = atendimento.FkUsuario;
                novo.IdAtendimento = atendimento.IdAtendimento;
                novo.Resposta = atendimento.Resposta;


                DataContext.DataContext.SubmitChanges();


                DataContext.CommitTransaction();
                msg = "Atendimento aprovado com sucesso. " + atendimento.IdAtendimento;

                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao aprovar atendimento. " + atendimento.IdAtendimento;

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

        public bool Desaprovar(Atendimento atendimento, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";


            try
            {

                DataContext.BeginTransaction();

                Atendimento novo = this.ConsultarPorId(atendimento.IdAtendimento, null);
                novo.Comentario = atendimento.Comentario;
                novo.Data = atendimento.Data;
                novo.DataAtendimento = atendimento.DataAtendimento;
                novo.Estado = 2;
                novo.FkAdmin = atendimento.FkAdmin;
                novo.FkServico = atendimento.FkServico;
                novo.FkUsuario = atendimento.FkUsuario;
                novo.IdAtendimento = atendimento.IdAtendimento;
                novo.Resposta = atendimento.Resposta;


                DataContext.DataContext.SubmitChanges();


                DataContext.CommitTransaction();
                msg = "Atendimento desaprovado com sucesso. " + atendimento.IdAtendimento;

                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao desaprovar atendimento. " + atendimento.IdAtendimento;

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
        
    }
}