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
    public partial class frm_UsuarioEmpresa : System.Web.UI.Page
    {
        #region Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Autentificar an_autentificar = new AN_Autentificar();
        AE_GA_SEG_Tusuempresa ae_ga_seg_Tusuempresa = new AE_GA_SEG_Tusuempresa();
        #endregion

        #region Funciones
        public void LlenarGrid()
        {
            ddlEmpleado.DataSource = an_autentificar.getEmpleados();
            ddlEmpleado.DataTextField = "empleado";
            ddlEmpleado.DataValueField = "empleado";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("Seleccione Empleado", "-1"));
            cblEmpresa.DataSource = an_autentificar.getEmpresas();
            cblEmpresa.DataTextField = "empresa";
            cblEmpresa.DataValueField = "cod_emp";
            cblEmpresa.DataBind();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in cblEmpresa.Items)
            {
                if (item.Selected)
                {
                    ae_ga_seg_Tusuempresa.cod_emp = Convert.ToInt32(item.Value);
                    ae_ga_seg_Tusuempresa.cod_usu = ddlEmpleado.SelectedValue;
                    try
                    {
                        an_autentificar.InsertUsuarioEmpresa(ae_ga_seg_Tusuempresa);
                        lblError.Text = an_alertas.Mensaje("CORRECTO!", "Datos Actualizados", "verde");
                    }
                    catch (Exception)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR!", "Problemas de Datos", "rojo");
                    }
                }
                else
                {
                    ae_ga_seg_Tusuempresa.cod_emp = Convert.ToInt32(item.Value);
                    ae_ga_seg_Tusuempresa.cod_usu = ddlEmpleado.SelectedValue;
                    try
                    {
                        an_autentificar.DeleteUsuarioEmpresa(ae_ga_seg_Tusuempresa);
                        lblError.Text = an_alertas.Mensaje("CORRECTO!", "Datos Actualizados", "verde");
                    }
                    catch (Exception)
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR!", "Problemas al borrar", "rojo");
                    }
                }
            }
        }

        protected void ddlEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in cblEmpresa.Items)
            {
                item.Selected = false;
            }
            DataSet ds = an_autentificar.UsuarioEmpresa(ddlEmpleado.SelectedValue);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                foreach (ListItem item in cblEmpresa.Items)
                {
                    if (row[0].ToString() == item.Value.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }
}