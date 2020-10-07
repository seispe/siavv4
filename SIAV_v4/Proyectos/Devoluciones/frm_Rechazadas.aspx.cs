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
    public partial class frm_Rechazadas : System.Web.UI.Page
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
                VincularGridTotal();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNumDevol.Text != "")
            {
                VincularGrid(txtNumDevol.Text.Trim(), "", 1);
            }
            else if (txtFechaDesde.Text != "" && txtFechaHasta.Text != "")
            {
                VincularGrid(txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim(), 1);
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", " INGRESE FECHAS O NUM DEVOLUCION", "rojo");
            }
        }

        protected void gvBodega_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("EnviarLogistica"))
                {
                    string dev = gvBodega.DataKeys[index].Value.ToString();
                    string resultado = an_devolucion.EnvioLogistica(dev, HttpContext.Current.User.Identity.Name, 4);
                    if (resultado != "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", " ERROR DE ENVIO", "rojo");
                    }
                    else
                    {
                        VincularGridTotal();
                    }
                }
            }
            catch (Exception ex)
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
            lblartdev.Text = an_devolucion.tablaDetDevRechazadas(valor);
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
        #endregion

        #region Funciones
        public void VincularGridTotal()
        {
            gvBodega.DataSource = an_devolucion.Getrpt_devrechazadas("", "", 3).DataSource;
            gvBodega.DataBind();
        }

        public void VincularGrid(string dato1, string dato2, int op)
        {
            gvBodega.DataSource = an_devolucion.Getrpt_devrechazadas(dato1, dato2, op).DataSource;
            gvBodega.DataBind();
        }

        #endregion

        
    }
}