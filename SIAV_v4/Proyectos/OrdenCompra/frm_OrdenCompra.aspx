<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_OrdenCompra.aspx.cs" Inherits="SIAV_v4.Proyectos.OrdenCompra.frm_OrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/OrdenCompra/css_tabs.css" rel="stylesheet" />
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
                <h1 class="page-header">Ingresar Facturas a OCL</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<div class="row">
    <div class="col-md-offset-3 col-md-6">
        <div class="panel with-nav-tabs panel-primary">
            <div class="panel-heading">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#tab1primary" data-toggle="tab">IAV</a></li>
                        <li><a href="#tab2primary" data-toggle="tab">CORPAL</a></li>
                        <li><a href="#tab3primary" data-toggle="tab">RECTIMA</a></li>
                    </ul>
            </div>
            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1primary">
                    <!-- Panel 1 Inicio -->
                        <%-- Buscar Inicio--%>
                        <div class="buscar">
                          <div class="form-group">
                            <div class="row">
                                <label class="control-label col-lg-6 col-md-6 col-sm-6 col-xs-4">Factura / Pedido / Bodega:</label>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-8">
                                    <asp:TextBox ID="txtBuscar" runat="server" Enabled="True" class="form-control" placeholder="Factura / Pedido / Bodega"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <br />
                                    <asp:UpdatePanel id="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Cssclass="btn btn-success" OnClick="btnBuscar_Click" CausesValidation="false"/>     
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"/>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                          </div> 
                        </div>  
                        <%-- Buscar Fin--%>
                        <asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:gridview id="gvImportadora" runat="server"
                                autogeneratecolumns="False" cellpadding="4"
                                cssclass="grid" datakeynames="factura" forecolor="#333333"
                                gridlines="None" OnPageIndexChanging="gvImportadora_PageIndexChanging" OnRowCommand="gvImportadora_RowCommand"
                                allowpaging="True" pagesize="100" 
                                AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/select.png" Text="Editar" ItemStyle-Width="20px" >
                                    </asp:ButtonField>
                                      <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                                        <ItemTemplate>
                                     <asp:LinkButton ID="lnkfact" runat="server" OnClick="Lnkfact_Click" Text='<%# Eval("factura") %>' CommandArgument='<%# Bind("factura") %>' />
                                        </ItemTemplate>
                                </asp:TemplateField> 
                                <%--    <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bodega" SortExpression="bodega">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbodega" runat="server" Text='<%# Bind("bodega") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pedido" SortExpression="pedido">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" SortExpression="total">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("total") %>'></asp:Label>
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
                    <!-- Panel 1 Fin -->
                    </div>
                    <div class="tab-pane fade" id="tab2primary">
                    <!-- Panel 2 Inicio -->
                        <%-- Buscar Inicio--%>
                        <div class="buscar">
                          <div class="form-group">
                            <div class="row">
                                <label class="control-label col-lg-6 col-md-6 col-sm-6 col-xs-4">Factura / Pedido / Bodega:</label>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-8">
                                    <asp:TextBox ID="txtBuscarCorpal" runat="server" Enabled="True" class="form-control" placeholder="Factura / Pedido / Bodega"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <br />
                                    <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:Button ID="btnBuscarCorpal" runat="server" Text="Buscar" Cssclass="btn btn-success" OnClick="btnBuscarCorpal_Click" CausesValidation="false"/>     
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnBuscarCorpal" EventName="Click"/>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                          </div> 
                        </div>  
                        <%-- Buscar Fin--%>
                        <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:gridview id="gvCorpal" runat="server"
                                autogeneratecolumns="False" cellpadding="4"
                                cssclass="grid" datakeynames="factura" forecolor="#333333"
                                gridlines="None" OnPageIndexChanging="gvCorpal_PageIndexChanging" OnRowCommand="gvCorpal_RowCommand"
                                allowpaging="True" pagesize="100" 
                                AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/select.png" Text="Editar" ItemStyle-Width="20px" >
                                    </asp:ButtonField>
                                <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                                        <ItemTemplate>
                                     <asp:LinkButton ID="lnkfactcorpal" runat="server" OnClick="Lnkfactcorpal_Click" Text='<%# Eval("factura") %>' CommandArgument='<%# Bind("factura") %>' />
                                        </ItemTemplate>
                                </asp:TemplateField> 
                                  <%--  <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bodega" SortExpression="bodega">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbodega" runat="server" Text='<%# Bind("bodega") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pedido" SortExpression="pedido">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" SortExpression="total">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("total") %>'></asp:Label>
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
                    <!-- Panel 2 Fin -->
                    </div>
                    <div class="tab-pane fade" id="tab3primary">
                    <!-- Panel 2 Inicio -->
                        <%-- Buscar Inicio--%>
                        <div class="buscar">
                          <div class="form-group">
                            <div class="row">
                                <label class="control-label col-lg-6 col-md-6 col-sm-6 col-xs-4">Factura / Pedido / Bodega:</label>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-8">
                                    <asp:TextBox ID="txtBuscarRectima" runat="server" Enabled="True" class="form-control" placeholder="Factura / Pedido / Bodega"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <br />
                                    <asp:UpdatePanel id="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:Button ID="btnBuscarRectima" runat="server" Text="Buscar" Cssclass="btn btn-success" OnClick="btnBuscarRectima_Click" CausesValidation="false"/>     
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnBuscarRectima" EventName="Click"/>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                          </div> 
                        </div>  
                        <%-- Buscar Fin--%>
                        <asp:UpdatePanel id="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:gridview id="gvRectima" runat="server"
                                autogeneratecolumns="False" cellpadding="4"
                                cssclass="grid" datakeynames="factura" forecolor="#333333"
                                gridlines="None" OnPageIndexChanging="gvRectima_PageIndexChanging" OnRowCommand="gvRectima_RowCommand"
                                allowpaging="True" pagesize="100" 
                                AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/select.png" Text="Editar" ItemStyle-Width="20px" >
                                    </asp:ButtonField>
                                    <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkfactrectima" runat="server" OnClick="Lnkfactrectima_Click" Text='<%# Eval("factura") %>' CommandArgument='<%# Bind("factura") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bodega" SortExpression="bodega">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbodega" runat="server" Text='<%# Bind("bodega") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pedido" SortExpression="pedido">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" SortExpression="total">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("total") %>'></asp:Label>
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
                    <!-- Panel 2 Fin -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<br />
