using AccesoNegocios.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4
{
    public partial class Default : System.Web.UI.Page
    {
        #region Inicializaciones GLobales
        AN_Menu an_menu = new AN_Menu();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuInicial();
            }
        }
        public void MenuInicial()
        {
            lblMenuInicial.Text = an_menu.GetAutLoginVentana(HttpContext.Current.User.Identity.Name, Request.Cookies["basesiav"].Value);
        }
    }
}