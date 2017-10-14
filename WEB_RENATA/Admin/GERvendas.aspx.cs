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
    public partial class GERvendas : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;


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
                pageDs.PageSize = 20;

                //masterPage.ValidarQueryString(Request.QueryString["id"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();

        }



        public List<Venda> ListarTodos()
        {
            VendaBO vendaBO = new VendaBO();
            List<Venda> lista = vendaBO.ConsultarTodos(null);
            return lista;
        }        


        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptVendas.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptVendas.DataBind();
        }

        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptVendas.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptVendas.DataBind();
        }

        public void MontarRepeater()
        {
            List<Venda> lista = new List<Venda>();
            lista = ListarTodos();

            if (lista != null && lista.Count > 0)
            {
                this.rptVendas.Visible = true;
                pageDs.DataSource = this.MontarDataTable(lista).DefaultView;
                rptVendas.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptVendas.DataBind();
            }
            else
            {
                this.rptVendas.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há vendas.", null);
                this.divResultado.Visible = true;
            }
        }


        private DataTable MontarDataTable(List<Venda> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("usuario");
            tabela.Columns.Add("data");
            tabela.Columns.Add("subtotal");
            


            foreach (Venda venda in list)
            {
                Usuario usuario = new Usuario();
                UsuarioBO usuarioBO = new UsuarioBO();

                //usuario = usuarioBO.ConsultarPorId(atend.FkUsuario); 

                usuario = usuarioBO.ConsultarPorId(venda.FkUsuario);


                DataRow row = tabela.NewRow();

                row["id"] = venda.IdCompra;
                row["usuario"] = usuario.Email;
                row["data"] = venda.Data;
                row["subtotal"] = venda.Subtotal;

                tabela.Rows.Add(row);
            }
            return tabela;
        }
    }
}