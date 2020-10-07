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
    public partial class frm_asigrackccg : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalG an_wms = new AN_WMScalG();
        AE_GA_CC_TMaestroCC ae_ga_cc_tmaestrocc = new AE_GA_CC_TMaestroCC();
        AE_GA_CC_TDetalleCC ae_ga_cc_tdetallecc = new AE_GA_CC_TDetalleCC();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlUsuario();
                VincularDdlAreas();
                VincularDdlCC();
                GridAvance();
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gvRacks.Visible = true;
                lblError.Text = "";
                GridRacks();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                //ELIGA UN CONTEO
                if (Convert.ToInt32(ddlConteo.SelectedValue) == 0)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Eliga un Conteo", "rojo");
                }
                else
                {
                    //INSERTAR EN LA TABLA DETALLE TIPO 1 TOTAL DE STOCK
                    foreach (GridViewRow row in gvRacks.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                ae_ga_cc_tdetallecc.idMaestroCC = Convert.ToInt32(ddlConteo.SelectedValue);
                                ae_ga_cc_tdetallecc.usuario = ddlUsuario.SelectedValue;
                                ae_ga_cc_tdetallecc.empresa = Request.Cookies["basesiav"].Value;
                                ae_ga_cc_tdetallecc.rack = (row.Cells[1].FindControl("lblracks") as Label).Text.Trim();
                                ae_ga_cc_tdetallecc.percha = (row.Cells[2].FindControl("lblperchas") as Label).Text.Trim();
                                ae_ga_cc_tdetallecc.area = (row.Cells[3].FindControl("lblarea") as Label).Text.Trim();
                                an_wms.InsAsigCCDetalle(ae_ga_cc_tdetallecc, 1);
                            }
                        }
                    }
                    ddlArea.ClearSelection();
                    ddlUsuario.ClearSelection();
                    gvRacks.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnNuevoC_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir el modal
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#obs').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void ddlConteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvRacks.Visible = false;
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
                //INSERTAR EN LA TABLA MAESTRO TIPO 1 TOTAL DE STOCK
                ae_ga_cc_tmaestrocc.observacion = txtObservación.Text.Trim();
                ae_ga_cc_tmaestrocc.usuario = HttpContext.Current.User.Identity.Name;
                ae_ga_cc_tmaestrocc.empresa = Request.Cookies["basesiav"].Value;
                an_wms.InsAsigCCMaestro(ae_ga_cc_tmaestrocc, 1);
                VincularDdlCC();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void VincularDdlUsuario()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetPicking(2, Request.Cookies["basesiav"].Value);

            ddlUsuario.DataSource = dsp;
            ddlUsuario.DataTextField = "nombre";
            ddlUsuario.DataValueField = "nombre";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("Eliga un Usuario..", "0"));
        }

        public void VincularDdlAreas()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetAreasBodega(Request.Cookies["basesiav"].Value);

            ddlArea.DataSource = dsp;
            ddlArea.DataTextField = "descripcion";
            ddlArea.DataValueField = "codigo";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Eliga un Área..", "0"));
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

        public void GridRacks()
        {
            try
            {
                gvRacks.DataSource = an_wms.getRacksxArea(Convert.ToInt32(ddlConteo.SelectedValue), ddlArea.SelectedValue, Request.Cookies["basesiav"].Value).DataSource;
                gvRacks.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridAvance()
        {
            try
            {
                gvAvanceUsuario.DataSource = an_wms.GetAvanceCCxUsuario("", 0).DataSource;
                gvAvanceUsuario.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        #endregion
    }
}