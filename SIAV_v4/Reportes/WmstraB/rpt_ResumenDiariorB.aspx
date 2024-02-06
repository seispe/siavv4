<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_ResumenDiariorB.aspx.cs" Inherits="SIAV_v4.Reportes.WmstraB.rpt_ResumenDiariorB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Resumen Diario de Pedidos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>FECHAS:</h5>
            </label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="150px" placeholder="Desde"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="150px" placeholder="Hasta"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
            <%-- <div class="col-sm-2">
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success"  />
        </div>--%>
        </div>
        <br />
        <br />
        <%-- GRID DE RESUMEN DIARIO DE PEDIDOS --%>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="False" CellPadding="8"
                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="150">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Desde" SortExpression="Desde">
                            <ItemTemplate>
                                <asp:Label ID="lblfdesde" runat="server" Text='<%# Bind("fdesde") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasta" SortExpression="Hasta">
                            <ItemTemplate>
                                <asp:Label ID="lblfhasta" runat="server" Text='<%# Bind("fhasta") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedidos" SortExpression="Pedidos">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidosdeldia" runat="server" Text='<%# Bind("PEDIDOSDELDIA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Consolidados" SortExpression="Consolidados">
                            <ItemTemplate>
                                <asp:Label ID="lblconsolidados" runat="server" Text='<%# Bind("CONSOLIDADOS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedidos Consolidados" SortExpression="Pedidos Consolidados">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidosconsolidados" runat="server" Text='<%# Bind("PEDIDOSCONSOLIDADOS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Por Consolidar" SortExpression="Pedidos por Consolidar">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidosxconsolidar" runat="server" Text='<%# Bind("PEDIDOSXCONSOLIDAR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conso Pendientes" SortExpression="Consolidados Pendientes" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblconsolidadospendientes" runat="server" Text='<%# Bind("CONSOLIDADOSPENDIENTES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conso Picking" SortExpression="Consolidados en Picking" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblconsolidadosenpicking" runat="server" Text='<%# Bind("CONSOLIDADOSENPICKING") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conso Armado" SortExpression="Consolidados en Armado" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblconsolidadosenarmado" runat="server" Text='<%# Bind("CONSOLIDADOSENARMADO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedidos Pendientes" SortExpression="Pedidos Pendientes">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidospendientes" runat="server" Text='<%# Bind("PEDIDOSPENDIENTES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedidos en Picking" SortExpression="Pedidos en Picking">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidosenpicking" runat="server" Text='<%# Bind("PEDIDOSENPICKING") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedidos en Armado" SortExpression="Pedidos en Armado">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidosenarmado" runat="server" Text='<%# Bind("PEDIDOSENARMADO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedidos en Transito" SortExpression="Pedidos en Transito">
                            <ItemTemplate>
                                <asp:Label ID="lblpedidosentransitobahias" runat="server" Text='<%# Bind("PEDIDOSENTRANSITOBAHIAS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="btnPendientes" runat="server" Text="Pendientes" CssClass="btn btn-primary" OnClick="btnPendientes_Click" />
        <asp:Button ID="btnPicking" runat="server" Text="Picking" CssClass="btn btn-warning" OnClick="btnPicking_Click" />
        <asp:Button ID="btnArmado" runat="server" Text="Armado" CssClass="btn btn-danger" OnClick="btnArmado_Click" />
        <asp:Button ID="btnTransito" runat="server" Text="Transito" CssClass="btn btn-success" OnClick="btnTransito_Click" />
        <br />
        <br />
        <%-- GRID DETALLE PEDIDOS --%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvResumenxProceso" runat="server" AutoGenerateColumns="False" CellPadding="8"
                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="150">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo" SortExpression="Tipo">
                            <ItemTemplate>
                                <asp:Label ID="lbltipo" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad" SortExpression="Ciudad">
                            <ItemTemplate>
                                <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Consolidado" SortExpression="Consolidado">
                            <ItemTemplate>
                                <asp:Label ID="lblconsolidado" runat="server" Text='<%# Bind("consolidado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                            <ItemTemplate>
                                <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblestado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtfdesde.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;

            var dp = $("#<%=txtfhasta.ClientID%>");
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

