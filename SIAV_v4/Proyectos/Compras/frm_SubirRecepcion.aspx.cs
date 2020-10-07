using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Compras
{
    public partial class frm_SubirRecepcion : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
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
                string salida = "";
                lblError.Text = "";
                if (txtOC.Text.Length > 0)
                {
                    salida = an_wms.SubirRecepcionOC(txtOC.Text.Trim());
                    //COLORES MENSAJE
                    if (salida.Contains("CORRECTO")) color = "verde";
                    if (salida.Contains("ERROR")) color = "rojo";
                    lblError.Text = an_alertas.Mensaje(" ", salida, color);
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE ORDEN", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones

        #endregion


    }
}