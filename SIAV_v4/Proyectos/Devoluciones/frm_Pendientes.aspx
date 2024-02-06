<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_Pendientes.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_Pendientes" %>
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
                <h1 class="page-header">Devoluciones Pendientes</h1>
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
        <asp:gridview id="gvLogistica" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="iddevolucion" forecolor="#333333"
        gridlines="None"
        allowpaging="True" pagesize="100" 
        AllowSorting="True" OnRowCommand="gvLogistica_RowCommand" OnPageIndexChanging="gvLogistica_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/select.png" Text="Editar" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:ButtonField CommandName="deleteRecord" ButtonType="Image" ImageUrl="~/Recursos/images/delete.png" Text="Eliminar" ItemStyle-Width="20px">
            </asp:ButtonField>
            <asp:TemplateField HeaderText="Id Devolucion" SortExpression="iddevolucion">
                <ItemTemplate>
                    <asp:LinkButton ID="lbliddevolucion" runat="server" CommandArgument='<%# Bind("iddevolucion") %>' OnClick="iddevolucion_Click" Text='<%# Bind("iddevolucion") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Web" SortExpression="idweb">
                <ItemTemplate>
                    <%--<asp:Label ID="lblidweb" runat="server" Text='<%# Bind("idweb") %>'></asp:Label>--%>
                    <asp:LinkButton ID="lblidweb" runat="server" CommandArgument='<%# Bind("idweb") %>' Text='<%# Bind("idweb") %>' OnClick="lblidweb_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FechaDevolucion" SortExpression="fechadocumento">
                <ItemTemplate>
                    <asp:Label ID="lblfechadocumento" runat="server" Text='<%# Bind("fechadocumento") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Vendedor" SortExpression="idvendedor">
                <ItemTemplate>
                    <asp:Label ID="lblidvendedor" runat="server" Text='<%# Bind("idvendedor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ruc" SortExpression="idcliente">
                <ItemTemplate>
                    <asp:Label ID="lblidcliente" runat="server" Text='<%# Bind("idcliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NomCliente" SortExpression="nomcliente">
                <ItemTemplate>
                    <asp:Label ID="lblnomcliente" runat="server" Text='<%# Bind("nomcliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderText="Observacion" SortExpression="observacion">
                <ItemTemplate>
                    <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bultos" SortExpression="bultos">
                <ItemTemplate>
                    <asp:Label ID="lblbultos" runat="server" Text='<%# Bind("bultos") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                <ItemTemplate>
                    <asp:LinkButton ID="lblfactura" runat="server" Text='<%# Bind("factura") %>' CommandArgument='<%# Bind("factura") %>' OnClick="factura_Click"></asp:LinkButton>
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
    <%--Modal Detalle Factura--%>
<div id="detalleFactura" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="devDetFact">Detalle Factura</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <table class="table">
                        <thead>
                          <tr>
                            <th>Pedido</th>
                            <th>fechaFactura</th>
                            <th>Ciudad</th>
                          </tr>
                        </thead>
                        <tbody>
                          <asp:Label ID="lbldetallefact" runat="server" Text=""></asp:Label>
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
