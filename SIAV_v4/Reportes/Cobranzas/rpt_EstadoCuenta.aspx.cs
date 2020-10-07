using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Cobranzas
{
    public partial class rpt_EstadoCuenta : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Cobranzas an_cobranzas = null;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_cobranzas = new AN_Cobranzas(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            VincularGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(),txtFechaEmision.Text.Trim(),txtFechaVencimiento.Text.Trim());
        }

        #region Funciones Agregadas
        public void VincularGrid(string cliente,string vendedor,string ciudad,string fechaEmision, string fechaVencimiento)
        {
            gvEstadoCuenta.DataSource = an_cobranzas.LlenarGrid(cliente, vendedor, ciudad, fechaEmision, fechaVencimiento).DataSource;
            gvEstadoCuenta.DataBind();
        }

        protected void gvEstadoCuenta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEstadoCuenta.PageIndex = e.NewPageIndex;
            VincularGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim());
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_cobranzas.LlenarGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim()).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptEstadoCuenta.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void ExportToCSV(object sender, EventArgs e)
        {
            //Get the data from database into datatable
            DataTable dt = an_cobranzas.generarCSV(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim()).Tables[0];

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=rptEstadoCuenta.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";


            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                //add separator
                sb.Append(dt.Columns[k].ColumnName + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
                }
                //append new line
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}