<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_CartaServ.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_CartaServ" %>

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
                        <h1 class="page-header">Carta Devoluciones Servientrega</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <%-- INGRESAR EL NUMERO DE FACTURA --%>
        <div class="row">
            <label class="col-md-1 col-sm-1 col-xs-12 label label-info">
                <h5>Factura:</h5>
            </label>
            <div class="col-md-3 col-sm-3 col-xs-12">
                <asp:TextBox ID="txtfactura" runat="server" CssClass="form-control" Width="200px" placeholder="#factura" ReadOnly="false"></asp:TextBox>
            </div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="200px" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnCarta" runat="server" Text="Generar" CssClass="btn btn-success" Width="200px" data-toggle="modal" data-target="#mdlCarta" OnClientClick="return false;"/>
        </div>
        <br />
        <br />

        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="False" CellPadding="8"
                    AllowPaging="True" AllowSorting="True" CssClass="grid" ForeColor="#333333" GridLines="None" PageSize="100000">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <%--<asp:ButtonField Text="Select" CommandName="Select" ImageUrl="~/Img/grafico.png" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
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
                        <asp:TemplateField HeaderText="Cant" SortExpression="Cant">
                            <ItemTemplate>
                                <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Factura" SortExpression="Factura">
                            <ItemTemplate>
                                <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ruc" SortExpression="Ruc">
                            <ItemTemplate>
                                <asp:Label ID="lblruc" runat="server" Text='<%# Bind("ruc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad" SortExpression="Ciudad">
                            <ItemTemplate>
                                <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Dev" SortExpression="Fecha Dev">
                            <ItemTemplate>
                                <asp:Label ID="lblfdev" runat="server" Text='<%# Bind("fdev") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvItems" />
            </Triggers>
        </asp:UpdatePanel>
        <%-- MODAL INGRESAR GUIA Y FECHA --%>
        <div class="modal fade" id="mdlCarta">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="busPedidosConsol">Ingrese la Guia y Fecha</h3>
                                <asp:HiddenField ID="hfConsolidado" runat="server" />
                                <br />
                            </div>
                            <div class="container"></div>
                            <div class="modal-body">
                                <div class="row">
                                    <label class="col-md-1 col-sm-1 col-xs-12 ">
                                        <h5>Guía:</h5>
                                    </label>
                                    <div class="col-md-5 col-sm-5 col-xs-12">
                                        <asp:TextBox ID="txtGuia" runat="server" CssClass="form-control" Width="150px" placeholder="#guia" ReadOnly="false"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-sm-1 col-xs-12">
                                        <h5>Fecha:</h5>
                                    </label>
                                    <div class="col-md-3 col-sm-3 col-xs-12">
                                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Width="150px" placeholder="fecha" ReadOnly="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass=" btn btn-success" OnClick="btnGenerar_Click" target="_blank" />
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
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
