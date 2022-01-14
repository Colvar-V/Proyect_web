function Agregarherr() {
    window.location.href = "AgregarHerr";
}
function ListaHerra() {
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/Coord/GetListHerra',
        data: {},
        contentType: "aplication/json; chaset=utf-8",
        async: false,
        success: function (listado) {
            console.log(listado);
            var grid = $('#grid').grid({
                dataSource: listado,
                columns: [
                    { field: 'Id', sortable: true },
                    { field: 'Nombre', sortable: true },
                    { field: 'Descripcion', sortable: true },
                    { field: 'N_Archivo', sortable: true },
                    { field: 'Proyecto', sortable: true },
                    { with: 64, tmpl: '<span class="material-icons gj-cursor-pointer">Descargar</span>', align: 'centro', events: { 'click': Editarlink}}
                ],
                pager: { limit: 5 }
            });
        },
        error: function (error) {
            alert("Error!!!!!!");
        }
    })
}
function Editarlink(e) {
    var info = e.data.record;
    window.location.href = '/Datos/'+info.N_Archivo;

}

function ListaTec() {
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/Coord/GetListTec',
        data: {},
        contentType: "aplication/json; chaset=utf-8",
        async: false,
        success: function (listado) {
            console.log(listado);
            var grid = $('#Tec').grid({
                dataSource: listado,
                columns: [
                    { field: 'Id', sortable: true },
                    { field: 'Nombre', sortable: true },
                    { field: 'Cargo', sortable: true },
                    { field: 'Usuario', sortable: true },
                    { field: 'Contrasena', sortable: true },
                    { field: 'Telefono', sortable: true },
                    { field: 'Correo', sortable: true },
                ],
                pager: { limit: 5 }
            });
        },
        error: function (error) {
            alert("Error!!!!!!");
        }
    })
}

function ListaCoord() {
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/Coord/GetListCoord',
        data: {},
        contentType: "aplication/json; chaset=utf-8",
        async: false,
        success: function (listado) {
            console.log(listado);
            var grid = $('#Coord').grid({
                dataSource: listado,
                columns: [
                    { field: 'Id', sortable: true },
                    { field: 'Nombre', sortable: true },
                    { field: 'Usuario', sortable: true },
                    { field: 'Contrasena', sortable: true },
                    { field: 'Telefono', sortable: true },
                    { field: 'Correo', sortable: true },
                ],
                pager: { limit: 5 }
            });
        },
        error: function (error) {
            alert("Error!!!!!!");
        }
    })
}

