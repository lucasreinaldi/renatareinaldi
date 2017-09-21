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



        public List<Log> ConsultarTodos()
        {

            try
            {

                var consulta = from Log in DataContext.DataContext.Logs select Log;
                return consulta.ToList();


            }
            catch
            {

                return null;
            }
        }

        public Log ConsultarPorId(int id)
        {
            try
            {
                return DataContext.DataContext.Logs.Single(a => a.IdLog == id);
            }
            catch (Exception e)
            {
                string msgLog = "Erro ao consultar log por id.";

                Log log = new Log() { IdUsuario = null, Mensagem = msgLog };
                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                return null;
            }
        }
    }
}