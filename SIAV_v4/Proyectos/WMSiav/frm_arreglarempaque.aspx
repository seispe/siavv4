<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Plantilla/Menu.Master" CodeBehind="frm_arreglarempaque.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_arreglarempaque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h2 class="page-header">No aparece para empacar</h2>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- INGRESAR DATOS --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>PEDIDO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" placeholder="#pedido"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>PRODUCTO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" placeholder="producto"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>CANTIDAD:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="cantidad"></asp:TextBox>
            </div>
            <asp:Button ID="btnProceso" runat="server" CssClass="btn btn-success" Text="Procesar" OnClick="btnProceso_Click" />
        </div>
    </form>
</asp:Content>
