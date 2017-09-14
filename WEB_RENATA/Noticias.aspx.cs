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
        protected void Page_Load(object sender, EventArgs e)
        {
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
                row["imagem"] = lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }


        public void MontarRepeaterNoticias()
        {

            Noticia noticia = new Noticia();
            NoticiaBO noticiaBO = new NoticiaBO();

            List<Noticia> listaNoticia = noticiaBO.ConsultarTodos(null);

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

        }
    }
}