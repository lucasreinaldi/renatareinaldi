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
    public partial class LojaProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.Request.QueryString["id"];

            if (id != null)
            {
                if (!this.IsPostBack)
                {
                    if (Int32.Parse(id) > 0)
                    {
                        MapearObjetosParaCampos(Convert.ToInt32(id));
                        ProdutoBO produtoBO = new ProdutoBO();
                        Produto produto = produtoBO.ConsultarPorId(Int32.Parse(id), null);
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

            if (produto != null)
            {
                this.nome.InnerText = produto.Nome.ToString();
                this.descricao.InnerText = produto.Descricao.ToString();
                this.preco.InnerText = produto.Preco.ToString() + " R$";
                this.estoque.InnerText = produto.Estoque.ToString() + " un.";


                 
                this.imagem.Src = "img\\produtos\\" + produto.CaminhoImagem.ToString();


            }



        }

        protected void btnAdicionar_Click(Object sender, EventArgs e)
        {

        }
    }
}