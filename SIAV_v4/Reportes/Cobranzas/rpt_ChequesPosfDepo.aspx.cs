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
    public partial class rpt_ChequesPosfDepo : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Cobranzas an_cobranzas = null;
        #endregion

        #region Funciones
        public void Grid()
        {
            try
            {
                gvchequesPosfDepo.DataSource = an_cobranzas.Getrpt_chequesPosfDepo(Request.Cookies["basesiav"].Value, txtfdesde.Text.Trim(), txtfhasta.Text.Trim()).DataSource;
                gvchequesPosfDepo.DataBind();
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
            GridView1.DataSource = an_cobranzas.Getrpt_chequesPosfDepo(Request.Cookies["basesiav"].Value, txtfdesde.Text.Trim(), txtfhasta.Text.Trim()).DataSource;
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptChequesPosfNoDepo.xls");
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
            an_cobranzas = new AN_Cobranzas(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                Grid();
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

        protected void gvchequesPosfDepo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvchequesPosfDepo.PageIndex = e.NewPageIndex;
            Grid();
        }
    }
}