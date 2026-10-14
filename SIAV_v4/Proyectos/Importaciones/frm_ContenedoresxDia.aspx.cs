using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Importaciones
{
    public partial class frm_ContenedoresxDia : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtCargas.Text.Trim() == "") txtCargas.Text = "0";
                if (txtCont.Text.Trim() == "") txtCont.Text = "0";
                string resultado = an_wms.UpContenedoresxDia(txtFecha.Text.Trim(), Convert.ToInt32(txtCont.Text.Trim()), Convert.ToInt32(txtCargas.Text), 1);
                lblError.Text = an_alertas.Mensaje("OK ", resultado, "verde");
                txtFecha.Text = "";
                txtCont.Text = "";
                txtCargas.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones

        #endregion

    }
}