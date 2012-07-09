var app = app || {};

app.user = (function () {
    var firstName = 'kwon';

    var getFirstName = function () {
        return firstName;
    };

    return { getFirstName: getFirstName };
})();