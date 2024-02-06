<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_vaciarccfamprodiavQ.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiavQ.frm_vaciarccfamprodiavQ" %>
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
                        <h1 class="page-header">Vaciar Coordenadas Conteo Familia/Producto</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%-- INGRESO DE COORDENADA --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>CONTEO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlConteo" runat="server" CssClass="form-control" Width="250px" ></asp:DropDownList>
        </div>
    </div>
    <div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>COORDENADA:</h5></label>  
        <div class="col-sm-3">
            <asp:TextBox ID="txtCoordenada" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
        <div class="col-xs-2">
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
        <div class="col-xs-2" >
            <asp:Button ID="btnVaciar" runat="server" CssClass="btn btn-success" Text="Vaciar Todo" OnClick="btnVaciar_Click" />
        </div>
    </div>
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    <asp:GridView ID="gvDetConteo" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="1000" HorizontalAlign="Left" OnRowCommand="gvDetConteo_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton CommandName="VaciarCantidad" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desea vaciar lo contado')" />
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Coordenada" SortExpression="Coordenada" >
                    <ItemTemplate>
                        <asp:Label ID="lblcoordenada" runat="server" Text='<%# Bind("coordenada") %>'></asp:Label>  
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
    </form>
    </asp:Content>
