<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_traspasoBodCua.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_traspasoBodCua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Traspasos Matriz a Cuarentena</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />

        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>FECHAS:</h5>
            </label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="150px" placeholder="Desde"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="150px" placeholder="Hasta"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
            <div class="col-sm-2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnGenerar" runat="server" Text="Generar Traspaso" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- MODAL INGRESAR OBSERVACIONES DE ITEMS CERRADOS --%>
        <div class="modal fade" id="generaTraspaso" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3>¿Generar Traspaso?</h3>
                                <br />
                            </div>

                            <div class="modal-body">
                                <div class="container">
                                    <div class="row">
                                        <b>Desde: </b>
                                        <asp:Label ID="lblDesde" runat="server"></asp:Label><br />
                                        <b>Hasta: </b>
                                        <asp:Label ID="lblHasta" runat="server"></asp:Label><br />
                                        <b>Items: </b>
                                        <asp:Label ID="lblItems" runat="server"></asp:Label><br />
                                        <b>CantTotal: </b>
                                        <asp:Label ID="lblCantTotal" runat="server"></asp:Label><br />
                                    </div>
                                    <div class="row">
                                        <label class="col-md-3 col-sm-3 col-xs-12 label label-info">
                                            <h5>Traspaso N°:</h5>
                                        </label>
                                        <div class="col-md-3 col-sm-3 col-xs-12">
                                            <asp:TextBox ID="txtNdocumento" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <label class="col-md-3 col-sm-3 col-xs-12 label label-info">
                                            <h5>Motivo:</h5>
                                        </label>
                                        <div class="col-md-3 col-sm-3 col-xs-12">
                                            <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnGenerarTraspaso" runat="server" Text="Generar Traspaso" CssClass="btn btn-success" OnClick="btnGenerarTraspaso_Click" />
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGenerarTraspaso" />
                    </Triggers>
                </asp:UpdatePanel>
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

