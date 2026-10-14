<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_ContenedoresxDia.aspx.cs" Inherits="SIAV_v4.Proyectos.Importaciones.frm_ContenedoresxDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
       .datepicker-input {
            cursor: pointer;
        }
    </style>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Ingreso Contenedores por Dia</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <br />
      <%-- INGRESAR EL NUMERO DE CONTENEDORES --%>
 <div class="row">
     <label class="col-md-1 col-sm-1 col-xs-12 label label-info" ><h5>FECHA:</h5></label>  
    <div class="col-md-2 col-sm-2 col-xs-12" >
        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control datepicker-input" style="width:150px"></asp:TextBox>
    </div>
     <label class="col-md-2 col-sm-3 col-xs-12 label label-info" style="width:150px"><h5>#CONTENEDORES:</h5></label>  
     <div class="col-md-2 col-sm-3 col-xs-12">
         <asp:TextBox style="width:100px" ID="txtCont" runat="server" CssClass="form-control" oninput="this.value = this.value.replace(/[^0-9]/g,'');" ></asp:TextBox>
     </div>
     <label class="col-md-2 col-sm-3 col-xs-12 label label-info" style="width:150px"><h5>#CARGASSUELTAS:</h5></label>  
    <div class="col-md-2 col-sm-3 col-xs-12">
        <asp:TextBox style="width:100px" ID="txtCargas" runat="server" CssClass="form-control" oninput="this.value = this.value.replace(/[^0-9]/g,'');" ></asp:TextBox>
    </div>
     <asp:Button ID="btnIngresar" runat="server" Text="Ingresar Contenedores" CssClass="btn btn-success" Width="200px" OnClick="btnIngresar_Click" />
 </div>
 <br />
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
                format: "yyyy-mm-dd",
                autoclose: true,
                todayHighlight: true,
                orientation: "bottom"
            }).on('changeDate', function () {
                $(this).datepicker('hide');
            });

            dp.datepicker('setDate', new Date());
        });
    </script>
</asp:Content>