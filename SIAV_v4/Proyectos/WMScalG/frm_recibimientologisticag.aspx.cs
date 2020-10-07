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
    public partial class frm_recibimientologisticag : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalG an_wms = new AN_WMScalG();
        public static string vg_ciudad { set; get; }
        public static string vg_bultos { set; get; }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtpedido.Focus();
        }

        protected void IngresarRecibimiento(object sender, EventArgs e)
        {
            try
            {
                string pedido = lblPedido.Text;
                string r = an_wms.InsPreciboLogistica(pedido, HttpContext.Current.User.Identity.Name);
                if (r == "OK")
                {
                    //btnIngresar.Visible = false;
                    gvDetallePedido.DataSource = null;
                    gvDetallePedido.DataBind();
                    lblPedido.Text = "";
                    lblciudad.Text = "";
                    lblbultos.Text = "";
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", r, "verde");
                    Timer1.Enabled = false;
                    Timer2.Enabled = true;
                    txtpedido.Enabled = true;
                }
                else
                {
                    gvDetallePedido.DataSource = null;
                    gvDetallePedido.DataBind();
                    lblPedido.Text = "";
                    lblciudad.Text = "";
                    lblbultos.Text = "";
                    lblError.Text = an_alertas.Mensaje("ERROR ", r, "rojo");
                    Timer1.Enabled = false;
                    Timer2.Enabled = true;
                    txtpedido.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
                Timer2.Enabled = true;
            }
        }

        protected void QuitarMensaje(object sender, EventArgs e)
        {
            lblError.Text = "";
            Timer2.Enabled = false;
        }

        protected void Txt_pedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                lblPedido.Text = "";
                lblciudad.Text = "";
                lblbultos.Text = "";
                //btnIngresar.Visible = false;
                gvDetallePedido.DataSource = null;
                gvDetallePedido.DataBind();
                DataSet dsp = new DataSet();
                string pedido = txtpedido.Text;
                pedido = pedido.Replace("'", "-");
                dsp = an_wms.GetPedidoLogistica(pedido);
                if (dsp.Tables[0].Rows.Count != 0)
                {
                    DataTable dt = dsp.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        lblPedido.Text = pedido;
                        lblciudad.Text = Convert.ToString(row["ciudad"]);
                        lblbultos.Text = Convert.ToString(row["numBulto"]);
                    }
                    txtpedido.Text = "";
                    txtpedido.Enabled = false;
                    gvDetallePedido.Visible = true;
                    GridDetallePedido(pedido);
                    //btnIngresar.Visible = true;
                    //btnIngresar.Focus();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "´El código tiene formato erróneo o el pedido no existe", "rojo");
                    txtpedido.Text = "";
                    Timer2.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
                Timer2.Enabled = true;
            }

        }
        #endregion

        #region Funciones
        public void GridDetallePedido(String pedido)
        {
            try
            {
                gvDetallePedido.DataSource = an_wms.GetDetallePedidoLogistica(pedido).DataSource;
                gvDetallePedido.DataBind();
                Timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
                Timer2.Enabled = true;
            }
        }
        #endregion
    }
}