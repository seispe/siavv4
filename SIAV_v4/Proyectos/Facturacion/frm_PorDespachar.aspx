<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_PorDespachar.aspx.cs" Inherits="SIAV_v4.Proyectos.Facturacion.frm_PorDespachar" %>
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
                <h1 class="page-header">Pedidos por Despachar</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvFac" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="pedido" forecolor="#333333"
        gridlines="None"
        allowpaging="True" pagesize="100" 
        AllowSorting="True" OnRowCommand="gvFac_RowCommand" OnPageIndexChanging="gvFac_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/select.png" Text="Editar" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:ButtonField CommandName="deleteRecord" ButtonType="Image" ImageUrl="~/Recursos/images/delete.png" Text="Eliminar" ItemStyle-Width="20px">
            </asp:ButtonField>
            <asp:TemplateField HeaderText="Pedido" SortExpression="pedido">
                <ItemTemplate>
                    <asp:LinkButton ID="lblpedido" runat="server" CommandArgument='<%# Bind("pedido") %>' OnClick="pedido_Click" Text='<%# Bind("pedido") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ruc" SortExpression="ruc_cliente">
                <ItemTemplate>
                    <asp:Label ID="lblruc_cliente" runat="server" Text='<%# Bind("ruc_cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="nom_cliente">
                <ItemTemplate>
                    <asp:Label ID="lblnom_cliente" runat="server" Text='<%# Bind("nom_cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razon Social" SortExpression="soc_cliente">
                <ItemTemplate>
                    <asp:Label ID="lblsoc_cliente" runat="server" Text='<%# Bind("soc_cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ciudad" SortExpression="ciudad">
                <ItemTemplate>
                    <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Num Lineas" SortExpression="num_lineas">
                <ItemTemplate>
                    <asp:Label ID="lblnum_lineas" runat="server" Text='<%# Bind("num_lineas") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Num Items" SortExpression="num_items">
                <ItemTemplate>
                    <asp:Label ID="lblnum_items" runat="server" Text='<%# Bind("num_items") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prioridad" SortExpression="prioridad">
                <ItemTemplate>
                    <asp:Label ID="lblprioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
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

<%--Modal Del Eliminar--%>
<div id="deleteModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="delModalLabel">Eliminar Registro</h3>
            </div>
            <asp:UpdatePanel id="upDel" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <asp:Label ID="lblMensajeDelete" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="HfDeleteID" runat="server" />
                        <br />
                        <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control col-lg-12 col-md-12 col-sm-12"></asp:TextBox>
                        <br /><br />
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-info" CausesValidation="false"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal Datos Devolucion--%>
<div id="devolucionModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="devModalLabel">Detalle Devolucion</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <table class="table">
                        <thead>
                          <tr>
                            <th>Articulo</th>
                            <th>Descripcion</th>
                            <th>Cantidad Original</th>
                            <th>Cantidad Real</th>
                            <th>Motivo Original</th>
                            <th>Motivo Real</th>
                          </tr>
                        </thead>
                        <tbody>
                          <asp:Label ID="lblarticulosdevol" runat="server" Text=""></asp:Label>
                        </tbody>
                      </table>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
<%--Modal Datos Factura--%>
<div id="facturaModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="facModalLabel">Detalle Factura</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <table class="table">
                        <thead>
                          <tr>
                            <th>Articulo</th>
                            <th>Descripcion</th>
                            <th>Cantidad</th>
                          </tr>
                        </thead>
                        <tbody>
                          <asp:Label ID="lblarticulosfact" runat="server" Text="" ></asp:Label>
                        </tbody>
                      </table>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
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
