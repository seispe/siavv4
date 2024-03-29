﻿<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_RecepcionNE.aspx.cs" Inherits="SIAV_v4.Reportes.Ventas.rpt_RecepcionNE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
     <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Reporte de Recepcion Notas de Entrega (Guias)</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <%-- SELECCIONAR LAS FECHAS --%>
        <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">RECIBIDAS</asp:ListItem>
                <asp:ListItem Value="2">FACTURADAS</asp:ListItem>
                <asp:ListItem Value="3">FALTANTES</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Desde:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtDesde" runat="server" Enabled="True" class="form-control" ></asp:TextBox>
        </div>
          <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Hasta:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtHasta" runat="server" Enabled="True" class="form-control" ></asp:TextBox>
        </div>
          <asp:Button ID="btnGenerarExcel" runat="server" CssClass="btn btn-success" Text="Generar Excel" OnClick="btnGenerarExcel_Click"/>
        </div>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtDesde.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
           var dp = $("#<%=txtHasta.ClientID%>");
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
