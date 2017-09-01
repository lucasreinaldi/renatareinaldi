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
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using REGRA_RENATA;

namespace REGRA_RENATA
{
    public class ServicoBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();


        public List<Servico> ConsultarTodos()
        {

            try
            {

                var consulta = from Servico in DataContext.DataContext.Servicos select Servico;
                return consulta.ToList();


            }
            catch
            {

                return null;
            }
        }

        public bool Excluir(Servico servico)
        {

            Servico exclusao = this.ConsultarPorId(servico.IdServicos);
            DataContext.DataContext.Servicos.DeleteOnSubmit(exclusao);
            DataContext.DataContext.SubmitChanges();
            return true;

        }

        public bool Inserir(Servico servico, String caminho, FileUpload arquivo)
        {

            string fullPath = caminho + servico.Nome + ".jpg";
            arquivo.SaveAs(fullPath);

            string caminhoDoArquivoNoBanco = "img\\servicos\\" + servico.Nome + ".jpg";
            servico.CaminhoImagem = caminhoDoArquivoNoBanco;


            string msg;
            try
            {
                DataContext.DataContext.Servicos.InsertOnSubmit(servico);
                DataContext.DataContext.SubmitChanges();

                msg = "Cliente inserido com sucesso. " + servico.IdServicos;

            }
            catch (Exception e)
            {

                msg = "Erro ao inserir o cliente. " + servico.IdServicos + "Erro: " + e.Message + " - " + e.Source;


                return false;
            }

            return true;
        }

        public Servico ConsultarPorId(int id)
        {

            try
            {
                return DataContext.DataContext.Servicos.Single(Servico => Servico.IdServicos == id);
            }

            catch (Exception e)
            {

                return null;
            }
        }




}
}