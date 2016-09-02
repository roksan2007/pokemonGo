angular.module("TimelineApp", [])
.constant("baseUrl", window.location.protocol + "//" + window.location.host)
.controller("TimlineCtrl", function ($scope, $http, baseUrl) {
    $scope.getOrders = function () {
        var config = {
            headers: {
                "content-type": "application/json"
            },
        };
        $http.get(baseUrl + "/Home/GetOrders").success(function (response) {
            if (response.success) {
                $scope.orders = response.orders;
            }
        });
    }
    $scope.getOrders();

});