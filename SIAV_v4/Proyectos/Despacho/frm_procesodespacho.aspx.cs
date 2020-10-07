using System;
using AccesoEntidades.Despacho;
using AccesoNegocios.Despacho;
using AccesoNegocios.Alertas;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

using AccesoNegocios.Seguridad;
using AccesoEntidades.Seguridad;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace SIAV_v4.Proyectos.Despacho
{
    public partial class frm_procesodespacho : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Despacho an_despacho = new AN_Despacho();
        AN_Autentificar an_autentificar = new AN_Autentificar();
        AE_GA_PKG_Tdetalle ad_tb_GA_PKG_Tproceso = new AE_GA_PKG_Tdetalle();
        AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos = new AE_GA_SEG_Tpermisos();

        private static int iddetalle = 0, idproceso = 0, idmaestro = 0;
        private static string documento = "";
        private static DateTime? fechaInigestion;
        #endregion

        #region Funciones
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                an_despacho.datosJson(Request.Cookies["basesiav"].Value);
                GridCobranzas();
                GridPedido();
                GridFacConta();
                GridPacking();
                GridEmpaqueBod();
                GridDespachoBod();
                GridLogistica();
                GridCliente();
            }
        }

        protected void Permisos(string permisos)
        {
            try
            {
                switch (permisos)
                {
                    case "BTNAUTOMATICOS":
                        //Llenamos Permiso BTNAUTOMATICOS
                        ae_ga_seg_tpermisos.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_seg_tpermisos.empresa = Request.Cookies["basesiav"].Value;
                        ae_ga_seg_tpermisos.proyecto = "DESPACHO";
                        ae_ga_seg_tpermisos.ventana = "frm_procesodespacho";
                        ae_ga_seg_tpermisos.permiso = "BTNAUTOMATICOS";                        
                        Response.Write(an_despacho.getPermisos(ae_ga_seg_tpermisos));
                        break;
                    case "GPACKING":
                        //Llenamos Permiso BTNAUTOMATICOS
                        ae_ga_seg_tpermisos.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_seg_tpermisos.empresa = Request.Cookies["basesiav"].Value;
                        ae_ga_seg_tpermisos.proyecto = "DESPACHO";
                        ae_ga_seg_tpermisos.ventana = "frm_procesodespacho";
                        ae_ga_seg_tpermisos.permiso = "GPACKING";
                        Response.Write(an_despacho.getPermisos(ae_ga_seg_tpermisos));
                        break;
                    case "GBODEGA":
                        //Llenamos Permiso BTNAUTOMATICOS
                        ae_ga_seg_tpermisos.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_seg_tpermisos.empresa = Request.Cookies["basesiav"].Value;
                        ae_ga_seg_tpermisos.proyecto = "DESPACHO";
                        ae_ga_seg_tpermisos.ventana = "frm_procesodespacho";
                        ae_ga_seg_tpermisos.permiso = "GBODEGA";
                        Response.Write(an_despacho.getPermisos(ae_ga_seg_tpermisos));
                        break;
                    case "GLOGISTICA":
                        //Llenamos Permiso BTNAUTOMATICOS
                        ae_ga_seg_tpermisos.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_seg_tpermisos.empresa = Request.Cookies["basesiav"].Value;
                        ae_ga_seg_tpermisos.proyecto = "DESPACHO";
                        ae_ga_seg_tpermisos.ventana = "frm_procesodespacho";
                        ae_ga_seg_tpermisos.permiso = "GLOGISTICA";
                        Response.Write(an_despacho.getPermisos(ae_ga_seg_tpermisos));
                        break;
                    case "GCLIENTE":
                        //Llenamos Permiso BTNAUTOMATICOS
                        ae_ga_seg_tpermisos.usuario = HttpContext.Current.User.Identity.Name;
                        ae_ga_seg_tpermisos.empresa = Request.Cookies["basesiav"].Value;
                        ae_ga_seg_tpermisos.proyecto = "DESPACHO";
                        ae_ga_seg_tpermisos.ventana = "frm_procesodespacho";
                        ae_ga_seg_tpermisos.permiso = "GCLIENTE";
                        Response.Write(an_despacho.getPermisos(ae_ga_seg_tpermisos));
                        break;
                }
            }
            catch (Exception)
            {
                //Response.Redirect("ERROR DE PERMISOS.");
            }
        }

        public void GridCobranzas()
        {
            try
            {
                gvCobranza.DataSource = an_despacho.getfacturasEstado("1").DataSource;
                gvCobranza.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void GridPedido()
        {
            try
            {
                gvPedido.DataSource = an_despacho.getfacturasEstado("2").DataSource;
                gvPedido.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GridFacConta()
        {
            try
            {
                gvFacConta.DataSource = an_despacho.getfacturasEstado("3").DataSource;
                gvFacConta.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GridPacking()
        {
            try
            {
                gvPacking.DataSource = an_despacho.getfacturasEstado("4").DataSource;
                gvPacking.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GridEmpaqueBod()
        {
            try
            {
                gvEmpaqueBod.DataSource = an_despacho.getfacturasEstado("5").DataSource;
                gvEmpaqueBod.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GridDespachoBod()
        {
            try
            {
                gvDespachoBod.DataSource = an_despacho.getfacturasEstado("6").DataSource;
                gvDespachoBod.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GridLogistica()
        {
            try
            {
                gvLogistica.DataSource = an_despacho.getfacturasEstado("7").DataSource;
                gvLogistica.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GridCliente()
        {
            try
            {
                gvCliente.DataSource = an_despacho.getfacturasEstado("8").DataSource;
                gvCliente.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Eventos


        protected void gvLogistica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                if (e.CommandName.Equals("imprimeNE"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    idproceso = Convert.ToInt32((gvLogistica.Rows[index].FindControl("lblidproceso") as Label).Text);
                    //fechaInigestion = Convert.ToDateTime((gvLogistica.Rows[index].FindControl("lblfechaFingestion") as Label).Text);
                    ad_tb_GA_PKG_Tproceso.iddetalle = Convert.ToInt32((gvLogistica.Rows[index].FindControl("lblidetalle") as Label).Text);
                    ad_tb_GA_PKG_Tproceso.idproceso = idproceso + 1;
                    ad_tb_GA_PKG_Tproceso.idmaestro = Convert.ToInt32((gvLogistica.Rows[index].FindControl("lblidmaestro") as Label).Text);
                    ad_tb_GA_PKG_Tproceso.fechaInigestion = DateTime.Now;
                    ad_tb_GA_PKG_Tproceso.fechaFingestion = Convert.ToDateTime("1999/01/01");//DateTime.Now;
                    ad_tb_GA_PKG_Tproceso.documento = (gvLogistica.Rows[index].FindControl("lbldocumento") as Label).Text;
                    ad_tb_GA_PKG_Tproceso.usuario = HttpContext.Current.User.Identity.Name;
                    ad_tb_GA_PKG_Tproceso.activo = 1;
                    //ad_tb_GA_PKG_Tproceso.observacion = txtObservacion.Text.Trim();
                    string estado = an_despacho.ValidarEstado((gvLogistica.Rows[index].FindControl("lbldocumento") as Label).Text, "3");
                    if (Convert.ToInt32(estado) == 7) an_despacho.ActinsaGestion(ad_tb_GA_PKG_Tproceso);
                    ReportParameter[] rptParametros = new ReportParameter[1];
                    Session["Directorio"] = "RECTIMA";
                    Session["NombreReporte"] = "NotaEntregaRectima";
                    rptParametros[0] = new ReportParameter("FACT", (gvLogistica.Rows[index].FindControl("lbldocumento") as Label).Text);
                    Session["ReportParameter"] = rptParametros;
                    Session["Parameter"] = 1;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/SIAV_v4/Reportes/Reporte247.aspx');", true);
                    lblError.Text = an_alertas.Mensaje("CORRECTO", " GENERADO", "verde");
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //al momento de activar el ordenamiento por columna, los nombres de las columnas
                //    se alteran y por enden en vez de ingresar un int ingreso un string y nos genera un error
                //    pero no hay problema lo enviamos al catch y solucionado....y cuando se necesite ejecutar los otros
                //    eventos instantaneamente ingresara donde debe
            }
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                if (e.CommandName.Equals("obserCliente"))
                {
                int index = Convert.ToInt32(e.CommandArgument);
                iddetalle = Convert.ToInt32((gvCliente.Rows[index].FindControl("lblidetalle") as Label).Text);
                fechaInigestion = Convert.ToDateTime((gvCliente.Rows[index].FindControl("lblfechaFingestion") as Label).Text);
                string valida = an_despacho.ValidarEstado((gvCliente.Rows[index].FindControl("lbldocumento") as Label).Text, "4");
                    if (Convert.ToInt32(valida) != 0)
                    {
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(@"<script type='text/javascript'>");
                            sb.Append("$('#observModal').modal('show');");
                            sb.Append(@"</script>");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "observModalScript", sb.ToString(), false);
                    }
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

        protected void gvPacking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                if (e.CommandName.Equals("imprimePacking"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    idproceso = Convert.ToInt32((gvPacking.Rows[index].FindControl("lblidproceso") as Label).Text);
                    //fechaInigestion = Convert.ToDateTime((gvPacking.Rows[index].FindControl("lblfechaFingestion") as Label).Text);
                    ad_tb_GA_PKG_Tproceso.iddetalle = Convert.ToInt32((gvPacking.Rows[index].FindControl("lbliddetalle") as Label).Text);
                    ad_tb_GA_PKG_Tproceso.idproceso = idproceso + 1;
                    ad_tb_GA_PKG_Tproceso.idmaestro = Convert.ToInt32((gvPacking.Rows[index].FindControl("lblidmaestro") as Label).Text);
                    ad_tb_GA_PKG_Tproceso.fechaInigestion = DateTime.Now;
                    ad_tb_GA_PKG_Tproceso.fechaFingestion = Convert.ToDateTime("1999/01/01");
                    ad_tb_GA_PKG_Tproceso.documento = (gvPacking.Rows[index].FindControl("lbldocumento") as Label).Text;
                    ad_tb_GA_PKG_Tproceso.usuario = HttpContext.Current.User.Identity.Name;
                    ad_tb_GA_PKG_Tproceso.activo = 1;
                    //ad_tb_GA_PKG_Tproceso.observacion = txtObservacion.Text.Trim();
                    string estado = an_despacho.ValidarEstado((gvPacking.Rows[index].FindControl("lbldocumento") as Label).Text, "3");
                    if (Convert.ToInt32(estado) == 4) an_despacho.ActinsaGestion(ad_tb_GA_PKG_Tproceso);
                    ReportParameter[] rptParametros = new ReportParameter[1];
                    Session["Directorio"] = "RECTIMA";
                    Session["NombreReporte"] = "PackingListRectima";
                    rptParametros[0] = new ReportParameter("FACT", (gvPacking.Rows[index].FindControl("lbldocumento") as Label).Text);
                    Session["ReportParameter"] = rptParametros;
                    Session["Parameter"] = 1;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/SIAV_v4/Reportes/Reporte247.aspx');", true);
                    lblError.Text = an_alertas.Mensaje("CORRECTO", " GENERADO", "verde");
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //al momento de activar el ordenamiento por columna, los nombres de las columnas
                //    se alteran y por enden en vez de ingresar un int ingreso un string y nos genera un error
                //    pero no hay problema lo enviamos al catch y solucionado....y cuando se necesite ejecutar los otros
                //    eventos instantaneamente ingresara donde debe
            }
        }
        
        protected void gvCobranza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCobranza.PageIndex = e.NewPageIndex;
            GridCobranzas();
        }

        protected void gvPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPedido.PageIndex = e.NewPageIndex;
            GridPedido();
        }

        protected void gvPacking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacking.PageIndex = e.NewPageIndex;
            GridPacking();
        }

        protected void btnrefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/SIAV_v4/Proyectos/Despacho/frm_procesodespacho.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void gvEmpaqueBod_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpaqueBod.PageIndex = e.NewPageIndex;
            GridEmpaqueBod();
        }

        protected void gvDespachoBod_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDespachoBod.PageIndex = e.NewPageIndex;
            GridDespachoBod();
        }

        protected void gvLogistica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLogistica.PageIndex = e.NewPageIndex;
            GridLogistica();
        }

        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCliente.PageIndex = e.NewPageIndex;
            GridCliente();
        }

        protected void gvFacConta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFacConta.PageIndex = e.NewPageIndex;
            GridFacConta();
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                ad_tb_GA_PKG_Tproceso.iddetalle = iddetalle;
                ad_tb_GA_PKG_Tproceso.fechaFingestion = DateTime.Now;
                ad_tb_GA_PKG_Tproceso.usuario = HttpContext.Current.User.Identity.Name;
                ad_tb_GA_PKG_Tproceso.observacion = txtObservacion.Text.Trim();
                an_despacho.ActGCli(ad_tb_GA_PKG_Tproceso);
                lblError.Text = an_alertas.Mensaje("CORRECTO", " PROCESADO", "verde");
                //GridPacking();
                //GridBodega();
                //GridLogistica();
                //GridCliente();
            }
            catch (Exception ex)
            {

                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
            finally
            {
                //Ocultando el Modal POPUP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#observModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
            }

        }

        //protected void btnbuscarpedido_Click(object sender, EventArgs e)
        //{
        //    gvConsultaPedido.DataSource = an_despacho.getPedidosEstado(txt_pedido.Text.Trim(), "").DataSource;
        //    gvConsultaPedido.DataBind();
        //}
        #endregion
    }

}