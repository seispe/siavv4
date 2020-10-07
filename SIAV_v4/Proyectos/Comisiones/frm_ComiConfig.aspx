<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_ComiConfig.aspx.cs" Inherits="SIAV_v4.Proyectos.Comisiones.frm_ComiConfig" %>
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
                <h1 class="page-header">Configuracion de Comisiones</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvConfig" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="idConfig" forecolor="#333333"
        gridlines="None"
        allowpaging="True" pagesize="10" 
        AllowSorting="True" OnRowCommand="gvConfig_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:TemplateField HeaderText="idConfig" SortExpression="idConfig">
                <ItemTemplate>
                    <asp:Label ID="lblidConfig" runat="server" Text='<%# Bind("idConfig") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Config" SortExpression="Config">
                <ItemTemplate>
                    <asp:Label ID="lblConfig" runat="server" Text='<%# Bind("Config") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Porcentaje" SortExpression="porcentaje">
                <ItemTemplate>
                    <asp:Label ID="lblporcentaje" runat="server" Text='<%# Bind("porcentaje") %>'></asp:Label>
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
<%--Modal Del Eliminar--%>
<div id="deleteModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                <h3 id="delModalLabel">Editar Registro de Configuracion</h3>
                <asp:HiddenField ID="hfCodigoPrincipal" runat="server" />
            </div>
            <asp:UpdatePanel id="upDel" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                    <label class="control-label" for="inputSuccess">ID</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtid" runat="server" Text='' CssClass="form-control" ReadOnly="true"></asp:Textbox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                <label class="control-label" for="inputWarning">Configuracion</label>
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                <asp:Textbox ID="txtConfiguracion" runat="server" Text='' CssClass="form-control" ReadOnly="true"></asp:Textbox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                <label class="control-label" for="inputError">Porcentaje</label>
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                <asp:Textbox ID="txtPorcentaje" runat="server" Text='' CssClass="form-control"></asp:Textbox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" CausesValidation="false" OnClick="btnActualizar_Click"/>
                        <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnActualizar" EventName="Click"/>
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
