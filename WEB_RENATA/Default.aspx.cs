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

namespace WEB_RENATA
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MontarRepeaterNoticias();
        }

        public void MontarRepeaterNoticias()
        {
             
            Noticia noticia = new Noticia();
            NoticiaBO noticiaBO = new NoticiaBO();

            List<Noticia> listaNoticia = noticiaBO.ConsultarTres(null);

            if (listaNoticia != null && listaNoticia.Count > 0)
            {
                this.rptNoticias.Visible = true;
                
                rptNoticias.DataSource = this.MontarDataTable(listaNoticia).DefaultView;
                rptNoticias.DataBind();
            }
            else
            {
                this.rptNoticias.Visible = false;
            }
            if (listaNoticia.Count == 0)
            {
                
            }
        }


        private DataTable MontarDataTable(List<Noticia> list)
        {
            DataTable tabela = new DataTable();
            
            tabela.Columns.Add("titulo");
            tabela.Columns.Add("descricao");
            

            foreach (Noticia lista in list)
            {
                DataRow row = tabela.NewRow();

                row["titulo"] = lista.Titulo;
                 
                row["descricao"] = lista.DescricaoBreve;
                 

                tabela.Rows.Add(row);
            }
            return tabela;
        }
        protected void btnNewsletter_Click(Object sender, EventArgs e)
        {
            NewsletterBO newsletterBO = new NewsletterBO();
            Newsletter newsletter = new Newsletter();

            newsletter.Email = txtNewsletter.Text;

            newsletterBO.Inserir(newsletter);

            if (newsletter != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        
    }
}