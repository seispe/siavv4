$(function () {
    GetCustomers(1);
});
$("[id*=txtSearch]").live("keyup", function () {
    GetCustomers(parseInt(1));
});
$(".Pager .page").live("click", function () {
    GetCustomers(parseInt($(this).attr('page')));
});
function SearchTerm() {
    return jQuery.trim($("[id*=txtSearch]").val());
};
function GetCustomers(pageIndex) {
    $.ajax({
        type: "POST",
        url: "Default.aspx/GetCustomers",
        data: '{searchTerm: "' + SearchTerm() + '", pageIndex: ' + pageIndex + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
}
var row;
function OnSuccess(response) {
    var xmlDoc = $.parseXML(response.d);
    var xml = $(xmlDoc);
    var customers = xml.find("Customers");
    if (row == null) {
        row = $("[id*=gvCustomers] tr:last-child").clone(true);
    }
    $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();
    if (customers.length > 0) {
        $.each(customers, function () {
            var customer = $(this);
            $("td", row).eq(0).html($(this).find("ContactName").text());
            $("td", row).eq(1).html($(this).find("CustomerID").text());
            $("td", row).eq(2).html($(this).find("City").text());
            $("[id*=gvCustomers]").append(row);
            row = $("[id*=gvCustomers] tr:last-child").clone(true);
        });
        var pager = xml.find("Pager");
        $(".Pager").ASPSnippets_Pager({
            ActiveCssClass: "current",
            PagerCssClass: "pager",
            PageIndex: parseInt(pager.find("PageIndex").text()),
            PageSize: parseInt(pager.find("PageSize").text()),
            RecordCount: parseInt(pager.find("RecordCount").text())
        });

        $(".ContactName").each(function () {
            var searchPattern = new RegExp('(' + SearchTerm() + ')', 'ig');
            $(this).html($(this).text().replace(searchPattern, "<span class = 'highlight'>" + SearchTerm() + "</span>"));
        });
    } else {
        var empty_row = row.clone(true);
        $("td:first-child", empty_row).attr("colspan", $("td", row).length);
        $("td:first-child", empty_row).attr("align", "center");
        $("td:first-child", empty_row).html("No records found for the search criteria.");
        $("td", empty_row).not($("td:first-child", empty_row)).remove();
        $("[id*=gvCustomers]").append(empty_row);
    }
};