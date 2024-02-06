using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMScalU
{
    public partial class frm_abrircoordenadau : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalU an_wms = new AN_WMScalU();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlCC();
            }
        }

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

        protected void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCoordenada.Text.Length > 0 && Convert.ToInt32(ddlConteo.SelectedValue) != 0)
                {
                    string salida = an_wms.AbrirCoor(txtCoordenada.Text.Trim(), Request.Cookies["basesiav"].Value, Convert.ToInt32(ddlConteo.SelectedValue));
                    lblError.Text = an_alertas.Mensaje("MENSAJE ", salida, "verde");
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