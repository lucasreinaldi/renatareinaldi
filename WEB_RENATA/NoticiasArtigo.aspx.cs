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
    public partial class NoticiasArtigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.Request.QueryString["id"];

            if (id != null)
            {
                if (!this.IsPostBack)
                {
                    if (Int32.Parse(id) > 0)
                    {
                        MapearObjetosParaCampos(Convert.ToInt32(id));
                        NoticiaBO noticiaBO = new NoticiaBO();
                        Noticia noticia = noticiaBO.ConsultarPorId(Int32.Parse(id), null);
                    }
                }
            }
            else
            {
                Response.Redirect("Noticias.aspx");
            }
        }





        public void MapearObjetosParaCampos(int id)
        {

            NoticiaBO noticiaBO = new NoticiaBO();
            Noticia noticia = noticiaBO.ConsultarPorId(id, null);

            if (noticia != null)
            {
                this.titulo.InnerText = noticia.Titulo.ToString();
                this.corpo.InnerText = noticia.DescricaoBreve.ToString();
                this.data.InnerText = noticia.DataPublicacao.ToString();
                this.imagem.Src = "img\\noticias\\" + noticia.CaminhoImagem.ToString();


            }



        }


    }
}