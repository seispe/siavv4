using AccesoNegocios.Alertas;
using AccesoNegocios.Wmscal;
using AccesoNegocios.WMSiav;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMScal
{
    public partial class rpt_ConsxUsuVJ : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMScal an_wmscal = new AN_WMScal();
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularDdlCiudades();
            }
        }

        protected void gvCons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCons.PageIndex = e.NewPageIndex;
            GridCons();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridCons();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
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
        public void ExportToExcel()
        {
            lblError.Text = "";
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (ddlCiudad.SelectedValue == "0" && txtUsuario.Text.Trim() == "")
            {
                if (txtfdesde.Text.Trim() != "" && txtfhasta.Text.Trim() != "")
                {
                    string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                    GridView1.DataSource = an_wmscal.GetConsoxUsu(fechadesde, fechahasta, "", 1).DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                }
            }
            else if (ddlCiudad.SelectedValue != "0" && txtUsuario.Text.Trim() == "")
            {
                if (txtfdesde.Text.Trim() != "" && txtfhasta.Text.Trim() != "")
                {
                    string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                    GridView1.DataSource = an_wmscal.GetConsoxUsu(fechadesde, fechahasta, ddlCiudad.SelectedValue, 2).DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                }
            }
            else if (ddlCiudad.SelectedValue == "0" && txtUsuario.Text.Trim() != "")
            {
                if (txtfdesde.Text.Trim() != "" && txtfhasta.Text.Trim() != "")
                {
                    string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                    string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                    GridView1.DataSource = an_wmscal.GetConsoxUsu(fechadesde, fechahasta, txtUsuario.Text.Trim(), 3).DataSource;
                    GridView1.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", " Elimine fitro ciudad o usuario", "rojo");
            }

            if (lblError.Text == "")
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=rptConsolidados.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridView1.Rows[i].Cells[3].Attributes.Add("style", @"mso-number-format:\@");
                    
                }
                GridView1.RenderControl(hw);

                //style to format numbers to string
                //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                //Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public void VincularDdlCiudades()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.Gettiposciudades(Request.Cookies["basesiav"].Value, "1");

            ddlCiudad.DataSource = dsp;
            ddlCiudad.DataTextField = "ciudad";
            ddlCiudad.DataValueField = "ciudad";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("Eliga una Ciudad..", "0"));
        }

        public void GridCons()
        {
            try
            {
                if (ddlCiudad.SelectedValue == "0" && txtUsuario.Text.Trim() == "")
                {
                    if (txtfdesde.Text.Trim() != "" && txtfhasta.Text.Trim() != "")
                    {
                        string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                        string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                        gvCons.DataSource = an_wmscal.GetConsoxUsu(fechadesde, fechahasta, "", 1).DataSource;
                        gvCons.DataBind();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                    }
                }
                else if (ddlCiudad.SelectedValue != "0" && txtUsuario.Text.Trim() == "")
                {
                    if (txtfdesde.Text.Trim() != "" && txtfhasta.Text.Trim() != "")
                    {
                        string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                        string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                        gvCons.DataSource = an_wmscal.GetConsoxUsu(fechadesde, fechahasta, ddlCiudad.SelectedValue, 2).DataSource;
                        gvCons.DataBind();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                    }
                }
                else if (ddlCiudad.SelectedValue == "0" && txtUsuario.Text.Trim() != "")
                {
                    if (txtfdesde.Text.Trim() != "" && txtfhasta.Text.Trim() != "")
                    {
                        string fechadesde = Convert.ToDateTime(txtfdesde.Text.Trim()).ToString("yyyy-MM-dd");
                        string fechahasta = Convert.ToDateTime(txtfhasta.Text.Trim()).ToString("yyyy-MM-dd");
                        gvCons.DataSource = an_wmscal.GetConsoxUsu(fechadesde, fechahasta, txtUsuario.Text.Trim(), 3).DataSource;
                        gvCons.DataBind();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE LAS FECHAS", "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " Elimine fitro ciudad o usuario", "rojo");
                }
        }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion


    }
}