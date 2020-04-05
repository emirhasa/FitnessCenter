$ = jQuery;
$(document).ready(function () {

    function DodajAjax() {
        $(".ajax-submit.ajax-form").submit(function(event) {
            event.preventDefault();
            var form = $(this);
            var formData = form.serialize();
            var url = form.attr("action");
            var r = form.attr("ajax-result");
            $.ajax({
                type: "POST",
                url: url,
                data: formData,
                success: function(rezultat) {
                    $("#" + r).html(rezultat);
                    DodajAjax();
                }
            })
        })
    }

    $("#TwoFactorCheckbox").click(function (event) {
        if ($(this).val() == 0) {
            $(this).val(1);
        } else $(this).val(0);
        $.get("/Index/TwoFactorChange?Value=" + $(this).val(), function (rezultat, status) {
            if (rezultat == 1) {
                alert("TwoFactor autentifikacija uspješno isključena");
            } else if (rezultat == 2) {
                alert("TwoFactor autentifikacija uspješno uključena");
            } else if (rezultat == 0) {
                alert("Ne možete uključiti TwoFactor dok ne potvrdite mail");
                $(this).val(0);
                $(this).removeAttr("checked");
            }
        });

    });

    $(".brisi-obavjestenje").click(function (e) {
        if (confirm("Jeste li sigurni da zelite brisati obavjestenje?")) {
            e.trigger("click");
        }
        else {
            e.preventDefault();
        }
    });

})