﻿using AccesoNegocios.Alertas;
using AccesoNegocios.WMScalU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMScalU
{
    public partial class frm_sincronizacionGPu : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMScalU an_wmscal = new AN_WMScalU();
        #endregion

        #region Funciones
        public void GridMaestros()
        {
            try
            {
                gvMaestros.DataSource = an_wmscal.GetUsuAsig("", 1);
                gvMaestros.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridMaestros();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvMaestros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "ExportarGP")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int maestro = Convert.ToInt32((gvMaestros.Rows[index].FindControl("lblid") as Label).Text);
                    string salida = an_wmscal.ExportarGP(maestro);
                    if (salida.Contains("ERROR"))
                    {
                        lblError.Text = an_alertas.Mensaje("", salida, "rojo");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");
                    }
                    GridMaestros();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}