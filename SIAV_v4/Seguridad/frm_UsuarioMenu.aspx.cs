using AccesoEntidades.Seguridad;
using AccesoNegocios.Alertas;
using AccesoNegocios.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Seguridad
{
    public partial class frm_UsuarioMenu : System.Web.UI.Page
    {
        #region Globales
        AN_Autentificar an_autentificar = new AN_Autentificar();
        AE_GA_SEG_Tusuventana ae_ga_seg_Tusuventana = new AE_GA_SEG_Tusuventana();
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Menu an_menu = new AN_Menu();
        #endregion

        #region Funciones
        public void LlenarGrid()
        {
            ddlEmpleado.DataSource = an_autentificar.getEmpleados();
            ddlEmpleado.DataTextField = "empleado";
            ddlEmpleado.DataValueField = "empleado";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("Seleccione Empleado", "-1"));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                an_autentificar.ListUsuarioAD();
            }
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblNivel1.DataSource = an_autentificar.nivel1(ddlEmpresa.SelectedValue);
            rblNivel1.DataTextField = "descripcion";
            rblNivel1.DataValueField = "id_menu_opcion";
            rblNivel1.DataBind();
            rblModulo.Items.Clear();
            cblVentana.Items.Clear();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Temgo Maestro
            //Empleado  gabriel.reyes
            //Empresa   1   grupoalvarado
            //Sistema   2   inventario
            //Modulo    3   inventarioAdd

            //Tengo Detalle
            //Ventanas  panel de acuerdo al modulo
            foreach (ListItem item in cblVentana.Items)
            {
                if (item.Selected)
                {
                    ae_ga_seg_Tusuventana.cod_emp = Convert.ToInt32(ddlEmpresa.SelectedValue);
                    ae_ga_seg_Tusuventana.cod_usu = ddlEmpleado.SelectedValue;
                    ae_ga_seg_Tusuventana.cod_rol = Convert.ToInt32(rblNivel1.SelectedValue);
                    ae_ga_seg_Tusuventana.cod_mod = Convert.ToInt32(rblModulo.SelectedValue);
                    ae_ga_seg_Tusuventana.cod_ven = Convert.ToInt32(item.Value);
                    try
                    {
                        an_autentificar.InsertUsuarioVentana(ae_ga_seg_Tusuventana);
                        lblError.Text = an_alertas.Mensaje("CORRECTO!", "Datos Actualizados", "verde");
                    }
                    catch (Exception)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR!", "Problemas de Datos", "rojo");
                    }
                }
                else
                {
                    ae_ga_seg_Tusuventana.cod_emp = Convert.ToInt32(ddlEmpresa.SelectedValue);
                    ae_ga_seg_Tusuventana.cod_usu = ddlEmpleado.SelectedValue;
                    ae_ga_seg_Tusuventana.cod_rol = Convert.ToInt32(rblNivel1.SelectedValue);
                    ae_ga_seg_Tusuventana.cod_mod = Convert.ToInt32(rblModulo.SelectedValue);
                    ae_ga_seg_Tusuventana.cod_ven = Convert.ToInt32(item.Value);
                    try
                    {
                        an_autentificar.DeleteUsuarioVentana(ae_ga_seg_Tusuventana);
                        lblError.Text = an_alertas.Mensaje("CORRECTO!", "Datos Actualizados", "verde");
                    }
                    catch (Exception)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR!", "Problemas al borrar", "rojo");
                    }
                }
            }

        }

        protected void rblNivel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblModulo.DataSource = an_autentificar.nivel2(rblNivel1.SelectedValue, ddlEmpresa.SelectedValue);
            rblModulo.DataTextField = "descripcion";
            rblModulo.DataValueField = "id_menu_opcion";
            rblModulo.DataBind();
            cblVentana.Items.Clear();
        }

        protected void rblModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblVentana.DataSource = an_autentificar.nivel3(rblModulo.SelectedValue, ddlEmpresa.SelectedValue);
            cblVentana.DataTextField = "descripcion";
            cblVentana.DataValueField = "id_menu_opcion";
            cblVentana.DataBind();
            //Poner las Ventanas que esten seleccionadas
            foreach (ListItem item in cblVentana.Items)
            {
                item.Selected = false;
            }
            DataSet ds = an_autentificar.GetUsuarioVentana(ddlEmpleado.SelectedValue, ddlEmpresa.SelectedValue, rblModulo.SelectedValue);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                foreach (ListItem item in cblVentana.Items)
                {
                    if (row[0].ToString() == item.Value.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void ddlEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmpresa.DataSource = an_autentificar.getEmpresa(ddlEmpleado.SelectedValue);
            ddlEmpresa.DataTextField = "empresa";
            ddlEmpresa.DataValueField = "cod_emp";
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0, new ListItem("Seleccione Empresa", "-1"));
            rblNivel1.Items.Clear();
            rblModulo.Items.Clear();
            cblVentana.Items.Clear();
        }
    }
}