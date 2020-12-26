var dataTable

$(document).ready(function () {
    loadDataTable()
})

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
                "render": function (bookId) {
                    return `
                        <div class="text-center">
                            <a href="/BookList/Edit?id=${bookId}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">
                                Edit
                            </a>
                            &nbsp;
                            <a class="btn btn-danger text-white" style="cursor:pointer; width:70px;">
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

    //DataTable methods comes from datatable package, introduced Index razor page.
}
