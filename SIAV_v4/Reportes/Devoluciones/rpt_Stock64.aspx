<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_Stock64.aspx.cs" Inherits="SIAV_v4.Reportes.Devoluciones.rpt_Stock64" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Reporte Stock Ubicación 64</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-sm-2">
                <asp:Button ID="btnGenerar" runat="server" CssClass="btn btn-success" Text="Generar a Excel" OnClick="btnGenerar_Click" />
            </div>
        </div>
    </form>
</asp:Content>
