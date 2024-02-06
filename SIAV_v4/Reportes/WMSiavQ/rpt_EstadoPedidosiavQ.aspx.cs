using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiavQ;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMSiavQ
{
    public partial class rpt_EstadoPedidosiavQ : System.Web.UI.Page
    {
        #region VariablesGlobables
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

        public void PintarGrid()
        {
            foreach (GridViewRow row in gvEstadoPedidos.Rows)
            {
                string picking = (row.FindControl("lblpicking") as Label).Text;
                switch (picking.Trim())
                {
                    case "OK":
                        row.Cells[10].BackColor = Color.LightGreen;
                        break;
                    case "EN PROCESO":
                        row.Cells[10].BackColor = Color.LightCoral;
                        break;
                }

                picking = (row.FindControl("lblarmado") as Label).Text;
                switch (picking.Trim())
                {
                    case "OK":
                        row.Cells[11].BackColor = Color.LightGreen;
                        break;
                    case "EN PROCESO":
                        row.Cells[11].BackColor = Color.LightCoral;
                        break;
                }

                picking = (row.FindControl("lblpreembarque") as Label).Text;
                switch (picking.Trim())
                {
                    case "OK":
                        row.Cells[12].BackColor = Color.LightGreen;
                        break;
                    case "EN PROCESO":
                        row.Cells[12].BackColor = Color.LightCoral;
                        break;
                }

                picking = (row.FindControl("lbllogistica") as Label).Text;
                switch (picking.Trim())
                {
                    case "OK":
                        row.Cells[13].BackColor = Color.LightGreen;
                        break;
                    case "EN PROCESO":
                        row.Cells[13].BackColor = Color.LightCoral;
                        break;
                }

                picking = (row.FindControl("lbldespachado") as Label).Text;
                switch (picking.Trim())
                {
                    case "EN PROCESO":
                        row.Cells[14].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[14].BackColor = Color.LightGreen;
                        break;
                }

                picking = (row.FindControl("lblrecibe") as Label).Text;
                switch (picking.Trim())
                {
                    case "LAAR":
                        row.Cells[15].BackColor = Color.LightCoral;
                        break;
                    case "EN PROCESO":
                        row.Cells[15].BackColor = Color.LightCoral;
                        break;
                    default:
                        row.Cells[15].BackColor = Color.LightGreen;
                        break;
                }
            }
        }

        protected void gvEstadoPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    GridView1.DataSource = an_wms.GetEstadoPedido(fechadesde, fechahasta, 3).DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = an_wms.GetEstadoPedido(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                    GridView1.DataBind();
                }
            }

            if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
            {
                GridView1.DataSource = an_wms.GetEstadoPedido(txtDato.Text.Trim(), "", 2).DataSource;
                GridView1.DataBind();
            }

            if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
            {
                GridView1.DataSource = an_wms.GetEstadoPedido(txtDato.Text.Trim(), "", 1).DataSource;
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
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedido(fechadesde, fechahasta, 3).DataSource;
                        gvEstadoPedidos.DataBind();
                        PintarGrid();
                    }
                    else
                    {
                        gvEstadoPedidos.DataSource = an_wms.GetEstadoPedido(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 3).DataSource;
                        gvEstadoPedidos.DataBind();
                        PintarGrid();
                    }
                }

                if (Convert.ToInt32(rdbTipo.SelectedValue) == 2)
                {
                    gvEstadoPedidos.DataSource = an_wms.GetEstadoPedido(txtDato.Text.Trim(), "", 2).DataSource;
                    gvEstadoPedidos.DataBind();
                    PintarGrid();
                }

                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    gvEstadoPedidos.DataSource = an_wms.GetEstadoPedido(txtDato.Text.Trim(), "", 1).DataSource;
                    gvEstadoPedidos.DataBind();
                    PintarGrid();
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