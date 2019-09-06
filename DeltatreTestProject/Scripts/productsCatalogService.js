(function () {
    'use strict';

    angular
        .module('app')
        .factory('productsCatalogService', productsCatalogService);

    productsCatalogService.$inject = ['$http'];

    function productsCatalogService($http) {
        var service = {
            getProducts : getProducts,
            addProduct: addProduct,
            getVersion: getVersion
        };

        return service;
        //use simple http call
        function getProducts() {
            return $http({
                method: 'GET',
                url: '/api/products'
            });
        }

        function addProduct(product) {
            return $http({
                method: 'POST',
                url: '/api/products',
                data: product
            });
        }

        function getVersion() {
            return $http({
                method: 'GET',
                url: '/api/products/status/version'
            });
        }
    }
})();