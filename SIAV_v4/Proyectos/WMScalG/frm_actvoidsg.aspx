<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Plantilla/Menu.Master" CodeBehind="frm_actvoidsg.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalG.frm_actvoidsg" %>
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
                        <h1 class="page-header">Actualizar Voids</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR NUMERO DE OC Y ESTADO --%>
        <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">PEDIDO</asp:ListItem>
                <asp:ListItem Value="3">VOIDS</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <%--INGRESAR EL PEDIDO O VOID A BUSCAR--%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>DATO:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtdoc" runat="server" CssClass="form-control" Width="200px" placeholder="#pedido/voids" ReadOnly="false"></asp:TextBox>
            </div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success" Width="150px" OnClick="btnBuscar_Click" />
        </div>
        <br />
        <br />
        <%-- GRID DETALLE DE VOIDS --%>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvVoids" runat="server" AutoGenerateColumns="False" CellPadding="8"
                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="150" OnRowCommand="gvVoids_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField CommandName="EditVoid" ButtonType="Image" ImageUrl="~/Recursos/images/edit.png" Text="Editar" ItemStyle-Width="20px">
                            <ItemStyle Width="20px" />
                        </asp:ButtonField>
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Voids" SortExpression="Voids">
                            <ItemTemplate>
                                <asp:Label ID="lblvoid" runat="server" Text='<%# Bind("void") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Voids Antiguos" SortExpression="Voids Antiguos">
                            <ItemTemplate>
                                <asp:Label ID="lblvoidantiguo" runat="server" Text='<%# Bind("voidantiguo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pedido" SortExpression="Pedido">
                            <ItemTemplate>
                                <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
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
                                <asp:Label ID="lblcant" runat="server" Text='<%# Bind("cant") %>'></asp:Label>
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
        <%-- MODAL DE REVERSA --%>
        <div id="editVoid" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="facModalLabel">Actualizar Void</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtVoid" runat="server" CssClass="form-control" Width="500px" PlaceHolder="nuevo void"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnGuardarR" runat="server" Text="Guardar" OnClick="btnGuardarR_Click" CssClass="btn btn-success" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar"
                                    UseSubmitBehavior="false" />
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