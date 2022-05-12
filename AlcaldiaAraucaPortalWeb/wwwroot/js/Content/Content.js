﻿const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:44334/" : "https://araucactiva.com/";
let numD = 0;

function AddContentDetalle() {
    if (ContentDetalleValidate()) {
        if ($("#OptionFile").val() == "1") {
            let formData = new FormData();
            formData.append("file", $("#contentUrlImg")[0].files[0]);
            $.ajax({
                type: "POST",
                url: urlServidor + "Contents/UploadeTemp",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    $("#myTableContentDetalle tbody").append("<tr>" +
                        "<td>" + $("#contentTitle").val() + "</td>" +
                        "<td>" + $("#contentText").val() + "</td>" +
                        "<td><img src='" + data.path + "' class='img - rounded' alt='Image' style='width: 100px; height: 100px; max - width: 100 %; height: auto;' /></td>" +
                        "<td style='display: none;'>" + data.path + "</td>" +
                        "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="ContentDetailDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
                        "</tr>");

                    $("#divContentDetalle table").append(
                        "<input type='hidden' name='ContentDetails.Index' value=" + numD + " /> " +
                        "<input type='hidden' name='ContentDetails[" + numD + "].ContentTitle' value='" + $("#contentTitle").val() + "'/> " +
                        "<input type='hidden' name='ContentDetails[" + numD + "].ContentText' value='" + $("#contentText").val() + "'/> " +
                        "<input type='hidden' name='ContentDetails[" + numD + "].ContentUrlImg' value='" + data.path + "'/> "+
                        "<input type='hidden' name='ContentDetails[" + numD + "].isEsta' value='1'/> "
                    );

                    $("#contentTitle").val("");
                    $("#contentText").val("");
                    $("#contentUrlImg").val("");

                    numD++;
                },
                error: function (ex) {
                    alert('Failed to retrieve.' + ex);
                }
            });
        } else {
            $("#myTableContentDetalle tbody").append("<tr>" +
                "<td>" + $("#contentTitle").val() + "</td>" +
                "<td>" + $("#contentText").val() + "</td>" +
                "<td>" + $("#contentUrlImg").val() +"</td>" +
                "<td style='display: none;'>" + $("#contentUrlImg").val() + "</td>" +
                "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="ContentDetailDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
                "</tr>");

            $("#divContentDetalle table").append(
                "<input type='hidden' name='ContentDetails.Index' value=" + numD + " /> " +
                "<input type='hidden' name='ContentDetails[" + numD + "].ContentTitle' value='" + $("#contentTitle").val() + "'/> " +
                "<input type='hidden' name='ContentDetails[" + numD + "].ContentText' value='" + $("#contentText").val() + "'/> " +
                "<input type='hidden' name='ContentDetails[" + numD + "].ContentUrlImg' value='" + $("#contentUrlImg").val() + "'/> " +
                "<input type='hidden' name='ContentDetails[" + numD + "].isEsta' value='0'/> "
            );

            $("#contentTitle").val("");
            $("#contentText").val("");
            $("#contentUrlImg").val("");
        }        
    }
}
function ContentDetailDelete(ctl) {
  
    _row = $(ctl).parents("tr");

    let cols = _row.children("td");
            
    let path = $(cols[3]).text();
    //TODO: validar que isEsta=1 y ejecuta el ajax
    $.ajax({
        type: "POST",
        url: urlServidor + "Contents/DeleteTemp",
        data: { file : path},
        success: function (data) {

            var count = $("#myTableContentDetalle tr").length - 1;

            var index = $(ctl).closest("tr").index();

            $(ctl).parents("tr").remove();

            $("input[value='" + index + "']").remove();

            $("input[name='ContentDetails[" + index + "].ContentTitle']").remove();
            $("input[name='ContentDetails[" + index + "].ContentText']").remove();
            $("input[name='ContentDetails[" + index + "].ContentUrlImg']").remove();

            numD--;
        },

        error: function (ex) {
            alert('Failed to retrieve cities.' + ex);
        }
    });

}
function ContentDetalleValidate() {
    var isValid = true;

    $('#spanContentTitle').text('').show('hide');
    $('#spanContentText').text('').show('hide');
    $('#spanContentUrlImg').text('').show('hide');
    $('#spanOptionFile').text('').show('hide');

    if ($('#contentTitle').val().trim() == "") {

        $('#spanContentTitle').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentTitle').focus();
        }

        isValid = false;
    }
    
    if ($('#contentText').val().trim() == "") {

        $('#spanContentText').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentText').focus();
        }

        isValid = false;
    }

    if ($("#OptionFile").val() == null) {
        $('#spanOptionFile').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#OptionFile').focus();
        }

        isValid = false;
    } else if ($('#contentUrlImg').val().trim() == "") {

        $('#spanContentUrlImg').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentUrlImg').focus();
        }

        isValid = false;
    }


    return isValid;
}

