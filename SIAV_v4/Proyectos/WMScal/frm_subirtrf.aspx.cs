using AccesoNegocios.Alertas;
using AccesoNegocios.Wmscal;
using System;

namespace SIAV_v4.Proyectos.WMScal
{
    public partial class frm_subirtrf : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMScal an_wmscal = new AN_WMScal();
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
                    string salida = an_wmscal.ValidaTrapasos(txtTraspaso.Text.Trim());
                    if (salida == "EXISTE")
                    {
                        if (rdbTipo.SelectedValue == "1")
                        {
                            an_wmscal.UpdateTraspasos(txtTraspaso.Text.Trim());
                            lblError.Text = an_alertas.Mensaje("CORRECTO ", "SUBIDO", "verde");
                        }
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