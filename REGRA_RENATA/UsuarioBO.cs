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
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
#pragma warning disable CS0246 // The type or namespace name 'DAL_NEBULUS' could not be found (are you missing a using directive or an assembly reference?)
using DAL_NEBULUS;

namespace REGRA_NEBULUS
{
    public class UsuarioBO
    {
        private nebulusbdEntities db = new nebulusbdEntities();
        public bool Salvar(usuario usuario)
        {
            if (usuario.id <= 0) // Inserir
            {
                return this.Inserir(usuario);
            }
            else //Alterar
            {/*
                return this.Alterar(usuario);*/
                return this.Inserir(usuario);
            }
        }

        /// <summary>
        /// Cadastrar os dados do Usuário na aplicação
        /// </summary>
        /// <param name="usuario">Usuário a ser persistido</param>
        /// <param name="idUsuarioLogado">Id do Usuário Logado</param>
        /// <param name="ip">Ip do Usuário Logado</param>
        /// <param name="caminhoAtual">Caminho para Salvar a foto na pasta temporaria</param>
        /// <param name="pastaDestino">Caminho para Salvar a foto do Usuário</param>
        /// <param name="fupUrlFoto">FileUpload da Imagem</param>
        /// <returns></returns>
        private bool Inserir(usuario usuario)
        {

            string msgLog = "";

            db.usuarios.Add(usuario);
            db.SaveChanges();
            return true;

        }

