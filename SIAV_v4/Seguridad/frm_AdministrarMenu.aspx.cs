using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocios.Seguridad;
using AccesoNegocios.Alertas;
using AccesoEntidades.Seguridad;

namespace SIAV_v4.Seguridad
{
    public partial class frm_AdministrarMenu : System.Web.UI.Page
    {
        #region Inicializacion Globales
        AN_Autentificar an_autentificar = new AN_Autentificar();
        AN_Menu an_menu = new AN_Menu();
        AN_Alertas an_alertas = new AN_Alertas();
        AE_GA_SEG_TmenuNivel1 ae_seg_menunivel1 = new AE_GA_SEG_TmenuNivel1();
        AE_GA_SEG_TmenuNivel2 ae_seg_menunivel2 = new AE_GA_SEG_TmenuNivel2();
        AE_GA_SEG_TmenuNivel3 ae_seg_menunivel3 = new AE_GA_SEG_TmenuNivel3();
        #endregion

        #region VariablesGlobales
        private static string valorn1 { set; get; }
        private static string valorn2 { set; get; }
        #endregion

        #region Funciones
        private void CargarCombo()
        {
            cblEmpresa.DataSource = an_autentificar.getEmpresas();
            cblEmpresa.DataTextField = "empresa";
            cblEmpresa.DataValueField = "cod_emp";
            cblEmpresa.DataBind();
        }

        private void CargarCombo2()
        {
            cblEmpresaN2.DataSource = an_autentificar.getEmpresas();
            cblEmpresaN2.DataTextField = "empresa";
            cblEmpresaN2.DataValueField = "cod_emp";
            cblEmpresaN2.DataBind();
        }

        private void CargarCombo3()
        {
            cblEmpresaN3.DataSource = an_autentificar.getEmpresas();
            cblEmpresaN3.DataTextField = "empresa";
            cblEmpresaN3.DataValueField = "cod_emp";
            cblEmpresaN3.DataBind();
        }

        private void CargarGridNivel1()
        {
            gvNivel1.DataSource = an_menu.GetConfigNivel("1","").DataSource;
            gvNivel1.DataBind();
        }

        private void CargarGridNivel2(string buscar)
        {
            gvNivel2.DataSource = an_menu.GetConfigNivel("2", buscar).DataSource;
            gvNivel2.DataBind();
        }

        private void CargarGridNivel3(string buscar)
        {
            gvNivel3.DataSource = an_menu.GetConfigNivel("3", buscar).DataSource;
            gvNivel3.DataBind();
        }
        #endregion

