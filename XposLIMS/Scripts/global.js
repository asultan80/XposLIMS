$(document).ready(function () {
    $("#manageLink").on("click", function() {
        $("iframe", "#ManageLogin").attr("src", "/Manage");
    });
});