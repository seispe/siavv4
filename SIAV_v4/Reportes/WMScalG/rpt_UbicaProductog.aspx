<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_UbicaProductog.aspx.cs" Inherits="SIAV_v4.Reportes.WMScalG.rpt_UbicaProductog" %>
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
                <h1 class="page-header">Reporte Ubicación Productos</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<%-- SELECCIONAR EL TIPO DE BUSQUEDA POR PEDIDO O CLIENTE --%>
    <div>
        <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
            <asp:ListItem Value="1" Selected="True">Producto</asp:ListItem>
            <asp:ListItem Value="2">Descripción</asp:ListItem>
            <asp:ListItem Value="3">Coordenada</asp:ListItem>
        </asp:RadioButtonList> 
    </div>
    <br />
    <div class="row">
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DATO:</h5></label>  
         <div class="col-md-3 col-sm-3 col-xs-12">
           <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" Width="350px" ></asp:TextBox>
         </div>
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
              <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click"/>
          </div>
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
              <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass=" btn btn-success" OnClick="btnGenerar_Click"/>
          </div>
    </div>
    <br />
      <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
       <asp:GridView ID="gvUbicaProducto" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="1000" 
        >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="PRODUCTO" SortExpression="PRODUCTO">
                <ItemTemplate>
                    <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="DESCRIPCION" SortExpression="DESCRIPCION">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="COORDENADA" SortExpression="COORDENADA">
                <ItemTemplate>
                    <asp:Label ID="lblcoordenada" runat="server" Text='<%# Bind("coordenada") %>'></asp:Label>
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

