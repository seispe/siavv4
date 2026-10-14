using AccesoNegocios.Logistica;
using AccesoNegocios.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SIAV_v4.Proyectos.Logistica
{
    public partial class frm_asignaChoferCamion : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Logistica an_logistica = new AN_Logistica();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridConductores();
            }
        }

        protected void gv_conductores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                lblError.Text = "";
                //Llenar Informacion
                DataSet dsp = new DataSet();
                dsp = an_logistica.GetConductores(2, "", 0);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //LLENAR EL HIDDEN CON EL CONDUCTOR
                    HiddenField hfidconductor = (HiddenField)e.Row.FindControl("hfidconductor");
                    //Encontrar el dropdownlist en la grilla
                    DropDownList ddlConductor = (e.Row.FindControl("ddlConductor") as DropDownList);
                    ddlConductor.DataSource = dsp;
                    ddlConductor.DataTextField = "nombre";
                    ddlConductor.DataValueField = "id";
                    ddlConductor.DataBind();
                    //Seleccionar el conductor por defecto si ya gestiono
                    if (hfidconductor.Value != "") ddlConductor.Items.FindByValue(hfidconductor.Value).Selected = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string placa = "";
                string idconductor = "";
                foreach (GridViewRow row in gv_conductores.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        idconductor = (row.Cells[0].FindControl("ddlConductor") as DropDownList).SelectedValue;
                        placa = (row.Cells[1].FindControl("lblplaca") as Label).Text.Trim();
                        an_logistica.UpConductores(3, placa, Convert.ToInt32(idconductor));
                        
                    }
                }
                GridConductores();
                lblError.Text = an_alertas.Mensaje("CORRECTO ", "ASIGNADO", "verde");
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridConductores()
        {
            try
            {
                lblError.Text = "";
                gv_conductores.DataSource = an_logistica.gvConductores(1, "", 0).DataSource;
                gv_conductores.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion
    }
}