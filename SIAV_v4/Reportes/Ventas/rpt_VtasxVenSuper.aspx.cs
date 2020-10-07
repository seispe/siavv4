using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Ventas
{
    public partial class rpt_VtasxVenSuper : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas;
        private string vg_supervisor = null;
        private string vg_usuario = null;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
                //TRAER EL CODIGO DE SUPERVISOR LOGEADO
                vg_usuario = HttpContext.Current.User.Identity.Name;
                vg_supervisor = an_ventas.GetPerSup(HttpContext.Current.User.Identity.Name, "", "", 6, "");
                if (!IsPostBack)
                {
                    VincularddlAños();
                    VincularddlMeses();
                    VincularddlSupervisor();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void ddlSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                //Llenar Informacion
                DataSet dsp = new DataSet();
                dsp = an_ventas.GetVenSup(ddlSupervisor.SelectedValue, "", "", 4,"");

                ddlVendedor.DataSource = dsp;
                ddlVendedor.DataTextField = "nombre";
                ddlVendedor.DataValueField = "codigo";
                ddlVendedor.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridVen();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvVen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVen.PageIndex = e.NewPageIndex;
            GridVen();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                ExportToExcel();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void VincularddlAños()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_ventas.GetVenSup("", "", "", 1,"");

            ddlAnio.DataSource = dsp;
            ddlAnio.DataTextField = "anio";
            ddlAnio.DataValueField = "anio";
            ddlAnio.DataBind();
        }

        public void VincularddlMeses()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_ventas.GetVenSup("", "", "", 2,"");

            ddlMes.DataSource = dsp;
            ddlMes.DataTextField = "nombre";
            ddlMes.DataValueField = "mes";
            ddlMes.DataBind();

            DataSet dsp2 = new DataSet();
            dsp2 = an_ventas.GetVenSup("", "", "", 2,"");

            ddlMesHasta.DataSource = dsp2;
            ddlMesHasta.DataTextField = "nombre";
            ddlMesHasta.DataValueField = "mes";
            ddlMesHasta.DataBind();
        }

        public void VincularddlSupervisor()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_ventas.GetVenSup(vg_supervisor, "", "", 3,"");

            ddlSupervisor.DataSource = dsp;
            ddlSupervisor.DataTextField = "nombre";
            ddlSupervisor.DataValueField = "codigo";
            ddlSupervisor.DataBind();
            ddlSupervisor.Items.Insert(0, new ListItem("Eliga un Supervisor..", "5"));
        }

        public void GridVen()
        {
            try
            {
                gvVen.DataSource = an_ventas.GetVenSup(ddlAnio.SelectedValue, ddlMes.SelectedValue, ddlVendedor.SelectedValue, 5, ddlMesHasta.SelectedValue);
                gvVen.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void ExportToExcel()
        {

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_ventas.GetVenSup(ddlAnio.SelectedValue, ddlMes.SelectedValue, ddlVendedor.SelectedValue, 5, ddlMesHasta.SelectedValue);
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptVtasSuper.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);
            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}