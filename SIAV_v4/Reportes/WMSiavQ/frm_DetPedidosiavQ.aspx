<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_DetPedidosiavQ.aspx.cs" Inherits="SIAV_v4.Reportes.WMSiavQ.frm_DetPedidosiavQ" %>
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
                <h1 class="page-header">Detalle de Pedidos</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>PEDIDO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click"/>
    </div>
    <br />
    <b>PEDIDO: </b><asp:Label ID="lblPedido" runat="server"></asp:Label><br />
    <b>BODEGA: </b><asp:Label ID="lblBodega" runat="server"></asp:Label><br />
    <b>RUTA: </b><asp:Label ID="lblRuta" runat="server"></asp:Label><br />
    <b>TELEFONOS: </b><asp:Label ID="lblTelefonos" runat="server"></asp:Label><br />
    <b>CLIENTE: </b><asp:Label ID="lblCliente" runat="server"></asp:Label><br />
    <b>RUC: </b><asp:Label ID="lblRuc" runat="server"></asp:Label><br />
    <b>DIRECCION: </b><asp:Label ID="lblDireccion" runat="server"></asp:Label><br />
    <b>RAZON: </b><asp:Label ID="lblRazonSocial" runat="server"></asp:Label><br />
    <b>CIUDAD: </b><asp:Label ID="lblCiudad" runat="server"></asp:Label><br />
    <b>TOTAL BULTOS: </b><asp:Label ID="lblTbultos" runat="server"></asp:Label><br />
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
       <asp:GridView ID="gvDetPedidos" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="500">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="Articulo" SortExpression="Articulo">
                <ItemTemplate>
                    <asp:Label ID="lblcodigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cant" SortExpression="Cant">
                <ItemTemplate>
                    <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("CANT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Bulto" SortExpression="Bulto">
                <ItemTemplate>
                    <asp:Label ID="lblbulto" runat="server" Text='<%# Bind("BULTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Observacion" SortExpression="Observacion">
                <ItemTemplate>
                    <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("OBSERVACION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Camion" SortExpression="Camion">
                <ItemTemplate>
                    <asp:Label ID="lblcamion" runat="server" Text='<%# Bind("CAMION") %>'></asp:Label>
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
