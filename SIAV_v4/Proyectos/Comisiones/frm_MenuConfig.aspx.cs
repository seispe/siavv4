using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Seguridad;
using System.Configuration;

namespace SIAV_v4.Proyectos.Comisiones
{
    public partial class frm_MenuConfig : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Menu an_menu = new AN_Menu();
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void boxquick()
        {
            Response.Write(an_menu.Boxquick(ConfigurationManager.AppSettings["PATH"] + "Proyectos/Comisiones/frm_ComiConfig.aspx", "fa-usd", "Configurar Comisiones", "green"));
            Response.Write(an_menu.Boxquick(ConfigurationManager.AppSettings["PATH"] + "Proyectos/Comisiones/frm_VendedoresComi.aspx", "fa-truck", "Configurar Vendedores","blue"));
            Response.Write(an_menu.Boxquick(ConfigurationManager.AppSettings["PATH"] + "Proyectos/Comisiones/frm_GenerarComi.aspx", "fa-truck", "Generar Comisiones", "red"));
        }
    }
}