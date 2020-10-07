<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Plantilla/Menu.Master" CodeBehind="frm_Cierre.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_Cierre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Cierre de Item</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <br />
    <%-- INGRESAR EL ID DE DEVOLUCION --%>
     <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Devolucion:</h5></label>  
          <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtDevolucion" runat="server" CssClass="form-control" Width = "200px" placeholder="#devolucion" ReadOnly="false"></asp:TextBox>               
          </div>  
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" />
        </div>
    <br />
    <br />
     <%-- GRID DETALLE DE ITEMS DEVOLUCION --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvItemDV" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="200" OnRowCommand="gvItemDV_RowCommand" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
            <asp:TemplateField>
                  <ItemTemplate>
                      <asp:ImageButton CommandName="CierreItem" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desea abrir/cerrar el item')" />
                  </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="DV" SortExpression="DV">
                    <ItemTemplate>
                        <asp:Label ID="lblnumerodocumento" runat="server" Text='<%# Bind("numerodocumento") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item" SortExpression="Item">
                    <ItemTemplate>
                        <asp:Label ID="lblcodigoproducto" runat="server" Text='<%# Bind("codigoproducto") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                    <ItemTemplate>
                        <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad">
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadsolicitada" runat="server" Text='<%# Bind("cantidadsolicitada") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Pendiente" SortExpression="Pendiente">
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadpendiente" runat="server" Text='<%# Bind("cantidadpendiente") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha" >
                    <ItemTemplate>
                        <asp:Label ID="lblfechaerp" runat="server" Text='<%# Bind("fechaerp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Estado" SortExpression="Estado" >
                    <ItemTemplate>
                        <asp:Label ID="lblestado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        </asp:GridView>
    </ContentTemplate>
        </asp:UpdatePanel>
</form>
</asp:Content>
    
