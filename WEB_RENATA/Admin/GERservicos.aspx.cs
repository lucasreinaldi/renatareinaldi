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

namespace WEB_RENATA.Admin
{
    public partial class GERservicos : System.Web.UI.Page
    {
        AdmHome mp;
        public static PagedDataSource pageDs;


        protected void Page_Load(object sender, EventArgs e)
        {
            mp = (AdmHome)this.Master;
            this.Page.Title = "Gerenciador de Serviços";

            if (!IsPostBack)
            {
                pageDs = new PagedDataSource();
                pageDs.AllowPaging = true;
                pageDs.PageSize = 20;

                //masterPage.ValidarQueryString(Request.QueryString["pagina"], "MidiaGer.aspx?pagina=0");

            }
            this.MontarRepeater();
        }

        protected void imbExcluirEmail_Click(object sender, CommandEventArgs e)
        {

             
            ServicoBO servicoBO = new ServicoBO();
            Servico servico = new Servico();

            int id = Int32.Parse(e.CommandArgument.ToString());
            servico.IdServicos = id;

            if (servicoBO.Excluir(servico) == true)
            {
                
                // masterPage.DefinirMsgResultado(divResultado, TipoMensagemLabel.Sucesso, lblResultado, "Cliente excluído com sucesso!", null);

                this.MontarRepeater();
            }
            else
            {

                this.MontarRepeater();
            }

            // divResultado.Visible = true;
            //  }


        }

        protected void lbtAnterior_Click(object sender, EventArgs e)
        {
            mp.CurrentPage--;

            this.rptServicos.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptServicos.DataBind();
        }


        protected void lbtProximo_Click(object sender, EventArgs e)
        {
            mp.CurrentPage++;

            this.rptServicos.DataSource = mp.MontarListaPaginada(pageDs, lblCurrentPage, lbtAnterior, lbtProximo);
            this.rptServicos.DataBind();
        }




        public void MontarRepeater()
        {
            ServicoBO servicoBO = new ServicoBO();
            List<Servico> listaServico = servicoBO.ConsultarTodos();

            if (listaServico != null && listaServico.Count > 0)
            {
                this.rptServicos.Visible = true;
                pageDs.DataSource = this.MontarDataTable(listaServico).DefaultView;
                rptServicos.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptServicos.DataBind();
            }
            else
            {
                this.rptServicos.Visible = false;
            }
            if (listaServico.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
                // mp.DefinirMsgResultado(divResultado, TipoMensagemLabel.Aviso, lblResultado, "Não há clientes cadastrados.", null);
                // this.divResultado.Visible = true;
            }
        }


        private DataTable MontarDataTable(List<Servico> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("valor");
            tabela.Columns.Add("caminho");

            foreach (Servico lista in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = lista.IdServicos;
                row["nome"] = lista.Nome;
                row["descricao"] = lista.Descricao;
                row["valor"] = lista.Valor;
                row["caminho"] = lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }

        protected void btnAdicionar_Click(Object sender, EventArgs e)
        {
            ServicoBO servicosBO = new ServicoBO();
            Servico servico = new Servico();

            servico.Nome = txtNome.Text;
            servico.Descricao = txtDescricao.Text;

            decimal decim = Convert.ToDecimal(txtValor.Text);

            servico.Valor = decim;

            servicosBO.Inserir(servico, MapPath("../" + "img/servicos" + "/"), exampleInputFile);

            if (servico != null)
            {
                Response.Redirect("GERservicos.aspx");
            }
        }
    }
}