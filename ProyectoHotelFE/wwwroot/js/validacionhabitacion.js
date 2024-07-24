$(document).ready(function () {
    $('#formHabitacion').on('submit', function (e) {
        var numeroHabitacion = parseInt($('#numeroHabitacion').val());
        var capacidad = parseInt($('#capacidad').val());
        var precio = parseFloat($('#precio').val());

        if (numeroHabitacion <= 0 || capacidad <= 0 || precio <= 0) {
            e.preventDefault();
            swal({
                title: "Error",
                text: "Los valores de Número de Habitación, Capacidad y Precio deben ser mayores a 0.",
                type: "error",
                confirmButtonText: "Aceptar"
            });
        }
    });
});
