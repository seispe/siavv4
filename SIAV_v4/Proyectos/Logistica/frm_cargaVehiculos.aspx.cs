using AccesoNegocios.Logistica;
using AccesoNegocios.Alertas;
using System;
using System.Data;

namespace SIAV_v4.Proyectos.Logistica
{
    public partial class frm_cargaVehiculos : System.Web.UI.Page
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

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtfecha.Text.Trim() != "" && ddlPlaca.SelectedValue != "0")
                {
                    Session["fecha"] = txtfecha.Text.Trim();
                    Session["placa"] = ddlPlaca.SelectedValue;
                    Session["frecuencia"] = ddlFrecuencia.SelectedValue;
                    //Abrir ventana del pdf
                    string urlPdf = "pdfCargaVehiculos.aspx";
                    string script = $"window.open('{urlPdf}', '_blank');";
                    ClientScript.RegisterStartupScript(this.GetType(), "abrirPDF", script, true);
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Debe escoger una fecha y una placa", "rojo");
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
            //EMPRESA
            string bodega;
            switch (Request.Cookies["empresasiav"].Value)
            {
                case "18":
                    bodega = "PVG";
                    break;
                case "19":
                    bodega = "PVQ";
                    break;
                case "1":
                    bodega = "MATRIZ";
                    break;
                default:
                    bodega = "MATRIZ";
                    break;
            }
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_logistica.CargaVehiculos(1, txtfecha.Text.Trim(), "", bodega, 0);

            ddlPlaca.DataSource = dsp;
            ddlPlaca.DataTextField = "placa";
            ddlPlaca.DataValueField = "placa";
            ddlPlaca.DataBind();
            ddlPlaca.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Eliga un Camion..", "0"));
        }
        #endregion

        
    }

   
}