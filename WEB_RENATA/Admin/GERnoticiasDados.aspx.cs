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
using System.IO;

namespace WEB_RENATA.Admin
{
    public partial class GERnoticiasDados : System.Web.UI.Page
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
                Response.Redirect("GERnoticias.aspx");
            }
        }

        private void Salvar()
        {
            NoticiaBO noticiaBO = new NoticiaBO();

            string idNoticia = this.Request.QueryString["id"];
            string extensao = Path.GetExtension(exampleInputFile.FileName);
            string pastaDestino = this.MapPath("../" + "img/noticias" + "/");

            Noticia noticia = MapearCamposParaObjeto();

            if (noticia != null)
            {
                int id = -1;

                try
                {
                    id = Int32.Parse(this.lblID.Text);
                }
                catch (FormatException)
                {
                    id = -1;
                }

                noticia.IdNoticia = id;
                if (noticiaBO.Salvar(noticia, pastaDestino, extensao, exampleInputFile, null))
                {
                    Session.Add("msgRes", "Noticia salva com sucesso!");
                }
                else
                {
                    Session.Add("msgRes", "Erro ao salvar noticia.");
                }
                Response.Redirect("GERnoticias.aspx");
            }
            else
            {
                lblMsg.Text = "Problema ao salvar noticia.";
                btnSalvar.Focus();
            }
        }

        private bool VerificaExtensao()
        {

            string extensao = Path.GetExtension(exampleInputFile.FileName).ToLower();

            if (Convert.ToInt32(Request.QueryString["id"]) < 0)
            {
                if (exampleInputFile.HasFile)
                {
                    if ((extensao.Equals(".jpg")) || (extensao.Equals(".jpeg")) || (extensao.Equals(".png")))
                    {
                        return true;
                    }
                    else
                    {
                        lblMsg.Text = "Arquivo com extensão inválida. Utilize as extenções 'jpg' e 'png'.";
                        return false;
                    }
                }
                else
                {
                    lblMsg.Text = "Arquivo de imagem não encontrado. Adicione e tente novamente.";
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void MapearObjetosParaCampos(int id)
        {

            NoticiaBO noticiaBO = new NoticiaBO();
            Noticia noticia = noticiaBO.ConsultarPorId(id, null);

            if (noticia != null)
            {
                this.lblID.Text = noticia.IdNoticia.ToString();
                this.txtTitulo.Text = noticia.Titulo.ToString();
                this.txtDescricaoBreve.Text = noticia.DescricaoBreve.ToString();
                this.txtConteudo.Text = noticia.Conteudo.ToString();
                

            }



        }

        public Noticia MapearCamposParaObjeto()
        {
            Noticia noticia = new Noticia();

            noticia.Conteudo = txtConteudo.Text;
            noticia.Titulo = txtTitulo.Text;
            noticia.DescricaoBreve = txtDescricaoBreve.Text;
            noticia.DataPublicacao = DateTime.Now;
            noticia.IdNoticia = Convert.ToInt32(Request.QueryString["id"]);

            return noticia;
        }

        protected void btnSalvar_Click(Object sender, EventArgs e)
        {
            if (VerificaExtensao())
            {
                this.Salvar();
            }
        }
    }
}