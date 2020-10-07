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
    public partial class rpt_VtasxLinea : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            string fechadesde = "";
            string fechahasta = "";
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (Request.Cookies["basesiav"].Value == "GPIAV")
            {
                if (txtfdesde.Text.Length > 0 || txtfhasta.Text.Length > 0)
                {
                    fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                }
                GridView1.DataSource = an_ventas.GetVtasxLineas(fechadesde, fechahasta).DataSource;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = an_ventas.GetVtasxLineas(txtfdesde.Text.Trim(), txtfhasta.Text.Trim()).DataSource;
                GridView1.DataBind();
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptVtasxLineas.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //Apply text style to each Row
                //GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
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

        #region Funciones

        #endregion


    }
}