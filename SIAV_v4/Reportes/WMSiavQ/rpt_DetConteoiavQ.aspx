﻿<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_DetConteoiavQ.aspx.cs" Inherits="SIAV_v4.Reportes.WMSiavQ.rpt_DetConteoiavQ" %>
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
                        <h1 class="page-header">Conteos General</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
   <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor = "green" PageSize="150" OnRowCommand="gvResumen_RowCommand" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="ExportarExcel" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/export.png" runat="server" OnClientClick="return confirm('Desea exportar a Excel')" />
              </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="#" SortExpression="#" >
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo" >
                    <ItemTemplate>
                        <asp:Label ID="lblcodigo" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tipo" SortExpression="Tipo" >
                    <ItemTemplate>
                        <asp:Label ID="lbltipo" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha" >
                    <ItemTemplate>
                        <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Bodega" SortExpression="Bodega" >
                    <ItemTemplate>
                        <asp:Label ID="lblcerrado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observacion" SortExpression="Observacion">
                    <ItemTemplate>
                        <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
            <asp:PostBackTrigger ControlID="gvResumen" />
    </Triggers>
        </asp:UpdatePanel>

    </form>
    </asp:Content>
