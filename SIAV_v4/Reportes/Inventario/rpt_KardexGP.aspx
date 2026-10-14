<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_KardexGP.aspx.cs" Inherits="SIAV_v4.Reportes.Inventario.rpt_KardexGP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <%--<a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>              --%>
                <h1 class="page-header">Reporte Kardex GP</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <%--Buscar--%>
<div class="buscar">
  <div class="form-group">
    <div class="row">
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
            <h5>PRODUCTO:</h5>
         </label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtProducto" runat="server" Enabled="True" class="form-control" placeholder="Codigo Producto"></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
            <h5>BODEGA:</h5>
        </label>
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlBodega" runat="server" CssClass="form-control" Width="150px">
                <asp:ListItem Value="MATRIZ" Selected="True">MATRIZ</asp:ListItem>
                <asp:ListItem Value="PVQ">PVQ</asp:ListItem>
                <asp:ListItem Value="PVG1">PVG</asp:ListItem>
                <asp:ListItem Value="CUARENTENA">CUARENTENA</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
   <div class="row">
    <div class="col-12">
        <br />
        <asp:UpdatePanel id="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div class="d-flex gap-2">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                        CssClass="btn btn-success"
                        OnClick="btnBuscar_Click"
                        CausesValidation="false" OnClientClick="clickOnce(this, 'Buscando...')" ValidationGroup="Buscar"
                             UseSubmitBehavior="false" />

                    <asp:Button ID="btnExport" runat="server" Text="Generar A Excel"
                        CssClass="btn btn-warning"
                        OnClick="btnGenerar_Click"
                        CausesValidation="false" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExport" />
            </Triggers>        </asp:UpdatePanel>
    </div>
    </div>
  </div> 
</div>  
   
    <%--Grid--%>
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvKardex" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" forecolor="#333333"
        gridlines="None"  OnPageIndexChanging="gvKardex_PageIndexChanging"
        allowpaging="True" pagesize="30">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="TIPO" SortExpression="Tipo">
                <ItemTemplate>
                    <asp:Label ID="lbltipo" runat="server" Text='<%# Bind("Tipo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOCUMENTO" SortExpression="documento">
                <ItemTemplate>
                    <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOCUMENTO2" SortExpression="documento2">
                <ItemTemplate>
                    <asp:Label ID="lbldocumento2" runat="server" Text='<%# Bind("documento2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA" SortExpression="fecha">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="ENTRADAS" SortExpression="Entradas">
                <ItemTemplate>
                    <asp:Label ID="lblentradas" runat="server" Text='<%# Bind("Entradas") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SALIDAS" SortExpression="Salidas">
                <ItemTemplate>
                    <asp:Label ID="lblsalidas" runat="server" Text='<%# Bind("Salidas") %>'></asp:Label> 				
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SALDO" SortExpression="Saldo">
                <ItemTemplate>
                    <asp:Label ID="lblsaldo" runat="server" Text='<%# Bind("Saldo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:gridview>
    </ContentTemplate>
    <Triggers>
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