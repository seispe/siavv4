<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_CuentasxCobrar.aspx.cs" Inherits="SIAV_v4.Reportes.Cobranzas.rpt_CuentasxCobrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
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
                <%--<a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>              --%>
                <h1 class="page-header">Reporte de Cuentas x Cobrar</h1>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<%--Buscar--%>
<div class="buscar">
  <div class="form-group">
    <div class="row">
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha Corte:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFecha" runat="server" Enabled="True" class="form-control" placeholder="Fecha Corte"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <br />
            <asp:UpdatePanel id="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:Button ID="btnBuscar" runat="server" Text="Generar" Cssclass="btn btn-success" OnClick="btnBuscar_Click" CausesValidation="false"/>     
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
  </div> 
</div>  
<%--Exportar--%>
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <br />
        <asp:Button ID="btnExport" runat="server" Text="Generar A Excel" Cssclass="btn btn-info" OnClick = "ExportToExcel" CausesValidation="false"/>    
    </div>
</div>

<%--Grid--%>
<asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gvCuentas" runat="server"
        autogeneratecolumns="False" cellpadding="4"
        cssclass="grid" datakeynames="DOCUMENTO" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvCuentas_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="TIPO" SortExpression="TIPO">
                <ItemTemplate>
                    <asp:Label ID="lblTIPO" runat="server" Text='<%# Bind("TIPO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RUC" SortExpression="RUC">
                <ItemTemplate>
                    <asp:Label ID="lblRUC" runat="server" Text='<%# Bind("RUC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N_CORTO" SortExpression="N_CORTO">
                <ItemTemplate>
                    <asp:Label ID="lblN_CORTO" runat="server" Text='<%# Bind("N_CORTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                <ItemTemplate>
                    <asp:Label ID="lblCLIENTE" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="REL" SortExpression="REL">
                <ItemTemplate>
                    <asp:Label ID="lblREL" runat="server" Text='<%# Bind("REL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BODEGA" SortExpression="BODEGA">
                <ItemTemplate>
                    <asp:Label ID="lblBODEGA" runat="server" Text='<%# Bind("BODEGA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOCUMENTO" SortExpression="DOCUMENTO">
                <ItemTemplate>
                    <asp:Label ID="lblDOCUMENTO" runat="server" Text='<%# Bind("DOCUMENTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FECHA_DOC" SortExpression="FECHA_DOC">
                <ItemTemplate>
                    <asp:Label ID="lblFECHA_DOC" runat="server" Text='<%# Bind("FECHA_DOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="FECHA_VENC" SortExpression="FECHA_VENC">
                <ItemTemplate>
                    <asp:Label ID="lblFECHA_VENC" runat="server" Text='<%# Bind("FECHA_VENC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SUBTOTAL" SortExpression="SUBTOTAL">
                <ItemTemplate>
                    <asp:Label ID="lblSUBTOTAL" runat="server" Text='<%# Bind("SUBTOTAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DESCUENTO" SortExpression="DESCUENTO">
                <ItemTemplate>
                    <asp:Label ID="lblDESCUENTO" runat="server" Text='<%# Bind("DESCUENTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMPUESTOS" SortExpression="IMPUESTOS">
                <ItemTemplate>
                    <asp:Label ID="lblIMPUESTOS" runat="server" Text='<%# Bind("IMPUESTOS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOTAL" SortExpression="TOTAL">
                <ItemTemplate>
                    <asp:Label ID="lblTOTAL" runat="server" Text='<%# Bind("TOTAL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SALDO_A" SortExpression="SALDO_A">
                <ItemTemplate>
                    <asp:Label ID="lblSALDO_A" runat="server" Text='<%# Bind("SALDO_A") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SALDO_F" SortExpression="SALDO_F">
                <ItemTemplate>
                    <asp:Label ID="lblSALDO_F" runat="server" Text='<%# Bind("SALDO_F") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VENDEDOR" SortExpression="VENDEDOR">
                <ItemTemplate>
                    <asp:Label ID="lblVENDEDOR" runat="server" Text='<%# Bind("VENDEDOR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PLAZO" SortExpression="PLAZO">
                <ItemTemplate>
                    <asp:Label ID="lblPLAZO" runat="server" Text='<%# Bind("PLAZO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:gridview>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</asp:UpdatePanel>
<!-- Efecto Procesando -->
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div class="updateProgress">
            <span class="updateProgressHijo">Cargando...<img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>images/loading.gif" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> 
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtFecha.ClientID%>");
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
