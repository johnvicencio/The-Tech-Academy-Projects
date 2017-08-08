(function ($) {
    $('input.btn').addClass("btn-raised");
    $('.collapse').collapse();
    $('[data-tooltip="tooltip"]').tooltip();
    $('[data-toggle="tooltip"]').tooltip();

    // Change phone format to xxx-xxx-xxxx
    $('#PhoneNumber').keyup(function () {
        $(this).val($(this).val().replace(/(\d{3})\-?(\d{3})\-?(\d{4})/, '$1-$2-$3'));
    });
    $(".alert").delay(15000).slideUp(200, function () {
        $(this).alert('close');
    });
    //Attribute types replacements of default datatype data annotations of zip code
    $('#ZipCode').clone().attr('type', 'number').insertAfter('#ZipCode').prev().remove();

    ////Flexdatalist
    $('.flexdatalist').flexdatalist({
        selectionRequired: 1,
        valueProperty: 'value',
        minLength: 1
    });

    /*Toggle show clients*/
    $("#show-icon").click(function () {
        $("#clients").toggle();
    });



    // Current Date Time Local Time
    var interval = setInterval(function () {
        var momentNow = moment();
        $('#date-part').html(momentNow.format('MMMM DD, YYYY') + ' '
                            + momentNow.format('ddd')
                             .substring(0, 3).toUpperCase());
        $('#time-part').html(momentNow.format('hh:mm:ss A'));
    }, 100);


})(jQuery);


//JavaScript Codes

///toggle not in used now
function toggle_visibility(id) {
    var e = document.getElementById(id);
    if (e.style.display === 'block')
        e.style.display = 'none';
    else
        e.style.display = 'block';
}

function show(id) {
    var e = document.getElementById(id);
    e.style.display = 'block';
}

// using list.js
var clientOptions = {
    valueNames: ['name'],
    page: 4,
    pagination: true
};

var clientList = new List('clients', clientOptions);

//Dismiss current modal when you open another one
$(function () {
    return $(".modal").on("show.bs.modal", function () {
        var curModal;
        curModal = this;
        $(".modal").each(function () {
            if (this !== curModal) {
                $(this).modal("hide");
            }
        });
    });
});



