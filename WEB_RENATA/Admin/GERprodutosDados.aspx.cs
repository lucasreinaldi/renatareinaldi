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
using System.IO;

namespace WEB_RENATA.Admin
{
    public partial class GERprodutosDados : System.Web.UI.Page
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
                Response.Redirect("GERprodutos.aspx");
            }
        }

        private void Salvar()
        {
            ProdutoBO produtoBO = new ProdutoBO();

            string idNoticia = this.Request.QueryString["id"];
            string extensao = Path.GetExtension(fup.FileName);
            string pastaDestino = this.MapPath("../" + "img/produtos" + "/");

            Produto produto = MapearCamposParaObjeto();

            if (produto != null)
            {
                int id = -1;

                try
                {
                    id = Int32.Parse(this.lblID.Text);
                }
                catch (FormatException)
                {
                    id = -1;
                }

                produto.IdProduto = id;
                if (produtoBO.Salvar(produto, pastaDestino, extensao, fup, null))
                {
                    Session.Add("msgRes", "Produto salvo com sucesso!");
                }
                else
                {
                    Session.Add("msgRes", "Erro ao salvar produto.");
                }
                Response.Redirect("GERprodutos.aspx");
            }
            else
            {
                lblMsg.Text = "Problema ao salvar produto.";
                btnSalvar.Focus();
            }
        }

        private bool VerificaExtensao()
        {

            string extensao = Path.GetExtension(fup.FileName).ToLower();

            if (Convert.ToInt32(Request.QueryString["id"]) < 0)
            {
                if (fup.HasFile)
                {
                    if ((extensao.Equals(".jpg")) || (extensao.Equals(".jpeg")) || (extensao.Equals(".png")))
                    {
                        return true;
                    }
                    else
                    {
                        lblMsg.Text = "Arquivo com extensão inválida. Utilize as extensões 'jpg' e 'png'.";
                        return false;
                    }
                }
                else
                {
                    lblMsg.Text = "Arquivo de imagem não encontrado. Adicione e tente novamente.";
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void MapearObjetosParaCampos(int id)
        {

            ProdutoBO produtoBO = new ProdutoBO();
            Produto produto = produtoBO.ConsultarPorId(id, null);

            if (produto != null)
            {
                this.lblID.Text = produto.IdProduto.ToString();
                this.txtNome.Text = produto.Nome.ToString();
                this.txtDescricao.Text = produto.Descricao.ToString();
                this.txtEstoque.Text = Convert.ToString(produto.Estoque);
                this.txtValor.Text = Convert.ToString(produto.Preco);

            }
        }

        public Produto MapearCamposParaObjeto()
        {
            Produto produto = new Produto();

            produto.Nome = txtNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Preco = Convert.ToDouble(txtValor.Text);
            produto.Estoque = Convert.ToInt32(txtEstoque.Text);

            produto.IdProduto = Convert.ToInt32(Request.QueryString["id"]);

            return produto;
        }

        protected void btnSalvar_Click(Object sender, EventArgs e)
        {
            if (VerificaExtensao())
            {
                this.Salvar();
            }
        }
    }
}