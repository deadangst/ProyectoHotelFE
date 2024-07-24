document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.btn-credit-card').forEach(function (button) {
        button.addEventListener('click', function (event) {
            event.preventDefault();
            var fechaFin = new Date(button.getAttribute('data-fechafin'));
            var hoy = new Date();
            hoy.setHours(0, 0, 0, 0);

            if (fechaFin.getTime() === hoy.getTime()) {
                window.location.href = button.getAttribute('href');
            } else {
                swal({
                    title: "¡Atención!",
                    text: "Solo puede cancelar la cuenta el día de checkout.",
                    type: "warning",
                    confirmButtonColor: "#dd4b39",
                    confirmButtonText: "Aceptar",
                    closeOnConfirm: true
                });
            }
        });
    });
});
