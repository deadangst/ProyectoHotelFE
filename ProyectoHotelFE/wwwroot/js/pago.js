function confirmarPago() {
    const monto = parseFloat($('input[name="monto"]').val());
    const montoConIva = monto * 1.13;
    const iva = monto * 0.13;

    swal({
        title: "Confirmar Pago",
        text: `El monto original es $${monto.toFixed(2)}. Se aplicará un 13% de IVA ($${iva.toFixed(2)}), por lo que el total a pagar será $${montoConIva.toFixed(2)}.`,
        type: "info",
        showCancelButton: true,
        confirmButtonText: "Aceptar y Pagar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    }, function (isConfirm) {
        if (isConfirm) {
            $('#pagoForm').submit();
        } else {
            window.location.href = "/Reserva/Index";
        }
    });
}
