"use strict";
/*!
 * Extension for Select2 4.0.5
 * https://select2.github.io
 * 
 * Script file that uses default values that are used on most pages
 * 
 */
 
 if(jQuery().select2) {
     // only run if select2 plugin is loaded.

     $.fn.select2Unite = function (imageListUrl, showPreview, placeholderText, divImagePreview, divImage) {

         if (imageListUrl === null || imageListUrl === undefined || imageListUrl.length === 0) {
             throw new Error('imageListUrl empty or not defined');
         }

         var ele = this;
         var defaultPlaceholder = 'Click and Search for an image';

         $(ele).select2({
             ajax: {
                 url: imageListUrl,
                 type: "POST",
                 dataType: 'json',
                 delay: 250,
                 data: function (params) {
                     console.log(params);
                     return {
                         searchTerm: params.term, // search term
                         pageNumber: params.page,
                         VerticalId: $('#VerticalId').val()
                     };
                 },
                 processResults: function (data, params) {
                     params.page = params.page || 1;

                     return {
                         results: data.items,
                         pagination: { more: (params.page * 10) < data.total_count }
                     };
                 },
                 cache: true
             },
             placeholder: placeholderText || defaultPlaceholder,
             escapeMarkup: function (markup) { return markup; },
             minimumInputLength: 1,
             templateResult: formatResult,
             templateSelection: formatSelection
         });

         function formatResult(listData) {
             if (listData.loading) {
                 return listData.text;
             }

             return "<div class='row'>" +
                 "<div class='col-sm-3'><img class='img-thumbnail' style='max-width:100px; max-height:100px' src='" + listData.image + "' /></div>" +
                 "<div class='col-sm-9'><h5>" + listData.text + "</h5><h5>" + listData.code + "</h5></div></div>";
         }

         function formatSelection(listData) {
             return listData.text || listData.id;
         }

         $(ele).on('select2:select', function (e) {
             var data = e.params.data;

             var domImagePreview = 'SelectedImagePreview';
             var domImage = 'SelectedImage';

             if (divImagePreview != undefined)
                 domImagePreview = divImagePreview;

             if (divImage != undefined)
                 domImage = divImage;

             if (showPreview) {
                 $('#' + domImagePreview).show();
             }
             $('#' + domImage).attr("src", data.image);
         });
     };
 }