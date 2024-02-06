using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiavQ;
using System;

namespace SIAV_v4.Proyectos.WMSiavQ
{
    public partial class frm_arreglarneiavQ : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMSiavQ an_wms = new AN_WMSiavQ();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                string color = "";
                lblError.Text = "";
                if (txtPedido.Text.Length > 0)
                {
                    string salida = an_wms.ArreglaNE(txtPedido.Text.Trim());
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