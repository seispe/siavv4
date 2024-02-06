<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_WmsVsGPu.aspx.cs" Inherits="SIAV_v4.Reportes.WMScalU.rpt_WmsVsGPu" %>
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
                        <h1 class="page-header">Reportes WMS vs GP</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <%-- SELECCIONAR EL TIPO DE REPORTE A GENERAR PRUEBA --%>
      <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">&nbsp WMS vs GP &nbsp</asp:ListItem>
                <asp:ListItem Value="2">&nbsp CUARENTENA vs 012101011 &nbsp</asp:ListItem>
                <asp:ListItem Value="3">&nbsp GP vs 010101063 &nbsp</asp:ListItem>
            </asp:RadioButtonList> 
      </div>
    <br />
    <div class="row">
        <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" Width="200px" OnClick="btnGenerar_Click" />
    </div>
    <br />
    </form>
   </asp:Content>
