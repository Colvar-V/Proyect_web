function ListaTecnicos() {
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/Admin/GetListTecnicos',
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
                    { field: 'Cargo', sortable: true },
                    { field: 'Usuario', sortable: true },
                    { field: 'Contrasena', sortable: true },
                    { field: 'Telefono', sortable: true },
                    { field: 'Correo', sortable: true },
                    { field: 'Proyecto', sortable: true },
                    { with: 64, tmpl: '<span class="material-icons gj-cursor-pointer">Editar</span>', align: 'centro', events: { 'click': EditarUsuario}}
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
        url: '/Admin/GetListCoord',
        data: {},
        contentType: "aplication/json; chaset=utf-8",
        async: false,
        success: function (listado) {
            console.log(listado);
            var grid = $('#grid1').grid({
                dataSource: listado,
                columns: [
                    { field: 'Id', sortable: true },
                    { field: 'Nombre', sortable: true },
                    { field: 'Usuario', sortable: true },
                    { field: 'Contrasena', sortable: true },
                    { field: 'Telefono', sortable: true },
                    { field: 'Correo', sortable: true },
                    { field: 'Proyecto', sortable: true },
                    { with: 64, tmpl: '<span class="material-icons gj-cursor-pointer">Editar</span>', align: 'centro', events: { 'click': EditarUsuario} }
                ],
                pager: { limit: 5 }
            });
        },
        error: function (error) {
            alert("Error!!!!!!");
        }
    })
}

function InsertUser() {
    var nombrejs = $("#Nombre").val();
    var cargojs = $("#Cargo").val();
    var usuariojs = $("#Usuario").val();
    var contrasenajs = $("#Contrasena").val();
    var correojs = $("#Correo").val();
    var telefonojs = $("#Telefono").val();
    var proyectjs = $("#Id_proy").val();
    if (nombrejs !== "" && cargojs !== "" && usuariojs !== "" && contrasenajs !== "" && correojs !== "" && telefonojs !== "" && proyectjs !=="") {
        if (cargojs == "Coordinador") {
            var model = JSON.stringify({
                Nombre: nombrejs, Usuario: usuariojs, Contrasena: contrasenajs, Telefono: telefonojs, Correo: correojs, IdProyecto:proyectjs
            });
            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: '/Admin/PostInsertCoord',
                data: model,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.CODIGO === "1") {
                        $("#Nombre").val("");
                        $("#Cargo").val("");
                        $("#Usuario").val("");
                        $("#Contrasena").val("");
                        $("#Correo").val("");
                        $("#Telefono").val("");
                        $("#Id_proy").val("");
                        alert(data.val());
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
        else {
            var model = JSON.stringify({
                Nombre: nombrejs, Cargo: cargojs, Usuario: usuariojs, Contrasena: contrasenajs, Correo: correojs, Telefono: telefonojs, IdProyecto: proyectjs
            });
            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: '/Admin/PostInsertTec',
                data: model,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.CODIGO == "1") {
                        $("#Nombre").val("");
                        $("#Cargo").val("");
                        $("#Usuario").val("");
                        $("#Contrasena").val("");
                        $("#Correo").val("");
                        $("#Telefono").val("");
                        $("#Id_proy").val("");
                        alert(data.val());
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
}
function EditarUsuario(e) {
    var info = e.data.record;
    window.location.href = "EditarUsuarios?Id=" + info.Id + "&Nombre=" + info.Nombre + "&Cargo=" + info.Cargo
    + "&Usuario=" + info.Usuario + "&Contrasena=" + info.Contrasena + "&Telefono=" + info.Telefono
        + "&Correo=" + info.Correo + "&Id_proy=" + info.IdProyecto;
}
function LlenarFormulario(id, nombre, cargo, telefono, correo, usuario, contrasena, idProyecto) {
    $("#Id").val(id);
    $("#Nombre").val(nombre);
    $("#Cargo").val(cargo);
    $("#Usuario").val(usuario);
    $("#Contrasena").val(contrasena);
    $("#Correo").val(correo);
    $("#Telefono").val(telefono);
    $("#Id_proy").val(idProyecto);
}
function getParamenterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, ""));
}
function UpdateUser() {
    var idjs = $("#Id").val();
    var nombrejs = $("#Nombre").val();
    var cargojs = $("#Cargo").val();
    var usuariojs = $("#Usuario").val();
    var contrasenajs = $("#Contrasena").val();
    var correojs = $("#Correo").val();
    var telefonojs = $("#Telefono").val();
    var proyectjs = $("#Id_proy").val();
    if (nombrejs !== "" && cargojs !== "" && usuariojs !== "" && contrasenajs !== "" && correojs !== "" && telefonojs !== "" && proyectjs !== "") {
        if (cargojs == "Coordinador") {
            var model = JSON.stringify({
                Id: idjs, Nombre: nombrejs, Usuario: usuariojs, Contrasena: contrasenajs, Telefono: telefonojs, Correo: correojs, IdProyecto: proyectjs
            });
            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: '/Admin/PostEditCoord',
                data: model,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.CODIGO === "1") {
                        alert(data.Resultado);
                        window.location.href = "Usuarios";
                    }
                },
                error: function (error) {
                    alert("ERROR!!!!!");
                }
            })
        }
        else {
            var model = JSON.stringify({
                Id: idjs, Nombre: nombrejs, Cargo: cargojs, Usuario: usuariojs, Contrasena: contrasenajs, Correo: correojs, Telefono: telefonojs, IdProyecto: proyectjs
            });
            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: '/Admin/PostEditTec',
                data: model,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.CODIGO == "1") {
                        alert(data.Resultado);
                        window.location.href = "Usuarios";
                    }
                },
                error: function (error) {
                    alert("ERROR!!!!!");
                }
            })
        }
    }
}