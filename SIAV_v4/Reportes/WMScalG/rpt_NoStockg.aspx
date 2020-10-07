<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_NoStockg.aspx.cs" Inherits="SIAV_v4.Reportes.WMScalG.rpt_NoStockg" %>
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
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 class="page-header">Reporte de No Stock</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
        <%-- SELECCIONAR LAS FECHAS --%>
<div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Desde:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Hasta:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvNoStock" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="250" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                <ItemTemplate>
                    <asp:Label ID="lblprod_id" runat="server" Text='<%# Bind("prod_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Consolidado" SortExpression="Consolidado">
                <ItemTemplate>
                    <asp:Label ID="lblconsolidado" runat="server" Text='<%# Bind("consolidado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Cant. Pedido" SortExpression="Cant. Pedido">
                <ItemTemplate>
                    <asp:Label ID="lblcant_pedido" runat="server" Text='<%# Bind("cant_pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                <ItemTemplate>
                    <asp:Label ID="lblfechacreacion" runat="server" Text='<%# Bind("fechacreacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                <ItemTemplate>
                    <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
    </Triggers>
   </asp:UpdatePanel>
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
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;

            var dp = $("#<%=txtfhasta.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
        });
    </script>
</asp:Content>