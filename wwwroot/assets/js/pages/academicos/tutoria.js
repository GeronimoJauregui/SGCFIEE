$(document).ready(function () {
    /*Agregar tutorado*/
    $("#nombre").hide();
    $("#matricula").hide();
    $("input[name=Tipotutorado]").change(function () {
        var t = $(this).val();
        if (t === '0') {
            $("#nombre").hide();
            $("#matricula").hide();
            $("#A_interno").show();
        } else {
            $("#nombre").show();
            $("#matricula").show();
            $("#A_interno").hide();
        }
    });

    $("#div_laboratorio").hide();
    $("#tipocontratacion").change(function () {
        var t = $(this).val();
        if (t === '1') {
            $("#div_laboratorio").hide();
            $("#div_fecha_nombramiento").show();
        } else if (t === '3') {
            $("#div_laboratorio").show();
            $("#div_fecha_nombramiento").hide();
        } else {
            $("#div_laboratorio").hide();
            $("#div_fecha_nombramiento").hide();
        }
    });

    var cod = document.getElementById("tipocontratacion").value;

    if (cod === '1') {
        $("#div_laboratorio").hide();
        $("#div_fecha_nombramiento").show();
    } else if (cod === '3') {
        $("#div_laboratorio").show();
        $("#div_fecha_nombramiento").hide();
    } else {
        $("#div_laboratorio").hide();
        $("#div_fecha_nombramiento").hide();
    }
});






