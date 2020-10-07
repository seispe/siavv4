<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_ListaPreciosNOAsociados.aspx.cs" Inherits="SIAV_v4.Reportes.ListaPrecios.rpt_ListaPreciosNOAsociados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
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
                <h1 class="page-header">Lista de Precios</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Proveedor:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtProveedor" runat="server" class="form-control" placeholder="Proveedor"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Codigo:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeholder="Codigo"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Descripcion:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" placeholder="Descripcion"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Marca:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtMarca" runat="server" class="form-control" placeholder="Marca"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <br />
            <asp:UpdatePanel id="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:Button ID="btnBuscar" runat="server" Text="Generar" Cssclass="btn btn-success" OnClick="btnBuscar_Click" CausesValidation="false"/>     
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
  </div> 
</div>  
<%--Grid--%>
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvListaPrecios" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="id" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvListaPrecios_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="Proveedor" SortExpression="Proveedor">
                <ItemTemplate>
                    <asp:Label ID="lblProveedor" runat="server" Text='<%# Bind("Proveedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="descripcion" SortExpression="descripcion">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="marca" SortExpression="marca">
                <ItemTemplate>
                    <asp:Label ID="lblmarca" runat="server" Text='<%# Bind("marca") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Stock" SortExpression="Stock">
                <ItemTemplate>
                    <asp:Label ID="lblStock" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="precio" SortExpression="precio">
                <ItemTemplate>
                    <asp:Label ID="lblprecio" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
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