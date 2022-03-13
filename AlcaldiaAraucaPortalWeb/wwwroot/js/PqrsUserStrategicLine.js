$(document).ready(function () {
    $("#UserId").change(function () {

        $("#PqrsStrategicLineId").empty();
        $("#PqrsStrategicLineId").append('<option value="0">[Seleccione una Linea..]</option>');
        $.ajax({
            type: 'GET',
            url: '/PqrsUserStrategicLines/LineaAtrategicSearch',
            dataType: 'json',
            data: { UserId: $("#UserId").val() },
            success: function (data) {
                $.each(data, function (i, row) {
                    $("#PqrsStrategicLineId").append('<option value="'
                        + row.pqrsStrategicLineId + '">'
                        + row.pqrsStrategicLineName + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve category.' + ex);
            }
        });
        return false;
    })
});