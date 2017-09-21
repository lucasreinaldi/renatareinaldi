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
    public class UsuarioBO
    {
        BancoLINQ<renataDBMLDataContext> DataContext = new BancoLINQ<renataDBMLDataContext>();


        public bool CriarUsuario(Usuario usu, Endereco end)
        {
            try
            {
                DataContext.DataContext.Enderecos.InsertOnSubmit(end);
                DataContext.DataContext.SubmitChanges();

                usu.fkEndereco = end.IdEndereco;
                DataContext.DataContext.Usuarios.InsertOnSubmit(usu);
                DataContext.DataContext.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CriarUsuario(Usuario usu)
        {
            try
            {

                DataContext.DataContext.Usuarios.InsertOnSubmit(usu);
                DataContext.DataContext.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Usuario> ConsultarTodos()
        {

            try
            {

                var consulta = from Usuario in DataContext.DataContext.Usuarios select Usuario;
                return consulta.ToList();


            }
            catch
            {

                return null;
            }
        }

        public Endereco BuscarEndereco(Usuario usuario)
        {
            try
            {



                var end = (from Endereco in DataContext.DataContext.Enderecos
                           where usuario.fkEndereco == Endereco.IdEndereco
                           select Endereco).FirstOrDefault();

                return end;
            }
            catch
            {

                return null;
            }

        }

        public bool Excluir(Usuario usu)
        {

            Usuario exclusao = this.ConsultarPorId(usu.IdUsuario);
            DataContext.DataContext.Usuarios.DeleteOnSubmit(exclusao);
            DataContext.DataContext.SubmitChanges();
            return true;

        }


        public Usuario ConsultarPorId(int id)
        {

            try
            {
                return DataContext.DataContext.Usuarios.Single(Usuario => Usuario.IdUsuario == id);
            }

            catch (Exception e)
            {

                return null;
            }
        }

        public static byte[] CriptografarSenhaSHA1(string senha)
        {

            byte[] unicodeSenha = System.Text.UTF8Encoding.UTF8.GetBytes(senha + "SMC98923482000rAAeADDw___0034920qkjqkejSKDJAADD");

            System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();


            byte[] senhaCripto = sha1.ComputeHash(unicodeSenha);


            return senhaCripto;
        }


        public static bool CompararSenhas(byte[] senha1, System.Data.Linq.Binary senha2)
        {
            byte[] senha3 = senha2.ToArray();


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

        public Usuario ConsultarPorLogin(string email, int? idUsuarioLogado)
        {
            try
            {
                Usuario usu = new Usuario();
                usu = DataContext.DataContext.Usuarios.SingleOrDefault(u => u.Email == email);

                if (usu != null)
                    return usu;

                return null;
            }
            catch (Exception e)
            {
                string msgLog = "Erro ao consultar usuário por login. " + e.Source;

                Log log = new Log() { IdUsuario = idUsuarioLogado, Mensagem = msgLog };

                LogBO logBO = new LogBO();
                logBO.Salvar(log);

                return null;
            }
        }

    }
}