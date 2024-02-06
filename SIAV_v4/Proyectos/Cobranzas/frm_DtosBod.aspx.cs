using AccesoNegocios.Alertas;
using System;
using AccesoNegocios.GP;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SIAV_v4.Proyectos.Cobranzas
{
    public partial class frm_DtosBod : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Compras an_compras = null;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_compras = new AN_Compras("GPIAV");
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                DataSet gpi = new DataSet();
                DataTable dti = new DataTable();
                gpi = an_compras.GetDetalleFacturaDtos(1, txtFactura.Text.Trim());
                dti = gpi.Tables[0];
                DataRow dt1 = dti.Rows[0];
                lblCliente.Text = dt1["cliente"].ToString();
                lblFecha.Text = dt1["fecha"].ToString();
                lblPedido.Text = dt1["pedido"].ToString();
                lblFactura.Text = dt1["factura"].ToString();
                lblSubtotal.Text = dt1["subtotal"].ToString();
                lblTotal.Text = dt1["total"].ToString();
                lblRuc.Text = dt1["ruc"].ToString();
                lblVendedor.Text = dt1["vendedor"].ToString();
                hfVendedor.Value = dt1["codvend"].ToString();
                GridDetalle();

            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", "Ya se ha solicitado todos los items o no existe el documento", "rojo");
            }
        }
      
        string item = "";
        string descripcion = "";
        int cantingreso = 0;
        int porcentajeingreso = 0;
        int cantfactura = 0;
        decimal precioUnit = 0;
        decimal dtoItem = 0;
        decimal precioTotal = 0;
        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string resul = "";
                string error = "";
                string secuencial = an_compras.SecuencialDtoMercaderia(2);
                foreach (GridViewRow row in gvDetPedidos.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            item = (row.Cells[1].FindControl("lblcodigo") as Label).Text.Trim();
                            cantingreso = Convert.ToInt32((row.Cells[3].FindControl("txtCantidad") as TextBox).Text.Trim());
                            cantfactura = Convert.ToInt32((row.Cells[5].FindControl("lblCantFactura") as Label).Text.Trim());
                            if (cantingreso > cantfactura)
                            {
                                error += " El item " + item + " presenta errores. ";
                            }
                        }
                    }
                }
                if (error == "")
                {
                    foreach (GridViewRow row in gvDetPedidos.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                item = (row.Cells[1].FindControl("lblcodigo") as Label).Text.Trim();
                                descripcion = (row.Cells[2].FindControl("lbldescripcion") as Label).Text.Trim();
                                cantingreso = Convert.ToInt32((row.Cells[3].FindControl("txtCantidad") as TextBox).Text.Trim());
                                porcentajeingreso = Convert.ToInt32((row.Cells[4].FindControl("txtPorcentaje") as TextBox).Text.Trim());
                                cantfactura = Convert.ToInt32((row.Cells[5].FindControl("lblCantFactura") as Label).Text.Trim());
                                precioUnit = Convert.ToDecimal((row.Cells[6].FindControl("lblprecioUnit") as Label).Text.Trim());
                                dtoItem = Convert.ToDecimal((row.Cells[7].FindControl("lblDto") as Label).Text.Trim());
                                precioTotal = Convert.ToDecimal((row.Cells[8].FindControl("lblPrcTotal") as Label).Text.Trim());
                                resul = an_compras.InsDtosMercaderia(secuencial, lblRuc.Text, lblCliente.Text, lblFactura.Text, Convert.ToDateTime(lblFecha.Text), item, descripcion, cantingreso, porcentajeingreso,
                                                               cantfactura, precioUnit, dtoItem, precioTotal, hfVendedor.Value);
                            }
                        }
                    }
                    if (resul == "OK")
                    {
                        string resultado = an_compras.CorreoDtoMercaderia(secuencial);
                        if (resultado == "OK")
                        {
                            //Response.Redirect(Request.RawUrl);
                            lblError.Text = an_alertas.Mensaje("CORRECTO ", "Se envió la notificacion a Cobranzas.", "verde");
                            txtFactura.Text = "";
                            gvDetPedidos.DataSource = null;
                            gvDetPedidos.DataBind();
                            lblCliente.Text = "";
                            lblFecha.Text = "";
                            lblPedido.Text = "";
                            lblFactura.Text = "";
                            lblSubtotal.Text = "";
                            lblTotal.Text = "";
                            lblRuc.Text = "";
                            lblVendedor.Text = "";
                        }
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", error, "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridDetalle()
        {
            try
            {
                gvDetPedidos.DataSource = an_compras.GetGVDetalleFacturaDtos(1, txtFactura.Text.Trim()).DataSource;
                gvDetPedidos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion
        

        
    }
}