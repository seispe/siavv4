using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using AccesoNegocios.TOC;
using AccesoNegocios.Alertas;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.TOC
{
    public partial class frm_TiemposReposicion : System.Web.UI.Page
    {
        #region VariablesGlobales
        
        AN_Alertas an_alertas = new AN_Alertas();
        AN_TOC an_toc = new AN_TOC("conTOC_IAV");
        #endregion

        #region Funciones

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtProveedor.Text.Length > 0 && txtNuevo.Text.Length > 0)
                {
                    string resultado = an_toc.TiemposReposicionUp(2, txtProveedor.Text.Trim(), ddlBodega.SelectedValue, Convert.ToInt32(txtNuevo.Text.Trim()));
                    if (resultado == "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", "ACTUALIZADO", "verde");
                        txtProveedor.Text = "";
                        txtActual.Text = "";
                        txtNuevo.Text = "";
                        txtNombre.Text = "";
                        txtIems.Text = "";
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESAR EL NUEVO TIEMPO DE REPOSICION", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
            
        }

        protected void btngestion_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDato.Text.Length > 0)
                {
                    gvproveedores.DataSource = an_toc.TiemposReposicionGV(4, txtDato.Text.Trim(), ddlBodega.SelectedValue, 0).DataSource;
                    gvproveedores.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE INFORMACION", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        protected void gvproveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                txtProveedor.Text = (gvproveedores.SelectedRow.FindControl("lblRuc") as Label).Text.Trim();
                txtNombre.Text = (gvproveedores.SelectedRow.FindControl("lblNombre") as Label).Text.Trim();
                txtIems.Text = (gvproveedores.SelectedRow.FindControl("lblItems") as Label).Text.Trim();
                txtActual.Text = (gvproveedores.SelectedRow.FindControl("lblDias") as Label).Text.Trim();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
            finally
            {
                //Ocultando el Modal POPUP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#buscarModalP').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
            }
        }

        protected void gvproveedores_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvproveedores.PageIndex = e.NewPageIndex;
            btngestion_Click(sender, e);
        }
        #endregion


    }
}