﻿using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_excedenteoc : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Funciones

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtOC.Text.Length > 0 && txtProducto.Text.Length > 0 && txtCantidad.Text.Length > 0)
                {
                    string salida = an_wms.InsItemRecepcion(txtOC.Text.Trim(), txtProducto.Text.Trim(), Convert.ToInt32(txtCantidad.Text.Trim()));
                    if (salida.Contains("OK"))  lblError.Text = an_alertas.Mensaje("CORRECTO ", "AGREGADO EL ITEM A LA OC " + txtOC.Text, "verde");
                    if (salida.Contains("NOORDEN")) lblError.Text = an_alertas.Mensaje("ERROR ", "NO EXISTE LA OC " + txtOC.Text, "rojo");
                    if (salida.Contains("NOPRODUCTO")) lblError.Text = an_alertas.Mensaje("ERROR ", "NO EXISTE EL ITEM " + txtProducto.Text, "rojo");
                    if (salida.Contains("NOCANTIDAD")) lblError.Text = an_alertas.Mensaje("ERROR ", "CANTIDAD ERRONEA " + txtCantidad.Text, "rojo");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "TODOS LOS CAMPOS SON OBLIGATORIOS", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}