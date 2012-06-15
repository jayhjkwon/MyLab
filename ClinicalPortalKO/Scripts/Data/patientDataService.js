/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../Libs/underscore.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />


ktc.namespace('ktc.data');
ktc.data.patientDataService = (function () {
    var patientsJson = [{ "PatientId": "100", "FirstName": "Scott", "LastName": "Hanselman", "Gender": "Male", "DateOfBirth": "1980-04-24", "Phone": "000-0000-0000" },
            { "PatientId": "200", "FirstName": "Choi", "LastName": "Hongman", "Gender": "Male", "DateOfBirth": "1970-12-21", "Phone": "000-1111-1111" },
            { "PatientId": "300", "FirstName": "Jason", "LastName": "Mraz", "Gender": "Female", "DateOfBirth": "1978-05-21", "Phone": "000-2222-2222" },
            { "PatientId": "400", "FirstName": "Diego", "LastName": "Simpson", "Gender": "Female", "DateOfBirth": "1945-11-21", "Phone": "000-3333-3333" },
            { "PatientId": "500", "FirstName": "Michael", "LastName": "Carick", "Gender": "Male", "DateOfBirth": "1993-04-21", "Phone": "000-4444-4444"}],

    getPatientListById = function (pid, callback) {
        if (pid === '') {
            callback([]);
        } else {
            callback(_.filter(patientsJson, function (p) {
                return p.PatientId === pid;
            }));
        }
    },

    getPatientListByName = function (patientName, callback) {
        if (patientName === '') {
            callback([]);
        } else {
            callback(_.filter(patientsJson, function (p) {
                return p.FirstName.toUpperCase().indexOf(patientName.toUpperCase()) != -1 || p.LastName.toUpperCase().indexOf(patientName.toUpperCase()) != -1;
            }));
        }
    };

    return {
        getPatientListById: getPatientListById
        , getPatientListByName: getPatientListByName
    };
})();