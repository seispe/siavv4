using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SIAV_v4.Reportes.Ventas
{
    public partial class rpt_infoPedidos : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
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
                if (txtDato.Text.Length > 0 || (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0))
                {
                    GridEP();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Ingresar un filtro", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvEstadoPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEstadoPedidos.PageIndex = e.NewPageIndex;
            GridEP();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDato.Text.Length > 0 || (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0))
                {
                    ExportToExcel();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Ingresar un filtro", "rojo");
                }
                
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridEP()
        {
            try
            {
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    if (txtDato.Text.Length > 0)
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtDato.Text.Trim(), "", 1).DataSource;
                        gvEstadoPedidos.DataBind();
                    }
                    else if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 4).DataSource;
                        gvEstadoPedidos.DataBind();
                    }
                }
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                {
                    if (txtDato.Text.Length > 0)
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtDato.Text.Trim(), "", 2).DataSource;
                        gvEstadoPedidos.DataBind();
                    }
                    else if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 5).DataSource;
                        gvEstadoPedidos.DataBind();
                    }
                }
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 3)
                {
                    if (txtDato.Text.Length > 0)
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtDato.Text.Trim(), "", 3).DataSource;
                        gvEstadoPedidos.DataBind();
                    }
                    else if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 6).DataSource;
                        gvEstadoPedidos.DataBind();
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
            if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
            {
                if (txtDato.Text.Length > 0)
                {
                    GridView1.DataSource = an_wms.GetEstadoPedidoVtas(txtDato.Text.Trim(), "", 1).DataSource;
                    GridView1.DataBind();
                }
                else if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    GridView1.DataSource = an_wms.GetEstadoPedidoVtas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 4).DataSource;
                    GridView1.DataBind();
                }
            }
            if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
            {
                if (txtDato.Text.Length > 0)
                {
                    GridView1.DataSource = an_wms.GetEstadoPedidoVtas(txtDato.Text.Trim(), "", 2).DataSource;
                    GridView1.DataBind();
                }
                else if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    GridView1.DataSource = an_wms.GetEstadoPedidoVtas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 5).DataSource;
                    GridView1.DataBind();
                }
            }
            if (Convert.ToInt32(rdbTipo.SelectedValue) == 3)
            {
                if (txtDato.Text.Length > 0)
                {
                    gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtDato.Text.Trim(), "", 3).DataSource;
                    gvEstadoPedidos.DataBind();
                }
                else if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    gvEstadoPedidos.DataSource = an_wms.GetEstadoPedidoVtas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 6).DataSource;
                    gvEstadoPedidos.DataBind();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptPedidos.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            /*for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:\@");
            }*/
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