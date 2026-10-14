using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.GP;
using DocumentFormat.OpenXml.Vml.Presentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Inventario
{
    public partial class rpt_KardexGP : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Inventario an_inventario = null;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_inventario = new AN_Inventario(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridKX();
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
                ExportToExcel();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvKardex_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvKardex.PageIndex = e.NewPageIndex;
            GridKX();
        }
        #endregion

        #region Funciones
        public void GridKX()
        {
            try
            {
                if (txtProducto.Text.Length > 0)
                {
                    DataTable dt = an_inventario.GetKardexGP(txtProducto.Text.Trim(),ddlBodega.SelectedValue);

                    // 🔥 Guardas en sesión
                    Session["KardexData"] = dt;

                    gvKardex.DataSource = dt;
                    gvKardex.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (txtProducto.Text.Length > 0)
            {
                DataTable dt = an_inventario.GetKardexGP(txtProducto.Text.Trim(), ddlBodega.SelectedValue);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptKardexGP.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                // 🔥 columna fecha
                DateTime fecha;
                if (DateTime.TryParse(GridView1.Rows[i].Cells[3].Text, out fecha))
                {
                    GridView1.Rows[i].Cells[3].Text = fecha.ToString("yyyy-MM-dd");
                    GridView1.Rows[i].Cells[3].Attributes.Add(
                        "style", @"mso-number-format:'dd\/mm\/yyyy'"
                    );
                }
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