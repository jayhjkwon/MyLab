﻿/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />
/// <reference path="../Models/patient.js" />
/// <reference path="../Data/patientData.js" />
/// <reference path="topMenuVM.js" />
/// <reference path="folderListVM.js" />
/// <reference path="documentListVM.js" />
/// <reference path="uploadDocumentVM.js" />

ktc.namespace('ktc.vm');
ktc.vm.PatientListVM = (function (ktc) {
    var self = this;

    var patientList = ko.observableArray(),

    loadPatientListById = function (pid) {
        ktc.data.patient.getPatientListById(pid, bindPatientList);
    },

    loadPatientListByName = function (name) {
        ktc.data.patient.getPatientListByName(name, bindPatientList);
    },

    bindPatientList = function (patients) {
        patientList.removeAll();
        _.each(patients, function (p) {
            patientList.push(new ktc.model.Patient()
                                        .pid(p.PatientId)
                                        .firstName(p.FirstName)
                                        .lastName(p.LastName)
                                        .address(p.Address)
                                        .dateOfBirth(p.DateOfBirth)
                                        .phone(p.Phone));
        });
    },

    test = function (doc) {
        alert(doc.title() + ' ' + doc.url() + ' ' + doc.comments());
    };

    ktc.vm.TopMenuVM.patientNameForSearch.subscribe(function (name) {
        loadPatientListByName(name);
    });

    return {
        patientList: patientList
        , loadPatientListById: loadPatientListById
        , loadPatientListByName: loadPatientListByName
        , test: test
    }

} (ktc));

$(function () {
    ko.applyBindings(ktc.vm.PatientListVM, document.getElementById('left-patient-list'));
});