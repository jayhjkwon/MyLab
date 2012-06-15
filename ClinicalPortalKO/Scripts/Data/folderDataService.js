/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../Libs/underscore.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />


ktc.namespace('ktc.data');
ktc.data.folderDataService = (function () {
    var foldersJson = [{ "PatientId" : "100", "Title":"CT - Right Head", "LastUpdateTime":"2012-03-12" }
            ,{ "PatientId" : "100", "Title":"MRI - Knee", "LastUpdateTime":"2010-01-25" }
            ,{ "PatientId" : "100", "Title":"X-Ray - Left Hand", "LastUpdateTime":"2012-05-12" }
            ,{ "PatientId" : "100", "Title":"CT - Breast", "LastUpdateTime":"2012-06-12" }
            ,{ "PatientId" : "200", "Title":"CT - Breast", "LastUpdateTime":"2012-06-12" }
            ,{ "PatientId" : "200", "Title":"X-Ray - Left Hand", "LastUpdateTime":"2012-06-12" }
            ],

    getFolderListByPid = function (pid, callback) {
        if (pid === '') {
            callback([]);
        } else {
            callback(_.filter(foldersJson, function (f) {
                return f.PatientId === pid;
            }));
        }
    };

    return {
        getFolderListByPid: getFolderListByPid
    };
})();