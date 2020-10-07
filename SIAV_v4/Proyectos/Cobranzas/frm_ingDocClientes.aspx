<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_ingDocClientes.aspx.cs" Inherits="SIAV_v4.Proyectos.Cobranzas.frm_ingDocClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">CheckList Documentos Clientes</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%--Buscar--%>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel with-nav-tabs panel-info">
                        <div class="panel-heading">
                            <ul class="nav nav-tabs">
                                <li><a href="#tab1nuevo" data-toggle="tab">Registrar Cliente</a></li>
                                <li><a href="#tab2antiguo" data-toggle="tab">Seleccionar Cliente</a></li>
                            </ul>
                        </div>
                        <div class="panel-body">
                            <div class="tab-content">
                                <div class="tab-pane fade" id="tab1nuevo">
                                    <div class="form-row">
                                        <div class="col-md-4 mb-4">
                                            <label for="txtCliente">CLIENTE</label>
                                            <asp:TextBox ID="txtCliente" runat="server" Class="form-control" placeholder="Nombre Cliente" Width="350px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 mb-2">
                                            <label for="txtRucnuevo">RUC</label>
                                            <asp:TextBox ID="txtRucnuevo" runat="server" Class="form-control" placeholder="Ruc"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 mb-2">
                                            <label for="txtVendedor">VENDEDOR</label>
                                            <asp:TextBox ID="txtVendedor" runat="server" Class="form-control" placeholder="Código"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 mb-2">
                                            <label for="txtVendedor">FECHA SOLICITUD</label>
                                            <asp:TextBox ID="txtfSolicitud" runat="server" Class="form-control" Enabled="true"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 mb-2">
                                            <label for="txtVendedor">FECHA RECIBO</label>
                                            <asp:TextBox ID="txtfRecibo" runat="server" Class="form-control" Enabled="true"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <div class="col-md-4 mb-4">
                                            <label for="txtVendedor">Observación</label>
                                            <asp:TextBox ID="txtObservacionCliente" runat="server" Class="form-control" Enabled="true" Width="350px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 mb-2">
                                            <label for="txtVendedor">&nbsp;</label>
                                            <asp:UpdatePanel ID="updatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnGuardarCliente" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardarCliente_Click" autopostback="true" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGuardarCliente" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab2antiguo">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div id="custom-search-input">
                                                    <div class="input-group col-md-6">
                                                        <asp:TextBox ID="txtRUC" runat="server" type="text" class="form-control input-md" placeholder="RUC/CLIENTE"></asp:TextBox>
                                                        <span class="input-group-btn">
                                                            <asp:UpdatePanel ID="updatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <button class="btn btn-info btn-md" id="btnBuscarCli" type="button" runat="server" onserverclick="BuscarCliente">
                                                                        <i class="fa fa-search"></i>
                                                                    </button>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="btnBuscarCli" EventName="serverclick" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </span>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="False" CellPadding="8"
                                                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000"
                                                    OnRowCommand="gvCliente_RowCommand">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/edit.png" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ruc" SortExpression="Ruc">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblruc" runat="server" Text='<%# Bind("ruc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Vendedor" SortExpression="Vendedor">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcod_ven" runat="server" Text='<%# Bind("cod_ven") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvCliente" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel with-nav-tabs panel-info">
                        <div class="panel-heading">
                            <ul class="nav nav-tabs">
                                <li><a href="#tab1success" data-toggle="tab">Persona Natural</a></li>
                                <li><a href="#tab2success" data-toggle="tab">Persona Jurídica</a></li>
                            </ul>
                        </div>
                        <div class="panel-body">
                            <div class="tab-content">
                                <div class="tab-pane fade" id="tab1success">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvPN" runat="server" AutoGenerateColumns="False" CellPadding="8"
                                                AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Persona Natural" SortExpression="PN" HeaderStyle-Width="550px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="Ob">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtObservacionPN" runat="server" Text='<%# Bind("observacion") %>' class="form-control" Height="22px" Width="210px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" type="checkbox" runat="server" Checked='<%# Eval("checked").ToString()=="1" ? true : false %>' AutoPostBack="false" Enabled='<%# Eval("checked").ToString()=="1" ? false : true %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvPN" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="updatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnGuardarPN" runat="server" Class="btn btn-success" Text="Guardar" OnClick="btnGuardarPN_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardarPN" EventName="click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade" id="tab2success">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvPJ" runat="server" AutoGenerateColumns="False" CellPadding="8"
                                                AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Persona Jurídica" SortExpression="PJ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="Ob">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtObservacionPJ" runat="server" Text='<%# Bind("observacion") %>' class="form-control" Height="22px" Width="210px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" type="checkbox" runat="server" Checked='<%# Eval("checked").ToString()=="1" ? true : false %>' AutoPostBack="false" Enabled='<%# Eval("checked").ToString()=="1" ? false : true %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvPJ" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="updatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnGuardarPJ" runat="server" Class="btn btn-success" Text="Guardar" OnClick="btnGuardarPJ_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardarPJ" EventName="click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel with-nav-tabs panel-info">
                        <div class="panel-heading">
                            <ul class="nav nav-tabs">
                                <li><a href="#tab1analisis" data-toggle="tab">Análisis del Crédito</a></li>
                            </ul>
                        </div>
                        <div class="panel-body">
                            <div class="tab-content">
                                <div class="tab-pane fade" id="tab1analisis">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvAnalisis" runat="server" AutoGenerateColumns="False" CellPadding="8"
                                                AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Análisis Crédito" SortExpression="AC" HeaderStyle-Width="550px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observación" SortExpression="Ob">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtObservacionAC" runat="server" Text='<%# Bind("observacion") %>' class="form-control" Height="22px" Width="210px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" type="checkbox" runat="server" Checked='<%# Eval("checked").ToString()=="1" ? true : false %>' AutoPostBack="false" Enabled='<%# Eval("checked").ToString()=="1" ? false : true %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvAnalisis" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="updatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnGuardarAC" runat="server" Class="btn btn-success" Text="Guardar" OnClick="btnGuardarAC_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardarAC" EventName="click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel with-nav-tabs panel-info">
                        <div class="panel-heading">
                            <ul class="nav nav-tabs">
                                <li><a href="#tab1cierre" data-toggle="tab">Cierre</a></li>
                                <li><a href="#tab2estado" data-toggle="tab">Estado Cierre</a></li>
                            </ul>
                        </div>
                        <div class="panel-body">
                            <div class="tab-content">
                                <div class="tab-pane fade" id="tab1cierre">
                                    <div class="form-row">
                                        <div class="container">
                                            <div class="col-md-3 mb-3">
                                                <asp:TextBox ID="txtObservacionCierre" runat="server" TextMode="MultiLine" Rows="2" placeholder="observaciones" class="form-control" Width="255px"></asp:TextBox>
                                            </div>
                                            <asp:UpdatePanel ID="updatePanel12" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnAceptarSolicitud" runat="server" Text="ACEPTAR" class="btn btn-success btn-lg" OnClick="btnAceptarSolicitud_Click" />
                                                    <asp:Button ID="btnRechazarSolicitud" runat="server" Text="RECHAZAR" class="btn btn-danger btn-lg" OnClick="btnRechazarSolicitud_Click" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAceptarSolicitud" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnRechazarSolicitud" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab2estado">
                                     <div class="container">
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvEstadoCierre" runat="server" AutoGenerateColumns="False" CellPadding="8"
                                                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/edit.png" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblestado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Observacion" SortExpression="Observacion">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblobservacioningreso" runat="server" Text='<%# Bind("observacioningreso") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfingreso" runat="server" Text='<%# Bind("fingreso") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuarioingreso") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvCliente" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- MODAL DE ACTUALIZAR --%>
        <div id="detCliente" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="facModalLabel">Actualizar Datos del Cliente</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <%--<label class="control-label" for="inputSuccess">Destino</label>--%>
                                        <asp:Label runat="server" ID="lblDestinoOC" CssClass="control-label" Font-Bold="true">RUC</asp:Label>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                        <asp:TextBox ID="txtRucActualiza" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:HiddenField ID="hfRucActualiza" runat="server" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <%--<label class="control-label" for="inputSuccess">Destino</label>--%>
                                        <asp:Label runat="server" ID="Label1" CssClass="control-label" Font-Bold="true">CLIENTE</asp:Label>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                        <asp:TextBox ID="txtClienteActualiza" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <%--<label class="control-label" for="inputSuccess">Destino</label>--%>
                                        <asp:Label runat="server" ID="Label2" CssClass="control-label" Font-Bold="true">VENDEDOR</asp:Label>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                        <asp:TextBox ID="txtVendedorActualiza" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnGuardarR" runat="server" Text="Guardar" OnClick="btnGuardarR_Click" CssClass="btn btn-success" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar"
                                    UseSubmitBehavior="false" />
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
        <asp:UpdateProgress ID="updateProgress" runat="server">
            <ProgressTemplate>
                <div class="updateProgress">
                    <span class="updateProgressHijo">Cargando...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked check all checkboxes and highlight all rows
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked uncheck all checkboxes and change rowcolor back to original
                        inputList[i].checked = false;
                    }
                }
            }
        }
        function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }

        $(document).ready(function () {
            var dp = $("#<%=txtfSolicitud.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
            var dp = $("#<%=txtfRecibo.ClientID%>");
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
