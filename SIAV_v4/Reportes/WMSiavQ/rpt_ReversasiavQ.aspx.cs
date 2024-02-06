using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiavQ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMSiavQ
{
    public partial class rpt_ReversasiavQ : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMSiavQ an_wms = new AN_WMSiavQ();
        AN_Alertas an_alertas = new AN_Alertas();
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
                GridReversas();
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
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
            {
                GridView1.DataSource = an_wms.GetrptReversas("", "", 1, txtpedido.Text.Trim()).DataSource;
                GridView1.DataBind();
            }
            else
            {
                if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    GridView1.DataSource = an_wms.GetrptReversas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 2, "").DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptReversas.xls");
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

        public void GridReversas()
        {
            try
            {
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    gvReversas.DataSource = an_wms.GetrptReversas("", "", 1, txtpedido.Text.Trim()).DataSource;
                    gvReversas.DataBind();
                }
                else
                {
                    if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                    {
                        gvReversas.DataSource = an_wms.GetrptReversas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 2, "").DataSource;
                        gvReversas.DataBind();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                    }
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