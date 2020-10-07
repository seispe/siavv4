<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_AdministrarMenu.aspx.cs" Inherits="SIAV_v4.Seguridad.frm_AdministrarMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <%--<a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>              --%>
                <h1 class="page-header">Administrar Menu</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<%--Padres--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="upBtnPadre" runat="server">
            <ContentTemplate>
                <asp:ImageButton ID="btnNuevoPadre" runat="server" ImageUrl="~/Recursos/images/add.png" CssClass="btn btn-success" OnClick="btnNuevoPadre_Click" CausesValidation="false"/>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:gridview id="gvNivel1" runat="server"
                autogeneratecolumns="False" cellpadding="4"
                cssclass="grid" datakeynames="id_men" forecolor="#333333"
                gridlines="None" OnRowCommand="gvNivel1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
                    </asp:ButtonField>
                    <asp:TemplateField HeaderText="id_men" SortExpression="id_men" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblid_men" runat="server" Text='<%# Bind("id_men") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion" SortExpression="descripcion" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbldescription" runat="server" Text='<%# Bind("descripcion") %>' OnClick="lbkNivel1_Click" CausesValidation="false"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Padre" SortExpression="padre" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPadre" runat="server" Text='<%# Bind("padre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Url" SortExpression="url">
                        <ItemTemplate>
                            <asp:Label ID="lblurl" runat="server" Text='<%# Bind("url") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nivel" SortExpression="nivel" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblNivel" runat="server" Text='<%# Bind("nivel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hijos" SortExpression="hijos">
                        <ItemTemplate>
                            <asp:Label ID="lblHijos" runat="server" Text='<%# Bind("hijos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Icono" SortExpression="icono" >
                        <ItemTemplate>
                            <asp:Label ID="lblIcono" runat="server" Text='<%# Bind("icono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IAV" SortExpression="IAV" >
                        <ItemTemplate>
                            <asp:Label ID="lblIAV" runat="server" Text='<%# Bind("IAV") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CORPAL" SortExpression="CORPAL" >
                        <ItemTemplate>
                            <asp:Label ID="lblCORPAL" runat="server" Text='<%# Bind("CORPAL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ALLPARTS" SortExpression="ALLPARTS" >
                        <ItemTemplate>
                            <asp:Label ID="lblALLPARTS" runat="server" Text='<%# Bind("ALLPARTS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CAO" SortExpression="CAO" >
                        <ItemTemplate>
                            <asp:Label ID="lblCAO" runat="server" Text='<%# Bind("CAO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RECTIMA" SortExpression="RECTIMA" >
                        <ItemTemplate>
                            <asp:Label ID="lblRECTIMA" runat="server" Text='<%# Bind("RECTIMA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEPO" SortExpression="DEPO" >
                        <ItemTemplate>
                            <asp:Label ID="lblDEPO" runat="server" Text='<%# Bind("DEPO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IAVEC" SortExpression="IAVEC" >
                        <ItemTemplate>
                            <asp:Label ID="lblIAVEC" runat="server" Text='<%# Bind("IAVEC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            </asp:gridview>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<%--Hijos--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="upBtnHijo" runat="server">
            <ContentTemplate>
                <asp:ImageButton ID="btnNuevoHijo" runat="server" ImageUrl="~/Recursos/images/add.png" CssClass="btn btn-success" OnClick="btnNuevoPadreN2_Click" CausesValidation="false"/>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel id="upGridView2" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Label ID="lblNivel2" runat="server" Text="" CssClass="label label-info"></asp:Label>
                <asp:gridview id="gvNivel2" runat="server"
                autogeneratecolumns="False" cellpadding="4"
                cssclass="grid" datakeynames="id_men" forecolor="#333333"
                gridlines="None" OnRowCommand="gvNivel2_RowCommand" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
                    </asp:ButtonField>
                    <asp:TemplateField HeaderText="id_men" SortExpression="id_men" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblid_men" runat="server" Text='<%# Bind("id_men") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion" SortExpression="descripcion" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lbldescription" runat="server" Text='<%# Bind("descripcion") %>' OnClick="lbkNivel2_Click" CausesValidation="false"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Padre" SortExpression="padre" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPadre" runat="server" Text='<%# Bind("padre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Url" SortExpression="url">
                        <ItemTemplate>
                            <asp:Label ID="lblurl" runat="server" Text='<%# Bind("url") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nivel" SortExpression="nivel" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblNivel" runat="server" Text='<%# Bind("nivel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hijos" SortExpression="hijos">
                        <ItemTemplate>
                            <asp:Label ID="lblHijos" runat="server" Text='<%# Bind("hijos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Icono" SortExpression="icono" >
                        <ItemTemplate>
                            <asp:Label ID="lblIcono" runat="server" Text='<%# Bind("icono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IAV" SortExpression="IAV" >
                        <ItemTemplate>
                            <asp:Label ID="lblIAV" runat="server" Text='<%# Bind("IAV") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CORPAL" SortExpression="CORPAL" >
                        <ItemTemplate>
                            <asp:Label ID="lblCORPAL" runat="server" Text='<%# Bind("CORPAL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ALLPARTS" SortExpression="ALLPARTS" >
                        <ItemTemplate>
                            <asp:Label ID="lblALLPARTS" runat="server" Text='<%# Bind("ALLPARTS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CAO" SortExpression="CAO" >
                        <ItemTemplate>
                            <asp:Label ID="lblCAO" runat="server" Text='<%# Bind("CAO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RECTIMA" SortExpression="RECTIMA" >
                        <ItemTemplate>
                            <asp:Label ID="lblRECTIMA" runat="server" Text='<%# Bind("RECTIMA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEPO" SortExpression="DEPO" >
                        <ItemTemplate>
                            <asp:Label ID="lblDEPO" runat="server" Text='<%# Bind("DEPO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IAVEC" SortExpression="IAVEC" >
                        <ItemTemplate>
                            <asp:Label ID="lblIAVEC" runat="server" Text='<%# Bind("IAVEC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            </asp:gridview>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<%--Ñetos--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="upBtnNieto" runat="server">
            <ContentTemplate>
                <asp:ImageButton ID="btnNuevoNieto" runat="server" ImageUrl="~/Recursos/images/add.png" CssClass="btn btn-success" OnClick="btnNuevoPadreN3_Click" CausesValidation="false"/>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel id="upNivel3" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Label ID="lblNivel3" runat="server" Text="" CssClass="label label-info"></asp:Label>
                <asp:gridview id="gvNivel3" runat="server"
                autogeneratecolumns="False" cellpadding="4"
                cssclass="grid" datakeynames="id_men" forecolor="#333333"
                gridlines="None" OnRowCommand="gvNivel3_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
                    </asp:ButtonField>
                    <asp:TemplateField HeaderText="id_men" SortExpression="id_men" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblid_men" runat="server" Text='<%# Bind("id_men") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion" SortExpression="descripcion" >
                        <ItemTemplate>
                            <asp:Label ID="lbldescription" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Padre" SortExpression="padre" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPadre" runat="server" Text='<%# Bind("padre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Url" SortExpression="url">
                        <ItemTemplate>
                            <asp:Label ID="lblurl" runat="server" Text='<%# Bind("url") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nivel" SortExpression="nivel" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblNivel" runat="server" Text='<%# Bind("nivel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hijos" SortExpression="hijos" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblHijos" runat="server" Text='<%# Bind("hijos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Icono" SortExpression="icono" >
                        <ItemTemplate>
                            <asp:Label ID="lblIcono" runat="server" Text='<%# Bind("icono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IAV" SortExpression="IAV" >
                        <ItemTemplate>
                            <asp:Label ID="lblIAV" runat="server" Text='<%# Bind("IAV") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CORPAL" SortExpression="CORPAL" >
                        <ItemTemplate>
                            <asp:Label ID="lblCORPAL" runat="server" Text='<%# Bind("CORPAL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ALLPARTS" SortExpression="ALLPARTS" >
                        <ItemTemplate>
                            <asp:Label ID="lblALLPARTS" runat="server" Text='<%# Bind("ALLPARTS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CAO" SortExpression="CAO" >
                        <ItemTemplate>
                            <asp:Label ID="lblCAO" runat="server" Text='<%# Bind("CAO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RECTIMA" SortExpression="RECTIMA" >
                        <ItemTemplate>
                            <asp:Label ID="lblRECTIMA" runat="server" Text='<%# Bind("RECTIMA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEPO" SortExpression="DEPO" >
                        <ItemTemplate>
                            <asp:Label ID="lblDEPO" runat="server" Text='<%# Bind("DEPO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IAVEC" SortExpression="IAVEC" >
                        <ItemTemplate>
                            <asp:Label ID="lblIAVEC" runat="server" Text='<%# Bind("IAVEC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            </asp:gridview>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<%--Modal Editar Nivel 1--%>
