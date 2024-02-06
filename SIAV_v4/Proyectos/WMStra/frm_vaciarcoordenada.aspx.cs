using AccesoNegocios.Alertas;
using AccesoNegocios.WMStra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMStra
{
    public partial class frm_vaciarcoordenada : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMStra an_wms = new AN_WMStra();
        #endregion

        #region Funciones
        public void GridCoorCant(string dato)
        {
            try
            {
                gvCoordenadas.DataSource = an_wms.GetCoorCont(dato, 1);
                gvCoordenadas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void gvCoordenadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "VaciarCoor")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string dato = (gvCoordenadas.Rows[index].FindControl("lblid") as Label).Text;
                    string salida = an_wms.VaciarCoorCant(dato, 2);
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");
                    GridCoorCant(txtProducto.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridCoorCant(txtProducto.Text.Trim());
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

    }
}