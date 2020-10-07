using AccesoEntidades.Devoluciones;
using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_Bodega : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        AE_GA_DEV_Tdevoldetalle ae_ga_dev_tdevoldetalle = new AE_GA_DEV_Tdevoldetalle();
        #endregion

        #region Funciones Propias
        protected void Page_Load(object sender, EventArgs e)
        {
            //Declaramos Variables que necesiten parametros por defecto dentro de ellas
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
            if (!IsPostBack)
            {
                VincularGrid();
            }
        }

        protected void gvBodega_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBodega.PageIndex = e.NewPageIndex;
            VincularGrid();
        }

        protected void gvBodega_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("deleteRecord"))
                {
                    string code = gvBodega.DataKeys[index].Value.ToString();
                    HfDeleteID.Value = code;
                    lblMensajeDelete.Text = "Esta seguro que desea eliminar el Registro: " + code + "  ? <br> * Ingrese el motivo de la eliminacion: <br> ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
                }
                if (e.CommandName.Equals("mailRecord"))
                {
                    string code = gvBodega.DataKeys[index].Value.ToString();
                    HfMailID.Value = code;
                    lblMailDelete.Text = "Llene la informacion del contenido y del asunto para poder enviar el correo. <br> ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#mailModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MailModalScript", sb.ToString(), false);
                }
                if (e.CommandName.Equals("editRecord"))
                {
                    string id = (gvBodega.Rows[index].FindControl("lbliddevolucion") as LinkButton).Text;
                    an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, id, "2", User.Identity.Name, "");
                    lblError.Text = an_alertas.Mensaje("ENVIADO...!", "Se envio a Ventas", "verde");
                    VincularGrid();
                }
                if (e.CommandName.Equals("printRecord"))
                {
                    string id = (gvBodega.Rows[index].FindControl("lbliddevolucion") as LinkButton).Text;
                    ReportParameter[] rptParametros = new ReportParameter[2];

                    Session["Empresa"] = Request.Cookies["basesiav"].Value;
                    Session["Directorio"] = "SIAV";

                    Session["NombreReporte"] = "DevolucionEntregaBodega";
                    rptParametros[0] = new ReportParameter("id", id);
                    rptParametros[1] = new ReportParameter("base", Request.Cookies["basesiav"].Value);

                    Session["Parameter"] = 1;
                    Session["ReportParameter"] = rptParametros;

                    // Cuando se ocupe UpdatePanel
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", "<script>window.open('/SIAV_v4/Reportes/Reporte247.aspx')</script>", false);
                    // Cuando no se ocupe UpdatePanel
                    //Response.Write("<script>window.open('/SIAV_v4/Reportes/Reporte247.aspx')</script>");
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

        protected void iddevolucion_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valor = btn.CommandArgument;
            //Llenar la devolucion
            gvEditar.DataSource = an_devolucion.DetalleDevolucion(Request.Cookies["basesiav"].Value, valor).DataSource;
            gvEditar.DataBind();
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#devolucionModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DevolucionModalScript", sb.ToString(), false);
        }

        protected void factura_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valor = btn.CommandArgument;
            //Llenar la factura
            lblarticulosfact.Text = an_devolucion.tablaFactura(Request.Cookies["basesiav"].Value, valor);
            //Abrir el modal
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#facturaModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "FacturaModalScript", sb.ToString(), false);
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlMotivos = (e.Row.FindControl("ddlMotivos") as DropDownList);
                ddlMotivos.DataSource = an_devolucion.LlenarMotivos();
                ddlMotivos.DataTextField = "descripcion";
                ddlMotivos.DataValueField = "idmotivo";
                ddlMotivos.DataBind();

                //Add Default Item in the DropDownList
                //ddlMotivos.Items.Insert(0, new ListItem("Por favor Seleccione"));

                //Select the Country of Customer in DropDownList
                string motivo = (e.Row.FindControl("lblMotivos") as Label).Text;
                ddlMotivos.Items.FindByValue(motivo).Selected = true;
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvEditar.Rows)
                {
                    ae_ga_dev_tdevoldetalle.iddetalle = Convert.ToInt32((row.FindControl("lbliddetalle") as Label).Text);
                    ae_ga_dev_tdevoldetalle.cantidadOriginal = Convert.ToInt32((row.FindControl("lblcantidadOriginal") as Label).Text);
                    ae_ga_dev_tdevoldetalle.cantidadReal = Convert.ToInt32((row.FindControl("txtcantidadReal") as TextBox).Text);
                    ae_ga_dev_tdevoldetalle.motivoReal = (row.FindControl("ddlMotivos") as DropDownList).SelectedValue;
                    ae_ga_dev_tdevoldetalle.observacion = (row.FindControl("txtObservacion") as TextBox).Text;

                    if (ae_ga_dev_tdevoldetalle.cantidadOriginal >= ae_ga_dev_tdevoldetalle.cantidadReal)
                    {
                        an_devolucion.actualizarDetalle(ae_ga_dev_tdevoldetalle);
                    }else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR...!", "La Cantidad Real no puede ser mayor que la Original.", "rojo");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR...!",  ex.Message , "rojo");
            }
            finally
            {
                //Ocultando el Modal POPUP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#devolucionModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text.Trim().Length > 0)
            {
                try
                {
                    lblError.Text = "";
                    an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, HfDeleteID.Value, "-1", User.Identity.Name, txtObservacion.Text);
                    lblError.Text = an_alertas.Mensaje("ELIMINADO...!", "Se elimino correctamente la devolucion, proceda a eliminar en la wica.", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
                }
                finally
                {
                    //Limpiamos la observacion
                    lblMensajeDelete.Text = "";
                    //Ocultando el Modal POPUP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR...!", "Por favor, ingresar el motivo de la eliminacion.", "rojo");
            }
        }

        protected void btnMail_Click(object sender, EventArgs e)
        {
            if (txtAsunto.Text.Trim().Length > 0 && txtContenidoMail.Text.Trim().Length > 0)
            {
                try
                {
                    lblError.Text = "";
                    //an_devolucion.ModificarEstado(Request.Cookies["basesiav"].Value, HfDeleteID.Value, "-1", User.Identity.Name, txtObservacion.Text);
                    if (HfDeleteID.Value.Length>0)
                    {
                        if (SendMail(HfDeleteID.Value, txtAsunto.Text.Trim(), txtContenidoMail.Text.Trim()))
                        {
                            lblError.Text = an_alertas.Mensaje("CORRECTO...!", "Se envio el mail correctamente.", "verde");
                        }
                        else
                        {
                            lblError.Text = an_alertas.Mensaje("ERROR...!", "No se puede enviar el Mail.", "rojo");
                        }
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("Error...!", "NO Se envio el mail. No tiene seleccionado un IdDevolucion Valido.", "rojo");
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
                }
                finally
                {
                    //Limpiamos la observacion
                    lblMensajeDelete.Text = "";
                    //Ocultando el Modal POPUP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#mailModal').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mailHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR...!", "Por favor, ingresar el asunto y el contenido de la devolucion.", "rojo");
            }
        }

        public Boolean SendMail(string id,string subject,string body)
        {
            try
            {
                //Configuración del Mensaje
                //string body = "";
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.outlook.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("info-noreplay@iav.com.ec", "Prueba", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = subject;// "Devolucion No Autorizada";

                //Sacamos el correo del cliente
                string correo = an_devolucion.getCorreoClienteDevolucion(Request.Cookies["basesiav"].Value,id);

                //body += "<br><h2>Preorden(es) " + vg_estado_at + "</h2><br>";
                //body += "<h3>Se ha " + vg_estado_at + " la(s) Preorden(es) con sus respectivos items: </h3><br><br>";
                //body += vg_productos;
                //body += "<br><br><br><br><a href='http://192.168.0.247/SIAV/Login.aspx'><h2>SIAV Ingresar Aquí</h2></a>";
                mail.Body = (body);
                mail.IsBodyHtml = true;

                if (correo.Length > 0)
                {
                    //Especificamos a quien enviaremos el Email
                    mail.To.Add(correo);
                    //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                }
                else
                {
                    //Especificamos a quien enviaremos el Email
                    mail.To.Add("greyes@iav.com.ec");
                    //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                }
                //Configuracion del SMTP
                SmtpServer.Port = 587;
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("info-noreplay@iav.com.ec", "IAVin2016@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Funciones Agregadas
        public void VincularGrid()
        {
            gvBodega.DataSource = an_devolucion.LlenarGrid(Request.Cookies["basesiav"].Value, "4").DataSource;
            gvBodega.DataBind();
        }
        #endregion
    }
}