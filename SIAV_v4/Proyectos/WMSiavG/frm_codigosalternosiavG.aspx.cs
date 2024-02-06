using AccesoEntidades.WMSiav;
using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiavG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiavG
{
    public partial class frm_codigosalternosiavG : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMSiavG an_wms = new AN_WMSiavG();
        AE_GA_WMS_Talterno ae_ga_wms_talterno = new AE_GA_WMS_Talterno();
        public static string vg_empresa { set; get; }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            vg_empresa = Request.Cookies["basesiav"].Value;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            txtNAlterno.Text = "";
            if (txtCodigo.Text.Length == 14)
            {
                GridCodAlt();
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR", " CODIGO NO VALIDO", "rojo");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtNAlterno.Text.Length > 0 && txtCodigo.Text.Length == 14)
            {
                int valida = Convert.ToInt32(an_wms.GetValidaProd("", txtCodigo.Text.Trim(), vg_empresa, 1));
                if (valida > 0)
                {
                    insertarDatos();
                    lblError.Text = an_alertas.Mensaje("CORRECTO", " GUARDADO", "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", " CODIGO DE EMPRESA NO EXISTE", "rojo");
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR", " CODIGOS NO PUEDEN SER VACIOS", "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridCodAlt()
        {
            lblError.Text = "";
            try
            {
                gvCodAlternos.DataSource = an_wms.GetCodAlt(txtCodigo.Text.Trim(), vg_empresa);
                gvCodAlternos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void insertarDatos()
        {
            try
            {
                //INSERTAR DATOS EN LA TABLA DE CODIGOS ALTERNOS
                ae_ga_wms_talterno.codigoproducto = txtCodigo.Text.Trim();
                ae_ga_wms_talterno.codigoalterno = txtNAlterno.Text.Trim();
                ae_ga_wms_talterno.usuario = HttpContext.Current.User.Identity.Name;
                ae_ga_wms_talterno.empresa = vg_empresa;
                an_wms.InsCodAlt(ae_ga_wms_talterno);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvCodAlternos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                an_wms.GetValidaProd((gvCodAlternos.SelectedRow.FindControl("lblcodigoalterno") as Label).Text, (gvCodAlternos.SelectedRow.FindControl("lblproducto") as Label).Text, vg_empresa, 2);
                GridCodAlt();
                lblError.Text = an_alertas.Mensaje("CORRECTO", " ELIMINADO", "verde");
            }
            catch (Exception ex)
            {

                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion
    }
}