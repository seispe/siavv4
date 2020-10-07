using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Logistica
{
    public partial class rpt_ResumenTiemposWMS : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                ExportToExcel();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR: ", ex.Message, "rojo");
            }
        }

        public void PintarGrid()
        {
            foreach (GridViewRow row in gvResumenWMS.Rows)
            {
                string semaforoiav = (row.FindControl("lblSemaforoIav") as Label).Text;
                string semaforolaar = (row.FindControl("lblSemaforoLaar") as Label).Text;
                switch (semaforoiav.Trim())
                {
                    case "Verde":
                        row.Cells[7].BackColor = Color.LightGreen;
                        break;
                    case "Rojo":
                        row.Cells[7].BackColor = Color.LightCoral;
                        break;
                    case "Amarillo":
                        row.Cells[7].BackColor = Color.Yellow;
                        break;
                }
                switch (semaforolaar.Trim())
                {
                    case "Verde":
                        row.Cells[9].BackColor = Color.LightGreen;
                        break;
                    case "Rojo":
                        row.Cells[9].BackColor = Color.LightCoral;
                        break;
                    case "Amarillo":
                        row.Cells[9].BackColor = Color.Yellow;
                        break;
                }
            }
        }

        protected void gvResumenWMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResumenWMS.PageIndex = e.NewPageIndex;
            GridResumen();
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
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_wms.GetRPT_PTiemposWMSresumen(txtFechaInicio.Text.Trim(), txtFechaFinal.Text.Trim()).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptTiemposWMSresumen.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //PRUEBA
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public void GridResumen()
        {
            try
            {
                lblError.Text = "";
                gvResumenWMS.DataSource = an_wms.GetRPT_PTiemposWMSresumen(txtFechaInicio.Text.Trim(), txtFechaFinal.Text.Trim()).DataSource;
                gvResumenWMS.DataBind();
                PintarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion


    }
}