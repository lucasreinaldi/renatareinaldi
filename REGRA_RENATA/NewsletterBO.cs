using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REGRA_RENATA
{
    public class NewsletterBO
    {
        
        public List<data> ConsultarTodosId(int i)
        {
            try
            {
                if (i == 0)
                {

                    var consulta = (from data in db.datas orderby data.id ascending select data);
                    List<data> datas = consulta.ToList();
                    return datas;
                }
                else
                {

                    var consulta = (from data in db.datas orderby data.id descending select data);
                    List<data> datas = consulta.ToList();
                    return datas;
                }
            }
            catch
            {
                return null;
            }
        }

        

        public Boolean Inserir(String email, String link, String data)
        {
            
            Util util = new Util();
            String ip = util.PegarIp();

            data datas = new data();
            datas.nome = nome;
            datas.link = link;

            datas.date = DateTime.ParseExact(data, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

            db.datas.Add(datas);
            db.SaveChanges();
            return true;
        }

        public bool Excluir(int id)
        {
            data datas = db.datas.Find(id);
            db.datas.Remove(datas);
            db.SaveChanges();
            return true;
        }
    }
}
}