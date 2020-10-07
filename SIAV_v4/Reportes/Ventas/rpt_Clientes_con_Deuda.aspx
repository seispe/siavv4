<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_Clientes_con_Deuda.aspx.cs" Inherits="SIAV_v4.Reportes.Ventas.rpt_Clientes_con_Deuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Exportar--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <%--<a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>              --%>
                <h1 class="page-header">REPORTE DE CLIENTES DE CONTADO CON DEUDA</h1>
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
        <asp:gridview id="gvDatos" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="RUC" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvDatos_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="TIPO" SortExpression="TIPO">
                <ItemTemplate>
                    <asp:Label ID="lblTipo" runat="server" Text='<%# Bind("TIPO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RUC" SortExpression="RUC">
                <ItemTemplate>
                    <asp:Label ID="lblRuc" runat="server" Text='<%# Bind("RUC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NOMBRE CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NOMBRE COMERCIAL" SortExpression="NOM_COMERCIAL">
                <ItemTemplate>
                    <asp:Label ID="lblNombreComercial" runat="server" Text='<%# Bind("NOM_COMERCIAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="COND PAGO TARJ." SortExpression="COND_PAGO_TARJETA">
                <ItemTemplate>
                    <asp:Label ID="lblCondPagoTar" runat="server" Text='<%# Bind("COND_PAGO_TARJETA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COND PAGO TRX." SortExpression="COND_PAGO_TRANSACCION">
                <ItemTemplate>
                    <asp:Label ID="lblCondPagoTrx" runat="server" Text='<%# Bind("COND_PAGO_TRANSACCION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NUM DCTO." SortExpression="DOCUMENTO">
                <ItemTemplate>
                    <asp:Label ID="lblDocumento" runat="server" Text='<%# Bind("DOCUMENTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA DOC." SortExpression="FECHA_DOC">
                <ItemTemplate>
                    <asp:Label ID="lblFechaDocumento" runat="server" Text='<%# Bind("FECHA_DOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COD VEND TAR" SortExpression="COD_VEND_TAR">
                <ItemTemplate>
                    <asp:Label ID="lblCodVendTarj" runat="server" Text='<%# Bind("COD_VEND_TAR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COD VEND TRX" SortExpression="COD_VEND_TRX">
                <ItemTemplate>
                    <asp:Label ID="lblCodVendTrx" runat="server" Text='<%# Bind("COD_VEND_TRX") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MONTO TOTAL" SortExpression="MONTO_TOTAL">
                <ItemTemplate>
                    <asp:Label ID="lblMontoTotal" runat="server" Text='<%# Bind("MONTO_TOTAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MONTO_PENDIENTE" SortExpression="MONTO_PENDIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblMontoPendiente" runat="server" Text='<%# Bind("MONTO_PENDIENTE") %>'></asp:Label>
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
            <span class="updateProgressHijo">Extrayendo información...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> 
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
</asp:Content>
