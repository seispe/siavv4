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
    public partial class rpt_ResumenDiariou : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMScalU an_wms = new AN_WMScalU();
        AN_Alertas an_alertas = new AN_Alertas();
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
                GridResumen();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvResumenxProceso.DataSource = an_wms.GetrptResumenDiarioXProceso(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 1).DataSource;
                gvResumenxProceso.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnPicking_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvResumenxProceso.DataSource = an_wms.GetrptResumenDiarioXProceso(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 2).DataSource;
                gvResumenxProceso.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnArmado_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvResumenxProceso.DataSource = an_wms.GetrptResumenDiarioXProceso(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                gvResumenxProceso.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnTransito_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvResumenxProceso.DataSource = an_wms.GetrptResumenDiarioXProceso(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 4).DataSource;
                gvResumenxProceso.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridResumen()
        {
            try
            {
                if (Request.Cookies["basesiav"].Value == "GPCAL")
                {
                    string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                    gvResumen.DataSource = an_wms.GetrptResumenDiario(fechadesde, fechahasta).DataSource;
                    gvResumen.DataBind();
                }
                else
                {
                    gvResumen.DataSource = an_wms.GetrptResumenDiario(txtfdesde.Text.Trim(), txtfhasta.Text.Trim()).DataSource;
                    gvResumen.DataBind();
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