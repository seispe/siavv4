using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.Alertas;

namespace SIAV_v4.Reportes.Devoluciones
{
    public partial class rpt_DevTraspasos : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Devolucion an_devolucion;
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (rdbTipo.SelectedValue == "1")
                {
                    ExportToExcel(1, txtDato.Text.Trim(), "");
                }
                else
                {
                    ExportToExcel(2, txtfdesde.Text, txtfhasta.Text);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void ExportToExcel(int op, string dato1, string dato2)
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_devolucion.GetrptTraspasos(op, dato1, dato2).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptTraspasos.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            /*for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[4].Attributes.Add("style", @"mso-number-format:\@");
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