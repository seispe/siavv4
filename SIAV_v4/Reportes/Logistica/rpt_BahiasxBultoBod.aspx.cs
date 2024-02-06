using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Logistica
{
    public partial class rpt_BahiasxBultoBod : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtpedido.Text.Length > 0)
            {
                GridBultos();
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE PEDIDO", "rojo");
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (txtpedido.Text.Length > 0)
            {
                GridView1.DataSource = an_wms.getBahiasxBultosBod(txtpedido.Text.Trim(), 2, "", "").DataSource;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = an_wms.getBahiasxBultosBod("", 1, txtfdesde.Text.Trim(), txtfhasta.Text.Trim()).DataSource;
                GridView1.DataBind();
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptBahiasxBultos.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //PRUEBA
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
            //}
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
        public void GridBultos()
        {
            try
            {
                //btnCerrar.Text = Txt_consolidado.Text.Trim();
                gvDetalleBultos.DataSource = an_wms.getBahiasxBultos(txtpedido.Text.Trim(), 2, "", "").DataSource;
                gvDetalleBultos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

    }
}