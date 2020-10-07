<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_DisponibilidadABC.aspx.cs" Inherits="SIAV_v4.Reportes.TOC.rpt_DisponibilidadABC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--Agregamos siempre un form en nuestro proyecto--%>
<form id="form1" runat="server">
<%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">Reporte de Disponibilidad ABC</h1>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</div>
<br />
<div class="buscar">
  <div class="form-group">
    <div class="row">
        <div class="col-md-4">
            <br />
            <label class="control-label col-xs-3">Ingrese Fecha:</label>
            <div class="col-xs-9">
                <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" placeholder="Fecha" ReadOnly="false"></asp:TextBox>
                <script type="text/javascript">
                    // When the document is ready
                    $(document).ready(function () {
                        var dp = $("#<%=txtFechaInicio.ClientID%>");
                        dp.datepicker({
                            changeMonth: true,
                            changeYear: true,
                            format: "dd/mm/yyyy",
                            language: "es",
                            autoclose: true
                        }).on('changeDate', function (ev) {
                            $(this).datepicker('hide');
                        });;
                    });
                </script>               
            </div>
        
        <div class="col-md-4">
            <br />
            <label class="control-label col-xs-3"></label>
            <div class="col-xs-9">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Cssclass="btn btn-success" OnClick="btnBuscar_Click"/>   
            </div>
        </div>
    </div>
    </div>
  </div> 
</div>
    <asp:GridView ID="gvBuffer" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="grid" DataKeyNames="bodega" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Bodega" SortExpression="bodega">
                <EditItemTemplate>
                    <asp:Label ID="txtBodega" runat="server" Text='<%# Bind("bodega") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("bodega") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="A" SortExpression="A">
                <EditItemTemplate>
                    <asp:Label ID="txtAgotado" runat="server" Text='<%# Bind("A") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("A") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B" SortExpression="B">
                <EditItemTemplate>
                    <asp:Label ID="txtUrgente" runat="server" Text='<%# Bind("B") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("B") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="C" SortExpression="C">
                <EditItemTemplate>
                    <asp:TextBox ID="txtNivel_Alto" runat="server" Text='<%# Bind("C") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("C") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="D" SortExpression="D">
                <EditItemTemplate>
                    <asp:Label ID="txtOk" runat="server" Text='<%# Bind("D") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("D") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Total" SortExpression="Total">
                <EditItemTemplate>
                    <asp:Label ID="txtSobre_Stock" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</form>
<%--Fin Agregar Formulario--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
