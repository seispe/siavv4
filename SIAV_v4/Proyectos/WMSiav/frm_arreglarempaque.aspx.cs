using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_arreglarempaque : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Funciones

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtPedido.Text.Length > 0 && txtProducto.Text.Length > 0 && txtCantidad.Text.Length > 0)
                {
                    string salida = an_wms.InsArreglarArmado(txtPedido.Text.Trim(), txtProducto.Text.Trim(), Convert.ToInt32(txtCantidad.Text.Trim()));
                    if (salida.Contains("OK"))
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", "AGREGADO ARMADO ", "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", salida, "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "TODOS LOS CAMPOS SON OBLIGATORIOS", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion


    }
}