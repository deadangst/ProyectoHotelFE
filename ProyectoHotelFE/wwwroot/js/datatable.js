function initializeDataTable(tableId) {
    $(document).ready(function () {
        $(tableId).DataTable({
            "pageLength": 10,
            "language": {
                "lengthMenu": "Mostrar _MENU_ entradas por página",
                "zeroRecords": "No se encontraron resultados",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay registros disponibles",
                "infoFiltered": "(filtrado de _MAX_ registros totales)",
                "paginate": {
                    "first": "Primero",
                    "last": "Último",
                    "next": " > Siguiente",
                    "previous": "Anterior < "
                }
            },
            "dom": '<"top"l>rt<"bottom"ip><"clear">' 
        });
    });
}
