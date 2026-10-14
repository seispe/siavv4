using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_RegistroLlegada : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                VincularGrid(1, 0);
            }
        }

        protected void gvLogistica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                lblError.Text = "";
                if (e.CommandName.Equals("editRecord"))
                {
                    hfIddevolucion.Value = (gvLogistica.Rows[index].FindControl("lbliddevolucion") as LinkButton).Text;
                    //Abrir el modal
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#obsGuia').modal('show');");
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

        protected void gvLogistica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLogistica.PageIndex = e.NewPageIndex;
            VincularGrid(1, 0);
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtidDevolucion.Text.Length > 0)
            {
                VincularGrid(2, Convert.ToInt32(txtidDevolucion.Text));
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR! ", "El # de devolucion es obligatorio.", "rojo");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, hfIddevolucion.Value, "8", User.Identity.Name, txtGuia.Text.Trim());
                lblError.Text = an_alertas.Mensaje("REGISTRADO...!", "Se registro la llegada", "verde");
                VincularGrid(1, 0);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR! ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void VincularGrid(int op, int iddevolucion)
        {
            switch (op)
            {
                case 1:
                    gvLogistica.DataSource = an_devolucion.LlenarGrid(Request.Cookies["basesiav"].Value, "0", 14).DataSource;
                    gvLogistica.DataBind();
                break;
                case 2:
                    gvLogistica.DataSource = an_devolucion.LlenarGrid(Request.Cookies["basesiav"].Value, iddevolucion).DataSource;
                    gvLogistica.DataBind();
                break;
            }
           
        }
        #endregion

       
    }
}