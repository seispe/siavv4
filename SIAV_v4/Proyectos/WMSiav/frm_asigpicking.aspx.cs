using AccesoEntidades.WMSiav;
using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Drawing;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_asigpicking : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AE_GA_WMS_Trol ae_ga_wms_trol = new AE_GA_WMS_Trol();
        AE_GA_WMS_TUsuario ae_ga_wms_tusuario = new AE_GA_WMS_TUsuario();
        AE_GA_WMS_TPedusuario ae_ga_wms_tpedusuario = new AE_GA_WMS_TPedusuario();
        AN_WMS an_wms = new AN_WMS();
        
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlClientes();
                VincularDdlCiudades();
                VincularDdlTipos();
                VincularDdlPicking();
                VincularDdlConsolidado();
                GridConsolidadosR();
            }
            RegisterPostBackControl();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GridPedidosPicking();
        }
        #endregion

        #region Funciones
        public void VincularDdlConsolidado()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetConsolidado(Request.Cookies["basesiav"].Value,"", "1");

            ddlConsolidado.DataSource = dsp;
            ddlConsolidado.DataTextField = "usuario";
            ddlConsolidado.DataValueField = "numconsolidado";
            ddlConsolidado.DataBind();
            ddlConsolidado.Items.Insert(0, new ListItem("Nuevo Consolidado..", "0"));
        }

        public void VincularDdlClientes()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.Gettiposciudades(Request.Cookies["basesiav"].Value, "3");

            ddlCliente.DataSource = dsp;
            ddlCliente.DataTextField = "cliente";
            ddlCliente.DataValueField = "cliente";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, new ListItem("Eliga un Cliente..", "0"));
        }

        public void VincularDdlTipos()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.Gettiposciudades(Request.Cookies["basesiav"].Value, "2");

            ddlTipo.DataSource = dsp;
            ddlTipo.DataTextField = "tipo";
            ddlTipo.DataValueField = "tipo";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("Eliga un Tipo..", "0"));
        }

        public void VincularDdlCiudades()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.Gettiposciudades(Request.Cookies["basesiav"].Value,"1");

            ddlCiudad.DataSource = dsp;
            ddlCiudad.DataTextField = "ciudad";
            ddlCiudad.DataValueField = "ciudad";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("Eliga una Ciudad..", "0"));
        }

        public void VincularDdlPicking()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetPicking(2, Request.Cookies["basesiav"].Value);

            ddlPicking.DataSource = dsp;
            ddlPicking.DataTextField = "nombre";
            ddlPicking.DataValueField = "id";
            ddlPicking.DataBind();
            ddlPicking.Items.Insert(0, new ListItem("Eliga un Usuario..", "0"));
        }

        public void GridConsolidadosR()
        {
            gvConsolidadosR.DataSource = an_wms.GetConsolidado(Request.Cookies["basesiav"].Value, "", "5");
            gvConsolidadosR.DataBind();
        }

        public void GridPedidosPicking()
        {
            try
            {
                string cliente = ddlCliente.SelectedValue;
                if (txtPedido.Text.Length>0)
                {
                    gvPedidosPicking.DataSource = an_wms.GetPedidosNoAsignados(txtPedido.Text.Trim(), ddlCiudad.SelectedValue, ddlTipo.SelectedValue, ddlCliente.SelectedValue, Request.Cookies["basesiav"].Value, "3").DataSource;
                    gvPedidosPicking.DataBind();
                }
                else
                {
                    if (ddlTipo.SelectedValue != "0" && ddlCiudad.SelectedValue == "0" && ddlCliente.SelectedValue == "0")
                    {
                        gvPedidosPicking.DataSource = an_wms.GetPedidosNoAsignados("", ddlCiudad.SelectedValue, ddlTipo.SelectedValue, ddlCliente.SelectedValue, Request.Cookies["basesiav"].Value, "4").DataSource;
                        gvPedidosPicking.DataBind();
                    }
                    else
                    {
                        if (ddlCliente.SelectedValue != "0")
                        {
                            gvPedidosPicking.DataSource = an_wms.GetPedidosNoAsignados("", ddlCiudad.SelectedValue, ddlTipo.SelectedValue, ddlCliente.SelectedValue, Request.Cookies["basesiav"].Value, "2").DataSource;
                            gvPedidosPicking.DataBind();
                        }
                        else
                        {
                            gvPedidosPicking.DataSource = an_wms.GetPedidosNoAsignados("", ddlCiudad.SelectedValue, ddlTipo.SelectedValue, ddlCliente.SelectedValue, Request.Cookies["basesiav"].Value, "1").DataSource;
                            gvPedidosPicking.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridConsolidados()
        {
            try
            {
               gvConsolidados.DataSource = an_wms.GetConsolidado(Request.Cookies["basesiav"].Value, txtDato.Text.Trim(), "4");
               gvConsolidados.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ",ex.Message,"rojo");
            }
        }
        #endregion

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string usuario = "";
                string estado = "";
                string max = "";
                string salida = "";
                if (ddlPicking.SelectedValue == "0")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", " ESCOGA UN USUARIO", "rojo");
                }
                else
                {
                    if (ddlConsolidado.SelectedValue == "0")
                    {
                        max = an_wms.getConsolidadoMax("", "", "2");
                        estado = "0";
                        usuario = "0";
                    }
                    else
                    {
                        max = ddlConsolidado.SelectedValue;
                        estado = an_wms.getConsolidadoMax("", ddlConsolidado.SelectedValue, "7");
                        usuario = an_wms.getConsolidadoMax("", ddlConsolidado.SelectedValue, "8");
                    }
                    if (estado == "1" || estado == "0")
                    {
                        if (usuario == ddlPicking.SelectedValue || usuario == "0")
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
                                        ae_ga_wms_tpedusuario.id_usuario = Convert.ToInt32(ddlPicking.SelectedValue);
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
                            GridPedidosPicking();
                            Response.Redirect(Request.RawUrl);
                        }
                        else
                        {
                            lblError.Text = an_alertas.Mensaje("ERROR ", " NO SE PUEDE ASIGNAR UN CONSOLIDADO A DISTINTO USUARIO", "rojo");
                        }
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "EL CONSOLIDADO ESTA SIENDO ATENDIDO", "rojo");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvPedidosPicking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPedidosPicking.PageIndex = e.NewPageIndex;
            GridPedidosPicking();
        }

        protected void btnBuscarC_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            GridConsolidados();
        }

       
        protected void PartialPostBack(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string valor = btn.CommandArgument;
                //Llenar el grid
                gvPedConsol.DataSource = an_wms.GetConsolidado(Request.Cookies["basesiav"].Value, valor, "6");
                gvPedConsol.DataBind();
                hfConsolidado.Value = valor;
                //Abrir el modal
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#pedConsolidado').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }


        private void RegisterPostBackControl()
        {
            foreach (GridViewRow row in gvConsolidadosR.Rows)
            {
               LinkButton lnkFull = row.FindControl("lnkFull") as LinkButton;
               ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);
            }
        }

        protected void gvConsolidadosR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if(e.CommandName == "lnkFull")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    ddlConsolidado.SelectedValue = (gvConsolidadosR.Rows[index].FindControl("lnkPartial") as LinkButton).Text; //txtcosto.text
                    ddlPicking.SelectedValue = (gvConsolidadosR.Rows[index].FindControl("lblidusuario") as Label).Text; //txtcosto.text
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvPedConsol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "UpdatePedido")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string pedido = (gvPedConsol.Rows[index].FindControl("lblpedido") as Label).Text; //txtcosto.text
                    string resultado = an_wms.UpdatePedidoConsol(hfConsolidado.Value, pedido);
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", resultado, "amarillo");
                    // Ocultar el modal
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#pedConsolidado').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvConsolidadosR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int estado = int.Parse(e.Row.Cells[4].Text);
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (estado == 2)
                    {
                        cell.BackColor = Color.Yellow;
                    }

                    if (estado == 3)
                    {
                        cell.BackColor = Color.LightSalmon;
                    }

                    if (estado == 4)
                    {
                        cell.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        protected void gvPedidosPicking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string tipodoc = (e.Row.Cells[10].Text);
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (tipodoc != "PV")
                    {
                        cell.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        protected void gvPedidosPicking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "AnularPedido")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string pedido = (gvPedidosPicking.Rows[index].FindControl("lnkpedido") as LinkButton).Text; //txtcosto.text
                    string salida = an_wms.AnulaPedido(pedido,1);
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", salida, "info");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvConsolidados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "AnularPedido")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string pedido = (gvConsolidados.Rows[index].FindControl("lnkpedido") as LinkButton).Text; //txtcosto.text
                    string salida = an_wms.AnulaPedido(pedido,1);
                    // Ocultar el modal
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#buscarModalP').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", salida, "info");
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

    }
}