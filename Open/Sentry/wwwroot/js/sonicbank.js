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
