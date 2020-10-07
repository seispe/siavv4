using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Cobranzas
{
    public partial class frm_ingDocClientes : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Cobranzas an_cobranzas = null;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_cobranzas = new AN_Cobranzas(Request.Cookies["basesiav"].Value);
        }

        protected void BuscarCliente(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtRUC.Text != "")
                {
                    int filasCliente = 0;
                    gvCliente.DataSource = an_cobranzas.GetListadoDoc(0, txtRUC.Text.Trim(), "", 2).DataSource;
                    gvCliente.DataBind();
                    filasCliente = Convert.ToInt32(gvCliente.Rows.Count.ToString());
                    if (filasCliente == 1)
                    {
                        foreach (GridViewRow row in gvCliente.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                GridListadoCliente(Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim()));
                                GridEstadoCierre(Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim()));
                            }
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN RUC O CLIENTE", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardarPN_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string ruc = "", cliente = "", vendedor = "", usuario = "", observacion = "";
                int idcliente = 0, documento = 0, filasCliente = 0;
                //SACAR LOS DATOS MAESTROS SEGUN EL TIPO DE BUSQUEDA
                filasCliente = Convert.ToInt32(gvCliente.Rows.Count.ToString());
                if (filasCliente == 1)
                {
                    foreach (GridViewRow row in gvCliente.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            idcliente = Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim());
                            ruc = (row.Cells[2].FindControl("lblruc") as Label).Text.Trim();
                            cliente = (row.Cells[3].FindControl("lblcliente") as Label).Text.Trim();
                            vendedor = (row.Cells[4].FindControl("lblcod_ven") as Label).Text.Trim();
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "SELECCIONE UN CLIENTE", "rojo");
                    return;
                }
                if (ruc.Length == 10 || ruc.Length == 13)
                {
                    foreach (GridViewRow row in gvPN.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[3].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                usuario = HttpContext.Current.User.Identity.Name;
                                documento = Convert.ToInt32((row.Cells[0].FindControl("lblid") as Label).Text.Trim());
                                observacion = (row.Cells[2].FindControl("txtObservacionPN") as TextBox).Text.Trim();
                                an_cobranzas.insDocumentos(idcliente, ruc, cliente, vendedor, documento, usuario, observacion, 3);
                            }
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN RUC VÁLIDO", "rojo");
                    return;
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardarPJ_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string ruc = "", cliente = "", vendedor = "", usuario = "", observacion = "";
                int idcliente = 0, documento = 0, filasCliente = 0;
                //SACAR LOS DATOS MAESTROS SEGUN EL TIPO DE BUSQUEDA
                filasCliente = Convert.ToInt32(gvCliente.Rows.Count.ToString());
                if (filasCliente == 1)
                {
                    foreach (GridViewRow row in gvCliente.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            idcliente = Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim());
                            ruc = (row.Cells[2].FindControl("lblruc") as Label).Text.Trim();
                            cliente = (row.Cells[3].FindControl("lblcliente") as Label).Text.Trim();
                            vendedor = (row.Cells[4].FindControl("lblcod_ven") as Label).Text.Trim();
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "SELECCIONE UN CLIENTE", "rojo");
                    return;
                }
                if (ruc.Length == 10 || ruc.Length == 13)
                {
                    foreach (GridViewRow row in gvPJ.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[3].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                usuario = HttpContext.Current.User.Identity.Name;
                                documento = Convert.ToInt32((row.Cells[0].FindControl("lblid") as Label).Text.Trim());
                                observacion = (row.Cells[2].FindControl("txtObservacionPJ") as TextBox).Text.Trim();
                                an_cobranzas.insDocumentos(idcliente, ruc, cliente, vendedor, documento, usuario, observacion, 3);
                            }
                        }
                    }
                    txtRucnuevo.Text = ""; txtCliente.Text = ""; txtVendedor.Text = "";
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN RUC VÁLIDO", "rojo");
                    return;
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardarAC_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string ruc = "", cliente = "", vendedor = "", usuario = "", observacion = "";
                int idcliente = 0, documento = 0, filasCliente = 0;
                //SACAR LOS DATOS MAESTROS SEGUN EL TIPO DE BUSQUEDA
                filasCliente = Convert.ToInt32(gvCliente.Rows.Count.ToString());
                if (filasCliente == 1)
                {
                    foreach (GridViewRow row in gvCliente.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            idcliente = Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim());
                            ruc = (row.Cells[2].FindControl("lblruc") as Label).Text.Trim();
                            cliente = (row.Cells[3].FindControl("lblcliente") as Label).Text.Trim();
                            vendedor = (row.Cells[4].FindControl("lblcod_ven") as Label).Text.Trim();
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "SELECCIONE UN CLIENTE", "rojo");
                    return;
                }
                if (ruc.Length == 10 || ruc.Length == 13)
                {
                    foreach (GridViewRow row in gvAnalisis.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[3].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                usuario = HttpContext.Current.User.Identity.Name;
                                documento = Convert.ToInt32((row.Cells[0].FindControl("lblid") as Label).Text.Trim());
                                observacion = (row.Cells[2].FindControl("txtObservacionAC") as TextBox).Text.Trim();
                                an_cobranzas.insDocumentos(idcliente, ruc, cliente, vendedor, documento, usuario, observacion, 3);
                            }
                        }
                    }
                    txtRucnuevo.Text = ""; txtCliente.Text = ""; txtVendedor.Text = "";
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN RUC VÁLIDO", "rojo");
                    return;
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("Editar"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    txtRucActualiza.Text = (gvCliente.Rows[index].FindControl("lblruc") as Label).Text;
                    hfRucActualiza.Value = (gvCliente.Rows[index].FindControl("lblid") as Label).Text;
                    txtClienteActualiza.Text = (gvCliente.Rows[index].FindControl("lblcliente") as Label).Text;
                    txtVendedorActualiza.Text = (gvCliente.Rows[index].FindControl("lblcod_ven") as Label).Text;
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#detCliente').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardarR_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = "", ruc = "", vendedor = "";
                cliente = txtClienteActualiza.Text.Trim();
                ruc = txtRucActualiza.Text.Trim();
                vendedor = txtVendedorActualiza.Text.Trim();
                //an_cobranzas.insDocumentos(Convert.ToInt32(hfRucActualiza.Value), ruc, cliente, vendedor, 0, "", "", 5);
                string resultado = an_cobranzas.insClientesDoc(Convert.ToInt32(hfRucActualiza.Value), ruc, cliente, vendedor, DateTime.Now, DateTime.Now,"", "", 5);
                //Cerrar ModalPoPuP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#detCliente').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                if (resultado != "OK")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "rojo");
                }
                else
                {
                    gvCliente.DataSource = an_cobranzas.GetListadoDoc(0, ruc, "", 2).DataSource;
                    gvCliente.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtRucnuevo.Text.Length == 10 || txtRucnuevo.Text.Length == 13)
                {
                    string resultado = an_cobranzas.insClientesDoc(0, txtRucnuevo.Text.Trim(), txtCliente.Text.Trim(), txtVendedor.Text.Trim(), Convert.ToDateTime(txtfSolicitud.Text), Convert.ToDateTime(txtfRecibo.Text), HttpContext.Current.User.Identity.Name, txtObservacionCliente.Text.Trim(), 6);
                    if (resultado != "OK")
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "rojo");
                    }
                    else
                    {
                        Response.Redirect(Request.RawUrl);
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN RUC VÁLIDO", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnAceptarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                int filasCliente = 0;
                //SACAR LOS DATOS MAESTROS SEGUN EL TIPO DE BUSQUEDA
                filasCliente = Convert.ToInt32(gvCliente.Rows.Count.ToString());
                if (filasCliente == 1)
                {
                    foreach (GridViewRow row in gvCliente.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            an_cobranzas.insDocumentos(Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim()), "", "ACEPTADA", "", 0, HttpContext.Current.User.Identity.Name, txtObservacionCierre.Text.Trim(), 7);
                        }
                    }
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "SELECCIONE UN CLIENTE", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnRechazarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                int filasCliente = 0;
                filasCliente = Convert.ToInt32(gvCliente.Rows.Count.ToString());
                if (filasCliente == 1)
                {
                    foreach (GridViewRow row in gvCliente.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            an_cobranzas.insDocumentos(Convert.ToInt32((row.Cells[1].FindControl("lblid") as Label).Text.Trim()), "", "RECHAZADA", "", 0, HttpContext.Current.User.Identity.Name, txtObservacionCierre.Text.Trim(), 7);
                        }
                    }
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "SELECCIONE UN CLIENTE", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridEstadoCierre(int idsolicitud)
        {
            gvEstadoCierre.DataSource = an_cobranzas.GetListadoDoc(idsolicitud, "", "", 8).DataSource;
            gvEstadoCierre.DataBind();
        }

        public void GridListadoCliente(int idsolicitud)
        {
            gvPN.DataSource = an_cobranzas.GetListadoDoc(idsolicitud, "", "PERSONA NATURAL", 4).DataSource;
            gvPN.DataBind();
            gvPJ.DataSource = an_cobranzas.GetListadoDoc(idsolicitud, "", "PERSONA JURIDICA", 4).DataSource;
            gvPJ.DataBind();
            gvAnalisis.DataSource = an_cobranzas.GetListadoDoc(idsolicitud, "", "ANALISIS DEL CREDITO", 4).DataSource;
            gvAnalisis.DataBind();
        }
        #endregion
    }
}