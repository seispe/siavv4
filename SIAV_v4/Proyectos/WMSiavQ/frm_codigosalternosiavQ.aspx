<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_codigosalternosiavQ.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiavQ.frm_codigosalternosiavQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Codigos Alternos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%-- BUSCAR CODIGO DE ARTICULO --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>ARTICULO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código"></asp:TextBox>
        </div>
        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <%--<div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Descripción:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Width="300px" ReadOnly="true"></asp:TextBox>
        </div>
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Alternos:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtAlternos" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Width="300px" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <br />--%>
    <%-- GRID DE CODIGOS ALTERNOS --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvCodAlternos" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="20" OnSelectedIndexChanged="gvCodAlternos_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
             
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Recursos/images/delete.png" SelectText="Seleccionar" ShowSelectButton="true" />
                <asp:TemplateField HeaderText="Cod Alterno" SortExpression="Cod Alterno" >
                    <ItemTemplate>
                        <asp:Label ID="lblcodigoalterno" runat="server" Text='<%# Bind("codigoalterno") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                    <ItemTemplate>
                        <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Producto" SortExpression="Producto" >
                    <ItemTemplate>
                        <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        </asp:GridView>
    </ContentTemplate>
        </asp:UpdatePanel>
    <br />
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Nuevo Alterno:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtNAlterno" runat="server" CssClass="form-control" placeholder="Código"></asp:TextBox>
        </div>
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>
</form>
</asp:Content>

