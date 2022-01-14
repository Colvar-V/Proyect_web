function InsertError() {
    var nombrejs = $("#Nombre").val();
    var descripcionjs = $("#Descripcion").val();
    var solucionjs = $("#Solucion").val();
    var idmodelojs = $("#IdModelo").val();
    if (nombrejs !== "" && descripcionjs !== "" && solucionjs !== "" && idmodelojs !== "") {
        var model = JSON.stringify({
            Nombre: nombrejs, Descripcion: descripcionjs, Solucion: solucionjs, IdModelo: idmodelojs
        });
        $.ajax({
            type: 'POST',
            dataType: 'JSON',
            url: '/Tecnico/PostInsertError',
            data: model,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.CODIGO === "1") {
                    $("#Nombre").val("");
                    $("#Descripcion").val("");
                    $("#Solucion").val("");
                    $("#IdModelo").val("");
                    alert(data);
                }
                else {
                    alert("ERROR!!!!!");
                }
            },
            error: function (error) {
                alert("ERROR!!!!!");
            }
        })
    }
}
function ListaError() {
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/Tecnico/GetListError',
        data: {},
        contentType: "aplication/json; chaset=utf-8",
        async: false,
        success: function (listado) {
            console.log(listado);
            var grid = $('#Errores').grid({
                dataSource: listado,
                columns: [
                    { field: 'Nombre', sortable: true },
                    { field: 'Modelo', sortable: true },
                    { field: 'Descripcion', sortable: true },
                    { field: 'Solucion', sortable: true }
                    
                ],
                pager: { limit: 5 }
            });
        },
        error: function (error) {
            alert("Error!!!!!!");
        }
    })
}