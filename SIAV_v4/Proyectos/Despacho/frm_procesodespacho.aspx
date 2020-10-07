<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_procesodespacho.aspx.cs" Inherits="SIAV_v4.Proyectos.Despacho.frm_procesodespacho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/Despacho/css_check.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/Despacho/css_process.css" rel="stylesheet" />
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/Despacho/js_process.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Ciclo de Vida Despacho</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
        <div class="row">
            <asp:Button runat="server" ID="btnrefrescar" CssClass="btn btn-success" Text="Actualizar" OnClick="btnrefrescar_Click" />
        </div>
        <div class="row">
            <div class="container">
                <div class="row col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="process">
                        <div class="process-row nav nav-tabs">
                            <% Permisos("BTNAUTOMATICOS"); %>                            
                            <% Permisos("GPACKING"); %>                            
                            <% Permisos("GBODEGA"); %>                            
                            <% Permisos("GLOGISTICA"); %>                            
                            <% Permisos("GCLIENTE"); %>                            
                        </div>
                    </div>
                    <div class="tab-content">
                        <div id="menu1" class="tab-pane fade">
                            <h3>Gestión Cobranzas</h3>
                            <div class="container">
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvCobranza" runat="server"
                                                AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                                GridLines="None"
                                                AllowPaging="True" PageSize="15"
                                                AllowSorting="True" OnPageIndexChanging="gvCobranza_PageIndexChanging">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" SortExpression="Id Detalle" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Estado" SortExpression="Id Estado" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Cobranzas" SortExpression="Id Cobranzas">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <ul class="list-unstyled list-inline pull-right">
                                <li>
                                    <button type="button" class="btn btn-info next-step">Siguiente <i class="fa fa-chevron-right"></i></button>
                                </li>
                            </ul>
                        </div>
                        <div id="menu2" class="tab-pane fade">
                            <h3>Gestión Pedido</h3>
                            <div class="container">
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvPedido" runat="server"
                                                AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                                GridLines="None"
                                                AllowPaging="True" PageSize="15"
                                                AllowSorting="True" OnPageIndexChanging="gvPedido_PageIndexChanging" >
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" SortExpression="Id Gestion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbliddetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Maestro" SortExpression="Id Estado" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <ul class="list-unstyled list-inline pull-right">
                                <li>
                                    <button type="button" class="btn btn-default prev-step"><i class="fa fa-chevron-left"></i>Atras</button></li>
                                <li>
                                    <button type="button" class="btn btn-info next-step">Siguiente <i class="fa fa-chevron-right"></i></button>
                                </li>
                            </ul>
                        </div>
                        <div id="menu4" class="tab-pane fade">
                            <h3>Gestión Factura Contabilizada</h3>
                            <div class="container">
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvFacConta" runat="server"
                                                AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                                GridLines="None"
                                                AllowPaging="True" PageSize="15"
                                                AllowSorting="True" OnPageIndexChanging="gvFacConta_PageIndexChanging">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" SortExpression="Id Detalle" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbliddetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Maestro" SortExpression="Id Maestro" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <ul class="list-unstyled list-inline pull-right">
                                <li>
                                    <button type="button" class="btn btn-default prev-step"><i class="fa fa-chevron-left"></i>Atras</button></li>
                                <li>
                                    <button type="button" class="btn btn-info next-step">Siguiente <i class="fa fa-chevron-right"></i></button>
                                </li>
                            </ul>
                        </div>
                        <div id="menu5" class="tab-pane fade">
                            <h3>Gestión Packing</h3>
                            <div class="container">
                                <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvPacking" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                            GridLines="None"
                                            AllowPaging="True" PageSize="15"
                                            AllowSorting="True" OnRowCommand="gvPacking_RowCommand" OnPageIndexChanging="gvPacking_PageIndexChanging">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField CommandName="imprimePacking" ButtonType="Image" ImageUrl="~/Recursos/images/printer2.png" Text="Observación" ItemStyle-Width="5px"></asp:ButtonField>
                                                    <asp:TemplateField HeaderText="#" SortExpression="Id Detalle" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbliddetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id Maestro" SortExpression="Id Maestro" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Factura" SortExpression="Factura" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                         </div>
                        <div id="menu6" class="tab-pane fade">
                            <h3>Gestión Bodega</h3>
                            <div class="container">
                                 <ul class="nav nav-tabs nav-justified" >
			                                <li class="empaque"><a href="#empaque" data-toggle="tab">Empaque</a></li>
			                                <li class="despacho"><a href="#despacho" data-toggle="tab">Despacho</a></li>
			                     </ul>
                                <div class="tab-content">
                                    <div class="tab-pane fade" id="empaque">
                                        <br />
                                         <asp:UpdatePanel ID="UpdatePanel7" runat="server" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                         <asp:GridView ID="gvEmpaqueBod" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                            GridLines="None"
                                            AllowPaging="True" PageSize="15"
                                            AllowSorting="True" OnPageIndexChanging="gvEmpaqueBod_PageIndexChanging" >
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" SortExpression="Id Detalle" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id Maestro" SortExpression="Id Estado" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        </asp:GridView>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="tab-pane fade" id="despacho">
                                        <br />
                                          <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvDespachoBod" runat="server"
                                                AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                                GridLines="None"
                                                AllowPaging="True" PageSize="15"
                                                AllowSorting="True" OnPageIndexChanging="gvDespachoBod_PageIndexChanging" >
                                                <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" SortExpression="Id Detalle" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id Maestro" SortExpression="Id Estado" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        </asp:GridView>
                                        </ContentTemplate>
                                              </asp:UpdatePanel>
                                         </div>
                            </div>
                        </div>
                            </div>
                        <div id="menu7" class="tab-pane fade">
                            <h3>Gestión Logística</h3>
                            <div class="container ">
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvLogistica" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                            GridLines="None"
                                            AllowPaging="True" PageSize="10"
                                            AllowSorting="True" OnRowCommand="gvLogistica_RowCommand" OnPageIndexChanging="gvLogistica_PageIndexChanging">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField CommandName="imprimeNE" ButtonType="Image" ImageUrl="~/Recursos/images/printer2.png" ItemStyle-Width="20px"></asp:ButtonField>
                                                    <asp:TemplateField HeaderText="#" SortExpression="Id Detalle" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id Estado" SortExpression="Id Estado" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div id="menu8" class="tab-pane fade">
                            <h3>Gestión Cliente</h3>
                            <div class="container">
                                <div class="row">
                                   <asp:UpdatePanel ID="UpdatePanel9" runat="server" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvCliente" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="grid" DataKeyNames="iddetalle" ForeColor="#333333"
                                            GridLines="None"
                                            AllowPaging="True" PageSize="10"
                                            AllowSorting="True" OnRowCommand="gvCliente_RowCommand" OnPageIndexChanging="gvCliente_PageIndexChanging">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonField CommandName="obserCliente" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" ItemStyle-Width="20px"></asp:ButtonField>
                                                    <asp:TemplateField HeaderText="#" SortExpression="Id Gestion" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidetalle" runat="server" Text='<%# Bind("iddetalle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Proceso" SortExpression="Id Proceso" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidproceso" runat="server" Text='<%# Bind("idproceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id Mestro" SortExpression="Id Estado" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblidmaestro" runat="server" Text='<%# Bind("idmaestro") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Inicio" SortExpression="Fecha Inicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaInigestion" runat="server" Text='<%# Bind("fechaInigestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Fin" SortExpression="Fecha Fin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfechaFingestion" runat="server" Text='<%# Bind("fechaFingestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Usuario" SortExpression="usuario">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo" SortExpression="activo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblactivo" runat="server" Text='<%# Bind("activo") %>'></asp:Label>
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
                                    <ul class="list-unstyled list-inline pull-right">
                                        <li>
                                            <button type="button" class="btn btn-success"><i class="fa fa-check"></i>Finalizado</button></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <%--Modal Observaciones--%>
        <div id="observModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="delModalLabel">Ingresar Observación (OPCIONAL)</h3>
                    </div>
                    <asp:UpdatePanel ID="upDel" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <asp:Label ID="lblMensajeDelete" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="HfDeleteID" runat="server" />
                                <br />
                                <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control col-lg-12 col-md-12 col-sm-12"></asp:TextBox>
                                <br />
                                <br />
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click" CssClass="btn btn-info" CausesValidation="false" />
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <%--<asp:AsyncPostBackTrigger ControlID="btnFinalizar" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
<!-- Efecto Procesando -->
<%--<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div class="updateProgress">
            <span class="updateProgressHijo"><img src="/SIAV_v4/Recursos/images/cargando.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>  --%>
    </form>
</asp:Content>
