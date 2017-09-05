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
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using REGRA_RENATA;

namespace WEB_RENATA
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Endereco end = new Endereco();
            UsuarioBO usuarioBO = new UsuarioBO();

            usuario.Nome = txtNome.Text;             
            usuario.Email = txtEmail.Text;
            usuario.CPF = txtCpf.Text;
            usuario.fkEndereco = end.IdEndereco;
            
            end.Bairro = txtBairro.Text;
            end.CEP = txtCep.Text;
            end.Cidade = txtCidade.Text;
            end.Estado = txtEstado.Text;
            end.Complemento = txtComplemento.Text;
            end.Endereco1 = txtEndereco.Text;

 
                        
            usuario.Senha = UsuarioBO.CriptografarSenhaSHA1(txtSenha.Text);

             

                try
                {
                    usuarioBO.CriarUsuario(usuario, end);
                    Session.Add("userName", usuario.Nome);
                    Response.Redirect("Admin/Home.aspx");
                }
                catch
                {
                }
            }
             
        }

         
    
}