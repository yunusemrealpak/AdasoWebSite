$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        if (mode === "FirmaGiris") {
            $(buton).data('url', "/Panel/Login/");
            formData.append("type", "Giris");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#frmLogin", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        window.location = '/Panel/Index'
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        if (mode === "FirmaSifreGuncelle") {
            $(buton).data('url', "/Panel/UyeIslem/");
            formData.append("uyeID", $(buton).data("data1"));
            formData.append("type", "SifreGuncelle");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#frmGenel", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        window.location = '/Panel/Index'
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }

        else if (mode === "UrunGuncelle") {
            $(buton).data('url', "/Panel/ProductDetail");
            ButtonExecute("url", "", this, formData, function () {
            }, function () { }, "true", "#");
        }
        else if (mode === "UrunIslem") {
            $(buton).data('url', "/Panel/UrunIslem/");
            formData.append("urunID", $(buton).data("data1"));
            formData.append("type", "Kaydet");

            formData.append("txtUrunAciklama_", CKEDITOR.instances['txtUrunAciklama'].getData());
            formData.append("txtUrunIcerik_", CKEDITOR.instances['txtUrunIcerik'].getData());

            var iiiii = 1;
            $(".li-kategori-active").each(function (index) {
                formData.append("kategori_" + iiiii, $(this).data("data1"));
                formData.append("kategoriUst_" + iiiii, $(this).data("data2"));
                iiiii++;
            });
            formData.append("index", iiiii);
            if (FormValidate(buton)) {
                ButtonExecute("post", "#genelBilgiler", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        window.location = "/Panel/ProductDetail/" + result.split("|")[2];
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        else if (mode === "GetUrunSilModal") {
            $(buton).data('url', "/Partial/GetUrunSilModal/");
            formData.append("urunID", $(buton).data("data1"));
            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "UrunSilProcess") {
            $(buton).data('url', "/Panel/UrunIslem/");
            formData.append("urunID", $(buton).data("data1"));
            formData.append("type", "Sil");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }

        else if (mode === "UyeIslem") {
            $(buton).data('url', "/Panel/UyeIslem/");
            formData.append("uyeID", $(buton).data("data1"));
            formData.append("type", "Kaydet");

            formData.append("txtUyeAciklama_", CKEDITOR.instances['txtUyeAciklama'].getData());
            formData.append("txtUyeIcerik_", CKEDITOR.instances['txtUyeIcerik'].getData());

            var iiiii = 1;
            $(".li-kategori-active").each(function (index) {
                formData.append("kategori_" + iiiii, $(this).data("data1"));
                formData.append("kategoriUst_" + iiiii, $(this).data("data2"));
                iiiii++;
            });
            formData.append("index", iiiii);
            if (FormValidate(buton)) {
                ButtonExecute("post", "#genelBilgiler", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }

        else if (mode === "GetDosyaFormModal") {
            $(buton).data('url', "/Partial/GetDosyaFormModal");
            formData.append("DosyaID", $(buton).data("data1"));
            formData.append("RefID", $(buton).data("data2"));
            formData.append("AltIslem", $(buton).data("data3"));
            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "DosyaIslem") {
            $(buton).data('url', "/Panel/DosyaIslem/");
            formData.append("DosyaID", $(buton).data("data1"));
            formData.append("RefID", $(buton).data("data2"));
            formData.append("AltIslem", $(buton).data("data3"));
            formData.append("type", "Kaydet");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
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
        else if (mode === "GetDosyaSilModal") {
            $(buton).data('url', "/Partial/GetDosyaSilModal/");
            formData.append("DosyaID", $(buton).data("data1"));
            formData.append("AltIslem", $(buton).data("data2"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "DosyaSilProcess") {
            $(buton).data('url', "/Panel/DosyaIslem/");
            formData.append("DosyaID", $(buton).data("data1"));
            formData.append("AltIslem", $(buton).data("data2"));
            formData.append("type", "Sil");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }

        else if (mode === "GetFormMesajFormModal") {
            $(buton).data('url', "/Partial/GetFormMesajFormModal");
            formData.append("FormMesajID", $(buton).data("data1"));
            formData.append("UyeID", $(buton).data("data2"));
            formData.append("UrunID", $(buton).data("data3"));
            formData.append("IsSubmitButton", $(buton).data("isSubmitButton"));

            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
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