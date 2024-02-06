using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_traspasoBodCua : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtfdesde.Text.Length > 0 && txtfhasta.Text.Length > 0)
                {
                    ExportToExcel();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Seleccione un rango de fechas", "rojo");
                }
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
                txtNdocumento.Text = "";
                txtMotivo.Text = "";
                DataSet gpi = new DataSet();
                DataTable dti = new DataTable();
                gpi = an_wms.GetDetalleTraspasos();
                dti = gpi.Tables[0];
                DataRow dt1 = dti.Rows[0];
                lblDesde.Text = dt1["desde"].ToString();
                lblHasta.Text = dt1["hasta"].ToString();
                lblItems.Text = dt1["items"].ToString();
                lblCantTotal.Text = dt1["canttotal"].ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#generaTraspaso').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGenerarTraspaso_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtNdocumento.Text.Length > 0)
                {
                    string resultado = an_wms.UpTraspasosBodCua(txtNdocumento.Text.Trim(), txtMotivo.Text.Trim(), HttpContext.Current.User.Identity.Name, 2);
                    //Cerrar el modal
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#generaTraspaso').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    txtfdesde.Text = "";
                    txtfhasta.Text = "";
                    if (resultado == "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("OK. ", " Traspaso " + txtNdocumento.Text.Trim() + " generado", "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "rojo");
                    }

                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " Ingrese un numero de documento", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_wms.GetMovimientosTraspaso(txtfdesde.Text, txtfhasta.Text, "", "", HttpContext.Current.User.Identity.Name, 1).DataSource;
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptTraspasos.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
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


    }
}