<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_TiemposWMS.aspx.cs" Inherits="SIAV_v4.Reportes.Logistica.rpt_TiemposWMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
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
                <h1 class="page-header">Reporte Tiempos en WMS</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <br />
    <%--Buscar--%>
<div class="buscar">
  <div class="form-group">
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHA INICIO:</h5></label>  
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaInicio" runat="server" Enabled="True" class="form-control" placeholder="Fecha Inicio"></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHA FIN:</h5></label>  
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="True" class="form-control" placeholder="Fecha Final"></asp:TextBox>
        </div>
             <div class="col-sm-2">
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
        </div>
    </div>
  </div> 
</div>  
    <%--Exportar--%>

    </form>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtFechaInicio.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
            var dp = $("#<%=txtFechaFinal.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
        });
    </script>
</asp:Content>