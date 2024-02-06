<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_subirExcel.aspx.cs" Inherits="SIAV_v4.Proyectos.Pruebas.frm_subirExcel" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%--<a href="<% Response.Write(ConfigurationManager.AppSettings["PATH"]); %>Proyectos/Comisiones/frm_MenuConfig.aspx" class="btn btn-primary btn-sm pull-left"><i class="fa fa-arrow-circle-left"></i> Regresar</a>              --%>
                        <h1 class="page-header">SUBIR EXCEL</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div class="form-group col-sm-10">
            <label for="FileUpload1">Archivo</label>
            <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server" />
        </div>
        <div class="form-group col-sm-2">
            <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-block btn-success mt-4" OnClick="btnCargar_Click" />
        </div>
    </form>
</asp:Content>
