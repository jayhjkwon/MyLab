/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />

ktc.namespace('ktc.model');

ktc.model.Document = function () {
    var self = this;

    self.patientId = ko.observable();
    self.comments = ko.observable();    
    self.title = ko.observable();
    self.url = ko.observable();
}