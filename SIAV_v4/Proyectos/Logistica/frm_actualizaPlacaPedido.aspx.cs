using AccesoNegocios.Alertas;
using AccesoNegocios.Logistica;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static NPOI.HSSF.Util.HSSFColor;

namespace SIAV_v4.Proyectos.Logistica
{
    public partial class frm_actualizaPlacaPedido : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Logistica an_logistica = new AN_Logistica();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlPlacas();
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtPedido.Text.Length > 0 && ddlPlaca.SelectedValue != "0")
                {
                    string resultado = an_logistica.UpPlacaPedido(2, txtPedido.Text.Trim(), ddlPlaca.SelectedValue);
                    if (resultado.Contains("OK"))
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", resultado, "verde");
                        txtPedido.Text = "";
                        ddlPlaca.SelectedIndex = 0;
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "verde");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Seleccione un camion", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void VincularDdlPlacas()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_logistica.ActualizaPlacaPedido(1, "", "");

            ddlPlaca.DataSource = dsp;
            ddlPlaca.DataTextField = "placa";
            ddlPlaca.DataValueField = "placa";
            ddlPlaca.DataBind();
            ddlPlaca.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Eliga un Camion..", "0"));
        }
        #endregion


    }
}