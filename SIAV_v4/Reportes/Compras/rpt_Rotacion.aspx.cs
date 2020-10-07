using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Compras
{
    public partial class rpt_Rotacion : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Compras an_compras = null;
        #endregion

        #region Funciones

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_compras = new AN_Compras(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                //btnGuayaquil.Enabled = true;
                //btnMatriz.Enabled = true;
            }
        }

        protected void btnMatriz_Click(object sender, EventArgs e)
        {
            //btnGuayaquil.Enabled = false;
            btnGuayaquil.Visible = false;
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_compras.GetRotacion(1).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptRotacionMatriz.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnGuayaquil_Click(object sender, EventArgs e)
        {
            btnMatriz.Visible = false;
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_compras.GetRotacion(2).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptRotacionGuayaquil.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
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