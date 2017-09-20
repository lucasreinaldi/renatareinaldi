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
    public partial class Login : System.Web.UI.Page
    {
        Home mp;

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (Home)this.Master;

            this.Page.Title = "LOGIN";

            this.btnLogar.Focus();

            divResultado.Visible = false;

            if (!IsPostBack)
            {
                string mensagem = "Usuário ou senha inválidos. Tente novamente.";
                lblResultado.Text = mensagem;
                divResultado.Visible = true;

                this.btnLogar.Focus();

            }

            
        }

         
        public void EfetuarLogin()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                try
                {
                    Session.Clear();  
                    Session.Abandon();  
                    FormsAuthentication.SignOut();
                }
                catch (HttpException e)
                {
                    string mensagem = "Erro - Não foi possível deslogar o usuário." + e;

                    Log log = new Log() {



                        IdUsuario = Convert.ToInt32(mp.ID),
                        DataHora = DateTime.Now,
                        Mensagem = mensagem };

                    

                    LogBO logBO = new LogBO();
                    logBO.Salvar(log);
                }
            }

            string login = this.txtNome.Text;
            string senhaDigitada = this.txtSenha.Text;

            bool isAutenticado = false;

            UsuarioBO usuarioBO = new UsuarioBO();

            Usuario usuario = new Usuario();

            usuario = usuarioBO.ConsultarPorLogin(login, null);

            if (usuario != null)
            {
                byte[] senhaCripto = UsuarioBO.CriptografarSenhaSHA1(senhaDigitada);

                if (UsuarioBO.CompararSenhas(senhaCripto, usuario.Senha))
                {                    
                    Session.Add("nomeUsuario", usuario.Nome);

                    FormsAuthentication.RedirectFromLoginPage(usuario.IdUsuario.ToString(), false);
                    isAutenticado = true;
                    
                }
            }
            else
            {
                isAutenticado = false;

                string mensagem = "Um usuário não conseguiu efetuar o login. " + login;
                Log log = new Log() { IdUsuario = null, DataHora = DateTime.Now, Mensagem = mensagem };
                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                this.btnLogar.Focus();
            }
            if (!isAutenticado)
            {

                Response.Redirect("Login.aspx");
                
                
            }
        }
              
                
        protected void btnLogar_Click(Object sender, EventArgs e)
        {
            this.EfetuarLogin();
        }

        protected void btnCadastrar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}