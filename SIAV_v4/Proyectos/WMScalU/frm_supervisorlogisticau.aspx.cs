using AccesoEntidades.WMSiav;
using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalU;
using SIAV_v4.Proyectos.Impresion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMScalU
{
    public partial class frm_supervisorlogisticau : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalU an_wms = new AN_WMScalU();
        AE_GA_WMS_Tlogistica ae_ga_wms_tlogistica = new AE_GA_WMS_Tlogistica();
        public static string pedido = "";
        public static ConexionTcp conexionTcp = new ConexionTcp();
        public static string IPADDRESS = "192.168.0.224";
        public const int PORT = 1982;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                an_wms.PedidosArmados();
                VincularDdlTransportistas();
                txtLC.Focus();
            }
        }

        protected void txtLC_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtLC.Text.Length > 15)
            {
                pedido = txtLC.Text.Trim();
                GridPedidosLogistica();
            }
            else
            {
                pedido = "";
                lblError.Text = an_alertas.Mensaje("ERROR", " No es un código valido", "rojo");
                GridPedidosLogistica();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTransportista.SelectedValue == "0")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", " ESCOGA UN TRANSPORTISTA", "rojo");
                }
                else
                {
                    //ACTUALIZAR LA TABLA DE LOGISTICA
                    foreach (GridViewRow row in gvSuperLogis.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                ae_ga_wms_tlogistica.pedido = (row.Cells[1].FindControl("lblpedido") as Label).Text.Trim();
                                ae_ga_wms_tlogistica.bulto = Convert.ToInt32((row.Cells[1].FindControl("lblbulto") as Label).Text.Trim());
                                ae_ga_wms_tlogistica.transportista = ddlTransportista.SelectedValue;
                                ae_ga_wms_tlogistica.usuario = HttpContext.Current.User.Identity.Name;
                                string logis = an_wms.UpTlogistica(ae_ga_wms_tlogistica);
                                if (logis == "OK")
                                {
                                    try
                                    {
                                        //Validamos que tengamos acceso al Servidor.
                                        if (!conexionTcp.Connectar(IPADDRESS, PORT))
                                        {
                                            lblError.Text = an_alertas.Mensaje("ERROR", " No se puede conectar al servidor!!", "rojo");
                                            return;
                                        }
                                        else
                                        {
                                            //Si tenemos acceso enviamos la impresion.
                                            var msgPack = new Paquete("login", string.Format("{0},{1},{2},{3}", "GPIAV", "jcarrasco", "32", "1"));
                                            conexionTcp.EnviarPaquete(msgPack);
                                            conexionTcp.TcpClient.Close();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        lblError.Text = an_alertas.Mensaje("ERROR", "Problemas de Impresion comunicarse con sistemas", "rojo");
                                    }
                                    lblError.Text = an_alertas.Mensaje("CORRECTO", " ASIGNADO", "verde");
                                }
                            }
                        }
                    }
                    GridPedidosLogistica();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Funciones
        public void VincularDdlTransportistas()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetPedidosArmados("", "4");

            ddlTransportista.DataSource = dsp;
            ddlTransportista.DataTextField = "transportista";
            ddlTransportista.DataValueField = "transportista";
            ddlTransportista.DataBind();
            ddlTransportista.Items.Insert(0, new ListItem("Eliga un Transportista..", "0"));
        }

        public void GridPedidosLogistica()
        {
            try
            {
                gvSuperLogis.DataSource = an_wms.GetPedidosArmados(pedido, "3");
                gvSuperLogis.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}