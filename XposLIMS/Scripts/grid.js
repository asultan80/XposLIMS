function grid_sendAntiForgery() {
    return { "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() }
}

function grid_error(e) {
    if (e.errors) {
        var message = "There are some errors:\n";
        // Create a message containing all errors.
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        // Display the message
        alert(message);
        // Cancel the changes
        var grid = $("#grid").data("kendoGrid");
        grid.cancelChanges();
    }
}

// set title (tooltip) for update and cancel buttons on Edit event
function grid_onEdit(e) {
    $(e.container).find("td:last").find("a.k-button.k-grid-update").attr("title", "Update");
    $(e.container).find("td:last").find("a.k-button.k-grid-cancel").attr("title", "Cancel");
}

function grid_onDelete(e) {
    grid_confirmDelete(e, this);
}

function grid_deleteConfirmed(event, obj) {
    var grid$ = $(event.target).closest("div.k-widget.k-grid");
    var tr = $(event.target).closest("tr"); //get the row for deletion
    var data = obj.dataItem(tr); //get the row data so it can be referred later
    grid$.data("kendoGrid").dataSource.remove(data);  //prepare a "destroy" request 
    grid$.data("kendoGrid").dataSource.sync();  //actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
}

function grid_confirmDelete(event, obj) {
    $.confirm({
        text: "Are you sure want to delete this row?",
        title: "Confirmation required",
        confirmButton: "Yes",
        cancelButton: "Cancel",
        modalIcon: "/Content/icons/exclamation.png",
        closeTimeout: 0,
        post: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-default",
        dialogClass: "modal-dialog modal-md", // Bootstrap classes for modal size: modal-lg, modal-md, modal-sm
        confirm: function () {
            grid_deleteConfirmed(event, obj);
        },
        cancel: function () {
            
        }

    });
}