<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_recibimientologistica.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_recibimientologistica" %>

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
                        <h1 class="page-header">Recibimiento de Logística</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%--INGRESA EL NUMERO DEL PEDIDO MEDIANTE LECTOR DE QR--%>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="row">
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                        <h5>Pedido:</h5>
                    </label>
                    <div class="col-md-3 col-sm-3 col-xs-12">
                        <asp:TextBox ID="txtpedido" runat="server" CssClass="form-control" Width="200px" placeholder="#pedido" ReadOnly="false" OnTextChanged="Txt_pedido_TextChanged" ></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-success">Pedido:</label>
                    <asp:Label ID="lblPedido" class="col-md-1 col-sm-1 col-xs-12 label label-default" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-success">Ciudad:</label>
                    <asp:Label ID="lblciudad" class="col-md-1 col-sm-1 col-xs-12 label label-default" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <label class="col-md-1 col-sm-1 col-xs-12 label label-success">Número de bultos:</label>
                    <asp:Label ID="lblbultos" class="col-md-1 col-sm-1 col-xs-12 label label-default" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--Grid--%>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvDetallePedido" runat="server"
                    AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" DataKeyNames="bultos" ForeColor="#333333"
                    GridLines="None"
                    AllowPaging="True" PageSize="200">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="BULTO" SortExpression="BULTO">
                            <ItemTemplate>
                                <asp:Label ID="lblbulto" runat="server" Text='<%# Bind("bultos") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OBSERVACION" SortExpression="OBSERVACION">
                            <ItemTemplate>
                                <asp:Label ID="lblobservacion" runat="server" Text='<%# Bind("observacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
                <asp:Timer ID="Timer1" enabled="false" runat="server" Interval="2000"  ontick="IngresarRecibimiento"></asp:Timer>
                <asp:Timer ID="Timer2" enabled="false" runat="server" Interval="2000"  ontick="QuitarMensaje"></asp:Timer>
                <%--<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass=" btn btn-primary" OnClick="btnIngresar_Click" Visible="false" />--%>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        <br />
    </form>
</asp:Content>
