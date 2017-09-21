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
using REGRA_RENATA;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace REGRA_RENATA
{
    public class HomeBO
    {

        public bool AlterarCar(string caminho, FileUpload arquivo, int filtro)
        {

            string fullPath = caminho + "Car" + filtro + ".jpg";
            arquivo.SaveAs(fullPath);
            return true;

        }

        public bool AlterarCli(string caminho, FileUpload arquivo, int filtro)
        {

            string fullPath = caminho + "Cliente" + filtro + ".jpg";
            arquivo.SaveAs(fullPath);
            return true;

        }


    }
}