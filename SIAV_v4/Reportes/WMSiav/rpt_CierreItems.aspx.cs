using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMSiav
{
    public partial class rpt_CierreItems : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
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
                if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    ExportToExcel();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " INGRESE TODA LA INFORMACIÓN", "rojo");
                }
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
            string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
            string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
            GridView1.DataSource = an_wms.GetrptAnulaciones(fechadesde, fechahasta, 2).DataSource;
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptCierresItems.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

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