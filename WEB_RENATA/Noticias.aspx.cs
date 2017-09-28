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
    public partial class Noticias : System.Web.UI.Page
    {
        Home mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (Home)this.Master;


            if (!IsPostBack)
            {

                if (Session["msgRes"] != null)
                {

                    mp.DefinirMsgResultado(divResultado, lblResultado, (string)Session["msgRes"], null);
                }
                Session["msgRes"] = null;

                Session.Remove("msgRes");

                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 10;



            }


            this.MontarRepeaterNoticias();
        }

        private DataTable MontarDataTable(List<Noticia> list)
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("id");
            tabela.Columns.Add("titulo");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("data");
            tabela.Columns.Add("imagem");

            foreach (Noticia lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdNoticia;
                row["titulo"] = lista.Titulo;
                row["descricao"] = lista.DescricaoBreve;
                row["data"] = lista.DataPublicacao;
                row["imagem"] = "\\img\\noticias\\" + lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }


        public void MontarRepeaterNoticias()
        {

            Noticia noticia = new Noticia();
            NoticiaBO noticiaBO = new NoticiaBO();

            List<Noticia> lista = noticiaBO.ConsultarTodos(null);

            if (lista != null && lista.Count > 0)
            {
                this.rptNoticias.Visible = true;
                pageDs.DataSource = this.MontarDataTable(lista).DefaultView;
                rptNoticias.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptNoticias.DataBind();
            }
            else
            {
                this.rptNoticias.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há serviços cadastrados.", null);
                this.divResultado.Visible = true;
            }

        }

        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptNoticias.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptNoticias.DataBind();
        }


        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptNoticias.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptNoticias.DataBind();
        }

    }
}