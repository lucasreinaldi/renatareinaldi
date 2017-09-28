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
    public partial class Servicos : System.Web.UI.Page
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
                pageDs.PageSize = 5;

                // mp.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");

            }

            
            MontarRepeater();



        }

        private DataTable MontarDataTable(List<Servico> list)
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("id");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("valor");
            tabela.Columns.Add("imagem");

            foreach (Servico lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdServicos;
                row["nome"] = lista.Nome;
                row["descricao"] = lista.Descricao;
                row["valor"] = lista.Valor;
                row["imagem"] = "\\img\\servicos\\" + lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }


        public void MontarRepeater()
        {
            List<Servico> lista = new List<Servico>();
            lista = ListarTodos();

            if (lista != null && lista.Count > 0)
            {
                this.rptServicos.Visible = true;
                pageDs.DataSource = this.MontarDataTable(lista).DefaultView;
                rptServicos.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptServicos.DataBind();
            }
            else
            {
                this.rptServicos.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há serviços cadastrados.", null);
                this.divResultado.Visible = true;
            }
        }

        public List<Servico> ListarTodos()
        {
            ServicoBO servicoBO = new ServicoBO();
            List<Servico> lista = servicoBO.ConsultarTodos(null);
            return lista;
        }

        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptServicos.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptServicos.DataBind();
        }

        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptServicos.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptServicos.DataBind();
        }
    }
}