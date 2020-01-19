$('a[name="eliminardato"]').on('click', function () {
    var value = $(this).data('value');
    var controlador = $(this).data('controlador');
    var accion = $(this).data('accion');
    var regreso = $(this).data('regreso');
    swal({
        title: "Estas seguro?",
        text: "Se eliminara el registro",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Confirmar",
        closeOnConfirm: false
    }, function () {
            $.get("https://sgcfiee.azurewebsites.net/" + controlador + "/" + accion, { id: value }).then(function () {
                $.get("https://sgcfiee.azurewebsites.net/" + controlador + "/" + regreso).then(function () {
                var newDoc = document.open("text/html", "replace");
                newDoc.write(arguments[0]);
                newDoc.close();
                swal("Eliminado exitosamente!", "Click en el bot\u00F3n!", "success");
            });
        });
    });

});
