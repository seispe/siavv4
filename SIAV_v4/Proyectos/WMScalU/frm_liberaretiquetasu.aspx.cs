using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMScalU
{
    public partial class frm_liberaretiquetasu : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalU an_wms = new AN_WMScalU();
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
                if (txtPedido.Text.Length > 0)
                {
                    string msg = an_wms.LiberaEtiquetas(txtPedido.Text.Trim());
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", msg, "azul");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Ingrese un número de pedido", "rojo");
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