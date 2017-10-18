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
    public partial class Painel : System.Web.UI.Page
    {
        Home mp;
        public static PagedDataSource pageDs;
        int idUsuarioLogado; 

        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (Home)this.Master;

            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
                idUsuarioLogado = Int32.Parse(Session["IdUsuario"].ToString());

            if (!IsPostBack)
            {
                if (Session["msgRes"] != null)
                {

                    mp.DefinirMsgResultado(divResultado, lblResultado, (string)Session["msgRes"], null);
                }
                Session["msgRes"] = null;

                Session.Remove("msgRes");


                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 10;

                //masterPage.ValidarQueryString(Request.QueryString["id"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
            this.MontarRepeaterVendas();
        }


        public List<Venda> ListarTodasVendas()
        {
            VendaBO vendaBO = new VendaBO();
            List<Venda> lista = vendaBO.ConsultarTodos(idUsuarioLogado);
            return lista;
        }


        public List<Atendimento> ListarTodos()
        {
            AtendimentoBO atendimentoBO = new AtendimentoBO();
            List<Atendimento> lista = atendimentoBO.ConsultarTodosPorId(idUsuarioLogado);
            return lista;
        }
 

        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptAtendimento.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptAtendimento.DataBind();
        }

        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptAtendimento.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptAtendimento.DataBind();
        }

        public void MontarRepeater()
        {
            List<Atendimento> lista = new List<Atendimento>();
            lista = ListarTodos();

            if (lista != null && lista.Count > 0)
            {
                this.rptAtendimento.Visible = true;
                pageDs.DataSource = this.MontarDataTable(lista).DefaultView;
                rptAtendimento.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptAtendimento.DataBind();
            }
            else
            {
                this.rptAtendimento.Visible = false;
            }
            if (lista.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há atendimentos.", null);
                this.divResultado.Visible = true;
                
            }
        }

        public void MontarRepeaterVendas()
        {
            List<Venda> lista = new List<Venda>();
            lista = ListarTodasVendas();

            if (lista != null && lista.Count > 0)
            {
                this.rptVenda.Visible = true;
                rptVenda.DataSource = this.MontarDataTableVenda(lista).DefaultView;
                
                rptVenda.DataBind();

               
            }
            else
            {
                this.rptVenda.Visible = false;
            }
            if (lista.Count == 0)
            {
                 
                mp.DefinirMsgResultado(divResultado, lblResultado, "Não há vendas.", null);
                this.divResultado.Visible = true;

            }
        }


        private DataTable MontarDataTable(List<Atendimento> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("servico");
             
            tabela.Columns.Add("dataAtend");
            tabela.Columns.Add("comentario");
            tabela.Columns.Add("resposta");
            tabela.Columns.Add("estado");
            tabela.Columns.Add("usuario");


            foreach (Atendimento atend in list)
            {
                Usuario usuario = new Usuario();
                UsuarioBO usuarioBO = new UsuarioBO();

                 
                string resultado = "Em aprovação";

                if (atend.Estado == 1)
                {
                    resultado = "Aprovado";
                     


                }
                if (atend.Estado == 2)
                {
                    resultado = "Desaprovado";
                }

                Servico servico = new Servico();
                ServicoBO servicoBO = new ServicoBO();

                servico = servicoBO.ConsultarPorId(atend.FkServico, null);

                DataRow row = tabela.NewRow();

                row["id"] = atend.IdAtendimento;
                row["servico"] = servico.Nome;
                row["dataAtend"] = atend.DataAtendimento;
                row["resposta"] = atend.Resposta;
                row["comentario"] = atend.Comentario;
                row["estado"] = resultado;
                 
                tabela.Rows.Add(row);
            }
            return tabela;
        }


        private DataTable MontarDataTableVenda(List<Venda> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("total");
            tabela.Columns.Add("data");
             

            foreach (Venda venda in list)
            {
                DataRow row = tabela.NewRow();

                row["total"] = venda.Subtotal;
                row["data"] = venda.Data;
                tabela.Rows.Add(row);
            }
            return tabela;
        }
    }
}