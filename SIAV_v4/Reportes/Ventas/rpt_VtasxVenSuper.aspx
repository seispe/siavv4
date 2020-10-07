<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_VtasxVenSuper.aspx.cs" Inherits="SIAV_v4.Reportes.Ventas.rpt_VtasxVenSuper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Reporte de Ventas por Vendedor y Supervisor</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- SELECCIONAR EL AÑO, EL MES, EL SUPERVISOR Y EL VENDEDOR --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>AÑO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlAnio" runat="server" CssClass="form-control" Width="100px"></asp:DropDownList>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>MES DESDE:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control" Width="150px"></asp:DropDownList>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>MES HASTA:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlMesHasta" runat="server" CssClass="form-control" Width="150px"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>SUPERVISOR:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlSupervisor" runat="server" CssClass="form-control" Width="250px" OnSelectedIndexChanged="ddlSupervisor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>VENDEDOR:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlVendedor" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
            </div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="100px" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" Width="200px" OnClick="btnGenerar_Click" />
        </div>
        <br />
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvVen" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor="green" PageSize="250"
                   OnPageIndexChanging="gvVen_PageIndexChanging"  >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="AÑO" SortExpression="AÑO" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblaño" runat="server" Text='<%# Bind("AÑO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MES" SortExpression="MES" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblmes" runat="server" Text='<%# Bind("MES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RUC" SortExpression="RUC">
                            <ItemTemplate>
                                <asp:Label ID="lblruc" runat="server" Text='<%# Bind("RUC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                            <ItemTemplate>
                                <asp:Label ID="lblclienre" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SUPERVISOR" SortExpression="SUPERVISOR" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblsupervisor" runat="server" Text='<%# Bind("SUPERVISOR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CODVEN" SortExpression="CODVEN">
                            <ItemTemplate>
                                <asp:Label ID="lblcodven" runat="server" Text='<%# Bind("CODVEN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VENDEDOR" SortExpression="VENDEDOR" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblvendedor" runat="server" Text='<%# Bind("VENDEDOR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="V NETO" SortExpression="V NETO">
                            <ItemTemplate>
                                <asp:Label ID="lblvneto" runat="server" Text='<%# Bind("V_neto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PRODUCTO" SortExpression="PRODUCTO">
                            <ItemTemplate>
                                <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("PRODUCTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DESCRIPCION" SortExpression="DESCRIPCION">
                            <ItemTemplate>
                                <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MARCA PROD" SortExpression="MARCA PROD">
                            <ItemTemplate>
                                <asp:Label ID="lblmarcaprod" runat="server" Text='<%# Bind("MARCA_PROD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MARCA VEH" SortExpression="MARCA VEH">
                            <ItemTemplate>
                                <asp:Label ID="lblmarcavehi" runat="server" Text='<%# Bind("MARCA_VEHI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="LINEA" SortExpression="LINEA">
                            <ItemTemplate>
                                <asp:Label ID="lbllinea" runat="server" Text='<%# Bind("LINEA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="C NETA" SortExpression="C NETA">
                            <ItemTemplate>
                                <asp:Label ID="lblcneta" runat="server" Text='<%# Bind("cneta") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>
