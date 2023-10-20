//tab,modal,url,post
function MessageBoxShow(message, x, y) {
    //alert(message);
}

function ShowLoading() {
    $.loading.start('Lütfen bekleyiniz...')
}

function EndLoading() {
    $.loading.end()
}

function initializeDatePicker() {
    $(".datepicker").datepicker({
        format: "dd/mm/yyyy",
        autoHide: true
    })

    $('.datepicker').datepicker().on('changeDate', function () {
        $(this).blur();
    });
}


function closePicker() {
    var items = document.getElementsByClassName("datepicker datepicker-dropdown dropdown-menu datepicker-orient-left datepicker-orient-top");
    for (var i = 0; i < items.length; i++) {
        items[i].style.display = "none";
    }
}

function ButtonExecute(url, buttontype, formID, formData, successfunction_, errorfunction_, content_, dictionary) {

    if (!(dictionary == undefined || dictionary == '' || dictionary == null)) {
        for (var key in dictionary) {
            if (dictionary[key].includes("#")) {
                if (dictionary[key] != "#") {
                    if (buttontype == "partial-get" && url.includes("?")) {
                        url += "&" + key + "=" + $(dictionary[key]).val();
                    }
                    else if (buttontype == "partial-get" && !(url.includes("?"))) {
                        url += "?" + key + "=" + $(dictionary[key]).val();
                    }
                    else {
                        formData.append(key, $(dictionary[key]).val());
                    }
                }
            }
            else {
                if (buttontype == "partial-get" && url.includes("?")) {
                    url += "&" + key + "=" + dictionary[key];
                }
                else if (buttontype == "partial-get" && !(url.includes("?"))) {
                    url += "?" + key + "=" + dictionary[key];
                }
                else {
                    formData.append(key, dictionary[key]);
                }
            }

        }
    }

    if (buttontype == "modal") {
        $.get(url, function (result, status) {
            $('#dvMdlDialog').html(result);
            $('#mdl').modal('show');
            initializeDatePicker();
            successfunction_(result);
        });
    }
    else if (buttontype == "url") {
        window.location.href = url;
        successfunction_(null);
    }
    else if (buttontype == "post") {

        if (!(formID == undefined || formID == '' || formID == null)) {

            $(formID + ' input').each(function () {
                if ($(this).attr('type') == 'checkbox') {
                    formData.append($(this).attr('name'), $(this).is(":checked"));
                }
                else if ($(this).attr('type') == 'radio') {
                    if ($(this).is(":checked") == true)
                        formData.append($(this).attr('name'), $(this).val());
                }
                else {
                    formData.append($(this).attr('name'), $(this).val());
                }
            })

            $(formID + ' textarea').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            })

            $(formID + ' select').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            })

            $(formID + ' input[type=file]').each(function () {
                formData.append($(this).attr('name'), $(this)[0].files[0]);
            })
        }

        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function () {

            },
            success: function (result) {
                MessageBoxShow("success", "Mesajiniz Var!", "Isleminiz basariyla tamamlandi");
                initializeDatePicker();
                successfunction_(result);
            },
            error: function (result) {
                MessageBoxShow("error", "Mesajiniz Var!", "Isleminiz gerceklestirilirken bir hata meydana geldi");
                errorfunction_(result);
            }
        });
    }
    else if (buttontype == "partial-post") {

        if (!(formID == undefined || formID == '' || formID == null)) {

            $(formID + ' input').each(function () {
                if ($(this).attr('type') == 'checkbox') {
                    formData.append($(this).attr('name'), $(this).is(":checked"));
                }
                else if ($(this).attr('type') == 'radio') {
                    if ($(this).is(":checked") == true)
                        formData.append($(this).attr('name'), $(this).val());
                }
                else {
                    formData.append($(this).attr('name'), $(this).val());
                }
            })

            $(formID + ' textarea').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            })

            $(formID + ' select').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            })

            $(formID + ' input[type=file]').each(function () {
                formData.append($(this).attr('name'), $(this)[0].files[0]);
            })
        }
        for (var pair of formData.entries()) {
            console.log(pair[0] + ', ' + pair[1]);
        }

        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (result) {
                $(content_).html(result);
                initializeDatePicker();
                successfunction_(result);
            },
            error: function () {
                errorfunction_();
            }
        });
    }
    else if (buttontype == "partial-get") {
        $.get(url, function (result, status) {
            $(content_).html(result);
            initializeDatePicker();
            successfunction_(result);
        });
    }
    else if (buttontype == "get") {
        $.get(url, function (result, status) {
            initializeDatePicker();
            successfunction_(result);
        });
    }
}