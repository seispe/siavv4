<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_GenerarComi.aspx.cs" Inherits="SIAV_v4.Proyectos.Comisiones.frm_GenerarComi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <h1 class="page-header">Generar Comisiones</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<%--Buscar--%>
<div class="buscar">
  <div class="form-group">
    <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Vendedor:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:DropDownList ID="ddlVendedores" class="form-control" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>    
    <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Mes:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:DropDownList id="ddlNewMes" AutoPostBack="false"  runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="0">Seleccione un mes</asp:ListItem>
                <asp:ListItem Value="ENERO"> ENERO </asp:ListItem>
                <asp:ListItem Value="FEBRERO"> FEBRERO </asp:ListItem>
                <asp:ListItem Value="MARZO"> MARZO </asp:ListItem>
                <asp:ListItem Value="ABRIL"> ABRIL </asp:ListItem>
                <asp:ListItem Value="MAYO"> MAYO </asp:ListItem>
                <asp:ListItem Value="JUNIO"> JUNIO </asp:ListItem>
                <asp:ListItem Value="JULIO"> JULIO </asp:ListItem>
                <asp:ListItem Value="AGOSTO"> AGOSTO </asp:ListItem>
                <asp:ListItem Value="SEPTIEMBRE"> SEPTIEMBRE </asp:ListItem>
                <asp:ListItem Value="OCTUBRE"> OCTUBRE </asp:ListItem>
                <asp:ListItem Value="NOVIEMBRE"> NOVIEMBRE </asp:ListItem>
                <asp:ListItem Value="DICIEMBRE"> DICIEMBRE </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Año:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:DropDownList id="ddlNewAño" AutoPostBack="false" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="0">Seleccione el Año</asp:ListItem>
                <asp:ListItem Value="2016"> 2016 </asp:ListItem>
                <asp:ListItem Value="2017"> 2017 </asp:ListItem>
                <asp:ListItem Value="2017"> 2018 </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <br />
            <asp:UpdatePanel id="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:Button ID="btnBuscar" runat="server" Text="Generar" Cssclass="btn btn-success" CausesValidation="false" OnClick="btnBuscar_Click"/>     
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
  </div> 
