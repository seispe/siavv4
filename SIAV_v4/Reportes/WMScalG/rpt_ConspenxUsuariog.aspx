<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_ConspenxUsuariog.aspx.cs" Inherits="SIAV_v4.Reportes.WMScalG.rpt_ConspenxUsuariog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server" id="form1">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 class="page-header">Consolidados Pendientes por Usuario</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <%-- Generar el reporte --%>
    <div class="row">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click"/>
    </div>
    <br />
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
       <asp:GridView ID="gvConsPendxUsu" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="20">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="#" SortExpression="#">
                <ItemTemplate>
                    <asp:Label ID="lblnumero" runat="server" Text='<%# Bind("numero") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                <ItemTemplate>
                    <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="PendienteXEtapa" SortExpression="PendienteXEtapa">
                <ItemTemplate>
                    <asp:Label ID="lblPendienteXEtapa" runat="server" Text='<%# Bind("PendienteXEtapa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Consolidados" SortExpression="Consolidados">
                <ItemTemplate>
                    <asp:Label ID="lblConsolidados" runat="server" Text='<%# Bind("Consolidados") %>'></asp:Label>
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