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
    public class NewsletterBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public List<Newsletter> ConsultarTodos()
        {

            try
            {

                var consulta = from Newsletter in DataContext.DataContext.Newsletters select Newsletter;
                return consulta.ToList();


            }
            catch
            {

                return null;
            }
        }

        public bool Excluir(Newsletter news)
        {

            Newsletter exclusao = this.ConsultarPorId(news.IdListaEmail);
            DataContext.DataContext.Newsletters.DeleteOnSubmit(exclusao);
            DataContext.DataContext.SubmitChanges();
            return true;

        }


        public bool Inserir(Newsletter news)
        {
            Util util = new Util();
            String ip = util.PegarIp();

            news.Data = DateTime.Now;
            news.IP = ip;

            string msg;
            try
            {
                DataContext.DataContext.Newsletters.InsertOnSubmit(news);
                DataContext.DataContext.SubmitChanges();

                msg = "Email inserido com sucesso. " + news.IdListaEmail;

            }
            catch (Exception e)
            {

                msg = "Erro ao inserir a . " + news.IdListaEmail + "Erro: " + e.Message + " - " + e.Source;


                return false;
            }

            return true;
        }

        public Newsletter ConsultarPorId(int idCliente)
        {

            try
            {
                return DataContext.DataContext.Newsletters.Single(Newsletter => Newsletter.IdListaEmail == idCliente);
            }

            catch (Exception e)
            {

                return null;
            }
        }



    }
}