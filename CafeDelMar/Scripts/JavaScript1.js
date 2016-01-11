/// <reference path="jquery-2.1.4.intellisense.js" />
/// <reference path="jquery-2.1.4.min.js" />
function Task(name, price, quantity) {
    this.Name = ko.observable(name);
    this.Price = ko.observable(price);
}

function CartListViewModel() {
    // Data
    var self = this;
    self.tasks = ko.observableArray([]);

    // Operations
    self.addItem = function (name, price, event) {
        self.tasks.push(new Task(name, price));
    };

    self.save = function () {
        $.ajax("/Home/Order", {
            data: ko.toJSON({ fdList: self.tasks }),
            type: "post", contentType: "application/json",
            success: function (result) { alert(result) }
        });
    };

}

ko.applyBindings(new CartListViewModel());