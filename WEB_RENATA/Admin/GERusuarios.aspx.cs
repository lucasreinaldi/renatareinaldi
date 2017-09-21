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
    public partial class GERusuarios : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Gerenciador de Usuários";

            if (!IsPostBack)
            {
                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 10;

                //masterPage.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
        }

        public List<Usuario> ListarTodos()
        {
            UsuarioBO logBO = new UsuarioBO();
            List<Usuario> lista = logBO.ConsultarTodos();
            return lista;
        }



        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptLogs.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptLogs.DataBind();
        }

        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptLogs.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptLogs.DataBind();
        }

        public void MontarRepeater()
        {
            List<Usuario> lista = new List<Usuario>();
            lista = ListarTodos();

            if (lista != null && lista.Count > 0)
            {
                this.rptLogs.Visible = true;
                pageDs.DataSource = this.MontarDataTable(lista).DefaultView;
                rptLogs.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptLogs.DataBind();
            }
            else
            {
                this.rptLogs.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há usuários.", null);
                this.divResultado.Visible = true;
            }
        }



        private DataTable MontarDataTable(List<Usuario> list)
        {
            UsuarioBO usuarioBO = new UsuarioBO();



            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("email");
            tabela.Columns.Add("endereco");

            tabela.Columns.Add("cidade");
            tabela.Columns.Add("estado");
            tabela.Columns.Add("cep");
            tabela.Columns.Add("bairro");
            tabela.Columns.Add("rua");


            foreach (Usuario lista in list)
            {
                Endereco endereco = usuarioBO.BuscarEndereco(lista);

                DataRow row = tabela.NewRow();

                row["id"] = lista.IdUsuario;
                row["nome"] = lista.Nome;
                row["email"] = lista.Email;


                row["cidade"] = endereco.Cidade;
                row["estado"] = endereco.Estado;
                row["cep"] = endereco.CEP;
                row["bairro"] = endereco.Bairro;
                row["rua"] = endereco.Endereco1;


                tabela.Rows.Add(row);
            }
            return tabela;
        }
    }
}