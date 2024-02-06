<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_cierreiavQ.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiavQ.frm_cierreiavQ" %>
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
                        <h1 class="page-header">Proceso</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR CONSOLIDADO O POR PEDIDO --%>
        <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">CONSOLIDADO</asp:ListItem>
                <asp:ListItem Value="2">PEDIDO</asp:ListItem>
            </asp:RadioButtonList>

        </div>
        <br />
        <%--SELECCIONAR EL CONSOLIDADO A CERRAR--%>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="row">
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                        <h5>Dato:</h5>
                    </label>
                    <div class="col-md-3 col-sm-3 col-xs-12">
                        <asp:TextBox ID="Txt_consolidado" runat="server" CssClass="form-control" Width="200px" placeholder="#consolidado/pedido" ReadOnly="false"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" OnClientClick="clickOnce(this, 'Buscando...')" ValidationGroup="Buscar"
                             UseSubmitBehavior="false" />
                </div>
                <br />
                 <div class="row">
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                        <h5>Tipo:</h5>
                    </label>
                    <div class="col-md-3 col-sm-3 col-xs-12">
                        <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" Width="300px"  ReadOnly="true"></asp:TextBox>
                    </div>
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnCerrar" runat="server" Text="Anular Pedido" CssClass="btn btn-success" Width="200px" OnClick="btnCerrarA_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <br />
               <%-- <div style="margin-left: 928px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnCerrar" runat="server" Text="Anular Pedido" CssClass="btn btn-success" Width="200px" OnClick="btnCerrarA_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <%-- GRID DE MAESTRO DE PEDIDOS CABECERA --%>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvDetallePicking" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
                    AllowSorting="True" HeaderStyle-BackColor="green"
                    PageSize="500" OnSelectedIndexChanged="gvDetallePicking_SelectedIndexChanged" OnRowDataBound="gvDetallePicking_RowDataBound" OnRowCommand="gvDetallePicking_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Recursos/images/grafico.png" SelectText="Seleccionar" ShowSelectButton="true" />
                        <%--<asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="AnularPedido" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="Warn()" />
              </ItemTemplate>
            </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Cons" SortExpression="Consol">
                            <ItemTemplate>
                                <asp:Label ID="lblnumconsolidado" runat="server" Text='<%# Bind("numconsolidado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lblfechapedido" runat="server" Text='<%# Bind("fechapedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblrazonsocial" runat="server" Text='<%# Bind("razonsocial") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad" SortExpression="Ciudad">
                            <ItemTemplate>
                                <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                            <ItemTemplate>
                                <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Coordenada" SortExpression="Coordenada">
                            <ItemTemplate>
                                <asp:Label ID="lblcoordenada" runat="server" Text='<%# Bind("coordenada") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                            <ItemTemplate>
                                <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No Stock" SortExpression="No Stock">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgCoor" CommandName="DarCoordenadas" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/add.png" runat="server" Height="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Etapa" SortExpression="Etapa">
                            <ItemTemplate>
                                <asp:Label ID="lbletapa" runat="server" Text='<%# Bind("etapa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Estado" SortExpression="Estado" >
                    <ItemTemplate>
                        <asp:Label ID="lblcerrado" runat="server" Text='<%# Bind("cerrado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:BoundField DataField="cerrado" HeaderText="Estado" Visible="true" />
                        <asp:BoundField DataField="can_solicitada" HeaderText="Solicitada" Visible="true" />
                        <asp:BoundField DataField="can_procesada" HeaderText="Procesada" Visible="true" />
                        <asp:TemplateField HeaderText="Pendiente" SortExpression="Pendiente">
                            <ItemTemplate>
                                <asp:Label ID="lblcan_pendiente" runat="server" Text='<%# Bind("can_pendiente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="can_armada" HeaderText="Armada" Visible="true" />
                        <asp:TemplateField HeaderText="Bultos" SortExpression="Bultos">
                            <ItemTemplate>
                                <asp:Label ID="lblbultos" runat="server" Text='<%# Bind("bultos") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                            <ItemTemplate>
                                <asp:Label ID="lblusuarioarmo" runat="server" Text='<%# Bind("usuarioarmo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- MODAL INGRESAR OBSERVACIONES DE ANULACIONES --%>
        <div class="modal fade" id="obsAnula" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="obsAnulaC">Ingrese una Observación</h3>
                                <asp:HiddenField ID="hfConsolidado" runat="server" />
                                <br />
                            </div>
                            <div class="container"></div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-3 col-sm-3 col-xs-12">
                                        <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnAnular" runat="server" Text="Anular Pedido" CssClass=" btn btn-success" OnClick="btnAnular_Click" />
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAnular" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
         <%-- MODAL INGRESAR OBSERVACIONES DE ITEMS CERRADOS --%>
        <div class="modal fade" id="obsCierra" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="obsCierraC">Ingrese una Observación</h3>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <br />
                            </div>
                            
                            <div class="modal-body">
                                <div class="container">
                                <div class="row">
                                   <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <%--<asp:TextBox ID="txtObservacionC" runat="server" CssClass="form-control" Width="350px" TextMode="MultiLine"></asp:TextBox>--%>
                                        <asp:DropDownList id="ddlmotCierre" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                         <asp:TextBox ID="txtCantCierre" runat="server" CssClass="form-control" placeholder="Cantidad" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                                    </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCerrarItem" runat="server" Text="Cerrar Item" CssClass="btn btn-success" OnClick="btnCerrarItem_Click" OnClientClick="clickOnce(this, 'Cerrando...')" ValidationGroup="Cerrar Item"
                             UseSubmitBehavior="false" />
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCerrarItem" />
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
    </script>
</asp:Content>
