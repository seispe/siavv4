<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_AumentoStock.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_AumentoStock" %>
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
                        <h2 class="page-header">Aumento Stock 64</h2>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
           <%-- INGRESAR DATOS --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Producto:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" placeholder="#codigo"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
             </div>
             <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:Button ID="btnProcesar" runat="server" CssClass="btn btn-success" Text="Procesar" OnClick="btnProcesar_Click" />
             </div>
        </div>
          <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Cantidad:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="cantidad"></asp:TextBox>
            </div>
        </div>
          <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Motivo:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:DropDownList id="ddlMotivo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Observación:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" placeholder="observacion" TextMode="MultiLine" Rows="3" Columns="22"></asp:TextBox>
            </div>
        </div>
        <br />
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
       <asp:GridView ID="gvUbicaProducto" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="1000" 
        >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="PRODUCTO" SortExpression="PRODUCTO">
                <ItemTemplate>
                    <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="DESCRIPCION" SortExpression="DESCRIPCION">
                <ItemTemplate>
                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="COORDENADA" SortExpression="COORDENADA">
                <ItemTemplate>
                    <asp:Label ID="lblcoordenada" runat="server" Text='<%# Bind("coordenada") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
    </Triggers>
   </asp:UpdatePanel>
        </form>
    </asp:Content>