<div id="editModalN1" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="editModalLabel">Editar Registro</h3>
                        <asp:HiddenField ID="hfCodigoPrincipal" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Descripcion</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtDescripcion" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtDescripcion" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtDescripcion" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtDescripcion" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                <label class="control-label" for="inputSuccess">Url</label>
                            </div>                            
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtUrl" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtUrl" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtUrl"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtUrl" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras y Números" ToolTip="Solo Letras y Números" ControlToValidate="txtUrl" ValidationExpression="^[a-zA-Z0-9?=#/_.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Icono</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtIcono" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtIcono" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtIcono"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtIcono" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtIcono" ValidationExpression="^[a-zA-Z-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Hijo</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtHijo" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtHijo" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtHijo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtHijo" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo S o N" ControlToValidate="txtHijo" ValidationExpression="^[SN]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Empresa</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:CheckBoxList ID="cblEmpresa" CssClass="form-control" runat="server"></asp:CheckBoxList>
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnGuardar" runat="server" Text="Actualizar" CssClass="btn btn-info" OnClick="btnActualizar_Click" ValidationGroup="editModalN1"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal Editar Nivel 2--%>
<div id="editModalN2" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="editModalLabel2">Editar Registro</h3>
                        <asp:HiddenField ID="hfCodigoPrincipalN2" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Descripcion</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtDescripcionN2" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtDescripcionN2" runat="server" ValidationGroup="editModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtDescripcionN2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtDescripcionN2" runat="server" ValidationGroup="editModalN2" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtDescripcionN2" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Url</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtUrlN2" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtUrlN2" runat="server" ValidationGroup="editModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtUrlN2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtUrlN2" runat="server" ValidationGroup="editModalN2" ForeColor="Red" Text="Solo Letras y Números" ToolTip="Solo Letras y Números" ControlToValidate="txtUrlN2" ValidationExpression="^[a-zA-Z0-9?=#/._]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Icono</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtIconoN2" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtIconoN2" runat="server" ValidationGroup="editModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtIconoN2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtIconoN2" runat="server" ValidationGroup="editModalN2" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtIconoN2" ValidationExpression="^[a-zA-Z-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Hijo</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtHijoN2" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtHijoN2" runat="server" ValidationGroup="editModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtHijoN2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtHijoN2" runat="server" ValidationGroup="editModalN2" ForeColor="Red" Text="Solo Letras" ToolTip="Solo S o N" ControlToValidate="txtHijoN2" ValidationExpression="^[SN]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Empresa</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:CheckBoxList ID="cblEmpresaN2" CssClass="form-control" runat="server"></asp:CheckBoxList>
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnActualizarN1" runat="server" Text="Actualizar" CssClass="btn btn-info" OnClick="btnActualizarN2_Click" ValidationGroup="editModalN2"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal Editar Nivel 3--%>
<div id="editModalN3" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="editModalLabel3">Editar Registro</h3>
                        <asp:HiddenField ID="hfCodigoPrincipalN3" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Descripcion</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtDescripcionN3" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtDescripcionN3" runat="server" ValidationGroup="editModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtDescripcionN3"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtDescripcionN3" runat="server" ValidationGroup="editModalN3" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtDescripcionN3" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Url</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtUrlN3" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtUrlN3" runat="server" ValidationGroup="editModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtUrlN3"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtUrlN3" runat="server" ValidationGroup="editModalN3" ForeColor="Red" Text="Solo Letras y Números" ToolTip="Solo Letras y Números" ControlToValidate="txtUrlN3" ValidationExpression="^[a-zA-Z0-9?=#/._]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Icono</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtIconoN3" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtIconoN3" runat="server" ValidationGroup="editModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtIconoN3"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtIconoN3" runat="server" ValidationGroup="editModalN3" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtIconoN3" ValidationExpression="^[a-zA-Z-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Empresa</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:CheckBoxList ID="cblEmpresaN3" CssClass="form-control" runat="server"></asp:CheckBoxList>
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="Button1" runat="server" Text="Actualizar" CssClass="btn btn-info" OnClick="btnActualizarN3_Click" ValidationGroup="editModalN3"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal New Nivel 1--%>
<div id="addModalN1" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="addModalLabel">Nuevo Registro</h3>
                        <asp:HiddenField ID="hfNuevoCodigo" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Descripcion</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewDescripcion" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewDescripcion" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtNewDescripcion"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewDescripcion" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Numeros" ControlToValidate="txtNewDescripcion" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Url</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewUrl" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewUrl" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtNewUrl"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewUrl" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras y Números" ToolTip="Solo Letras y Números" ControlToValidate="txtNewUrl" ValidationExpression="^[a-zA-Z0-9?=#/._]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Icono</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewIcono" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewIcono" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNewIcono"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewIcono" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtNewIcono" ValidationExpression="^[a-zA-Z-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Hijo</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewHijo" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewHijo" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNewHijo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewHijo" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo S o N" ToolTip="Solo S o N" ControlToValidate="txtNewHijo" ValidationExpression="^[SN]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnNewPadre" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnNewPadre_Click" ValidationGroup="addModalN1"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal New Nivel 2--%>
<div id="addModalN2" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="addModalLabel2">Nuevo Registro</h3>
                        <asp:HiddenField ID="hfNuevoCodigoN2" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Descripcion</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew2Descripcion" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew2Descripcion" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtNew2Descripcion"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew2Descripcion" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Numeros" ControlToValidate="txtNew2Descripcion" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Url</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew2Url" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew2Url" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtNew2Url"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew2Url" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo Letras y Números" ToolTip="Solo Letras y Números" ControlToValidate="txtNew2Url" ValidationExpression="^[a-zA-Z0-9?=#/._]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Icono</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew2Icono" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew2Icono" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNew2Icono"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew2Icono" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtNew2Icono" ValidationExpression="^[a-zA-Z-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Hijo</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew2Hijo" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew2Hijo" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNew2Hijo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew2Hijo" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo S o N" ToolTip="Solo S o N" ControlToValidate="txtNew2Hijo" ValidationExpression="^[SN]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="Button2" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnNewPadreN2_Click" ValidationGroup="addModalN2"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal New Nivel 3--%>
<div id="addModalN3" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel7" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="addModalLabel3">Nuevo Registro</h3>
                        <asp:HiddenField ID="hfNuevoCodigo3" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Descripcion</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew3Descripcion" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew3Descripcion" runat="server" ValidationGroup="addModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtNew3Descripcion"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew3Descripcion" runat="server" ValidationGroup="addModalN3" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Numeros" ControlToValidate="txtNew3Descripcion" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Url</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew3Url" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew3Url" runat="server" ValidationGroup="addModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtNew3Url"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew3Url" runat="server" ValidationGroup="addModalN3" ForeColor="Red" Text="Solo Letras y Numeros" ToolTip="Solo Letras y Numeros" ControlToValidate="txtNew3Url" ValidationExpression="^[a-zA-Z0-9?=#/._]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Icono</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNew3Icono" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNew3Icono" runat="server" ValidationGroup="addModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNew3Icono"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNew3Icono" runat="server" ValidationGroup="addModalN3" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtNew3Icono" ValidationExpression="^[a-zA-Z-]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="Button3" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnNewPadreN3_Click" ValidationGroup="addModalN3"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<!-- Efecto Procesando -->
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div class="updateProgress">
            <span class="updateProgressHijo">Cargando...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> 
</form>
</asp:Content>
