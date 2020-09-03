//Script para eliminar un registro del modulo academicos, antes de llegar al controlador respectivo, primero de la vista pasa por aqui//
/*Es script se utiliza para cuando el return a una vista no debe llebar ningun campo establecido*/
$('a[name="eliminardato"]').on('click', function () {
    /*datos obtenidos de la vista*/
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
            /* Lo que lleva dentro del get, es la ruta a donde se debe diriguir */
            $.get("https://localhost:5001/" + controlador + "/" + accion, { id: value }).then(function () {
                $.get("https://localhost:5001/" + controlador + "/" + regreso).then(function () { 
                var newDoc = document.open("text/html", "replace");
                newDoc.write(arguments[0]);
                newDoc.close();
                    swal({ title: "Eliminado exitosamente!", timer: 2000, type: "success", showConfirmButton: false });
            });
        });
    });

});

/*Es script se utiliza para cuando el return a una vista debe llebar un campo establecido*/
$('a[name="eliminaracademico"]').on('click', function () {
    /*datos obtenidos de la vista*/
    var id_acad = $(this).data("id");
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
            /*Lo que lleva dentro del get, es la ruta a donde se debe diriguir*/
            $.get("https://localhost:5001/" + controlador + "/" + accion, { id: value, id_acad: id_acad }).then(function () {
                /* Lo que lleva dentro del get, es la ruta a donde se debe diriguir */
                $.get("https://localhost:5001/" + controlador + "/" + regreso, { id: id_acad }).then(function () { /*El regreso del campo se observa en este campo.*/
                var newDoc = document.open("text/html", "replace");
                newDoc.write(arguments[0]);
                newDoc.close();
                swal({ title: "Eliminado exitosamente!", timer: 2000, type: "success", showConfirmButton: false });
            });
        });
    });

});

