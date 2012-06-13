/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />
/// <reference path="../Models/document.js" />
/// <reference path="../Data/documentData.js" />

ktc.namespace('ktc.vm');
ktc.vm.UploadDocumentVM = (function () {
    var self = this;

    isVisible = ko.observable(false);

    ktc.vm.TopMenuVM.patientNameForSearch.subscribe(function (name) {
        if (!name) {
            isVisible(false);
        }
    });

    return {
        isVisible: isVisible
    };

}());

$(function () {
    ko.applyBindings(ktc.vm.UploadDocumentVM, document.getElementById('body-pnr'));
});