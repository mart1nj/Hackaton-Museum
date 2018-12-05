"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bankHub").build();

connection.on("NewAccount", function(id, type, balance, status) {
    balance += ".00";
    var tableId = "accTable";
    var accTable = document.getElementById(tableId).innerHTML;
    accTable += "<tr>" +
        "<td>" + id + "</td>" +
        "<td>" + type + "</td>" +
        "<td>" + balance + "</td>" +
        "<td>" + status + "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm btn-block\" href=\"/Transaction/Index/" + id + "\">Transactions »</a>" +
        "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm btn-block\" href=\"/Transaction/Create?senderId=" + id + "\">New transaction »</a>" +
        "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm btn-block\" href=\"/Insurance/Create?id=" + id + "\">New request »</a>" +
        "</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm btn-block\" href=\"/Insurance/Create?id=" + id + "\">New insurance »</a>" +
        "</td>" +
        "</tr>";

    document.getElementById(tableId).innerHTML = accTable;
});

/* TODO: Saada meetod tööle; lisada balance'i muutmine ka avalehel, kui transaction tehakse
connection.on("NewTransaction", function(datetime, receiverName, receiverId, senderName, senderId, explanation, amount) {
    var tableId = "transTable";
    var transTable = document.getElementById(tableId).innerHTML;
    
    // Sender
    transTable += "<tr>" +
        "<td>03/12/2018 13:32:39</td>" +
        "<td><b>" + receiverName + "</b><br>EE940196072654890000</td>" +
        "<td>" + explanation + "</td>" +
        "<td><span style=\"color: red;\">-10.00</span></td>" +
        "<td>Details</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm\" href=\"/Transaction/CreateWithReceiver?senderId=EE407198383196815000&amp;receiverId=EE940196072654890000\">Make transaction »</a>" +
        "</td>" +
        "</tr>";
    
    // Receiver
    transTable += "<tr>" +
        "<td>03/12/2018 13:32:39</td>" +
        "<td><b>" + senderName + "</b><br>EE407198383196815000</td>" +
        "<td>Let's make some transactions, yo!</td>" +
        "<td><span style=\"color: green;\">10.00</span></td>" +
        "<td>Details</td>" +
        "<td>" +
            "<a class=\"btn btn-primary btn-sm\" href=\"/Transaction/CreateWithReceiver?senderId=EE940196072654890000&amp;receiverId=EE407198383196815000\">Make transaction »</a>" +
        "</td>" +
        "</tr>";
    document.getElementById(tableId).innerHTML = transTable;
});
*/
connection.start();

$("a.markAsRead").click(function (e) {
    e.preventDefault();
    var btn = $(this);
    $.ajax({
        url: $(this).attr("href"),
        type: "GET",
        success: function () {
            var dataCount = $(".fa-bell").attr("data-count");
            if (btn.text().indexOf("Mark as unread") > -1) {
                btn.text("Mark as read");
                btn.closest("li").attr("style", "color:black");
                dataCount++;
            } else {
                btn.text("Mark as unread"); 
                btn.closest("li").attr("style", "color:lightgrey");
                dataCount--;
            }
            $(".fa-bell").attr("data-count", dataCount);
            $(".dropdown-toolbar-title").text("Recent Notifications (" + dataCount + ")");
        }
    });
});

$("a.markAllAsRead").click(function (e) {
    e.preventDefault();
    var btn = $(this);
    $.ajax({
        url: $(this).attr("href"),
        type: "GET",
        success: function () {
            $(".notification").attr("style", "color:lightgrey");
            $(".fa-bell").attr("data-count", 0);
            $(".markAsRead").text("Mark as unread");
            $(".dropdown-toolbar-title").text("Recent Notifications (" + 0 + ")");
        }
    });
});

$(".dropdown-container").on("click.bs.dropdown", function () {
    return $(".dropdown").one("hide.bs.dropdown", function () {
        return false;
    });
});
