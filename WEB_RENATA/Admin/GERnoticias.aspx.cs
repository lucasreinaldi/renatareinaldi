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

namespace WEB_RENATA.Admin
{
    public partial class GERnoticias : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Gerenciador de Notícias";

            if (!IsPostBack)
            {
                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 10;

                //masterPage.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
        }

        private void Excluir(int id)
        {
            string pastaDestino = this.MapPath("..\\img\\noticias\\");

            if (id > 0)
            {
                NoticiaBO noticiaBO = new NoticiaBO();
                Noticia noticia = new Noticia();

                noticia.IdNoticia = id;

                if (noticiaBO.Excluir(noticia, pastaDestino, null) == true)
                {
                    mp.DefinirMsgResultado(divResultado, lblResultado, "Noticia excluida com sucesso!", null);
                    this.MontarRepeater();
                }
            }
        }

        protected void Excluir_Click(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            this.Excluir(id);
        }

        protected void btnAdicionar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("GERnoticiasDados.aspx?id=-1");
        }

        public List<Noticia> ListarTodos()
        {
            NoticiaBO noticiaBO = new NoticiaBO();
            List<Noticia> lista = noticiaBO.ConsultarTodos(null);
            return lista;
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

        

        public void MontarRepeater()
        {
            List<Noticia> lista = new List<Noticia>();
            lista = ListarTodos();

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


        private DataTable MontarDataTable(List<Noticia> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("titulo");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("conteudo");
            tabela.Columns.Add("data");
            tabela.Columns.Add("caminho");

            foreach (Noticia lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdNoticia;
                row["titulo"] = lista.Titulo;
                row["conteudo"] = lista.Conteudo;
                row["descricao"] = lista.DescricaoBreve;
                row["data"] = lista.DataPublicacao;
                row["caminho"] = "..\\img\\noticias\\" + lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }

      
    }
}