<%--Modal Crear Orden Compra Importadora--%>
<div id="oclImportadoraModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3>Crear Orden de Compra</h3>
            </div>
            <asp:UpdatePanel id="upDel" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <asp:Label ID="lblMensajeImportadora" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="HfImportadora" runat="server" />
                        <br />
                        <h3>Selecciona la Bodega:</h3>
                        <asp:DropDownList ID="ddlBodegaIAV" class="form-control" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Selected="True" Value="PVA1">PVA1</asp:ListItem>
                            <asp:ListItem Value="PVA2">PVA2</asp:ListItem>
                            <asp:ListItem Value="PVG1">PVG1</asp:ListItem>
                            <asp:ListItem Value="PVQ1">PVQ1</asp:ListItem>
                            <asp:ListItem Value="PVQ2">PVQ2</asp:ListItem>
                            <asp:ListItem Value="PVQ4">PVQ4</asp:ListItem>
                            <asp:ListItem Value="PVQ5">PVQ5</asp:ListItem>
                            <asp:ListItem Value="PVS1">PVS1</asp:ListItem>
                            <asp:ListItem Value="PVGS">PVGS</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                      <%--  <h3>Tipo de OC:</h3>
                        <asp:DropDownList ID="ddlTipoIAV" class="form-control" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Selected="True" Value="Abastecimiento">ABASTECIMIENTO</asp:ListItem>
                            <asp:ListItem Value="Puntual">PUNTUAL</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <h3>Responsable de la compra:</h3>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-8">
                            <asp:TextBox ID="txtResponsableIAV" runat="server" Enabled="True" class="form-control" placeholder="compradores" Width="250px"></asp:TextBox>
                        </div>
                        <br />--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnCrearImportadora" runat="server" Text="Generar" OnClick="btnCrearImportadora_Click" CssClass="btn btn-info" CausesValidation="false"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCrearImportadora" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal Crear Orden Compra Corpal--%>
