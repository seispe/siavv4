using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using AccesoNegocios.Alertas;

namespace SIAV_v4.Proyectos.Cobranzas
{
    public partial class frm_NewCliente : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRuc.Text.Trim().Length > 0 && txtCiudad.Text.Trim().Length > 0 && txtContacto.Text.Trim().Length > 0 && 
                    txtCorreo.Text.Trim().Length > 0 && txtDireccion.Text.Trim().Length > 0 && txtNombreComercial.Text.Trim().Length > 0 &&
                    txtParroquia.Text.Trim().Length > 0 && txtProvincia.Text.Trim().Length > 0 && txtRazonSocial.Text.Trim().Length > 0 &&
                    txtTelefono.Text.Trim().Length > 0)
                {
                    


                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", "Todos los campos con (*) son obligatorios", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
            }
        }
    }
}