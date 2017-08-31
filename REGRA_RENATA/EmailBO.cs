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
    public class EmailBO
    {
        private nebulusbdEntities db = new nebulusbdEntities();

        public List<lista_email> ConsultarTodos() 
        {

            try {
                List<lista_email> lista = db.lista_email.ToList();
                return lista;
            } catch {

                return null;
            }

        }

        public bool Excluir(int id) {

            lista_email newsletter = db.lista_email.Find(id);
            db.lista_email.Remove(newsletter);
            db.SaveChanges();
            return true;

        }
        
        public Boolean Inserir(String nome)
        {
            Util util = new Util();
            String ip = util.PegarIp();

            lista_email email = new lista_email();
            email.email = nome; 
            email.data = DateTime.Now;
            email.ip = ip;

            db.lista_email.Add(email);
            db.SaveChanges();
            return true;            
        }
    }
}
 