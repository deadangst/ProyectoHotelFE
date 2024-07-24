function calcularMontoTotal() {
    const habitacionID = $('#habitacionID').val();
    const fechaInicio = new Date($('#fechaInicio').val());
    const fechaFin = new Date($('#fechaFin').val());

    if (habitacionID && fechaInicio && fechaFin) {
        const diferenciaDias = Math.ceil((fechaFin - fechaInicio) / (1000 * 60 * 60 * 24));
        if (diferenciaDias > 0) {
            $.ajax({
                url: '/Habitacion/GetPrecioHabitacion',
                type: 'GET',
                data: { habitacionID: habitacionID },
                success: function (precio) {
                    const montoTotal = diferenciaDias * precio;
                    $('#montoTotal').val(montoTotal.toFixed(2));
                }
            });
        } else {
            $('#montoTotal').val('');
        }
    }
}

$(document).ready(function () {
    $('#habitacionID, #fechaInicio, #fechaFin').on('change', calcularMontoTotal);
});
