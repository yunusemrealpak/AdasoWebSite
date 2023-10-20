$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this); 
        if (mode === "uyeAramaDetayModal") {

            $(buton).data('url', "/Paritial/uyeAramaDetayModal");
            formData.append("ticaretSicilNo", $(buton).data("id")); 
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
   

        }
        if (mode === "ProjeDetayModal") {

            $(buton).data('url', "/Paritial/ProjeDetayModal");
            formData.append("id", $(buton).data("id"));

            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");


        }
        if (mode === "FireKararlariDetayModal") {

            $(buton).data('url', "/Paritial/FireKararlariDetayModal");
            formData.append("id", $(buton).data("id"));

            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");


        }
        if (mode === "lnkDuyurularTebligler") {

            var TabTip = buton.parents("div[class*='duyurularveTebligler']").find("div[class*='active']").data("tab");

            location.href = "/" + TabTip;
             
        }
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
        if (mode === "iletisimFormIslem") {
            $(buton).data('url', "/Home/iletisimFormIslem/"); 
            var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
            
            formData.append("textareaAciklama_", txtMetin_);

            if (FormValidate(buton)) {
                ButtonExecute("post", "#iletisimForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        alert_v1("Bilgi", result.split("|")[1], function () { });
                        ObjectClear("#iletisimForm");
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        if (mode === "bilgiEdinmeFormIslem") {
            $(buton).data('url', "/Home/bilgiEdinmeFormIslem/"); 
            var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
            
            formData.append("textareaAciklama_", txtMetin_);

            if (FormValidate(buton)) {
                ButtonExecute("post", "#bilgiEdinmeForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        alert_v1("Bilgi", result.split("|")[1], function () { });
                        ObjectClear("#bilgiEdinmeForm");
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        if (mode === "DanismanFormIslem") {
            $(buton).data('url', "/Home/DanismanFormIslem/");
            var txtMetin_ = CKEDITOR.instances.ckeditor.getData();            
            formData.append("textareaAciklama_", txtMetin_);

            if (FormValidate(buton)) {
                ButtonExecute("post", "#DanismanForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        alert_v1("Bilgi", result.split("|")[1], function () { });
                        ObjectClear("#DanismanForm");
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        if (mode === "BultenAboneIslemler") {
            $(buton).data('url', "/Home/BultenAboneIslemler/");
           
            if (FormValidate(buton)) {
                ButtonExecute("post", "#BultenAboneIslemlerForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        alert_v1("Bilgi", result.split("|")[1], function () { });
                        ObjectClear("#BultenAboneIslemlerForm");
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        if (mode === "KendoTemplateLinkEtkinlikler") {

            var id_ = $(buton).data("id");
            var buton = $(this);
            var formData = new FormData();

            $(buton).data('url', "/Paritial/EtkinliklerModal");

            formData.append("ID", id_);

            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }

        if (mode === "sunumAraParitial") {
            
            $(buton).data('url', "/Paritial/sunumAraParitial");

            formData.append("id", $(buton).data("id"));
            formData.append("sunumYear", $("#sunumYear").val());
            formData.append("sunumMounth", $("#sunumMounth").val());
            formData.append("txtContainsSearch", $("#txtContainsSearch").val());
             
            ButtonExecute("partial", "#pagecontent", buton, formData, function () {
                
            }, function () { }, "false", "#dvParitialSunum");
        }
    });

    $("body").on("change", ".sunumDate", function () {

        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        formData.append("id", $(buton).data("id"));
        var year = $("#sunumYear").val();
        var mounth = $("#sunumMounth").val();
        var search = $("#txtContainsSearch").val();

        formData.append("sunumYear", year);
        formData.append("sunumMounth", mounth);
        formData.append("txtContainsSearch", search);
        

        if (year != 0) 
            $("#sunumMounth").removeAttr("disabled");
        else             
            $("#sunumMounth").attr("disabled","disabled");
        
         
        if (mode === "sunumYear") {
            $(buton).data('url', "/Paritial/sunumAraParitial");
            ButtonExecute("partial", "#pagecontent", buton, formData, function () {
            }, function () { }, "false", "#dvParitialSunum");

        }
    });
    $("body").on("keyup", "#txtContainsSearch", function () {


        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);
        var thisLen = $(this).val().length;
        
        if (thisLen >= 1 && thisLen <= 3 ) return false;
        else if (thisLen == 0)  post();
        else if (thisLen > 3)   post();


        function post() {
            formData.append("id", $(buton).data("id"));
            var year = $("#sunumYear").val();
            var mounth = $("#sunumMounth").val();
            var search = $("#txtContainsSearch").val();

            formData.append("sunumYear", year);
            formData.append("sunumMounth", mounth);
            formData.append("txtContainsSearch", search);

            if (year != 0)
                $("#sunumMounth").removeAttr("disabled");
            else
                $("#sunumMounth").attr("disabled", "disabled");

            if (mode === "txtContainsSearch") {
                $(buton).data('url', "/Paritial/sunumAraParitial");
                ButtonExecute("partial", "#pagecontent", buton, formData, function () {
                }, function () { }, "false", "#dvParitialSunum");
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

    $("body").on("change", ".fromTo", function () {

        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);
        if (mode === "ActivesChangeFrom") {
            var formData = new FormData();
            $(buton).data('url', "/EtkinlikListesi/InvokeAsync/?start=2021-08-30&end=2021-10-11");
            formData.append("start", $("#from").val());
            formData.append("end", $("#to").val());
            ButtonExecute("partial", "", buton, formData, function () {
            }, function () { }, "false", "#EtkinlikListesi");
        }


    });


});

function FirmaListele(buton) {
    var formData = new FormData();
    $(buton).data('url', "/Partial/GetUyeFilterList");
    formData.append("KategoriID", $("#selectKategoriler").val());
    formData.append("Arama", " ");
    ButtonExecute("partial", "", buton, formData, function () {
    }, function () { }, "false", "#CompanyList");
}