function ConsultarNombre() {

    let identificacion = $("#Identificacion").val();

    if (identificacion.lenght > 0) { } else { 
        // ajax Sirve para hacer llamados a APIS con JS (llamar servidor desde JS)
        $.ajax({
            url: 'https://apis.gometa.org/cedulas/' + identificacion,
            type: "GET",
            success: function (data) {
                let nombreCompleto = data.results[0].firstname + " " + data.results[0].lastname
                $("#Nombre").val(nombreCompleto);
            }
            //Desde el lado del cliente --> Se muestra en el DOM Baja seguridad
        }
        );
        $("#Nombre").val("");

    }
}