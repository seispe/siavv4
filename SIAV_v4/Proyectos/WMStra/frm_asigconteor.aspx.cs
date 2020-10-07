using AccesoNegocios.Alertas;
using AccesoNegocios.WMStra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMStra
{
    public partial class frm_asigconteor : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMStra an_wms = new AN_WMStra();
        public static int op;
        public static string idMConteoCiclico;
        public static string tipo;
        #endregion

        #region Funciones
        public void VincularDdlUsuario()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = an_wms.GetPicking(2, Request.Cookies["basesiav"].Value);

            ddlUsuario.DataSource = dsp;
            ddlUsuario.DataTextField = "nombre";
            ddlUsuario.DataValueField = "nombre";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("Eliga un Usuario..", "ninguno"));
        }

        public void GridProdFam()
        {
            try
            {
                if (op == 1)
                {
                    gvProdFam.DataSource = an_wms.GetCCproductofamilia(op, txtDato.Text.Trim());
                    gvProdFam.DataBind();
                }
                if (op == 2)
                {
                    gvProdFam.DataSource = an_wms.GetCCproductofamilia(op, "");
                    gvProdFam.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridAsignados()
        {
            try
            {
                gvUsuAsig.DataSource = an_wms.GetUsuAsig("", 0);
                gvUsuAsig.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void GridDetalle()
        {
            try
            {
                gvDetalle.DataSource = an_wms.GetUsuAsig(idMConteoCiclico, 3);
                gvDetalle.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDato.Visible = false;
                imgB.Visible = false;
                imgAsigna.Visible = false;
                VincularDdlUsuario();
                GridAsignados();
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (ddlTipo.SelectedValue == "0")
                {
                    op = 0;
                    txtDato.Visible = false;
                    imgB.Visible = false;
                    imgAsigna.Visible = false;
                    gvProdFam.Visible = false;
                }

                if (ddlTipo.SelectedValue == "producto")
                {
                    op = 1;
                    txtDato.Visible = true;
                    imgB.Visible = true;
                    imgAsigna.Visible = true;
                    gvProdFam.Visible = false;
                }

                if (ddlTipo.SelectedValue == "familia")
                {
                    op = 2;
                    txtDato.Visible = false;
                    imgB.Visible = false;
                    imgAsigna.Visible = true;
                    gvProdFam.Visible = true;
                    GridProdFam();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void imgB_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridProdFam();
                gvProdFam.Visible = true;
                imgB.Visible = true;
                imgAsigna.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
                ddlTipo.ClearSelection();
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                string salida = "";
                string salida2 = "";
                lblError.Text = "";
                //ELIGA UN USUARIO
                if (ddlUsuario.SelectedValue == "ninguno")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "ELIGA UN USUARIO", "rojo");
                }
                else
                {
                    foreach (GridViewRow row in gvProdFam.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                string tipo = ddlTipo.SelectedValue;
                                string codigo = (row.Cells[1].FindControl("lblcodigo") as Label).Text.Trim();
                                string descripcion = (row.Cells[1].FindControl("lbldescripcion") as Label).Text.Trim();
                                string empresa = Request.Cookies["basesiav"].Value;
                                string usuarioasigna = HttpContext.Current.User.Identity.Name;
                                string usuario = ddlUsuario.SelectedValue;
                                salida = an_wms.InsConteoCiclico(1, tipo, "", 0, codigo, descripcion, "", "", empresa, 0, usuario, usuarioasigna);
                            }
                            else
                            {
                                salida2 = "VISTEE UN PRODUCTO O FAMILIA";
                            }
                        }
                    }

                    if (salida2 != "") lblError.Text = an_alertas.Mensaje("ERROR ", salida2, "rojo");
                    if (salida.Contains("ERROR")) lblError.Text = an_alertas.Mensaje("", salida, "rojo");
                    if (salida.Contains("CORRECTO")) lblError.Text = an_alertas.Mensaje("", salida, "verde");

                    ddlTipo.ClearSelection();
                    ddlUsuario.ClearSelection();
                    txtDato.Visible = false;
                    imgB.Visible = false;
                    imgAsigna.Visible = false;
                    gvProdFam.Visible = false;
                    GridAsignados();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvUsuAsig_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName.Equals("DetConteo"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    idMConteoCiclico = (gvUsuAsig.Rows[index].FindControl("lblid") as Label).Text;
                    tipo = (gvUsuAsig.Rows[index].FindControl("lbltipo") as Label).Text;
                    GridDetalle();
                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#detModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnContar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string empresa = Request.Cookies["basesiav"].Value;
                string salida = an_wms.InsConteoCiclico(8, tipo, "", 0, "", "", txtObservacion.Text.Trim(), "", empresa, 0, "", "");

                //Abrir ModalPoPuP
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#detModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

                GridAsignados();

                if (salida.Contains("ERROR")) lblError.Text = an_alertas.Mensaje("", salida, "rojo");
                if (salida.Contains("CORRECTO")) lblError.Text = an_alertas.Mensaje("", salida, "verde");
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetalle.PageIndex = e.NewPageIndex;
            GridDetalle();
        }

        protected void gvProdFam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdFam.PageIndex = e.NewPageIndex;
            GridProdFam();
        }
        #endregion
    }
}