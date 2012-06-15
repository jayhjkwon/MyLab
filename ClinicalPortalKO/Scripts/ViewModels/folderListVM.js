/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />
/// <reference path="../Models/folder.js" />
/// <reference path="../Data/folderDataService.js" />
/// <reference path="topMenuVM.js" />

ktc.namespace('ktc.vm');
ktc.vm.folderListVM = (function (ktc) {
    var self = this;

    var isVisible = ko.observable(false),
    folderList = ko.observableArray(),

    loadFolderList = function (pid) {
        ktc.data.folderDataService.getFolderListByPid(pid, bindFolderList);
    },

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

    ktc.vm.topMenuVM.patientNameForSearch.subscribe(function (name) {
        if (!name) {
            folderList([]);
        }
    });

    

    return {
        isVisible: isVisible
        , folderList: folderList
        , loadFolderList: loadFolderList
    };

}(ktc));

$(function () {
    ko.applyBindings(ktc.vm.folderListVM, document.getElementById('left-folder-list'));
});