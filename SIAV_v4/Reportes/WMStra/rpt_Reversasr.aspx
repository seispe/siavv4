<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_Reversasr.aspx.cs" Inherits="SIAV_v4.Reportes.WMStra.rpt_Reversasr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
     <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Reporte de Reversas Realizadas</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%-- SELECCION DE FECHAS PARA LA GENERACION DEL REPORTE --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHAS:</h5></label>  
        <div class="col-sm-2">
            <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="150px" placeholder="Desde" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="150px" placeholder="Hasta" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
              <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
        <div class="col-sm-2">
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" OnClick="btnGenerar_Click"  />
        </div>
    </div>
    <br />
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvReversas" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="150" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="Proceso" SortExpression="Proceso">
                <ItemTemplate>
                    <asp:Label ID="lblproceso" runat="server" Text='<%# Bind("proceso") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Consolidado" SortExpression="Consolidado">
                <ItemTemplate>
                    <asp:Label ID="lblnumconsolidado" runat="server" Text='<%# Bind("numconsolidado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                <ItemTemplate>
                    <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Motivo" SortExpression="Motivo">
                <ItemTemplate>
                    <asp:Label ID="lblmotivo" runat="server" Text='<%# Bind("motivo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad">
                <ItemTemplate>
                    <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                <ItemTemplate>
                    <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
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