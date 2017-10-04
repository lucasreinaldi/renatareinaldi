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

namespace WEB_RENATA
{
    public partial class ServicoConfirma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChecarPermissao();

            string id = this.Request.QueryString["id"];
            

            if (id != null)
            {
                if (!this.IsPostBack)
                {
                    if (Int32.Parse(id) > 0)
                    {
                        MapearObjetosParaCampos(Convert.ToInt32(id));
                        
                    }
                }
            }
            else
            {
                Response.Redirect("Servicos.aspx");
            }
        }
        public void MapearObjetosParaCampos(int id)
        {

            ServicoBO servicoBO = new ServicoBO();
            Servico servico = servicoBO.ConsultarPorId(id, null);

            if (servico != null)
            {

                this.lblServico.InnerText = servico.Nome.ToString();
                

            }



        }

        protected void btnAgendar_Click(Object sender, EventArgs e)
        {
            string id = this.Request.QueryString["id"];

            ServicoBO servicoBO = new ServicoBO();
            Servico servico = servicoBO.ConsultarPorId(Convert.ToInt32(id), null);

            int idUsuarioLogado = Int32.Parse(Session["IdUsuario"].ToString());

            Atendimento atendimento = new Atendimento();

            atendimento.FkServico = servico.IdServicos;
            atendimento.FkUsuario = idUsuarioLogado;
            
            atendimento.Estado = 0;
            atendimento.Data = DateTime.Now;
            atendimento.DataAtendimento = Convert.ToDateTime(txtData.Text);
            atendimento.Comentario = txtComentario.Text;

            AtendimentoBO atendimentoBO = new AtendimentoBO();

            if (atendimentoBO.Agendar(atendimento, servico, idUsuarioLogado, 0))
            {
                Session.Add("msgRes", "Serviço agendado com sucesso!");
                Response.Redirect("Painel.aspx");
            }
            else
            {
                Session.Add("msgRes", "Erro ao agendar serviço.");
                Response.Redirect("Servicos.aspx");
            }
        }

        public void ChecarPermissao()
        {
            if (Session["nomeUsuario"] != null)
            {
                
            }
            else
            {
                Response.Redirect("Login.aspx");

            }
        }

        
    }
}