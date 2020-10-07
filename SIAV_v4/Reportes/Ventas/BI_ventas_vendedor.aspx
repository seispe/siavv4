<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="BI_ventas_vendedor.aspx.cs" Inherits="SIAV_v4.Reportes.Ventas.BI_ventas_vendedor" %>
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
                <h1 class="page-header">REPORTE DE VENTAS POR VENDEDOR (LÍNEA)</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Tipo Consulta:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <ContentTemplate> 
                <asp:DropDownList ID="ddlTipoConsulta" runat="server" AutoPostBack="true" Enabled="True" class="form-control" OnTextChanged="ddlTipoConsulta_TextChanged">
                <asp:ListItem Value="1">Diario</asp:ListItem>
                <asp:ListItem Value="2">Semanal</asp:ListItem>
                <asp:ListItem Value="3">Mensual</asp:ListItem>
                </asp:DropDownList>
                </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        </div>

        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFecha" runat="server" Enabled="True" class="form-control" placeholder="Elija una fecha"></asp:TextBox>
        </div>

        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Fin:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
               <asp:TextBox ID="txtFecha2" runat="server" Enabled="True" class="form-control" placeholder="Elija una fecha"></asp:TextBox>
        </div>

    </div>
      <div class="row">
          
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Cod. Vendedor:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtCodVendedor" runat="server" Enabled="True" class="form-control" placeholder="Ejemplo: 01"></asp:TextBox>
        </div>

        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Linea:</label>

          <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
                    <asp:DropDownList ID="ddlLineas" runat="server" AutoPostBack="true"  Enabled="True" class="form-control" placeholder="TODAS">
                    </asp:DropDownList>
                </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        
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
        <asp:gridview id="gvDatos" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="VEN_Codigo" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvDatos_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="COD_VEND" SortExpression="VEN_Codigo">
                <ItemTemplate>
                    <asp:Label ID="lblCodigoVendedor" runat="server" Text='<%# Bind("VEN_Codigo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NOMBRE DE VENDEDOR" SortExpression="VEN_Nombre">
                <ItemTemplate>
                    <asp:Label ID="lblNombreVendedor" runat="server" Text='<%# Bind("VEN_Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LÍNEA" SortExpression="Linea">
                <ItemTemplate>
                    <asp:Label ID="lbllinea" runat="server" Text='<%# Bind("Linea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VENTA NETA" SortExpression="Venta_Neta">
                <ItemTemplate>
                    <asp:Label ID="lblVentaNeta" runat="server" Text='<%# Bind("Venta_Neta") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="ESTADO" SortExpression="Estado_Vendedor">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Estado_Vendedor") %>'></asp:Label>
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
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%= txtFecha.ClientID%>");
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

    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%= txtFecha2.ClientID%>");
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
