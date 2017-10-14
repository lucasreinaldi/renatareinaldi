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
    public partial class GERatendimentoDados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.Request.QueryString["id"];

            this.Title = "Gerenciar atendimento";

            if (id != null)
            {
                if (!this.IsPostBack)
                {
                    if (Int32.Parse(id) > 0)
                    {
                        MapearObjetosParaCampos(Convert.ToInt32(id));
                        AtendimentoBO atendimentoBO = new AtendimentoBO();
                        Atendimento atendimento = atendimentoBO.ConsultarPorId(Int32.Parse(id), null);
                    }
                }
            }
            else
            {
                Response.Redirect("GERatendimento.aspx");
            }
        }

             

        public void MapearObjetosParaCampos(int id)
        {

            AtendimentoBO atendimentoBO = new AtendimentoBO();
            Atendimento atendimento = atendimentoBO.ConsultarPorId(id, null);

            if (atendimento != null)
            {
                
                 

            }
        }

        public Atendimento MapearCamposParaObjeto()
        {
            Atendimento atendimento = new Atendimento();
            atendimento.Resposta = txtDescricao.Text;

            atendimento.IdAtendimento = Convert.ToInt32(Request.QueryString["id"]);

            return atendimento;
        }

        public void Aprovar()
        {
            string id = this.Request.QueryString["id"];
            AtendimentoBO atendimentoBO = new AtendimentoBO();

            Atendimento atendimento = new Atendimento();
            atendimento = atendimentoBO.ConsultarPorId(Convert.ToInt32(id), null);
            atendimento.Estado = 1;
            atendimento.Resposta = txtDescricao.Text;

            if (atendimentoBO.Aprovar(atendimento, null))
            {
                Session.Add("msgRes", "Atendimento aprovado com sucesso.");
            }
            else
            {
                Session.Add("msgRes", "Erro ao aprovar atendimento.");
            }
            Response.Redirect("GERAtendimento.aspx");
        }

        public void Desaprovar()
        {
            string id = this.Request.QueryString["id"];
            AtendimentoBO atendimentoBO = new AtendimentoBO();

            Atendimento atendimento = new Atendimento();
            atendimento = atendimentoBO.ConsultarPorId(Convert.ToInt32(id), null);
            atendimento.Estado = 2;
            atendimento.Resposta = txtDescricao.Text;

            if (atendimentoBO.Desaprovar(atendimento, null))
            {
                Session.Add("msgRes", "Atendimento deaprovado com sucesso.");
            }
            else
            {
                Session.Add("msgRes", "Erro ao desaprovar atendimento.");
            }
            Response.Redirect("GERAtendimento.aspx");
        }

        protected void btnAprovar_Click(Object sender, EventArgs e)
        {
            Aprovar();
        }

        protected void btnDesaprovar_Click(Object sender, EventArgs e)
        {
            Desaprovar();
        }
    }
}