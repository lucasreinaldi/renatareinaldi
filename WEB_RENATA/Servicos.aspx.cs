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
    public partial class Servicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MontarRepeaterServicos();
        }

        private DataTable MontarDataTable(List<Servico> list)
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("nome");
            tabela.Columns.Add("descricao");
            tabela.Columns.Add("valor");
            tabela.Columns.Add("imagem");

            foreach (Servico lista in list)
            {
                DataRow row = tabela.NewRow();

                row["nome"] = lista.Nome;
                row["descricao"] = lista.Descricao;
                row["valor"] = lista.Valor;
                row["imagem"] = "\\img\\servicos\\" + lista.CaminhoImagem;

                tabela.Rows.Add(row);
            }
            return tabela;
        }


        public void MontarRepeaterServicos()
        {

            Servico servico = new Servico();
            ServicoBO servicoBO = new ServicoBO();

            List<Servico> listaNoticia = servicoBO.ConsultarTodos(null);

            if (listaNoticia != null && listaNoticia.Count > 0)
            {
                this.rptServicos.Visible = true;

                rptServicos.DataSource = this.MontarDataTable(listaNoticia).DefaultView;
                rptServicos.DataBind();
            }
            else
            {
                this.rptServicos.Visible = false;
            }

        }
    }
}