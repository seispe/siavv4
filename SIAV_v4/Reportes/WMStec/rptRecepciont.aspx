<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="rptRecepciont.aspx.cs" Inherits="SIAV_v4.Reportes.WMStec.rptRecepciont" %>
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
                        <h1 class="page-header">Recepción</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
      <%-- SELECCIONAR EL TIPO DE BUSQUEDA POR NUMERO DE OC Y ESTADO --%>
      <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">&nbsp TODO &nbsp</asp:ListItem>
                <asp:ListItem Value="5">&nbsp PARCIALES POR ORDEN &nbsp</asp:ListItem>
                <asp:ListItem Value="6">&nbsp ESTADOS POR ORDEN &nbsp</asp:ListItem>
            </asp:RadioButtonList> 

        </div>
    <br />
      <%--SELECCIONAR LA OC A BUSCAR--%>
             
        <div class="row">
          <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>OC:</h5></label>  
          <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="Txt_oc" runat="server" CssClass="form-control" Width = "200px" placeholder="#OC" ReadOnly="false"></asp:TextBox>               
          </div>  
            <asp:Button ID="btnGenerar" runat="server" Text="Generar a Excel" CssClass="btn btn-success" Width="200px" OnClick="btnGenerar_Click" />
        </div>
         <br />
   
    <br />
    <br />
</form>
</asp:Content>
