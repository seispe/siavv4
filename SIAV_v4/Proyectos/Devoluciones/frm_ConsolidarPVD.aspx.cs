using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using AccesoEntidades.WMSiav;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_ConsolidarPVD : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        AE_GA_WMS_TPedusuario ae_ga_wms_tpedusuario = new AE_GA_WMS_TPedusuario();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlPicking();
                GridPedidosPicking();
                GridConsolidadosR();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string max = an_wms.getConsolidadoMax("", "", "2");
                string salida = "";
                if (ddlUsuario.SelectedValue == "0")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", " ESCOGA UN USUARIO", "rojo");
                }
                else
                {
                    //INSERTAR TABLA PEDIDOS USUARIO
                    foreach (GridViewRow row in gvPedidosPicking.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                ae_ga_wms_tpedusuario.pedido = (row.Cells[1].FindControl("lnkpedido") as LinkButton).Text.Trim();
                                //vl_usuario = (gvMaestroCompras.SelectedRow.FindControl("Label3") as Label).Text;
                                ae_ga_wms_tpedusuario.id_usuario = Convert.ToInt32(ddlUsuario.SelectedValue);
                                string estadopedido = an_wms.AnulaPedido(ae_ga_wms_tpedusuario.pedido, 2);
                                if (estadopedido == "ABIERTO")
                                {
                                    salida = an_wms.InsGA_WMS_Tconsolidado(Convert.ToInt32(max), ae_ga_wms_tpedusuario, Request.Cookies["basesiav"].Value);
                                }
                            }
                        }
                    }
                    //INSERTAR COORDENADA SUGERIDA JC
                    //an_wms.InsRutaSugerida(Request.Cookies["basesiav"].Value, Convert.ToString(ddlPicking.SelectedItem), max);
                    //GridPedidosPicking();
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void lnkpedido_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string pedido = btn.CommandArgument;
            //Llenar la tabla
            lbldetalleped.Text = an_wms.GetDetallePed(pedido);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detPedido').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ArticuloModalScript", sb.ToString(), false);
        }
        #endregion

        #region Funciones
        public void VincularDdlPicking()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetPicking(4, Request.Cookies["basesiav"].Value);

            ddlUsuario.DataSource = dsp;
            ddlUsuario.DataTextField = "nombre";
            ddlUsuario.DataValueField = "id";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("Eliga un Usuario..", "0"));
        }

        public void GridPedidosPicking()
        {
            try
            {
                lblError.Text = "";
                gvPedidosPicking.DataSource = an_wms.GetPedidosNoAsignados("", "", "", "", Request.Cookies["basesiav"].Value, "5").DataSource;
                gvPedidosPicking.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridConsolidadosR()
        {
            gvConsolidadosR.DataSource = an_wms.GetConsolidado(Request.Cookies["basesiav"].Value, "", "9");
            gvConsolidadosR.DataBind();
        }
        #endregion


    }
}