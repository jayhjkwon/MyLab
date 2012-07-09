function ViewModel() {
    var self = this;

    self.userNameToAdd = ko.observable("");

    self.addUser = function () {
        alert(self.userNameToAdd());
    };
};

ko.applyBindings(new ViewModel());
 
