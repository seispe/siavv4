<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_supervisorlogisticau.aspx.cs" Inherits="SIAV_v4.Proyectos.WMScalU.frm_supervisorlogisticau" %>
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
                        <h1 class="page-header">Supervisor de Logistica</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
<%-- LECTOR DE CODIGO DE BARRAS --%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
    <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>LECTOR:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtLC" runat="server" CssClass="form-control" Width="200px" OnTextChanged="txtLC_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
    </div>
       </ContentTemplate>
                </asp:UpdatePanel>
    <br />
    <div class="row">
         <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>TRANSPORTISTA:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlTransportista" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" Text="Guardar" Width="200px" OnClick="btnGuardar_Click" />
    </div>
    <br />
    <br />
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvSuperLogis" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="30" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:ButtonField Text="Select" CommandName="Select" ImageUrl="~/Img/grafico.png" />--%>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PEDIDO" SortExpression="PEDIDO">
                <ItemTemplate>
                    <asp:Label ID="lblpedido" runat="server" Text='<%# Bind("pedido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COD BULTO" SortExpression="COD. BULTO">
                <ItemTemplate>
                    <asp:Label ID="lblbulto" runat="server" Text='<%# Bind("bulto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblsoc_cliente" runat="server" Text='<%# Bind("soc_cliente") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RUTA" SortExpression="RUTA">
                <ItemTemplate>
                    <asp:Label ID="lblruta" runat="server" Text='<%# Bind("ruta") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="CIUDAD" SortExpression="CIUDAD">
                <ItemTemplate>
                    <asp:Label ID="lblciudad" runat="server" Text='<%# Bind("ciudad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="FECHA ARMADO" SortExpression="FECHA ARMADO">
                <ItemTemplate>
                    <asp:Label ID="lblfarmado" runat="server" Text='<%# Bind("farmado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "gvSuperLogis" /> 
    </Triggers>
   </asp:UpdatePanel> 
</form>
</asp:Content>

