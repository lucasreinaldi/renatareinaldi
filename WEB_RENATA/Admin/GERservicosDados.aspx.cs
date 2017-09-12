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
    public partial class GERservicosDados : System.Web.UI.Page
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
                        ServicoBO servicoBO = new ServicoBO();
                        Servico servico = servicoBO.ConsultarPorId(Int32.Parse(id));
                    }                    
                }
            }
            else
            {
                Response.Redirect("GERservicos.aspx");
            }
        }

        private void Salvar()
        {
            ServicoBO servicoBO = new ServicoBO();

            string idServico = this.Request.QueryString["id"];
            string extensao = Path.GetExtension(exampleInputFile.FileName);
            string pastaDestino = this.MapPath("../" + "img/servicos" + "/");

            Servico servico = MapearCamposParaObjeto();

            if (servico != null)
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

                servico.IdServicos = id;
                if (servicoBO.Salvar(servico, pastaDestino, extensao, exampleInputFile))
                {                    
                    Session.Add("msgRes", "Release salvo com sucesso!");
                }
                else
                {                    
                    Session.Add("msgRes", "Erro ao salvar release!");
                }
                Response.Redirect("GERservicos.aspx");
            }
            else
            {
                lblMsg.Text = "Problema ao salvar release.";
                btnSalvar.Focus();
            }
        }

        private bool VerificaExtensao()
        {

            string extensao = Path.GetExtension(exampleInputFile.FileName).ToLower();

            if (Convert.ToInt32(Request.QueryString["id"]) < 0)
            {
                if (exampleInputFile.HasFile)
                {
                    if ((extensao.Equals(".jpg")) || (extensao.Equals(".jpeg")) || (extensao.Equals(".png")))
                    {
                        return true;
                    }
                    else
                    {
                        lblMsg.Text = "Arquivo com extensão inválida. Utilize as extenções 'jpg' e 'png'.";
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
             
            ServicoBO servicoBO = new ServicoBO();
            Servico servico = servicoBO.ConsultarPorId(id);

            if (servico != null)
            {
                 
                this.lblID.Text = servico.IdServicos.ToString();
                this.txtDescricao.Text = servico.Descricao.ToString();
                this.txtNome.Text = servico.Nome.ToString();
                this.txtValor.Text = servico.Valor.ToString();
                                
            }

             

        }

        public Servico MapearCamposParaObjeto()
        {
            Servico servico = new Servico();

            servico.Nome = txtNome.Text;
            servico.Descricao = txtDescricao.Text;
            servico.Valor = Convert.ToDecimal(txtValor.Text);             
            servico.IdServicos = Convert.ToInt32(Request.QueryString["id"]);

            return servico;
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