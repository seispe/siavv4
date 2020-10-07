<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_Bodega.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_Bodega" %>
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
                <h1 class="page-header">Devoluciones en Bodega</h1>
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
        <asp:gridview id="gvBodega" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="iddevolucion" forecolor="#333333"
        gridlines="None"  OnPageIndexChanging="gvBodega_PageIndexChanging"
        allowpaging="True" pagesize="20" 
        AllowSorting="True" OnRowCommand="gvBodega_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="editRecord" ButtonType="Image" ImageUrl="~/Recursos/images/select.png" Text="Editar" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:ButtonField CommandName="printRecord" ButtonType="Image" ImageUrl="~/Recursos/images/printer.png" Text="Imprimir" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:ButtonField CommandName="deleteRecord" ButtonType="Image" ImageUrl="~/Recursos/images/delete.png" Text="Eliminar" ItemStyle-Width="20px">
            </asp:ButtonField>
            <asp:ButtonField CommandName="mailRecord" ButtonType="Image" ImageUrl="~/Recursos/images/mail.png" Text="Mail" ItemStyle-Width="20px" >
            </asp:ButtonField>
            <asp:TemplateField HeaderText="Id Devolucion" SortExpression="iddevolucion">
                <ItemTemplate>
                    <asp:LinkButton ID="lbliddevolucion" runat="server" CommandArgument='<%# Bind("iddevolucion") %>' OnClick="iddevolucion_Click" Text='<%# Bind("iddevolucion") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Web" SortExpression="idweb">
                <ItemTemplate>
                    <asp:Label ID="lblidweb" runat="server" Text='<%# Bind("idweb") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Ciudad" SortExpression="ciudad">
                <ItemTemplate>
                    <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion" SortExpression="observacion">
                <ItemTemplate>
                    <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bultos" SortExpression="bultos">
                <ItemTemplate>
                    <asp:Label ID="lblbultos" runat="server" Text='<%# Bind("bultos") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pedido" SortExpression="pedido">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
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
<%--Modal Del Mail--%>
<div id="mailModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="mailModalLabel">Enviar Correo al Cliente y Vendedor.</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <asp:Label ID="lblMailDelete" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="HfMailID" runat="server" />
                        <br />Asunto:
                        <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control col-lg-12 col-md-12 col-sm-12"></asp:TextBox>
                        <br />Contenido:
                        <asp:TextBox ID="txtContenidoMail" runat="server" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control col-lg-12 col-md-12 col-sm-12"></asp:TextBox>
                        <br /><br /><br /><br /><br /><br /><br /><br />
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnMail" runat="server" Text="Enviar Mail" OnClick="btnMail_Click" CssClass="btn btn-info" CausesValidation="false"/>
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
    <div class="modal-dialog modal-lg">
        <div class="modal-content" style="width: 800px;">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="devModalLabel">Detalle Devolucion</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <asp:gridview id="gvEditar" runat="server" autogeneratecolumns="False" cellpadding="4" 
                        cssclass="grid" datakeynames="iddetalle" forecolor="#333333"
                        gridlines="None" OnRowDataBound="OnRowDataBound"
                        allowpaging="True" pagesize="10" >
                        <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="iddetalle" SortExpression="iddetalle" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbliddetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                            
                                <asp:TemplateField HeaderText="Articulo" SortExpression="articulo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblarticulo" runat="server" Text='<%# Bind("articulo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="cantOriginal" SortExpression="cantidadOriginal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcantidadOriginal" runat="server" Text='<%# Bind("cantidadOriginal") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="motiOriginal" SortExpression="motiOriginal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmotiOriginal" runat="server" Text='<%# Bind("motiOriginal") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="cantReal" SortExpression="cantidadReal">
                                    <ItemTemplate>
                                        <asp:Textbox ID="txtcantidadReal" Width="50px" runat="server" Text='<%# Bind("cantidadReal") %>'></asp:Textbox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="motiReal" SortExpression="motiReal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMotivos" runat="server" Text='<%# Bind("motiReal") %>' Visible = "false" />
                                        <asp:DropDownList ID="ddlMotivos" runat="server"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>     
                                  <asp:TemplateField HeaderText="Observacion" SortExpression="Observacion">
                                    <ItemTemplate>
                                        <asp:Textbox ID="txtObservacion" TextMode="MultiLine" runat="server" Text='<%# Bind("observacion") %>'></asp:Textbox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        </asp:gridview>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Cssclass="btn btn-success" OnClick="btnGuardar_Click"/> 
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
            <span class="updateProgressHijo"><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/cargando.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> 
</form>
</asp:Content>
