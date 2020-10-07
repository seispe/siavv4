using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_VentasBodega : System.Web.UI.Page
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
                if (Request.Cookies["basesiav"].Value != "GPTRA")
                {
                    //UpdateEstados();
                }
                VincularGrid();
            }
        }

        protected void gvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("printRecord"))
                {
                    string id = (gvVentas.Rows[index].FindControl("lbliddevolucion") as LinkButton).Text;
                    ReportParameter[] rptParametros = new ReportParameter[2];

                    Session["Empresa"] = Request.Cookies["basesiav"].Value;
                    //CORPAL
                    if (Request.Cookies["basesiav"].Value == "GPCAL")
                    {
                        Session["Directorio"] = "CORPAL/VENTAS/DEVOLUCIONES";
                    }
                    else
                    {
                        Session["Directorio"] = "SIAV";
                    }
                    

                    Session["NombreReporte"] = "DevolucionEntregaBodega";
                    rptParametros[0] = new ReportParameter("id", id);
                    rptParametros[1] = new ReportParameter("base", Request.Cookies["basesiav"].Value);

                    Session["Parameter"] = 1;
                    Session["ReportParameter"] = rptParametros;

                    // Cuando se ocupe UpdatePanel
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", "<script>window.open('/SIAV_v4/Reportes/Reporte247.aspx')</script>", false);
                    // Cuando no se ocupe UpdatePanel
                    //Response.Write("<script>window.open('/SIAV_v4/Reportes/Reporte247.aspx')</script>");
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
        #endregion

        #region Funciones Agregadas
        public void VincularGrid()
        {
            gvVentas.DataSource = an_devolucion.LlenarGrid(Request.Cookies["basesiav"].Value, "2").DataSource;
            gvVentas.DataBind();
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