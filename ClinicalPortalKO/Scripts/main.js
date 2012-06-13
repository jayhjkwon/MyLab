/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />


/***********************************
* define root namespace
***********************************/
var ktc = ktc || {};


/***********************************
* define namespace utility function
*
* namespace() utility function's usage is as follow
*
*   ktc.namespace('ktc.model');
*   ktc.model.user = (function () {
*       var name = 'khj';
*       var getFullName = function () { return name; };
*       return { getFullName: getFullName };
*   })();
*
*   var n = ktc.model.user.getFullName();
*
***********************************/
ktc.namespace = function (namespaceString) {
    var parts = namespaceString.split('.'),
        parent = window,
        currentPart = '';

    for (var i = 0, length = parts.length; i < length; i++) {
        currentPart = parts[i];
        parent[currentPart] = parent[currentPart] || {};
        parent = parent[currentPart];
    }
}

