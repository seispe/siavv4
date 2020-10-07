<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_TiemposWMS.aspx.cs" Inherits="SIAV_v4.Reportes.WMSiav.rpt_TiemposWMS" %>
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
                        <h1 class="page-header">Tiempos WMS</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
       <%--CAMPOS--%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHA INICIO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="150px" ></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>CIUDAD:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtciudad" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHA FIN:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="150px" ></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>PRIORIDAD:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlprioridad" runat="server" CssClass="form-control" Width="250px">
                <asp:ListItem Value="0">Todo</asp:ListItem>
                <asp:ListItem Value="1">Urgente</asp:ListItem>
                <asp:ListItem Value="2">Grande</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>ITEMS:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtitems" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" Text="Ver" Width="200px" OnClick="btnGuardar_Click" />
    </div>
    <br />
    </form>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtfdesde.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;

            var dp = $("#<%=txtfhasta.ClientID%>");
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