<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_agregarprodconteo.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_agregarprodconteo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
      <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Agregar Productos a Conteo</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
            <%-- SELECCIONAR EL CONTEO E INGRESAR EL PRODUCTO --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Id Conteo:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList ID="ddlConteos" runat="server" CssClass="form-control" Width="400px"></asp:DropDownList>
            </div>
        </div>
    <br />
           <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Producto:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" Width="200px" ></asp:TextBox>
            </div>
           <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" Width="100px" OnClick="btnAgregar_Click" />
        </div>
    </form>
    </asp:Content>