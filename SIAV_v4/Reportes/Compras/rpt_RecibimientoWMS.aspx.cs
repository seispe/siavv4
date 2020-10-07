using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Compras
{
    public partial class rpt_RecibimientoWMS : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Compras an_compras = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            an_compras = new AN_Compras(Request.Cookies["basesiav"].Value);
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            if (txtOrdenCompra.Text.Trim().Length > 0)
            {
                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = an_compras.rpt_recibimientoWMS(Request.Cookies["basesiav"].Value, txtOrdenCompra.Text.Trim()).DataSource;
                GridView1.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=rptRecimientoWMS.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
                    //GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
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