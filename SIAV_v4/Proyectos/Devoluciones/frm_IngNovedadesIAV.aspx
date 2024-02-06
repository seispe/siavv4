<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_IngNovedadesIAV.aspx.cs" Inherits="SIAV_v4.Proyectos.Devoluciones.frm_IngNovedadesIAV" %>

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
                        <h1 class="page-header">Traspaso Devoluciones a Cuarentena</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                <br />
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-info" OnClick="btnCargar_Click" OnClientClick="clickOnce(this, 'Cargando...')" ValidationGroup="Cargar"
                    UseSubmitBehavior="false" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" Width="250px" TextMode="MultiLine" placeholder="Motivo"></asp:TextBox>
            </div>
              
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                <asp:Button ID="btnGenerar" runat="server" Text="Generar Traspaso" CssClass="btn btn-success" OnClick="btnGenerar_Click"
                       OnClientClick="clickOnce(this, 'Generando...')" UseSubmitBehavior="false"  ValidationGroup="Generar"/>
            </div>
                         
        </div>
        <br />
        <asp:GridView ID="grTabla" runat="server" CssClass="table table-bordered table-hover"></asp:GridView>
    
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }
    </script>
</asp:Content>
