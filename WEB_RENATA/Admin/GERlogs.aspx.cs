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
    public partial class GERlog : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Gerenciador de Logs";

            if (!IsPostBack)
            {
                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 10;

                //masterPage.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
        }

        public List<Log> ListarTodos()
        {
            LogBO logBO = new LogBO();
            List<Log> lista = logBO.ConsultarTodos();
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
            List<Log> lista = new List<Log>();
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
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há logs.", null);
                this.divResultado.Visible = true;
            }
        }

        private DataTable MontarDataTable(List<Log> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("idUsuario");
            tabela.Columns.Add("mensagem");
            tabela.Columns.Add("data");
                        

            foreach (Log lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdLog;
                row["idUsuario"] = lista.IdUsuario;
                row["mensagem"] = lista.Mensagem;
                row["data"] = lista.DataHora;
                
                tabela.Rows.Add(row);
            }
            return tabela;
        }
    }
}