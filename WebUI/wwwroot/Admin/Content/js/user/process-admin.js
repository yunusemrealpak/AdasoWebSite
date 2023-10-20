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
        else if (mode === "GetTebligIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));            
            formData.append("type", $(buton).data("type"));            
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Tebligler/GetTebligIslemler/");
                var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
                formData.append("txtMetin_", txtMetin_);

                /*alert($('input[name="txtBitTarih"]').val());*/
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
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Tebligler/GetTebligIslemler/");
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

        }
        else if (mode === "GetTebliglerUpdateModal") {
            $(buton).data('url', "/Admin/Tebligler/GetTebliglerUpdateModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetTebliglerSilModal") {
            $(buton).data('url', "/Admin/Tebligler/GetTebliglerSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#dvMdlDialog", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        if (mode === "GetHaberlerModal") {
            $(buton).data('url', "/Admin/Admin/GetHaberlerModal");
            formData.append("ID", $(buton).data("data1"));            
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetHaberlerUpdateModal") {
            $(buton).data('url', "/Admin/Admin/GetHaberlerUpdateModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode ==="GetYaziIslemler") {
            var type = $(buton).data("type");
            formData.append("ID", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            var KategoriAdi_=$("#selectYaziTipi option:selected").text()
            formData.append("KategoriAdi", KategoriAdi_);            
            if (KategoriAdi_ == "Haber" && $(buton).data("id")!=0 ) {
                var resimSira = $("#hdnImgSira").val();
                $("#sortable >li >a >img.YaziGalery").each(function (x) {
                    var order = $(this).attr("data-ImgOrder");
                    var id = $(this).attr("data-Imgid");
                    resimSira += order + "-" + id + ",";


                });
                formData.append("ImgSira", resimSira.slice(0, -1));
            }
            else formData.append("ImgSira", "null_");

                if (type == "Kaydet") {
                    $(buton).data('url', "/Admin/Admin/GetYaziIslemler/");
                    var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
                    formData.append("txtMetin_", txtMetin_);

                    /*alert($('input[name="txtBitTarih"]').val());*/
                    if (FormValidate(buton)) {
                        ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                            if (result.split("|")[0] === "Ok") {
                                kendo_reload("#tblYazilar", "");
                                $("#mdl").modal("hide");
                            }
                            else {
                                alert_v1("Hata", result.split("|")[1], function () { });
                            }
                        }, function () { }, "false", "");
                    }

                }
                else if (type == "Sil") {
                    $(buton).data('url', "/Admin/Admin/GetYaziIslemler/");
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
             
        }
        else if (mode === "GetYazilarSilModal") {

            $(buton).data('url', "/Admin/Admin/GetYazilarSilModal/");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "#dvMdlDialog", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetHrkModal") {
            $(buton).data('url', "/Admin/Admin/GetIslemHrkModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#dvMdlDialog", buton, formData, function () {
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

        /*TDHABERLER*/
        if (mode === "GetTDHaberlerModal") {
            $(buton).data('url', "/Admin/TDHaberler/GetTDHaberlerModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetTDHaberlerUpdateModal") {
            $(buton).data('url', "/Admin/TDHaberler/GetTDHaberlerUpdateModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetTDHaberIslemler") {
            var type = $(buton).data("type");
            formData.append("ID", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            formData.append("KategoriAdi", $("#selectYaziTipi option:selected").text());
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/TDHaberler/GetTDHAberIslemler/");
 
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
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/TDHaberler/GetTDHaberIslemler/");
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

        }
        else if (mode === "GetTDHaberlerSilModal") {
            $(buton).data('url', "/Admin/TDHaberler/GetTDHaberlerSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        /*TDHABERLER*/

        /*RAPORLAR*/
        if (mode === "GetRaporFormModal") {
            $(buton).data('url', "/Admin/Raporlar/GetRaporFormModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetRaporUpdateModal") {
            $(buton).data('url', "/Admin/Raporlar/GetRaporUpdateModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetRaporSilModal") {
            $(buton).data('url', "/Admin/Raporlar/GetRaporSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetRaporIslemler") {
            var type = $(buton).data("type");
            formData.append("ID", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            formData.append("KategoriAdi", $("#selectYaziTipi option:selected").text());
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Raporlar/GetRaporIslemler/");

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
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Raporlar/GetRaporIslemler/");
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

        }
        /*RAPORLAR*/

        /*ETKİNLİKLER*/
        if (mode === "GetEtkinliklerModal") {
            $(buton).data('url', "/Admin/Etkinlikler/GetEtkinliklerModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetEtkinliklerUpdateModal") {
            $(buton).data('url', "/Admin/Etkinlikler/GetEtkinliklerUpdateModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetEtkinliklerSilModal") {
            $(buton).data('url', "/Admin/Etkinlikler/GetEtkinliklerSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetEtkinliklerIslemler") {
            var type = $(buton).data("type");
            formData.append("ID", $(buton).data("id"));
            formData.append("type", $(buton).data("type")); 
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Etkinlikler/GetEtkinliklerIslemler/");
                var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
                formData.append("txtMetin_", txtMetin_);
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Etkinlikler/GetEtkinliklerIslemler/");
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            kendo_reload("#tblYazilar", "&kendotable.ust=1&kendotable.ust_=0");
                        }
                        else {
                            alert_v1("Hata", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }
            }

        }
        /*ETKİNLİKLER*/

        /*GAZETELER*/
        if (mode === "GetGazetelerModal") {
            $(buton).data('url', "/Admin/Gazeteler/GetGazetelerModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetGazetelerUpdateModal") {
            $(buton).data('url', "/Admin/Gazeteler/GetGazetelerUpdateModal");
            formData.append("ID", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetGazetelerSilModal") {
            $(buton).data('url', "/Admin/Gazeteler/GetGazetelerSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetGazetelerIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Gazeteler/GetGazetelerIslemler/"); 
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Gazeteler/GetGazetelerIslemler/");
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

        }
        /*GAZETELER*/

        /*PROJELER*/
        if (mode === "GetProjelerModal") {
            $(buton).data('url', "/Admin/Projeler/GetProjelerModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetProjelerUpdateModal") {
            $(buton).data('url', "/Admin/Projeler/GetProjelerUpdateModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetProjelerSilModal") {
            $(buton).data('url', "/Admin/Projeler/GetProjelerSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetProjelerIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Projeler/GetProjelerIslemler/");
                var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
                formData.append("txtMetin_", txtMetin_);
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Projeler/GetProjelerIslemler/");
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

        }
        /*PROJELER*/

        /*Youtube*/
        if (mode === "GetYoutubeModal") {
            $(buton).data('url', "/Admin/Youtube/GetYoutubeModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetYoutubeUpdateModal") {
            $(buton).data('url', "/Admin/Youtube/GetYoutubeUpdateModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetYoutubeSilModal") {
            $(buton).data('url', "/Admin/Youtube/GetYoutubeSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetYoutubeIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Youtube/GetYoutubeIslemler/");
 
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Youtube/GetYoutubeIslemler/");
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

        }
        /*Youtube*/

        /*DosyaYonetimi*/
        if (mode === "GetDosyaYonetimiModal") {
            $(buton).data('url', "/Admin/Admin/GetDosyaYonetimiModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("url", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetDosyaYonetimiCopy") {            
            $(buton).data('url', "/Admin/Admin/GetDosyaYonetimiCopy");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("post", "", buton, formData, function (result) {
                if (result.split("|")[0] === "Ok") {
               
                    alert_v1("Bilgi ", "<br>"+ result.split("|")[1], function () { });
                }
                else {
                    alert_v1("Hata ", result.split("|")[1], function () { });
                }
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetDosyaYonetimiSilModal") {
            $(buton).data('url', "/Admin/Admin/GetDosyaYonetimiSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function (result) {
                if (result.split("|")[0] === "Ok") {

                    location.href = "/Admin/Admin/FileManager";
                }
                else {
                    alert_v1("Hata ", result.split("|")[1], function () { });
                }
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetDosyaYonetimiIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/DosyaYonetimi/GetDosyaYonetimiIslemler/");

                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/DosyaYonetimi/GetDosyaYonetimiIslemler/");
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

        }
        /*DosyaYonetimi*/

        /*Sayfalar*/
        if (mode === "GetSayfalarModal") {
            $(buton).data('url', "/Admin/Sayfalar/GetSayfalarModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetSayfalarUpdateModal") {
            $(buton).data('url', "/Admin/Sayfalar/GetSayfalarUpdateModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetSayfalarSilModal") {
            $(buton).data('url', "/Admin/Sayfalar/GetSayfalarSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetSayfalarIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
  
            formData.append("type", $(buton).data("type"));
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Sayfalar/GetSayfalarIslemler/");
                var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
                formData.append("txtMetin_", txtMetin_);
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            
                            /*kendo_reload("#tblYazilar", "&kendotable.ust=" + result.split("|")[1] + "&kendotable.ust_="+result.split("|")[1]);*/

                            $('#mdl').modal('toggle');
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Sayfalar/GetSayfalarIslemler/");
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

        }
        /*Sayfalar*/

        /*FireKararlari*/
        if (mode === "GetFireKararlariModal") {
            $(buton).data('url', "/Admin/FireKararlari/GetFireKararlariModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetFireKararlariUpdateModal") {
            $(buton).data('url', "/Admin/FireKararlari/GetFireKararlariUpdateModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetFireKararlariSilModal") {
            $(buton).data('url', "/Admin/FireKararlari/GetFireKararlariSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetFireKararlariIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/FireKararlari/GetFireKararlariIslemler/");

                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }

            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/FireKararlari/GetFireKararlariIslemler/");
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

        }
        /*FireKararlari*/

        /*Baglantilar*/
        if (mode === "GetBaglantilarModal") {
            $(buton).data('url', "/Admin/Baglantilar/GetBaglantilarModal");

            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetBaglantilarUpdateModal") {
            $(buton).data('url', "/Admin/Baglantilar/GetBaglantilarUpdateModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetBaglantilarSilModal") {
            $(buton).data('url', "/Admin/Baglantilar/GetBaglantilarSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetBaglantilarIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));
            var KategoriAdi_ = $("#selectYaziTipi option:selected").text()
            formData.append("KategoriAdi", KategoriAdi_);
            if (type == "Kaydet") {
                $(buton).data('url', "/Admin/Baglantilar/GetBaglantilarIslemler/");
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }
            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Baglantilar/GetBaglantilarIslemler/");
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
        }
        /*Baglantilar*/


        /*Sunumlar*/
        if (mode === "GetSunumlarModal") {
            $(buton).data('url', "/Admin/Sunumlar/GetSunumlarModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetSunumlarUpdateModal") {
            $(buton).data('url', "/Admin/Sunumlar/GetSunumlarUpdateModal");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");

        }
        else if (mode === "GetSunumlarSilModal") {
            $(buton).data('url', "/Admin/Sunumlar/GetSunumlarSilModal/");
            formData.append("id", $(buton).data("id"));
            ButtonExecute("partial", "#", buton, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "GetSunumlarIslemler") {
            var type = $(buton).data("type");
            formData.append("id", $(buton).data("id"));
            formData.append("type", $(buton).data("type"));

            if (type == "Kaydet") {
                var txtMetin_ = CKEDITOR.instances.ckeditor.getData();
                formData.append("txtMetin_", txtMetin_);
                $(buton).data('url', "/Admin/Sunumlar/GetSunumlarIslemler/");
                if (FormValidate(buton)) {
                    ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                        if (result.split("|")[0] === "Ok") {
                            location.reload();
                        }
                        else {
                            alert_v1("Hata ", result.split("|")[1], function () { });
                        }
                    }, function () { }, "false", "");
                }
            }
            else if (type == "Sil") {
                $(buton).data('url', "/Admin/Sunumlar/GetSunumlarIslemler/");
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
        }
        /*Sunumlar*/


        if (mode === "Login") {
 
            $(buton).data('url', "/admin/admin/GetLoginForm");
            formData.append("ID", $(buton).data("data1"));

            ButtonExecute("post", "#mdlForm", buton, formData, function (result) {
                
                if (result.split("|")[0] === "Ok") {

                    window.location.href = '/admin/admin/yazilar';
 
                }
                else {
                    alert(result.split("|")[1]);

                }
                return false;
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