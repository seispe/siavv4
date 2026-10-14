using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiavQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiavQ
{
    public partial class frm_subirTraspasosQ : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMSiavQ an_wms = new AN_WMSiavQ();
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
                lblError.Text = "";
                if (txtTraspaso.Text.Length > 0)
                {
                    string salida = an_wms.ValidaTrapasos(txtTraspaso.Text.Trim());
                    if (salida == "EXISTE")
                    {
                        an_wms.UpdateTraspasosPVQ(txtTraspaso.Text.Trim());
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", "SUBIDO", "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "NO EXISTE EL NUMERO DE TRASPASO", "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE EL NUMERO DE TRASPASO", "rojo");
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