using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_asigfamilias : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        public static int op;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Funciones
        public void GridProductos()
        {
            try
            {
                gvProductos.DataSource = an_wms.GetCCproductofamilia(op, txtDato.Text.Trim());
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridProdFam()
        {
            try
            {
                gvProdFam.DataSource = an_wms.GetCCproductofamilia(2, txtFamilia.Text.Trim());
                gvProdFam.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDato.Text.Length > 0)
                {
                    op = 4;
                }
                else
                {
                    op = 3;
                }
                gvProductos.Visible = true;
                GridProductos();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void imgB_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvProdFam.Visible = true;
                GridProdFam();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string salida = "";
                string salida2 = "";
                lblError.Text = "";
                foreach (GridViewRow row in gvProductos.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string producto = (row.Cells[1].FindControl("lblproducto") as Label).Text.Trim();
                            foreach (GridViewRow rows in gvProdFam.Rows)
                            {
                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    CheckBox chkFamilia = (rows.Cells[0].FindControl("chkFamilia") as CheckBox);
                                    if (chkFamilia.Checked)
                                    {
                                        string familia = (rows.Cells[1].FindControl("lblcodigo") as Label).Text.Trim();
                                        salida = an_wms.AsigFamilia(producto, familia, 1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            salida2 = "VISTEE UN PRODUCTO O FAMILIA";
                        }
                    }
                }
                if (salida2 != "") lblError.Text = an_alertas.Mensaje("ERROR ", salida2, "rojo");
                lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");
                gvProdFam.Visible = false;
                gvProductos.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvProdFam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdFam.PageIndex = e.NewPageIndex;
            GridProdFam();
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            GridProductos();
        }
    }
}