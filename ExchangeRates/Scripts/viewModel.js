var RatesViewModel = function () {

    var self = this;
    this.currencyData = ko.observableArray([]);

    this.getRates = function () {
        $.getJSON('/api/rates').then(function (data) {
            console.log(data);
            self.currencyData(data);
        });
    }
};