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
    public partial class frm_agregarprodconteo : System.Web.UI.Page
    {

        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlConteos();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (ddlConteos.SelectedValue != "ninguno" && txtProducto.Text.Length > 0)
                {
                    string salida = an_wms.AgregarProdConteos(2, txtProducto.Text.Trim(), Convert.ToInt32(ddlConteos.SelectedValue));
                    if (salida == "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("Ok ", "Agregado correctamente", "verde");
                        txtProducto.Text = "";
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", salida, "rojo");
                        txtProducto.Text = "";
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Escoga un conteo o ingrese un producto", "rojo");
                }
                
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void VincularDdlConteos()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetConteosAbiertos(1, "", 0);

            ddlConteos.DataSource = dsp;
            ddlConteos.DataTextField = "nombre";
            ddlConteos.DataValueField = "id";
            ddlConteos.DataBind();
            ddlConteos.Items.Insert(0, new ListItem("Eliga un Conteo..", "ninguno"));
        }
        #endregion

       
    }
}