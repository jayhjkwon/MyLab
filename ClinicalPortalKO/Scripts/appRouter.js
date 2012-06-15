/// <reference path="Libs/jquery-1.7.2.js" />
/// <reference path="Libs/modernizr-2.5.3.js" />
/// <reference path="Libs/knockout.debug.js" />
/// <reference path="Libs/knockout.mapping-latest.debug.js" />
/// <reference path="Libs/sammy/sammy.js" />
/// <reference path="main.js" />
/// <reference path="common.js" />
/// <reference path="ViewModels/folderListVM.js" />
/// <reference path="ViewModels/patientListVM.js" />
/// <reference path="ViewModels/documentListVM.js" />
/// <reference path="ViewModels/uploadDocumentVM.js" />


ktc.namespace('ktc.router');
ktc.router.appRouter = (function () {

    var init = $.sammy(function () {
        this.get("", function () {
            console.log("default route page");
        });

        this.get('#/patient/:pid', function () {
            var pid = this.params.pid;
            ktc.vm.patientListVM.loadPatientListById(pid, true);
            ktc.vm.folderListVM.loadFolderList(pid);
        });

        this.get('#/patient/folder/:pid', function () {
            var pid = this.params.pid;
            ktc.vm.patientListVM.loadPatientListById(pid, true);
            ktc.vm.folderListVM.loadFolderList(pid);
            ktc.vm.documentListVM.isVisible(true);
            ktc.vm.documentListVM.loadDocumentList(pid);
            ktc.vm.uploadDocumentVM.isVisible(false);
        });

        this.get('#/document/upload', function () {
            ktc.vm.documentListVM.isVisible(false);
            ktc.vm.uploadDocumentVM.isVisible(true);
        });
    }).run();

    return { init: init };

}());

$(function(){
    ktc.router.appRouter.init;
});