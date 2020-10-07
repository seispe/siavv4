<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_PorcentajeConteo.aspx.cs" Inherits="SIAV_v4.Reportes.WMSiav.rpt_PorcentajeConteo" %>
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
                        <h1 class="page-header">Porcentajes de Avance Conteo Cíclico</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <%-- SELECCIONAR EL REPORTE --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>REPORTE:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlReporte" runat="server" CssClass="form-control" Width="250px" >
                <asp:ListItem Value="0" Selected="True">Porcentajes por Usuario</asp:ListItem>
                <asp:ListItem Value="1">Cantidades por Producto</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
     <%--INGRESAR ALGUN DATO--%>
             
        <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DATO:</h5></label>  
          <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" Width = "200px" placeholder="#dato" ReadOnly="false"></asp:TextBox>               
          </div>  
            <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" Width="200px" OnClick="btnGenerar_Click" />
        </div>
         <br />
    </form>
    </asp:Content>