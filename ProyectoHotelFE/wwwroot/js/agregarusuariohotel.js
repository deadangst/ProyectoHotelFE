// agregarusuario.js

function mostrarMensajeUsuarioAgregadoHotel(successMessage, errorMessage) {
    if (successMessage) {
        swal({
            title: "Éxito",
            text: successMessage,
            type: "success",
            confirmButtonText: "Cerrar"
        }, function () {
            // No redirigir, solo cerrar el popup
        });
    }

    if (errorMessage) {
        swal({
            title: "Error",
            text: errorMessage,
            type: "error",
            confirmButtonText: "Cerrar"
        }, function () {
            // No redirigir, solo cerrar el popup
        });
    }
}
