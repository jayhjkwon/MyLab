define(['jQuery', 'knockout'], function (jQuery, ko) {

    return function appViewModel() {
        this.firstName = ko.observable('Bert');
        this.firstNameCaps = ko.computed(function () {
            return this.firstName().toUpperCase();
        }, this);
        this.names = ['khj', 'lsj'];
    }
});