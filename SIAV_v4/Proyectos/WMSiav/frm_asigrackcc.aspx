<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_asigrackcc.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_asigrackcc" %>
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
                        <h1 class="page-header">Asignación Racks Conteo Cíclico</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <%--COMBO DE USUARIOS Y AREAS--%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>CONTEO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlConteo" runat="server" CssClass="form-control" Width="250px" OnSelectedIndexChanged="ddlConteo_SelectedIndexChanged"></asp:DropDownList>
        </div>
        

          <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
        <div class="row">
            
        <asp:Button ID="btnNuevoC" runat="server" class="btn btn-success" Text="Nuevo Conteo" Width="200px" OnClick="btnNuevoC_Click" AutoPostBack="true"/>
            
        </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

    </div>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>USUARIO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
        </div>
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>AREA:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" Width="250px" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" Text="Guardar" Width="200px" OnClick="btnGuardar_Click"/>
    </div>
    <br />
    <div class="row">
         <div style="height: 500px; overflow:scroll" class="col-sm-3 col-lg-3">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <asp:GridView ID="gvAvanceUsuario" runat="server" AutoGenerateColumns="False" CellPadding="8"
                   AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="100000" HorizontalAlign="Right"  >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
            <asp:TemplateField HeaderText="Usuario" SortExpression="Usuario">
                <ItemTemplate>
                    <asp:Label ID="lblusuario" runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="% Avance" SortExpression="% Avance" Visible="true">
                <ItemTemplate>
                    <asp:Label ID="lblporcentaje" runat="server" Text='<%# Eval("PORCENTAJETAREA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
                   </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    </asp:GridView>
        </ContentTemplate>
</asp:UpdatePanel>
        </div>
        <div  class="col-sm-9 col-lg-9" pull-right>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
    <asp:GridView ID="gvRacks" runat="server" AutoGenerateColumns="False" CellPadding="8"
       AllowPaging="True" AllowSorting="True" CssClass="grid"  ForeColor="#333333" GridLines="None" PageSize="1000" HorizontalAlign="Left" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Rack" SortExpression="Rack" >
                    <ItemTemplate>
                        <asp:Label ID="lblracks" runat="server" Text='<%# Bind("racks") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Perchas" SortExpression="Perchas" >
                    <ItemTemplate>
                        <asp:Label ID="lblperchas" runat="server" Text='<%# Bind("perchas") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="Area" SortExpression="Area" >
                    <ItemTemplate>
                        <asp:Label ID="lblarea" runat="server" Text='<%# Bind("area") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    </asp:GridView>
</ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "gvRacks" /> 
    </Triggers>
   </asp:UpdatePanel>
            </div>
    </div>
    
<%-- MODAL INGRESAR OBSERVACION --%>
    <div class="modal fade" id="obs">
        <div class="modal-dialog">
            <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"data-dismiss="modal"aria-hidden="true">×</button>
                    <h3 id="busPedidosConsol">Ingrese una Observación</h3>
                    <asp:HiddenField ID="hfConsolidado" runat="server"/>
                    <br />
                </div>
                <div class="container"></div>
                <div class="modal-body">
                  <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox ID="txtObservación" runat="server" CssClass="form-control" Width="250px" TextMode="MultiLine" ></asp:TextBox>
                            </div>
                    </div>
                </div>
                <div class="modal-footer">	
                       <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" CssClass=" btn btn-success" />
                    <button class="btn btn-info"data-dismiss="modal"aria-hidden="true">Cancel</button>
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