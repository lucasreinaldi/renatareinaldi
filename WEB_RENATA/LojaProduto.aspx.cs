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
using WEB_RENATA.Admin;

namespace WEB_RENATA
{
    public partial class LojaProduto : System.Web.UI.Page
    {
        Home mp;
        public static PagedDataSource pageDs;
                

        protected void Page_Load(object sender, EventArgs e)
        {

            ChecarPermissao();
            mp = (Home)this.Master;
 
            string id = this.Request.QueryString["id"];

            if (id != null)
            {
                if (!this.IsPostBack)
                {
                    if (Session["msgRes"] != null)
                    {

                        mp.DefinirMsgResultado(divResultado, lblResultado, (string)Session["msgRes"], null);
                    }
                    Session["msgRes"] = null;
                    Session.Remove("msgRes");

                    if (Int32.Parse(id) > 0)
                    {
                        MapearObjetosParaCampos(Convert.ToInt32(id));                        
                    }
                }
            }
            else
            {
                Response.Redirect("Loja.aspx");
            }
        }


        public void MapearObjetosParaCampos(int id)
        {
            int qtidade = 0;
            ProdutoBO produtoBO = new ProdutoBO();
            Produto produto = new Produto();

            List<Produto> produtos = (List<Produto>)Session["TodosProdutos"];
            
            foreach (Produto lista in produtos)
            {
                if (lista.IdProduto == id)
                {
                    qtidade = lista.Estoque;
                    produto = lista;
                }
                    
            }
                        
            if (produto != null)
            {
                this.nome.InnerText = produto.Nome.ToString();
                this.descricao.InnerText = produto.Descricao.ToString();
                this.preco.InnerText = "valor: " + produto.Preco.ToString() + " R$";
                this.estoque.InnerText = "qtd: " + qtidade + " un.";

                this.imagem.Src = "img\\produtos\\" + produto.CaminhoImagem.ToString();
            }
        }

        protected void btnAdicionar_Click(Object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.Request.QueryString["id"]);
            List<Produto> produtos = new List<Produto>();
            int qtidadeSelecionada = Convert.ToInt32(txtEstoque.Text);
            produtos = (List<Produto>)Session["TodosProdutos"];

            Produto produto = new Produto();
            ProdutoBO produtoBO = new ProdutoBO();

            foreach (Produto produtoSession in produtos)
            {
                if (produtoSession.IdProduto == id)
                    produto = produtoSession;
            }
            int qtidade = produto.Estoque;
            if (qtidadeSelecionada > qtidade)
            {
                Session.Add("msgRes", "Estoque insuficiente.");
                Response.Redirect("LojaProduto.aspx?id=" + id);
            }
            else
            {
                qtidade = qtidade - Convert.ToInt32(txtEstoque.Text);
                if (Session["Carrinho"] == null)
                {
                    List<CarrinhoSESSION> carrinho = new List<CarrinhoSESSION>();

                    CarrinhoSESSION items = new CarrinhoSESSION
                        (produto.IdProduto, produto.Nome, produto.Preco,
                        qtidadeSelecionada, produto.CaminhoImagem);

                    carrinho.Add(items);
                    Session["Carrinho"] = null;
                    Session.Remove("Carrinho");
                    Session["Carrinho"] = carrinho;

                    foreach (Produto prod in produtos)
                    {
                        if (prod.IdProduto == id)
                            prod.Estoque = qtidade;
                    }

                    Session["TodosProdutos"] = null;
                    Session.Remove("TodosProdutos");
                    Session["TodosProdutos"] = produtos;
                }
                else
                {
                    List<CarrinhoSESSION> carrinho = (List<CarrinhoSESSION>)Session["Carrinho"];

                    CarrinhoSESSION items = new CarrinhoSESSION(produto.IdProduto, produto.Nome,
                        produto.Preco, qtidadeSelecionada, produto.CaminhoImagem);
                    carrinho.Add(items);
                    Session["Carrinho"] = null;
                    Session.Remove("Carrinho");
                    Session["Carrinho"] = carrinho;
                    foreach (Produto prod in produtos)
                    {
                        if (prod.IdProduto == id)
                            prod.Estoque = qtidade;
                    }
                    Session["TodosProdutos"] = null;
                    Session.Remove("TodosProdutos");
                    Session["TodosProdutos"] = produtos;
                }
                Response.Redirect("Carrinho.aspx");
            }
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