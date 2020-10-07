<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_PedsinStock.aspx.cs" Inherits="SIAV_v4.Reportes.WMScal.rpt_PedsinStock" %>

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
                        <h1 class="page-header">Pedidos sin stock</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
        <br>
        <div class="row">
            <asp:Button ID="Button2" runat="server" Text="Exportar EXCEL" CssClass="btn btn-success" OnClick="btnExcel_Click" />
        </div>
        <br />
        <br />
        <%-- Recuperación de datos de pedidos cuyos artículos de IAVEC están sin stock --%>
        <table id="table" class="table">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Descripcion</th>
                    <th>Cantidad</th>
                    <th>Pedido</th>
                    <th>Fecha</th>
                    <th>Cliente</th>
                    <th>Vendedor</th>
                    <th>Stock</th>
                    <th>CIF</th>
                    <th>Precio</th>
                    <th>MU</th>
                    <th>QTY_UC</th>
                    <th>FECHA_UC</th>
                </tr>
            </thead>
            <tbody>
                <asp:Label ID="lbldetalleped" runat="server" Text=""></asp:Label>
            </tbody>
        </table>

    </form>
</asp:Content>
