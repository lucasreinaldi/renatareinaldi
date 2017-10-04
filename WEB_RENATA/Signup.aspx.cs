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
            PreencherEstados(dropEstados, true);
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
            end.Estado = dropEstados.Text;
            end.Complemento = txtComplemento.Text;
            end.Endereco1 = txtEndereco.Text;



            usuario.Senha = UsuarioBO.CriptografarSenhaSHA1(txtSenha.Text);

            try
            {
                if (usuarioBO.CriarUsuario(usuario, end))
                {

                    Session.Add("nomeUsuario", usuario.Nome);
                    Session.Add("IdUsuario", usuario.IdUsuario);
                   
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session.Add("msgRes", "Erro ao criar usuário.");
                    Response.Redirect("Login.aspx");
                }
            }
            catch
            {
            }
        }

        public void PreencherEstados(DropDownList dropEstados, bool comLinhaInicial)
        {
            dropEstados.Items.Clear();

            if (comLinhaInicial)
            {
                 
            }
            dropEstados.Items.Add(new ListItem("Acre", "AC"));
            dropEstados.Items.Add(new ListItem("Alagoas", "AL"));
            dropEstados.Items.Add(new ListItem("Amapá", "AP"));
            dropEstados.Items.Add(new ListItem("Amazona", "AM"));
            dropEstados.Items.Add(new ListItem("Bahia", "BA"));
            dropEstados.Items.Add(new ListItem("Ceará", "CE"));
            dropEstados.Items.Add(new ListItem("Distrito Federal", "DF"));
            dropEstados.Items.Add(new ListItem("Espírito Santo", "ES"));
            dropEstados.Items.Add(new ListItem("Goiás", "GO"));
            dropEstados.Items.Add(new ListItem("Maranhão", "MA"));
            dropEstados.Items.Add(new ListItem("Mato Grosso", "MT"));
            dropEstados.Items.Add(new ListItem("Mato Grosso do Sul", "MS"));
            dropEstados.Items.Add(new ListItem("Minas Gerais", "MG"));
            dropEstados.Items.Add(new ListItem("Pará", "PA"));
            dropEstados.Items.Add(new ListItem("Paraíba", "PB"));
            dropEstados.Items.Add(new ListItem("Paraná", "PR"));
            dropEstados.Items.Add(new ListItem("Pernambuco", "PE"));
            dropEstados.Items.Add(new ListItem("Piauí", "PI"));
            dropEstados.Items.Add(new ListItem("Rio de Janeiro", "RJ"));
            dropEstados.Items.Add(new ListItem("Rio Grande do Norte", "RN"));
            dropEstados.Items.Add(new ListItem("Rio Grande do Sul", "RS"));
            dropEstados.Items.Add(new ListItem("Rondônia", "RO"));
            dropEstados.Items.Add(new ListItem("Roraima", "RR"));
            dropEstados.Items.Add(new ListItem("Santa Catarina", "SC"));
            dropEstados.Items.Add(new ListItem("São Paulo", "SP"));
            dropEstados.Items.Add(new ListItem("Sergipe", "SE"));
            dropEstados.Items.Add(new ListItem("Tocantins", "TO"));
        }
    }
}