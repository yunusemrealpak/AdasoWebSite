$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        if (mode === "GetTebliglerForm") {
            $(buton).data('url', "/Admin/Tebligler/GetTebliglerForm");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "TebliglerIslem") {
            $(buton).data('url', "/Admin/Tebligler/TebliglerIslem/");
            formData.append("ID", $(buton).data("data1"));
            formData.append("type", $(buton).data("type"));
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        else if (mode === "GetTebliglerSilModal") {
            $(buton).data('url', "/Admin/Tebligler/GetTebliglerSilModal/");
            formData.append("ID", $(buton).data("data1"));
            ButtonExecute("partial", "#dvMdlDialog", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        if (mode === "GetHaberFormModal") {
            $(buton).data('url', "/Partial/GetHaberFormModal");
            formData.append("ID", $(buton).data("data1"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "HaberIslem") {
            $(buton).data('url', "/Admin/HaberIslem/");
            formData.append("ID", $(buton).data("data1"));
            formData.append("type", "Kaydet");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        //alert_v1("Bilgi", result.split("|")[1], function () { });
                        //$('#hoca_yabanciDil_datatable').DataTableT(hoca_yabanciDil_getir);
                        //$("#mdl").modal("hide");
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        else if (mode === "GetHaberSilModal") {
            $(buton).data('url', "/Partial/GetHaberSilModal/");
            formData.append("ID", $(buton).data("data1"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "HaberSilProcess") {
            $(buton).data('url', "/Admin/HaberIslem/");
            formData.append("ID", $(buton).data("data1"));
            formData.append("type", "sil");            
                        
            ButtonExecute("post", "#mdl", buton, formData, function (result) {
                if (result.split("|")[0] === "Ok") {
                    location.reload();
                }
                else {
                    alert_v1("Hata", result.split("|")[1], function () { });
                }
            }, function () { }, "false", "");
            
        }
        else if (mode === "GetHaberAktifPasifModal") {
            $(buton).data('url', "/Partial/GetHaberAktifPasifModal");
            formData.append("ID", $(buton).data("data1"));
            formData.append("AktifPasif", $(buton).data("data2"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "HaberAktifPasifIslem") {
            $(buton).data('url', "/Admin/HaberIslem/");
            formData.append("ID", $(buton).data("data1"));
            formData.append("AktifPasif", $(buton).data("data2"));
            formData.append("type", "AktifPasif");
            ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                if (result.split("|")[0] === "Ok") {
                    location.reload();
                }
                else {
                    alert_v1("Hata", result.split("|")[1], function () { });
                }
            }, function () { }, "false", "");
        }

        if (mode === "Login") {
 
            $(buton).data('url', "/admin/admin/GetLoginForm");
            formData.append("ID", $(buton).data("data1"));

            ButtonExecute("post", "#mdlForm", buton, formData, function (result) {

                if (result.split("|")[0] === "Ok") {
                    location.reload();
                }
                else {
                    alert_v1("Hata", result.split("|")[1], function () { });
                }
            }, function () { }, "false", "");
        }

    });

    $("body").on("keyup", "input[data-mode]", function (e) {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);
        if (mode === "DilDetayIslem") {
            if (e.keyCode == 13) {
                $(buton).data('url', "/Admin/DilDetayIslem/");
                formData.append("DilDetayID", $(buton).data("data1"));
                formData.append("DilID", $(buton).data("data2"));
                formData.append("DilEtiket", $(buton).data("data3"));
                formData.append("DilIcerik", $(buton).val());
                formData.append("type", "Kaydet");
                ButtonExecute("post", "#genel", buton, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        $(buton).closest('td').removeClass("not_change");
                        $(buton).closest('td').addClass("change");
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                        $(buton).closest('td').removeClass("change");
                        $(buton).closest('td').addClass("not_change");
                    }
                }, function () { $(buton).closest('td').removeClass("change"); $(buton).closest('td').addClass("not_change"); }, "false", "");
            }
        }
    });

    $("body").on("change", "select[data-mode]", function (e) {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);
        if (mode === "SayfaDilIslem") {
            $(buton).data('url', "/Home/SayfaDilIslem/");
            formData.append("DilID", $(buton).val());
            ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                if (result.split('|')[0] === "Ok") {
                    location.reload();
                }
                else {
                    alert_v1("Hata", result.split("|")[1], function () { });
                }
            }, function () { }, "false", "");
        }
    });

    $("body").on("click", ".li-kategori", function () {

        if ($(this).hasClass("li-kategori-active")) {
            $(this).removeClass("li-kategori-active");
            $(this).find('i').removeClass("fa-check-circle-o").addClass("fa-circle-o");
        }
        else {
            $(this).addClass("li-kategori-active");
            $(this).find('i').removeClass("fa-circle-o").addClass("fa-check-circle-o");

        }
    });

    $("body").on("click", ".img-kirilim", function () {
        $(this).closest(".li-kirilim").find(".li-kategori").toggle('slow')
        if ($(this).attr("src") == "https://icons.getbootstrap.com/icons/chevron-double-down.svg") {
            $(this).attr("src", "https://icons.getbootstrap.com/icons/chevron-double-up.svg");
        }
        else {
            $(this).attr("src", "https://icons.getbootstrap.com/icons/chevron-double-down.svg");
        }
        //$(this).find(".li-kategori").slideDown("slow");

    });
});