        #region Normales
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridNivel1();
                btnNuevoHijo.Visible = false;
                btnNuevoNieto.Visible = false;
            }
        }

        protected void lbkNivel1_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = "";
                LinkButton lb = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lb.NamingContainer;
                if (row != null)
                {
                    int index = row.RowIndex;
                    Label lbl = (Label)row.FindControl("lblid_men");
                    LinkButton lbl2 = (LinkButton)row.FindControl("lbldescription");
                    valorn1 = lbl.Text;
                    Nombre = lbl2.Text;
                }
                CargarGridNivel2(valorn1);
                CargarGridNivel3("");
                lblError.Text = an_alertas.Mensaje("INFO!", "Hijos Cargados", "azul");
                lblNivel2.Text = Nombre;
                lblNivel3.Text = "";
                btnNuevoHijo.Visible = true;
                btnNuevoNieto.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
            }
        }

        protected void lbkNivel2_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = "";
                LinkButton lb = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lb.NamingContainer;
                if (row != null)
                {
                    int index = row.RowIndex;
                    Label lbl = (Label)row.FindControl("lblid_men");
                    LinkButton lbl2 = (LinkButton)row.FindControl("lbldescription");
                    Nombre = lbl2.Text;
                    valorn2 = lbl.Text;
                }
                CargarGridNivel3(valorn2);
                lblError.Text = an_alertas.Mensaje("INFO!", "Ñetos Cargados", "azul");
                lblNivel3.Text = Nombre;
                btnNuevoNieto.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
            }
        }
        #endregion

        #region Grid
        protected void gvNivel1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    //CargarCombo
                    CargarCombo();
                    //Pasar Variables
                    hfCodigoPrincipal.Value = (gvNivel1.Rows[index].FindControl("lblid_men") as Label).Text;
                    txtDescripcion.Text = (gvNivel1.Rows[index].FindControl("lbldescription") as LinkButton).Text;
                    txtUrl.Text = (gvNivel1.Rows[index].FindControl("lblurl") as Label).Text;
                    txtIcono.Text = (gvNivel1.Rows[index].FindControl("lblIcono") as Label).Text;
                    txtHijo.Text = (gvNivel1.Rows[index].FindControl("lblHijos") as Label).Text;

                    string IAV = (gvNivel1.Rows[index].FindControl("lblIAV") as Label).Text;
                    string CORPAL = (gvNivel1.Rows[index].FindControl("lblCORPAL") as Label).Text;
                    string ALLPARTS = (gvNivel1.Rows[index].FindControl("lblALLPARTS") as Label).Text;
                    string CAO = (gvNivel1.Rows[index].FindControl("lblCAO") as Label).Text;
                    string RECTIMA = (gvNivel1.Rows[index].FindControl("lblRECTIMA") as Label).Text;
                    string DEPO = (gvNivel1.Rows[index].FindControl("lblDEPO") as Label).Text;
                    string IAVEC = (gvNivel1.Rows[index].FindControl("lblIAVEC") as Label).Text;
                    //Limpiar el combo
                    foreach (ListItem item in cblEmpresa.Items)
                    {
                        item.Selected = false;
                    }
                    //Seleccionar los actuales
                    foreach (ListItem item in cblEmpresa.Items)
                    {
                        if (IAV == "1" && item.Value.ToString() == "1") item.Selected = true;
                        if (CORPAL == "1" && item.Value.ToString() == "2") item.Selected = true;
                        if (RECTIMA == "1" && item.Value.ToString() == "3") item.Selected = true;
                        if (DEPO == "1" && item.Value.ToString() == "6") item.Selected = true;
                        if (IAVEC == "1" && item.Value.ToString() == "7") item.Selected = true;
                        if (ALLPARTS == "1" && item.Value.ToString() == "4") item.Selected = true;
                        if (CAO == "1" && item.Value.ToString() == "5") item.Selected = true;
                    }
                    //Limpiar Combo y Check los que tiene igual a 1

                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN1').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
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

        protected void gvNivel2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    //CargarCombo
                    CargarCombo2();
                    //Pasar Variables
                    hfCodigoPrincipalN2.Value = (gvNivel2.Rows[index].FindControl("lblid_men") as Label).Text;
                    txtDescripcionN2.Text = (gvNivel2.Rows[index].FindControl("lbldescription") as LinkButton).Text;
                    txtUrlN2.Text = (gvNivel2.Rows[index].FindControl("lblurl") as Label).Text;
                    txtIconoN2.Text = (gvNivel2.Rows[index].FindControl("lblIcono") as Label).Text;
                    txtHijoN2.Text = (gvNivel2.Rows[index].FindControl("lblHijos") as Label).Text;

                    string IAV = (gvNivel2.Rows[index].FindControl("lblIAV") as Label).Text;
                    string CORPAL = (gvNivel2.Rows[index].FindControl("lblCORPAL") as Label).Text;
                    string ALLPARTS = (gvNivel2.Rows[index].FindControl("lblALLPARTS") as Label).Text;
                    string CAO = (gvNivel2.Rows[index].FindControl("lblCAO") as Label).Text;
                    string RECTIMA = (gvNivel2.Rows[index].FindControl("lblRECTIMA") as Label).Text;
                    string DEPO = (gvNivel2.Rows[index].FindControl("lblDEPO") as Label).Text;
                    string IAVEC = (gvNivel2.Rows[index].FindControl("lblIAVEC") as Label).Text;
                    //Limpiar el combo
                    foreach (ListItem item in cblEmpresaN2.Items)
                    {
                        item.Selected = false;
                    }
                    //Seleccionar los actuales
                    foreach (ListItem item in cblEmpresaN2.Items)
                    {
                        if (IAV == "1" && item.Value.ToString() == "1") item.Selected = true;
                        if (CORPAL == "1" && item.Value.ToString() == "2") item.Selected = true;
                        if (RECTIMA == "1" && item.Value.ToString() == "3") item.Selected = true;
                        if (DEPO == "1" && item.Value.ToString() == "6") item.Selected = true;
                        if (IAVEC == "1" && item.Value.ToString() == "7") item.Selected = true;
                        if (ALLPARTS == "1" && item.Value.ToString() == "4") item.Selected = true;
                        if (CAO == "1" && item.Value.ToString() == "5") item.Selected = true;
                    }
                    //Limpiar Combo y Check los que tiene igual a 1

                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN2').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
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

        protected void gvNivel3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    //CargarCombo
                    CargarCombo3();
                    //Pasar Variables
                    hfCodigoPrincipalN3.Value = (gvNivel3.Rows[index].FindControl("lblid_men") as Label).Text;
                    txtDescripcionN3.Text = (gvNivel3.Rows[index].FindControl("lbldescription") as Label).Text;
                    txtUrlN3.Text = (gvNivel3.Rows[index].FindControl("lblurl") as Label).Text;
                    txtIconoN3.Text = (gvNivel3.Rows[index].FindControl("lblIcono") as Label).Text;

                    string IAV = (gvNivel3.Rows[index].FindControl("lblIAV") as Label).Text;
                    string CORPAL = (gvNivel3.Rows[index].FindControl("lblCORPAL") as Label).Text;
                    string ALLPARTS = (gvNivel3.Rows[index].FindControl("lblALLPARTS") as Label).Text;
                    string CAO = (gvNivel3.Rows[index].FindControl("lblCAO") as Label).Text;
                    string RECTIMA = (gvNivel3.Rows[index].FindControl("lblRECTIMA") as Label).Text;
                    string DEPO = (gvNivel3.Rows[index].FindControl("lblDEPO") as Label).Text;
                    string IAVEC = (gvNivel3.Rows[index].FindControl("lblIAVEC") as Label).Text;
                    //Limpiar el combo
                    foreach (ListItem item in cblEmpresaN3.Items)
                    {
                        item.Selected = false;
                    }
                    //Seleccionar los actuales
                    foreach (ListItem item in cblEmpresaN3.Items)
                    {
                        if (IAV == "1" && item.Value.ToString() == "1") item.Selected = true;
                        if (CORPAL == "1" && item.Value.ToString() == "2") item.Selected = true;
                        if (RECTIMA == "1" && item.Value.ToString() == "3") item.Selected = true;
                        if (DEPO == "1" && item.Value.ToString() == "6") item.Selected = true;
                        if (IAVEC == "1" && item.Value.ToString() == "7") item.Selected = true;
                        if (ALLPARTS == "1" && item.Value.ToString() == "4") item.Selected = true;
                        if (CAO == "1" && item.Value.ToString() == "5") item.Selected = true;
                    }
                    //Limpiar Combo y Check los que tiene igual a 1

                    //Abrir ModalPoPuP
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN3').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_seg_menunivel1.id_menu_option = hfCodigoPrincipal.Value;
                    ae_seg_menunivel1.description = txtDescripcion.Text;
                    ae_seg_menunivel1.hijos = txtHijo.Text;
                    ae_seg_menunivel1.url = txtUrl.Text;
                    ae_seg_menunivel1.icono = txtIcono.Text;
                    foreach (ListItem item in cblEmpresa.Items)
                    {
                        if (item.Value.ToString() == "1") ae_seg_menunivel1.iav = item.Selected.ToString();
                        if (item.Value.ToString() == "2") ae_seg_menunivel1.corpal = item.Selected.ToString();
                        if (item.Value.ToString() == "3") ae_seg_menunivel1.rectima = item.Selected.ToString();
                        if (item.Value.ToString() == "4") ae_seg_menunivel1.allparts = item.Selected.ToString();
                        if (item.Value.ToString() == "5") ae_seg_menunivel1.cao = item.Selected.ToString();
                        if (item.Value.ToString() == "6") ae_seg_menunivel1.depo = item.Selected.ToString();
                        if (item.Value.ToString() == "7") ae_seg_menunivel1.iavec = item.Selected.ToString();
                    }
                    an_menu.UpdateNivel1(ae_seg_menunivel1);
                    CargarGridNivel1();
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN1').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }

        protected void btnActualizarN2_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_seg_menunivel2.id_menu_option = hfCodigoPrincipalN2.Value;
                    ae_seg_menunivel2.description = txtDescripcionN2.Text;
                    ae_seg_menunivel2.hijos = txtHijoN2.Text;
                    ae_seg_menunivel2.url = txtUrlN2.Text;
                    ae_seg_menunivel2.icono = txtIconoN2.Text;
                    foreach (ListItem item in cblEmpresaN2.Items)
                    {
                        if (item.Value.ToString() == "1") ae_seg_menunivel2.iav = item.Selected.ToString();
                        if (item.Value.ToString() == "2") ae_seg_menunivel2.corpal = item.Selected.ToString();
                        if (item.Value.ToString() == "3") ae_seg_menunivel2.rectima = item.Selected.ToString();
                        if (item.Value.ToString() == "6") ae_seg_menunivel2.depo = item.Selected.ToString();
                        if (item.Value.ToString() == "4") ae_seg_menunivel2.allparts = item.Selected.ToString();
                        if (item.Value.ToString() == "5") ae_seg_menunivel2.cao = item.Selected.ToString();
                        if (item.Value.ToString() == "7") ae_seg_menunivel2.iavec = item.Selected.ToString();
                    }
                    an_menu.UpdateNivel2(ae_seg_menunivel2);
                    CargarGridNivel2(valorn1);
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN2').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }

        protected void btnActualizarN3_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_seg_menunivel3.id_menu_option = hfCodigoPrincipalN3.Value;
                    ae_seg_menunivel3.description = txtDescripcionN3.Text;
                    ae_seg_menunivel3.url = txtUrlN3.Text;
                    ae_seg_menunivel3.icono = txtIconoN3.Text;
                    foreach (ListItem item in cblEmpresaN3.Items)
                    {
                        if (item.Value.ToString() == "1") ae_seg_menunivel3.iav = item.Selected.ToString();
                        if (item.Value.ToString() == "2") ae_seg_menunivel3.corpal = item.Selected.ToString();
                        if (item.Value.ToString() == "3") ae_seg_menunivel3.rectima = item.Selected.ToString();
                        if (item.Value.ToString() == "6") ae_seg_menunivel3.depo = item.Selected.ToString();
                        if (item.Value.ToString() == "4") ae_seg_menunivel3.allparts = item.Selected.ToString();
                        if (item.Value.ToString() == "5") ae_seg_menunivel3.cao = item.Selected.ToString();
                        if (item.Value.ToString() == "7") ae_seg_menunivel3.iavec = item.Selected.ToString();
                    }
                    an_menu.UpdateNivel3(ae_seg_menunivel3);
                    CargarGridNivel3(valorn2);
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModalN3').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }

        protected void btnNewPadre_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_seg_menunivel1.description = txtNewDescripcion.Text;
                    ae_seg_menunivel1.hijos = txtNewHijo.Text;
                    ae_seg_menunivel1.url = txtNewUrl.Text;
                    ae_seg_menunivel1.icono = txtNewIcono.Text;
                    an_menu.InsertNewPadre(ae_seg_menunivel1);
                    CargarGridNivel1();
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#addModalN1').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }

        protected void btnNewPadreN2_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_seg_menunivel2.description = txtNew2Descripcion.Text;
                    ae_seg_menunivel2.hijos = txtNew2Hijo.Text;
                    ae_seg_menunivel2.url = txtNew2Url.Text;
                    ae_seg_menunivel2.icono = txtNew2Icono.Text;
                    ae_seg_menunivel2.id_parent_menu_option = valorn1;
                    an_menu.InsertNewHijo(ae_seg_menunivel2);
                    CargarGridNivel2(valorn1);
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#addModalN2').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }

        protected void btnNewPadreN3_Click(object sender, EventArgs e)
        {
            //Valida Intentos de Hacking
            if (Page.IsValid)
            {
                try
                {
                    ae_seg_menunivel3.description = txtNew3Descripcion.Text;
                    ae_seg_menunivel3.hijos = "N";
                    ae_seg_menunivel3.url = txtNew3Url.Text;
                    ae_seg_menunivel3.icono = txtNew3Icono.Text;
                    ae_seg_menunivel3.id_parent_menu_option = valorn2;
                    an_menu.InsertNewNieto(ae_seg_menunivel3);
                    CargarGridNivel3(valorn2);
                    lblError.Text = an_alertas.Mensaje("CORRECTO!", "Se Actualizo Correctamente", "verde");
                }
                catch (Exception ex)
                {
                    lblError.Text = an_alertas.Mensaje("ERROR!", ex.Message, "rojo");
                }
                finally
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#addModalN3').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                }
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR!", "Validación Incorrecta", "rojo");
            }
        }

        protected void btnNuevoPadre_Click(object sender, ImageClickEventArgs e)
        {
            //Abrir ModalPoPuP
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModalN1').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }

        protected void btnNuevoPadreN2_Click(object sender, ImageClickEventArgs e)
        {
            //Abrir ModalPoPuP
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModalN2').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }

        protected void btnNuevoPadreN3_Click(object sender, ImageClickEventArgs e)
        {
            //Abrir ModalPoPuP
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModalN3').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
        #endregion
    }
}