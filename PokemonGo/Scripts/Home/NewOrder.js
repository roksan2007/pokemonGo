angular.module("orderPokemonApp", [])
.constant("baseUrl",   window.location.protocol + "//" + window.location.host)
.controller("orderPokemonCtrl", function ($scope, $http, baseUrl) {
    $scope.showError = false;
    $scope.sendOrder = function (isValid) {
        if (isValid) {
            var config = {
                headers: {
                    "content-type": "application/json"
                },
                //data: { order: $scope.orderPokemon }
            }
            $http.post(baseUrl + "/Home/SendOrder", $scope.orderPokemon, config).success(function (response) {
                if (response.success) {
                    alert("Вы удачно заказали нового покемона!");
                    window.location.href = baseUrl + "/Home/Timeline";
                }
            });
        }
        else { $scope.showError = true }
    }
    $scope.getError = function (error) {
        if (angular.isDefined(error)) {
            if (error.required) {
                return "Поле не должно быть пустым";
            } if (error.email) {
                return "Введите праивльный email";
            }
            if (error.pattern) {
                return "Введите телефон в правильном формате. Пример +380502222222";
            }
        }
    }
});