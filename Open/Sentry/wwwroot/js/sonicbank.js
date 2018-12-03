"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bankHub").build();

connection.on("NewAccount", function(id, type, balance, status) {
    var tableId = "accTable";
    var accTable = document.getElementById(tableId).innerHTML;
    accTable += "<tr>" +
        "<td>" + id + "</td>" +
        "<td>" + type + "</td>" +
        "<td>" + balance + "</td>" +
        "<td>" + status + "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm\" href=\"/Transaction/Index/" + id + "\">Transactions »</a>" +
        "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm\" href=\"/Transaction/Create?senderId=" + id + "\">New transaction »</a>" +
        "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm\" href=\"/Insurance/Create?id=" + id + "\">New Insurance »</a>" +
        "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm\" href=\"/Insurance/Index/" + id + "\">Account's Insurance »</a>" +
        "</td>" +
        "</tr>";

    document.getElementById(tableId).innerHTML = accTable;
});

connection.start();

$("a.preventRedirect").click(function (e) {

    e.preventDefault();
    var btn = $(this);
    $.ajax({
        url: $(this).attr("href"),
        type: "GET",
        success: function (html) {
            var dataCount = $(".notification-icon").attr("data-count");
            if (btn.text().indexOf("Mark as unread") > -1) {
                btn.text("Mark as read");
                btn.closest("li").attr("style", "color:black");
                dataCount++;
            } else {
                btn.text("Mark as unread"); 
                btn.closest("li").attr("style", "color:lightgrey");
                dataCount--;
            }
            $(".notification-icon").attr("data-count", dataCount);
            $(".dropdown-toolbar-title").text("Recent Notifications (" + dataCount + ")");
        }
    });

});

$(".dropdown .dropdown-menu").on("click.bs.dropdown", function () {
    return $(".dropdown").one("hide.bs.dropdown", function () {
        return false;
    });
});