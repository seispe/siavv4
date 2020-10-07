<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_EstadoCuenta.aspx.cs" Inherits="SIAV_v4.Reportes.Cobranzas.rpt_EstadoCuenta" %>
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
                <h1 class="page-header">Reporte de Estado de Cuenta</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Cliente / Razon Social:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtCliente" runat="server" class="form-control" placeholder="Cliente / Razon Social"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Vendedor:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtVendedor" runat="server" class="form-control" placeholder="Vendedor"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Ciudad:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtCiudad" runat="server" class="form-control" placeholder="Ciudad"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Emision:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaEmision" runat="server" class="form-control" placeholder="Fecha Corte Emision"></asp:TextBox>
        </div>
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Vencimiento:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaVencimiento" runat="server" class="form-control" placeholder="Fecha Corte Vencimiento"></asp:TextBox>
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
        <asp:gridview id="gvEstadoCuenta" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="FACTURA" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvEstadoCuenta_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="RUC" SortExpression="RUC">
                <ItemTemplate>
                    <asp:Label ID="lblRUC" runat="server" Text='<%# Bind("RUC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblCLIENTE" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NOM_COMERCIAL" SortExpression="NOM_COMERCIAL">
                <ItemTemplate>
                    <asp:Label ID="lblNOM_COMERCIAL" runat="server" Text='<%# Bind("NOM_COMERCIAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CIUDAD" SortExpression="CIUDAD">
                <ItemTemplate>
                    <asp:Label ID="lblCIUDAD" runat="server" Text='<%# Bind("CIUDAD") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="TIPO" SortExpression="TIPO">
                <ItemTemplate>
                    <asp:Label ID="lblTIPO" runat="server" Text='<%# Bind("TIPO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VEN_CODIGO_TAR" SortExpression="VEN_CODIGO_TAR">
                <ItemTemplate>
                    <asp:Label ID="lblVEN_CODIGO_TAR" runat="server" Text='<%# Bind("VEN_CODIGO_TAR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DIRECCION" SortExpression="DIRECCION">
                <ItemTemplate>
                    <asp:Label ID="lblDIRECCION" runat="server" Text='<%# Bind("DIRECCION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TELEFONO" SortExpression="TELEFONO">
                <ItemTemplate>
                    <asp:Label ID="lblTELEFONO" runat="server" Text='<%# Bind("TELEFONO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="FACTURA" SortExpression="FACTURA">
                <ItemTemplate>
                    <asp:Label ID="lblFACTURA" runat="server" Text='<%# Bind("FACTURA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="F_EMISION" SortExpression="F_EMISION">
                <ItemTemplate>
                    <asp:Label ID="lblF_EMISION" runat="server" Text='<%# Bind("F_EMISION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="F_VENCIMIENTO" SortExpression="F_VENCIMIENTO">
                <ItemTemplate>
                    <asp:Label ID="lblF_VENCIMIENTO" runat="server" Text='<%# Bind("F_VENCIMIENTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VEN_CODIGO_DOC" SortExpression="VEN_CODIGO_DOC">
                <ItemTemplate>
                    <asp:Label ID="lblVEN_CODIGO_DOC" runat="server" Text='<%# Bind("VEN_CODIGO_DOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COND_PAGO" SortExpression="COND_PAGO">
                <ItemTemplate>
                    <asp:Label ID="lblCOND_PAGO" runat="server" Text='<%# Bind("COND_PAGO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MONTO_DOC" SortExpression="MONTO_DOC">
                <ItemTemplate>
                    <asp:Label ID="lblMONTO_DOC" runat="server" Text='<%# Bind("MONTO_DOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PENDIENTE" SortExpression="PENDIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblPENDIENTE" runat="server" Text='<%# Bind("PENDIENTE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DIAS_VENCIDO" SortExpression="DIAS_VENCIDO">
                <ItemTemplate>
                    <asp:Label ID="lblDIAS_VENCIDO" runat="server" Text='<%# Bind("DIAS_VENCIDO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ANULADO" SortExpression="ANULADO">
                <ItemTemplate>
                    <asp:Label ID="lblANULADO" runat="server" Text='<%# Bind("ANULADO") %>'></asp:Label>
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
            var dp = $("#<%=txtFechaEmision.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
            var dp = $("#<%=txtFechaVencimiento.ClientID%>");
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

