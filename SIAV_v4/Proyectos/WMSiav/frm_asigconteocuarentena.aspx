<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_asigconteocuarentena.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_asigconteocuarentena" %>
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
                        <h1 class="page-header">Asignación Conteo Cíclico Bodega Cuarentena</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%-- COMBOS DE USUARIOS Y TIPOS --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>TIPO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" Width="250px" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="0" Selected="True">Eliga un Tipo</asp:ListItem>
                <asp:ListItem Value="producto">Producto</asp:ListItem>
                <asp:ListItem Value="familia">Familia</asp:ListItem>
            </asp:DropDownList>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>USUARIO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        
    </div>
    <br />
    <br />
    <br />
     <%--BUSQUEDA Y GRILLA SEGUN EL TIPO DE CONTEO ESCOGIDO --%>
       <div class="row">
           <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DATO:</h5></label>  
           <div class="col-xs-4">
                <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" placeholder="articulo/familia"></asp:TextBox>
           </div>
           <div class="col-xs-2">
               <asp:ImageButton ID="imgB" runat="server" ImageUrl="~/Recursos/images/find.png" OnClick="imgB_Click"/>
               
           </div>
        <asp:ImageButton ID="imgAsigna" runat="server" ImageUrl="~/Recursos/images/add.png" OnClick="btnAsignar_Click"/>
           
       </div>
    <br />
     <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvProdFam" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor = "green" PageSize="250" 
        OnPageIndexChanging="gvProdFam_PageIndexChanging" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo" >
                    <ItemTemplate>
                        <asp:Label ID="lblcodigo" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                    <ItemTemplate>
                        <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>  
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
    <br />
     <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>ASIGNADOS:</h5></label>  
    </div>
    <%-- MAESTROS CREADOS EN ESTADO PARCIAL --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <asp:GridView ID="gvUsuAsig" runat="server" AutoGenerateColumns="False" CellPadding="8"
                           AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="100000" HorizontalAlign="Left" OnRowCommand="gvUsuAsig_RowCommand"
                        >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                        <asp:ButtonField CommandName="DetConteo" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px" >
                            <ItemStyle Width="20px" />
                        </asp:ButtonField> 
                           <asp:TemplateField HeaderText="#" SortExpression="#" >
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>  
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo" >
                            <ItemTemplate>
                                <asp:Label ID="lblcodigo" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>  
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo" SortExpression="Tipo" >
                            <ItemTemplate>
                                <asp:Label ID="lbltipo" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>  
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha" >
                            <ItemTemplate>
                                <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>  
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerrado" SortExpression="Cerrado" >
                            <ItemTemplate>
                                <asp:Label ID="lblcerrado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>  
                            </ItemTemplate>
                        </asp:TemplateField>
                           </Columns>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                     </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- MODAL DETALLE DE ASIGNADOS Y MANDAR A CONTAR --%>
<div class="modal fade" id="detModal">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel id="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busModalLabelOb">Detalle</h3>
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="20" OnPageIndexChanging="gvDetalle_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo" SortExpression="Tipo">
                            <ItemTemplate>
                                <asp:Label ID="lbltipo" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Documento" SortExpression="Documento">
                            <ItemTemplate>
                                <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("documento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                            <ItemTemplate>
                                <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                            <ItemTemplate>
                                <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    </asp:GridView>
                    <br />
                    <div class="row">
                       <label class="col-md-2 col-sm-2 col-xs-12 label label-info"><h5>OBSERVACION:</h5></label>  
                       <div class="col-xs-2">
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" TextMode="MultiLine" Width="500px"></asp:TextBox>
                       </div>
                   </div>
                </div>
                <div class="modal-footer">	
                    <asp:Button ID="btnContar" runat="server" CssClass="btn btn-success" Text="Mandar a Contar" OnClick="btnContar_Click" />
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