$(document).ready(function () {
    var id = $('#calialumno').find('#selectPeriodo').val();
    $('#calialumno').find('div[name^="calificacion-"]').hide();
    $('#calialumno').find('div[name="calificacion-' + id + '"]').show();
    $('#calialumno').find('#selectPeriodo').change(function () {
        //console.log($(this).val());
        $('#calialumno').find('div[name^="calificacion-"]').hide();
        $('#calialumno').find('div[name="calificacion-' + $(this).val() + '"]').show();
    });
    var idp = $('#pafialumno').find('#PeriodoPafi').val();
    $('#pafialumno').find('tr[name^="pafi-"]').hide();
    $('#pafialumno').find('tr[name="pafi-' + idp + '"]').show();
    $('#pafialumno').find('#PeriodoPafi').change(function () {
        //console.log($(this).val());
        $('#pafialumno').find('tr[name^="pafi-"]').hide();
        $('#pafialumno').find('tr[name="pafi-' + $(this).val() + '"]').show();
    });
    var idm = $('#movialumno').find('#PeriodoMovi').val();
    $('#movialumno').find('div[name^="movilidad-"]').hide();
    $('#movialumno').find('div[name="movilidad-' + idm + '"]').show();
    $('#movialumno').find('#PeriodoMovi').change(function () {
        console.log($(this).val());
        $('#movialumno').find('div[name^="movilidad-"]').hide();
        $('#movialumno').find('div[name="movilidad-' + $(this).val() + '"]').show();
    });
});