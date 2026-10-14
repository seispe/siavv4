<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_subirTraspasosQ.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiavQ.frm_subirTraspasosQ" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Subir Traspasos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
     <%-- INGRESAR EL NUMERO DE TRASPASO --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>TRASPASO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtTraspaso" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <asp:Button ID="btnSubir" runat="server" Text="Subir" CssClass="btn btn-success" Width="200px" OnClick="btnSubir_Click"/>
    </div>
    </form>
    </asp:Content>