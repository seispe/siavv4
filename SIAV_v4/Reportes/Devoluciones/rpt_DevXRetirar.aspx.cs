using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Devoluciones
{
    public partial class rpt_DevXRetirar : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string fechadesde = "";
            string fechahasta = "";
            if (Request.Cookies["basesiav"].Value == "GPIAV")
            {
                if (txtFechaDesde.Text.Length > 0 || txtFechaHasta.Text.Length > 0)
                {
                    fechadesde = Convert.ToDateTime(txtFechaDesde.Text.Trim()).ToString("yyyy-MM-dd");
                    fechahasta = Convert.ToDateTime(txtFechaHasta.Text.Trim()).ToString("yyyy-MM-dd");
                }
                VincularGrid(Request.Cookies["basesiav"].Value, fechadesde, fechahasta);
            }
            else
            {
                VincularGrid(Request.Cookies["basesiav"].Value, txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim());
            }
        }

        #region Funciones Agregadas
        public void VincularGrid(string empresa, string fechaDesde, string fechaHasta)
        {
            gvDev.DataSource = an_devolucion.rpt_porretirar(empresa, fechaDesde, fechaHasta).DataSource;
            gvDev.DataBind();
        }

        protected void gvDev_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDev.PageIndex = e.NewPageIndex;
            string fechadesde = "";
            string fechahasta = "";
            if (Request.Cookies["basesiav"].Value == "GPIAV")
            {
                if (txtFechaDesde.Text.Length > 0 || txtFechaHasta.Text.Length > 0)
                {
                    fechadesde = Convert.ToDateTime(txtFechaDesde.Text.Trim()).ToString("yyyy-MM-dd");
                    fechahasta = Convert.ToDateTime(txtFechaHasta.Text.Trim()).ToString("yyyy-MM-dd");
                }
                VincularGrid(Request.Cookies["basesiav"].Value, fechadesde, fechahasta);
            }
            else
            {
                VincularGrid(Request.Cookies["basesiav"].Value, txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim());
            }
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            string fechadesde = "";
            string fechahasta = "";
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;

            if (Request.Cookies["basesiav"].Value == "GPIAV")
            {
                if (txtFechaDesde.Text.Length > 0 || txtFechaHasta.Text.Length > 0)
                {
                    fechadesde = Convert.ToDateTime(txtFechaDesde.Text.Trim()).ToString("yyyy-MM-dd");
                    fechahasta = Convert.ToDateTime(txtFechaHasta.Text.Trim()).ToString("yyyy-MM-dd");
                }
                GridView1.DataSource = an_devolucion.rpt_porretirar(Request.Cookies["basesiav"].Value, fechadesde, fechahasta).DataSource;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = an_devolucion.rpt_porretirar(Request.Cookies["basesiav"].Value, txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim()).DataSource;
                GridView1.DataBind();
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptPorRetirar.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[5].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = "<style> .textmode { mso-number-format:\"\@\" } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}