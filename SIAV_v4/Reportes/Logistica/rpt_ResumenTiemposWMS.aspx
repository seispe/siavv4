<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_ResumenTiemposWMS.aspx.cs" Inherits="SIAV_v4.Reportes.Logistica.rpt_ResumenTiemposWMS" %>
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
                <h1 class="page-header">Reporte Resumen Tiempos en WMS</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <br />
        <%--Buscar--%>
<div class="buscar">
  <div class="form-group">
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHA INICIO:</h5></label>  
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaInicio" runat="server" Enabled="True" class="form-control" placeholder="Fecha Inicio"></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHA FIN:</h5></label>  
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="True" class="form-control" placeholder="Fecha Final"></asp:TextBox>
        </div>
         <div class="col-sm-2">
             <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
             <div class="col-sm-2">
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
        </div>
    </div>
  </div> 
</div> 
<br />
    <br />
    <%-- GRID DE MAESTRO DE PEDIDOS CABECERA --%>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvResumenWMS" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
                    AllowSorting="True" HeaderStyle-BackColor="green"
                    PageSize="500" OnPageIndexChanging="gvResumenWMS_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RUC" SortExpression="RUC">
                            <ItemTemplate>
                                <asp:Label ID="lblruc_cliente" runat="server" Text='<%# Bind("ruc_cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                            <ItemTemplate>
                                <asp:Label ID="lblnom_cliente" runat="server" Text='<%# Bind("nom_cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PRIORIDAD" SortExpression="PRIORIDAD">
                            <ItemTemplate>
                                <asp:Label ID="lblprioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CIUDAD" SortExpression="CIUDAD">
                            <ItemTemplate>
                                <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FECHA" SortExpression="FECHA">
                            <ItemTemplate>
                                <asp:Label ID="lblf_pedido" runat="server" Text='<%# Bind("f_pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TIEMPO IAV" SortExpression="TIEMPO IAV">
                            <ItemTemplate>
                                <asp:Label ID="lbltiempoIav" runat="server" Text='<%# Bind("tiempoIav") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SEMÁFORO IAV" SortExpression="SEMÁFORO IAV">
                            <ItemTemplate>
                                <asp:Label ID="lblSemaforoIav" runat="server" Text='<%# Bind("SemaforoIav") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TIEMPO LAAR" SortExpression="TIEMPO LAAR">
                            <ItemTemplate>
                                <asp:Label ID="lblTiempoLaar" runat="server" Text='<%# Bind("TiempoLaar") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SEMÁFORO LAAR" SortExpression="SEMÁFORO LAAR">
                            <ItemTemplate>
                                <asp:Label ID="lblSemaforoLaar" runat="server" Text='<%# Bind("SemaforoLaar") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--<asp:BoundField DataField="SemaforoLaar" HeaderText="SEMÁFORO LAAR" Visible="true" />--%>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtFechaInicio.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
            var dp = $("#<%=txtFechaFinal.ClientID%>");
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
