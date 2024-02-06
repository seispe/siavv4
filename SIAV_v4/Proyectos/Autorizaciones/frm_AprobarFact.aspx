<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_AprobarFact.aspx.cs" Inherits="SIAV_v4.Proyectos.Autorizaciones.frm_AprobarFact" %>
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
                <h1 class="page-header">Aprobar Documentos</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
     <%-- GRID DE APROBAR FACTURAS --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvAprobar" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="200" OnRowCommand="gvAprobar_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="Aprobacion" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desea aprobar el documento')" />
              </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="#" SortExpression="#" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Modulo" SortExpression="Modulo">
                    <ItemTemplate>
                        <asp:Label ID="lblmodulo" runat="server" Text='<%# Bind("modulo") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Documento" SortExpression="Documento" >
                    <ItemTemplate>
                        <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario" >
                    <ItemTemplate>
                        <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario_crea") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Ingreso" SortExpression="Fecha Ingreso" >
                    <ItemTemplate>
                        <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("f_ingreso") %>'></asp:Label>
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
