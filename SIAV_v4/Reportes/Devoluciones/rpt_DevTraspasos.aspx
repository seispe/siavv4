<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_DevTraspasos.aspx.cs" Inherits="SIAV_v4.Reportes.Devoluciones.rpt_DevTraspasos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server" id="form1">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 class="page-header">Reporte Traspasos</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
      <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR TRASPASO O FECHA--%>
      <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">TRASPASO</asp:ListItem>
                <asp:ListItem Value="2">FECHAS DEVOLUCIONES</asp:ListItem>
                <asp:ListItem Value="7">FECHAS MATRIZ</asp:ListItem>
            </asp:RadioButtonList> 
        </div>
    <br />
    <div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>TRASPASO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
</div>
     <br />
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHAS:</h5></label>  
        <div class="col-sm-2">
            <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="150px" placeholder="Desde" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="150px" placeholder="Hasta" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" OnClick="btnGenerar_Click"/>
        </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
           <div class="col-sm-2">
             <asp:Button ID="btnTraspaso" runat="server" Text="Asignar/Liberar Traspaso" CssClass="btn btn-success" OnClick="btnTraspaso_Click"/>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>

       <%-- MODAL GENERAR/LIBERAR TRASPASO --%>
<div id="traspasoModal" class="modal fade" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                <h3 id="facModalLabel">Asignar/Liberar Traspaso</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                       <div class="row">
                        <label class="col-lg-3 col-md-3 col-sm-3 col-xs-12 label label-info"><h5>Documentos:</h5></label>  
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lblDocumentos" runat="server" CssClass="control-label" Text=""></asp:Label>
                            </div>
                          </div>
                        <br />
                      <div class="row">
                           <label class="col-lg-3 col-md-3 col-sm-3 col-xs-12 label label-info"><h5>Traspaso No:</h5></label>  
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox ID="txtnumeroDocGP" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    <div class="modal-footer">
                           <asp:Button ID="btnGuardarR" runat="server" Text="Guardar" OnClick="btnGuardarR_Click" CssClass="btn btn-success" ValidationGroup="Procesar"
                             UseSubmitBehavior="false"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    </div>
                </ContentTemplate>
                <Triggers>

                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
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
                format: "yyyy-mm-dd",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;

            var dp = $("#<%=txtfhasta.ClientID%>");
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