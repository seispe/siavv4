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
    public partial class frm_ingresoMotivos : System.Web.UI.Page
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
                txtObservacionFallaFabrica.Text = "";
                txtCantFallaFabrica.Text = "";
                txtObservacionCuarentena.Text = "";
                txtCantCuarentena.Text = "";
                if (e.CommandName.Equals("detMotivos"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    lblhArticulo.Text = (gvDetalle.Rows[index].FindControl("lblarticulo") as Label).Text;
                    hfDevolucion.Value = (gvDetalle.Rows[index].FindControl("lbliddevolucion") as Label).Text;
                    hfArticulo.Value = (gvDetalle.Rows[index].FindControl("lblarticulo") as Label).Text;
                    hfCantidadReal.Value = (gvDetalle.Rows[index].FindControl("lblcantidadReal") as Label).Text;
                    hfCantidadFallaFabrica.Value = (gvDetalle.Rows[index].FindControl("lblcantFallaFabrica") as Label).Text;
                    hfCantidadCuarentena.Value = (gvDetalle.Rows[index].FindControl("lblcantCuarentena") as Label).Text;
                    txtObservacionFallaFabrica.Text = "";
                    txtCantFallaFabrica.Text = "";
                    txtObservacionCuarentena.Text = "";
                    txtCantCuarentena.Text = "";
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#mdMotivos').modal('show');");
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
                int cantFallaFabrica = Convert.ToInt32(hfCantidadFallaFabrica.Value);
                int cantCuarentena = Convert.ToInt32(hfCantidadCuarentena.Value);
                int sumaComp = cantFallaFabrica + cantCuarentena;
                int cantActualFallaFabrica = 0;
                int cantActualCuarentena = 0;
                if (txtCantFallaFabrica.Text != "" || txtCantCuarentena.Text != "")
                {
                    if (canReal == sumaComp)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "Cantidad total falla de fabrica/cuarentena", "rojo");
                    }
                    else
                    {
                        if (txtCantFallaFabrica.Text != "") cantActualFallaFabrica= Convert.ToInt32(txtCantFallaFabrica.Text);
                        if (txtCantCuarentena.Text != "") cantActualCuarentena= Convert.ToInt32(txtCantCuarentena.Text);
                        int sumaActual = cantActualFallaFabrica + cantActualCuarentena;
                        int suma = sumaActual + sumaComp;
                        if (suma <= canReal)
                        {
                            an_devolucion.setDVingresoMotivos(devolucion, hfArticulo.Value, cantActualFallaFabrica, txtObservacionFallaFabrica.Text.Trim(),
                                   cantActualCuarentena, txtObservacionCuarentena.Text.Trim(), usuario, 3);
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(@"<script type='text/javascript'>");
                            sb.Append("$('#mdMotivos').modal('hide');");
                            sb.Append(@"</script>");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                            txtObservacionFallaFabrica.Text = "";
                            txtCantFallaFabrica.Text = "";
                            txtObservacionCuarentena.Text = "";
                            txtCantCuarentena.Text = "";
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
                gvCabecera.DataSource = an_devolucion.GetDVingresoMotivos(devolucion, 1).DataSource;
                gvCabecera.DataBind();
                gvDetalle.DataSource = an_devolucion.GetDVingresoMotivos(devolucion, 2).DataSource;
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