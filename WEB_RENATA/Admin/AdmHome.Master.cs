using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_RENATA.Admin
{
    public partial class AdmHome : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // this.ChecarPermissao();
        }

        public static int Totalpaginas
        {
            get; set;
        }
        public static int NumeroP
        {
            get; set;
        }
        public static int NumeroPaginas
        {
            get; set;
        }
        public static int Inicio
        {
            get; set;
        }
        public static string NomePagina
        {
            get; set;
        }
        public static int NumTotalPaginas
        {
            get; set;
        }
        public static int Pagina
        {
            get; set;
        }
        public static Literal ltlpaginas
        {
            get; set;
        }
        public static int IdQuery
        {
            get; set;
        }



        public void ChecarPermissao()
        {
            if (Session["userName"] != null)
            {
                //lnkWelcome.InnerText += Session["New"].ToString();
                //FormsAuthentication.RedirectFromLoginPage(ToString(), true);

            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        #region Paginação

        ///Monta a Páginação da Lista
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

        /// <summary>
        /// Propriedade que manipula a página atual
        /// </summary>
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

        #endregion

        #region Paginação Nova

        /// <summary>
        /// Método Público responsável por montar os números da paginação
        /// </summary>
        /// <returns></returns>
        public static string PaginacaoWeb()
        {
            ltlpaginas = new Literal();

            int indice = (Pagina / 10);
            int indiceInicio = 0;
            int indiceFinal = Totalpaginas;
            int indiceCentral = 5;

            if (indice >= indiceCentral && NumTotalPaginas > Totalpaginas)
            {
                int contDepois = (NumTotalPaginas - indice);
                int contAntes = ((NumTotalPaginas - contDepois) + 1);

                if (contAntes >= indiceCentral && contDepois >= indiceCentral)
                {
                    indiceInicio = (indice - indiceCentral);
                    indiceFinal = (indice + indiceCentral);
                }

                if (contAntes >= indiceCentral && contDepois < indiceCentral)
                {
                    for (int k = 1; k <= contDepois; k++)
                    {
                        if (contDepois == k)
                        {
                            indiceInicio = indice - (Totalpaginas - k);
                            indiceFinal = (indice + k);
                            break;
                        }
                    }
                }
            }

            for (int i = indiceInicio; i < indiceFinal; i++)
            {
                if (i >= NumTotalPaginas)
                {
                    break;
                }
                if (i >= 0)
                {
                    if ((i * 10) == Pagina)
                    {
                        ltlpaginas.Text += "<a class=\"linkPaginacao\" href=\"" + NomePagina + ".aspx?pagina=" + (i * 10) + "\">" + " [" + (i + 1) + "] " + "</a>";
                    }
                    else
                    {
                        ltlpaginas.Text += "<a class=\"linkPaginacao\" href=\"" + NomePagina + ".aspx?pagina=" + (i * 10) + "\">" + " " + (i + 1) + " " + "</a>";
                    }
                }
            }

            return ltlpaginas.Text;
        }

        /// <summary>
        /// Método Público que monta o link Anterior ao número do índice atual da paginação
        /// </summary>
        /// <returns></returns>
        public static string Anterior()
        {
            Pagina = Pagina - 10;

            if (Pagina >= 0)
            {
                return ltlpaginas.Text = "<a class=\"linkPaginacao\" href=\"" + NomePagina + ".aspx?pagina=" + Pagina + "\"> <<< </a>";
            }

            return ltlpaginas.Text = "";
        }

        /// <summary>
        /// Método Público que monta o Próximo link do número do índice atual da paginação
        /// </summary>
        /// <returns></returns>
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

        #endregion
    
}
}