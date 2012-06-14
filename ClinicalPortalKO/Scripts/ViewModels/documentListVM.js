﻿/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />
/// <reference path="../Models/document.js" />
/// <reference path="../Data/documentData.js" />

ktc.namespace('ktc.vm');
ktc.vm.DocumentListVM = (function (ktc) {
    var self = this;
    var isVisible = ko.observable(false),
    documentList = ko.observableArray(),

    loadDocumentList = function (pid) {
        ktc.data.document.getDocumentListByPid(pid, bindDocumentList);
    },

    bindDocumentList = function (documents) {
        documentList.removeAll();
        _.each(documents, function (f) {
            var document = new ktc.model.Document()
                                .patientId(f.PatientId)
                                .title(f.Title)
                                .url(f.Url)
                                .comments(f.Comments);
            documentList.push(document);
        });
    },

    onTitleClick = function (document) {
        ktc.vm.PatientListVM.test(document);    // demonstrate to call function in other ViewModels
    };

    ktc.vm.TopMenuVM.patientNameForSearch.subscribe(function (name) {
        if (!name) {
            documentList([]);
            isVisible(false);
        };
    });

    return {
        isVisible: isVisible
        , documentList: documentList
        , loadDocumentList: loadDocumentList
        , onTitleClick: onTitleClick
    };

} (ktc));

$(function () {
    ko.applyBindings(ktc.vm.DocumentListVM, document.getElementById('body-document-list'));
});