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

namespace WEB_RENATA.ADM
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        ADM mp;
        public static PagedDataSource pageDs;
         

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (ADM)this.Master;
            this.Page.Title = "Lista de E-mails";
            
            if (!IsPostBack)
            {
                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 20;

                //masterPage.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
        }

        protected void imbExcluirEmail_Click(object sender, CommandEventArgs e)
        {
            
            //if (this.hidID.Value != null && int.Parse(hidID.Value) > 0)
            //{
                NewsletterBO newsletterBO = new NewsletterBO();
                Newsletter newsletter = new Newsletter();

                newsletter.IdListaEmail = int.Parse(hidID.Value);

                if (newsletterBO.Excluir(newsletter) == true)
                {
                   // masterPage.DefinirMsgResultado(divResultado, TipoMensagemLabel.Sucesso, lblResultado, "Cliente excluído com sucesso!", null);

                    this.MontarRepeater();
                }
                else
                {
                    
                    this.MontarRepeater();
                }

               // divResultado.Visible = true;
          //  }


        }

        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptNewsletter.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptNewsletter.DataBind();
        }


        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptNewsletter.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptNewsletter.DataBind();
        }


         

        public void MontarRepeater()
        {
            NewsletterBO newsletterBO  = new NewsletterBO();
            List<Newsletter> listaNewsletter = newsletterBO.ConsultarTodos();

            if (listaNewsletter != null && listaNewsletter.Count > 0)
            {
                this.rptNewsletter.Visible = true;
                pageDs.DataSource = this.MontarDataTable(listaNewsletter).DefaultView;
                rptNewsletter.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptNewsletter.DataBind();
            }
            else
            {
                this.rptNewsletter.Visible = false;
            }
            if (listaNewsletter.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
               // mp.DefinirMsgResultado(divResultado, TipoMensagemLabel.Aviso, lblResultado, "Não há clientes cadastrados.", null);
               // this.divResultado.Visible = true;
            }
        }


        private DataTable MontarDataTable(List<Newsletter> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("ip");
            tabela.Columns.Add("data");
            tabela.Columns.Add("email");

            foreach (Newsletter lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdListaEmail;
                row["ip"] = lista.IP;
                row["data"] = lista.Data;
                row["email"] = lista.Email;

                tabela.Rows.Add(row);
            }
            return tabela;
        }


    }
}