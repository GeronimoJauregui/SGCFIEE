$(document).ready(function () {
    $('#examenAlumno').find('input[id="enviadatose"]').on('click', function () {
        var arreglo = new Array();
        $("#examenAlumno").find('div.calificacion').each(function () {
            arreglo.push({
                "IdAlumno": $(this).find('input[name="alumno"]').val()
                ,"IdRubroExamen": $(this).find('input[name="rubro"]').val()
                , "CalificacionExamen": $(this).find('input[name="calificacion"]').val()
                , "IdTbExamenAlumno": $(this).find('input[name="idExamenAlum"]').val()
            });
        });
        alert("Calificaciones guardadas");
        $.post("EstudiantesExamen/Crear", { json: JSON.stringify(arreglo) });
    });
});