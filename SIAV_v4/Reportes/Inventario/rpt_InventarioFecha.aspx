﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_InventarioFecha.aspx.cs" Inherits="SIAV_v4.Reportes.Inventario.rpt_InventarioFecha" %>
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
                <h1 class="page-header">Reporte Inventario a la Fecha</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Corte:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFecha" runat="server" Enabled="True" class="form-control" placeholder="Fecha Corte"></asp:TextBox>
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
        <asp:gridview id="gvCuentas" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="ITEM,BODEGA" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvCuentas_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="ITEM" SortExpression="ITEM">
                <ItemTemplate>
                    <asp:Label ID="lblITEM" runat="server" Text='<%# Bind("ITEM") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DESCRIPCION" SortExpression="DESCRIPCION">
                <ItemTemplate>
                    <asp:Label ID="lblDESCRIPCION" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CLASE" SortExpression="CLASE">
                <ItemTemplate>
                    <asp:Label ID="lblCLASE" runat="server" Text='<%# Bind("CLASE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BODEGA" SortExpression="BODEGA">
                <ItemTemplate>
                    <asp:Label ID="lblBODEGA" runat="server" Text='<%# Bind("BODEGA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="CANTIDAD_ACT" SortExpression="CANTIDAD_ACT">
                <ItemTemplate>
                    <asp:Label ID="lblCANTIDAD_ACT" runat="server" Text='<%# Bind("CANTIDAD_ACT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PROMEDIO_ACT" SortExpression="PROMEDIO_ACT">
                <ItemTemplate>
                    <asp:Label ID="lblPROMEDIO_ACT" runat="server" Text='<%# Bind("PROMEDIO_ACT") %>'></asp:Label> 				
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CANT_FECHA" SortExpression="CANT_FECHA">
                <ItemTemplate>
                    <asp:Label ID="lblCANT_FECHA" runat="server" Text='<%# Bind("CANT_FECHA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PROM_FECH" SortExpression="PROM_FECH">
                <ItemTemplate>
                    <asp:Label ID="lblPROM_FECH" runat="server" Text='<%# Bind("PROM_FECH") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="TOTAL" SortExpression="TOTAL">
                <ItemTemplate>
                    <asp:Label ID="lblTOTAL" runat="server" Text='<%# Bind("TOTAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA_COMPRA" SortExpression="FECHA_COMPRA">
                <ItemTemplate>
                    <asp:Label ID="lblFECHA_COMPRA" runat="server" Text='<%# Bind("FECHA_COMPRA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA_TRANSFER" SortExpression="FECHA_TRANSFER">
                <ItemTemplate>
                    <asp:Label ID="lblFECHA_TRANSFER" runat="server" Text='<%# Bind("FECHA_TRANSFER") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA_VENTA" SortExpression="FECHA_VENTA">
                <ItemTemplate>
                    <asp:Label ID="lblFECHA_VENTA" runat="server" Text='<%# Bind("FECHA_VENTA") %>'></asp:Label>
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
            var dp = $("#<%=txtFecha.ClientID%>");
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
