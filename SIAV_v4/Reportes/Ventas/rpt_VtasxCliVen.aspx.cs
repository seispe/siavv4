using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Ventas
{
    public partial class rpt_VtasxCliVen : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas = null;
        #endregion

        #region Funciones
        protected void ExportToExcel(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtRuc.Text.Length > 0 && txtDesde.Text.Length > 0 && txtHasta.Text.Length > 0)
                {
                    string fechadesde = "";
                    string fechahasta = "";
                    //Create a dummy GridView
                    GridView GridView1 = new GridView();
                    GridView1.AllowPaging = false;

                    fechadesde = Convert.ToDateTime(txtDesde.Text.Trim()).ToString("yyyy-MM-dd");
                    fechahasta = Convert.ToDateTime(txtHasta.Text.Trim()).ToString("yyyy-MM-dd");

                    GridView1.DataSource = an_ventas.GetVtasxCliVen(txtRuc.Text.Trim(), fechadesde, fechahasta).DataSource;
                    GridView1.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition",
                     "attachment;filename=rptVtasxFechasMU.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                        GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                    }
                    GridView1.RenderControl(hw);

                    //style to format numbers to string
                    //string style = "<style> .textmode { mso-number-format:\"\@\" } </style>";
                    //Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " INGRESE RUC Y FECHAS", "rojo");
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
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
        }
        #endregion

    }
}