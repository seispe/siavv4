<%@ Page Language="C#"  MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_TiemposReposicion.aspx.cs" Inherits="SIAV_v4.Proyectos.TOC.frm_TiemposReposicion" %>
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
                        <h1 class="page-header">Tiempos de Reposición</h1>
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
     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>BODEGA:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlBodega" runat="server" CssClass="form-control" Width="150px"  AutoPostBack="false">
                <asp:ListItem Selected="True" Value="MATRIZ">MATRIZ</asp:ListItem>
                <asp:ListItem Value="PVQ">PVQ</asp:ListItem>
                <asp:ListItem Value="PVG1">PVG1</asp:ListItem>
            </asp:DropDownList>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>PROVEEDOR:</h5></label>  
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
    <ContentTemplate>   
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control" Width="250px" placeholder="RUC" data-toggle="modal" href="#buscarModalP" ReadOnly="true"></asp:TextBox>
        </div>
           </ContentTemplate>
</asp:UpdatePanel> 
   
    </div>
   <br />
     <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>NOMBRE:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Width="300px" placeholder="nombre" ReadOnly="true"></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5># ITEMS:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtIems" runat="server" CssClass="form-control" Width="150px" placeholder="número de items" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>ACTUAL:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtActual" runat="server" CssClass="form-control" Width="250px" placeholder="dias" ReadOnly="true" Font-Size="Large"></asp:TextBox>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>NUEVO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtNuevo" runat="server" CssClass="form-control" Width="250px" placeholder="dias"></asp:TextBox>
        </div>
        <asp:Button ID="btnActualizar" runat="server" class="btn btn-success" Text="Actualizar" Width="200px" OnClick="btnActualizar_Click" OnClientClick="clickOnce(this, 'Actualizando...')"
            UseSubmitBehavior="false" ValidationGroup="Buscar" />
    </div>
    <br />
     </ContentTemplate>
        </asp:UpdatePanel>
    <br />
    <br />
    <%-- MODAL BUSCAR PROVEEDOR --%>
     <div class="modal fade" id="buscarModalP">
        <div class="modal-dialog">
            <asp:UpdatePanel id="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busModalLabelOb">Buscar Proveedores</h3>
                    <div class="row">
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-7">
                            <asp:TextBox ID="txtDato" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-2">
                            <asp:Button id="btngestion" runat="server" Text="Buscar" OnClick="btngestion_Click"  CssClass="btn btn-info" CausesValidation="false" OnClientClick="clickOnce(this, 'Buscando...')"
                                    UseSubmitBehavior="false" ValidationGroup="Buscar" />
                        </div>
                    </div>
                </div>
                <div class="container"></div>
                <div class="modal-body">

                    <asp:gridview id="gvproveedores" runat="server" autogeneratecolumns="False" cellpadding="4" 
                    cssclass="grid" datakeynames="ruc" forecolor="#333333"
                    gridlines="None" OnPageIndexChanging="gvproveedores_PageIndexChanging"
                    allowpaging="True" pagesize="10" OnSelectedIndexChanged="gvproveedores_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            
                            <asp:CommandField ButtonType="Image" HeaderText="Seleccionar" SelectImageUrl="~/Recursos/images/select.png" SelectText="Seleccionar" ShowSelectButton="true" />
                            
                            <asp:TemplateField HeaderText="Ruc" SortExpression="Ruc">
                                <ItemTemplate>
                                    <asp:Label ID="lblRuc" runat="server" Text='<%# Bind("ruc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="# Items" SortExpression="# Items">
                                <ItemTemplate>
                                    <asp:Label ID="lblItems" runat="server" Text='<%# Bind("articulos") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="# Dias" SortExpression="# Dias">
                                <ItemTemplate>
                                    <asp:Label ID="lblDias" runat="server" Text='<%# Bind("dias") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    </asp:gridview>
                </div>
                <div class="modal-footer">	
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                </div>
            </div>
                </ContentTemplate>
                  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btngestion" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
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