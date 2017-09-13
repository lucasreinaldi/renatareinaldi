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
    public class LogBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public bool Salvar(Log log)
        {
            log.DataHora = DateTime.Now;

            return Inserir(log);
        }

       
        private bool Inserir(Log log)
        {
            try
            {
                DataContext.DataContext.Logs.InsertOnSubmit(log);
                DataContext.DataContext.SubmitChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
        
       
        public string FormatarDataMesDiaAno(DateTime data)
        {
            return data.Year + "/" + data.Month + "/" + data.Day;
        }

       

      /*  public List<Log> ConsultarTodos(CategoriaLog categoria, DateTime dataInicio, DateTime dataFim, int? codEvento, int? idUsuario, int? idUsuarioLogado)
        {
            try
            {
                string sql = MontarSQL(categoria, dataInicio, dataFim, idUsuario, codEvento, idUsuarioLogado);
                var consulta = Contexto.DataContext.ExecuteQuery<Log>(sql);

                List<Log> lista = consulta.ToList();

                return lista;
            }
            catch (Exception e)
            {
                string msgLog = "Erro ao Consultar Todos Logs[ConsultarTodos - LogBO.cs][ " + e.Message + " - " + e.Source + " ]";
                Log log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30002, IdUsuario = idUsuarioLogado, Mensagem = msgLog };

                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                return null;
            }
        } */

       /* public Log ConsultarPorId(int id)
        {
            try
            {
                return Contexto.DataContext.Logs.Single(a => a.IdLog == id);
            }
            catch (Exception e)
            {
                string msgLog = "Erro ao Consultar Log Por ID [ConsultarPorId - LogBO.cs][" + e.Message + " - " + e.Source + " ]";

                Log log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30003, IdUsuario = idUsuarioLogado, Mensagem = msgLog };
                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                return null;
            }
        }*/
    }
}