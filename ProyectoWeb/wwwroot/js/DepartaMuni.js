$(document).ready(function () {
    // Cuando se cambia la selección en el elemento "departamentos"
    $('#departamentos').change(function () {
        // Obtén el valor seleccionado del departamento
        var selectedDepartamentoId = $(this).val();

        // Oculta todos los elementos en el elemento "municipios"
        $('#municipios option').hide();

        // Muestra solo los municipios que pertenecen al departamento seleccionado
        $('#municipios option[value="' + selectedDepartamentoId + '"]').show();
    });
});