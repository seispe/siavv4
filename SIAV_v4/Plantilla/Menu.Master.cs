using System;
using System.Web;
using AccesoEntidades.Seguridad;
using System.Configuration;
using AccesoNegocios.Seguridad;

namespace SIAV_v4.Plantilla
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        #region Variables Globales
        AE_GA_SEG_Tloginvent ae_ga_seg_tloginvent = new AE_GA_SEG_Tloginvent();
        AN_Menu an_menu = new AN_Menu();
        AN_Autentificar an_autentificar = new AN_Autentificar();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string ventana = "";
            string respuesta = "";
            //si se autentica mostramos nombre de usuario
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Ventanas de Usuarios Logueados
                ae_ga_seg_tloginvent.usuario = HttpContext.Current.User.Identity.Name;
                ae_ga_seg_tloginvent.empresa = Request.Cookies["basesiav"].Value;
                ae_ga_seg_tloginvent.ventana = Request.Url.AbsoluteUri;
                ae_ga_seg_tloginvent.pc = Request.Url.Host;
                ae_ga_seg_tloginvent.pcdns = Request.Url.DnsSafeHost;
                //Titulos
                lblMedio.Text = "Bienvenido a SIAV v4 - " + an_menu.AcronimoEmpresas(Request.Cookies["empresasiav"].Value);
                lblNombreHorizontal.Text = ae_ga_seg_tloginvent.usuario;
                //Verificar si tiene permisos
                if (ae_ga_seg_tloginvent.ventana.Contains("localhost"))
                {
                    ventana = ae_ga_seg_tloginvent.ventana.Substring(22, ae_ga_seg_tloginvent.ventana.Length-22);
                }
                else
                {
                    if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.247"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.252"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.231"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.213"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.214"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.219"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.239"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else if (ae_ga_seg_tloginvent.ventana.Contains("192.168.0.220"))
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(20, ae_ga_seg_tloginvent.ventana.Length - 20);
                    }
                    else
                    {
                        ventana = ae_ga_seg_tloginvent.ventana.Substring(21, ae_ga_seg_tloginvent.ventana.Length - 21);
                    }
                    
                }
                respuesta = an_menu.VerificarVentana(ae_ga_seg_tloginvent.usuario, Request.Cookies["empresasiav"].Value, ventana);
                if (respuesta != "OK" && ventana != "/SIAV_v4/Default.aspx")
                {
                    Response.Redirect(ConfigurationManager.AppSettings["PATH"] + "Default.aspx");
                }else
                {
                    ae_ga_seg_tloginvent.ventana = ventana;
                    an_menu.InsertAutLoginVentana(ae_ga_seg_tloginvent);
                }
            }
            else
            {
                //Si intentan Ingresar sin Loguearse
                Response.Redirect(ConfigurationManager.AppSettings["PATH"]+"OutLogin.aspx");
            }
        }

        protected void nombreEmpresa()
        {
            Response.Write("<link rel='icon' href='"+ConfigurationManager.AppSettings["PATH_RECURSOS"] +"favicon/Logo" + (an_menu.AcronimoEmpresas(Request.Cookies["empresasiav"].Value)).ToLower() + ".ico' />" + "<link rel='shortcut icon' href='" + ConfigurationManager.AppSettings["PATH_RECURSOS"] + "favicon/Logo" + (an_menu.AcronimoEmpresas(Request.Cookies["empresasiav"].Value)).ToLower() + ".ico' type='image/x-icon' /> <title>" + an_menu.AcronimoEmpresas(Request.Cookies["empresasiav"].Value) + "</title>");
        }

        protected void CargarMenu()
        {
            try
            {
                Response.Write(an_menu.CrearMenu(Request.Cookies["empresasiav"].Value, HttpContext.Current.User.Identity.Name));
            }
            catch (Exception)
            {
                Response.Redirect(ConfigurationManager.AppSettings["PATH"] + "OutLogin.aspx");
            }
        }
    }
}