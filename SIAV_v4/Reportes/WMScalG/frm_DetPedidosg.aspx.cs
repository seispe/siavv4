using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMScalG
{
    public partial class frm_DetPedidosg : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMScalG an_wms = new AN_WMScalG();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones
        public void GridDetalle()
        {
            try
            {
                gvDetPedidos.DataSource = an_wms.GetDetallePedidosLogistica(Request.Cookies["basesiav"].Value, txtPedido.Text.Trim(), 1).DataSource;
                gvDetPedidos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
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
                DataSet gpi = new DataSet();
                DataTable dti = new DataTable();
                gpi = an_wms.GetDetallePedidosLogisticaDT(Request.Cookies["basesiav"].Value, txtPedido.Text.Trim(), 1);
                dti = gpi.Tables[0];
                DataRow dt1 = dti.Rows[0];
                lblPedido.Text = dt1["DOCUMENTO"].ToString();
                lblBodega.Text = dt1["BODEGA"].ToString();
                lblRuta.Text = dt1["RUTA"].ToString();
                lblTelefonos.Text = dt1["TELEFONOS"].ToString();
                lblCliente.Text = dt1["CLIENTE"].ToString();
                lblRuc.Text = dt1["RUC"].ToString();
                lblDireccion.Text = dt1["DIRECCION"].ToString();
                lblRazonSocial.Text = dt1["RAZON_SOCIAL"].ToString();
                lblCiudad.Text = dt1["CIUDAD"].ToString();
                lblTbultos.Text = dt1["TOTAL_BULTOS"].ToString();
                GridDetalle();

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion
    }
}