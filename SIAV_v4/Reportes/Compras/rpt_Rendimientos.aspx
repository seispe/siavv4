<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rpt_Rendimientos.aspx.cs" Inherits="SIAV_v4.Reportes.Compras.rpt_Rendimientos" %>
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
                <h1 class="page-header">REPORTE DE RENDIMIENTOS (BCCT 3 motor 4)</h1>
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
        <label class="control-label col-lg-1 col-md-1 col-sm-3 col-xs-4">Fecha:</label>
        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-8">
            <asp:TextBox ID="txtFecha" runat="server" Enabled="True" class="form-control" placeholder="Fecha"></asp:TextBox>
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
        cssclass="grid" datakeynames="RECIBO" forecolor="#333333"
        gridlines="None" OnPageIndexChanging="gvCuentas_PageIndexChanging"
        allowpaging="True" pagesize="200">
        <AlternatingRowStyle BackColor="White" />
        <Columns>     
            <asp:TemplateField HeaderText="AÑO" SortExpression="AÑO">
                <ItemTemplate>
                    <asp:Label ID="lblAño" runat="server" Text='<%# Bind("AÑO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MES" SortExpression="MES">
                <ItemTemplate>
                    <asp:Label ID="lblMes" runat="server" Text='<%# Bind("MES") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RECIBO" SortExpression="RECIBO">
                <ItemTemplate>
                    <asp:Label ID="lblrecibo" runat="server" Text='<%# Bind("RECIBO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LINEA" SortExpression="LINEA">
                <ItemTemplate>
                    <asp:Label ID="lblLinea" runat="server" Text='<%# Bind("LINEA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="PROVEEDOR" SortExpression="PROVEEDOR">
                <ItemTemplate>
                    <asp:Label ID="lblproveedor" runat="server" Text='<%# Bind("PROVEEDOR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="F_RECIBIMIENTO" SortExpression="F_RECIBIMIENTO">
                <ItemTemplate>
                    <asp:Label ID="lblSUBTOTAL" runat="server" Text='<%# Bind("F_RECIBIMIENTO") %>'></asp:Label> 				
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CANT" SortExpression="CANT">
                <ItemTemplate>
                    <asp:Label ID="lblTOTAL_COST_DESCARGA" runat="server" Text='<%# Bind("CANT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FOB" SortExpression="FOB">
                <ItemTemplate>
                    <asp:Label ID="lblCOSTO_DESCARG" runat="server" Text='<%# Bind("FOB") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="CIF" SortExpression="CIF">
                <ItemTemplate>
                    <asp:Label ID="lblDESC_COSTO_DESCARG" runat="server" Text='<%# Bind("CIF") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOTAL_FOB" SortExpression="TOTAL_FOB">
                <ItemTemplate>
                    <asp:Label ID="lblVALOR_DESCARG" runat="server" Text='<%# Bind("TOTAL_FOB") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOTAL_CIF" SortExpression="TOTAL_CIF">
                <ItemTemplate>
                    <asp:Label ID="lblCOMPRA" runat="server" Text='<%# Bind("TOTAL_CIF") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="vta_15dias" SortExpression="vta_15dias">
                <ItemTemplate>
                    <asp:Label ID="lblvtaMes15" runat="server" Text='<%# Bind("vta_15dias") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="vta_1mes" SortExpression="vta_1mes">
                <ItemTemplate>
                    <asp:Label ID="lblvtaMes1" runat="server" Text='<%# Bind("vta_1mes") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="vta_2meses" SortExpression="vta_2meses">
                <ItemTemplate>
                    <asp:Label ID="lblvtaMes2" runat="server" Text='<%# Bind("vta_2meses") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="VTA_MES_CORTE"  SortExpression="VTA_MES">
                <ItemTemplate>
                    <asp:Label ID="lblvtaMes" runat="server" Text='<%# Bind("VTA_MES") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="REND" SortExpression="REND">
                 <ItemTemplate>
                    <asp:Label ID="lblRend" runat="server" Text='<%# Bind("REND") %>'></asp:Label>
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
            var dp = $("#<%= txtFecha.ClientID%>");
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
