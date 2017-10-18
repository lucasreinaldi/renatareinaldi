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
    public partial class Loja : System.Web.UI.Page
    {
        Home mp;
        public static PagedDataSource pageDs;
        public static List<Produto> produtos;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (Home)this.Master;

            if (!IsPostBack)
            {
                if (Session["msgRes"] != null)
                {
                    mp.DefinirMsgResultado(divResultado, lblResultado, (string)Session["msgRes"], null);
                }
                if (Session["TodosProdutos"] == null)
                {
                    ColetarSessao();
                }
                Session["msgRes"] = null;

                Session.Remove("msgRes");

                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 10;

                // mp.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");
                
                if (Session["TodosProdutos"] != null)
                {
                    produtos = (List<Produto>)Session["TodosProdutos"];
                    MontarRepeater(produtos);
                }
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
            tabela.Columns.Add("imagem");

            foreach (Produto lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdProduto;
                row["nome"] = lista.Nome;
                row["descricao"] = lista.Descricao;
                row["estoque"] = lista.Estoque;
                row["valor"] = lista.Preco;
                row["imagem"] = "\\img\\produtos\\" + lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }


        public void MontarRepeater(List<Produto> lista)
        {

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
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há produtos.", null);
                this.divResultado.Visible = true;
            }
        }



        public List<Produto> ListarTodos()
        {
            ProdutoBO produtoBO = new ProdutoBO();
            List<Produto> lista = produtoBO.ConsultarTodos(null);
            return lista;
        }

        public void ColetarSessao()
        {
            ProdutoBO produtoBO = new ProdutoBO();
            List<Produto> lista = produtoBO.ConsultarTodos(null);
            Session["TodosProdutos"] = lista;

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
    }
}