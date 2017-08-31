using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_RENATA.ADM
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewsletter_Click(object sender, EventArgs e)
        {
            EmailBO emails = new EmailBO();
            emails.Inserir(txtNewsletter.Text);
             
             
        }

        public void mostrarEmails(int verificador)
        {
            DataBO dataBO = new DataBO();
            List<data> data = dataBO.ConsultarTodosId(verificador);

            if (data != null && data.Count > 0)
            {
                this.rptDatas.Visible = true;
                pageDs.DataSource = this.MontarDataTable(data).DefaultView;
                rptDatas.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptDatas.DataBind();
            }
            else
            {
                this.rptDatas.Visible = false;
            }
            if (data.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
            }
        }

        public void mostrarDatasByDate(int verificador)
        {
            DataBO dataBO = new DataBO();
            List<data> data = dataBO.ConsultarTodosData(verificador);

            if (data != null && data.Count > 0)
            {
                this.rptDatas.Visible = true;
                pageDs.DataSource = this.MontarDataTable(data).DefaultView;
                rptDatas.DataSource = mp.MontarListaPaginada(pageDs, this.lblCurrentPage, this.lbtAnterior, this.lbtProximo);
                rptDatas.DataBind();
            }
            else
            {
                this.rptDatas.Visible = false;
            }
            if (data.Count == 0)
            {
                lbtAnterior.Visible = false;
                lbtProximo.Visible = false;
            }
        }

        private DataTable MontarDataTable(List<data> list)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("date");
            tabela.Columns.Add("link");

            foreach (data data in list)
            {
                DataRow row = tabela.NewRow();

                row["id"] = data.id;
                row["nome"] = data.nome;
                row["date"] = data.date;
                row["link"] = data.link;

                tabela.Rows.Add(row);
            }
            return tabela;
        }

        protected void imbExcluirData_Click(object sender, CommandEventArgs e)
        {
            DataBO datas = new DataBO();
            int id = Int32.Parse(e.CommandArgument.ToString());
            if (datas.Excluir(id))
            {
                Response.Redirect("GerDatas.aspx");
            }
        }
  

        public void limparCampos()
        {
            tboxNome.Text = "";
            tboxData.Text = "";
            tboxLink.Text = "";
        }
    }
}