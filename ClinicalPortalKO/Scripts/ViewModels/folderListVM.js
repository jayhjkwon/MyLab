/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />
/// <reference path="../Models/folder.js" />
/// <reference path="../Data/folderData.js" />
/// <reference path="topMenuVM.js" />

ktc.namespace('ktc.vm');
ktc.vm.FolderListVM = (function () {
    var self = this;

    isVisible: ko.observable(false);
    folderList = ko.observableArray();

    loadFolderList = function (pid) {
        ktc.data.folder.getFolderListByPid(pid, bindFolderList);
    };

    ktc.vm.TopMenuVM.patientNameForSearch.subscribe(function (name) {
        if (name === '') {
            folderList([]);
        }
    });

    bindFolderList = function (folders) {
        folderList.removeAll();
        _.each(folders, function (f) {
            var folder = new ktc.model.Folder();
            folder.patientId(f.PatientId);
            folder.title(f.Title);
            folder.lastUpdateTime(f.LastUpdateTime);
            folderList.push(folder);
        });
    };

    return {
        isVisible: isVisible
        , folderList: folderList
        , loadFolderList: loadFolderList
    };

})();

$(function () {
    ko.applyBindings(ktc.vm.FolderListVM, document.getElementById('left-folder-list'));
});