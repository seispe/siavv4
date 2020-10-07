<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Plantilla/Menu.Master" CodeBehind="rpt_DevVoids.aspx.cs" Inherits="SIAV_v4.Reportes.Devoluciones.rpt_DevVoids" %>
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
                        <h1 class="page-header">Reporte-Voids</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
      <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR NUMERO DE OC Y ESTADO --%>
      <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">PEDIDO</asp:ListItem>
                <asp:ListItem Value="2">FACTURA</asp:ListItem>
                <asp:ListItem Value="3">VOIDS</asp:ListItem>
            </asp:RadioButtonList> 

        </div>
    <br />
      <%--SELECCIONAR LA OC A BUSCAR--%>
             
        <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DATO:</h5></label>  
          <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtdoc" runat="server" CssClass="form-control" Width = "200px" placeholder="#pedido/factura/voids" ReadOnly="false"></asp:TextBox>               
          </div>  
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" onclick="btnBuscar_Click" />
            <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" Width="200px" OnClick="btnGenerar_Click"/>
        </div>
          <br />
        <br />
        <%-- Recuperación de datos por PEDIDO--%>
        <table id="tablepedido" class="table">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Producto</th>
                    <th>Descripcion</th>
                    <th>Void</th>
                    <th>Cantidad</th>
                    <th>Pedido</th>
                    <th>Factura</th>
                    <th>Fecha Factura</th>
                </tr>
            </thead>
            <tbody>
                <asp:Label ID="lbldetalle" runat="server" Text=""></asp:Label>
            </tbody>
        </table>  
</form>
</asp:Content>
