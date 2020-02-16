$(document).ready(function () {
    toastr.options = {
        "closeButton": false,
        "positionClass": "toast-top-full-width",
        "onclick": null,
        "showDuration": "0",
        "hideDuration": "0",
        "timeOut": "2000",
        "showMethod": "fadeIn"
    };
    $("#btnRegister").click(function (e) {
        $("#loading").modal({
            'backdrop':'static'
        })
        var _mobileNo = $('#inpMobileNo').val();
        var _firstNm = $('#inpFirstName').val();
        var _lastNm = $('#inpLastName').val();
        var _dob = $('#inpYearDOB').val() + '-' + $('#selMonth').val() + '-' + $('#inpdateDOB').val();
        var _gender = '';
        if ($('#rdMale').is(':checked')) {
            _gender = $('#rdMale').val();
        }
        else {
            _gender = $('#rdFemale').val();
        }
        var _email = $('#inpEmail').val();

        registerData('+62'+_mobileNo, _firstNm, _lastNm, _dob, _gender, _email);
    });
});

;
function registerData(mobileNo, firstName, lastName, dob, gender, email) {
    var paramData = {
        MobileNo: mobileNo,
        FirstName: firstName,
        LastName: lastName,
        DOB: dob,
        Gender: gender,
        Email: email
    }

    $.ajax({
        url: 'https://localhost:44313/api/Registration',
        datatype: 'json',
        data: JSON.stringify(paramData),
        type: "POST",
        context: document.body,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.Code == 'S') {
                toastr.success(data.Message);
                var btReg = document.getElementById("btnRegister");
                var btLogin = document.getElementById("btnLogin");

                btReg.style.display = "none";
                btLogin.style.display = "block";
            }
            else {
                toastr.options.closeButton = true;
                toastr.options.timeOut = 0;
                toastr.error(data.Description);
            }
            $("#loading").modal('hide');
        },
        error: function (data) {
            toastr.options.closeButton = true;
            toastr.options.timeOut = 0;
            toastr.error(data.responseJSON.Description);
            $("#loading").modal('hide');
        }
    });
}

function reposition() {
    var modal = $(this),
        dialog = modal.find('.modal-dialog');
    modal.css('display', 'block');

    // Dividing by two centers the modal exactly, but dividing by three
    // or four works better for larger screens.
    dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 2));
}
// Reposition when a modal is shown
$('.modal').on('show.bs.modal', reposition);
// Reposition when the window is resized
$(window).on('resize', function () {
    $('.modal:visible').each(reposition);
});