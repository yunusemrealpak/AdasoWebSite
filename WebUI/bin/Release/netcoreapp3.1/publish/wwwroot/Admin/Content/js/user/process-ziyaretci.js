$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        if (mode === "GetUyeFilterList") {

            $(buton).data('url', "/Partial/GetUyeFilterList");
            formData.append("KategoriID", $("#selectKategoriler").val());
            formData.append("Arama", $("#txtCompanyName").val());
            formData.append("dilID", $(buton).data("data1"));
            ButtonExecute("partial", "", buton, formData, function () {
            }, function () { }, "false", "#CompanyList");

        }

        else if (mode === "GetUrunFilterList") {
            $(buton).data('url', "/Partial/GetUrunFilterList");
            formData.append("KategoriID", $("#hdnKategoriID").val());
            formData.append("Arama", $("#txtArama").val());
            //alert($("#txtArama").val());

            try {
                formData.append("UyeID", $("#hdnUyeID").val());
            } catch (e) {
                formData.append("UyeID", "0");
            }
            ButtonExecute("partial", "", buton, formData, function () {
            }, function () { }, "false", "#ProductList");
        }

        else if (mode === "GetRequestFormModal") {
            $(buton).data('url', "/Partial/GetRequestFormModal");
            formData.append("FormMesajID", $(buton).data("data1"));
            formData.append("UyeID", $(buton).data("data2"));
            formData.append("UrunID", $(buton).data("data3"));
            formData.append("EtkinlikID", $(buton).data("data4"));
            formData.append("FormMesajTuru", $(buton).data("data5"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }

        else if (mode === "FormMesajIslem") {
            $(buton).data('url', "/Home/FormMesajIslem/");
            formData.append("FormMesajID", $(buton).data("data1"));
            formData.append("UyeID", $(buton).data("data2"));
            formData.append("UrunID", $(buton).data("data3"));
            formData.append("EtkinlikID", $(buton).data("data4"));
            formData.append("FormMesajTuru", $(buton).data("data5"));
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        alert_v1("Bilgi", result.split("|")[1], function () { });
                        ObjectClear("#mdlForm");
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }

        if (mode === "SayfaDilIslem") {
            $(buton).data('url', "/Home/SayfaDilIslem/");
            formData.append("DilID", $(buton).data("data1"));
            var attr = $(this).attr('tabindex');
            if (typeof attr !== typeof undefined && attr !== false) {
                ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                    if (result.split('|')[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
    });

    $("body").on("click", "li[data-mode]", function () {
        var mode = $(this).data("mode");
        var buton = $(this);

        if (mode === "GetKategoriSelect") {
            $("li[data-mode=GetKategoriSelect]").removeClass("active active-li");
            $(buton).addClass("active active-li");
            $("#hdnKategoriID").val($(buton).data("data1"));
            $("#btnUrunListele").trigger("click");
        }
    });

    $("body").on("change", "#selectDiller", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        if (mode === "SayfaDilIslem") {
            $(buton).data('url', "/Home/SayfaDilIslem/");
            formData.append("DilID", $(buton).val());
            ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                if (result.split('|')[0] === "Ok") {
                    alert_v1("Bilgi", result.split("|")[1], function () { });
                    location.reload();
                }
                else {
                    alert_v1("Hata", result.split("|")[1], function () { });
                }
            }, function () { alert_v1("Hata", "ajax hata", function () { }); }, "false", "");
        }
    });

    //$("body").on("keyup", "#txtArama", function (e) {
    //    if (e.keyCode == 13) {
    //        $("#btnUrunListele").trigger("click");
    //    }
    //});
});

function FirmaListele(buton) {
    var formData = new FormData();
    $(buton).data('url', "/Partial/GetUyeFilterList");
    formData.append("KategoriID", $("#selectKategoriler").val());
    formData.append("Arama", " ");
    ButtonExecute("partial", "", buton, formData, function () {
    }, function () { }, "false", "#CompanyList");
}



//$('.nav li').each(function (i) {

//    var href_ = $(this).find("a").attr("href");

//    if (href_.charAt(0) === "/") {

//        var attr = $(this).attr("active", href_.slice(1));

//        var loc = window.location.href.slice(window.location.href.lastIndexOf("/") + 1);
//        var loc2 = window.location.href;

//        var liAttr = $(this).attr("active");

//        console.log(loc2.slice(loc2.lastIndexOf("/")));

//        if (loc === liAttr) {
//            $('.nav li').removeClass("active");
//            $(this).addClass("active");
//        }
//    }

//});