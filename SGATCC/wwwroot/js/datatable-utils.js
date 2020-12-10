$.fn.dataTable.moment('DD/MM/YYYY HH:mm:ss');    //Formatação com Hora
$.fn.dataTable.moment('DD/MM/YYYY');    //Formatação sem Hora
$.fn.dataTable.moment('MM/YYYY');    //Formatação sem Hora

function InitDataTable(idTable) {
    var opt = {
        "order": [],
        retrieve: true,
        deferRender: true,
        dom: 'frtip',
        searching: false,
        language: {
            sEmptyTable: "Nenhum registro encontrado",
            sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            sInfoEmpty: "Mostrando 0 até 0 de 0 registros",
            sInfoFiltered: "(Filtrados de _MAX_ registros)",
            sInfoPostFix: "",
            sInfoThousands: ".",
            sLengthMenu: "_MENU_ resultados por página",
            sLoadingRecords: "Carregando...",
            sProcessing: "Processando...",
            sZeroRecords: "Nenhum registro encontrado",
            sSearch: "Pesquisar",
            oPaginate: {
                sNext: "Próximo",
                sPrevious: "Anterior",
                sFirst: "Primeiro",
                sLast: "Último"
            },
            oAria: {
                sSortAscending: ": Ordenar colunas de forma ascendente",
                sSortDescending: ": Ordenar colunas de forma descendente"
            },
            decimal: ",",
            thousands: ".",
            buttons: {
                copy: "<u>C</u>opiar",
                copyTitle: "Dados copiados",
                copyKeys: "Use o teclado ou menu para selecionar o comando de cópia.",
                copySuccess: {
                    1: "Uma linha copiada para a área de transferência",
                    _: "%d linhas copiadas para o área de transferência"
                },
                print: "<u>I</u>mprimir",
                pdf: "PDF",
                excel: "Excel",
                colvis: "<u>V</u>isibilidade"
            },
            select: {
                rows: {
                    _: "%d linhas selecionadas",
                    0: "", //Clique em um linha para seleciná-la
                    1: "1 linha selecionada"
                }
            }
        },
        responsive: {
            details: {
                type: 'column'
            }
        }, "pageLength": 10
    };

    var table = $(idTable).DataTable(opt);
   
}

function InitDataTableExport(idTable, exportTitle, fileName, enableOrder) {
  
    
    var title = exportTitle || $(idTable).closest('.card').find('.card-title').text();

    title = title.replace(/(\r\n|\n|\r)/gm, " ");
    title = title.replace(/ {1,}/g, " ");

    var opt = {
        "ordering": enableOrder === undefined ? true : enableOrder,
        "order": [],
        retrieve: true,
        deferRender: true,
        dom: 'Bfrtip',
        searching: false,
        buttons:
        [

            {
                extend: 'csv',
                title: title,
                fileName: fileName || 'Csv_Export',
                charset: 'utf-8',
                bom: true,
                fieldSeparator: ';',
                text: '<i class="fas fa-file-csv"></i> CSV',
                titleAttr: 'CSV',
                className: 'btn btn-tool',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'excel',
                title: title,
                fileName: fileName || 'Excel_Export',
                charset: 'utf-8',
                text: '<i class="fas fa-file-excel"></i> Excel',
                titleAttr: 'Excel',
                className: 'btn btn-tool',
                exportOptions: {
                    columns: ':visible',
                    format: {
                        body: function (data, row, column, node) {
                            data = $('<p>' + data + '</p>').text();
                            return $.isNumeric(data.replace('.', '').replace(',', '.')) ? data.replace('.','').replace(',', '.') : data;
                        }
                    }
                }
            },
            {
                extend: 'pdf',
                orientation: 'landscape',
                //pageSize: 'LEGAL',
                title: title,
                fileName: fileName || 'pdf_Export',
                text: '<i class="fas fa-file-pdf"></i> PDF',
                titleAttr: 'PDF',
                className: 'btn btn-tool',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'print',
                title: title,
                text: '<i class="fa fa-print"></i> Imprimir',
                titleAttr: 'Print',
                className: 'btn btn-tool',
                exportOptions: {
                    columns: ':visible'
                }
            }
        ],
        language: {
            sEmptyTable: "Nenhum registro encontrado",
            sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            sInfoEmpty: "Mostrando 0 até 0 de 0 registros",
            sInfoFiltered: "(Filtrados de _MAX_ registros)",
            sInfoPostFix: "",
            sInfoThousands: ".",
            sLengthMenu: "_MENU_ resultados por página",
            sLoadingRecords: "Carregando...",
            sProcessing: "Processando...",
            sZeroRecords: "Nenhum registro encontrado",
            sSearch: "Pesquisar",
            oPaginate: {
                sNext: "Próximo",
                sPrevious: "Anterior",
                sFirst: "Primeiro",
                sLast: "Último"
            },
            oAria: {
                sSortAscending: ": Ordenar colunas de forma ascendente",
                sSortDescending: ": Ordenar colunas de forma descendente"
            },
            decimal: ",",
            thousands: ".",
            buttons: {
                copy: "<u>C</u>opiar",
                copyTitle: "Dados copiados",
                copyKeys: "Use o teclado ou menu para selecionar o comando de cópia.",
                copySuccess: {
                    1: "Uma linha copiada para a área de transferência",
                    _: "%d linhas copiadas para o área de transferência"
                },
                print: "<u>I</u>mprimir",
                pdf: "PDF",
                excel: "Excel",
                colvis: "<u>V</u>isibilidade"
            },
            select: {
                rows: {
                    _: "%d linhas selecionadas",
                    0: "", //Clique em um linha para seleciná-la
                    1: "1 linha selecionada"
                }
            }
        },
        responsive: {
            details: {
                type: 'column'
            }
        }, "pageLength": 10
    };

    var table = $(idTable).DataTable(opt);

    var tools = $(idTable).closest('.card').find('.card-tools');

    $(tools).find(".dt-buttons").remove();
    //$(".dt-buttons")
    table.buttons().container()
        .appendTo($(tools));
}