$(document).ready(function () {
    //var successMessage = '@TempData["SuccessMessage"]';
    //var errorMessage = '@TempData["ErrorMessage"]';

    mostrarMensajeUsuarioAgregado(successMessage, errorMessage);

    // Enmascarar número de tarjeta y código de seguridad
    var numeroTarjeta = $('#numeroTarjeta').val();
    var maskedNumeroTarjeta = numeroTarjeta.slice(0, -4).replace(/./g, '*') + numeroTarjeta.slice(-4);
    $('#numeroTarjeta').val(maskedNumeroTarjeta);

    $('#codigoSeguridad').val('***');

    // Actualizar número de tarjeta y código de seguridad al cambiar
    $('#numeroTarjeta').on('input', function () {
        var inputVal = $(this).val().replace(/\D/g, '');
        if (inputVal.length > 4) {
            $(this).val(inputVal.slice(0, -4).replace(/./g, '*') + inputVal.slice(-4));
        } else {
            $(this).val(inputVal);
        }
    });

    $('#codigoSeguridad').on('input', function () {
        var inputVal = $(this).val().replace(/\D/g, '');
        $(this).val(inputVal.replace(/./g, '*'));
    });
});
