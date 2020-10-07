<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIAV_v4.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- Jqeury + Bootstrap -->
 <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/bootstrap.min.css" rel="stylesheet" />
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/jquery.js"></script>
   <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblError" Runat="server"></asp:Label>    
    <div class="top-content">
        	<div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong>GRUPO </strong>ALVARADO</h1>
                            <div class="description">
                            	<p>
	                            	Trabajando por el bienestar de cada empleado!
                            	</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>SIAV v4.0</h3>
                            		<p>Ingrese su usuario y contraseña</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-lock"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <form id="form1" runat="server" class="form-inline">
			                    	<div class="form-group">
                                        <asp:TextBox ID="txtUsername" Runat="server" class="form-control"  placeholder="Usuario" required autofocus></asp:TextBox>
                                    </div>
			                        <div class="form-group">
                                        <asp:TextBox ID="txtPassword" Runat="server" class="form-control" TextMode="Password" placeholder="Contraseña" required autofocus></asp:TextBox>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlEmpresa" class="form-control" runat="server" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                    <br />
                                    <br />
                                    
                                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn" OnClick="btnIngresar_Click"/>
                                </form>
		                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
               <div class="col-sm-6 col-sm-offset-3 center">
                    <div class="panel panel-primary">
                          <div class="panel-body">
                              <img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/logoIAVGROUP.png" width="50px" /><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoRectima.png" width="200px"/><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoAccpass.png" width="200px" /><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoAllparts.png" width="200px"/><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoCorpal.png" width="200px"/><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoIAV.png" width="200px"/><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoDepo.png" width="200px"/><img src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>logos/LogoCAO.png" width="200px"/>
                          </div>
                    </div>
               </div>
</asp:Content>
