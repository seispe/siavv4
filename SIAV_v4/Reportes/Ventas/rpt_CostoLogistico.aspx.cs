using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Ventas
{
    public partial class rpt_CostoLogistico : System.Web.UI.Page
    {
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas = null;
        public static string desde, hasta;

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            string fechadesde = "";
            string fechahasta = "";
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;

            fechadesde = Convert.ToDateTime(txtDesde.Text.Trim()).ToString("yyyy-MM-dd");
            fechahasta = Convert.ToDateTime(txtHasta.Text.Trim()).ToString("yyyy-MM-dd");
            if (Convert.ToInt32(rdBodega.SelectedValue) == 1)
            {
                GridView1.DataSource = an_ventas.GetVtasCostoLogistico(fechadesde, fechahasta).DataSource;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = an_ventas.GetVtasCostoLogisticoPVG(fechadesde, fechahasta).DataSource;
                GridView1.DataBind();
            }
            
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptCostoLogistico.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
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

        #region Funciones

        #endregion


    }
}