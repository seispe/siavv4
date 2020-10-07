using AccesoNegocios.Alertas;
using AccesoNegocios.Autorizaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Autorizaciones
{
    public partial class frm_ajustesaprobados : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Autorizaciones an_autorizaciones;
        #endregion

        #region Funciones
        public void GridAJ()
        {
            try
            {
                gvAjustes.DataSource = an_autorizaciones.GetAjustes("", 3).DataSource;
                gvAjustes.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_autorizaciones = new AN_Autorizaciones(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridAJ();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void lnkparametroN1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ajuste = btn.CommandArgument;
            //Llenar la tabla
            lbldetalleaj.Text = an_autorizaciones.GetDetalleAjustes(ajuste, 2);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detAjuste').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ArticuloModalScript", sb.ToString(), false);
        }

        protected void gvAjustes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "Aprobacion")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int id = Convert.ToInt32((gvAjustes.Rows[index].FindControl("lblid") as Label).Text);
                    string ajuste = (gvAjustes.Rows[index].FindControl("lnkparametroN1") as LinkButton).Text;
                    string salida = an_autorizaciones.setAprobarAjustes(id, ajuste, 2);
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");
                    GridAJ();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}