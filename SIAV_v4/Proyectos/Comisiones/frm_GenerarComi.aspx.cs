using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoEntidades.Comisiones;
using AccesoNegocios.Alertas;
using AccesoNegocios.Comisiones;

namespace SIAV_v4.Proyectos.Comisiones
{
    public partial class frm_GenerarComi : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Comisiones an_com;
        AN_Alertas an_alertas = new AN_Alertas();
        AE_GA_COM_Tpagada_calc ae_ga_com_tpagada_calc = new AE_GA_COM_Tpagada_calc();
        #endregion

        #region Funciones
        public void LlenarCombo()
        {
            ddlVendedores.DataSource = an_com.getVendedores();
            ddlVendedores.DataTextField = "vendedor";
            ddlVendedores.DataValueField = "id";
            ddlVendedores.DataBind();
            ddlVendedores.Items.Insert(0, new ListItem("Seleccione Vendedor", "-1"));
        }

        public void VincularGrid()
        {
            //Comisiones
            gvComisiones.DataSource = an_com.GetComision(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue, "COMISION").DataSource;
            gvComisiones.DataBind();
            //Efectividad
            gvEfectividad.DataSource = an_com.GetComision(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue, "EFECTIVIDAD").DataSource;
            gvEfectividad.DataBind();
            //Devoluciones
            gvDevoluciones.DataSource = an_com.GetComision(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue, "DEVOLUCIONES").DataSource;
            gvDevoluciones.DataBind();
            //Morosidad
            gvMorosidad.DataSource = an_com.GetComision(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue, "MOROSIDAD").DataSource;
            gvMorosidad.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            an_com = new AN_Comisiones(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                LlenarCombo();
            }
            lblError.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            //Validar que los combobox esten seleccionados
            if (ddlVendedores.SelectedValue != "0" && ddlNewAño.SelectedValue != "0" && ddlNewMes.SelectedValue != "0")
            {
                //Validar que no exista la comision caso contrario notificar que ya existe y solo mostrar
                string resultado = an_com.getExisteComision(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue);
                if (resultado == "OK")
                {
                    //Generar la comision y mostrar
                    resultado = an_com.setComision(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue);
                    if (resultado == "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO! ", "Se genero correctamente.", "verde");
                        VincularGrid();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR! ", resultado, "rojo");
                    }
                }
                else
                {
                    //Cargar la comision porque ya existe
                    lblError.Text = an_alertas.Mensaje("ERROR! ", "La comision que desea generar ya existe, y se procedera solo a mostrar.", "rojo");
                    VincularGrid();
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR! ", "Debe seleccionar todos los combo antes de generar.", "rojo");
            }
        }

        protected void gvComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComisiones.PageIndex = e.NewPageIndex;
            VincularGrid();
        }

    }
}