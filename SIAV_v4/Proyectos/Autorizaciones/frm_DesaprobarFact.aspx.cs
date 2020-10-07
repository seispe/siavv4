using AccesoNegocios.Alertas;
using AccesoNegocios.Autorizaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Autorizaciones
{
    public partial class frm_DesaprobarFact : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Autorizaciones an_autorizaciones;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_autorizaciones = new AN_Autorizaciones(Request.Cookies["basesiav"].Value);
            GridAprobar();
        }
        #endregion

        #region Funciones
        public void GridAprobar()
        {
            try
            {
                gvDesAprobar.DataSource = an_autorizaciones.GetFacturas(2).DataSource;
                gvDesAprobar.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        protected void gvDesAprobar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "Aprobacion")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string factura = (gvDesAprobar.Rows[index].FindControl("Factura") as Label).Text;
                    string salida = an_autorizaciones.setAprobarFacturas(factura, 2);
                    lblError.Text = an_alertas.Mensaje("MENSAJE. ", salida, "verde");
                    GridAprobar();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
    }
}