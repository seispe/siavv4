using AccesoEntidades.Seguridad;
using AccesoNegocios.Alertas;
using AccesoNegocios.Comisiones;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Comisiones
{
    public partial class frm_ComiConfig : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Comisiones an_comisiones;
        AN_Alertas an_alertas = new AN_Alertas();
        AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos = new AE_GA_SEG_Tpermisos();
        #endregion

        #region Funciones Propias
        protected void Page_Load(object sender, EventArgs e)
        {
            //Declaramos Variables que necesiten parametros por defecto dentro de ellas
            an_comisiones = new AN_Comisiones(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                VincularGrid();
            }
        }

        protected void gvConfig_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    //Pasar Variables
                    hfCodigoPrincipal.Value = (gvConfig.Rows[index].FindControl("lblidConfig") as Label).Text;
                    txtid.Text = (gvConfig.Rows[index].FindControl("lblidConfig") as Label).Text;
                    txtConfiguracion.Text = (gvConfig.Rows[index].FindControl("lblConfig") as Label).Text;
                    txtPorcentaje.Text = (gvConfig.Rows[index].FindControl("lblporcentaje") as Label).Text;

                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('show');");
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
        #endregion

        #region Funciones Agregadas
        public void VincularGrid()
        {
            gvConfig.DataSource = an_comisiones.GetConfigComi().DataSource;
            gvConfig.DataBind();
        }
        #endregion

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            decimal i = 0;
            bool result = decimal.TryParse(txtPorcentaje.Text, out i);
            if (result)
            {
                an_comisiones.ModificarValor(txtid.Text,txtPorcentaje.Text);
                VincularGrid();
                lblError.Text = an_alertas.Mensaje("CORRECTO..!!", "Valor Actualizado Correctamente.", "verde");
                //Abrir ModalPoPuP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#deleteModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR..!!", "Debe Ingresar un numero decimal. Ej: 3.00 / 3.10", "rojo");
            }
        }
    }
}