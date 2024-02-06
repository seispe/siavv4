<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_vaciarcoordenadat.aspx.cs" Inherits="SIAV_v4.Proyectos.WMStec.frm_vaciarcoordenadat" %>
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
                        <h1 class="page-header">Vaciar Coordenadas</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
     <%-- INGRESO DE COORDENADA --%>
    <div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>PRODUCTO:</h5></label>  
        <div class="col-sm-3">
            <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
        <div class="col-xs-2" >
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
    </div>
     <br />
     <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvCoordenadas" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor = "green" PageSize="50" OnRowCommand="gvCoordenadas_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="VaciarCoor" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/delete.png" runat="server" OnClientClick="return confirm('Desea borrar lo contado')" />
              </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="#" SortExpression="#" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Coordenada" SortExpression="Coordenada" >
                    <ItemTemplate>
                        <asp:Label ID="lblcoordenada" runat="server" Text='<%# Bind("coordenada") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Prod" SortExpression="Prod" >
                    <ItemTemplate>
                        <asp:Label ID="lblcodigoproducto" runat="server" Text='<%# Bind("codigoproducto") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Desc" SortExpression="Desc" >
                    <ItemTemplate>
                        <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Cant" SortExpression="Cant" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                    <ItemTemplate>
                        <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Obs" SortExpression="Obs">
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

