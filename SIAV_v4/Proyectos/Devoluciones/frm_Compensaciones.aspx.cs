using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_Compensaciones : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                if (txtDatos.Text.Length > 0)
                {
                    grids(Convert.ToInt32(txtDatos.Text));
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Ingrese un informe de devolucion", "rojo");
                }

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                txtObservacionC.Text = "";
                txtCantCompensacion.Text = "";
                txtObservacionNoC.Text = "";
                txtCantNoCompensacion.Text = "";
                if (e.CommandName.Equals("detCompensacion"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    lblhArticulo.Text = (gvDetalle.Rows[index].FindControl("lblarticulo") as Label).Text;
                    hfDevolucion.Value = (gvDetalle.Rows[index].FindControl("lbliddevolucion") as Label).Text;
                    hfArticulo.Value = (gvDetalle.Rows[index].FindControl("lblarticulo") as Label).Text;
                    hfCantidadReal.Value = (gvDetalle.Rows[index].FindControl("lblcantidadReal") as Label).Text;
                    hfCantidadCompensada.Value = (gvDetalle.Rows[index].FindControl("lblcantCompensada") as Label).Text;
                    hfCantidadNoCompensada.Value = (gvDetalle.Rows[index].FindControl("lblcantNoCompensada") as Label).Text;
                    txtObservacionC.Text = "";
                    txtCantCompensacion.Text = "";
                    txtObservacionNoC.Text = "";
                    txtCantNoCompensacion.Text = "";
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#mdCompensacion').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string usuario = HttpContext.Current.User.Identity.Name;
                int devolucion = Convert.ToInt32(hfDevolucion.Value);
                int canReal = Convert.ToInt32(hfCantidadReal.Value);
                int cantComp = Convert.ToInt32(hfCantidadCompensada.Value);
                int cantNoComp = Convert.ToInt32(hfCantidadNoCompensada.Value);
                int sumaComp = cantComp + cantNoComp;
                int cantActualComp = 0;
                int cantActualNoComp = 0;
                if (txtCantCompensacion.Text != "" || txtCantNoCompensacion.Text != "")
                {
                    if (canReal == sumaComp)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "Cantidad total compensada/no compensada", "rojo");
                    }
                    else
                    {
                        if (txtCantCompensacion.Text != "") cantActualComp = Convert.ToInt32(txtCantCompensacion.Text);
                        if (txtCantNoCompensacion.Text != "") cantActualNoComp = Convert.ToInt32(txtCantNoCompensacion.Text);
                        int sumaActual = cantActualComp + cantActualNoComp;
                        int suma = sumaActual + sumaComp;
                        if (suma <= canReal)
                        {
                            an_devolucion.setDVCompensaciones(devolucion, hfArticulo.Value, cantActualComp, txtObservacionC.Text.Trim(),
                                   cantActualNoComp, txtObservacionNoC.Text.Trim(), usuario, 3);
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(@"<script type='text/javascript'>");
                            sb.Append("$('#mdCompensacion').modal('hide');");
                            sb.Append(@"</script>");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                            txtObservacionC.Text = "";
                            txtCantCompensacion.Text = "";
                            txtObservacionNoC.Text = "";
                            txtCantNoCompensacion.Text = "";
                            grids(devolucion);
                        }
                        else
                        {
                            lblError.Text = an_alertas.Mensaje("ERROR ", "La cantidad no puede ser mayor a la real", "rojo");
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Ingrese una cantidad", "rojo");
                }

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void grids(int devolucion)
        {
            try
            {
                gvCabecera.DataSource = an_devolucion.GetDVCompensaciones(devolucion, 1).DataSource;
                gvCabecera.DataBind();
                gvDetalle.DataSource = an_devolucion.GetDVCompensaciones(devolucion, 2).DataSource;
                gvDetalle.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }



        #endregion


    }
}