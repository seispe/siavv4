using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_actvoids : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        public static string vg_id { set; get; }
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
                GridVoids();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvVoids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("EditVoid"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    vg_id = (gvVoids.Rows[index].FindControl("lblid") as Label).Text;
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editVoid').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
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
                if (txtVoid.Text.Length > 0)
                {
                    string salida = an_wms.ActVoids(Convert.ToInt32(vg_id), txtVoid.Text.Trim(), 1);
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");

                    //Cerrar ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editVoid').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

                    GridVoids();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN VOID", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridVoids()
        {
            try
            {
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    gvVoids.DataSource = an_wms.GetActVoids(txtdoc.Text.Trim(), 1).DataSource;
                    gvVoids.DataBind();
                }
                else
                {
                    gvVoids.DataSource = an_wms.GetActVoids(txtdoc.Text.Trim(), 3).DataSource;
                    gvVoids.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion
    }
}