<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_reversasu.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalU.frm_reversasu" %>
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
                        <h1 class="page-header">Reversas</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%--SELECCIONAR EL PEDIDO A REVERSAR--%>
    <div>
        <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
            <asp:ListItem Value="1" Selected="True">Pedido</asp:ListItem>
            <asp:ListItem Value="2">Orden Compra</asp:ListItem>
        </asp:RadioButtonList> 
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
     <ContentTemplate>                
        <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Dato:</h5></label>  
          <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="Txt_numpedido" runat="server" CssClass="form-control" data-toggle="modal" href="#buscarModalP" Width = "200px" placeholder="#Pedido" ReadOnly="false"></asp:TextBox>               
          </div>  
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" />
        </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <%-- GRID DE MAESTRO DE PEDIDOS CABECERA --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvPedidosCab" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" DataKeyNames="NUMERO" HeaderStyle-BackColor = "green" 
             PageSize="5" OnSelectedIndexChanged="gvPedidosCab_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
             
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Recursos/images/select.png" SelectText="Seleccionar" ShowSelectButton="true" />
                <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblPedido" runat="server" Text='<%# Bind("PEDIDO") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NUMERO" SortExpression="NUMERO">
                    <ItemTemplate>
                        <asp:Label ID="lblNumero" runat="server" Text='<%# Bind("NUMERO") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="N° Linea" SortExpression="NLINEA" >
                    <ItemTemplate>
                        <asp:Label ID="lblNlinea" runat="server" Text='<%# Bind("NLINEA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESTADO" SortExpression="ESTADO">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                    <ItemTemplate>
                        <asp:Label ID="lblCliente" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CIUDAD" SortExpression="CIUDAD" >
                    <ItemTemplate>
                        <asp:Label ID="lblCiudad" runat="server" Text='<%# Bind("CIUDAD") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OBSERVACION" SortExpression="OBSERVACION">
                    <ItemTemplate>
                        <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("OBSERVACION") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FECHA CREACION" SortExpression="FECHA_CREACION">
                    <ItemTemplate>
                        <asp:Label ID="lblFcreacion" runat="server" Text='<%# Bind("FECHA_CREACION") %>'></asp:Label>
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
         <div style="margin-left: 550px">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>
              <asp:Label ID="lblPedido" runat="server" class="label label-primary" Font-Size="Large" Text=""></asp:Label>
              </ContentTemplate>
              </asp:UpdatePanel>
     </div>
    <br />
    <%-- GRID DE DETALLE DE PEDIDOS ARTICULOS --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvPedidosDet" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" DataKeyNames="CODIGO" HeaderStyle-BackColor = "green" 
             PageSize="100" OnRowCommand="gvPedidosDet_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:ButtonField CommandName="ReversaRecord" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
            <ItemStyle Width="20px" />
            </asp:ButtonField> 
                 <asp:TemplateField HeaderText="Consolidado" SortExpression="Consolidado" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblnumconsolidado" runat="server" Text='<%# Bind("numconsolidado") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="CODIGO" SortExpression="CODIGO">
                    <ItemTemplate>
                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PRODUCTO" SortExpression="PRODUCTO" >
                    <ItemTemplate>
                        <asp:Label ID="lblProducto" runat="server" Text='<%# Bind("PRODUCTO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COOR_ORIGEN" SortExpression="COOR_ORIGEN" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCoorOrigenPicking" runat="server" Text='<%# Bind("COOR_ORIGEN_PICKNIG") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COOR_ORIGEN" SortExpression="COOR_ORIGEN" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCoorOrigenArmado" runat="server" Text='<%# Bind("COOR_ORIGEN_ARMADO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESTADO" SortExpression="ESTADO">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SOLICITADA" SortExpression="SOLICITADA">
                    <ItemTemplate>
                        <asp:Label ID="lblSolicitada" runat="server" Text='<%# Bind("SOLICITADA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PROCESADA" SortExpression="PROCESADA" >
                    <ItemTemplate>
                        <asp:Label ID="lblProcesada" runat="server" Text='<%# Bind("PROCESADA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PENDIENTE" SortExpression="PENDIENTE">
                    <ItemTemplate>
                        <asp:Label ID="lblPendiente" runat="server" Text='<%# Bind("PENDIENTE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                        <asp:TemplateField HeaderText="ARMADA" SortExpression="ARMADA">
                    <ItemTemplate>
                        <asp:Label ID="lblArmada" runat="server" Text='<%# Bind("ARMADA") %>'></asp:Label>
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
     <%-- GRID DE DETALLE DE ORDENES DE COMPRA ARTICULOS --%>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvCompraDet" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="1000" OnRowCommand="gvCompraDet_RowCommand" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:ButtonField CommandName="ReversaOC" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
            <ItemStyle Width="20px" />
            </asp:ButtonField> 
               <asp:TemplateField HeaderText="CODIGO" SortExpression="CODIGO">
                    <ItemTemplate>
                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOCUMENTO" SortExpression="DOCUMENTO" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblDocumento" runat="server" Text='<%# Bind("DOCUMENTO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PRODUCTO" SortExpression="PRODUCTO" >
                    <ItemTemplate>
                        <asp:Label ID="lblProducto" runat="server" Text='<%# Bind("PRODUCTO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="ESTADO" SortExpression="ESTADO">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SOLICITADA" SortExpression="SOLICITADA">
                    <ItemTemplate>
                        <asp:Label ID="lblSolicitada" runat="server" Text='<%# Bind("SOLICITADA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PROCESADA" SortExpression="PROCESADA" >
                    <ItemTemplate>
                        <asp:Label ID="lblProcesada" runat="server" Text='<%# Bind("PROCESADA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PENDIENTE" SortExpression="PENDIENTE">
                    <ItemTemplate>
                        <asp:Label ID="lblPendiente" runat="server" Text='<%# Bind("PENDIENTE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="DAÑADA" SortExpression="DAÑADA">
                    <ItemTemplate>
                        <asp:Label ID="lblDaniada" runat="server" Text='<%# Bind("DANIADA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EXCEDENTE" SortExpression="EXCEDENTE">
                    <ItemTemplate>
                        <asp:Label ID="lblExcedente" runat="server" Text='<%# Bind("EXCEDENTE") %>'></asp:Label>
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
     <%-- MODAL DE REVERSA --%>
