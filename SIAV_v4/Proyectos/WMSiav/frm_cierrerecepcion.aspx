<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Plantilla/Menu.Master" CodeBehind="frm_cierrerecepcion.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_cierrerecepcion" %>
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
                        <h1 class="page-header">Cierre Recepción</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%--SELECCIONAR LA ORDEN DE COMPRA A CERRAR--%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>OC:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtOC" runat="server" CssClass="form-control" placeholder="# OC completo" ></asp:TextBox>
        </div>
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Orden" CssClass="btn btn-success" Width="200px" OnClick="btnCerrar_Click"/>
    </div>
    <br />
    <br />
  
</form>
</asp:Content>
