<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_Proveedores.aspx.cs" Inherits="SIAV_v4.Proyectos.Compras.frm_Proveedores" %>
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
                        <h1 class="page-header">Proveedores</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
     <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR TIPO --%>
      <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="2">TIPO</asp:ListItem>
            </asp:RadioButtonList> 

        </div>
        <br />
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DATOS:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtDatos" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <br />
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="50" HorizontalAlign="Right" OnPageIndexChanging="gvProveedores_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
            <asp:TemplateField HeaderText="Proveedor" SortExpression="Proveedor">
                <ItemTemplate>
                    <asp:Label ID="lblproveedor" runat="server" Text='<%# Eval("proveedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad" SortExpression="Ciudad">
                <ItemTemplate>
                    <asp:Label ID="lblciudad" runat="server" Text='<%# Eval("ciudad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono" SortExpression="Telefono">
                <ItemTemplate>
                    <asp:Label ID="lbltelefono" runat="server" Text='<%# Eval("telefono") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Marca" SortExpression="Marca">
                <ItemTemplate>
                    <asp:Label ID="lblmarcar" runat="server" Text='<%# Eval("marca") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Procedencia" SortExpression="Procedencia">
                <ItemTemplate>
                    <asp:Label ID="lblprocedencia" runat="server" Text='<%# Eval("procedencia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lineas" SortExpression="Lineas">
                <ItemTemplate>
                    <asp:Label ID="lbllineas" runat="server" Text='<%# Eval("lineas") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                <ItemTemplate>
                    <asp:Label ID="lblproducto" runat="server" Text='<%# Eval("producto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descuento" SortExpression="Descuento">
                <ItemTemplate>
                    <asp:Label ID="lbldescuento" runat="server" Text='<%# Eval("descuento") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo" SortExpression="Tipo">
                <ItemTemplate>
                    <asp:Label ID="lbltipo" runat="server" Text='<%# Eval("tipo") %>'></asp:Label>
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

