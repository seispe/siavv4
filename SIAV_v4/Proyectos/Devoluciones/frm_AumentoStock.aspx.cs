using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_AumentoStock : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        public static string vg_coordenada { set; get; }
        
        
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlMotivos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridUbica();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string salida = "";
                vg_coordenada = "010101064";
                if (txtProducto.Text.Length > 0 && txtCantidad.Text.Length > 0 && ddlMotivo.SelectedValue != "ninguno")
                {
                    salida = an_wms.AumentoStock(txtProducto.Text.Trim(), Convert.ToInt32(txtCantidad.Text), ddlMotivo.SelectedValue, txtObservacion.Text.Trim(), vg_coordenada, HttpContext.Current.User.Identity.Name, 1);
                    if (salida.Contains("OK"))
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", "Stock aumentado con éxito", "verde");
                        txtProducto.Text = "";
                        txtCantidad.Text = "";
                        txtObservacion.Text = "";
                        gvUbicaProducto.DataSource = null;
                        gvUbicaProducto.DataBind();
                        ddlMotivo.ClearSelection();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", salida, "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Código, cantidad y motivo obligatorios", "rojo");
                }
               
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridUbica()
        {
            try
            {
                gvUbicaProducto.DataSource = an_wms.GetUbicaProducto(txtProducto.Text.Trim(), 4).DataSource;
                gvUbicaProducto.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void VincularDdlMotivos()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetMotivosReversa(3);

            ddlMotivo.DataSource = dsp;
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "nombre";
            ddlMotivo.DataBind();
            ddlMotivo.Items.Insert(0, new ListItem("Escoga un motivo..", "ninguno"));
        }

        #endregion

     
    }
}