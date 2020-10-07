using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Seguridad;
using AccesoNegocios.Alertas;
using AccesoEntidades.Seguridad;

namespace SIAV_v4.Seguridad
{
    public partial class frm_UsuarioVentana : System.Web.UI.Page
    {
        #region Inicializacion Globales
        AN_Autentificar an_autentificar = new AN_Autentificar();
        AN_Menu an_menu = new AN_Menu();
        AN_Alertas an_alertas = new AN_Alertas();
        AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos = new AE_GA_SEG_Tpermisos();
        #endregion
        
        private void CargarDatos()
        {
            gvNivel1.DataSource = an_menu.GetUsuarioVentana("").DataSource;
            gvNivel1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        protected void btnNuevoPadre_Click(object sender, ImageClickEventArgs e)
        {
            //Abrir ModalPoPuP
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModalN1').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }

        protected void gvNivel1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    //Pasar Variables
                    hfCodigoPrincipal.Value = (gvNivel1.Rows[index].FindControl("lblid") as Label).Text;
                    txtUsuario.Text = (gvNivel1.Rows[index].FindControl("lblusuario") as Label).Text;
                    txtEmpresa.Text = (gvNivel1.Rows[index].FindControl("lblempresa") as Label).Text;
                    txtProyecto.Text = (gvNivel1.Rows[index].FindControl("lblproyecto") as Label).Text;
                    txtVentana.Text = (gvNivel1.Rows[index].FindControl("lblventana") as Label).Text;

                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN1').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception)
            {
                /*  Al momento de Activar el Ordenamiento por columna, los nombres de las columnas
                    se alteran y por enden en vez de ingresar un Int ingreso un String y nos genera un error
                    Pero no hay problema lo enviamos al Catch y solucionado.... y cuando se necesite ejecutar los otros
                    eventos instantaneamente ingresara donde debe */
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_ga_seg_tpermisos.usuario = txtNewUsuario.Text;
                    ae_ga_seg_tpermisos.empresa = txtNewEmpresa.Text;
                    ae_ga_seg_tpermisos.proyecto = txtNewProyecto.Text;
                    ae_ga_seg_tpermisos.ventana = txtNewUrl.Text;
                    ae_ga_seg_tpermisos.permiso = "VENTANA";
                    ae_ga_seg_tpermisos.activo = 1;
                    an_menu.UpdateUsuarioVentan(ae_ga_seg_tpermisos);
                    CargarDatos();
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN1').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }
        
        protected void btnNewPadre_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_ga_seg_tpermisos.usuario = txtNewUsuario.Text;
                    ae_ga_seg_tpermisos.empresa = txtNewEmpresa.Text;
                    ae_ga_seg_tpermisos.proyecto = txtNewProyecto.Text;
                    ae_ga_seg_tpermisos.ventana = txtNewUrl.Text;
                    ae_ga_seg_tpermisos.permiso = "VENTANA";
                    ae_ga_seg_tpermisos.activo = 1;
                    an_menu.InsertUsuarioVentana(ae_ga_seg_tpermisos);
                    CargarDatos();
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#addModalN1').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }
    }
}