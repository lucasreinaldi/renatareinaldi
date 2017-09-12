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

      
        public bool Inserir(Servico servico, string pastaDestino, string extensao, FileUpload fup)
        {

            string msg = "";

            try
            {
                servico.CaminhoImagem = " ";
                DataContext.BeginTransaction();
                DataContext.DataContext.Servicos.InsertOnSubmit(servico);
                DataContext.DataContext.SubmitChanges();

                string caminhoCompleto = pastaDestino + "Servico_" + servico.IdServicos + extensao;
                Util.UploadArquivo(fup, caminhoCompleto);
                if (Util.ArquivoExists(caminhoCompleto, null, null))
                {
                    Servico servicoAlterar = this.ConsultarPorId(servico.IdServicos);
                    servicoAlterar.CaminhoImagem = "../img/servicos/Servico_" + servico.IdServicos + extensao;
                    DataContext.DataContext.SubmitChanges();
                }
                else
                {
                    DataContext.RollbackTransaction();
                }

                DataContext.CommitTransaction();
                msg = "Inserido com sucesso [Inserir - Release]";

                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao inserir o Cliente [Inserir - ClienteBO.cs][" + e.Message + "][" + e.Source + "]";

                DataContext.RollbackTransaction();
                return false;
            }
        }

        private bool Alterar(Servico servico, string pastaDestino, string extensao, FileUpload fup)
        {
            
            string msg = "";
            bool ok = false;
            string oldPath;

            try
            {
                DataContext.BeginTransaction();

                Servico novoServico = this.ConsultarPorId(servico.IdServicos);
                novoServico.Nome = servico.Nome;
                novoServico.Descricao = servico.Descricao;
                novoServico.Valor = servico.Valor;
                oldPath = servico.CaminhoImagem;

                // string caminhoCompleto = pastaDestino + "Release_" + release.Id + extensao;

                if (fup.HasFile)
                {
                    novoServico.CaminhoImagem = servico.CaminhoImagem;

                    if ((fup.FileName != null) && (fup.FileName != "") && (pastaDestino != null) && (pastaDestino != ""))
                    {

                        if (Util.ExcluirArquivo(pastaDestino + oldPath, null, null))
                        {
                            ok = true;
                        }
                        if (Util.UploadArquivo(fup, pastaDestino + "Servico_" + servico.IdServicos + extensao))
                        {
                            ok = true;
                            novoServico.CaminhoImagem = "Servico_" + servico.IdServicos + extensao;
                            DataContext.DataContext.SubmitChanges();
                        }
                        else
                        {
                            ok = false;
                        }
                    }
                }
                else
                {
                    ok = true;
                }

                if (ok)
                {
                    DataContext.DataContext.SubmitChanges();
                    DataContext.CommitTransaction();
                    msg = "O Release foi alterado com sucesso [Alterar - Release]";
                    
                    return true;
                }

                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o Release [Alterar - ReleaseBO.cs][Erro ao carregar Release do Cliente]";
                 
                return false;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao alterar o Release [Alterar - ReleaseBO.cs][Erro ao carregar Release do Cliente]";
                 
                return false;
            }
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

        public bool Salvar(Servico servico, string pastaDestino, string extensao, FileUpload fup)
        {
            if (servico.IdServicos <= 0)
                return this.Inserir(servico, pastaDestino, extensao, fup);
            else
                return this.Alterar(servico, pastaDestino, extensao, fup);
        }
    }
}