<div id="reversaModal" class="modal fade" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                <h3 id="facModalLabel">Reversar</h3>
            </div>
            <asp:UpdatePanel id="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                <%--<label class="control-label" for="inputSuccess">Proceso</label>--%>
                                <asp:Label runat="server" ID="lblProcesoOC" CssClass="control-label" Font-Bold="true">Proceso</asp:Label>
                            
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                <asp:DropDownList ID="ddlProceso" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="Seleccione" Selected="True">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="Picking">Picking</asp:ListItem>
                                    <asp:ListItem Value="Armado">Armado</asp:ListItem>
                                </asp:DropDownList>
                          </div>
                        </div>
                        <br />
                       <div class="row">
                            <div class="col-md-3">
                                  <label class="control-label">Pedido</label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblPedidoR" runat="server" CssClass="control-label" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Producto</label>
                            </div>
                           <div class="col-md-3">
                                <asp:Label ID="lblProductoR" runat="server" CssClass="control-label" Text=""></asp:Label>
                            </div>
                          </div>
                        <br />
                         <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                <label class="control-label" for="inputSuccess">Motivo</label>
                            
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                <%--<asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" Width="350px" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlMotivo" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                          </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-3">
                                <%--<label class="control-label" for="inputSuccess">Picado</label>--%>
                                <asp:Label runat="server" ID="lblPicadoOC" CssClass="control-label" Font-Bold="true">Picado</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlPicking" runat="server" CssClass="form-control"></asp:DropDownList>
                          </div>
                        </div>
                        <br />
                         <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                <%--<label class="control-label" for="inputSuccess">Destino</label>--%>
                                <asp:Label runat="server" ID="lblDestinoOC" CssClass="control-label" Font-Bold="true">Destino</asp:Label>
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control" OnTextChanged="txtDestino_TextChanged" AutoPostBack="true"  ></asp:TextBox>
                          </div>
                        </div>
                        <br />
                       <div class="row">
                            <div class="col-md-3">
                                  <%--<label class="control-label" for="inputSuccess">Sugerido</label>--%>
                                <asp:Label runat="server" ID="lblSugeridoOC" CssClass="control-label" Font-Bold="true">Sugerido</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtSugeridoR" runat="server" CssClass="form-control" Width="140px" Text='' ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <%--<label class="control-label" for="inputSuccess">Total Procesado</label>--%>
                                <asp:Label runat="server" ID="lblTotalProcesadoOC" CssClass="control-label" Font-Bold="true">Total Procesado</asp:Label>
                            </div>
                           <div class="col-md-3">
                                <asp:Label ID="lblProcesadoR" runat="server" CssClass="control-label" Text=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                <%--<label class="control-label" for="inputSuccess">Reversar</label>--%>
                                <asp:Label runat="server" ID="lblReversarOC" CssClass="control-label" Font-Bold="true">Reversar</asp:Label>
                            </div>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-10">
                                <asp:TextBox ID="txtReversar" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revtxtReversar" runat="server" ValidationGroup="addModalGestion" ForeColor="Red" Text="Solo Números" ToolTip="Solo Números" ControlToValidate="txtReversar" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                          </div>
                        </div>
                        </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGuardarR" runat="server" Text="Guardar" OnClick="btnGuardarR_Click" CssClass="btn btn-success" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar"
                             UseSubmitBehavior="false"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    </div>
                </ContentTemplate>
                <Triggers>

                </Triggers>
            </asp:UpdatePanel>
        </div>
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

