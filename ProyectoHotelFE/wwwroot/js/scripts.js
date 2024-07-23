function confirmarEliminacion(url) {
    swal({
        title: "¿Estás seguro de querer eliminar la información?",
        text: "¡No podrás restaurar los datos!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dd4b39",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: true
    }, function (isConfirm) {
        if (isConfirm) {
            window.location.href = url;
        }
    });
}
