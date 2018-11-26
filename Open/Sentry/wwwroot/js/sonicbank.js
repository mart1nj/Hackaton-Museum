"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bankHub").build();

connection.on("NewAccount", function(accNumber, type, balance,  status) {
    var accTable = document.getElementById("accountTable").innerHTML;
    accTable += "<tr><td></td></tr>";
});
