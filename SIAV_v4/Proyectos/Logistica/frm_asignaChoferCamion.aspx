<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_asignaChoferCamion.aspx.cs" Inherits="SIAV_v4.Proyectos.Logistica.frm_asignaChoferCamion" %>
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
                        <h1 class="page-header">Asignación Conductores - Camiones</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
             <asp:UpdatePanel id="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <div style="display: flex; justify-content: center;">
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar Conductores" CssClass="btn btn-success" Width="200px" OnClick="btnAsignar_Click" />
        </div>
        </ContentTemplate>
                   <Triggers>
                    <asp:PostBackTrigger ControlID="btnAsignar" />
                </Triggers>
                 </asp:UpdatePanel>
       <br />
        <div style="display: flex; justify-content: center;">
      <asp:UpdatePanel id="upCrudGrid" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:gridview id="gv_conductores" runat="server"
        autogeneratecolumns="False" cellpadding="4" Width="550px"
        cssclass="grid"  AlternatingRowStyle-BackColor = "#C2D69B" datakeynames="placa"  HeaderStyle-BackColor = "black"
        allowpaging="True" AllowSorting="True" OnRowDataBound="gv_conductores_RowDataBound" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" PageSize="15" >
        <Columns>   
        <asp:TemplateField ItemStyle-Width = "10px"  HeaderText = "CONDUCTOR">
            <ItemTemplate>
                <%--<asp:Label ID="lblBodCompras" runat="server" Text='<%# Eval("BodCompras")%>'></asp:Label>--%>
                <asp:HiddenField ID="hfidconductor" runat="server" Value='<%# Eval("idconductor")%>' />
                <asp:DropDownList ID="ddlConductor" runat="server" CssClass="form-control" Width="350px"></asp:DropDownList>
            </ItemTemplate>          
            <ItemStyle Width="10px" />
        </asp:TemplateField>
         <asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "PLACA" >
            <ItemTemplate>
                <asp:Label ID="lblplaca" runat="server" Font-Bold="true" Text='<%# Eval("placa")%>'></asp:Label>
            </ItemTemplate> 
            <ItemStyle Width="100px" />
        </asp:TemplateField> 
       </Columns>
         <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
         
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
         
    </asp:gridview>
    </ContentTemplate>
    <Triggers>
        
    </Triggers>
</asp:UpdatePanel>
            <!-- Efecto Procesando -->
        <asp:UpdateProgress id="updateProgress" runat="server">
            <ProgressTemplate>
                <div class="updateProgress">
                    <span class="updateProgressHijo">Cargando...<img src="/SIAV/Img/loading.gif" /></span>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
            </div>
        </form>
    </asp:Content>