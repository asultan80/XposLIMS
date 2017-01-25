$(document).ready(function () {
    $("#manageLink").on("click", function() {
        $("iframe", "#ManageLogin").attr("src", "/Manage");
    });

    $("a.progressbar-loading").on("click", function (e) {
        e.preventDefault();
        var href = $(this).attr("href");

        showLoadingProgressbar();

        setTimeout(function() {
            window.location.href = href;
        }, 500);

        return false;
    });

    function showLoadingProgressbar() {
        $("#curtain").show();
    }
});
