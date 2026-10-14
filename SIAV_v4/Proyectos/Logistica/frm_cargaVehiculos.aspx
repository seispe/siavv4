<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_cargaVehiculos.aspx.cs" Inherits="SIAV_v4.Proyectos.Logistica.frm_cargaVehiculos" %>
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
                        <h1 class="page-header">CheckList Carga de Vehiculos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
             <%-- SELECCION DE FECHAS PARA LA GENERACION DEL REPORTE --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>FECHAS:</h5>
            </label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtfecha" runat="server" CssClass="form-control" Width="150px" placeholder="Fecha Carga"></asp:TextBox>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>PLACA:</h5>
            </label>
            <div class="col-sm-2">
                <asp:DropDownList ID="ddlPlaca" runat="server" CssClass="form-control" Width="150px"></asp:DropDownList>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>FRECUENCIA:</h5>
            </label>
              <div class="col-sm-2">
                  <asp:DropDownList ID="ddlFrecuencia" runat="server" CssClass="form-control" Width="150px">
                      <asp:ListItem Selected="True" Value="1">Frecuencia 1</asp:ListItem>
                      <asp:ListItem Value="2">Frecuencia 2</asp:ListItem>
                      <asp:ListItem Value="3">Frecuencia 3</asp:ListItem>
                  </asp:DropDownList>
              </div>
              <div class="col-sm-2">
                <asp:Button ID="btnGenerar" runat="server" Text="Generar CheckList" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
            </div>
        </div>
        <br />
        <br />
        </form>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtfecha.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "yyyy-mm-dd",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
        });
    </script>
</asp:Content>