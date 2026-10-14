<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_autorizarPeriodoFiscal.aspx.cs" Inherits="SIAV_v4.Proyectos.Autorizaciones.frm_autorizarPeriodoFiscal" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .menu-class {
            font-size: 16px;
        }
        
        ul {
            font-size: 16px;
        }

        .uppercase-header {
            text-transform: capitalize;
        }
    </style>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="font-size:16px; padding-top:25px;">
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" />
                    <asp:BoundField DataField="USUARIO_SOLICITA_PERMISO" HeaderText="Usuario" />
                    <asp:BoundField DataField="FECHA_SOLICITUD" HeaderText="Fecha Solicitud" DataFormatString="{0:D}" ItemStyle-CssClass="uppercase-header"/>
                    <asp:BoundField DataField="MODULO" HeaderText="Módulo" />
                    <asp:BoundField DataField="AÑO" HeaderText="Año" />
                    <asp:BoundField DataField="NOMBRE_MES" HeaderText="Mes" />
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <button type="button" class="btn btn-secondary menu-class" data-toggle="modal" data-target="#exampleModal" data-id='<%# Eval("ID") %>' data-usuario='<%# Eval("USUARIO_SOLICITA_PERMISO") %>'>
                                Habilitar Período
                            </button>
                        </ItemTemplate>
                    </asp:TemplateField> 
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#023859" Font-Bold="True" ForeColor="#FFFFFF" Height="25px"/>
                <PagerStyle />
                <RowStyle BackColor="White" ForeColor="#000000"/>
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>

        <!-- Modal -->
        <div class="modal fade menu-class" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Confirmar Acción</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        ¿Está seguro que desea habilitar el período fiscal para el usuario <span id="modalUsuario"></span>?
                        <div class="form-group mt-3">
                            <label for="authorizationTime">Escriba el tiempo en minutos para autorizar:</label>
                            <asp:HiddenField ID="hiddenFieldId" runat="server" />
                            <asp:TextBox ID="authorizationTime" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer menu-class">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <asp:Button runat="server" ID="confirmButton" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnMostrarNombre_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" crossorigin="anonymous"></script>

    <script>
        $('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget);
            var id = button.data('id');
            $('#<%= hiddenFieldId.ClientID %>').val(id);
            var usuario = button.data('usuario');
            var modal = $(this);
            modal.find('.modal-body #modalUsuario').text(usuario);
        });
    </script>
</asp:Content>
