<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_forzarpedidosr.aspx.cs" Inherits="SIAV_v4.Proyectos.WMStra.frm_forzarpedidosr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
     <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Subir Pedidos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <br />
     <%-- INGRESAR EL NUMERO DE PEDIDO --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>PEDIDO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <asp:Button ID="btnSubir" runat="server" Text="Subir Pedido" CssClass="btn btn-success" Width="200px" OnClick="btnSubir_Click"  />
    </div>
    <br />
</form>
</asp:Content>