<div id="oclCorpalModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3>Crear Orden de Compra</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <asp:Label ID="lblMensajeCorpal" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="HfCorpal" runat="server" />
                        <br />
                        <h3>Selecciona la Bodega:</h3>
                        <asp:DropDownList ID="ddlBodegaCORPAL" class="form-control" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Selected="True" Value="PVA1">PVA1</asp:ListItem>
                            <asp:ListItem Value="PVA2">PVA2</asp:ListItem>
                            <asp:ListItem Value="PVG1">PVG1</asp:ListItem>
                            <asp:ListItem Value="PVQ1">PVQ1</asp:ListItem>
                            <asp:ListItem Value="PVQ2">PVQ2</asp:ListItem>
                            <asp:ListItem Value="PVQ4">PVQ4</asp:ListItem>
                            <asp:ListItem Value="PVQ5">PVQ5</asp:ListItem>
                            <asp:ListItem Value="PVS1">PVS1</asp:ListItem>
                            <asp:ListItem Value="PVGS">PVGS</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                      <%--   <h3>Tipo de OC:</h3>
                        <asp:DropDownList ID="ddlTipoCorpal" class="form-control" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Selected="True">ABASTECIMIENTO</asp:ListItem>
                            <asp:ListItem>PUNTUAL</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <h3>Responsable de la compra:</h3>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-8">
                            <asp:TextBox ID="txtResponsableCorpal" runat="server" Enabled="True" class="form-control" placeholder="compradores"></asp:TextBox>
                        </div>
                        <br />--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnCrearCorpal" runat="server" Text="Generar" OnClick="btnCrearCorpal_Click" CssClass="btn btn-info" CausesValidation="false"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCrearCorpal" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal Crear Orden Compra Rectima--%>
<div id="oclRectimaModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3>Crear Orden de Compra</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <asp:Label ID="lblMensajeRectima" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="HfRectima" runat="server" />
                        <br />
                        <h3>Selecciona la Bodega:</h3>
                        <asp:DropDownList ID="ddlBodegaRectima" class="form-control" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Selected="True" Value="PVA1">PVA1</asp:ListItem>
                            <asp:ListItem Value="PVA2">PVA2</asp:ListItem>
                            <asp:ListItem Value="PVG1">PVG1</asp:ListItem>
                            <asp:ListItem Value="PVQ1">PVQ1</asp:ListItem>
                            <asp:ListItem Value="PVQ2">PVQ2</asp:ListItem>
                            <asp:ListItem Value="PVQ4">PVQ4</asp:ListItem>
                            <asp:ListItem Value="PVQ5">PVQ5</asp:ListItem>
                            <asp:ListItem Value="PVS1">PVS1</asp:ListItem>
                            <asp:ListItem Value="PVGS">PVGS</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <%-- <h3>Tipo de OC:</h3>
                        <asp:DropDownList ID="ddlTipoRectima" class="form-control" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Selected="True">ABASTECIMIENTO</asp:ListItem>
                            <asp:ListItem>PUNTUAL</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <h3>Responsable de la compra:</h3>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-8">
                            <asp:TextBox ID="txtResponsableRectima" runat="server" Enabled="True" class="form-control" placeholder="compradores"></asp:TextBox>
                        </div>
                        <br />--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnCrearRectima" runat="server" Text="Generar" OnClick="btnCrearRectima_Click" CssClass="btn btn-info" CausesValidation="false"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCrearRectima" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
    <%-- MODAL VER DETALLE DE UN FACTURA --%>
    <div id="detFactura" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3>Detalle de Factura</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                          <table class="table">
                        <thead>
                          <tr>
                            <th>COD FACTURA</th>
                            <th>COD ALLPARTS</th>
                          </tr>
                        </thead>
                        <tbody>
                          <asp:Label ID="lbldetalleped" runat="server" Text=""></asp:Label>
                        </tbody>
                      </table>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
    
<!-- Efecto Procesando -->
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div class="updateProgress">
            <span class="updateProgressHijo">Cargando...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> 
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
