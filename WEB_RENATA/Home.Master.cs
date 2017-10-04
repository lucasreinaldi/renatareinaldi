using DAL_RENATA;
using REGRA_RENATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WEB_RENATA
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ChecarPermissao();
            
        }


        public static int Totalpaginas
        {
            get;
            set;
        }
        public static int NumeroP
        {
            get;
            set;
        }
        public static int NumeroPaginas
        {
            get;
            set;
        }
        public static int Inicio
        {
            get;
            set;
        }
        public static string NomePagina
        {
            get;
            set;
        }
        public static int NumTotalPaginas
        {
            get;
            set;
        }
        public static int Pagina
        {
            get;
            set;
        }
        public static Literal ltlpaginas
        {
            get;
            set;
        }
        public static int IdQuery
        {
            get;
            set;
        }

        public int IdUsuario
        {
            get
            {
                int id = -1;
                try
                {
                    id = Int32.Parse(Context.User.Identity.Name);
                }
                catch (Exception)
                {
                    return -1;
                }
                return id;
            }
        }


        public int ValidarQueryString(string queryString, string pagina)
        {
            try
            {
                if (queryString == null)
                {
                    Response.Redirect(pagina);
                }

                int valor = Int32.Parse(queryString);

                if (valor > 0)
                {
                    return valor;
                }
                else if (valor == 0)
                {
                    return 0;
                }

                Response.Redirect(pagina);
            }
            catch (FormatException)
            {
                Response.Redirect(pagina);
            }
            catch (OverflowException)
            {
                Response.Redirect(pagina);
            }

            return -1;
        }

        public void ChecarPermissao()
        {
            if (Session["nomeUsuario"] != null)
            {
                //lnkWelcome.InnerText += Session["New"].ToString();
                //FormsAuthentication.RedirectFromLoginPage(ToString(), true);
                this.ConfigurarDadosUsuario();

                user.InnerHtml = "Bem vindo " + Session["nomeUsuario"].ToString();
            }
            else
            {
                login.Visible = true;
                logout.Visible = false;
                painel.Visible = false;
                adm.Visible = false;

            }
        }

        private void ConfigurarDadosUsuario()
        {
            if (Session["IdUsuario"] == null)
            {
                login.Visible = true;
                logout.Visible = false;
                painel.Visible = false;
                adm.Visible = false;
                carrinho.Visible = false;
            }
            else
            {
                UsuarioBO usuBO = new UsuarioBO();
                Usuario usuario = usuBO.ConsultarPorId(Int32.Parse(Session["IdUsuario"].ToString()));

                if (usuario.TipoUsuario == 1)
                {
                    carrinho.Visible = false;
                    logout.Visible = true;
                    adm.Visible = true;
                    login.Visible = false;
                    painel.Visible = false;

                }
                else
                {
                    if (usuario.TipoUsuario == 0)
                    {
                        logout.Visible = true;
                        painel.Visible = true;
                        login.Visible = false;
                        adm.Visible = false;
                        carrinho.Visible = true;
                    }

                }
            }
                
        }

        public void RecarregarSessao()
        {
            try
            {
                UsuarioBO usuBO = new UsuarioBO();
                Usuario usuario = usuBO.ConsultarPorId(this.IdUsuario);

                if (usuario != null)
                {
                    Session["userName"] = usuario.Nome;
                }
                else
                {
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logout.aspx");
                }
            }
            catch (Exception ex)
            {
                // Desloga o Usuario
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();

                throw ex;
            }
        }

        public void DefinirMsgResultado(HtmlGenericControl divResultado, Label lblMsg, string msg, LinkButton btnFoco)
        {
            if (btnFoco != null)
            {
                btnFoco.Focus();
            }

            divResultado.Attributes["class"] = "formlinhamsg";


            lblMsg.Text = msg;

            Session["msgRes"] = null;
            Session["msgTipo"] = null;
        }

      
        public PagedDataSource MontarListaPaginada(PagedDataSource pageDs, Label lblCurrentPage, LinkButton lbtAnterior, LinkButton lbtProximo)
        {
            lblCurrentPage.Text = (CurrentPage + 1).ToString() + " de <b>"
            + pageDs.PageCount.ToString() + "</b>";

            pageDs.CurrentPageIndex = CurrentPage;

            if (pageDs.PageCount == 1 && CurrentPage + 1 == 1)
            {
                lblCurrentPage.Visible = false;
            }
            else
            {
                lblCurrentPage.Visible = true;
            }

            lbtAnterior.Visible = !pageDs.IsFirstPage;
            lbtProximo.Visible = !pageDs.IsLastPage;

            if (pageDs.Count <= 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
            }

            return pageDs;
        }

       public int CurrentPage
        {
            get
            {
                object o = this.ViewState["_CurrentPage"];
                if (o == null || (int)o < 0)
                    return 0;
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

       

       public static string Anterior()
        {
            Pagina = Pagina - 10;

            if (Pagina >= 0)
            {
                return ltlpaginas.Text = "<a class=\"linkPaginacao\" href=\"" + NomePagina + ".aspx?pagina=" + Pagina + "\"> <<< </a>";
            }

            return ltlpaginas.Text = "";
        }
              
        public string Proximo()
        {

            Pagina = Pagina + 10;
            IdQuery = IdQuery + Inicio;

            Pagina = Pagina + 10;
            IdQuery = IdQuery + Inicio;

            if ((NumTotalPaginas * 10) > Pagina)
            {
                return ltlpaginas.Text = "<a class=\"linkPaginacao\" href=\"" + NomePagina + ".aspx?pagina=" + Pagina + "\"> >>> </a>";
            }

            return ltlpaginas.Text = "";
        }

       
    }
}