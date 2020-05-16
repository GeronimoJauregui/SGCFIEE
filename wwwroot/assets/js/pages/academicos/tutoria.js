$(document).ready(function () {
    //----------------editorial----------------
    $("#div_agregar").hide();
    $("#select").change(function () {        
        element = document.getElementById("div_agregar");
        check = document.getElementById("select");
        if (check.checked) {
            element.style.display = 'block';
        }
        else {
            element.style.display = 'none';
            $("#agregar").val(null);
        }
    });

    $("#div_agregar2").hide();
    $("#select2").change(function () {
        element = document.getElementById("div_agregar2");
        check = document.getElementById("select2");
        if (check.checked) {
            element.style.display = 'block';
        }
        else {
            element.style.display = 'none';
            $("#agregar2").val(null);
        }
    });



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
    };


    
    //$("#div_agregarEdi").hide();
    //$("#nueva_editorial").change(function () {
    //    var t = $(this).val();
    //    if (t === '1') {
    //        $("#agregarEdi").show();
    //    } else {
    //        $("#agregarEdi").hide();

    //    }
    //});
});




