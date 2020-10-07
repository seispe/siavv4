using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using AccesoNegocios.Logistica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Logistica
{
    public partial class rpt_LogisticaTiempos : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Logistica an_logistica = new AN_Logistica();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text.Trim().Length > 0 && txtFechaFinal.Text.Trim().Length > 0)
            {
                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = an_logistica.rpt_tiemposlogistica(Request.Cookies["basesiav"].Value, txtFechaInicio.Text.Trim(), txtFechaFinal.Text.Trim()).DataSource;
                GridView1.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=rptTiemposLogistica.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[8].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[12].Attributes.Add("style", @"mso-number-format:\@");
                }
                GridView1.RenderControl(hw);

                //style to format numbers to string
                //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                //Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "La fecha es obligatoria.", "rojo");
            }
        }
    }
}