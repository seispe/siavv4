using AccesoNegocios.Alertas;
using AccesoNegocios.WMStra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMStra
{
    public partial class rpt_ConteoDetallador : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMStra an_wms = new AN_WMStra();
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
                ExportToExcel();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR: ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (rdbTipo.SelectedValue == "1") GridView1.DataSource = an_wms.GetConteoDetallado(1, txtDato.Text.Trim()).DataSource;
            if (rdbTipo.SelectedValue == "2") GridView1.DataSource = an_wms.GetConteoDetallado(2, txtDato.Text.Trim()).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptConteoDetallado.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //PRUEBA
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[4].Attributes.Add("style", @"mso-number-format:\@");
            //}
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