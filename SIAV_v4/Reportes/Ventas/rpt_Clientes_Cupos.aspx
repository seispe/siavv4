<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_Clientes_Cupos.aspx.cs" Inherits="SIAV_v4.Reportes.Ventas.rpt_Clientes_Cupos" %>
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
                <h1 class="page-header">REPORTE DE CUPOS DE CLIENTES</h1>
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
            <asp:TemplateField HeaderText="CLASE" SortExpression="CLASE">
                <ItemTemplate>
                    <asp:Label ID="lblClase" runat="server" Text='<%# Bind("CLASE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PROVINCIA" SortExpression="PROVINCIA">
                <ItemTemplate>
                    <asp:Label ID="lblProvincia" runat="server" Text='<%# Bind("PROVINCIA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COND_PAGO" SortExpression="COND_PAGO">
                <ItemTemplate>
                    <asp:Label ID="lblCondPago" runat="server" Text='<%# Bind("COND_PAGO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TIPO" SortExpression="TIPO">
                <ItemTemplate>
                    <asp:Label ID="lblTipo" runat="server" Text='<%# Bind("TIPO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CUPO" SortExpression="CUPO">
                <ItemTemplate>
                    <asp:Label ID="lblCupo" runat="server" Text='<%# Bind("CUPO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NIVEL PRECIO" SortExpression="NIVEL_PRECIO">
                <ItemTemplate>
                    <asp:Label ID="lblNivelPrecio" runat="server" Text='<%# Bind("NIVEL_PRECIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="INACTIVO" SortExpression="INACTIVO">
                <ItemTemplate>
                    <asp:Label ID="lblInactivo" runat="server" Text='<%# Bind("INACTIVO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SUSPENDIDO" SortExpression="SUSPENDIDO">
                <ItemTemplate>
                    <asp:Label ID="lblSuspendido" runat="server" Text='<%# Bind("SUSPENDIDO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AÑO PASADO" SortExpression="Neto_Año_Pasado">
                <ItemTemplate>
                    <asp:Label ID="lblAñoPasado" runat="server" Text='<%# Bind("Neto_Año_Pasado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Neto_Año_Actual" SortExpression="Neto_Año_Actual">
                <ItemTemplate>
                    <asp:Label ID="lblAñoActual" runat="server" Text='<%# Bind("Neto_Año_Actual") %>'></asp:Label>
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
