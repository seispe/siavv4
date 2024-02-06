using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiavG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiavG
{
    public partial class frm_forzarpedidosiavG : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMSiavG an_wms = new AN_WMSiavG();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                string color = "";
                lblError.Text = "";
                if (txtPedido.Text.Length > 0)
                {
                    string salida = an_wms.ForzarPed(txtPedido.Text.Trim());
                    //COLORES MENSAJE
                    if (salida.Contains("CORRECTO")) color = "verde";
                    if (salida.Contains("ERROR")) color = "rojo";
                    lblError.Text = an_alertas.Mensaje(" ", salida, color);
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE PEDIDO", "rojo");
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