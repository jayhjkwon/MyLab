/// <reference path="Libs/jquery-1.7.2.js" />
/// <reference path="Libs/modernizr-2.5.3.js" />
/// <reference path="Libs/knockout.debug.js" />
/// <reference path="Libs/knockout.mapping-latest.debug.js" />
/// <reference path="Libs/sammy/sammy.js" />
/// <reference path="main.js" />
/// <reference path="common.js" />
/// <reference path="ViewModels/folderListVM.js" />
/// <reference path="ViewModels/patientListVM.js" />


ktc.namespace('ktc.router');
ktc.router.AppRouter = (function () {

    init = $.sammy(function () {
        this.get("", function () {
            console.log("default route page");
        });

        this.get('#/patient/:pid', function () {
            var pid = this.params.pid;
            ktc.vm.PatientListVM.loadPatientListById(pid, true);
            ktc.vm.FolderListVM.loadFolderList(pid);
        });
    }).run();

    return { init: init };

})();

$(function(){
    ktc.router.AppRouter.init;
});