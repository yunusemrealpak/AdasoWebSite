function IsValidEmailAddress(Text) {
    var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
    return pattern.test(Text);
}

function IsValidDate(Text) {
    //var pattern = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    //var pattern = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    //return pattern.test(true);
    return true;
}

function IsValidTel(Text) {
    var pattern = /^(05)[0-9][0-9][1-9]([0-9]){6}$/;
    return pattern.test(Text.replace(/\D+/g, ""));
}

function IsPassword(Text, PasswordType) {
    var pattern = "";
    if (PasswordType == "easy") {
        return true;
    }
    else if (PasswordType == "medium") {
        var pattern = new RegExp("^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})");//mediumRegex
    }
    else if (PasswordType == "strong") {
        var pattern = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");//strongRegex
    }
    return pattern.test(Text);
}

function IsValidTC(Text) {
    Text = Text.toString();
    var isEleven = /^[0-9]{11}$/.test(Text);
    var totalX = 0;
    for (var i = 0; i < 10; i++) {
        totalX += Number(Text.substr(i, 1));
    }
    var isRuleX = totalX % 10 == Text.substr(10, 1);
    var totalY1 = 0;
    var totalY2 = 0;
    for (var i = 0; i < 10; i += 2) {
        totalY1 += Number(Text.substr(i, 1));
    }
    for (var i = 1; i < 10; i += 2) {
        totalY2 += Number(Text.substr(i, 1));
    }
    var isRuleY = ((totalY1 * 7) - totalY2) % 10 == Text.substr(9, 0);
    return isEleven && isRuleX && isRuleY;
}

////////////////////////

var success_message = "İşleminiz başarıyla tamamlandı";
var error_message = "İşleminiz tamamlanırken bir hata meydana geldi";

var error_message_template = "<span class=\"error\" style=\"color:red;\">{message}</span>";
var success_message_template = "<span class=\"error\" style=\"color:green;\">{message}</span>";

var tc_error_message = "Girilen kimlik numarası formatı yanlış";
var tc_used_error_message = "Girmiş olduğunuz kimlik numarası başka biri tarafından kullanılmaktadır.";
var tc_not_used_error_message = "Girmiş olduğunuz kimlik numarası sistemde kayıtlı bulunmamaktadır.";
var tc_success_message = "Girmiş olduğunuz kimlik numarası uygun.";

var email_error_message = "Girilen email formatı yanlış";
var email_used_error_message = "Girmiş olduğunuz email adresi başka biri tarafından kullanılmaktadır.";
var email_not_used_error_message = "Girmiş olduğunuz email adresi sistemde kayıtlı bulunmamaktadır.";
var email_success_message = "Girmiş olduğunuz email adresi uygun.";

var tel_error_message = "Girilen telefon formatı yanlış";
var date_error_message = "Girilen tarih formatı yanlış";
var text_error_message = "Text alanı boş geçilemez";
var number_error_message = "Sayı alanı boş geçilemez";
var select_error_message = "Seçim alanı boş geçilemez";
var file_error_message = "Dosya seçimi yapınız";
var checkbox_error_message = "Lütfen işaretleyiniz.";

var password_error_message = "Lütfen şifre giriniz.";
var password_strength_error_message = "Şifreniz yeterince karmaşık değil.";
var password_compare_to_error_message = "Şifre ve şifre tekrarı aynı değil.";

var max_length_error_message = "Girilen değer sayısı çok fazla.(Max:{0})";
var min_length_error_message = "Girilen değer sayısı çok az.(Min:{0})";

$(document).ready(function () {
    $("[data-prevent_default='false'],[data-prevent_default='false']").closest("form").submit(function (e) {
        if ($(this).data("form_validate")) {
        }
        else {
            e.preventDefault();
        }
    });
});