function AddContentEditDetalle(ContentId) {
    if (ContentEditDetalleValidate()) {
        let formData = new FormData();
        formData.append("id", ContentId);
        formData.append("Title", $("#contentTitle").val());
        formData.append("ContentText", $("#contentText").val());
        if ($("#OptionFile").val() == "1") {
            formData.append("file", $("#contentUrlImg")[0].files[0]);
        }

        formData.append("fileUrl", $("#contentUrlImg").val());

        console.log(formData);
        $.ajax({
            type: "POST",
            url: urlServidor + "Contents/AddContentDetalle ",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {

                if (response.status == true) {
                    window.location.href = "/Contents/Edit/?id=" + ContentId
                }
            }
        });
    }
}
function ContentEditDetailDelete(ContentDetailsId, ContentId) {
    $.ajax({
        type: "POST",
        url: urlServidor + "Contents/DeleteDetails",
        data: { id: ContentDetailsId },
        success: function (response) {

            if (response.status == true) {
                window.location.href = "/Contents/Edit/?id=" + ContentId
            }
        }
    });
}
function ContentEditDetalleValidate() {
    var isValid = true;

    $('#spanContentTitle').text('').show('hide');
    $('#spanContentText').text('').show('hide');
    $('#contentUrlImg').text('').show('hide');

    if ($('#contentTitle').val().trim() == "") {

        $('#spanContentTitle').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentTitle').focus();
        }

        isValid = false;
    }

    if ($('#contentText').val().trim() == "") {

        $('#spanContentText').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentText').focus();
        }

        isValid = false;
    }
    if ($("#OptionFile").val() == null) {
        $('#spanOptionFile').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#OptionFile').focus();
        }

        isValid = false;
    } else if ($('#contentUrlImg').val().trim() == "") {

        $('#spanContentUrlImg').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentUrlImg').focus();
        }

        isValid = false;
    }


    return isValid;
}


$(document).ready(function () {

    $("#OptionFile").change(function () {
        $("#dynamicCtr").empty();
        if ($("#OptionFile").val() == "1") {
            $("#dynamicCtr").append("<div class='form-group' id='inputFile'><input id='contentUrlImg' class='form-control' type='file' /><span id='spanContentUrlImg' class='text-danger'></span></div>");
        }
        else if ($("#OptionFile").val() == "2"){
            $("#dynamicCtr").append("<input id='contentUrlImg' class='form-control' maxlength='150' placeholder='Digite una url'/><span id='spanContentUrlImg' class='text-danger'></span>");
        }
    });

    let strategicLine = 0;
    let strategicLineSector = 0;

    $("#pqrsStrategicLineId").change(function () {

        var newVal = $(this).val();
        let a = document.getElementById("myTableContentDetalle");
        let lnRows = a.rows.length - 1;

        if (lnRows > 0) {
            if (!confirm("Realmente desea cambiar de linea estrategica?,la informacion del detalle se perderá.")) {
                $(this).val(strategicLine);
                return;
            }

            DeleteTable();
        }

        //if (strategicLine != 0) {
        //    let a = document.getElementById("myTableContentDetalle");
        //    let rows = a.rows.length;
        //    if (rows > 0) {
        //        DeleteTable();
        //    }
        //}

        $("#pqrsStrategicLineSectorId").empty();

        $.ajax({
            type: 'POST',
            url: '/Prensa/getSector/',
            dataType: 'json',
            data: { Id: $("#pqrsStrategicLineId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#pqrsStrategicLineSectorId").append('<option value="'
                        + data.pqrsStrategicLineSectorId + '">'
                        + data.pqrsStrategicLineSectorName + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve cities.' + ex);
            }
        });

        strategicLine = newVal;
    })

    $("#pqrsStrategicLineSectorId").change(function () {
        var newVal = $(this).val();

        let a = document.getElementById("myTableContentDetalle");
        let lnRows = a.rows.length - 1;

        if (lnRows > 0) {

            if (!confirm("Realmente desea cambiar el sector ?,la informacion del detalle se perderá.")) {
                $(this).val(strategicLineSector);
                return;
            }

            DeleteTable();
        }

        //if (strategicLineSector != 0) {
        //    let a = document.getElementById("myTableContentDetalle");
        //    let rows = a.rows.length;
        //    if (rows > 0) {
        //        DeleteTable();
        //    }
        //}

        strategicLineSector = newVal;
    });

});

function DeleteTable() {

    let a = document.getElementById("myTableContentDetalle");
    let rows = a.rows.length-1;

    for (var index = 0; index < rows; index++) {

        var fileDelete = $("input[name='ContentDetails[" + index + "].isEsta']").val();
        if (fileDelete == "1") {
            FileDelete($("input[name='ContentDetails[" + index + "].ContentUrlImg']").val());
        }

        $("input[value='" + index + "']").remove();
        $("input[name='ContentDetails[" + index + "].ContentTitle']").remove();
        $("input[name='ContentDetails[" + index + "].ContentText']").remove();
        $("input[name='ContentDetails[" + index + "].ContentUrlImg']").remove();
        $("input[name='ContentDetails[" + index + "].isEsta']").remove();
    }

    $("#myTableContentDetalle tbody tr").remove();

    numD = 0;
}

function FileDelete(path) {
    $.ajax({
        type: "POST",
        url: urlServidor + "Contents/DeleteTemp",
        data: { file: path },
        success: function (data) {

        },
        error: function (ex) {
            alert('Failed to delete file.' + ex);
        }
    });
}
