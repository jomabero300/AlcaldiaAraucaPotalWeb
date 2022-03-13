let numD = 0;
let numP = 0;

function ActivitiesAdd() {
    if (ActivitiesValidate()) {

        $("#myTableActivities tbody").append("<tr>" +
            "<td>" + $("#description").val() + "</td>" +
            "<td>" + $("#budget").val() + "</td>" +
            "<td>" + $("#dateStart").val() + "</td>" +
            "<td>" + $("#dateEnd").val() + "</td>" +
            "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="ActivitiesDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
            "</tr>");

        $("#divActivities table").append(
            "<input type='hidden' name='PqrsProjectActivities.Index' value=" + numD + " /> " +
            "<input type='hidden' name='PqrsProjectActivities[" + numD + "].Description' value='" + $("#description").val() + "'/> " +
            "<input type='hidden' name='PqrsProjectActivities[" + numD + "].Budget' value='" + $("#budget").val() + "'/> " +
            "<input type='hidden' name='PqrsProjectActivities[" + numD + "].DateStart' value='" + $("#dateStart").val() + "'/> " +
            "<input type='hidden' name='PqrsProjectActivities[" + numD + "].DateEnd' value='" + $("#dateEnd").val() + "'/> "
        );

        $("#description").val("");
        $("#budget").val("");
        $("#dateStart").val("");
        $("#dateEnd").val("");
        $("#description").focus();

        numD++;
    }
}
function ActivitiesDelete(ctl) {

    _row = $(ctl).parents("tr");

    var cols = _row.children("td");

    var count = $("#myTableActivities tr").length - 1;

    var index = $(ctl).closest("tr").index();

    $(ctl).parents("tr").remove();

    $("input[value='" + index + "']").remove();

    $("input[name='PqrsProjectActivities[" + index + "].Description']").remove();
    $("input[name='PqrsProjectActivities[" + index + "].Budget']").remove();
    $("input[name='PqrsProjectActivities[" + index + "].DateStart']").remove();
    $("input[name='PqrsProjectActivities[" + index + "].DateEnd']").remove();

    numD--;
}
function ActivitiesValidate() {
    var isValid = true;

    $('#spanDescription').text('').show('hide');
    $('#spanBudget').text('').show('hide');

    if ($('#description').val().trim() == "") {

        $('#spanDescription').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#description').focus();
        }

        isValid = false;
    }

    if ($('#budget').val().trim() == "") {

        $('#spanbudget').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#budget').focus();
        }

        isValid = false;
    }

    return isValid;
}

function ProponentsAdd() {
    if (ProponentsValidate()) {
        $("#myTableProponents tbody").append("<tr>" +
            "<td>" + $("#email").val() + "</td>" +
            "<td>" + $("#name").val() + "</td>" +
            "<td>" + $("#phone").val() + "</td>" +
            "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="ProponentsDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
            "</tr>");

        $("#divActivities table").append(
            "<input type='hidden' name='PqrsProjectProponents.Index' value=" + numP + " /> " +
            "<input type='hidden' name='PqrsProjectProponents[" + numP + "].Email' value='" + $("#email").val() + "'/> " +
            "<input type='hidden' name='PqrsProjectProponents[" + numP + "].Name' value='" + $("#name").val() + "'/> " +
            "<input type='hidden' name='PqrsProjectProponents[" + numP + "].Phone' value='" + $("#phone").val() + "'/> " +
            "</tr>");

        $("#email").val("");
        $("#name").val("");
        $("#phone").val("");
        $("#email").focus();

        numP++;
    }
}
function ProponentsDelete(ctl) {

    _row = $(ctl).parents("tr");

    var cols = _row.children("td");

    var count = $("#myTableProponents tr").length - 1;

    var index = $(ctl).closest("tr").index();

    $(ctl).parents("tr").remove();

    $("input[value='" + index + "']").remove();

    $("input[name='PqrsProjectProponents[" + index + "].Email']").remove();
    $("input[name='PqrsProjectProponents[" + index + "].Name']").remove();
    $("input[name='PqrsProjectProponents[" + index + "].Phone']").remove();

    numP--;
}
function ProponentsValidate() {
    var isValid = true;

    $('#spanEmail').text('').show('hide');

    $('#spanName').text('').show('hide');

    $('#spanPhone').text('').show('hide');

    if ($('#email').val().trim() == "") {

        $('#spanEmail').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#email').focus();
        }

        isValid = false;
    }

    if ($('#name').val().trim() == "") {

        $('#spanName').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#name').focus();
        }

        isValid = false;
    }
    if ($('#phone').val().trim() == "") {

        $('#spanPhone').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#phone').focus();
        }

        isValid = false;
    }

    return isValid;
}