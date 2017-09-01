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
        BancoLINQ<renatadatabaseDataContext> DataContext = new BancoLINQ<renatadatabaseDataContext>();

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

        public bool Excluir(Newsletter cliente)
        {

            Newsletter clienteExcluir = this.ConsultarPorId(cliente.IdListaEmail);
            DataContext.DataContext.Newsletters.DeleteOnSubmit(clienteExcluir);
            DataContext.DataContext.SubmitChanges();
            return true;

        }


        private bool Inserir(Newsletter news)
        {
            string msg;
            try
            {
                DataContext.DataContext.Newsletters.InsertOnSubmit(news);
                DataContext.DataContext.SubmitChanges();

                msg = "Cliente inserido com sucesso. " + news.IdListaEmail;

            }
            catch (Exception e)
            {

                msg = "Erro ao inserir o cliente. " + news.IdListaEmail + "Erro: " + e.Message + " - " + e.Source;


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