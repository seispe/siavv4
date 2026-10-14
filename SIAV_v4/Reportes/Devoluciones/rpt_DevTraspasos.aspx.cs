using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.Alertas;
using System.Web;

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
                    ExportToExcel(Convert.ToInt32(rdbTipo.SelectedValue), txtfdesde.Text, txtfhasta.Text);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnTraspaso_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (rdbTipo.SelectedValue == "1")
                {
                    
                    string documentos = an_devolucion.GetTraspasosDocs(3, txtDato.Text.Trim(), "");
                    lblDocumentos.Text = documentos;
                }
                else
                {
                    string documentos = an_devolucion.GetTraspasosDocs(4, txtfdesde.Text.Trim(), txtfhasta.Text.Trim());
                    lblDocumentos.Text = documentos;
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#traspasoModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "reversaModalScript", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardarR_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (rdbTipo.SelectedValue == "1")
                {
                    if (lblDocumentos.Text.Length > 0 && txtnumeroDocGP.Text.Length > 0)
                    {
                        string usuario = HttpContext.Current.User.Identity.Name;
                        string resultado = an_devolucion.UpLiberaTraspasos(5, txtDato.Text.Trim(), "", txtnumeroDocGP.Text.Trim(), usuario);
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", resultado, "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "Documentos vacios", "rojo");
                    }
                }
                else
                {
                    if (lblDocumentos.Text.Length > 0 && txtnumeroDocGP.Text.Length > 0)
                    {
                        string usuario = HttpContext.Current.User.Identity.Name;
                        string resultado = an_devolucion.UpLiberaTraspasos(6, txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), txtnumeroDocGP.Text.Trim(), usuario);
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", resultado, "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "Documentos vacios", "rojo");
                    }
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#traspasoModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "reversaModalScript", sb.ToString(), false);

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