<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_liberaretiquetasu.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalU.frm_liberaretiquetasu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Liberar Etiquetas de Bultos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
     <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
     <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Pedido:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" placeholder="#pedido"></asp:TextBox>
        </div>
        <asp:Button ID="btnProceso" runat="server" CssClass="btn btn-success" Text="Procesar" OnClick="btnProceso_Click" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar"
                             UseSubmitBehavior="false"/>
    </div>
                           </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnProceso" />
                    </Triggers>
                </asp:UpdatePanel>
    </form>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
       function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }
    </script>
</asp:Content>