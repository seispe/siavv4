<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_DevxMotivos.aspx.cs" Inherits="SIAV_v4.Reportes.Devoluciones.rpt_DevxMotivos" %>
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
                <h1 class="page-header">Reporte de Devoluciones por Estados</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Desde:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaDesde" runat="server" Enabled="True" class="form-control" placeholder="Fecha Desde"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Hasta:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaHasta" runat="server" Enabled="True" class="form-control" placeholder="Fecha Hasta"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">NumDevolucion:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtNumDevol" runat="server" Enabled="True" class="form-control" placeholder="NumDevolucion"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Cliente / Razon Social:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtCliente" runat="server" class="form-control" placeholder="Cliente / Razon Social"></asp:TextBox>
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
<%--Exportar--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <br />
        <asp:Button ID="btnExport" runat="server" Text="Generar A Excel" Cssclass="btn btn-info" OnClick = "ExportToExcel" CausesValidation="false"/>    
    </div>
</div>
<%--Grid--%>
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvDev" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="IdDevolucion" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvDev_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="IdDevolucion" SortExpression="IdDevolucion">
                <ItemTemplate>
                    <asp:Label ID="lblIdDevolucion" runat="server" Text='<%# Bind("IdDevolucion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
     <%--       <asp:TemplateField HeaderText="NumWeb" SortExpression="NumWeb">
                <ItemTemplate>
                    <asp:Label ID="lblNumWeb" runat="server" Text='<%# Bind("NumWeb") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="FechaDevolucion" SortExpression="FechaDevolucion">
                <ItemTemplate>
                    <asp:Label ID="lblFechaDevolucion" runat="server" Text='<%# Bind("FechaDevolucion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NumFactura" SortExpression="NumFactura">
                <ItemTemplate>
                    <asp:Label ID="lblNumFactura" runat="server" Text='<%# Bind("NumFactura") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
       <%--     <asp:TemplateField HeaderText="NumPedido" SortExpression="NumPedido">
                <ItemTemplate>
                    <asp:Label ID="lblNumPedido" runat="server" Text='<%# Bind("NumPedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="FechaFactura" SortExpression="FechaFactura">
                <ItemTemplate>
                    <asp:Label ID="lblFechaFactura" runat="server" Text='<%# Bind("FechaFactura") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ruc" SortExpression="Ruc">
                <ItemTemplate>
                    <asp:Label ID="lblRuc" runat="server" Text='<%# Bind("Ruc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
      <%--      <asp:TemplateField HeaderText="NombreCliente" SortExpression="NombreCliente">
                <ItemTemplate>
                    <asp:Label ID="lblNombreCliente" runat="server" Text='<%# Bind("NombreCliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="RazonSocial" SortExpression="RazonSocial">
                <ItemTemplate>
                    <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("RazonSocial") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
   <%--         <asp:TemplateField HeaderText="bultos" SortExpression="bultos">
                <ItemTemplate>
                    <asp:Label ID="lblbultos" runat="server" Text='<%# Bind("bultos") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="idVendedor" SortExpression="idVendedor">
                <ItemTemplate>
                    <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="observacion" SortExpression="observacion">
                <ItemTemplate>
                    <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Origen C/V" SortExpression="OrigenCV">
                <ItemTemplate>
                    <asp:Label ID="lblorigen" runat="server" Text='<%# Bind("origen") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Mot Eliminacion" SortExpression="Mot Eliminacion">
                <ItemTemplate>
                    <asp:Label ID="lblobservacioneliminacion" runat="server" Text='<%# Bind("observacioneliminacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Articulo" SortExpression="Articulo">
                <ItemTemplate>
                    <asp:Label ID="lblArticulo" runat="server" Text='<%# Bind("Articulo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
      <%--      <asp:TemplateField HeaderText="Void" SortExpression="Void">
                <ItemTemplate>
                    <asp:Label ID="lblVoid" runat="server" Text='<%# Bind("Void") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
             <asp:TemplateField HeaderText="Cod Ant" SortExpression="Cod Ant">
                <ItemTemplate>
                    <asp:Label ID="lblcodigoantiguo" runat="server" Text='<%# Bind("codigoantiguo") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="cantidadReal" SortExpression="cantidadReal">
                <ItemTemplate>
                    <asp:Label ID="lblcantidadReal" runat="server" Text='<%# Bind("cantidadReal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CostoUnitario" SortExpression="CostoUnitario">
                <ItemTemplate>
                    <asp:Label ID="lblCostoUnitario" runat="server" Text='<%# Bind("CostoUnitario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PrecioUnitario" SortExpression="PrecioUnitario">
                <ItemTemplate>
                    <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Bind("PrecioUnitario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descuento" SortExpression="Descuento">
                <ItemTemplate>
                    <asp:Label ID="lblDescuento" runat="server" Text='<%# Bind("Descuento") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MotivoOriginal" SortExpression="MotivoOriginal">
                <ItemTemplate>
                    <asp:Label ID="lblMotivoOriginal" runat="server" Text='<%# Bind("MotivoOriginal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="MotivoReal" SortExpression="MotivoReal">
                <ItemTemplate>
                    <asp:Label ID="lblMotivoReal" runat="server" Text='<%# Bind("MotivoReal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Placa" SortExpression="Placa">
                <ItemTemplate>
                    <asp:Label ID="lblplaca" runat="server" Text='<%# Bind("Placa") %>'></asp:Label>
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
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtFechaDesde.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;

            var dp = $("#<%=txtFechaHasta.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
        });
    </script>
</asp:Content>
