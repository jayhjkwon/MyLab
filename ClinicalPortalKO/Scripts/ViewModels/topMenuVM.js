/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />

ktc.namespace('ktc.vm');
ktc.vm.TopMenuVM = (function () {
    var self = this;

    patientNameForSearch = ko.observable();

    return {
        patientNameForSearch : patientNameForSearch
    }

})();

$(function () {
    ko.applyBindings(ktc.vm.TopMenuVM, document.getElementById('top'));
});