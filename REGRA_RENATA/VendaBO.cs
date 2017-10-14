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

namespace REGRA_RENATA
{
    public class VendaBO
    {

        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public Venda ConsultarPorId(int id, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                return DataContext.DataContext.Vendas.Single(Venda => Venda.IdCompra == id);
            }

            catch (Exception e)
            {
                msg = "Erro ao consultar venda por id. " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return null;
            }
        }

        public List<Venda> ConsultarTodos(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Venda in DataContext.DataContext.Vendas select Venda;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar todas vendas. Erro: " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    DataHora = DateTime.Now,
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                logBO.Salvar(log);

                return null;
            }
        }
 

    }
}