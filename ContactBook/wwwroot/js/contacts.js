$(document).ready(function () {
    $(".btn-add").click(function () {
        OpenAddPopup();
    })

    $(document).on("click", ".btn-add-image", function () {
        $("#btn-file").click();
    })

    $(document).on("change", "#btn-file", function () {
        readImage(this);
    });

   
})

function readImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#displayImage').attr('src', e.target.result);
            $($("#contactsModel_ImageUrl")[0]).val(e.target.result)
        }

        reader.readAsDataURL(input.files[0]);
    }
}


