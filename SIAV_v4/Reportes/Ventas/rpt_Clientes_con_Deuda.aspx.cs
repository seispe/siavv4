using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace SIAV_v4.Reportes.Ventas
{
    public partial class rpt_Clientes_con_Deuda : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas = null;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
                VincularGrid(Request.Cookies["basesiav"].Value);
        }
        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatos.PageIndex = e.NewPageIndex;
            VincularGrid(Request.Cookies["basesiav"].Value);
        }

        #region Funciones Agregadas
        public void VincularGrid(string empresa)
        {
            gvDatos.DataSource = an_ventas.rpt_clientes_con_deuda(empresa).DataSource;
            gvDatos.DataBind();
        }
        protected void ExportToExcel(object sender, EventArgs e)
        {
                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = an_ventas.rpt_clientes_con_deuda(Request.Cookies["basesiav"].Value).DataSource;
                GridView1.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=rptClientes_con_Deuda.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-text-format:\@");
                    GridView1.Rows[i].Cells[11].Attributes.Add("style", @"mso-number-format:'#,###.##'");
                    GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:'#,###.##'");
                }
                GridView1.RenderControl(hw);

                //style to format numbers to string
                //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                //Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        
        #endregion
    }
}