$(document).ready(function () {
    $('#examena').find('input[id="guardarexamen"]').on('click', function () {
        var arreglo = new Array();
        $("#examena").find('div.calificacion').each(function () {
            arreglo.push({
                "IdAlumno": $(this).find('input[name="alumno"]').val()
                , "IdRubroExamen": $(this).find('input[name="rubro"]').val()
                , "CalificacionExamen": $(this).find('input[name="calificacion"]').val()
                , "IdTbExamenAlumno": $(this).find('input[name="idExamenAlum"]').val()
            });
        });
        var idd = arreglo[0].IdAlumno;
        $.post("https://localhost:5001/" + "EstudiantesInformacion/GuardarExamen", { json: JSON.stringify(arreglo) }).then(function () {

            $.get("https://localhost:5001/" + "EstudiantesInformacion/DetallesExamen", { id: idd }).then(function () {
                var newDoc = document.open("text/html", "replace");
                newDoc.write(arguments[0]);
                newDoc.close();
                swal({ title: "Guardado exitosamente!", timer: 2000, type: "success", showConfirmButton: false });
            });
        });
    });

    $('#examenAlumno2').find('input[id="actualizarexamen"]').on('click', function () {
        var arreglo = new Array();
        $("#examenAlumno2").find('div.calificacion').each(function () {
            arreglo.push({
                "IdAlumno": $(this).find('input[name="alumno"]').val()
                , "IdRubroExamen": $(this).find('input[name="rubro"]').val()
                , "CalificacionExamen": $(this).find('input[name="calificacion"]').val()
                , "IdTbExamenAlumno": $(this).find('input[name="idExamenAlum"]').val()
            });
        });
        var idd = arreglo[0].IdAlumno;
        $.post("https://localhost:5001/" + "EstudiantesInformacion/ActualizarExamen", { json: JSON.stringify(arreglo) }).then(function () {

            $.get("https://localhost:5001/" + "EstudiantesInformacion/DetallesExamen", { id: idd }).then(function () {
                var newDoc = document.open("text/html", "replace");
                newDoc.write(arguments[0]);
                newDoc.close();
                swal({ title: "Actualizado exitosamente!", timer: 2000, type: "success", showConfirmButton: false });
            });
        });
    });
});