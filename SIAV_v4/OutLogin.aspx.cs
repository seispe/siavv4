using System;
using System.Configuration;
using System.Web.Security;

namespace SIAV_v4
{
    public partial class OutLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["empresasiav"] != null)
            {
                Response.Cookies["empresasiav"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Request.Cookies["basesiav"] != null)
            {
                Response.Cookies["basesiav"].Expires = DateTime.Now.AddDays(-1);
            }
            //se borra la cookie de autenticacion
            FormsAuthentication.SignOut();
            //se redirecciona al usuario a la pagina de login
            Response.Redirect(ConfigurationManager.AppSettings["PATH"] + "Login.aspx");
        }
    }
}