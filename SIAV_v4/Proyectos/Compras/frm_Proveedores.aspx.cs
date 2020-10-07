using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Compras
{
    public partial class frm_Proveedores : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Compras an_compras;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_compras = new AN_Compras(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDatos.Text.Length > 0)
                {
                    GridProveedores();
                    rdbTipo.ClearSelection();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " INGRESE UN DATO", "rojo");
                    rdbTipo.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
                rdbTipo.ClearSelection();
            }
        }

        protected void gvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProveedores.PageIndex = e.NewPageIndex;
            GridProveedores();
        }
        #endregion

        #region Funciones
        public void GridProveedores()
        {
            if (rdbTipo.SelectedValue == "")
            {
                gvProveedores.DataSource = an_compras.GetProveedores(txtDatos.Text.Trim(), 1).DataSource;
                gvProveedores.DataBind();
            }

            if (rdbTipo.SelectedValue == "2")
            {
                gvProveedores.DataSource = an_compras.GetProveedores(txtDatos.Text.Trim(),2).DataSource;
                gvProveedores.DataBind();
            }
        }

        #endregion

        
    }
}