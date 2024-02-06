<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_ingresoMotivos.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_ingresoMotivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Ingreso Motivos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Devolución:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtDatos" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:ImageButton ID="imgB" runat="server" ImageUrl="~/Recursos/images/find.png" OnClick="btnBuscar_Click" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="imgB" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
        <br />
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvCabecera" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor="green">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Devolucion" SortExpression="Dev">
                            <ItemTemplate>
                                <asp:Label ID="lbliddevolucion" runat="server" Text='<%# Bind("iddevolucion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RUC" SortExpression="Ruc">
                            <ItemTemplate>
                                <asp:Label ID="lblidcliente" runat="server" Text='<%# Bind("idcliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cli">
                            <ItemTemplate>
                                <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                            <ItemTemplate>
                                <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vendedor" SortExpression="Vend">
                            <ItemTemplate>
                                <asp:Label ID="lblvendedor" runat="server" Text='<%# Bind("vendedor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observacion" SortExpression="Obs">
                            <ItemTemplate>
                                <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Transporte" SortExpression="Trans">
                            <ItemTemplate>
                                <asp:Label ID="lbltransporte" runat="server" Text='<%# Bind("transporte") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblestado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
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
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor="green" OnRowCommand="gvDetalle_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonField CommandName="detMotivos" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px">
                            <ItemStyle Width="20px" />
                        </asp:ButtonField>
                        <asp:TemplateField HeaderText="Dev" SortExpression="Dev" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbliddevolucion" runat="server" Text='<%# Bind("iddevolucion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Articulo" SortExpression="Art">
                            <ItemTemplate>
                                <asp:Label ID="lblarticulo" runat="server" Text='<%# Bind("articulo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                            <ItemTemplate>
                                <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CantidadReal" SortExpression="Cant">
                            <ItemTemplate>
                                <asp:Label ID="lblcantidadReal" runat="server" Text='<%# Bind("cantidadReal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cant FallaFabrica" SortExpression="CantFab">
                            <ItemTemplate>
                                <asp:Label ID="lblcantFallaFabrica" runat="server" Text='<%# Bind("cantFallaFabrica") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Cant Cuarentena" SortExpression="CantCuarentena">
                            <ItemTemplate>
                                <asp:Label ID="lblcantCuarentena" runat="server" Text='<%# Bind("cantCuarentena") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MotivoDev" SortExpression="MotivoDev">
                            <ItemTemplate>
                                <asp:Label ID="lblmotivo" runat="server" Text='<%# Bind("motivo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--Modal Ingresar Motivos--%>
        <div id="mdMotivos" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="delModalLabel">Motivos</h3>
                    </div>
                    <asp:UpdatePanel ID="upDel" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="text-center">
                                    <h4>
                                        <asp:Label ID="lblhArticulo" runat="server" Text=""></asp:Label></h4>
                                </div>
                                <br />
                                <asp:Label ID="lblMensajeMotivos" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hfDevolucion" runat="server" />
                                <asp:HiddenField ID="hfArticulo" runat="server" />
                                <asp:HiddenField ID="hfCantidadReal" runat="server" />
                                <asp:HiddenField ID="hfCantidadFallaFabrica" runat="server" />
                                <asp:HiddenField ID="hfCantidadCuarentena" runat="server" />
                                <div class="container">
                                    <div class="row">
                                             <label class="col-md-6 col-sm-6 col-xs-12 label label-info">
                                        <h5>Falla de Fabrica:</h5>
                                    </label>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txtObservacionFallaFabrica" runat="server" CssClass="form-control" Width="250px" TextMode="MultiLine" placeholder="Motivo Falla de Fabrica"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txtCantFallaFabrica" runat="server" CssClass="form-control" placeholder="Cantidad" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                         <label class="col-md-6 col-sm-6 col-xs-12 label label-info">
                                        <h5>Cuarentena:</h5>
                                    </label>
                                    </div>
                                   <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txtObservacionCuarentena" runat="server" CssClass="form-control" Width="250px" TextMode="MultiLine" placeholder="Motivo Cuarentena"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txtCantCuarentena" runat="server" CssClass="form-control" placeholder="Cantidad" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" CausesValidation="false" OnClick="btnGuardar_Click" />
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- Efecto Procesando -->
        <asp:UpdateProgress ID="updateProgress" runat="server">
            <ProgressTemplate>
                <div class="updateProgress">
                    <span class="updateProgressHijo">Cargando...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</asp:Content>
