(function () {
    'use strict';
    var app= angular.module('zapApp');

    app.controller('registerCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.RegisterFormSubmit = function () {

            $http({
                method: 'POST',
                url: 'http://localhost:51084/api/User/Register',
                data: {
                    Username: $scope.username,
                    Password: $scope.password,
                    EmaiL: $scope.email
                }
            })
                .then(function (response) {
                    alert('IdUser: ' + response.data.UserId);
                    console.log(response.data);
                });
        };
    }]);
}());