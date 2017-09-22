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
    public partial class GERprodutos : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Gerenciador de Produtos";

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

                //masterPage.ValidarQueryString(Request.QueryString["id"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
        }

        private void Excluir(int id)
        {
            string pastaDestino = this.MapPath("..\\img\\produtos\\");

            if (id > 0)
            {
                ProdutoBO produtoBO = new ProdutoBO();
                Produto produto = new Produto();

                produto.IdProduto = id;

                if (produtoBO.Excluir(produto, pastaDestino, null) == true)
                {
                    mp.DefinirMsgResultado(divResultado, lblResultado, "Produto excluido com sucesso!", null);
                    this.MontarRepeater();
                }
            }
        }

        protected void Excluir_Click(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            this.Excluir(id);
        }

        protected void btnAprovar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("GERprodutosDados.aspx?id=0");
        }

        public List<Produto> ListarTodos()
        {
            ProdutoBO produtosBO = new ProdutoBO();
            List<Produto> lista = produtosBO.ConsultarTodos(null);
            return lista;
        }

        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptProdutos.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptProdutos.DataBind();
        }

        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptProdutos.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptProdutos.DataBind();
        }

        public void MontarRepeater()
        {
            List<Produto> lista = new List<Produto>();
            lista = ListarTodos();

            if (lista != null && lista.Count > 0)
            {
                this.rptProdutos.Visible = true;
                pageDs.DataSource = this.MontarDataTable(lista).DefaultView;
                rptProdutos.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptProdutos.DataBind();
            }
            else
            {
                this.rptProdutos.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há produtos cadastrados.", null);
                this.divResultado.Visible = true;
            }
        }

        private DataTable MontarDataTable(List<Produto> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("valor");
            tabela.Columns.Add("estoque");
            tabela.Columns.Add("caminho");

            foreach (Produto produto in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = produto.IdProduto;
                row["nome"] = produto.Nome;
                row["valor"] = produto.Preco + " R$";
                row["descricao"] = produto.Descricao;
                row["estoque"] = produto.Estoque + " un.";
                row["caminho"] = "..\\img\\produtos\\" + produto.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }

    }
}