using AccesoNegocios.Alertas;
using AccesoNegocios.WmstraB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WmstraB
{
    public partial class frm_cierrerB : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMStraB an_wms = new AN_WMStraB();
        public static string vg_consolidado { set; get; }
        public static string vg_pedido { set; get; }
        public static string vg_producto { set; get; }
        public static string vg_coordenada { set; get; }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCerrar.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (Txt_consolidado.Text.Length > 0)
            {
                gvDetallePicking.Visible = true;
                btnCerrar.Visible = true;
                if (Convert.ToInt32(rdbTipo.SelectedValue) == 1)
                {
                    DataSet gpi = new DataSet();
                    DataTable dti = new DataTable();
                    gpi = an_wms.getCierrePickingTipo(Txt_consolidado.Text.Trim(), 3);
                    dti = gpi.Tables[0];
                    DataRow dt1 = dti.Rows[0];
                    txtTipo.Text = dt1["tipodocumento"].ToString();
                }
                else
                {
                    DataSet gpi = new DataSet();
                    DataTable dti = new DataTable();
                    gpi = an_wms.getCierrePickingTipo(Txt_consolidado.Text.Trim(), 4);
                    dti = gpi.Tables[0];
                    DataRow dt1 = dti.Rows[0];
                    txtTipo.Text = dt1["tipodocumento"].ToString();
                }
                GridPicking();
            }
            else
            {
                btnCerrar.Visible = false;
                gvDetallePicking.Visible = false;
                lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE CONSOLIDADO/PEDIDO", "rojo");
            }
        }

        protected void gvDetallePicking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                vg_consolidado = (gvDetallePicking.SelectedRow.FindControl("lblnumconsolidado") as Label).Text;
                vg_producto = (gvDetallePicking.SelectedRow.FindControl("lblproducto") as Label).Text;
                vg_pedido = (gvDetallePicking.SelectedRow.FindControl("lblpedido") as Label).Text;
                vg_coordenada = (gvDetallePicking.SelectedRow.FindControl("lblcoordenada") as Label).Text;
                //Abrir el modal
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#obsCierra').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetallePicking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string cerrado = (e.Row.Cells[11].Text);
                int solicitada = int.Parse(e.Row.Cells[12].Text);
                int procesada = int.Parse(e.Row.Cells[13].Text);
                int armada = int.Parse(e.Row.Cells[15].Text);
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (cerrado == "CERRADO")
                    {
                        cell.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        if (armada == solicitada)
                        {
                            cell.BackColor = Color.LightGreen;
                        }

                        if ((procesada > 0) && (armada == 0))
                        {
                            cell.BackColor = Color.Yellow;
                        }

                        if ((solicitada == procesada) && (solicitada != armada))
                        {
                            cell.BackColor = Color.Yellow;
                        }

                        if (procesada == 0)
                        {
                            cell.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        protected void btnCerrarA_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                //Abrir el modal
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#obsAnula').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (Txt_consolidado.Text.Length > 0)
                {
                    string resultado = an_wms.AnulaPedidoV2(Txt_consolidado.Text.Trim(), txtObservacion.Text.Trim(), HttpContext.Current.User.Identity.Name);
                    if (resultado.Contains("CORRECTO"))
                    {
                        lblError.Text = an_alertas.Mensaje("", resultado.Trim(), "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("", resultado.Trim(), "rojo");
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN PEDIDO", "rojo");
                }

                //Cerrar el modal
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#obsAnula').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                txtObservacion.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetallePicking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("DarCoordenadas"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string producto = (gvDetallePicking.Rows[index].FindControl("lblproducto") as Label).Text;
                    string empresa = Request.Cookies["basesiav"].Value;
                    string consolidado = (gvDetallePicking.Rows[index].FindControl("lblnumconsolidado") as Label).Text;
                    string salida = an_wms.DarCoordenada(producto, empresa, consolidado);
                    if (salida.Contains("OK"))
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", salida, "verde");
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", salida, "rojo");
                    }
                    GridPicking();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnCerrarItem_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string salida = "";
                if (txtObservacionC.Text.Length > 0)
                {
                    salida = an_wms.UpCerrarProd(vg_consolidado, vg_pedido, vg_producto, vg_coordenada, txtObservacionC.Text.Trim(), HttpContext.Current.User.Identity.Name);
                    GridPicking();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " OBSERVACION OBLIGATORIA", "rojo");
                }
                if (salida.Contains("ERROR"))
                {
                    lblError.Text = an_alertas.Mensaje("", salida, "rojo");
                }


            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridPicking()
        {
            try
            {
                //btnCerrar.Text = Txt_consolidado.Text.Trim();
                gvDetallePicking.DataSource = an_wms.getCierrePicking(Txt_consolidado.Text.Trim(), Convert.ToInt32(rdbTipo.SelectedValue)).DataSource;
                gvDetallePicking.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

    }
}