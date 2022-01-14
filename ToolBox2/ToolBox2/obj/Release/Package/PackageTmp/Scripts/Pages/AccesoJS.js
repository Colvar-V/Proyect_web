function verificar() {
    var usuariojs = $("#Usuario").val();
    var passwordjs = $("#password").val();
    if (usuariojs !== "" && passwordjs !== "") {
        var model = JSON.stringify({
            Usuario: usuariojs, Contrasena: passwordjs
        });
        $.ajax({
            type: 'POST',
            dataType: 'JSON',
            url: '/Acceso/PostVerficarUsuario',
            data: model,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.Aprobado == "1") {
                    window.location = "/Tecnico/TCInicio";
                }
                else {
                    if (data.Aprobado == "2") {
                        window.location = "/Coord/COInicio";
                    }
                    else {
                        if (data.Aprobado == "3") {
                            window.location = "/Admin/ADInicio"
                        }
                        else {
                            alert("ERROR!!!!!");
                        }
                    }
                }
            },
            error: function (error) {
                alert("ERROR!!!!!");
            }
        })
    }
}