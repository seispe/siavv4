<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_consBultos.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_consBultos" %>

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
                        <h1 class="page-header">CONSOLIDADO DE BULTOS - IMPRESION NOTA ENTREGA</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%--BUSCAR EL PEDIDO--%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>PEDIDO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtpedido" runat="server" CssClass="form-control" Width="200px" placeholder="#pedido" ReadOnly="false"></asp:TextBox>
            </div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" OnClientClick="clickOnce(this, 'Buscando...')" ValidationGroup="Buscar"
                UseSubmitBehavior="false" />
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-warning" Width="200px" OnClick="btnImprimir_Click" OnClientClick="openInNewTab();" />

        </div>
        <br />
        <br />
       
        
        <%-- GRID DE MAESTRO DE PEDIDOS CABECERA --%>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvDetalleArmado" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
                    AllowSorting="True" HeaderStyle-BackColor="green"
                    PageSize="500" OnRowCommand="gvDetalleArmado_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="id" SortExpression="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblidbulto" runat="server" Text='<%# Bind("idbulto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BULTO" SortExpression="BULTO">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkidbulto" CommandName="detBulto" runat="server" Text='<%# Eval("bulto") %>' CommandArgument='<%# Eval("pedido") + ";" + Eval("idbulto") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
         <div class="row">
            <div class="col-sm-2 col-md-offset-1">
                   <asp:Button ID="btnConsolidar" runat="server" Text="Consolidar" CssClass="btn btn-success" Width="200px" OnClick="btnConsolidar_Click" />
            </div>
        </div>
        <%-- MODAL VER DETALLE DE UN BULTO --%>
        <div class="modal fade" id="detBulto">
            <div class="modal-dialog modal-lg">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3>Detalle de Pedido</h3>
                                <br />
                            </div>
                            <div class="container"></div>
                            <div class="modal-body">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>Pedido</th>
                                            <th>Bulto</th>
                                            <th>Producto</th>
                                            <th>Descripcion</th>
                                            <th>Cantidad</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Label ID="lbldetallebulto" runat="server" Text=""></asp:Label>
                                    </tbody>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }
        function openInNewTab() {
            window.document.forms[0].target = '_blank'; 
            setTimeout(function () { window.document.forms[0].target = ''; }, 0);
        }   
    </script>
</asp:Content>
