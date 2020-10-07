<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="Reporte247.aspx.cs" Inherits="SIAV_v4.Reportes.Reporte247" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
                <h1 class="page-header">Mostrando Reporte</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <%--<a href="/SIAV_v4/Defautl.aspx" class="btn btn-info">Regresar</a>--%>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <rsweb:reportviewer id="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="600" ProcessingMode="Remote" Width="100%">
        <ServerReport ReportServerUrl="" />
    </rsweb:reportviewer>
</form>
</asp:Content>
