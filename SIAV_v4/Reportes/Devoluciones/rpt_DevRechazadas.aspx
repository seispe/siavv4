﻿<%@ Page Language="C#"  MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_DevRechazadas.aspx.cs" Inherits="SIAV_v4.Reportes.Devoluciones.rpt_DevRechazadas" %>
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
                <h1 class="page-header">Reporte de Devoluciones Rechazadas</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Devolucion:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtNumDevol" runat="server" Enabled="True" class="form-control" placeholder="NumDevolucion"></asp:TextBox>
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
        <asp:Button ID="btnExport" runat="server" Text="Generar A Excel" Cssclass="btn btn-info" OnClick="btnExport_Click" CausesValidation="false"/>    
    </div>
</div>
<%--Grid--%>
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvDev" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="IdDevolucion" forecolor="#333333"
        gridlines="None" OnRowCommand="gvDev_RowCommand" 
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="Rechazar" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/mail.png" runat="server" OnClientClick="return confirm('Desea rechazar definitivamente')" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IdDevolucion" SortExpression="IdDevolucion">
                <ItemTemplate>
                    <asp:Label ID="lblIdDevolucion" runat="server" Text='<%# Bind("iddevolucion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ruc" SortExpression="Ruc">
                <ItemTemplate>
                    <asp:Label ID="lblidcliente" runat="server" Text='<%# Bind("idcliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                <ItemTemplate>
                    <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vendedor" SortExpression="Vendedor">
                <ItemTemplate>
                    <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblestado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observacion" SortExpression="Observacion">
                <ItemTemplate>
                    <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Dev" SortExpression="Fecha Dev">
                <ItemTemplate>
                    <asp:Label ID="lblfechadev" runat="server" Text='<%# Bind("fechadev") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                <ItemTemplate>
                    <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Fecha Factura" SortExpression="Fecha Factura">
                <ItemTemplate>
                    <asp:Label ID="lblfechafactura" runat="server" Text='<%# Bind("fechafactura") %>'></asp:Label>
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

