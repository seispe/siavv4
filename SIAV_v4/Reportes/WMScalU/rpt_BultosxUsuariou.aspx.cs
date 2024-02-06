using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMScalU
{
    public partial class rpt_BultosxUsuariou : System.Web.UI.Page
    {
        #region VariablesGobales
        AN_WMScalU an_wms = new AN_WMScalU();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones
        public void GridBultos()
        {
            try
            {
                gvBultosxUsuario.DataSource = an_wms.GetBultosxUsuario(txtUsuario.Text.Trim()).DataSource;
                gvBultosxUsuario.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridBultos();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
        }
        #endregion
    }
}