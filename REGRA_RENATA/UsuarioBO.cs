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
            //senha digitada
            byte[] unicodeSenha = System.Text.UTF8Encoding.UTF8.GetBytes(senha + "SMC98923482000rAAeADDw___0034920qkjqkejSKDJAADD");

            System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            //criptografa a senha
            byte[] senhaCripto = sha1.ComputeHash(unicodeSenha);

            //retorna a senha criptografada
            return senhaCripto;
        }

        /// <summary>
        /// Efetua a comparação entre duas senha, retorna true se forem iguais.
        /// </summary>
        /// <param name="senha1">Senha a ser comparada.</param>
        /// <param name="senha2">Senha a ser comparada.</param>
        /// <returns></returns>
        public static bool CompararSenhas(byte[] senha1, System.Data.Linq.Binary senha2)
        {
            byte[] senha3 = senha2.ToArray();

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

    }
}