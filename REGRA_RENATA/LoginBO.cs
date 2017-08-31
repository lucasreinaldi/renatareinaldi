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
#pragma warning restore CS0246 // The type or namespace name 'DAL_NEBULUS' could not be found (are you missing a using directive or an assembly reference?)

namespace REGRA_NEBULUS
{
    public class LoginBO
    {
        public String nomeUsuario(String nome)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select count(*) from usuarios where login='" + nome + "'";


            if (BancoClassico.IniciarTransaction(comando))
            {
                BancoClassico.ExecutarTransaction(comando);

                int temp = Convert.ToInt32(comando.ExecuteScalar().ToString());
                if (temp == 1)
                {

                    comando.CommandText = "select login from usuarios where login='" + nome + "'";
                    string user = comando.ExecuteScalar().ToString();

                    if (BancoClassico.CommitTransaction(comando))
                    {
                        return user;
                    }
                    else
                    {
                        BancoClassico.RollBackTransaction(comando);
                        return "erro";
                        //erro ao comitar no banco
                    }
                }
                else
                {
                    //erro ao abrir conexao
                    return "Erro de user duplicado.";
                }
            }
            return "Erro ao abrir conexão.";
        }

        public String senhaUsuario(String nome)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select senha from usuarios where login='" + nome + "'";

            if (BancoClassico.IniciarTransaction(comando))
            {
                BancoClassico.ExecutarTransaction(comando);

                string senha = comando.ExecuteScalar().ToString();

                if (BancoClassico.CommitTransaction(comando))
                {
                    return senha;
                }
                else
                {
                    BancoClassico.RollBackTransaction(comando);
                    return "erro";
                    //erro ao comitar no banco
                }
            }
            else
            {
                //erro ao abrir conexao
                return "erro";
            }
        }

        public static byte[] CriptografarSenhaSHA1(string senha)
        {
            //senha digitada
            byte[] unicodeSenha = System.Text.UTF8Encoding.UTF8.GetBytes(senha);

            System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            //criptografa a senha
            byte[] senhaCripto = sha1.ComputeHash(unicodeSenha);

            //retorna a senha criptografada
            return senhaCripto;
        }

        public static bool CompararSenhas(byte[] senha1, byte[] senha2)
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

        

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}