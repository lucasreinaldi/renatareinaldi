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

namespace WEB_RENATA.Admin
{
    public partial class GERhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCarUm_Click(Object sender, EventArgs e)
        {
            HomeBO homeBO = new HomeBO();
            if (homeBO.AlterarCar(MapPath("../" + "img/home" + "/"), fupCarUm, 1))
            {
                Response.Redirect("GERhome.aspx");
            }

            Response.Redirect("GERhome.aspx");
        }

        protected void btnCarDois_Click(Object sender, EventArgs e)
        {
            HomeBO homeBO = new HomeBO();
            if (homeBO.AlterarCar(MapPath("../" + "img/home" + "/"), fupCarDois, 2))
            {
                Response.Redirect("GERhome.aspx");
            }

            Response.Redirect("GERhome.aspx");
        }

        protected void btnCarTres_Click(Object sender, EventArgs e)
        {
            HomeBO homeBO = new HomeBO();
            if (homeBO.AlterarCar(MapPath("../" + "img/home" + "/"), fupCarTres, 3))
            {
                Response.Redirect("GERhome.aspx");
            }

            Response.Redirect("GERhome.aspx");
        }

        protected void btnCliUm_Click(Object sender, EventArgs e)
        {
            HomeBO homeBO = new HomeBO();
            if (homeBO.AlterarCli(MapPath("../" + "img/home" + "/"), fupCliUm, 1))
            {
                Response.Redirect("GERhome.aspx");
            }

            Response.Redirect("GERhome.aspx");
        }

        protected void btnCliDois_Click(Object sender, EventArgs e)
        {
            HomeBO homeBO = new HomeBO();
            if (homeBO.AlterarCli(MapPath("../" + "img/home" + "/"), fupCliDois, 2))
            {
                Response.Redirect("GERhome.aspx");
            }

            Response.Redirect("GERhome.aspx");
        }

        protected void btnCliTres_Click(Object sender, EventArgs e)
        {
            HomeBO homeBO = new HomeBO();
            if (homeBO.AlterarCli(MapPath("../" + "img/home" + "/"), fupCliTres, 3))
            {
                Response.Redirect("GERhome.aspx");
            }

            Response.Redirect("GERhome.aspx");
        }


    }
}