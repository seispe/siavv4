<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_asigreccg.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalG.frm_asigreccg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <script type="text/javascript">

        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                       inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                       inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
     <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Asignación ReConteo Cíclico</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <%--COMBO DE CONTEOS--%>
    <div class="row">
        <asp:Button ID="btnMergeCantidades" runat="server" Text="Actualizar Cantidades" CssClass="btn btn-success" Width="200px"  />
    </div>
    <br />
     <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>RE CONTEO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
           <asp:DropDownList ID="ddlConteo" runat="server" CssClass="form-control" Width="250px" ></asp:DropDownList>
        </div>
    </div>
    <br />
     <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>USUARIO:</h5></label>  
        <div class="col-sm-3">
            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
         <div class="col-xs-2">
             <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar Diferencias" Width="200px" OnClick="btnBuscar_Click" />
         </div>
         <div class="col-xs-2">
             <asp:Button ID="btnAsginarRe" runat="server" CssClass="btn btn-success" Text="Asignar Reconteo" OnClick="btnAsginarRe_Click" />
         </div>
    </div>
   <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    <asp:GridView ID="gvDetConteo" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="15" HorizontalAlign="Left" OnRowCommand="gvDetConteo_RowCommand" OnPageIndexChanging="gvDetConteo_PageIndexChanging" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
             <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" />
                </HeaderTemplate>
               <ItemTemplate>
                    <asp:CheckBox ID="chkRow" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Producto" SortExpression="Producto" >
                    <ItemTemplate>
                        <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion" >
                    <ItemTemplate>
                        <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Cant Manual" SortExpression="Cant Manual" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadmanual" runat="server" Text='<%# Bind("cantidadmanual") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="Cant Reconteo" SortExpression="Cant Reconteo" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadreconteo" runat="server" Text='<%# Bind("cantidadreconteo") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="Cant WMS" SortExpression="Cantidad WMS" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadwms" runat="server" Text='<%# Bind("cantidadwms") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Cant GP" SortExpression="Cantidad GP" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadgp" runat="server" Text='<%# Bind("cantidadgp") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:ButtonField CommandName="DetCoordenadas" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
            <ItemStyle Width="20px" />
            </asp:ButtonField> 
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "gvDetConteo" /> 
    </Triggers>
   </asp:UpdatePanel>
<%-- MODAL DE EDITAR CANTIDADES CONTADAS POR UN ARTICULO --%>
    <div class="modal fade" id="detCoorModal">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel id="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="p">Cantidades por Coordenada</h3>
                    <asp:HiddenField ID="HiddenField1" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <asp:GridView ID="gvDetConteoCoor" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="30" OnRowCommand="gvDetConteoCoor_RowCommand" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                      
                        <asp:TemplateField HeaderText="Coordenada" SortExpression="Coordenada">
                            <ItemTemplate>
                                <asp:Label ID="lblcoordenada" runat="server" Text='<%# Bind("coordenada") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                            <ItemTemplate>
                                <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                            <ItemTemplate>
                                <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad">
                            <ItemTemplate>
                                <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad Manual" SortExpression="Cantidad Manual">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>--%>
                                <asp:TextBox ID="txtcantidadmanual" runat="server" Text='<%# Eval("cantidadmanual")%>' CssClass="form-text" Width="30px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton CommandName="ActualizarCantidad" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desa actualizar la cantidad')" />
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
                    
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div> 
    <%-- MODAL INGRESAR OBSERVACION --%>
    <div class="modal fade" id="obs">
        <div class="modal-dialog">
            <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busPedidosConsol">Ingrese una Observación</h3>
                    <asp:HiddenField ID="hfConsolidado" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox ID="txtObservación" runat="server" CssClass="form-control" Width="250px" TextMode="MultiLine" ></asp:TextBox>
                            </div>
                    </div>
                </div>
                <div class="modal-footer">	
                       <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass=" btn btn-success" />
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                </div>
            </div>
                </ContentTemplate>
                  <Triggers>
                  <asp:PostBackTrigger ControlID="btnGenerar" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div> 
</form>
</asp:Content>