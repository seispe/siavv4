<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_PedPenxFact.aspx.cs" Inherits="SIAV_v4.Reportes.WMSiav.rpt_PedPenxFact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Pedidos Pendientes por Facturar</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%-- COMBOS DE USUARIOS Y TIPOS --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>AÑO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlAño" runat="server" CssClass="form-control" Width="250px">
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2018" Selected="True">2018</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                </asp:DropDownList>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>MES:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control" Width="250px">
                    <asp:ListItem Value="1" Selected="True">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" Width="200px" OnClick="btnGenerar_Click" />
        </div>
        <br />
    </form>
</asp:Content>
