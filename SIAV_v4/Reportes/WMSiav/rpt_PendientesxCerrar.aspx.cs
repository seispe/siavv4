using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;

namespace SIAV_v4.Reportes.WMSiav
{
    public partial class rpt_PendientesxCerrar : System.Web.UI.Page
    {

        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridAnulaciones();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            GridAnulaciones();
        }
        #endregion

        #region Funciones
        public void GridAnulaciones()
        {
            try
            {
                gvPendientes.DataSource = an_wms.GetPendientesporRevisar().DataSource;
                gvPendientes.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion


    }
}