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
    public partial class frm_subirpvc : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #endregion

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                string color = "";
                string salida = "";
                lblError.Text = "";
                if (txtFact.Text.Length > 0)
                {
                    if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                    {
                        salida = an_wms.SubirPVC(txtFact.Text.Trim());
                    }

                    if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                    {
                        salida = an_wms.SubirNC(txtFact.Text.Trim());
                    }
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
    }
}