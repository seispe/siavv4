<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_ChequesPosfNoDepo.aspx.cs" Inherits="SIAV_v4.Reportes.Cobranzas.rpt_ChequesPosfNoDepo" %>
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
                <h1 class="page-header">Reporte Cheques Posfechados NO Depositados</h1>
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
    
    <asp:GridView ID="gvchequesPosfNoDepo" runat="server" AutoGenerateColumns="False" CellPadding="8"
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
                <asp:TemplateField HeaderText="BANCO" SortExpression="BANCO">
                <ItemTemplate>
                    <asp:Label ID="lblbanco" runat="server" Text='<%# Bind("BANCO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N CUENTA" SortExpression="N CUENTA" ControlStyle-Width="90px">
                <ItemTemplate>
                    <asp:Label ID="lblnum_cuenta" runat="server" Text='<%# Bind("NUM_CUENTA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="N CHEQUE" SortExpression="N CHEQUE" ControlStyle-Width="10px">
                <ItemTemplate>
                    <asp:Label ID="lblnum_cheque" runat="server" Text='<%# Bind("NUM_CHEQUE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="F ING" SortExpression="F ING">
                <ItemTemplate>
                    <asp:Label ID="lblfecha_ing" runat="server" Text='<%# Bind("FECHA_ING") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="F VENC" SortExpression="F VENC">
                <ItemTemplate>
                    <asp:Label ID="lblfecha_venc" runat="server" Text='<%# Bind("FECHA_VENC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MONTO" SortExpression="MONTO">
                <ItemTemplate>
                    <asp:Label ID="lblmonto" runat="server" Text='<%# Bind("MONTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="POR APLI" SortExpression="POR APLI">
                <ItemTemplate>
                    <asp:Label ID="lblpor_aplicar" runat="server" Text='<%# Bind("POR_APLICAR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="VEND" SortExpression="VEND">
                <ItemTemplate>
                    <asp:Label ID="lblvendedor" runat="server" Text='<%# Bind("VENDEDOR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N VEND" SortExpression="N VEND">
                <ItemTemplate>
                    <asp:Label ID="lblnom_vendedor" runat="server" Text='<%# Bind("NOM_VENDEDOR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="USR EDIT" SortExpression="USR EDIT">
                <ItemTemplate>
                    <asp:Label ID="lblusr_edit" runat="server" Text='<%# Bind("USR_EDIT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="USR ING" SortExpression="USR ING">
                <ItemTemplate>
                    <asp:Label ID="lblusr_ing" runat="server" Text='<%# Bind("USR_INGRESO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="ANULADO" SortExpression="ANULADO">
                <ItemTemplate>
                    <asp:Label ID="lblanulado" runat="server" Text='<%# Bind("ANULADO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="RECIBO" SortExpression="RECIBO">
                <ItemTemplate>
                    <asp:Label ID="lblrecibo_caja" runat="server" Text='<%# Bind("RECIBO_CAJA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="F APLI" SortExpression="F APLI">
                <ItemTemplate>
                    <asp:Label ID="lblfact_aplicadas" runat="server" Text='<%# Bind("FACT_APLICADAS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="NOTA" SortExpression="NOTA" Visible="false">
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
    
