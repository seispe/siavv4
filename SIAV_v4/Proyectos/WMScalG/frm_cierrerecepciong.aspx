<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_cierrerecepciong.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalG.frm_cierrerecepciong" %>
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
                        <h1 class="page-header">Cierre Recepción</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%--SELECCIONAR LA ORDEN DE COMPRA A CERRAR--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
     <ContentTemplate>                
        <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>Consolidado:</h5></label>  
          <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtOC" runat="server" CssClass="form-control" Width = "200px" placeholder="#orden" ReadOnly="false"></asp:TextBox>               
          </div>  
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" />
        </div>
         <br />
         <br />
            <div style="margin-left: 128px">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>
                <asp:Button ID="btnCerrar" runat="server" Text="" CssClass="btn btn-success" Width="200px" OnClientClick="return confirm('Desea Cerrar el Picking?')"  />
              </ContentTemplate>
              </asp:UpdatePanel>
     </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
     <%-- GRID DE MAESTRO DE PEDIDOS CABECERA --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvRecepcion" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="30" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
             <asp:TemplateField HeaderText="Documento" SortExpression="Documento">
                    <ItemTemplate>
                        <asp:Label ID="lbldocumento" runat="server" Text='<%# Bind("numerodocumento") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                    <ItemTemplate>
                        <asp:Label ID="lblcodigoproducto" runat="server" Text='<%# Bind("codigoproducto") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Solicitada" SortExpression="Solicitada" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadsolicitada" runat="server" Text='<%# Bind("cantidadsolicitada") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Procesada" SortExpression="Procesada">
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadprocesada" runat="server" Text='<%# Bind("cantidadprocesada") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pendiente" SortExpression="Pendiente">
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadpendiente" runat="server" Text='<%# Bind("cantidadpendiente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado" SortExpression="Estado" >
                    <ItemTemplate>
                        <asp:Label ID="lblestado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Dañada" SortExpression="Estado" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidaddaniada" runat="server" Text='<%# Bind("cantidaddaniada") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Excedente" SortExpression="Excedente" >
                    <ItemTemplate>
                        <asp:Label ID="lblcantidadexcedente" runat="server" Text='<%# Bind("cantidadexcedente") %>'></asp:Label>
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

