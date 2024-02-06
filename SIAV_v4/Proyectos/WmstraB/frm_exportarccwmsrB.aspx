<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_exportarccwmsrB.aspx.cs" Inherits="SIAV_v4.Proyectos.WmstraB.frm_exportarccwmsrB" %>
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
                        <h1 class="page-header">Exportar Conteo WMS</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%-- SELECCION MAESTRO DE CONTEO CERRADO PARA EXPORTAR A GP --%>
    <div class="row">
        <asp:Button ID="btnActualizar" runat="server" class="btn btn-primary" Text="Actualizar" Width="200px" OnClick="btnActualizar_Click" />
    </div>
     <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvMaestros" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor = "green" PageSize="50" OnRowCommand="gvMaestros_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="ExportarGP" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desa exportar al WMS')" />
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
                  <asp:TemplateField HeaderText="Cerrado" SortExpression="Cerrado" >
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
        </asp:UpdatePanel>

</form>
</asp:Content>
