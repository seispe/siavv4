<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_DtosBodCal.aspx.cs" Inherits="SIAV_v4.Proyectos.Cobranzas.frm_DtosBodCal" %>
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
                        <h1 class="page-header">Descuentos Mercaderia</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <div class="row">
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                        <h5>Dato:</h5>
                    </label>
                    <div class="col-md-3 col-sm-3 col-xs-12">
                        <asp:TextBox ID="txtFactura" runat="server" CssClass="form-control" Width="200px" placeholder="#factura/pedido" ReadOnly="false"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" CausesValidation="false" OnClientClick="clickOnce(this, 'Buscando...')"
                                    UseSubmitBehavior="false" ValidationGroup="Buscar" OnClick="btnBuscar_Click"  />
                </div>
                <br />
                <div class="row">
                    <b class="col-md-1 col-sm-1 col-xs-12">FECHA: </b>
                    <asp:Label ID="lblFecha" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                    <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="btn btn-success" Width="200px" CausesValidation="false" OnClientClick="clickOnce(this, 'Procesando...')"
                                    UseSubmitBehavior="false" ValidationGroup="Buscar" OnClick="btnProcesar_Click"/>
                </div>
                <div class="row">
                    <b class="col-md-1 col-sm-1 col-xs-12">BODEGA: </b>
                    <asp:Label ID="lblBodega" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                <div class="row">
                    <b class="col-md-1 col-sm-1 col-xs-12">PEDIDO: </b>
                    <asp:Label ID="lblPedido" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                <div class="row">
                    <b class="col-md-1 col-sm-1 col-xs-12">FACTURA: </b>
                    <asp:Label ID="lblFactura" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                 <div class="row">
                    <b class="col-md-1 col-sm-1 col-xs-12">SUBTOTAL: </b>
                    <asp:Label ID="lblSubtotal" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                 <div class="row">
                     <b class="col-md-1 col-sm-1 col-xs-12">TOTAL: </b>
                     <asp:Label ID="lblTotal" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                 <div class="row">
                     <b class="col-md-1 col-sm-1 col-xs-12">CLIENTE: </b>
                     <asp:Label ID="lblCliente" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                  <div class="row">
                     <b class="col-md-1 col-sm-1 col-xs-12">RUC: </b>
                     <asp:Label ID="lblRuc" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                <div class="row">
                     <b class="col-md-1 col-sm-1 col-xs-12">VENDEDOR: </b>
                     <asp:Label ID="lblVendedor" runat="server" class="col-md-3 col-sm-3 col-xs-12"></asp:Label>
                </div>
                <asp:HiddenField ID="hfVendedor" runat="server"/>
                     <br />
                   </ContentTemplate>
        </asp:UpdatePanel>
      <br />
           <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
       <asp:GridView ID="gvDetPedidos" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="500">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
              <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField HeaderText="Articulo" SortExpression="Articulo">
                <ItemTemplate>
                    <asp:Label ID="lblcodigo" runat="server" Text='<%# Bind("item") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText = "Cantidad">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidad" runat="server" Text="" CssClass="form-text" ></asp:TextBox>
            </ItemTemplate>          
            <ItemStyle/>
        </asp:TemplateField>
                <asp:TemplateField  HeaderText = "Porcentaje">
            <ItemTemplate>
                <asp:TextBox ID="txtPorcentaje" runat="server" Text="" CssClass="form-text" ></asp:TextBox>
            </ItemTemplate>          
            <ItemStyle/>
        </asp:TemplateField>
              <asp:TemplateField HeaderText="Cant. Factura" SortExpression="Cant. Factura">
                <ItemTemplate>
                    <asp:Label ID="lblCantFactura" runat="server" Text='<%# Bind("cantfactura") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Prc. Unit" SortExpression="Prc. Unit">
                <ItemTemplate>
                    <asp:Label ID="lblprecioUnit" runat="server" Text='<%# Bind("precioUnit") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Dto" SortExpression="Dto">
                <ItemTemplate>
                    <asp:Label ID="lblDto" runat="server" Text='<%# Bind("Dto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Precio Total" SortExpression="Precio Total">
                <ItemTemplate>
                    <asp:Label ID="lblPrcTotal" runat="server" Text='<%# Bind("precioTotal") %>'></asp:Label>
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
    <script type="text/javascript">
       function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }
    </script>
</asp:Content>