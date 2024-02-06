using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalU;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMScalU
{
    public partial class rpt_CierreProcesou : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalU an_wms = new AN_WMScalU();
        #endregion

        #region Funciones
        public void GridPicking()
        {
            try
            {
                //btnCerrar.Text = Txt_consolidado.Text.Trim();
                gvDetallePicking.DataSource = an_wms.getCierrePicking(Txt_consolidado.Text.Trim(), Convert.ToInt32(rdbTipo.SelectedValue)).DataSource;
                gvDetallePicking.DataBind();
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
            lblError.Text = "";

            if (Txt_consolidado.Text.Length > 0)
            {
                gvDetallePicking.Visible = true;
                GridPicking();
            }
            else
            {
                gvDetallePicking.Visible = false;
                lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE CONSOLIDADO/PEDIDO", "rojo");
            }
        }

        protected void gvDetallePicking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string cerrado = (e.Row.Cells[11].Text);
                int solicitada = int.Parse(e.Row.Cells[12].Text);
                int procesada = int.Parse(e.Row.Cells[13].Text);
                int armada = int.Parse(e.Row.Cells[15].Text);
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (cerrado == "CERRADO")
                    {
                        cell.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        if (armada == solicitada)
                        {
                            cell.BackColor = Color.LightGreen;
                        }

                        if ((procesada > 0) && (armada == 0))
                        {
                            cell.BackColor = Color.Yellow;
                        }

                        if ((solicitada == procesada) && (solicitada != armada))
                        {
                            cell.BackColor = Color.Yellow;
                        }

                        if (procesada == 0)
                        {
                            cell.BackColor = Color.White;
                        }
                    }
                }
            }
        }
        #endregion
    }
}