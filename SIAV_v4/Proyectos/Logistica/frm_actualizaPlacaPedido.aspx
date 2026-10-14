<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_actualizaPlacaPedido.aspx.cs" Inherits="SIAV_v4.Proyectos.Logistica.frm_actualizaPlacaPedido" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Actualización Placa - Pedido</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <br />
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>PEDIDO:</h5>
            </label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" Width="150px" placeholder="#pedido"></asp:TextBox>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>PLACA:</h5>
            </label>
              <div class="col-sm-2">
                  <asp:DropDownList ID="ddlPlaca" runat="server" CssClass="form-control" Width="150px"></asp:DropDownList>
              </div>
              <div class="col-sm-2">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click"/>
            </div>
        </div>
        </form>
    </asp:Content>