/// <reference path="../Libs/jquery-1.7.2.js" />
/// <reference path="../Libs/modernizr-2.5.3.js" />
/// <reference path="../Libs/knockout.debug.js" />
/// <reference path="../Libs/knockout.mapping-latest.debug.js" />
/// <reference path="../Libs/sammy/sammy.js" />
/// <reference path="../Libs/underscore.js" />
/// <reference path="../main.js" />
/// <reference path="../common.js" />


ktc.namespace('ktc.data');
ktc.data.documentDataService = (function () {
    var documentsJson = [{ "PatientId": "100", "Title": "CT - Right Head", "Comments": "aaaaaaaaaaaaaa", "Url":"a.jpg" }
            , { "PatientId": "100", "Title": "MRI - Knee", "Comments": "bbbbbbbbbbb", "Url": "b.jpg" }
            , { "PatientId": "100", "Title": "X-Ray - Left Hand", "Comments": "cccccccccccccc", "Url": "c.jpg" }
            , { "PatientId": "100", "Title": "CT - Breast", "Comments": "ddddddddddddd", "Url": "d.jpg" }
            , { "PatientId": "200", "Title": "CT - Breast", "Comments": "ffffffffffffff", "Url": "e.jpg" }
            , { "PatientId": "200", "Title": "X-Ray - Left Hand", "Comments": "ggggggggggg", "Url": "f.jpg" }
            ],

    getDocumentListByPid = function (pid, callback) {
        if (pid === '') {
            callback([]);
        } else {
            callback(_.filter(documentsJson, function (d) {
                return d.PatientId === pid;
            }));
        }
    };

    return {
        getDocumentListByPid: getDocumentListByPid
    };
})();