</div> 
<br /><br />
<div class="container">
    <div class="row">
		<div class="col-md-12">
            <div class="panel with-nav-tabs panel-success">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1success" data-toggle="tab">Resumen</a></li>
                            <li><a href="#tab2success" data-toggle="tab">Detallado</a></li>                            
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1success">
                            <span class = "label label-primary">Comision</span>
                            <%--Grid Comision--%>
                            <asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:gridview id="gvComisiones" runat="server"
                                    autogeneratecolumns="False" cellpadding="4"
                                    cssclass="grid" datakeynames="idComi" forecolor="#333333"
                                    gridlines="None"
                                    allowpaging="True" pagesize="50" 
                                    AllowSorting="True" OnPageIndexChanging="gvComisiones_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="idComi" SortExpression="idComi">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidComi" runat="server" Text='<%# Bind("idComi") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="idVendedor" SortExpression="idVendedor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ruc" SortExpression="ruc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblruc" runat="server" Text='<%# Bind("ruc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cliente" SortExpression="cliente">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Factura" SortExpression="factura">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fechafac" SortExpression="fechafac">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfechafac" runat="server" Text='<%# Bind("fechafac") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fechaefectivizada" SortExpression="fechaefectivizada">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfechaefectivizada" runat="server" Text='<%# Bind("fechaefectivizada") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subtotal" SortExpression="subtotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsubtotal" runat="server" Text='<%# Bind("subtotal") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NotasCredido" SortExpression="notasCredido">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnotasCredido" runat="server" Text='<%# Bind("notasCredido") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Devolucion" SortExpression="devolucion">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldevolucion" runat="server" Text='<%# Bind("devolucion") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NetoComi" SortExpression="netoComi">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnetoComi" runat="server" Text='<%# Bind("netoComi") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comision" SortExpression="comision">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcomision" runat="server" Text='<%# Bind("comision") %>'></asp:Label>
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
                            <span class = "label label-success">Efectividad</span>
                            <%--Grid Efectividad--%>
                            <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:gridview id="gvEfectividad" runat="server"
                                    autogeneratecolumns="False" cellpadding="4"
                                    cssclass="grid" datakeynames="idEfectividad" forecolor="#333333"
                                    gridlines="None"
                                    allowpaging="True" pagesize="20" 
                                    AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="idEfectividad" SortExpression="idEfectividad">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidEfectividad" runat="server" Text='<%# Bind("idEfectividad") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="idVendedor" SortExpression="idVendedor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalCliente" SortExpression="totalCliente">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalCliente" runat="server" Text='<%# Bind("totalCliente") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VentaCliente" SortExpression="ventaCliente">
                                            <ItemTemplate>
                                                <asp:Label ID="lblventaCliente" runat="server" Text='<%# Bind("ventaCliente") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PorceComi" SortExpression="porceComi">
                                            <ItemTemplate>
                                                <asp:Label ID="lblporceComi" runat="server" Text='<%# Bind("porceComi") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PorceComisionar" SortExpression="porceComisionar">
                                            <ItemTemplate>
                                                <asp:Label ID="lblporceComisionar" runat="server" Text='<%# Bind("porceComisionar") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comision" SortExpression="comision">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcomision" runat="server" Text='<%# Bind("comision") %>'></asp:Label>
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
                            <span class = "label label-warning">Devoluciones</span>
                            <%--Grid Devoluciones--%>
                            <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:gridview id="gvDevoluciones" runat="server"
                                    autogeneratecolumns="False" cellpadding="4"
                                    cssclass="grid" datakeynames="idDevolucion" forecolor="#333333"
                                    gridlines="None"
                                    allowpaging="True" pagesize="20" 
                                    AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="idDevolucion" SortExpression="idDevolucion">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidDevolucion" runat="server" Text='<%# Bind("idDevolucion") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="idVendedor" SortExpression="idVendedor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ventaneta" SortExpression="ventaneta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblventaneta" runat="server" Text='<%# Bind("ventaneta") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MontoDevolucion" SortExpression="montoDevolucion">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmontoDevolucion" runat="server" Text='<%# Bind("montoDevolucion") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MontoAlcanzado" SortExpression="montoAlcanzado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmontoAlcanzado" runat="server" Text='<%# Bind("montoAlcanzado") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PorceAceptable" SortExpression="porceAceptable">
                                            <ItemTemplate>
                                                <asp:Label ID="lblporceAceptable" runat="server" Text='<%# Bind("porceAceptable") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PorceComi" SortExpression="porceComi">
                                            <ItemTemplate>
                                                <asp:Label ID="lblporceComi" runat="server" Text='<%# Bind("porceComi") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comision" SortExpression="comision">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcomision" runat="server" Text='<%# Bind("comision") %>'></asp:Label>
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
                            <span class = "label label-danger">Morosidad</span>
                            <%--Grid Morosidad--%>
                            <asp:UpdatePanel id="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:gridview id="gvMorosidad" runat="server"
                                    autogeneratecolumns="False" cellpadding="4"
                                    cssclass="grid" datakeynames="idMosoridad" forecolor="#333333"
                                    gridlines="None"
                                    allowpaging="True" pagesize="20" 
                                    AllowSorting="True" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="idMorosidad" SortExpression="idMosoridad">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidMosoridad" runat="server" Text='<%# Bind("idMosoridad") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="idVendedor" SortExpression="idVendedor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidVendedor" runat="server" Text='<%# Bind("idVendedor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ventaneta" SortExpression="ventaneta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblventaneta" runat="server" Text='<%# Bind("ventaneta") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MontoMorosidad" SortExpression="montoMorosidad">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmontoMorosidad" runat="server" Text='<%# Bind("montoMorosidad") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MontoAlcanzado" SortExpression="montoAlcanzado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmontoAlcanzado" runat="server" Text='<%# Bind("montoAlcanzado") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PorceComi" SortExpression="porceComi">
                                            <ItemTemplate>
                                                <asp:Label ID="lblporceComi" runat="server" Text='<%# Bind("porceComi") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PorceAceptable" SortExpression="porceAceptable">
                                            <ItemTemplate>
                                                <asp:Label ID="lblporceAceptable" runat="server" Text='<%# Bind("porceAceptable") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comision" SortExpression="comision">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcomision" runat="server" Text='<%# Bind("comision") %>'></asp:Label>
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
                        </div>
                        <div class="tab-pane fade" id="tab2success">
                            <%--Tabla Detalla--%>
                            Comision 5.00
                            Morosidad 4.00
                            Efectividad
                            Devoluciones
                        </div>                       
                    </div>
                </div>
            </div>
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
