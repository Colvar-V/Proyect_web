function ListaEquipo() {
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/Coord/GetListEquipo',
        data: {},
        contentType: "aplication/json; chaset=utf-8",
        async: false,
        success: function (listado) {
            console.log(listado);
            var grid = $('#gri').grid({
                dataSource: listado,
                columns: [
                    { field: 'Id', sortable: true },
                    { field: 'Serial', sortable: true },
                    { field: 'Modelo', sortable: true },
                    { field: 'Componentes', sortable: true },
                    { field: 'Marca', sortable: true },
                    { field: 'Proyecto', sortable: true },
                    { field: 'Estado', sortable: true }
                ],
                pager: { limit: 5}
            });
        },
        error: function (error) {
            alert("Error!!!!!!");
        }
    })
}