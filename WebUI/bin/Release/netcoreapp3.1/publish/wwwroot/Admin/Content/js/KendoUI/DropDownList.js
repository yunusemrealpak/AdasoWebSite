function parameter_init(contentId) {
    if (contentId == undefined || contentId == null) contentId = "body";
    else contentId = contentId;
    dict = "";
    $(contentId).find('[data-select="true"]').each(function (index, tr) {
        template = $(this);
        id = $(this).data("id");
        name = $(this).data("name");
        page_count = $(this).data("page_count");
        page_count = page_count == undefined || page_count == null ? 50 : page_count;
        groupkod = $(this).data("groupkod");
        anagrupkod = $(this).data("anagrupkod");
        selected_id = $(this).data("selected_id");
        selected_kod = $(this).data("selected_kod");
        class_ = $(this).data("class");
        relation = $(this).data("relation");
        filter_ = $(this).data("filter");
        style = $(this).data("style");
        placeholder = $(this).data("placeholder");
        placeholder = placeholder == undefined || placeholder == null ? "Seçiniz" : placeholder;
        disabled = $(this).data("disabled");
        multiple = $(this).data("multiple");
        multiple = multiple == undefined || multiple == null ? "" : 'multiple="multiple"';
        min_length = $(this).data("min-length");
        min_length = min_length == undefined || min_length == null ? "0" : min_length;
        var sehir = "<select " + multiple + " class=\"" + class_ + "\" id=\"" + id + "\" name=\"" + name + "\" data-min-length=\"" + min_length + "\" data-groupkod=\"" + groupkod + "\" data-relation=\"" + relation + "\" data-filter=\"" + filter_ + "\" style=\"" + style + "z-index=2;\" data-placeholder=\"" + placeholder + "\">";
        sehir += "<option></option>";
        sehir += "</select>";
        $(template).html(sehir);


        if (!(selected_id == undefined || selected_id == null)) {
            if (selected_id.toString().length != selected_id.toString().replace(",", "").length) {
                $.each(selected_id.split(','), function (key, value) {
                    $.ajax({
                        url: "/Admin/DropDown/GetirFiltre?id=" + value + "&grupKod=" + groupkod + "&AnaGrupKod=" + (anagrupkod == undefined || anagrupkod == null ? -1 : anagrupkod) + "&Sorgu=" + (filter_ == undefined || filter_ == null ? "" : filter_) + "&Adet=" + page_count,
                        async: false
                    }).done(function (dataSelectedItem) {
                        if (dataSelectedItem != undefined && dataSelectedItem != null && dataSelectedItem.results.length != 0 && selected_id != null && selected_id != '' && selected_id != undefined) {
                            dataSelectedItemId = (dataSelectedItem.results[0]).id;
                            dataSelectedItemText = (dataSelectedItem.results[0]).text;
                            dataSelectedItemKod = (dataSelectedItem.results[0]).kod;
                            var data = {
                                id: dataSelectedItemId,
                                text: dataSelectedItemText
                            };

                            var newOption = new Option(dataSelectedItemText, dataSelectedItemId, true, true);
                            $(newOption).data("kod", dataSelectedItemKod);
                            $('#' + id).append(newOption);


                            $('[data-relation="#' + id + '"]').data("anagrupkod", dataSelectedItemKod);
                        }
                    });
                });
            }
            else {
                $.ajax({
                    url: "/Admin/DropDown/GetirFiltre?id=" + selected_id + "&grupKod=" + groupkod + "&AnaGrupKod=" + (anagrupkod == undefined || anagrupkod == null ? -1 : anagrupkod) + "&Sorgu=" + (filter_ == undefined || filter_ == null ? "" : filter_) + "&Adet=" + page_count,
                    async: false
                }).done(function (dataSelectedItem) {
                    if (dataSelectedItem != undefined && dataSelectedItem != null && dataSelectedItem.results.length != 0 && selected_id != null && selected_id != '' && selected_id != undefined) {
                        dataSelectedItemId = (dataSelectedItem.results[0]).id;
                        dataSelectedItemText = (dataSelectedItem.results[0]).text;
                        dataSelectedItemKod = (dataSelectedItem.results[0]).kod;
                        var data = {
                            id: dataSelectedItemId,
                            text: dataSelectedItemText
                        };

                        var newOption = new Option(dataSelectedItemText, dataSelectedItemId, true, true);
                        $(newOption).data("kod", dataSelectedItemKod);
                        $('#' + id).append(newOption);


                        $('[data-relation="#' + id + '"]').data("anagrupkod", dataSelectedItemKod);
                    }
                });
            }

        }
        else if (!(selected_kod == undefined || selected_kod == null)) {
            $.ajax({
                url: "/Admin/DropDown/GetirFiltre?id=0&kod=" + selected_kod + "&grupKod=" + groupkod + "&AnaGrupKod=" + (anagrupkod == undefined || anagrupkod == null ? -1 : anagrupkod) + "&Sorgu=" + (filter_ == undefined || filter_ == null ? "" : filter_) + "&Adet=" + page_count,
                async: false
            }).done(function (dataSelectedItem) {
                if (dataSelectedItem != undefined && dataSelectedItem != null && dataSelectedItem.results.length != 0) {
                    dataSelectedItemId = (dataSelectedItem.results[0]).id;
                    dataSelectedItemText = (dataSelectedItem.results[0]).text;
                    dataSelectedItemKod = (dataSelectedItem.results[0]).kod;
                    var data = {
                        id: dataSelectedItemId,
                        text: dataSelectedItemText
                    };

                    var newOption = new Option(dataSelectedItemText, dataSelectedItemId, true, true);
                    $(newOption).data("kod", dataSelectedItemKod);
                    $('#' + id).append(newOption);


                    $('[data-relation="#' + id + '"]').data("anagrupkod", dataSelectedItemKod);
                }
            });
        }


        if ((relation != undefined || relation != null) && dict.indexOf(relation) == -1) {
            $('body').on('change', relation, function () {
                _template = $(this);
                _id = $(_template).attr("id");
                _name = $(_template).attr("name");
                _groupkod = $(_template).data("groupkod");
                _class_ = $(_template).data("class");
                _relation = $(_template).data("relation");
                $('select[data-relation="#' + _id + '"]').each(function (index, tr) {
                    __template = $(this);
                    __id = $(__template).attr("id");
                    __name = $(__template).attr("name");
                    __groupkod = $(__template).data("groupkod");
                    __selected_id = $(__template).data("selected_id");
                    __class_ = $(__template).data("class");
                    __relation = $(__template).data("relation");
                    __filter_ = $(__template).data("filter");
                    __style = $(__template).attr("style");
                    __placeholder = $(__template).data("placeholder");
                    __placeholder = __placeholder == undefined || __placeholder == null ? "Seçiniz" : __placeholder;
                    __page_count = $(this).data("page_count");
                    __page_count = __page_count == undefined || page_count == null ? 50 : __page_count;
                    __multiple = $(this).data("multiple");
                    __multiple = __multiple == undefined || __multiple == null ? "" : 'multiple="multiple"';
                    __min_length = $(this).data("min-length");
                    __min_length = __min_length == undefined || __min_length == null ? "0" : __min_length;
                    var sehir__ = "<select " + __multiple + " class=\"" + __class_ + "\" id=\"" + __id + "\" name=\"" + __name + "\"  data-min-length=\"" + min_length + "\"  data-groupkod=\"" + __groupkod + "\" data-relation=\"" + __relation + "\" data-filter=\"" + __filter_ + "\" style=\"" + __style + "z-index=2;\" data-page_count=\"" + __page_count + "\" data-placeholder=\"" + __placeholder + "\">";
                    sehir__ += "<option></option>";
                    sehir__ += "</select>";
                    $('#' + __id).html(sehir__);

                    $('#' + __id).select2({
                        minimumInputLength: __min_length,
                        dropdownParent: $(contentId),
                        minimumResultsForSearch: 20,
                        allowClear: true,
                        style: style,
                        language: {
                            searching: function () {
                                return "İçerik aranıyor...";
                            },
                            loadingMore: function () {
                                return "Daha fazlası yükleniyor...";
                            }
                        },
                        ajax: {
                            url: "/Admin/DropDown/GetirFiltre?grupKod=" + __groupkod + "&AnaGrupKod=" + $(_template).find(':selected').data("kod") + "&Sorgu=" + (__filter_ == undefined || __filter_ == null ? "" : __filter_) + "&Adet=" + __page_count,
                            dataType: 'json',
                            type: "GET",
                            quietMillis: 50,
                            data: function (params) {
                                var query = {
                                    arama: params.term,
                                    type: 'public',
                                    sayfa: params.page || 0
                                }
                                return query;
                            },
                            processResults: function (data, params) {
                                params.page = params.page || 1;

                                return {
                                    results: data.results,
                                    pagination: data.pagination
                                };
                                cache: false
                            },
                        },
                        escapeMarkup: function (markup) {
                            return markup;
                        },
                        templateResult: format,
                        templateSelection: function (option) {
                            $(option.element).attr('data-kod', option.kod);
                            return option.text
                        },
                        escapeMarkup: function (m) {
                            return m;
                        }
                    });
                });
            });
        }
        //});


        dict += relation;

        function format(option) {
            var $result = "";

            if (option.icon == undefined || option.icon == null) {
                $result = option.text;
            }
            else {
                $result = $(
                    '<table><tr><td rowspan="2"><img src="' + option.icon + '" width="50"/></td><td style="vertical-align: bottom;">' + option.text + '</td></tr><tr><td style="font-size:10px;vertical-align: top;">' + option.unvan + '</td></tr></table>'
                );
            }
            return $result;
        };


        $('#' + id).select2({
            minimumInputLength: min_length,
            dropdownParent: $(contentId),
            minimumResultsForSearch: 20,
            allowClear: true,
            style: style,
            language: {
                searching: function () {
                    return "İçerik aranıyor...";
                },
                loadingMore: function () {
                    return "Daha fazlası yükleniyor...";
                }
            },
            ajax: {
                url: "/Admin/DropDown/GetirFiltre?grupKod=" + groupkod + "&AnaGrupKod=" + (anagrupkod == undefined || anagrupkod == null ? 0 : anagrupkod) + "&Sorgu=" + (filter_ == undefined || filter_ == null ? "" : filter_) + "&Adet=" + page_count,
                dataType: 'json',
                type: "GET",
                quietMillis: 50,
                data: function (params) {
                    var query = {
                        arama: params.term,
                        type: 'public',
                        sayfa: params.page || 0
                    }
                    return query;
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;

                    return {
                        results: data.results,
                        pagination: data.pagination
                    };
                    cache: false
                },
            },
            escapeMarkup: function (markup) {
                return markup;
            },
            templateResult: format,
            templateSelection: function (option) {
                $(option.element).attr('data-kod', option.kod);
                return option.text
            },
            escapeMarkup: function (m) {
                return m;
            }
        });

        $('#' + id).prop("disabled", disabled);
    });
}


function set(element, id, kod) {
    $.ajax({
        url: "/Admin/DropDown/GetirFiltre?id=" + id + "&grupKod=" + kod + "&AnaGrupKod=0&Sorgu=",
        async: false
    }).done(function (dataSelectedItem) {
        if (dataSelectedItem != undefined && dataSelectedItem != null && dataSelectedItem.results.length != 0) {
            dataSelectedItemId = (dataSelectedItem.results[0]).id;
            dataSelectedItemText = (dataSelectedItem.results[0]).text;
            dataSelectedItemKod = (dataSelectedItem.results[0]).kod;

            var data = {
                id: dataSelectedItemId,
                text: dataSelectedItemText
            };

            var newOption = new Option(dataSelectedItemText, dataSelectedItemId, true, true);
            $(newOption).data("kod", dataSelectedItemKod);
            $(element).append(newOption).trigger('change');
        }
    });
}