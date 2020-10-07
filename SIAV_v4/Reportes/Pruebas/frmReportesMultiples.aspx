<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frmReportesMultiples.aspx.cs" Inherits="SIAV_v4.Reportes.Pruebas.frmReportesMultiples" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server" id="form1">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 class="page-header">Reporting Server</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<div class="row">
    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
        <asp:Button ID="btnPrueba" runat="server" Text="Prueba Reporte" OnClick="btnPrueba_Click" CssClass="btn btn-success" />
    </div>
</div>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
