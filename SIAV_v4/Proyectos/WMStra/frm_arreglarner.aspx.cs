using System;
using AccesoNegocios.Alertas;
using AccesoNegocios.WMStra;

namespace SIAV_v4.Proyectos.WMStra
{
    public partial class frm_arreglarner : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMStra an_wms = new AN_WMStra();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

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
    }
}