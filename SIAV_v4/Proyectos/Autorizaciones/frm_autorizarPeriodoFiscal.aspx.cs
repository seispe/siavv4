using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Autorizaciones;
using AccesoEntidades.Autorizaciones;

namespace SIAV_v4.Proyectos.Autorizaciones
{
    public partial class frm_autorizarPeriodoFiscal : System.Web.UI.Page
    {
        AN_Autorizaciones an_Autorizaciones = new AN_Autorizaciones("GPCAO");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }

        }

        private void CargarDatos()
        {
            List<GP_AUTH_MOD> lista = an_Autorizaciones.getAutorizacionesPewndientes();
            GridView1.DataSource = lista;
            GridView1.DataBind();
        }

        protected void btnMostrarNombre_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(hiddenFieldId.Value);
            string user = HttpContext.Current.User.Identity.Name;
            int tiempo = Convert.ToInt32(authorizationTime.Text);
            int autorizado = an_Autorizaciones.updateAutorizacionesPendientes(user, id, tiempo);
            if (autorizado > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Permiso concedido');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al autorizar permiso');", true);
            }
            CargarDatos();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            /*int id = Convert.ToInt32(hiddenFieldId.Value);
            string user = HttpContext.Current.User.Identity.Name;
            int time = Convert.ToInt32(authorizationTime.Text);

            if (time < 15)
            {
                time = 15;
            }

            int autorizado = an_Autorizaciones.updateAutorizacionesPendientes(user, id, time);
            if (autorizado > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Permiso concedido');", true);
                authorizationTime.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al autorizar permiso');", true);
            }

            CargarDatos();*/
        }


        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarDatos();
        }
    }
}