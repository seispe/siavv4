using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.GP;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Facturacion
{
    public partial class frm_PorDespachar : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas;
        #endregion

        #region Funciones Propias
        protected void Page_Load(object sender, EventArgs e)
        {
            //Declaramos Variables que necesiten parametros por defecto dentro de ellas
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                VincularGrid();
            }
        }

        protected void gvFac_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("deleteRecord"))
                {
                    string code = gvFac.DataKeys[index].Value.ToString();
                    HfDeleteID.Value = code;
                    lblMensajeDelete.Text = "Esta seguro que desea eliminar el Registro: " + code + "  ? <br> * Ingrese el motivo de la eliminacion: <br> ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
                }
                if (e.CommandName.Equals("editRecord"))
                {
                    //an_ventas.ModificarEstado(Request.Cookies["basesiav"].Value, "","4", User.Identity.Name, "");
                    lblError.Text = an_alertas.Mensaje("ENVIADO...!", "Se envio a Empacar", "verde");
                    VincularGrid();
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

        protected void pedido_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valor = btn.CommandArgument;
            //Llenar la devolucion
            //lblarticulosdevol.Text = an_ventas.tablaDevolucion(Request.Cookies["basesiav"].Value, valor);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#devolucionModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DevolucionModalScript", sb.ToString(), false);
        }

        protected void gvFac_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFac.PageIndex = e.NewPageIndex;
            VincularGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text.Trim().Length > 0)
            {
                try
                {
                    lblError.Text = "";
                    //an_ventas.ModificarEstado(Request.Cookies["basesiav"].Value, HfDeleteID.Value, "-1", User.Identity.Name, txtObservacion.Text);
                    lblError.Text = an_alertas.Mensaje("ELIMINADO...!", "Se elimino correctamente el pedido, proceda a eliminar en la wica.", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
                }
                finally
                {
                    //Limpiamos la observacion
                    lblMensajeDelete.Text = "";
                    //Ocultando el Modal POPUP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR...!", "Por favor, ingresar el motivo de la eliminacion.", "rojo");
            }
        }
        #endregion

        #region Funciones Agregadas
        public void VincularGrid()
        {
            gvFac.DataSource = an_ventas.getPorDespachar(Request.Cookies["basesiav"].Value).DataSource;
            gvFac.DataBind();
        }
        #endregion
    }
}