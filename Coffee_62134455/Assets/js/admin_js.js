function validate() {
    var counter = 0;
    $(`.required`).each(function () {
        if ($(this).val().trim() === "") {
            counter++;
            $(this).parents("div").children('.message').addClass('text-danger').text("Bạn không được bỏ trống trường này");
        }
        else {
            $(this).parents("div").children('.message').removeClass('text-danger').text("");
        }
    });
    if (counter > 0) {

        return false;
    }
    //Validate giá trị tối thiểu
    $("input[min]").each(function () {
        var min = $(this).attr("min");
        if ($(this).val() && parseFloat($(this).val()) < parseFloat(min)) {
            counter++;
            $(this).parents("div").children('.message').addClass('text-danger').text("Vui lòng nhập lớn hơn " + min);
        }
        else {
            $(this).parents("div").children('.message').removeClass('text-danger').text("");
        }
    });
    if (counter > 0) {

        return false;
    }

    return true;
}

function validateModal() {
    var counter = 0;
    $(`#exampleModal .required`).each(function () {
        if ($(this).val().trim() === "") {
            counter++;
            $(this).parents("div").children('.message').addClass('text-danger').text("Bạn không được bỏ trống trường này");
        }
        else {
            $(this).parents("div").children('.message').removeClass('text-danger').text("");
        }
    });
    if (counter > 0) {

        return false;
    }
    //Validate giá trị tối thiểu
    $("#exampleModal input[min]").each(function () {
        var min = $(this).attr("min");
        if ($(this).val() && parseFloat($(this).val()) < parseFloat(min)) {
            counter++;
            $(this).parents("div").children('.message').addClass('text-danger').text("Vui lòng nhập lớn hơn " + min);
        }
        else {
            $(this).parents("div").children('.message').removeClass('text-danger').text("");
        }
    });
    if (counter > 0) {

        return false;
    }

    return true;
}




function openModal(title, data, classFrom = "default", textAction= "Lưu lại") {
    $(".modal .modal-title").text(title);
    $(".modal .modal-body").html(data);
    $(".modal .btn-action-modal").html(textAction);
    $(".modal").modal('show');
}

function CloseModal() {
    $(".modal").modal('hide');
}