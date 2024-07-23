function mostrarMensajeUsuarioAgregado(successMessage, errorMessage) {
    if (successMessage) {
        swal({
            title: "Éxito",
            text: successMessage,
            type: "success",
            confirmButtonText: "Cerrar",
            confirmButtonColor: "#5cb85c"
        });
    }

    if (errorMessage) {
        swal({
            title: "Error",
            text: errorMessage,
            type: "error",
            confirmButtonText: "Cerrar",
            confirmButtonColor: "#d9534f"
        });
    }
}
