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
    public partial class BI_ventas_vendedor_linea : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas = null;
        string baseBI;
        string año;
        string mes;
        int opcion, validador;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
            ElegirBase();
        }
        private void ElegirBase()
        {
            switch (Request.Cookies["basesiav"].Value)
            {
                case "GPIAV":
                    baseBI = "SI_PRE";
                    break;
                case "GPCAL":
                    baseBI = "SI_PCOR";
                    break;
                case "GPTRA":
                    baseBI = "SI_PRE_REC";
                    break;
                case "GPALL":
                    baseBI = "SI_PREALL";
                    break;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
                if (txtFecha.Text.Trim().Length > 0)
                {
                    VincularGrid(baseBI, txtFecha.Text.Trim());
                }
                else
                {
                       lblError.Text = an_alertas.Mensaje("ERROR! ", "La fecha es obligatoria", "rojo");
                }
        }

        public void VincularGrid(string empresa, string fecha)
        {
        gvDatos.DataSource = an_ventas.rpt_ventas_vendedor_linea_mensual(empresa, fecha).DataSource;
        gvDatos.DataBind();
        }

        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatos.PageIndex = e.NewPageIndex;
            VincularGrid(baseBI, txtFecha.Text.Trim());
            //            VincularGrid(baseBI, año, mes, "", opcion);
        }
        protected void ExportToExcel(object sender, EventArgs e)
        {
            if (txtFecha.Text.Trim().Length > 0)
            {
                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = an_ventas.rpt_ventas_vendedor_linea_mensual(baseBI, txtFecha.Text.Trim()).DataSource;
                GridView1.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=rptVentasPresupuestos.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[4].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[5].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[6].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[8].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:'0.00'");
                    GridView1.Rows[i].Cells[11].Attributes.Add("style", @"mso-number-format:'#,###.00'");
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