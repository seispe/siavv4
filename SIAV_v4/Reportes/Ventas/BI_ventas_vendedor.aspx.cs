using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace SIAV_v4.Reportes.Ventas
{
    public partial class BI_ventas_vendedor : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas = null;
        string baseBI;
        string año;
        string mes;
        int opcion, validador;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
            ElegirBase();
            if (!IsPostBack)
            {
                LlenarCombo();
            }
           
            //txtFecha2.Visible = false;
        }
       
        private void LlenarCombo()
        {
            ddlLineas.DataSource = an_ventas.rptLineas(baseBI).DataSource;
            ddlLineas.DataTextField = "LIN_NOMBRE";
            ddlLineas.DataValueField = "LIN_ID"; 
            ddlLineas.DataBind();
            //Llenar Informacion
        }
        private void ElegirBase()
        {
            switch (Request.Cookies["basesiav"].Value)
            {
                case "GPIAV":
                    baseBI = "SI_PRE";
                    break;
                case "GPCAL":
                    baseBI = "SI_PCOR";
                    break;
                case "GPTRA":
                    baseBI = "SI_PRE_REC";
                    break;
                case "GPALL":
                    baseBI = "SI_PREALL";
                    break;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = ddlLineas.SelectedValue.ToString();//an_alertas.Mensaje("ERROR! ", "La fecha final no puede ser anterior a la fecha inicial", "rojo");
            validador = 0;
            opcion = Convert.ToInt32(ddlTipoConsulta.SelectedValue);
            if (opcion == 1 | opcion == 3)
            {
                if (txtFecha.Text.Trim().Length > 0)
                {
                    VincularGrid(baseBI, txtFecha.Text.Trim(), txtFecha2.Text.Trim(),txtCodVendedor.Text.Trim(), ddlLineas.SelectedValue, opcion);
                }
            }
            else
            {
                if (txtFecha.Text.Trim().Length > 0 & txtFecha2.Text.Trim().Length > 0)
                {
                    if (Convert.ToDateTime(txtFecha.Text.Trim()) <= Convert.ToDateTime(txtFecha2.Text.Trim()))
                    {
                        VincularGrid(baseBI, txtFecha.Text.Trim(), txtFecha2.Text.Trim(), txtCodVendedor.Text.Trim(), ddlLineas.SelectedValue, opcion);
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR! ", "La fecha final no puede ser anterior a la fecha inicial", "rojo");
                    }
                }

            }

            if (validador == 1)
            {

            }

            //if (ddlLineas.Text.Trim().Length > 0 && txtFecha.Text.Trim().Length > 0)
            //{
            //    año = Convert.ToDateTime(txtFecha.Text.Trim()).Year.ToString();
            //    mes = Convert.ToDateTime(txtFecha.Text.Trim()).Month.ToString();
            //    opcion = Convert.ToInt32(ddlTipoConsulta.SelectedValue);
            //    UbicarMes();
            //    VincularGrid(baseBI, año,mes,"",opcion);
            //}
            //else
            //{
            //    lblError.Text = an_alertas.Mensaje("ERROR!", "La fecha es obligatoria.", "rojo");
            //}
        }
        public void VincularGrid(string empresa, string fecha1, string fecha2, string vendedor, string linea, int tipo)
        {
            gvDatos.DataSource = an_ventas.rpt_ventas_vendedorlinea(empresa, fecha1, fecha2,vendedor, linea, tipo).DataSource;
            gvDatos.DataBind();
        }

        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatos.PageIndex = e.NewPageIndex;
            VincularGrid(baseBI, txtFecha.Text.Trim(), txtFecha2.Text.Trim(), txtCodVendedor.Text.Trim(), "0", opcion);
//            VincularGrid(baseBI, año, mes, "", opcion);
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            //if (txtFecha.Text.Trim().Length > 0)
            //{
            //    //Create a dummy GridView
            //    GridView GridView1 = new GridView();
            //    GridView1.AllowPaging = false;
            //    GridView1.DataSource = an_compras.rpt_rendimientos(Request.Cookies["basesiav"].Value, txtFecha.Text.Trim()).DataSource;
            //    GridView1.DataBind();

            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.AddHeader("content-disposition",
            //     "attachment;filename=rptCuentasxCobrar.xls");
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.ms-excel";
            //    StringWriter sw = new StringWriter();
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    for (int i = 0; i < GridView1.Rows.Count; i++)
            //    {
            //        GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
            //        GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
            //        GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
            //        GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
            //        GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:'0.00'");
            //        GridView1.Rows[i].Cells[8].Attributes.Add("style", @"mso-number-format:'0.00'");
            //        GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:'0.00'");
            //        GridView1.Rows[i].Cells[10].Attributes.Add("style", @"mso-number-format:'0.00'");
            //        GridView1.Rows[i].Cells[11].Attributes.Add("style", @"mso-number-format:'#,###.00'");
            //    }
            //    GridView1.RenderControl(hw);

            //    //style to format numbers to string
            //    //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //    //Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
            //else
            //{
            //    lblError.Text = an_alertas.Mensaje("ERROR!", "La fecha es obligatoria.", "rojo");
            //}
        }
        protected void ddlTipoConsulta_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = ddlTipoConsulta.SelectedValue.ToString();

            if (ddlTipoConsulta.SelectedValue == "2")
            {
                txtFecha2.Visible = true;
            }
            else
            {
                txtFecha2.Visible = false;
            }
        }

    }
}