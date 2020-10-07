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
    public partial class frm_reversasg : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalG an_wms = new AN_WMScalG();
        AE_GA_WMS_Treversas ae_ga_wms_treversas = new AE_GA_WMS_Treversas();
        public static string vg_consolidado { set; get; }
        public static string vg_empresa { set; get; }
        public static string vg_pedido { set; get; }
        public static string vg_oripicking { set; get; }
        public static string vg_oriarmada { set; get; }
        public static string vg_propicking { set; get; }
        public static string vg_proarmada { set; get; }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            vg_empresa = Request.Cookies["basesiav"].Value;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            gvPedidosDet.Visible = false;
            gvCompraDet.Visible = false;
            lblPedido.Visible = false;
            if (Txt_numpedido.Text.Length > 0)
            {
                lblError.Text = "";
                GridPedidosCabecera();
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR", " INGRESE UN PEDIDO", "rojo");
            }
        }

        protected void gvPedidosCab_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPedidosDet.Visible = true;
            gvCompraDet.Visible = true;
            lblPedido.Visible = true;
            try
            {
                vg_pedido = (gvPedidosCab.SelectedRow.FindControl("lblPedido") as Label).Text;
                lblPedido.Text = vg_pedido;
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    gvCompraDet.Visible = false;
                    GridPedidosDetalle();
                }
                else
                {
                    gvPedidosDet.Visible = false;
                    GridPedidosDetalleOC();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void lnkAbrirDet_Click(object sender, EventArgs e)
        {
            //LinkButton btn = (LinkButton)(sender);
            //string valor = btn.CommandArgument;
            //string secuencia = Txt_numpedido.Text;
            //Llenar la factura
            //lblarticulos.Text = an_gestionarcompra.tablaArticulo(secuencia, valor);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#reversaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "reversaModalScript", sb.ToString(), false);
        }

        protected void gvPedidosDet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("ReversaRecord"))
                {

                    ddlProceso.ClearSelection();
                    lblProcesoOC.Visible = true;
                    lblPicadoOC.Visible = true;
                    lblDestinoOC.Visible = true;
                    lblSugeridoOC.Visible = true;
                    lblTotalProcesadoOC.Visible = true;
                    lblReversarOC.Visible = true;
                    ddlPicking.Visible = true;
                    ddlProceso.Visible = true;
                    //txtMotivo.Text = "";
                    txtDestino.Visible = true;
                    txtReversar.Visible = true;
                    txtSugeridoR.Visible = true;
                    lblProcesadoR.Visible = true;
                    ddlPicking.Items.Clear();
                    txtDestino.Text = "";
                    txtReversar.Text = "";
                    txtSugeridoR.Text = "";
                    lblProcesadoR.Text = "";
                    int index = Convert.ToInt32(e.CommandArgument);
                    vg_consolidado = (gvPedidosDet.Rows[index].FindControl("lblnumconsolidado") as Label).Text;
                    lblPedidoR.Text = vg_pedido.Substring(8);
                    lblProductoR.Text = (gvPedidosDet.Rows[index].FindControl("lblCodigo") as Label).Text;
                    vg_oripicking = (gvPedidosDet.Rows[index].FindControl("lblCoorOrigenPicking") as Label).Text.Trim();
                    vg_oriarmada = (gvPedidosDet.Rows[index].FindControl("lblCoorOrigenArmado") as Label).Text.Trim();
                    vg_propicking = (gvPedidosDet.Rows[index].FindControl("lblProcesada") as Label).Text.Trim();
                    vg_proarmada = (gvPedidosDet.Rows[index].FindControl("lblArmada") as Label).Text.Trim();
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#reversaModal').modal('show');");
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

                string salida = "";
                //SELECCIONE= reversa de recepcion.
                if (ddlProceso.SelectedValue == "Seleccione")
                {
                    ae_ga_wms_treversas.pedido = vg_pedido;
                    ae_ga_wms_treversas.producto = lblProductoR.Text.Trim();
                    ae_ga_wms_treversas.motivo = ddlMotivo.SelectedValue; //txtMotivo.Text.Trim();
                    ae_ga_wms_treversas.usuario = HttpContext.Current.User.Identity.Name;
                    string resultado = an_wms.InsGA_WMS_PReversaRecepcion(ae_ga_wms_treversas, vg_empresa);
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", resultado, "azul");

                    //Cerrar ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#reversaModal').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
                else
                {
                    string procesada = "";
                    if (ddlProceso.SelectedValue == "Picking")
                    {
                        procesada = Convert.ToString(an_wms.GetCantReversa(vg_consolidado, ddlPicking.SelectedValue, lblProductoR.Text.Trim(), 1));
                    }

                    if (ddlProceso.SelectedValue == "Armado")
                    {
                        procesada = Convert.ToString(an_wms.GetCantReversa(ddlPicking.SelectedValue, vg_pedido, lblProductoR.Text.Trim(), 2));
                    }

                    lblError.Text = "";
                    if (txtDestino.Text.Trim() == "" || txtReversar.Text.Trim() == "")
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR", " FALTA INFORMACIÓN", "rojo");
                    }
                    else if (Convert.ToDecimal(txtReversar.Text.Trim()) > Convert.ToDecimal(procesada))
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR", " LA CANTIDAD A REVERSAR NO PUEDE SER MAYOR A LA PROCESADA EN PICADO", "rojo");
                    }
                    else if (ddlMotivo.SelectedValue == "ninguno")
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR", " ESCOGA UN MOTIVO", "rojo");
                    }
                    else
                    {

                        ae_ga_wms_treversas.proceso = ddlProceso.SelectedValue;
                        ae_ga_wms_treversas.numconsolidado = vg_consolidado;
                        ae_ga_wms_treversas.pedido = vg_pedido;
                        ae_ga_wms_treversas.producto = lblProductoR.Text.Trim();
                        ae_ga_wms_treversas.motivo = ddlMotivo.SelectedValue;//ddlMotivo.SelectedValue; //txtMotivo.Text.Trim();
                        ae_ga_wms_treversas.coor_destino = txtDestino.Text.Trim();
                        ae_ga_wms_treversas.coor_sugerida = txtSugeridoR.Text.Trim();
                        ae_ga_wms_treversas.can_procesada = Convert.ToDecimal(procesada); //Convert.ToDecimal(lblProcesadoR.Text.Trim());
                        ae_ga_wms_treversas.can_reversar = Convert.ToDecimal(txtReversar.Text.Trim());
                        ae_ga_wms_treversas.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_wms_treversas.linea = Convert.ToInt32(ddlPicking.SelectedValue);
                        if (ddlProceso.SelectedValue == "Picking") salida = an_wms.InsGA_WMS_Treversas(ae_ga_wms_treversas, "1");
                        if (ddlProceso.SelectedValue == "Armado") salida = an_wms.InsGA_WMS_Treversas(ae_ga_wms_treversas, "2");


                        if (salida.Contains("CORRECTO"))
                        {
                            lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");
                        }
                        else
                        {
                            lblError.Text = an_alertas.Mensaje("ERROR ", salida, "rojo");
                        }

                        //Cerrar ModalPoPuP
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#reversaModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("Error ", ex.Message, "rojo");
            }
        }

        protected void txtDestino_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string coor = "";
                lblError.Text = "";
                //OPCION 8 TIPO DE COORDENADA PERCHA (NORMAL), OPCION 1 TIPO DE COORDENADA ARMADO
                if (ddlProceso.SelectedValue == "Picking") coor = an_wms.getCoorPedvalida(txtDestino.Text.Trim(), "", "PICKORIGEN", "1");
                if (ddlProceso.SelectedValue == "Armado") coor = an_wms.getCoorPedvalida(txtDestino.Text.Trim(), "", "ARMORIGEN", "1");
                if (coor == "0")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", " NO CORRESPONDE LA COORDENADA DESTINO", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProceso.SelectedValue == "Picking")
            {
                ddlPicking.Items.Clear();
                txtSugeridoR.Text = "";
                lblProcesadoR.Text = "";
                lblError.Text = "";
                string armado = an_wms.getValidaarmado(vg_pedido, lblProductoR.Text, 1);
                if (armado == "NO EXISTE" || armado == "0")
                {
                    //ddlPicking.Visible = false;
                    VincularDdlMotivosR();
                    VincularDdlDetPicking();

                    txtSugeridoR.Text = vg_oripicking;
                    lblProcesadoR.Text = vg_propicking;
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ADVERTENCIA", " YA SE ARMO ESTE ARTICULO, REALIZE PRIMERO LA REVERSA DE ARMADO", "verde");
                }
            }
            if (ddlProceso.SelectedValue == "Armado")
            {
                lblError.Text = "";
                VincularDdlMotivosR();
                VincularDdlDetArmado();

                txtSugeridoR.Text = vg_oriarmada;
                lblProcesadoR.Text = vg_proarmada;
            }
        }

        protected void gvCompraDet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("ReversaOC"))
                {

                    ddlProceso.ClearSelection();
                    lblProcesoOC.Visible = false;
                    lblPicadoOC.Visible = false;
                    lblDestinoOC.Visible = false;
                    lblSugeridoOC.Visible = false;
                    lblTotalProcesadoOC.Visible = false;
                    lblReversarOC.Visible = false;
                    ddlPicking.Visible = false;
                    ddlProceso.Visible = false;
                    //txtMotivo.Text = "";
                    txtDestino.Visible = false;
                    txtReversar.Visible = false;
                    txtSugeridoR.Visible = false;
                    lblProcesadoR.Visible = false;
                    int index = Convert.ToInt32(e.CommandArgument);
                    //vg_consolidado = (gvCompraDet.Rows[index].FindControl("lblDocumento") as Label).Text;
                    lblPedidoR.Text = vg_pedido;
                    lblProductoR.Text = (gvCompraDet.Rows[index].FindControl("lblCodigo") as Label).Text;
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#reversaModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void VincularDdlMotivosR()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetMotivosReversa(1);

            ddlMotivo.DataSource = dsp;
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "nombre";
            ddlMotivo.DataBind();
            ddlMotivo.Items.Insert(0, new ListItem("Escoga un motivo..", "ninguno"));
        }

        public void VincularDdlDetArmado()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetDetPicking("", vg_pedido, lblProductoR.Text.Trim(), "2");

            ddlPicking.DataSource = dsp;
            ddlPicking.DataTextField = "coor_cant";
            ddlPicking.DataValueField = "linea";
            ddlPicking.DataBind();
        }

        public void VincularDdlDetPicking()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetDetPicking(vg_consolidado, vg_pedido, lblProductoR.Text.Trim(), "1");

            ddlPicking.DataSource = dsp;
            ddlPicking.DataTextField = "coor_cant";
            ddlPicking.DataValueField = "linea";
            ddlPicking.DataBind();
        }

        public void GridPedidosCabecera()
        {
            try
            {
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    gvPedidosCab.DataSource = an_wms.getPedidosReversa(Txt_numpedido.Text.Trim(), vg_empresa, "1").DataSource;
                    gvPedidosCab.DataBind();
                }
                else
                {
                    gvPedidosCab.DataSource = an_wms.getPedidosReversa(Txt_numpedido.Text.Trim(), vg_empresa, "3").DataSource;
                    gvPedidosCab.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridPedidosDetalle()
        {
            try
            {
                gvPedidosDet.DataSource = an_wms.getPedidosReversa(vg_pedido, vg_empresa, "2").DataSource;
                gvPedidosDet.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GridPedidosDetalleOC()
        {
            try
            {
                gvCompraDet.DataSource = an_wms.getPedidosReversa(vg_pedido, vg_empresa, "4").DataSource;
                gvCompraDet.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}