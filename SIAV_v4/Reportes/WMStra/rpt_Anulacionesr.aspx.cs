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
    public partial class rpt_Anulacionesr : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMStra an_wms = new AN_WMStra();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (Request.Cookies["basesiav"].Value == "GPCAL")
            {
                string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                GridView1.DataSource = an_wms.GetrptAnulaciones(fechadesde, fechahasta, 1).DataSource;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = an_wms.GetrptAnulaciones(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 1).DataSource;
                GridView1.DataBind();
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptAnulaciones.xls");
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

        public void GridAnulaciones()
        {
            try
            {
                if (Request.Cookies["basesiav"].Value == "GPCAL")
                {
                    string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                    gvAnulaciones.DataSource = an_wms.GetrptAnulaciones(fechadesde, fechahasta, 1).DataSource;
                    gvAnulaciones.DataBind();
                }
                else
                {
                    gvAnulaciones.DataSource = an_wms.GetrptAnulaciones(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 1).DataSource;
                    gvAnulaciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    GridAnulaciones();
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
    }
}