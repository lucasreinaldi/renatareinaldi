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

        public bool Inserir(Noticia noticia, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";
            try
            {
                noticia.CaminhoImagem = " ";
                DataContext.BeginTransaction();
                DataContext.DataContext.Noticias.InsertOnSubmit(noticia);
                DataContext.DataContext.SubmitChanges();
                string caminhoCompleto = pastaDestino + "Noticia_" + noticia.IdNoticia + extensao;
                if (fup.HasFile)
                {
                    Util.UploadArquivo(fup, caminhoCompleto);
                    if (Util.ArquivoExists(caminhoCompleto, null, null))
                    {
                        Noticia noticiaAlterar = this.ConsultarPorId(noticia.IdNoticia, idUsuarioLogado);
                        noticiaAlterar.CaminhoImagem = "Noticia_" + noticia.IdNoticia + extensao;
                        DataContext.DataContext.SubmitChanges();
                    }
                    else
                    {
                        DataContext.RollbackTransaction();
                    }
                }
                else
                {
                    Noticia noticiaAlterar = this.ConsultarPorId(noticia.IdNoticia, idUsuarioLogado);
                    noticiaAlterar.CaminhoImagem = "Default.jpg";
                    DataContext.DataContext.SubmitChanges();
                }
                DataContext.CommitTransaction();
                msg = "Notícia inserida com sucesso. id: " + noticia.IdNoticia;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao inserir a notícia. [" + e.Message + "][" + e.Source + "]";
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                DataContext.RollbackTransaction();
                return false;
            }
        }

        private bool Alterar(Noticia noticia, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";
            bool ok = false;
            string oldPath;
            try
            {
                DataContext.BeginTransaction();
                Noticia novoObj = this.ConsultarPorId(noticia.IdNoticia, idUsuarioLogado);
                novoObj.Titulo = noticia.Titulo;
                novoObj.DescricaoBreve = noticia.DescricaoBreve;
                novoObj.Conteudo = noticia.Conteudo;
                novoObj.DataPublicacao = noticia.DataPublicacao;
                oldPath = noticia.CaminhoImagem;
                if (fup.HasFile)
                {
                    novoObj.CaminhoImagem = novoObj.CaminhoImagem;
                    if ((fup.FileName != null) && (fup.FileName != "") && (pastaDestino != null) && (pastaDestino != ""))
                    {
                        if (Util.ExcluirArquivo(pastaDestino + oldPath, null, null))
                        {
                            ok = true;
                        }
                        if (Util.UploadArquivo(fup, pastaDestino + "Noticia_" + noticia.IdNoticia + extensao))
                        {
                            ok = true;
                            novoObj.CaminhoImagem = "Noticia_" + noticia.IdNoticia + extensao;
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
                    msg = "A notícia foi alterada com sucesso.";
                    log = new Log()
                    {
                        IdUsuario = idUsuarioLogado,
                        Mensagem = msg
                    };
                    logBO.Salvar(log);
                    return true;
                }
                DataContext.RollbackTransaction();
                msg = "Erro ao alterar a notícia.";
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                return false;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao alterar a notícia. [Erro ao carregar notícia do bd]";
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return false;
            }
        }

        public bool Salvar(Noticia noticia, string pastaDestino, string extensao, FileUpload fup, int? idUsuarioLogado)
        {
            if (noticia.IdNoticia <= 0)
                return this.Inserir(noticia, pastaDestino, extensao, fup, idUsuarioLogado);
            else
                return this.Alterar(noticia, pastaDestino, extensao, fup, idUsuarioLogado);
        }

        public bool Excluir(Noticia noticia, string pastaDestino, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg = "";

            try
            {
                DataContext.BeginTransaction();
                Noticia noticiaExcluir = this.ConsultarPorId(noticia.IdNoticia, idUsuarioLogado);
                string caminhoCompleto = pastaDestino + noticiaExcluir.CaminhoImagem;
                DataContext.DataContext.Noticias.DeleteOnSubmit(noticiaExcluir);

                if (noticia.CaminhoImagem != null)
                {
                    if (Util.ExcluirArquivo(caminhoCompleto, null, null))
                    {
                        DataContext.DataContext.SubmitChanges();
                        DataContext.CommitTransaction();

                        msg = "Notícia excluída com sucesso. " + noticiaExcluir.IdNoticia;
                        log = new Log()
                        {
                            IdUsuario = idUsuarioLogado,
                            Mensagem = msg
                        };

                        return true;
                    }
                    else
                    {
                        DataContext.RollbackTransaction();
                        msg = "Erro ao excluir a notícia. " + noticiaExcluir.IdNoticia;

                        return false;
                    }
                }
                DataContext.DataContext.SubmitChanges();
                DataContext.CommitTransaction();

                msg = "Notícia excluída com sucesso. " + noticiaExcluir.IdNoticia;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                return true;
            }
            catch (Exception e)
            {
                DataContext.RollbackTransaction();
                msg = "Erro ao excluir a noticia. " + noticia.IdNoticia + "Erro: " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    DataHora = DateTime.Now,
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };

                return false;
            }
        }

        public Noticia ConsultarPorId(int id, int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log = new Log();
            string msg = "";

            try
            {
                return DataContext.DataContext.Noticias.Single(Noticia => Noticia.IdNoticia == id);
            }

            catch (Exception e)
            {
                msg = "Erro ao consultar notícia por ID. " + e.Message + " - " + e.Source;
                log = new Log()
                {
                    IdUsuario = idUsuarioLogado,
                    Mensagem = msg
                };
                logBO.Salvar(log);
                return null;
            }
        }

        public List<Noticia> ConsultarTodos(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = from Noticia in DataContext.DataContext.Noticias select Noticia;
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar notícias. Erro: " + e.Message + " - " + e.Source;
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

        public List<Noticia> ConsultarTres(int? idUsuarioLogado)
        {
            LogBO logBO = new LogBO();
            Log log;
            string msg;

            try
            {

                var consulta = (from Noticia in DataContext.DataContext.Noticias select Noticia).Take(3);
                return consulta.ToList();


            }
            catch (Exception e)
            {
                msg = "Erro ao consultar 3 notícias. Erro: " + e.Message + " - " + e.Source;
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


