(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                     ["productResource", ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        vm.searchCrtieria = "GDN";
        vm.sortBy = "Price";
        vm.sortDir = "desc";

        productResource.query(
            {
                $filter: "contains(ProductCode, '" + vm.searchCrtieria + "') or contains(ProductName, '" + vm.searchCrtieria + "')",
                $orderby: vm.sortBy + " " + vm.sortDir
            },
            function (data) {
                vm.products = data;
            });
    }
}());
