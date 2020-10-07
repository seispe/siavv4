﻿<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_subirpvc.aspx.cs" Inherits="SIAV_v4.Proyectos.WMSiav.frm_subirpvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Subir a Cuarentena</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <br />
    <%-- SELECCIONAR EL TIPO A SUBIR FACTURA O NOTA DE CREDITO --%>
     <div>
            <asp:RadioButtonList ID="rdbTipo" runat="server" class="lbl padding-8" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">FACTURA</asp:ListItem>
                <asp:ListItem Value="2">DEVOLUCION</asp:ListItem>
            </asp:RadioButtonList> 
    </div>
    <br />
     <%-- INGRESAR EL NUMERO DE PEDIDO --%>
    <div class="row">
        <label class="col-md-1 col-sm-1 col-xs-12 label label-info"><h5>DOCUMENTO:</h5></label>  
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:TextBox ID="txtFact" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <asp:Button ID="btnSubir" runat="server" Text="Subir Cuarentena" CssClass="btn btn-success" Width="200px" OnClick="btnSubir_Click" />
    </div>
    <br />
</form>
</asp:Content>