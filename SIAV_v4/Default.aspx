<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIAV_v4.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- Jqeury + Bootstrap -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">Menu Inicial</h1>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</div>
<br />
<div class="row">    
    <asp:Label ID="lblMenuInicial" runat="server" Text=""></asp:Label>    
</div>
</form>
</asp:Content>
