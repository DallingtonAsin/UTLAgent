$(document).ready(function () {
    var title = "List of customers";
    var table = $("#Customers");
    dirtyTable(table, title);
    Console.log("Where is my table");


    function dirtyTable(table, title) {
        table.dataTable({
            paging: true,
            select: true,
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
                    text: '<i class="fa fa-download"></i> Download Excel',
                    title: title,

                }),

                $.extend(true, {}, {
                    extend: 'pdfHtml5',
                    exportOptions: {
                        modifier: {
                            selected: null
                        }
                    },
                    text: '<i class="fa fa-download text-success"></i> Download pdf',
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

});
