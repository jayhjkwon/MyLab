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
ktc.router.AppRouter = (function () {

    var init = $.sammy(function () {
        this.get("", function () {
            console.log("default route page");
        });

        this.get('#/patient/:pid', function () {
            var pid = this.params.pid;
            ktc.vm.PatientListVM.loadPatientListById(pid, true);
            ktc.vm.FolderListVM.loadFolderList(pid);
        });

        this.get('#/patient/folder/:pid', function () {
            var pid = this.params.pid;
            ktc.vm.PatientListVM.loadPatientListById(pid, true);
            ktc.vm.FolderListVM.loadFolderList(pid);
            ktc.vm.DocumentListVM.isVisible(true);
            ktc.vm.DocumentListVM.loadDocumentList(pid);
            ktc.vm.UploadDocumentVM.isVisible(false);
        });

        this.get('#/document/upload', function () {
            ktc.vm.DocumentListVM.isVisible(false);
            ktc.vm.UploadDocumentVM.isVisible(true);
        });
    }).run();

    return { init: init };

}());

$(function(){
    ktc.router.AppRouter.init;
});