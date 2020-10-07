using AccesoEntidades.Comisiones;
using AccesoNegocios.Alertas;
using AccesoNegocios.Comisiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Comisiones
{
    public partial class frm_VendedoresComi : System.Web.UI.Page
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
            gvConfig.DataSource = an_com.GetConfigVendedor(ddlVendedores.SelectedValue).DataSource;
            gvConfig.DataBind();
        }
        #endregion

        #region Funciones Propias
        protected void Page_Load(object sender, EventArgs e)
        {
            an_com = new AN_Comisiones(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                btnNuevo.Visible = false;
                LlenarCombo();
            }            
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = "";
            //Abrir ModalPoPuP
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }

        protected void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (txtNewComision.Text.Length > 0 && txtNewCupo.Text.Length > 0 && txtNewNeto.Text.Length > 0 && ddlNewAño.SelectedValue != "0" && ddlNewMes.SelectedValue != "0" )
            {
                //Verificamos si existe 
                string resultado = an_com.getExisteRegistro(ddlVendedores.SelectedValue, ddlNewMes.SelectedValue, ddlNewAño.SelectedValue);
                if (resultado == "OK")
                {
                    //Ingresamos y actualizamos el grid
                    ae_ga_com_tpagada_calc.año = Convert.ToInt32(ddlNewAño.SelectedValue);
                    ae_ga_com_tpagada_calc.cupo = Convert.ToDecimal(txtNewCupo.Text.Trim());
                    ae_ga_com_tpagada_calc.idVendedor = ddlVendedores.SelectedValue;
                    ae_ga_com_tpagada_calc.mes = ddlNewMes.SelectedValue;
                    ae_ga_com_tpagada_calc.neto = Convert.ToDecimal(txtNewNeto.Text.Trim());
                    ae_ga_com_tpagada_calc.porceComi = Convert.ToDecimal(txtNewComision.Text.Trim());
                    ae_ga_com_tpagada_calc.porceAlcanzado = (ae_ga_com_tpagada_calc.neto / ae_ga_com_tpagada_calc.cupo == 0 ? 1 : ae_ga_com_tpagada_calc.cupo) * 100;
                    ae_ga_com_tpagada_calc.porceComisionar = (ae_ga_com_tpagada_calc.porceComi * ae_ga_com_tpagada_calc.porceAlcanzado) / 100;
                    resultado = an_com.putNuevoCalculo(ae_ga_com_tpagada_calc);
                    if (resultado == "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", "Se Ingreso Correctamente.", "verde");

                        txtNewComision.Text = "";
                        txtNewCupo.Text = "";
                        txtNewNeto.Text = "";

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#addModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

                        VincularGrid();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "No se inserto correctamente, revisar con sistemas.", "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "El Mes y Año que intenta ingresar ya se encuentran ingresados procesada a actualizar, por los datos que necesita.", "rojo");
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", "Todos los campos son obligatorios. POr favor llenar todos los campos.", "rojo");
            }
        }

        protected void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (txtEditComision.Text.Length > 0 && txtEditCupo.Text.Length > 0 && txtEditNeto.Text.Length > 0)
            {
                //Verificamos si existe 
                string resultado = an_com.getExisteRegistro(txtEditVendedor.Text, txtEditmes.Text, txtEditAño.Text);
                if (resultado != "OK")
                {
                    //Ingresamos y actualizamos el grid
                    ae_ga_com_tpagada_calc.idPago = Convert.ToInt32(hfCodigoEditar.Value);
                    ae_ga_com_tpagada_calc.año = Convert.ToInt32(txtEditAño.Text);
                    ae_ga_com_tpagada_calc.cupo = Convert.ToDecimal(txtEditCupo.Text.Trim());
                    ae_ga_com_tpagada_calc.idVendedor = txtEditVendedor.Text;
                    ae_ga_com_tpagada_calc.mes = txtEditmes.Text.Trim();
                    ae_ga_com_tpagada_calc.neto = Convert.ToDecimal(txtEditNeto.Text.Trim());
                    ae_ga_com_tpagada_calc.porceComi = Convert.ToDecimal(txtEditComision.Text.Trim());
                    ae_ga_com_tpagada_calc.porceAlcanzado = (ae_ga_com_tpagada_calc.neto / ae_ga_com_tpagada_calc.cupo == 0 ? 1 : ae_ga_com_tpagada_calc.cupo) * 100;
                    ae_ga_com_tpagada_calc.porceComisionar = (ae_ga_com_tpagada_calc.porceComi * ae_ga_com_tpagada_calc.porceAlcanzado) / 100;
                    resultado = an_com.editCalculo(ae_ga_com_tpagada_calc);
                    if (resultado == "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", "Se Ingreso Correctamente.", "verde");

                        txtEditComision.Text = "";
                        txtEditCupo.Text = "";
                        txtEditNeto.Text = "";

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EdittModalScript", sb.ToString(), false);

                        VincularGrid();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", "No se inserto correctamente, revisar con sistemas.", "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "El Mes y Año que intenta ingresar ya se encuentran ingresados procesada a actualizar, por los datos que necesita.", "rojo");
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", "Todos los campos son obligatorios. POr favor llenar todos los campos.", "rojo");
            }
        }

        protected void gvConfig_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    //Pasar Variables
                    hfCodigoEditar.Value = (gvConfig.Rows[index].FindControl("lblidPago") as Label).Text;
                    txtEditmes.Text = (gvConfig.Rows[index].FindControl("lblmes") as Label).Text;
                    txtEditAño.Text = (gvConfig.Rows[index].FindControl("lblaño") as Label).Text;
                    txtEditCupo.Text = (gvConfig.Rows[index].FindControl("lblcupo") as Label).Text;
                    txtEditNeto.Text = (gvConfig.Rows[index].FindControl("lblneto") as Label).Text;
                    txtEditComision.Text = (gvConfig.Rows[index].FindControl("lblporceComi") as Label).Text;
                    txtEditVendedor.Text = (gvConfig.Rows[index].FindControl("lblidVendedor") as Label).Text;

                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception)
            {
                /*  Al momento de Activar el Ordenamiento por columna, los nombres de las columnas
                    se alteran y por enden en vez de ingresar un Int ingreso un String y nos genera un error
                    Pero no hay problema lo enviamos al Catch y solucionado.... y cuando se necesite ejecutar los otros
                    eventos instantaneamente ingresara donde debe */
            }
        }
        #endregion

        protected void ddlVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            VincularGrid();
            lblError.Text = "";
            btnNuevo.Visible = true;
            gvConfig.Visible = true;
        }
    }
}