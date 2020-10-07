<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_ajustesrectima.aspx.cs" Inherits="SIAV_v4.Proyectos.Autorizaciones.frm_ajustesrectima" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <h1 class="page-header">Autorización de Ajustes</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <div class="row">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
    </div>
    <br />
     <%-- GRID DE AJUSTES --%>
    <asp:UpdatePanel ID="upCrudGrid" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:GridView ID="gvAjustes" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="grid" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" HeaderStyle-BackColor = "green" 
             PageSize="200" OnRowCommand="gvAjustes_RowCommand" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
              <ItemTemplate>
                  <asp:ImageButton CommandName="Aprobacion" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Recursos/images/grafico.png" runat="server" OnClientClick="return confirm('Desea aprobar el ajuste')" />
              </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                    <ItemTemplate>
                        <asp:Label ID="lblusuario" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Ajuste" SortExpression="Ajuste">
                    <ItemTemplate>
                        <%--<asp:Label ID="lblparametroN1" runat="server" Text='<%# Bind("parametroN1") %>'></asp:Label>  --%>
                        <asp:LinkButton ID="lnkparametroN1" runat="server" Text='<%# Eval("parametroN1") %>' CommandArgument='<%# Bind("parametroN1") %>' OnClick="lnkparametroN1_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Ingreso" SortExpression="Fecha Ingreso" >
                    <ItemTemplate>
                        <asp:Label ID="lblf_ingreso" runat="server" Text='<%# Bind("f_ingreso") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        </asp:GridView>
    </ContentTemplate>
        </asp:UpdatePanel>
<%-- MODAL VER DETALLE DE UN AJUSTE --%>
    <div class="modal fade" id="detAjuste">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel id="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3>Detalle de Ajuste</h3>
                    <asp:HiddenField ID="HiddenField1" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                          <tr>
                            <th>Articulo</th>
                            <th>Descripcion</th>
                            <th>Cantidad</th>
                            <th>Costo</th>
                          </tr>
                        </thead>
                        <tbody>
                          <asp:Label ID="lbldetalleaj" runat="server" Text=""></asp:Label>
                        </tbody>
                      </table>
                </div>
                <div class="modal-footer">	
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
