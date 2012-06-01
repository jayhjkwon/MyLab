/// <reference path="lib/jquery-1.7.2.js" />
/// <reference path="lib/ember-0.9.8.1.js" />

var App = Em.Application.create();

App.MyView = Em.View.extend({
    tagName: 'div',
    templateName: 'hello',
    message: 'hello ember'
});

var myView = App.MyView.create();
