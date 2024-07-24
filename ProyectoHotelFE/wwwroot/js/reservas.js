function confirmarEliminacionReserva(url, montoTotal, fechaInicio) {
    const fechaInicioDate = new Date(fechaInicio);
    const fechaActual = new Date();
    const diferenciaDias = Math.ceil((fechaInicioDate - fechaActual) / (1000 * 60 * 60 * 24));

    if (diferenciaDias <= 15) {
        const multa = montoTotal * 0.2;
        const iva = multa * 0.13;
        const multaConIva = multa + iva;
        swal({
            title: "¡Atención!",
            text: `La fecha de inicio de la reserva está dentro de los próximos 15 días.\n
                   Se aplicará una multa del 20% del monto total de la reserva, que equivale a $${multa.toFixed(2)}.\n
                   Además, se sumará el 13% de IVA ($${iva.toFixed(2)}), por lo que el total de la multa será $${multaConIva.toFixed(2)}.`,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#dd4b39",
            confirmButtonText: "Sí, aceptar multa y eliminar",
            closeOnConfirm: true
        }, function () {
            window.location.href = url;
        });
    } else {
        confirmarEliminacion(url);
    }
}

function confirmarEliminacion(url) {
    swal({
        title: "Confirmación",
        text: "¿Estás seguro de que deseas eliminar esta reserva?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dd4b39",
        confirmButtonText: "Sí, eliminar",
        closeOnConfirm: true
    }, function () {
        window.location.href = url;
    });
}
