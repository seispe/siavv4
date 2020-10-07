<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frmOrdenCompra.aspx.cs" Inherits="SIAV_v4.Proyectos.Importaciones.frmOrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--Agregamos los scripts y styles que necesitemos--%>
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <%--<a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>              --%>
                <h1 class="page-header">Cargar Orden de Compra</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<div class="row">
    <div class="col-md-offset-3 col-md-6">
        <div class="panel with-nav-tabs panel-primary">
            <div class="panel-heading">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#tab1primary" data-toggle="tab">DATOS ORDEN DE COMPRA</a></li>
                    </ul>
            </div>
            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1primary">
                    <!-- Panel 1 Inicio -->
                        <div class="row">
                            Datos de la Orden de Compra
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                Cardar datos:
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            </div>
                            <div class="row">
                                <div class="col-lg-8 col-md-8 col-sm-6 col-xs-12">
                                    <asp:Label ID="Label1" runat="server" Text="Tiene Cabecera ?" />
                                    <asp:RadioButtonList ID="rbHDR" runat="server">
                                        <asp:ListItem Text = "SI" Value = "SI" Selected = "True" ></asp:ListItem>
                                        <asp:ListItem Text = "NO" Value = "NO"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-info" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <asp:GridView ID="GridView1" runat="server"  CssClass="grid" OnPageIndexChanging = "PageIndexChanging" pagesize="10" AllowPaging = "true">
                                </asp:GridView>
                            </div>
                        </div>

                    <!-- Panel 1 Fin -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<br />
<!-- Efecto Procesando -->
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div class="updateProgress">
            <span class="updateProgressHijo">Cargando...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> 
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
