using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.ListaPrecios
{
    public partial class rpt_ListaPreciosNOAsociados : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Compras an_compras = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            an_compras = new AN_Compras(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtProveedor.Text.Trim().Length > 0 || txtMarca.Text.Trim().Length > 0 || txtCodigo.Text.Trim().Length > 0 || txtDescripcion.Text.Trim().Length > 0)
            {
                lblError.Text = "";
                VincularGrid(Request.Cookies["basesiav"].Value, txtProveedor.Text.Trim(), txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), txtMarca.Text.Trim());
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Deben Tener LLeno por lo menos un campo.", "rojo");
            }
        }

        protected void gvListaPrecios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaPrecios.PageIndex = e.NewPageIndex;
            VincularGrid(Request.Cookies["basesiav"].Value, txtProveedor.Text.Trim(), txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), txtMarca.Text.Trim());
        }

        #region Funciones Agregadas
        public void VincularGrid(string empresa, string proveedor, string codigo, string descripcion, string marca)
        {
            gvListaPrecios.DataSource = an_compras.rpt_listaprecios(empresa, proveedor, codigo, descripcion,marca).DataSource;
            gvListaPrecios.DataBind();
        }
        #endregion
    }
}