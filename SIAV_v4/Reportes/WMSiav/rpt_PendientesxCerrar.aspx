<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_PendientesxCerrar.aspx.cs" Inherits="SIAV_v4.Reportes.WMSiav.rpt_PendientesxCerrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Pedidos pendientes por Revisar</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <br />
        <div class="col-sm-2">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass=" btn btn-primary" OnClick="btnActualizar_Click" />
        </div>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvPendientes" runat="server" AutoGenerateColumns="False" CellPadding="8"
                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="150">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Ruc" SortExpression="Ruc">
                            <ItemTemplate>
                                <asp:Label ID="lblruc" runat="server" Text='<%# Bind("ruc_cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("soc_cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Solicitado" SortExpression="Solicitado">
                            <ItemTemplate>
                                <asp:Label ID="lblsolicitado" runat="server" Text='<%# Bind("cant_solicitada") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Procesado" SortExpression="Procesado">
                            <ItemTemplate>
                                <asp:Label ID="lblprocesado" runat="server" Text='<%# Bind("can_procesada") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pendiente" SortExpression="Pendiente">
                            <ItemTemplate>
                                <asp:Label ID="lblpendiente" runat="server" Text='<%# Bind("pendiente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Armado" SortExpression="Armado">
                            <ItemTemplate>
                                <asp:Label ID="lblarmado" runat="server" Text='<%# Bind("can_armada") %>'></asp:Label>
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
