<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_EstadoPedidosFechat.aspx.cs" Inherits="SIAV_v4.Reportes.WMStec.rpt_EstadoPedidosFechat" %>
<asp:Content ID="Content6" ContentPlaceHolderID="head" runat="server">
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
                <h1 class="page-header">Reporte Estado Pedidos con Fecha</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
      <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR PEDIDO O CLIENTE --%>
      <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">PEDIDO</asp:ListItem>
                <asp:ListItem Value="2">CLIENTE</asp:ListItem>
                <asp:ListItem Value="3">FECHAS</asp:ListItem>
            </asp:RadioButtonList> 

        </div>
    <br />
    <div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DATO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
</div>
    <br />
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
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
        </div>
    </div>
    <br />
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvEstadoPedidosFecha" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="150" OnRowDataBound="gvEstadoPedidosFecha_RowDataBound"
       OnPageIndexChanging="gvEstadoPedidosFecha_PageIndexChanging" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="ANULADO" SortExpression="ANULADO">
                <ItemTemplate>
                    <asp:Label ID="lblanulado" runat="server" Text='<%# Bind("anulado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="CIUDAD" SortExpression="CIUDAD">
                <ItemTemplate>
                    <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="consolidado" HeaderText="CONS" Visible="true"/>
            <asp:TemplateField HeaderText="FECHA" SortExpression="FECHA">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="BULTOS" SortExpression="BULTOS">
                <ItemTemplate>
                    <asp:Label ID="lbltotal_bultos" runat="server" Text='<%# Bind("total_bultos") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="FECHA PREEMBARQUE" SortExpression="FECHA PREEMBARQUE">
                <ItemTemplate>
                    <asp:Label ID="lblfechapreembarque" runat="server" Text='<%# Bind("fechapreembarque") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA LOGISTICA" SortExpression="FECHA LOGISTICA">
                <ItemTemplate>
                    <asp:Label ID="lblfechalogistica" runat="server" Text='<%# Bind("fechalogistica") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PRIORIDAD" SortExpression="PRIORIDAD">
                <ItemTemplate>
                    <asp:Label ID="lblprioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="PICKING" SortExpression="PICKING">
                <ItemTemplate>
                    <asp:Label ID="lblpicking" runat="server" Text='<%# Bind("PICKING") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="ARMADO" SortExpression="ARMADO">
                <ItemTemplate>
                    <asp:Label ID="lblarmado" runat="server" Text='<%# Bind("ARMADO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="TRANSITO BAHIAS" SortExpression="TRANSITO">
                <ItemTemplate>
                    <asp:Label ID="lblpreembarque" runat="server" Text='<%# Bind("PRE_EMBARQUE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="PRE EMBARQUE" SortExpression="PRE EMBARQUE">
                <ItemTemplate>
                    <asp:Label ID="lbllogistica" runat="server" Text='<%# Bind("LOGISTICA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="CARGA DE CAMION" SortExpression="CARGA DE CAMION">
                <ItemTemplate>
                    <asp:Label ID="lbldespachado" runat="server" Text='<%# Bind("DESPACHADO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="ENTREGA" SortExpression="ENTREGA">
                <ItemTemplate>
                    <asp:Label ID="lblentrega" runat="server" Text='<%# Bind("ENTREGA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RECIBE DE LAAR" SortExpression="RECIBE DE LAAR">
                <ItemTemplate>
                    <asp:Label ID="lblrecibido" runat="server" Text='<%# Bind("RECIBIDO") %>'></asp:Label>
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