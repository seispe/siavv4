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
    public partial class frm_cierrerecepcion : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                string color = "";
                lblError.Text = "";
                if (txtOC.Text.Length > 0)
                {
                    string salida = an_wms.CerrarOC(txtOC.Text.Trim());
                    if (salida.Contains("CORRECTO")) color = "verde";
                    if (salida.Contains("ERROR")) color = "rojo";
                    lblError.Text = an_alertas.Mensaje("", salida, color);
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