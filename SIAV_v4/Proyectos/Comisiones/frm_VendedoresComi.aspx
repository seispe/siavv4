<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_VendedoresComi.aspx.cs" Inherits="SIAV_v4.Proyectos.Comisiones.frm_VendedoresComi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <h1 class="page-header">Configurar Vededores</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<%--Buscar--%>
<div class="buscar">
  <div class="form-group">
    <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Vendedor:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
             <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <ContentTemplate>  
                    <asp:DropDownList ID="ddlVendedores" class="form-control" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVendedores_SelectedIndexChanged"></asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="ddlVendedores" EventName="SelectedIndexChanged"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>    
  </div> 
</div> 
<br /><br />
<asp:UpdatePanel id="upBtnNieto" runat="server">
    <ContentTemplate>
        <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/Recursos/images/add.png" CssClass="btn btn-success" OnClick="btnNuevo_Click" CausesValidation="false"/>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvConfig" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="idPago" forecolor="#333333"
        gridlines="None"
        allowpaging="True" pagesize="20" 
        AllowSorting="True" OnRowCommand="gvConfig_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:TemplateField HeaderText="idPago" SortExpression="idPago" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblidPago" runat="server" Text='<%# Bind("idPago") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="idVendedor" SortExpression="idVendedor" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mes" SortExpression="mes">
                <ItemTemplate>
                    <asp:Label ID="lblmes" runat="server" Text='<%# Bind("mes") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Año" SortExpression="año">
                <ItemTemplate>
                    <asp:Label ID="lblaño" runat="server" Text='<%# Bind("año") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cupo" SortExpression="cupo">
                <ItemTemplate>
                    <asp:Label ID="lblcupo" runat="server" Text='<%# Bind("cupo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Neto" SortExpression="neto">
                <ItemTemplate>
                    <asp:Label ID="lblneto" runat="server" Text='<%# Bind("neto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Porcentaje Comi" SortExpression="porceComi">
                <ItemTemplate>
                    <asp:Label ID="lblporceComi" runat="server" Text='<%# Bind("porceComi") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Porce a Comisionar" SortExpression="porceComisionar">
                <ItemTemplate>
                    <asp:Label ID="lblporceComisionar" runat="server" Text='<%# Bind("porceComisionar") %>'></asp:Label>
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
<!-- Modal Nuevo -->
<div id="addModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel7" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="addModalLabel3">Nuevo Registro</h3>
                        <asp:HiddenField ID="hfNuevo" runat="server" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Mes</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:DropDownList id="ddlNewMes" AutoPostBack="false"  runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0">Seleccione un mes</asp:ListItem>
                                    <asp:ListItem Value="ENERO"> ENERO </asp:ListItem>
                                    <asp:ListItem Value="FEBRERO"> FEBRERO </asp:ListItem>
                                    <asp:ListItem Value="MARZO"> MARZO </asp:ListItem>
                                    <asp:ListItem Value="ABRIL"> ABRIL </asp:ListItem>
                                    <asp:ListItem Value="MAYO"> MAYO </asp:ListItem>
                                    <asp:ListItem Value="JUNIO"> JUNIO </asp:ListItem>
                                    <asp:ListItem Value="JULIO"> JULIO </asp:ListItem>
                                    <asp:ListItem Value="AGOSTO"> AGOSTO </asp:ListItem>
                                    <asp:ListItem Value="SEPTIEMBRE"> SEPTIEMBRE </asp:ListItem>
                                    <asp:ListItem Value="OCTUBRE"> OCTUBRE </asp:ListItem>
                                    <asp:ListItem Value="NOVIEMBRE"> NOVIEMBRE </asp:ListItem>
                                    <asp:ListItem Value="DICIEMBRE"> DICIEMBRE </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Año</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:DropDownList id="ddlNewAño" AutoPostBack="false" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0">Seleccione el Año</asp:ListItem>
                                    <asp:ListItem Value="2016"> 2016 </asp:ListItem>
                                    <asp:ListItem Value="2017"> 2017 </asp:ListItem>
                                    <asp:ListItem Value="2018"> 2018 </asp:ListItem>
                                    <asp:ListItem Value="2019"> 2019 </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Cupo</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewCupo" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewCupo" runat="server" ValidationGroup="addModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNewCupo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewCupo" runat="server" ValidationGroup="addModalN3" ForeColor="Red" Text="Solo Numeros" ToolTip="Solo Letras" ControlToValidate="txtNewCupo" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Venta Neta</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewNeto" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewNeto" runat="server" ValidationGroup="addModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNewNeto"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewNeto" runat="server" ValidationGroup="addModalN3" ForeColor="Red" Text="Solo Numeros" ToolTip="Solo Letras" ControlToValidate="txtNewNeto" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Porce Comision</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtNewComision" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="rfvtxtNewComision" runat="server" ValidationGroup="addModalN3" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtNewComision"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtNewComision" runat="server" ValidationGroup="addModalN3" ForeColor="Red" Text="Solo Numeros" ToolTip="Solo Letras" ControlToValidate="txtNewComision" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnGuardarNuevo_Click"  ValidationGroup="addModalN3"/>
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
<!-- Modal Editar -->
<div id="editModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                        <h3 id="editTitulo">Editar Registro</h3>
                        <asp:HiddenField ID="hfCodigoEditar" runat="server" />
                    </div>
                    <div class="modal-body">
                         <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Vendedor</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEditVendedor" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:Textbox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Mes</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEditmes" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:Textbox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Año</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEditAño" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:Textbox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Cupo</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEditCupo" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtEditCupo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo Numeros" ToolTip="Solo Letras" ControlToValidate="txtEditCupo" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Venta Neta</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEditNeto" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtEditNeto"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo Numeros" ToolTip="Solo Letras" ControlToValidate="txtEditNeto" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">Porce Comision</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtEditComision" runat="server" Text="" CssClass="form-control"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="addModalN2" Text="Obligatorio" ForeColor="Red"  ToolTip="Ingrese El Icono" ControlToValidate="txtEditComision"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="addModalN2" ForeColor="Red" Text="Solo Numeros" ToolTip="Solo Letras" ControlToValidate="txtEditComision" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnGuardarEdicion" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnGuardarEdicion_Click"  ValidationGroup="addModalN2"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardarEdicion" EventName="Click"/>
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
