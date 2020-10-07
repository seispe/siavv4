using AccesoEntidades.WMSiav;
using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMScalG
{
    public partial class frm_asigreccg : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalG an_wms = new AN_WMScalG();
        AE_GA_CC_TReconteo ae_ga_cc_treconteo = new AE_GA_CC_TReconteo();
        public static string vg_producto { set; get; }
        #endregion
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlCC();
                VincularDdlUsuarios();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridDetalleConteo();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnAsginarRe_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (Convert.ToInt32(ddlConteo.SelectedValue) != 0 && Convert.ToInt32(ddlUsuario.SelectedValue) != 0)
                {
                    foreach (GridViewRow row in gvDetConteo.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                ae_ga_cc_treconteo.producto = (row.Cells[1].FindControl("lblproducto") as Label).Text.Trim();
                                ae_ga_cc_treconteo.cantconteo = Convert.ToInt32((row.Cells[3].FindControl("lblcantidad") as Label).Text.Trim());
                                ae_ga_cc_treconteo.idMaestroCC = Convert.ToInt32(ddlConteo.SelectedValue);
                                ae_ga_cc_treconteo.usuario = Convert.ToString(ddlUsuario.SelectedItem);
                                ae_ga_cc_treconteo.empresa = Request.Cookies["basesiav"].Value;
                                string salida = an_wms.InsGA_CC_PInsReconteoCab(ae_ga_cc_treconteo);

                            }
                        }
                    }
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", "ASIGNADO", "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "SELECCIONE INFORMACIÓN", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetConteo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("DetCoordenadas"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    vg_producto = (gvDetConteo.Rows[index].FindControl("lblproducto") as Label).Text;
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#detCoorModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    GridDetalleConteoCoor();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetConteoCoor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "ActualizarCantidad")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int dato = Convert.ToInt32((gvDetConteoCoor.Rows[index].FindControl("txtcantidadmanual") as TextBox).Text);
                    string coordenada = (gvDetConteoCoor.Rows[index].FindControl("lblcoordenada") as Label).Text;
                    string producto = (gvDetConteoCoor.Rows[index].FindControl("lblproducto") as Label).Text;
                    string usuario = HttpContext.Current.User.Identity.Name;
                    string empresa = Request.Cookies["basesiav"].Value;
                    int idmaestro = Convert.ToInt32(ddlConteo.SelectedValue);
                    an_wms.UpCantCoor(dato, coordenada, producto, usuario, empresa, idmaestro);
                    //Cerrar ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#detCoorModal').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetConteo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetConteo.PageIndex = e.NewPageIndex;
            GridDetalleConteo();
        }
        #endregion

        #region Funciones
        public void GridDetalleConteoCoor()
        {
            try
            {
                gvDetConteoCoor.DataSource = an_wms.GetDetConteo(vg_producto, ddlConteo.SelectedValue, Request.Cookies["basesiav"].Value, 2).DataSource;
                gvDetConteoCoor.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridDetalleConteo()
        {
            try
            {
                gvDetConteo.DataSource = an_wms.GetDifeConteo(Convert.ToInt32(ddlConteo.SelectedValue), Request.Cookies["basesiav"].Value).DataSource;
                gvDetConteo.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void VincularDdlCC()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetConteoCiclico(Request.Cookies["basesiav"].Value);

            ddlConteo.DataSource = dsp;
            ddlConteo.DataTextField = "codigo";
            ddlConteo.DataValueField = "id";
            ddlConteo.DataBind();
            ddlConteo.Items.Insert(0, new ListItem("Eliga un Conteo..", "0"));
        }

        public void VincularDdlUsuarios()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetPicking(2, Request.Cookies["basesiav"].Value);

            ddlUsuario.DataSource = dsp;
            ddlUsuario.DataTextField = "nombre";
            ddlUsuario.DataValueField = "id";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("Eliga un Usuario..", "0"));
        }
        #endregion
    }
}