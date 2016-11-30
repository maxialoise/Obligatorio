$(function () {
    $("#txtFecha").datepicker();
    $("#txtFechaDos").datepicker();
});

function validarFecha(sender, arguments) {
    arguments.IsValid = arguments.Value != "";
}