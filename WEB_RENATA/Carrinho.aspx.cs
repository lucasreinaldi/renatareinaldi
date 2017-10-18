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
    public partial class Carrinho : System.Web.UI.Page
    {
        Home mp;
        public static PagedDataSource pageDs;
        public static List<Produto> produtos;
        public static List<CarrinhoSESSION> carrinhos;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChecarPermissao();

            mp = (Home)this.Master;

            btnFinalizar.Visible = false;
            btnEsvaziar.Visible = false;

            if (!IsPostBack)
            {
                if (Session["msgRes"] != null)
                {
                    
                }
                Session["msgRes"] = null;
                Session.Remove("msgRes");
                
                if (Session["Carrinho"] != null)
                {
                    carrinhos = (List<CarrinhoSESSION>)Session["Carrinho"];                     
                    MontarRepeater(carrinhos);
                    calcularTotal();
                    total.InnerText = "Total: " + Convert.ToString(calcularTotal()) + " R$";
                    btnFinalizar.Visible = true;
                    btnEsvaziar.Visible = true;
                }
                else
                {
                    mp.DefinirMsgResultado(divResultado, lblResultado, "Não há itens no carrinho.", null);
                }
            }
                pageDs = new PagedDataSource();
        }

        private DataTable MontarDataTable(List<CarrinhoSESSION> list)
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("imagem");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("quantidade");
            tabela.Columns.Add("valor");
            
            
            foreach (CarrinhoSESSION lista in list)
            {
                DataRow row = tabela.NewRow();

                row["imagem"] = "\\img\\produtos\\" + lista.caminho;
                row["nome"] = lista.nome;
                row["quantidade"] = lista.quantidade;
                row["valor"] = lista.valor * lista.quantidade;
                
                tabela.Rows.Add(row);
            }
            return tabela;
        }


        public void MontarRepeater(List<CarrinhoSESSION> lista)
        {

            if (lista != null && lista.Count > 0)
            {
                this.rptLoja.Visible = true;
                rptLoja.DataSource = this.MontarDataTable(lista).DefaultView;
                
                rptLoja.DataBind();
            }
            else
            {
                this.rptLoja.Visible = false;
            }
            if (lista.Count == 0)
            {
                
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

        public double calcularTotal()
        {
            double total = 0;
            if (Session["Carrinho"] != null)
            {
                carrinhos = (List<CarrinhoSESSION>)Session["Carrinho"];
                foreach (CarrinhoSESSION lista in carrinhos)
                {
                    total = total + (lista.valor * Convert.ToDouble(lista.quantidade));
                }
                return total;
            }
            else
                return total;
        }

        protected void btnFinalizar_Click(Object sender, EventArgs e)
        {
            Venda venda = new Venda();
            VendaBO vendaBO = new VendaBO();

            venda.FkUsuario = Convert.ToInt32(Session["IdUsuario"]);
            venda.Data = DateTime.Now;
            venda.Subtotal = calcularTotal();
            vendaBO.Finalizar(venda);

            List<Produto> produtos = (List<Produto>)Session["TodosProdutos"];

            ProdutoBO produtoBO = new ProdutoBO();
            produtoBO.AlterarEstoque(produtos);

            Session.Add("msgRes", "Compra finalizada com sucesso.");

            Session["TodosProdutos"] = null;
            Session.Remove("TodosProdutos");
            Session["Carrinho"] = null;
            Session.Remove("Carrinho");

            Response.Redirect("Loja.aspx");
        }

        protected void btnEsvaziar_Click(Object sender, EventArgs e)
        {
            Session["TodosProdutos"] = null;
            Session.Remove("TodosProdutos");
            Session["Carrinho"] = null;
            Session.Remove("Carrinho");
            btnEsvaziar.Visible = false;

            Response.Redirect("Loja.aspx");
        }

        public void ChecarPermissao()
        {
            if (Session["nomeUsuario"] != null)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");

            }
        }
    }
}