<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_UsuarioVentana.aspx.cs" Inherits="SIAV_v4.Seguridad.frm_UsuarioVentana" %>
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
                <h1 class="page-header">Administrar Usuario Ventana</h1>
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
                cssclass="grid" datakeynames="id" forecolor="#333333"
                gridlines="None" OnRowCommand="gvNivel1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
                    </asp:ButtonField>
                    <asp:TemplateField HeaderText="ID" SortExpression="id">
                        <ItemTemplate>
                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario" >
                        <ItemTemplate>
                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Empresa" SortExpression="empresa">
                        <ItemTemplate>
                            <asp:Label ID="lblempresa" runat="server" Text='<%# Bind("empresa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Proyecto" SortExpression="proyecto">
                        <ItemTemplate>
                            <asp:Label ID="lblproyecto" runat="server" Text='<%# Bind("proyecto") %>'></asp:Label>  
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ventana" SortExpression="ventana">
                        <ItemTemplate>
                            <asp:Label ID="lblventana" runat="server" Text='<%# Bind("ventana") %>'></asp:Label>
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
                                    <label class="control-label" for="inputSuccess">Usuario</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtUsuario" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtUsuario" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtUsuario" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtUsuario" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                <label class="control-label" for="inputSuccess">Empresa</label>
                            </div>                            
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEmpresa" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtEmpresa" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtEmpresa"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtEmpresa" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtEmpresa" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Proyecto</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtProyecto" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtProyecto" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtProyecto"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtProyecto" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtProyecto" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Ventana</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtVentana" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtVentana" runat="server" ValidationGroup="editModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la descripcion" ControlToValidate="txtVentana"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtVentana" runat="server" ValidationGroup="editModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Letras" ControlToValidate="txtVentana" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
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
                                    <label class="control-label" for="inputSuccess">Usuario</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewUsuario" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewUsuario" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese el Usuario" ControlToValidate="txtNewUsuario"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewUsuario" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Numeros" ControlToValidate="txtNewUsuario" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Empresa</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewEmpresa" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewEmpresa" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese el Usuario" ControlToValidate="txtNewEmpresa"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewEmpresa" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Numeros" ControlToValidate="txtNewEmpresa" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Proyecto</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewProyecto" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewProyecto" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese el Proyecto" ControlToValidate="txtNewProyecto"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewProyecto" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras" ToolTip="Solo Numeros" ControlToValidate="txtNewProyecto" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Url Ventana</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewUrl" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewUrl" runat="server" ValidationGroup="addModalN1" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese la Url" ControlToValidate="txtNewUrl"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewUrl" runat="server" ValidationGroup="addModalN1" ForeColor="Red" Text="Solo Letras y Números" ToolTip="Solo Letras y Números" ControlToValidate="txtNewUrl" ValidationExpression="^[a-zA-Z0-9?=#/._]*$"></asp:RegularExpressionValidator>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
