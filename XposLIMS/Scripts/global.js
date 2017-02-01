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

    $(".open-confirm").confirm();

    function testJsConfirm() {
        $.confirm({
            text: "Are you sure you want to delete that comment?",
            title: "Confirmation required",
            confirmButton: false,
            cancelButton: false,
            closeTimeout: 5000,
            post: true,
            confirmButtonClass: "btn-danger",
            cancelButtonClass: "btn-default",
            dialogClass: "modal-dialog modal-lg", // Bootstrap classes for large modal
            confirm: function () {
                alert("You just confirmed.");
            },
            cancel: function () {
                alert("You cancelled.");
            }

        });
    }


});
