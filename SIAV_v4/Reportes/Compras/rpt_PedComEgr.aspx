<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_PedComEgr.aspx.cs" Inherits="SIAV_v4.Reportes.Compras.rpt_PedComEgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Reporte de Pedidos, Compras, Egresos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%--Buscar--%>
    <div class="buscar">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <br />
                        <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar Reporte"  CssClass="btn btn-success" Width="200px" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
