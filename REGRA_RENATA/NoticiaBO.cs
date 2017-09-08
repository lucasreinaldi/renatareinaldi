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
using System.Data.Linq;

namespace REGRA_RENATA
{
    public class NoticiaBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();

        public bool Inserir(Noticia noticia, String caminho, FileUpload arquivo)
        {

            string fullPath = caminho + noticia.Titulo + ".jpg";
            arquivo.SaveAs(fullPath);

            string caminhoDoArquivoNoBanco = "img\\noticias\\" + noticia.Titulo + ".jpg";
            noticia.CaminhoImagem = caminhoDoArquivoNoBanco;


            string msg;
            try
            {
                DataContext.DataContext.Noticias.InsertOnSubmit(noticia);
                DataContext.DataContext.SubmitChanges();

                msg = "Cliente inserido com sucesso. " + noticia.IdNoticia;

            }
            catch (Exception e)
            {

                msg = "Erro ao inserir o cliente. " + noticia.IdNoticia + "Erro: " + e.Message + " - " + e.Source;


                return false;
            }

            return true;
        }


        private bool Alterar(Noticia noticia)
        {

            string msg;

            try
            {
                Noticia noticiaAntiga = this.ConsultarPorId(noticia.IdNoticia);
                noticiaAntiga.Titulo = noticia.Titulo;
                noticiaAntiga.DescricaoBreve = noticia.DescricaoBreve;
                noticiaAntiga.Conteudo = noticia.Conteudo;
                noticiaAntiga.CaminhoImagem = noticia.CaminhoImagem;


                msg = "Release alterado com sucesso. " + noticia.IdNoticia;


                return true;
            }
            catch (Exception e)
            {


                return false;
            }


        }
        public Noticia ConsultarPorId(int id)
        {

            string msg;

            try
            {
                return DataContext.DataContext.Noticias.Single(Noticia => Noticia.IdNoticia == id);
            }
            catch (Exception e)
            {
                msg = "Erro ao consultar Release por ID. " + e.Message + " - " + e.Source;

            };

            return null;
        }


        public bool Excluir(Noticia noticia)
        {

            string msg;

            try
            {
                Noticia noticiaExcluir = this.ConsultarPorId(noticia.IdNoticia);
                DataContext.DataContext.Noticias.DeleteOnSubmit(noticiaExcluir);
                DataContext.DataContext.SubmitChanges();

                msg = "Release excluído com sucesso. " + noticia.IdNoticia;

                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao excluir release. " + noticia.IdNoticia + "Erro: " + e.Message + " - " + e.Source;


                return false;
            }
        }

        public List<Noticia> ConsultarTodos()
        {

            string msg;

            try
            {
                var consulta = from Noticia in DataContext.DataContext.Noticias orderby Noticia.DataPublicacao descending select Noticia;
                if (consulta == null)
                    return null;
                return consulta.ToList();
            }
            catch (Exception e)
            {


                return null;
            }
        }

        public List<Noticia> ConsultarTres()
        {

            string msg;

            try
            {
                var consulta = (from Noticia in DataContext.DataContext.Noticias orderby Noticia.DataPublicacao descending select Noticia).Take(3);
                if (consulta == null)
                    return null;
                return consulta.ToList();
            }
            catch (Exception e)
            {


                return null;
            }
        }

        public List<Noticia> ConsultarTodosPorIdCliente(int id)
        {

            string msg;

            try
            {
                var consulta = from Noticia in DataContext.DataContext.Noticias where (Noticia.IdNoticia == id) orderby Noticia.DataPublicacao descending select Noticia;
                return consulta.ToList();
            }
            catch (Exception e)
            {
                msg = "Erro ao consultar Release por ID do Cliente. " + e.Message + " - " + e.Source;




                return null;
            }
        }
    }
}

 
