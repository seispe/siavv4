using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Cobranzas
{
    public partial class rpt_CuentasxCobrar : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Cobranzas an_cobranzas = null;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_cobranzas = new AN_Cobranzas(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string fecha = "";
            if (txtFecha.Text.Trim().Length > 0)
            {
                if (Request.Cookies["basesiav"].Value == "GPIAV" || Request.Cookies["basesiav"].Value == "GPALL" || Request.Cookies["basesiav"].Value == "GPVEC" || Request.Cookies["basesiav"].Value == "GPACC")
                {
                    fecha = Convert.ToDateTime(txtFecha.Text.Trim()).ToString("yyyy-MM-dd");
                    VincularGrid(Request.Cookies["basesiav"].Value, fecha);
                }
                else
                {
                    VincularGrid(Request.Cookies["basesiav"].Value, txtFecha.Text.Trim());
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "La fecha es obligatoria.","rojo");
            }
        }

        protected void gvCuentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCuentas.PageIndex = e.NewPageIndex;
            VincularGrid(Request.Cookies["basesiav"].Value, txtFecha.Text.Trim());
        }

        #region Funciones Agregadas
        public void VincularGrid(string empresa,string fecha)
        {
            gvCuentas.DataSource = an_cobranzas.rpt_cuentasxcobrar(empresa,fecha).DataSource;
            gvCuentas.DataBind();
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            if (txtFecha.Text.Trim().Length > 0)
            {
                string fecha = "";
                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                if (Request.Cookies["basesiav"].Value == "GPIAV" || Request.Cookies["basesiav"].Value == "GPALL" || Request.Cookies["basesiav"].Value == "GPVEC" || Request.Cookies["basesiav"].Value == "GPACC")
                {
                    fecha = Convert.ToDateTime(txtFecha.Text.Trim()).ToString("yyyy-MM-dd");
                    GridView1.DataSource = an_cobranzas.rpt_cuentasxcobrar(Request.Cookies["basesiav"].Value, fecha).DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = an_cobranzas.rpt_cuentasxcobrar(Request.Cookies["basesiav"].Value, txtFecha.Text.Trim()).DataSource;
                    GridView1.DataBind();
                }
                
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=rptCuentasxCobrar.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[8].Attributes.Add("style", @"mso-number-format:\@");
                }
                GridView1.RenderControl(hw);

                //style to format numbers to string
                //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                //Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "La fecha es obligatoria.", "rojo");
            }
        }
        #endregion
    }
}