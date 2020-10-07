<%@ Page Language="C#" MasterPageFile="~/Plantilla/Menu.Master" AutoEventWireup="true" CodeBehind="frm_HRVehiculos.aspx.cs" Inherits="SIAV_v4.Proyectos.Adata.frm_HRVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>css/css_grid.css" rel="stylesheet" />
    <script src="<% Response.Write(ConfigurationManager.AppSettings["PATH_RECURSOS"]); %>js/js_prueba.js" type="text/javascript" ></script> 
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js" type="text/javascript"></script>  
    <script type="text/javascript">
        // event to fire on Save button click //
        $(document).on('click', '#btnSave', function () {
            var data = HTMLtbl.getData($('#tbldata'));
            var parameters = {};
            parameters.array = data;

            var request = $.ajax({
                async: true,
                cache: false,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "frm_HRVehiculos.aspx/SaveData",
                data: JSON.stringify(parameters)
            });

            request.done(function (msg) {
                alert("Row saved " + msg.d);
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });

        });

        //function to convert HTML table to jagged array//
        var HTMLtbl =
            {
                getData: function (table) {
                    var data = [];
                    table.find('tr').not(':first').each(function (rowIndex, r) {
                        var cols = [];
                        $(this).find('td').each(function (colIndex, c) {

                            if ($(this).children(':text,:hidden,textarea,select').length > 0)    //text//hidden//textarea//select
                                cols.push($(this).children('input,textarea,select').val().trim());

                                // if dropdown text is needed then uncomment it and remove SELECT from above IF condition// 
                                // else if ($(this).children('select').length > 0)
                                // cols.push($(this).find('option:selected').text());

                            else if ($(this).children(':checkbox').length > 0)                    // checkbox
                                cols.push($(this).children(':checkbox').is(':checked') ? 1 : 0);  //or true false
                            else
                                cols.push($(this).text().trim());                                // get td Value
                        });
                        data.push(cols);
                    });
                    return data;
                }
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
      <%--Titulos y el lblError para el control de Errores--%>
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <h1 class="page-header">Hoja de Ruta de Vehículos</h1>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    <div>
    <div>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
        <br/>
        <asp:Label ID="lblResultado" runat="server" ></asp:Label>
    </div>
    <br />
    <br />
    
    <div class="container">
    <div class="row clearfix">
    	<div class="col-md-12 table-responsive">
			<table class="table table-bordered table-hover table-sortable" id="tab_logic">
				<thead>
					<tr >
						<th class="text-center">
							Name
						</th>
						<th class="text-center">
							Email
						</th>
						<th class="text-center">
							Notes
						</th>
    					<th class="text-center">
							Option
						</th>
        				<th class="text-center" style="border-top: 1px solid #ffffff; border-right: 1px solid #ffffff;">
						</th>
					</tr>
				</thead>
				<tbody>
    				<tr id='addr0' data-id="0" class="hidden">
						<td data-name="name">
						    <input type="text" name='name0'  placeholder='Name' class="form-control"/>
                            
						</td>
						<td data-name="mail">
						    <input type="text" name='mail0' placeholder='Email' class="form-control"/>
                            
						</td>
						<td data-name="desc">
						    <textarea name="desc0" placeholder="Description" class="form-control"></textarea>
                            
						</td>
    					<td data-name="sel">
                            <select name="sel0">
        				        <option value"">Select Option</option>
    					        <option value"1">Option 1</option>
        				        <option value"2">Option 2</option>
        				        <option value"3">Option 3</option>
						    </select>
						</td>
                        <td data-name="del">
                            <button nam"del0" class='btn btn-danger glyphicon glyphicon-remove row-remove'>X</button>
                        </td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>
	<a id="add_row" class="btn btn-default pull-right">Add Row</a>
</div>
         <div id="divbtn">
                <input id="btnSave" type="button" value="Save" />
            </div>
</div>

    <table id="tbldata" style="width: 100%;" border="1">
    <tr>
        <th>Name</th>
        <th>Last Name</th>
        <th>Age</th>
        <th>Address</th>
        <th>comments</th>
        <th>Course</th>
        <th>Is Eligible ?</th>
        <th>Hidden fields</th>
    </tr>
    <tr>
        <td>Amit</td>
        <td>Singh</td>
        <td>23</td>
        <td>
            <input type="text" value="Amit's Address" /></td>
        <td>
            <textarea rows="4" cols="50">your comments </textarea>
        </td>
        <td>
            <select>
                <option value="0">MBA</option>
                <option value="1">B.E.</option>
            </select>
            
        </td>
        <td>
            <input type="checkbox" />
        </td>
        <td>
            <input type="hidden" value="1" />
        </td>
    </tr>
    <tr>
        <td>Sakshi</td>
        <td>Singh</td>
        <td>20</td>
        <td>
            <input type="text" value="Sakshi's Address" /></td>
        <td>
            <textarea rows="4" cols="50">your comments</textarea>
        </td>
        <td>
            <select>
                <option value="0">MBA</option>
                <option value="1">B.E.</option>
            </select>
            
        </td>
        <td>
            <input type="checkbox" />
        </td>
        <td>
            <input type="hidden" value="2" />
        </td>
    </tr>
    <tr>
        <td>Ram</td>
        <td>Singh</td>
        <td>25</td>
        <td>
            <input type="text" value="Ram's Address" /></td>
        <td>
            <textarea rows="4" cols="50">your comments </textarea>
        </td>
        <td>
            <select>
                <option value="0">MBA</option>
                <option value="1">B.E.</option>
            </select>
         </td>
        <td>
            <input type="checkbox" />
        </td>
        <td>
            <input type="hidden" value="3" />
        </td>
    </tr>
    <tr>
        <td>Rahul</td>
        <td>Sharma</td>
        <td>23</td>
        <td>
            <input type="text" value="Rahul's Address" /></td>
        <td>
            <textarea rows="4" cols="50">your comments </textarea>
        </td>
        <td>
            <select>
                <option value="0">MBA</option>
                <option value="1">B.E.</option>
            </select>
            
        </td>
        <td>
            <input type="checkbox" />
        </td>
        <td>
            <input type="hidden" value="4" />
        </td>
    </tr>
        <tr>
        <td>Sebastian</td>
        <td>Pozo</td>
        <td>24</td>
        <td>
            <input type="text" value="Sebastian Direccion" /></td>
        <td>
            <textarea rows="4" cols="50">your comments </textarea>
        </td>
        <td>
            <select>
                <option value="0">MBA</option>
                <option value="1">B.E.</option>
            </select>
            
        </td>
        <td>
            <input type="checkbox" />
        </td>
        <td>
            <input type="hidden" value="5" />
        </td>
    </tr>
</table>
       <%-- <div id="divbtn">
                <input id="btnSave" type="button" value="Save" />
            </div>--%>
</form>
 
</asp:Content>