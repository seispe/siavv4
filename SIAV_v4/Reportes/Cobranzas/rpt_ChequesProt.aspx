<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_ChequesProt.aspx.cs" Inherits="SIAV_v4.Reportes.Cobranzas.rpt_ChequesProt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server" id="form1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
<div class="row">
    <div class="col-lg-12">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 class="page-header">Reporte Cheques Protestados</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
    <%-- SELECCIONAR FECHAS --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>FECHAS:</h5></label>  
        <div class="col-sm-2">
            <asp:TextBox ID="txtfdesde" runat="server" CssClass="form-control" Width="150px" placeholder="Desde" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtfhasta" runat="server" CssClass="form-control" Width="150px" placeholder="Hasta" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
              <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
        <div class="col-sm-2">
             <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
        </div>
    </div>
     <br />
    <br />
     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    
    <asp:GridView ID="gvchequesProt" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="500" OnPageIndexChanging="gvchequesProt_PageIndexChanging" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="RUC" SortExpression="RUC">
                <ItemTemplate>
                    <asp:Label ID="lblruc" runat="server" Text='<%# Bind("RUC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="NOMBRE COMERCIAL" SortExpression="NOMBRE COMERCIAL">
                <ItemTemplate>
                    <asp:Label ID="lblnom_comercial" runat="server" Text='<%# Bind("NOM_COMERCIAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="DOCUMENTO" SortExpression="DOCUMENTO">
                <ItemTemplate>
                    <asp:Label ID="lbldoc" runat="server" Text='<%# Bind("DOCUMENTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA" SortExpression="FECHA">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("FECHA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="MONTO ORIGINAL" SortExpression="MONTO ORIGINAL">
                <ItemTemplate>
                    <asp:Label ID="lblmnt_orig" runat="server" Text='<%# Bind("MNT_ORIG") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="MONTO PENDIENTE" SortExpression="MNT_PEND">
                <ItemTemplate>
                    <asp:Label ID="lblmnt_pend" runat="server" Text='<%# Bind("MNT_PEND") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VEN_DOC" SortExpression="VEN_DOC">
                <ItemTemplate>
                    <asp:Label ID="lblven_doc" runat="server" Text='<%# Bind("VEN_DOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VEN_CLI" SortExpression="VEN_CLI">
                <ItemTemplate>
                    <asp:Label ID="lblven_cli" runat="server" Text='<%# Bind("VEN_CLI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="DESC" SortExpression="DESC">
                <ItemTemplate>
                    <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("TRXDSCRN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="NOTA" SortExpression="NOTA">
                <ItemTemplate>
                    <asp:Label ID="lblnota" runat="server" Text='<%# Bind("NOTA") %>'></asp:Label>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtfdesde.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;

            var dp = $("#<%=txtfhasta.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                autoclose: true
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });;
        });
    </script>
</asp:Content>