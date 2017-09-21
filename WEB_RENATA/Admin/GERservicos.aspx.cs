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
    public partial class GERservicos : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Gerenciador de Serviços";

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
            this.MontarRepeater();
        }

        private void Excluir(int id)
        {
            string pastaDestino = this.MapPath("..\\img\\servicos\\");

            if (id > 0)
            {
                ServicoBO servicoBO = new ServicoBO();
                Servico servico = new Servico();

                servico.IdServicos = id;

                if (servicoBO.Excluir(servico, pastaDestino, null) == true)
                {
                    mp.DefinirMsgResultado(divResultado, lblResultado, "Serviço excluído com sucesso!", null);
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
            Response.Redirect("GERservicosDados.aspx?id=-0");
        }

        public List<Servico> ListarTodos()
        {
            ServicoBO servicoBO = new ServicoBO();
            List<Servico> lista = servicoBO.ConsultarTodos(null);
            return lista;
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
                this.divResultado.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há serviços cadastrados.", null);
                this.divResultado.Visible = true;
            }
        }


        private DataTable MontarDataTable(List<Servico> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("valor");
            tabela.Columns.Add("caminho");

            foreach (Servico lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdServicos;
                row["nome"] = lista.Nome;
                row["descricao"] = lista.Descricao;
                row["valor"] = lista.Valor;
                row["caminho"] = "..\\img\\servicos\\" + lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
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