using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_vaciarcc : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Eventos

        #endregion

        #region Funciones
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

        public void GridDetalleConteo()
        {
            try
            {
                gvDetConteo.DataSource = an_wms.GetDetConteo(txtCoordenada.Text.Trim(), ddlConteo.SelectedValue, Request.Cookies["basesiav"].Value,1).DataSource;
                gvDetConteo.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlCC();
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

        protected void gvDetConteo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "VaciarCantidad")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string coordenada = (gvDetConteo.Rows[index].FindControl("lblcoordenada") as Label).Text; //txtcosto.text
                    string producto = (gvDetConteo.Rows[index].FindControl("lblproducto") as Label).Text; //txtcosto.text
                    an_wms.UpVaciarCoordenada(coordenada, Convert.ToInt32(ddlConteo.SelectedValue), producto, Request.Cookies["basesiav"].Value,1);
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", "VACIADO", "verde");
                    GridDetalleConteo();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtCoordenada.Text.Length > 0 && Convert.ToInt32(ddlConteo.SelectedValue) != 0)
                {
                    string coordenada = txtCoordenada.Text.Trim();
                    string salida = an_wms.UpVaciarCoordenada(coordenada, Convert.ToInt32(ddlConteo.SelectedValue), "", Request.Cookies["basesiav"].Value, 2);
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", salida, "azul");
                    GridDetalleConteo();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE LA INFORMACIÓN", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}