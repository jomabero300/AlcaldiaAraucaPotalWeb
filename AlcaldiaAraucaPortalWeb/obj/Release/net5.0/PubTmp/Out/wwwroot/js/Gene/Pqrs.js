var loadFile1 = function (event) {
    $("#dynamicImage1").empty();

    let image1 = document.getElementById('dynamicImage1');
    image1.innerHTML = `
    <iframe class="embed-responsive-item" src="${URL.createObjectURL(event.target.files[0])}" allowfullscreen></iframe>
<div class="col-md-2">
    <a href="#" data-toggle="modal" data-target="#MyModalImage1">Ver..</a>

    <div class="modal fade" id="MyModalImage1" tabindex="-1" role="dialog" ari-labelledby="MyModalImage1Label" aria-hidden="true">
        <button type="button" class="close mr-2" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <iframe class='embed - responsive - item' src="${URL.createObjectURL(event.target.files[0])}" allowfullscreen></iframe>
        </div>
    </div>
</div>
`



//    $("#dynamicImage1").append("<iframe class='embed - responsive - item' src='" + URL.createObjectURL(event.target.files[0]) + "' allowfullscreen></iframe>");
}
var loadFile2 = function (event) {
    $("#dynamicImage2").empty();
    let image2 = document.getElementById('dynamicImage2');
    image2.innerHTML = `
    <iframe class='embed-responsive-item' src="${URL.createObjectURL(event.target.files[0])}" allowfullscreen></iframe>
    <div class="col-md-2">
        <a href="#" data-toggle="modal" data-target="#MyModalImage2">Ver..</a>
        <div class="modal fade" id="MyModalImage2" tabindex="-1" role="dialog" ari-labelledby="MyModalImage2Label" aria-hidden="true">
            <button type="button" class="close mr-2" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
                <iframe class='embed - responsive - item' src="${URL.createObjectURL(event.target.files[0])}" allowfullscreen></iframe>
            </div>
        </div>
    </div>
`
    //$("#dynamicImage2").append("<iframe class='embed - responsive - item' src='" + URL.createObjectURL(event.target.files[0]) + "' allowfullscreen></iframe>");
}
var loadFile3 = function (event) {
    $("#dynamicImage3").empty();
    let image3 = document.getElementById('dynamicImage3');
    image3.innerHTML = `
    <a href="#" data-toggle="modal" data-target="#MyModalImage3"><img src="${ URL.createObjectURL(event.target.files[0]) }" class="dynamicimg" style="width:100px;height:100px;max-width: 100%; height: auto;" /></a> <br>

    <div class="modal fade" id="MyModalImage3" tabindex="-1" role="dialog" ari-labelledby="MyModalImage3Label" aria-hidden="true">
        <button type="button" class="close mr-2" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <img src="${URL.createObjectURL(event.target.files[0])}" alt="" class="img-fluid rounded" />
        </div>
    </div>
`
//    $("#dynamicImage3").append("<a href='#' data-toggle='modal' data-target='#MyModal'><img src='" + URL.createObjectURL(event.target.files[0]) + "' class='dynamicimg' style='width:100px;height:100px;max-width: 100%; height: auto;' /></a> <br>");
}
var loadFile4 = function (event) {
    $("#dynamicImage4").empty();

    let image4 = document.getElementById('dynamicImage4');
    image4.innerHTML = `
    <a href="#" data-toggle="modal" data-target="#MyModalImage4"><img src="${URL.createObjectURL(event.target.files[0])}" class="dynamicimg" style="width:100px;height:100px;max-width: 100%; height: auto;" /></a> <br>

    <div class="modal fade" id="MyModalImage4" tabindex="-1" role="dialog" ari-labelledby="MyModalImage4Label" aria-hidden="true">
        <button type="button" class="close mr-2" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <img src="${URL.createObjectURL(event.target.files[0])}" alt="" class="img-fluid rounded" />
        </div>
    </div>
`



//    $("#dynamicImage4").append("<img src='" + URL.createObjectURL(event.target.files[0]) + "' class='dynamicimg' style='width:100px;height:100px;max-width: 100%; height: auto;' /> <br>");
}