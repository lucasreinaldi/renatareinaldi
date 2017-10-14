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
        AdmHome mp;
        public static PagedDataSource pageDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Produto";

            List<Produto> produtos;

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
                        ProdutoBO produtoBO = new ProdutoBO();
                        Produto produto = produtoBO.ConsultarPorId(Int32.Parse(id), null);

                        produtos = (List<Produto>)Session["Carrinho"];

                        List<Produto> listprodutos;

                        foreach (Produto c in produtos)
                            listprodutos = produtos;
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

            ProdutoBO produtoBO = new ProdutoBO();
            Produto produto = produtoBO.ConsultarPorId(id, null);

            List<Produto> produtos = (List<Produto>)Session["Carrinho"];

            Produto listprodutos;

            foreach (Produto c in produtos)
                //listprodutos = produtos;

            
            if (produto != null)
            {
                this.nome.InnerText = produto.Nome.ToString();
                this.descricao.InnerText = produto.Descricao.ToString();
                this.preco.InnerText = "valor: " + produto.Preco.ToString() + " R$";
             //   this.estoque.InnerText = "qtd: " + listprodutos.IdProduto + " un.";

                this.imagem.Src = "img\\produtos\\" + produto.CaminhoImagem.ToString();
            }
        }

        protected void btnAdicionar_Click(Object sender, EventArgs e)
        {

            int qtidade = (int)Session["qtd"];
            int id = (int)Session["IdProduto"];

            if (Convert.ToInt32(txtEstoque.Text) > qtidade)
            {
                Session.Add("msgRes", "Estoque insuficiente.");
                Response.Redirect("LojaProduto.aspx");
            }
            else
            {
                qtidade = qtidade - Convert.ToInt32(txtEstoque.Text);
                Session["qtd"] = qtidade;
                Response.Redirect("LojaProduto.aspx");
            }
        }
    }
}