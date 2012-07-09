/// <reference path="lib/require.js" />
/// <reference path="lib/knockout-2.1.0.debug.js" />


define(['jQuery', 'knockout', 'appViewModel'], function (jQuery, ko, appViewModel) {
    ko.applyBindings(new appViewModel("#names"));
});