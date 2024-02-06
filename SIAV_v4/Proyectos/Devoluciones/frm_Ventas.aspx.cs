using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_Ventas : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        #endregion

        #region Funciones Propias
        protected void Page_Load(object sender, EventArgs e)
        {
            //Declaramos Variables que necesiten parametros por defecto dentro de ellas
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                if (Request.Cookies["basesiav"].Value != "GPHOR" && Request.Cookies["basesiav"].Value != "GPPKR")
                {
                    UpdateEstados();
                }
                VincularGrid();
            }
        }

        protected void gvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                string resultado = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("deleteRecord"))
                {
                    string code = gvVentas.DataKeys[index].Value.ToString();
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
                    string id = (gvVentas.Rows[index].FindControl("lbliddevolucion") as LinkButton).Text;
                    if (Request.Cookies["basesiav"].Value == "GPPKR")
                    {
                        resultado = an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, id, "2", User.Identity.Name, "");
                    }
                    else
                    {
                        resultado = an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, id, "3", User.Identity.Name, "");
                    }
                    if (resultado.Trim().Length > 17)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR...!", resultado, "rojo");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ENVIADO...!", "Se envio al GP con el # " + resultado, "verde");
                    }                    
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

        protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVentas.PageIndex = e.NewPageIndex;
            VincularGrid();
        }
        protected void iddevolucion_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valor = btn.CommandArgument;
            //Llenar la devolucion
            lblarticulosdevol.Text = an_devolucion.tablaDevolucion(Request.Cookies["basesiav"].Value, valor);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#devolucionModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DevolucionModalScript", sb.ToString(), false);
        }

        protected void factura_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valor = btn.CommandArgument;
            //Llenar la factura
            lblarticulosfact.Text = an_devolucion.tablaFactura(Request.Cookies["basesiav"].Value, valor);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#facturaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "FacturaModalScript", sb.ToString(), false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text.Trim().Length > 0)
            {
                try
                {
                    lblError.Text = "";
                    if (Request.Cookies["basesiav"].Value == "GPPKR")
                    {
                        an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, HfDeleteID.Value, "3", User.Identity.Name, txtObservacion.Text);
                        lblError.Text = an_alertas.Mensaje("ELIMINADO...!", "Se elimino correctamente la devolucion, proceda a eliminar en la wica.", "verde");
                    }
                    else
                    {
                        an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, HfDeleteID.Value, "-1", User.Identity.Name, txtObservacion.Text);
                        lblError.Text = an_alertas.Mensaje("ELIMINADO...!", "Se elimino correctamente la devolucion, proceda a eliminar en la wica.", "verde");
                    }
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
                    VincularGrid();
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
            if (Request.Cookies["basesiav"].Value == "GPPKR")
            {
                gvVentas.DataSource = an_devolucion.LlenarGrid(Request.Cookies["basesiav"].Value, "1", 0).DataSource;
                gvVentas.DataBind();
            }
            else
            {
                gvVentas.DataSource = an_devolucion.LlenarGrid(Request.Cookies["basesiav"].Value, "2", 0).DataSource;
                gvVentas.DataBind();
            }
        }

        public void UpdateEstados()
        {
            an_devolucion.UpdateEstados();
        }
        #endregion

        protected void lblidweb_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valor = btn.CommandArgument;
            //Llenar la devolucion
            lbldetallefact.Text = an_devolucion.tablaDetalleFactura(valor);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detalleFactura').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DevolucionModalScript", sb.ToString(), false);
        }
    }
}