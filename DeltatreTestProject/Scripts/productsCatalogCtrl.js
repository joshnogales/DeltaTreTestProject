(function () {
    'use strict';

    angular
        .module('app', [])
        .directive('productsCatalog', productsCatalog);

    function productsCatalog() {
        return {
            controller: productsCatalogCtrl,
            controllerAs: 'vm',
            templateUrl: '/Pages/catalog/list.html'
        }
    }

    productsCatalogCtrl.$inject = ['$scope','$timeout', 'productsCatalogService'];

    function productsCatalogCtrl($scope, $timeout, productsCatalogService) {
        /* jshint validthis:true */
        var vm = $scope;
        vm.version = null;
        vm.products = [];

        vm.inputProductName = "";
        vm.inputProductDescription = "";
        vm.inputProductQty = null;
        vm.hasLoaded = false;
        vm.submitClicked = false;
        vm.lastAddedName = null;
        vm.initialized = false;

        vm.submitNewProduct = function () {
            vm.submitClicked = true;
            if (vm.inputProductName.trim().length > 0 && vm.inputProductQty !== null) {
                addProduct();
            }
        }


        function checkVersion() {
            productsCatalogService.getVersion().then(function (response) {
                if (vm.version !== response.data) {
                    getProductsList();
                }
                else {
                    $timeout(checkVersion, 5000);
                }
            });
        }

        function resetNewFlag() {
            angular.forEach(vm.products, function (val) {
                 val.isNew = false;
            });
        }


        function getProductsList() {
            productsCatalogService.getProducts().then(function (response) {
                if (!!response.data.Products && !!response.data.ModifiedVersion) {
                    if (vm.initialized) /*Don't set flag for first load*/ {
                        angular.forEach(response.data.Products, function (val) {
                            var product = vm.products.find(function (p) { return p.Name == val.Name; });
                            if (!product)
                                val.isNew = true;
                        });
                    }
                    else
                        vm.initialized = true;
                    vm.products = response.data.Products;
                    vm.version = response.data.ModifiedVersion;
                    vm.hasLoaded = true;
                    $timeout(checkVersion, 3000);
                    $timeout(resetNewFlag, 2000);
                }
                else
                    console.log("Products data did not match expected format.");
            });
        }

        function addProduct() {
            var productData = {
                Name : vm.inputProductName,
                Description : vm.inputProductDescription,
                Quantity : vm.inputProductQty
            };
            productsCatalogService.addProduct(productData).then(function (response) {
                if (response.status == "200") {
                    getProductsList();
                    vm.lastAddedName = vm.inputProductName;
                }

                vm.submitClicked = false;
                vm.inputProductName = "";
                vm.inputProductDescription = "";
                vm.inputProductQty = null;

            }, function (response) {
                    if (response.status == "409")
                        vm.conflictName = vm.inputProductName;
            });
        }

        init();

        function init() {
            getProductsList();
        }
    }
})();
