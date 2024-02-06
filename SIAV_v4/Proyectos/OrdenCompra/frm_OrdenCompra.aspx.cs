using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.GP;
using AccesoNegocios.OrdenCompra;
using AccesoNegocios.Seguridad;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.OrdenCompra
{
    public partial class frm_OrdenCompra : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_OrdenCompra an_ordencompra = new AN_OrdenCompra();
        AN_Autentificar an_autentificar = new AN_Autentificar();
        public static string usuariogp { set; get; }
        #endregion

        #region Funciones Propias
        protected void Page_Load(object sender, EventArgs e)
        {
            //Declaramos Variables que necesiten parametros por defecto dentro de ellas
            if (!IsPostBack)
            {
                usuariogp = an_autentificar.getusuariogp(HttpContext.Current.User.Identity.Name);
                an_ordencompra.setFacturas();
                VincularGrid();
                VincularGridCorpal();
                VincularGridRectima();
            }
        }

        protected void gvImportadora_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    string code = gvImportadora.DataKeys[index].Value.ToString();
                    HfImportadora.Value = code.Trim();
                    lblMensajeImportadora.Text = "Esta seguro que desea generar la Orden de Compra (OCL) de la Factura: " + code + " ? <br> ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#oclImportadoraModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclImportadoraModalScript", sb.ToString(), false);
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
        
        protected void gvImportadora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvImportadora.PageIndex = e.NewPageIndex;
            VincularGrid();
        }

        protected void gvCorpal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    string code = gvCorpal.DataKeys[index].Value.ToString();
                    HfCorpal.Value = code.Trim();
                    lblMensajeCorpal.Text = "Esta seguro que desea generar la Orden de Compra (OCL) de la Factura: " + code + " ? <br> ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#oclCorpalModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclCorpalModalScript", sb.ToString(), false);
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

        protected void gvCorpal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCorpal.PageIndex = e.NewPageIndex;
            VincularGridCorpal();
        }

        protected void gvRectima_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    string code = gvRectima.DataKeys[index].Value.ToString();
                    HfRectima.Value = code.Trim();
                    lblMensajeRectima.Text = "Esta seguro que desea generar la Orden de Compra (OCL) de la Factura: " + code + " ? <br> ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#oclRectimaModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclRectimaModalScript", sb.ToString(), false);
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

        protected void gvRectima_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRectima.PageIndex = e.NewPageIndex;
            VincularGridRectima();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            VincularGrid();
        }

        protected void btnBuscarCorpal_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            VincularGridCorpal();
        }

        protected void btnBuscarRectima_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            VincularGridRectima();
        }

        protected void btnCrearImportadora_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
               
                string resultado = an_ordencompra.setOrdenCompra("GPIAV", HfImportadora.Value, ddlBodegaIAV.SelectedValue, usuariogp);
                //string resultado = "OCPRUEBA";
                if (resultado.Trim().Length < 12)
                {
                    VincularGrid();
                    lblError.Text = an_alertas.Mensaje("GENERADO...!", "Su Numero de Orden de Compra (OCL) es : " + resultado, "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR...!", resultado, "rojo");
                }
               
                    
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
            finally
            {
                //Limpiamos la observacion
                lblMensajeImportadora.Text = "";
                //Ocultando el Modal POPUP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#oclImportadoraModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "oclHideImportadoraModal", sb.ToString(), false);
            }
        }

        protected void btnCrearCorpal_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
               
                string resultado = an_ordencompra.setOrdenCompra("GPCAL", HfCorpal.Value, ddlBodegaIAV.SelectedValue, usuariogp);
                if (resultado.Trim().Length < 12)
                {
                    VincularGridCorpal();
                    lblError.Text = an_alertas.Mensaje("GENERADO...!", "Su Numero de Orden de Compra (OCL) es : " + resultado, "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR...!", resultado, "rojo");
                }
              
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
            finally
            {
                //Limpiamos la observacion
                lblMensajeCorpal.Text = "";
                //Ocultando el Modal POPUP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#oclCorpalModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclHideCorpalModalScript", sb.ToString(), false);
            }
        }

        protected void btnCrearRectima_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                
                string resultado = an_ordencompra.setOrdenCompra("GPTRA", HfRectima.Value, ddlBodegaIAV.SelectedValue, usuariogp);
                if (resultado.Trim().Length < 12)
                {
                    VincularGridRectima();
                    lblError.Text = an_alertas.Mensaje("GENERADO...!", "Su Numero de Orden de Compra (OCL) es : " + resultado, "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR...!", resultado, "rojo");
                }
                
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
            finally
            {
                //Limpiamos la observacion
                lblMensajeRectima.Text = "";
                //Ocultando el Modal POPUP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#oclRectimaModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclHideRectimaModalScript", sb.ToString(), false);
            }
        }
        #endregion

        #region Funciones Agregadas
        public void VincularGrid()
        {
            gvImportadora.DataSource = an_ordencompra.getfacturas("GPIAV", txtBuscar.Text.Trim()).DataSource;
            gvImportadora.DataBind();
        }

        public void VincularGridCorpal()
        {
            gvCorpal.DataSource = an_ordencompra.getfacturas("GPCAL", txtBuscarCorpal.Text.Trim()).DataSource;
            gvCorpal.DataBind();
        }

        public void VincularGridRectima()
        {
            gvRectima.DataSource = an_ordencompra.getfacturas("GPTRA", txtBuscarRectima.Text.Trim()).DataSource;
            gvRectima.DataBind();
        }
        #endregion

        protected void Lnkfact_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string factura = btn.CommandArgument;
            //Llenar la tabla
            lbldetalleped.Text = an_ordencompra.GetDetalleFac(factura, "GPIAV");
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detFactura').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclImportadoraModalScript", sb.ToString(), false);
        }

        protected void Lnkfactcorpal_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string factura = btn.CommandArgument;
            //Llenar la tabla
            lbldetalleped.Text = an_ordencompra.GetDetalleFac(factura, "GPCAL");
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detFactura').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclImportadoraModalScript", sb.ToString(), false);
        }

        protected void Lnkfactrectima_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string factura = btn.CommandArgument;
            //Llenar la tabla
            lbldetalleped.Text = an_ordencompra.GetDetalleFac(factura, "GPTRA");
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detFactura').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OclImportadoraModalScript", sb.ToString(), false);
        }
    }
}