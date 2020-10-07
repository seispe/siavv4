using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SIAV_v4.Reportes.WMSiav
{
    public partial class rpt_EstadoPedidosFecha : System.Web.UI.Page
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
            if (Convert.ToInt32(rdbTipo.SelectedValue) == 3)
            {
                if (Request.Cookies["basesiav"].Value == "GPCAL")
                {
                    string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                    gvEstadoPedidosFecha.DataSource = an_wms.GetEstadoPedidoFecha(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                    gvEstadoPedidosFecha.DataBind();
                    PintarGrid();
                }
                else
                {
                    gvEstadoPedidosFecha.DataSource = an_wms.GetEstadoPedidoFecha(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                    gvEstadoPedidosFecha.DataBind();
                    PintarGrid();
                }
            }

            if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
            {
                GridView1.DataSource = an_wms.GetEstadoPedidoFecha(txtDato.Text.Trim(), "", 2).DataSource;
                GridView1.DataBind();
            }

            if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
            {
                GridView1.DataSource = an_wms.GetEstadoPedidoFecha(txtDato.Text.Trim(), "", 1).DataSource;
                GridView1.DataBind();
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
                GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public void GridEP()
        {
            try
            {
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 3)
                {
                    if (Request.Cookies["basesiav"].Value == "GPCAL")
                    {
                        string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                        string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                        gvEstadoPedidosFecha.DataSource = an_wms.GetEstadoPedidoFecha(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                        gvEstadoPedidosFecha.DataBind();
                        PintarGrid();
                    }
                    else
                    {
                        gvEstadoPedidosFecha.DataSource = an_wms.GetEstadoPedidoFecha(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                        gvEstadoPedidosFecha.DataBind();
                        PintarGrid();
                    }
                }

                if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                {
                    gvEstadoPedidosFecha.DataSource = an_wms.GetEstadoPedidoFecha(txtDato.Text.Trim(), "", 2).DataSource;
                    gvEstadoPedidosFecha.DataBind();
                    PintarGrid();
                }

                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    gvEstadoPedidosFecha.DataSource = an_wms.GetEstadoPedidoFecha(txtDato.Text.Trim(), "", 1).DataSource;
                    gvEstadoPedidosFecha.DataBind();
                    PintarGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void PintarGrid()
        {
            foreach (GridViewRow row in gvEstadoPedidosFecha.Rows)
            {
                string picking = Convert.ToString((row.FindControl("lblpicking") as Label).Text);
                switch (picking.Trim())
                {
                    case "01/01/1900 0:00:00":
                        row.Cells[10].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[10].BackColor = Color.LightGreen;
                        break;
                }

                picking = (row.FindControl("lblarmado") as Label).Text;
                switch (picking.Trim())
                {
                    case "01/01/1900 0:00:00":
                        row.Cells[11].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[11].BackColor = Color.LightGreen;
                        break;
                }

                picking = (row.FindControl("lblpreembarque") as Label).Text;
                switch (picking.Trim())
                {
                    case "01/01/1900 0:00:00":
                        row.Cells[12].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[12].BackColor = Color.LightGreen;
                        break;
                }

                picking = (row.FindControl("lbllogistica") as Label).Text;
                switch (picking.Trim())
                {
                    case "01/01/1900 0:00:00":
                        row.Cells[13].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[13].BackColor = Color.LightGreen;
                        break;
                }

                picking = (row.FindControl("lbldespachado") as Label).Text;
                switch (picking.Trim())
                {
                    case "01/01/1900 0:00:00":
                        row.Cells[14].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[14].BackColor = Color.LightGreen;
                        break;
                }
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
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1 || Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                {
                    if (txtDato.Text.Length > 0)
                    {
                        GridEP();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "Seleccione la opción FECHAS o ingrese un pedido/cliente", "rojo");
                    }
                }
                else
                {
                    GridEP();
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
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1 || Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                {
                    if (txtDato.Text.Length > 0)
                    {
                        ExportToExcel();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "Seleccione la opción FECHAS o ingrese un pedido/cliente", "rojo");
                    }
                }
                else
                {
                    ExportToExcel();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvEstadoPedidosFecha_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int consolidado = int.Parse(e.Row.Cells[4].Text);
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        switch (consolidado)
                        {
                            case 0:
                                cell.BackColor = Color.LightCoral;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvEstadoPedidosFecha_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEstadoPedidosFecha.PageIndex = e.NewPageIndex;
            GridEP();
        }
        #endregion
    }
}