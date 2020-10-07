using AccesoEntidades.Seguridad;
using AccesoNegocios.Alertas;
using AccesoNegocios.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        #region VariablesGobales
        AN_Autentificar an_autentificar = new AN_Autentificar();
        AE_GA_SEG_Tlogin ae_ga_seg_tlogin = new AE_GA_SEG_Tlogin();
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Menu an_menu = new AN_Menu();
        #endregion

        #region Funciones
        public void LlenarGrid()
        {
            ddlEmpresa.DataSource = an_autentificar.getEmpresas();
            ddlEmpresa.DataTextField = "empresa";
            ddlEmpresa.DataValueField = "cod_emp";
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0, new ListItem("Seleccione Empresa", "-1"));
        }
        #endregion

        #region Eventos
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Autentificar usuario de logeo.
            if (an_autentificar.UsuarioAD(txtUsername.Text, txtPassword.Text, "ALVARADO", "18.224.209.11"))
            {
                if (ddlEmpresa.SelectedValue != "-1")
                {
                    string acceso = an_autentificar.getusuarioEmpresa(txtUsername.Text.Trim(), ddlEmpresa.SelectedValue);
                    if (acceso != "1")
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR!", "Ud no tiene acceso a esta empresa", "rojo");
                    }
                    else
                    {
                        //Crear la Variable de id de nombre de empresa     
                        HttpCookie aCookie = new HttpCookie("empresasiav");
                        aCookie.Value = ddlEmpresa.SelectedValue;
                        aCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(aCookie);
                        //Crear la Variable de nombre base de empresa
                        HttpCookie aCookie1 = new HttpCookie("basesiav");
                        aCookie1.Value = an_menu.BaseEmpresas(ddlEmpresa.SelectedValue);
                        aCookie1.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(aCookie1);
                        //Usuarios Logueados
                        ae_ga_seg_tlogin.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_seg_tlogin.empresa = an_menu.BaseEmpresas(ddlEmpresa.SelectedValue);
                        ae_ga_seg_tlogin.fecha = DateTime.Now;
                        an_autentificar.InsertAutLogin(ae_ga_seg_tlogin);
                        //Rediriguir a donde corresponde
                        FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);
                        //Response.Redirect(ConfigurationManager.AppSettings["PATH"] + "Default.aspx");
                    }
                    
                }
                else lblError.Text = an_alertas.Mensaje("ERROR!", "Seleccione una empresa valida.", "rojo");
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Usuario o Contraseña Incorrectos.", "rojo");
            }
            
        }
        #endregion
    }
}