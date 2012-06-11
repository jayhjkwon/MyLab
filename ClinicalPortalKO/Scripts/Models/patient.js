/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />

ktc.namespace('ktc.model');

ktc.model.Patient = function () {
    var self = this;

    self.pid = ko.observable();
    self.firstName = ko.observable();
    self.lastName = ko.observable();
    self.gender = ko.observable();
    self.dateOfBirth = ko.observable();
    self.phone = ko.observable();
    self.address = ko.observable();
    self.fullName = ko.computed(function () {
        return self.firstName() + ' ' + self.lastName();
    });
};

