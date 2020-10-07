using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMSiav
{
    public partial class rpt_TiemposWMS : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (txtitems.Text == "")
            {
                txtitems.Text = "0";
            }
            GridView1.DataSource = an_wms.GetTiemposWMS(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), ddlprioridad.SelectedValue, txtciudad.Text.Trim(), Convert.ToInt32(txtitems.Text.Trim())).DataSource;
            GridView1.DataBind();
            

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptTiemposWMS.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:\@");
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

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                ExportToExcel();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}