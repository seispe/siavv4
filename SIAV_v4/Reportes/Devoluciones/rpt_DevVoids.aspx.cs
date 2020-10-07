using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Devoluciones
{
    public partial class rpt_DevVoids : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Devolucion an_devolucion;
        AN_Alertas an_alertas = new AN_Alertas();
        public int op = 0;
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_devolucion.GetrptVoids(txtdoc.Text.Trim(), op).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptConsultaVoid.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
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
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
        }
        #endregion

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbTipo.SelectedValue == "1")
                {
                    op = 1;
                    ExportToExcel();
                }

                if (rdbTipo.SelectedValue == "2")
                {
                    op = 2;
                    ExportToExcel();
                }

                if (rdbTipo.SelectedValue == "3")
                {
                    op = 3;
                    ExportToExcel();
                }

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbTipo.SelectedValue == "1")
                {
                    op = 1;
                }

                if (rdbTipo.SelectedValue == "2")
                {
                    op = 2;
                }

                if (rdbTipo.SelectedValue == "3")
                {
                    op = 3;
                }

                lbldetalle.Text = an_devolucion.GetDetalle(txtdoc.Text.Trim(), op);

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}