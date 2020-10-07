using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMScalG
{
    public partial class rpt_Comprometidosg : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMScalG an_wms = new AN_WMScalG();
        AN_Alertas an_alertas = new AN_Alertas();
        public static int op;
        #endregion

        #region Funciones
        public void GridComprometidos()
        {
            try
            {
                if (op == 2)
                {
                    gvComprometidos.DataSource = an_wms.GetComprometidos(txtproducto.Text.Trim(), "", op).DataSource;
                    gvComprometidos.DataBind();
                }
                else
                {
                    gvComprometidos.DataSource = an_wms.GetComprometidos(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), op).DataSource;
                    gvComprometidos.DataBind();
                }
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
                if (txtproducto.Text.Length > 0)
                {
                    op = 2;
                    GridComprometidos();
                }
                else
                {
                    op = 1;
                    GridComprometidos();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvComprometidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComprometidos.PageIndex = e.NewPageIndex;
            GridComprometidos();
        }
        #endregion
    }
}