
function designTable(table, title) {
    table.dataTable({
        paging: true,
        select: false,
        "bLengthChange": true,
        oLanguage: {
            sLengthMenu: "Show _MENU_ entries",
        },
        dom: '<"top"lf><B>rt<"bottom"<ip>>',
        buttons: [

            $.extend(true, {}, {
                extend: 'excelHtml5',
                exportOptions: {
                    modifier: {
                        selected: null
                    }
                },
                text: '<i class="fa fa-download"></i> Excel',
                title: title,

            }),

            $.extend(true, {}, {
                extend: 'pdfHtml5',
                exportOptions: {
                    modifier: {
                        selected: null
                    }
                },
                text: '<i class="fa fa-download text-success"></i>PDF',
                title: title,

            }),

            $.extend(true, {}, {
                extend: 'print',
                exportOptions: {
                    modifier: {
                        selected: null
                    }
                },
                text: '<i class="fa fa-print text-dark"></i> Print',
                title: title,

            }),
        ]


    });
}