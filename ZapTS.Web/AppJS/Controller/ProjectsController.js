(function () {
    'use strict';
    var app = angular.module('zapApp');

    app.controller('projectsCtrl', ['$scope', '$http', function ($scope, $http) {
        var today = new Date();
        var dzien = today.getDate();
        $scope.data = today;


    }]);
}());