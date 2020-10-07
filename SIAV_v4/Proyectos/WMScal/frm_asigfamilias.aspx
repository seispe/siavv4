<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_asigfamilias.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScal.frm_asigfamilias" %>

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
                        <h1 class="page-header">Productos sin Familia</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- BUSCAR LOS ARTICULOS CON O SIN FAMILIA --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>DATO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtDato" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <%-- LISTADO DE ARTICULOS --%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="8"
                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000" HorizontalAlign="Left" OnRowCommand="gvProductos_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:ImageButton CommandName="UpdateFamilia" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/delete.png" runat="server" OnClientClick="return confirm('Desea eliminar de la familia')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
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
                        <asp:TemplateField HeaderText="Familia" SortExpression="Familia">
                            <ItemTemplate>
                                <asp:Label ID="lblfamilia" runat="server" Text='<%# Bind("familia") %>'></asp:Label>
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
        <%-- SECCION PARA BUSCAR Y ASIGNAR UNA FAMILIA --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Familia:</h5>
            </label>
            <div class="col-xs-4">
                <asp:TextBox ID="txtFamilia" runat="server" CssClass="form-control" placeholder="familia"></asp:TextBox>
            </div>
            <div class="col-xs-2">
                <asp:ImageButton ID="imgB" runat="server" ImageUrl="~/Recursos/images/find.png" OnClick="imgB_Click" />
            </div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar"
                UseSubmitBehavior="false" />
        </div>
        <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="gvProdFam" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor="green" PageSize="50" OnPageIndexChanging="gvProdFam_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkFamilia" runat="server" onclick="CheckBox_Clicked(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo">
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
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }

        function CheckBox_Clicked(chk) {
            var grid = chk.parentNode.parentNode.parentNode;
            var chks = grid.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i].type == "checkbox" && chks[i] != chk) {
                    chks[i].disabled = chk.checked;
                }
            }
        }
    </script>
</asp:Content>

