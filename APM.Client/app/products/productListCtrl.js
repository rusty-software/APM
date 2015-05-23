(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                     ["productResource", ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        vm.search = "GDN";

        productResource.query({search: vm.search}, function (data) {
            vm.products = data;
        });
    }
}());