function FormValidate(Item) {
    var group_name = $(Item).data("group_name");

    var is_validate = true;
    var scope_ = 'input,select,textarea';
    var modal_message_template = "";
    var min_error_input_height = 10000;
    var moving_scroll_bar = $(Item).data("moving_scroll_bar");

    if ($(Item).data("required") == null || $(Item).data("required") == undefined || $(Item).data("required") == "") return is_validate;

    $(scope_).each(function () {
        var is_sub_validate = true;
        var value = $(this).val();
        var required = $(this).data("required");
        var sub_group_name = $(this).data("group_name");
        var type = $(this).attr("type");
        var error_message = $(this).data("error_message");

        var error_format_message = $(this).data("error_format_message");

        var max_lenght = $(this).data("max_lenght");
        var error_max_lenght_message = $(this).data("error_max_lenght_message");

        var min_lenght = $(this).data("min_lenght");
        var error_min_lenght_message = $(this).data("error_min_lenght_message");

        var error_strength_message = $(this).data("error_password_strength_message");
        var error_compare_to_message = $(this).data("error_compare_to_message");

        var form_group = $(this).closest("div");//$(this).closest(".form-group");
        var error_message_template_temp = error_message_template;
        var message_type = $(this).data("message_type");

        $(form_group).find(".error").remove();
        if (required === true && (sub_group_name === group_name || group_name == undefined)) {
            if (type === "email") {
                if (value.trim() === "") {
                    error_message = error_message == undefined ? email_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
                else if (!IsValidEmailAddress(value)) {
                    error_format_message = error_format_message == undefined ? email_error_message : error_format_message;
                    error_message = error_format_message == undefined ? error_message : error_format_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }

                if (max_lenght != undefined && value.length > max_lenght) {
                    error_max_lenght_message = error_max_lenght_message == undefined ? max_length_error_message.replace("{0}", max_lenght) : error_max_lenght_message;
                    error_message = error_max_lenght_message == undefined ? error_message : error_max_lenght_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_max_lenght_message);
                    is_validate = false;
                    is_sub_validate = false;
                }

                if (min_lenght != undefined && value.length > min_lenght) {
                    error_min_lenght_message = error_min_lenght_message == undefined ? min_length_error_message.replace("{0}", min_lenght) : error_min_lenght_message;
                    error_message = error_min_lenght_message == undefined ? error_message : error_min_lenght_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_min_lenght_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }
            if (type === "tel") {
                if (value.trim() === "") {
                    error_message = error_message == undefined ? tel_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
                else if (!IsValidTel(value)) {
                    error_message = error_message == undefined ? tel_error_message : error_message;
                    error_message = error_format_message == undefined ? error_message : error_format_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }

                if (max_lenght != undefined && value.length > max_lenght) {
                    error_max_lenght_message = error_max_lenght_message == undefined ? max_length_error_message.replace("{0}", max_lenght) : error_max_lenght_message;
                    error_message = error_max_lenght_message == undefined ? error_message : error_max_lenght_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_max_lenght_message);
                    is_validate = false;
                    is_sub_validate = false;
                }

                if (min_lenght != undefined && value.length > min_lenght) {
                    error_min_lenght_message = error_min_lenght_message == undefined ? min_length_error_message.replace("{0}", min_lenght) : error_min_lenght_message;
                    error_message = error_min_lenght_message == undefined ? error_message : error_min_lenght_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_min_lenght_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }
            else if (type === "date" || $(this).data("sub_type") === "date") {
                if (value.trim() === "") {
                    error_message = error_message == undefined ? date_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
                else if (!IsValidDate(value)) {
                    error_message = error_message == undefined ? date_error_message : error_message;
                    error_message = error_format_message == undefined ? error_message : error_format_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }
            else if (type === "text" || type === "textarea") {
                if ($(this).data("sub_type") === "tc") {
                    if (!IsValidTC(value)) {
                        error_message = error_message == undefined ? tc_error_message : error_message;
                        error_message = error_format_message == undefined ? error_message : error_format_message;
                        error_message_template_temp = error_message_template.replace("{message}", error_message);
                        is_validate = false;
                        is_sub_validate = false;
                    }
                }
                else if ($(this).data("sub_type") === "date") {
                    if (value == "") {
                        error_message = error_message == undefined ? date_error_message : error_message;
                        error_message_template_temp = error_message_template.replace("{message}", error_message);
                        is_validate = false;
                        is_sub_validate = false;
                    }
                }
                else {
                    if (value == "") {
                        error_message = error_message == undefined ? text_error_message : error_message;
                        error_message_template_temp = error_message_template.replace("{message}", error_message);
                        is_validate = false;
                        is_sub_validate = false;
                    }

                    if (max_lenght != undefined && value.length > max_lenght) {
                        error_max_lenght_message = error_max_lenght_message == undefined ? max_length_error_message.replace("{0}", max_lenght) : error_max_lenght_message;
                        error_message = error_max_lenght_message == undefined ? error_message : error_max_lenght_message;
                        error_message_template_temp = error_message_template.replace("{message}", error_max_lenght_message);
                        is_validate = false;
                        is_sub_validate = false;
                    }

                    if (min_lenght != undefined && value.length > min_lenght) {
                        error_min_lenght_message = error_min_lenght_message == undefined ? min_length_error_message.replace("{0}", min_lenght) : error_min_lenght_message;
                        error_message = error_min_lenght_message == undefined ? error_message : error_min_lenght_message;
                        error_message_template_temp = error_message_template.replace("{message}", error_min_lenght_message);
                        is_validate = false;
                        is_sub_validate = false;
                    }
                }
            }
            else if (type === "password") {
                if (value === "") {
                    error_message = error_message == undefined ? password_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
                else {
                    if ($(this).data("compare_to") === undefined) {
                        if (max_lenght != undefined && value.length > max_lenght) {
                            error_max_lenght_message = error_max_lenght_message == undefined ? max_length_error_message.replace("{0}", max_lenght) : error_max_lenght_message;
                            error_message = error_max_lenght_message == undefined ? error_message : error_max_lenght_message;
                            error_message_template_temp = error_message_template.replace("{message}", error_max_lenght_message);
                            is_validate = false;
                            is_sub_validate = false;
                        }
                        else if (min_lenght != undefined && value.length > min_lenght) {
                            error_min_lenght_message = error_min_lenght_message == undefined ? min_length_error_message.replace("{0}", min_lenght) : error_min_lenght_message;
                            error_message = error_min_lenght_message == undefined ? error_message : error_min_lenght_message;
                            error_message_template_temp = error_message_template.replace("{message}", error_min_lenght_message);
                            is_validate = false;
                            is_sub_validate = false;
                        }
                        else if (!IsPassword(value, $(this).data("password_strength_type"))) {
                            error_message = error_strength_message == undefined ? password_strength_error_message : error_strength_message;
                            error_message_template_temp = error_message_template.replace("{message}", error_message);
                            is_validate = false;
                            is_sub_validate = false;
                        }
                    }
                    else if ($(this).data("compare_to") != undefined) {
                        if ($($(this).data("compare_to")).val() != value) {
                            error_message = error_compare_to_message == undefined ? password_compare_to_error_message : error_compare_to_message;
                            error_message_template_temp = error_message_template.replace("{message}", error_message);
                            is_validate = false;
                            is_sub_validate = false;
                        }
                    }
                }
            }

            else if (type === "select") {
                if (value === "" || value === undefined || value === null || value === "0") {
                    error_message = error_message == undefined ? select_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }
            else if (type === "hidden") {
                if (value === "") {
                    error_message = error_message == undefined ? "" : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }
            else if (type === "checkbox") {
                value = $(this).prop('checked');
                if (value == false) {
                    error_message = error_message == undefined ? checkbox_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }
            else if (type === "file") {
                value = $(this)[0].files[0];
                if (value == null || value == undefined) {
                    error_message = error_message == undefined ? file_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }

            else if (type === "number" || $(this).data("sub_type") === "number") {
                if (value == "") {
                    error_message = error_message == undefined ? number_error_message : error_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_message);
                    is_validate = false;
                    is_sub_validate = false;
                }

                if (max_lenght != undefined && value > max_lenght) {
                    error_max_lenght_message = error_max_lenght_message == undefined ? max_length_error_message.replace("{0}", max_lenght) : error_max_lenght_message;
                    error_message = error_max_lenght_message == undefined ? error_message : error_max_lenght_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_max_lenght_message);
                    is_validate = false;
                    is_sub_validate = false;
                }

                if (min_lenght != undefined && value > min_lenght) {
                    error_min_lenght_message = error_min_lenght_message == undefined ? min_length_error_message.replace("{0}", min_lenght) : error_min_lenght_message;
                    error_message = error_min_lenght_message == undefined ? error_message : error_min_lenght_message;
                    error_message_template_temp = error_message_template.replace("{message}", error_min_lenght_message);
                    is_validate = false;
                    is_sub_validate = false;
                }
            }


            if (is_sub_validate === false && message_type === "formmessage") {
                $(form_group).append(error_message_template_temp);
            }
            else if (is_sub_validate === false && message_type === "modal") {
                modal_message_template += error_message_template_temp + "<br />";
            }
            else if (is_sub_validate === false && message_type === "tooltip") {
                $(this).attr('title', error_message).tooltip('fixTitle').tooltip('show');
            }
            else if (is_sub_validate === false && error_message != undefined) {
                toastr.error("Form Hata", error_message);//alert(error_message);
            }

            if (is_sub_validate === false) {
                $(this).css("border", "1px solid #ff0505");
                if ($(this).position().top < min_error_input_height)
                    min_error_input_height = $(this).position().top;
            }
            else {
                if ($(this).data("sub_type") === "date") {
                    // alert("green");
                }
                $(this).css("border", "1px solid green");
                if ($(this).position().top < min_error_input_height)
                    min_error_input_height = $(this).position().top;
            }
        }
    });

    if (is_validate === false) {
        if (modal_message_template !== "") {
            if (!($('#validMessageModal').length)) {
                var modalTemplate = "";
                modalTemplate += '<div id="validMessageModal" class="modal fade">';
                modalTemplate += '    <div class="modal-dialog modal-confirm">';
                modalTemplate += '        <div class="modal-content">';
                modalTemplate += '            <div class="modal-header">';
                modalTemplate += '                <div class="icon-box">';
                modalTemplate += '                    <i class="material-icons">&#xE5CD;</i>';
                modalTemplate += '                </div>';
                modalTemplate += '                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>';
                modalTemplate += '            </div>';
                modalTemplate += '            <div class="modal-body text-center">';
                modalTemplate += '                <h4>Ooops!</h4>';
                modalTemplate += '                <p id="message"></p>';
                modalTemplate += '                <button class="btn btn-success" data-dismiss="modal">Try Again</button>';
                modalTemplate += '            </div>';
                modalTemplate += '        </div>';
                modalTemplate += '    </div>';
                modalTemplate += '</div>';
                $("form").append(modalTemplate);
            }

            $("#message").html(modal_message_template);
            $("#validMessageModal").modal("show");
        }
        if (moving_scroll_bar === "1") {
            $('html,body').animate({
                scrollTop: min_error_input_height
            });
        }
    }
    if (is_validate && $(Item).attr("type") == "submit") {
        $(Item).closest("form").data("form_validate", true);
        $(Item).closest("form").submit();
    }
    return is_validate;
}