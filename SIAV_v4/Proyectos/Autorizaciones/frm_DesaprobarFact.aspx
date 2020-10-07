<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_DesaprobarFact.aspx.cs" Inherits="SIAV_v4.Proyectos.Autorizaciones.frm_DesaprobarFact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <h1 class="page-header">Desaprobar Facturas</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
     <%-- GRID DE DESAPROBAR FACTURAS --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvDesAprobar" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="200" OnRowCommand="gvDesAprobar_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="Aprobacion" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desea desaprobar la factura')" />
              </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                    <ItemTemplate>
                        <asp:Label ID="lblFactura" runat="server" Text='<%# Bind("Factura") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Devolucion" SortExpression="Devolucion" >
                    <ItemTemplate>
                        <asp:Label ID="lblDevolucion" runat="server" Text='<%# Bind("Devolucion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Motivo" SortExpression="Motivo" >
                    <ItemTemplate>
                        <asp:Label ID="lblMotivo" runat="server" Text='<%# Bind("Motivo") %>'></asp:Label>
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
