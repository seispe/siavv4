<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_Rotacion.aspx.cs" Inherits="SIAV_v4.Reportes.Compras.rpt_Rotacion" %>

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
                        <h1 class="page-header">Reporte de Rotación por PV</h1>
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
                        <asp:Button ID="btnMatriz" runat="server" Text="ROTACION MATRIZ" OnClick="btnMatriz_Click" CssClass="btn btn-success" Width="200px" />
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <br />
                        <asp:Button ID="btnGuayaquil" runat="server" Text="ROTACION GUAYAQUIL" OnClick="btnGuayaquil_Click" CssClass="btn btn-primary" Width="200px" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

