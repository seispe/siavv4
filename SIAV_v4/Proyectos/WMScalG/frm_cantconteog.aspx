<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_cantconteog.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalG.frm_cantconteog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
  <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Cantidades Contadas</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
<%-- SELECCION DE CONTEO Y BUSQUEDA DE ARTICULO --%>
   <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>RE CONTEO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
           <asp:DropDownList ID="ddlConteo" runat="server" CssClass="form-control" Width="250px" ></asp:DropDownList>
        </div>
    </div>
</form>
</asp:Content>