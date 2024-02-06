using AccesoNegocios.Alertas;
using AccesoNegocios.WmstraB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WmstraB
{
    public partial class rpt_KardexrB : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMStraB an_wms = new AN_WMStraB();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones
        public void GridKX()
        {
            try
            {
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 3)
                {
                    gvKardex.DataSource = an_wms.GetKardex(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), "", 3).DataSource;
                    gvKardex.DataBind();
                }

                if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                {
                    gvKardex.DataSource = an_wms.GetKardex(txtDato.Text.Trim(), "", "", 2).DataSource;
                    gvKardex.DataBind();
                }

                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    if (txtfdesde.Text.Length != 0 && txtfhasta.Text.Length != 0)
                    {
                        gvKardex.DataSource = an_wms.GetKardex(txtDato.Text.Trim(), txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 4).DataSource;
                        gvKardex.DataBind();
                    }
                    else
                    {
                        gvKardex.DataSource = an_wms.GetKardex(txtDato.Text.Trim(), "", "", 1).DataSource;
                        gvKardex.DataBind();
                    }
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
            if (Convert.ToInt32(rdbTipo.SelectedValue) == 3)
            {
                GridView1.DataSource = an_wms.GetKardex(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), "", 3).DataSource;
                GridView1.DataBind();
            }

            if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
            {
                GridView1.DataSource = an_wms.GetKardex(txtDato.Text.Trim(), "", "", 2).DataSource;
                GridView1.DataBind();
            }

            if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
            {
                if (txtfdesde.Text.Length != 0 && txtfhasta.Text.Length != 0)
                {
                    GridView1.DataSource = an_wms.GetKardex(txtDato.Text.Trim(), txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 4).DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = an_wms.GetKardex(txtDato.Text.Trim(), "", "", 1).DataSource;
                    GridView1.DataBind();
                }
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptRecepciones.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[4].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[5].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[6].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
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

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}