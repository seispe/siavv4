using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_Cierre : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        #endregion

        #region Funciones
        public void GridDV()
        {
            try
            {
                gvItemDV.DataSource = an_devolucion.GetItemDV(txtDevolucion.Text.Trim(), "", Request.Cookies["basesiav"].Value,1).DataSource;
                gvItemDV.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // Declaramos Variables que necesiten parametros por defecto dentro de ellas
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDevolucion.Text.Length>0)
                {
                    GridDV();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE DEVOLUCION", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvItemDV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "CierreItem")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string iddevolucion = (gvItemDV.Rows[index].FindControl("lblnumerodocumento") as Label).Text; //txtcosto.text
                    string producto = (gvItemDV.Rows[index].FindControl("lblcodigoproducto") as Label).Text; //txtcosto.text
                    string salida = an_devolucion.setCierreItemDV(iddevolucion,producto, Request.Cookies["basesiav"].Value, 2);
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", salida, "verde");
                    GridDV();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}