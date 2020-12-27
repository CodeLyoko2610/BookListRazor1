var dataTable

$(document).ready(function () {
    loadDataTable()
})

//The DataTable method (on line 8) comes from datatable package, introduced Index razor page.   
function loadDataTable() {
    dataTable = $('#DataTable_Load').DataTable({
        "ajax": {
            "url": "/api/books",
            "type": "GET",
            "datatype": "json",
        },
        //name of data follows camel case rule, even thought the actual name might be capitalized
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (res) {
                    return `
                        <div class="text-center">
                            <a href="/BookList/Edit?id=${res}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">
                                Edit
                            </a>
                            &nbsp;
                            <a onclick=Delete("api/books?id=${res}") class="btn btn-danger text-white" style="cursor:pointer; width:70px;">
                                Delete
                            </a>
                        </div>
                    `
                },
                "width": "40%",
            },
        ],
        "language": {
            "emptyTable":"No data found."
        },
        "width:":"100%"
    })    
}

function Delete(url) {
    console.log('Inside function Delete')
    swal({
        title: "Are you sure to delete this book?",
        text: "Once deleted, the book cannot be recovered.",
        icon: "warning",
        dangerMode: true,
        buttons: true,
    }).then(userRes => {
        if (userRes) {
            $.ajax({
                type: "DELETE",
                url: url,                
                success: function (controllerRes) {
                    if (controllerRes.success) {
                        toastr.success(controllerRes.message)
                        dataTable.ajax.reload()
                    } else {
                        toastr.error(controllerRes.message)
                    }
                }
            })
        }
    })
}