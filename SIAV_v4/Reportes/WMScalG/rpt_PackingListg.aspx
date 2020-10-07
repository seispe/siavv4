<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_PackingListg.aspx.cs" Inherits="SIAV_v4.Reportes.WMScalG.rpt_PackingListg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server" id="form1">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 class="page-header">Reportes Notas de Entrega</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>REIMPRESION:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
        </div>
    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" />
    </div>
</div>
    <br />
    <br />
     <div class="row">
        <div class="col-md-1 col-sm-1 col-xs-12">
            <asp:Button ID="btnImp" runat="server" Text="Generar Reporte" OnClick="btnImp_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
        <div class="row">
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:Button ID="btnReimp" runat="server" Text="Generar Reporte" OnClick="btnReimp_Click" CssClass="btn btn-success" />
            </div>
        </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    

     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvNE" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="100000" OnRowDataBound="gvNE_RowDataBound" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:ButtonField Text="Select" CommandName="Select" ImageUrl="~/Img/grafico.png" />--%>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CONSOLIDADO" SortExpression="CONSOLIDADO">
                <ItemTemplate>
                    <asp:Label ID="lblnumconsolidado" runat="server" Text='<%# Bind("numconsolidado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="FECHA PEDIDO" SortExpression="FECHA PEDIDO">
                <ItemTemplate>
                    <asp:Label ID="lblfechapedido" runat="server" Text='<%# Bind("fechapedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="impresiones" HeaderText="Impresiones" Visible="true"/>
       
    </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "gvNE" /> 
    </Triggers>
   </asp:UpdatePanel>


<%-- MODAL INGRESAR CONTRASEÑA --%>
    <div class="modal fade" id="claveImpresion">
        <div class="modal-dialog">
            <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busPedidosConsol">Ingrese la Contraseña</h3>
                    <asp:HiddenField ID="hfConsolidado" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" Width="250px" ></asp:TextBox>
                            </div>
                    </div>
                </div>
                <div class="modal-footer">	
                       <asp:Button ID="btnGenerarReimp" runat="server" Text="Generar" OnClick="btnGenerarReimp_Click" CssClass=" btn btn-success" />
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
                </div>
            </div>
                </ContentTemplate>
                  <Triggers>
                  <asp:PostBackTrigger ControlID="btnGenerarReimp" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div> 
</form>
</asp:Content>
