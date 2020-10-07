<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_NewCliente.aspx.cs" Inherits="SIAV_v4.Proyectos.Cobranzas.frm_NewCliente" %>
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
                        <h1 class="page-header">Crear Nuevo Cliente</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Ruc/Cédula (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtRuc" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Extranjero:</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtExtranjero" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Nombre Comercial (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtNombreComercial" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Razón Social (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtRazonSocial" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Dirección (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtDireccion" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Teléfono (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtTelefono" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Ciudad (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtCiudad" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Parroquia (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtParroquia" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Provincia (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtProvincia" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Correo Electrónico (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtCorreo" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                    <label class="control-label" for="inputSuccess">Nombre de Contacto (*):</label>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:Textbox ID="txtContacto" runat="server" Text="" CssClass="form-control"></asp:Textbox>
            </div>
        </div>
        <div class="row">
            <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success" Text="Guardar Cliente" OnClick="btnGuardar_Click"/>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
