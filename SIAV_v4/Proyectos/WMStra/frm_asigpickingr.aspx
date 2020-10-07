<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_asigpickingr.aspx.cs" Inherits="SIAV_v4.Proyectos.WMStra.frm_asigpickingr" %>
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
                        <h1 class="page-header">Asignación Consolidado</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%--COMBO DE USUARIOS PICKING--%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>CONSOLIDADO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlConsolidado" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>PEDIDO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>CIUDAD:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>TIPO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <div class="row">
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>CLIENTE:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
            <label class="col-md-1 col-sm-1 col-xs-12"></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            
        </div>
        <a class="btn btn-info" href="#buscarModalP" data-toggle="modal" id="VerConsol" style="width:200px">Ver Consolidados</a>

    </div>
    <br />
    <div class="row">
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>USUARIO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlPicking" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" Text="Guardar" Width="200px" OnClick="btnGuardar_Click" />
    </div>
    <br />
    <br />
    <div class="row">
        <div style="height: 500px; overflow:scroll" class="col-sm-3 col-lg-3">
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
            <asp:GridView ID="gvConsolidadosR" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="100000" HorizontalAlign="Right"  
                 OnRowCommand="gvConsolidadosR_RowCommand" OnRowDataBound="gvConsolidadosR_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkFull" CommandName="lnkFull" CommandArgument="<%# Container.DataItemIndex %>"  runat="server" ><img src="~/Recursos/images/select.png" runat="server"/></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>        
            <asp:TemplateField HeaderText="Consolidado" SortExpression="Consolidado">
                <ItemTemplate>
             <asp:LinkButton ID="lnkPartial" runat="server" OnClick="PartialPostBack" Text='<%# Eval("numconsolidado") %>' CommandArgument='<%# Bind("numconsolidado") %>' />
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                <ItemTemplate>
                    <asp:Label ID="lblusuario" runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="Id Usuario" SortExpression="Id Usuario" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblidusuario" runat="server" Text='<%# Eval("idusuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
                       
                <asp:BoundField DataField="estado" HeaderText="Estado" Visible="true"/>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    </asp:GridView>
        </ContentTemplate>
</asp:UpdatePanel>
        </div>
<div style="height: 500px; overflow:scroll" class="col-sm-9 col-lg-9" pull-right>
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvPedidosPicking" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="100" OnPageIndexChanging="gvPedidosPicking_PageIndexChanging" HorizontalAlign="Left" 
        OnRowCommand="gvPedidosPicking_RowCommand" OnRowDataBound="gvPedidosPicking_RowDataBound" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="AnularPedido" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desa anular el pedido')" />
              </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO">
                <ItemTemplate>
                    <%--<asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>--%>
                    <asp:LinkButton ID="lnkpedido" runat="server" Text='<%# Eval("pedido") %>' CommandArgument='<%# Bind("pedido") %>' OnClick="lnkpedido_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ITEMS" SortExpression="ITEMS">
                <ItemTemplate>
                    <asp:Label ID="lblnum_lineas" runat="server" Text='<%# Bind("num_lineas") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CANT" SortExpression="CANT">
                <ItemTemplate>
                    <asp:Label ID="lblnumitems" runat="server" Text='<%# Bind("num_items") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RUC CLIENTE" SortExpression="RUCCLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblruc_cliente" runat="server" Text='<%# Bind("ruc_cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblsoc_cliente" runat="server" Text='<%# Bind("soc_cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="FECHA" SortExpression="FECHA">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="CIUDAD" SortExpression="CIUDAD">
                <ItemTemplate>
                    <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PRIORIDAD" SortExpression="PRIORIDAD">
                <ItemTemplate>
                    <asp:Label ID="lblprioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
    <%--           <asp:TemplateField HeaderText="TIPODOC" SortExpression="TIPODOC">
                <ItemTemplate>
                    <asp:Label ID="lbltipodoc" runat="server" Text='<%# Bind("tipodoc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField DataField="tipodoc" HeaderText="TIPODOC" Visible="true"/>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "gvPedidosPicking" /> 
    </Triggers>
   </asp:UpdatePanel>

        </div>
        
        
</div>
    <br />
    <br />
     
     <%-- MODAL DE VER CONSOLIDADOS --%>
<div class="modal fade" id="buscarModalP">
        <div class="modal-dialog">
            <asp:UpdatePanel id="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busModalLabelOb">Ver Consolidados Asignados</h3>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" placeholder="Consolidado/Pedido/Usuario" Width="200px"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-3">
                            <asp:Button id="btnBuscarC" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscarC_Click" CausesValidation="false"/>
                        </div>
                    </div>
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <asp:GridView ID="gvConsolidados" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="20" OnRowCommand="gvConsolidados_RowCommand"  >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                          <ItemTemplate>
                              <asp:ImageButton CommandName="AnularPedido" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desa anular el pedido')" />
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Consolidado" SortExpression="Consolidado">
                            <ItemTemplate>
                                <asp:Label ID="lblnumconsolidado" runat="server" Text='<%# Bind("numconsolidado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                            <ItemTemplate>
                                <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblsoc_cliente" runat="server" Text='<%# Bind("soc_cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Prioridad" SortExpression="Prioridad">
                            <ItemTemplate>
                                <asp:Label ID="lblprioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Num Items" SortExpression="Num Items">
                            <ItemTemplate>
                                <asp:Label ID="lblnum_items" runat="server" Text='<%# Bind("num_items") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                <div class="modal-footer">	
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                </div>
            </div>
                </ContentTemplate>
                  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscarC" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div> 
<%-- MODAL VER PEDIDOS ASIGNADOS A UN CONSOLIDADO --%>
    <div class="modal fade" id="pedConsolidado">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel id="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busPedidosConsol">Pedidos Asignados</h3>
                    <asp:HiddenField ID="hfConsolidado" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <asp:GridView ID="gvPedConsol" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="30" OnRowCommand="gvPedConsol_RowCommand"  >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                       <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/Recursos/images/select.png" SelectText="Seleccionar" ShowSelectButton="true" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:ImageButton CommandName="UpdatePedido" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/delete.png" runat="server" OnClientClick="return confirm('Eliminar el pedido del consolidado')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblsoc_cliente" runat="server" Text='<%# Bind("soc_cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Items" SortExpression="Items">
                            <ItemTemplate>
                                <asp:Label ID="lblnum_lineas" runat="server" Text='<%# Bind("num_lineas") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cant" SortExpression="Cant">
                            <ItemTemplate>
                                <asp:Label ID="lblnum_items" runat="server" Text='<%# Bind("num_items") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Prioridad" SortExpression="Prioridad">
                            <ItemTemplate>
                                <asp:Label ID="lblprioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                <div class="modal-footer">	
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                </div>
            </div>
                </ContentTemplate>
                  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscarC" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div> 

<%-- MODAL VER DETALLE DE UN PEDIDO --%>
    <div class="modal fade" id="detPedido">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3>Detalle de Pedido</h3>
                    <asp:HiddenField ID="HiddenField1" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                          <tr>
                            <th>Pedido</th>
                            <th>Producto</th>
                            <th>Cantidad</th>
                            <th>Descripcion</th>
                            <th>Marca</th>
                          </tr>
                        </thead>
                        <tbody>
                          <asp:Label ID="lbldetalleped" runat="server" Text=""></asp:Label>
                        </tbody>
                      </table>
                </div>
                <div class="modal-footer">	
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
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