        /*
         private bool Alterar(usuario usuario) {
             LogBO logBO = new LogBO();
             Log log = new Log();
             string msgLog = "";

             try {
                 Contexto.BeginTransaction(); //abre a transação

                 Usuario usu = this.ConsultarPorId(usuario.IdUsuario, idUsuarioLogado, ip);

                 if (caminhoAtual != "" && caminhoAtual != null && pastaDestino != "" && pastaDestino != null) {
                     if (PersistirFoto(usuario, idUsuarioLogado, ip, caminhoAtual, pastaDestino, fupUrlFoto)) {
                         string url = pastaDestino + "foto_" + usuario.Login + ".jpg";

                         if (Utils.ArquivoExists(url, idUsuarioLogado, ip)) // se existe a foto do Usuario, grava o endereco no banco
                         {
                             if (caminhoAtual != null)
                                 usu.PathFoto = @"imgAvatar/foto_" + usuario.Login + ".jpg"; // grava o endereço da foto no Usuario
                         }
                     } else //erro ao inserir foto
                       {
                         Contexto.RollbackTransaction();

                         msgLog = "Erro ao alterar o usuário [" + usu.Nome + "] [Alterar - UsuarioBO.cs]";

                         log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30010, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                         logBO.Salvar(log);

                         return false;
                     }
                 } else {
                     usu.PathFoto = usu.PathFoto;
                 }

                 usu.Nome = usuario.Nome;
                 usu.Sobrenome = usuario.Sobrenome;
                 usu.Email = usuario.Email;
                 usu.DataNasc = usuario.DataNasc;
                 usu.TipoUsu = usuario.TipoUsu;
                 usu.Login = usuario.Login;

                 if (usuario.Senha != null) {
                     usu.Senha = usuario.Senha;
                 }

                 Contexto.DataContext.SubmitChanges();

                 Contexto.CommitTransaction(); //Efetiva e fecha a conexão 

                 msgLog = "O usuário [" + usu.Nome + "] foi alterado com sucesso [Alterar - UsuarioBO.cs]";

                 log = new Log() { Categoria = (int)CategoriaLog.Informacao, CodEvento = 10001, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                 logBO.Salvar(log);

                 return true;
             } catch (Exception e) {
                 msgLog = "Erro ao Alterar Usuário [Alterar - UsuarioBO.cs][ " + e.Message + " - " + e.Source + " ]";

                 log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30002, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                 logBO.Salvar(log);

                 Contexto.RollbackTransaction();

                 return false;
             }
         }


         public bool Excluir(usuario usu) {

             string msgLog = "";

             try {
                 Contexto.BeginTransaction();

                 if (logBO.ExcluirLogUsuario(usu.IdUsuario, Contexto)) {
                     Contexto.DataContext.Usuarios.DeleteOnSubmit(usu);
                     Contexto.DataContext.SubmitChanges();

                     if (usu.PathFoto != "") //se tiver foto
                     {
                         if (Utils.ArquivoExists(urlFoto, idUsuarioLogado, ip)) {
                             if (!Utils.ExcluirArquivo(urlFoto, idUsuarioLogado, ip)) {
                                 Contexto.RollbackTransaction();

                                 msgLog = "Erro ao Excluir Usuário [" + usu.Nome + "][Excluir - UsuarioBO.cs]";

                                 log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30012, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                                 logBO.Salvar(log);
                                 return false;
                             }
                         }
                     }

                     Contexto.CommitTransaction();

                     msgLog = "O Usuário [" + usu.Nome + "] foi excluído com sucesso [Excluir - UsuarioBO.cs]";

                     log = new Log() { Categoria = (int)CategoriaLog.Aviso, CodEvento = 20004, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                     logBO.Salvar(log);

                     return true;
                 } else {
                     Contexto.RollbackTransaction();

                     msgLog = "Erro ao Excluir Usuário [" + usu.Nome + "][Excluir - UsuarioBO.cs]";

                     log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30012, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                     logBO.Salvar(log);

                     return false;
                 }
             } catch (Exception e) {
                 msgLog = "Erro ao Excluir Usuário [Excluir - UsuarioBO.cs][ " + e.Message + " - " + e.Source + " ]";

                 log = new Log() { Categoria = (int)CategoriaLog.Erro, CodEvento = 30004, IdUsuario = idUsuarioLogado, Ip = ip, Mensagem = msgLog };

                 logBO.Salvar(log);

                 Contexto.RollbackTransaction();

                 return false;
             }
         }
         */
        public usuario ConsultarPorId(int idUsuario)
        {
            try
            {
                return db.usuarios.Single(usuario => usuario.id == idUsuario);
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public List<usuario> ConsultarPorNome(string prefixText, int count)
        {
            try
            {
                //StarWith == like
                var consulta = from usuarios in db.usuarios
                               where usuarios.nome.StartsWith(prefixText)
                               || usuarios.nome.Contains(prefixText)
                               orderby usuarios.nome
                               select usuarios;

                List<usuario> usuario = consulta.ToList();

                return usuario;

            }
            catch (Exception e) { }

            return null;
        }

        public List<usuario> ConsultarTodos()
        {
            try
            {
                var consulta = from usuarios in db.usuarios orderby usuarios.nome select usuarios;

                List<usuario> lista = consulta.ToList();

                return lista;
            }
            catch (Exception e)
            {
                string msgLog = "Erro ao Consultar Todos Usuários [ConsultarTodos - UsuarioBO.cs][ " + e.Message + " - " + e.Source + " ]";



                return null;
            }
        }

        public usuario ConsultarPorLogin(string login)
        {
            try
            {
                usuario usu = new usuario();
                usu = db.usuarios.SingleOrDefault(u => u.login == login);

                if (usu != null)
                    return usu;

                return null;
            }
            catch (Exception e)
            {
                string msgLog = "Erro ao Consultar Usuário Por Login  [ConsultarPorLogin - UsuarioBO.cs][ " + e.Message + " - " + e.Source + " ]";



                return null;
            }
        }

        public static byte[] CriptografarSenhaSHA1(string senha)
        {
            //senha digitada
            byte[] unicodeSenha = System.Text.UTF8Encoding.UTF8.GetBytes(senha + "S4WwEbSiTe98923482000rAAeADDw___0034920qkjqkejSKDJAADD");

            System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            //criptografa a senha
            byte[] senhaCripto = sha1.ComputeHash(unicodeSenha);

            //retorna a senha criptografada
            return senhaCripto;
        }

        public static bool CompararSenhas(byte[] senha1, byte[] senha2)
        {
            byte[] senha3 = senha2;

            //Verifica o tamanho dos arrays
            if (senha1.Length == senha3.Length)
            {
                for (int i = 0; i < senha1.Length; i++)
                {
                    if (senha1[i] != senha3[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool CriarUsuario(usuario usu)
        {
            try
            {
                db.usuarios.Add(usu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}