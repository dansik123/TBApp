
(function () {
    'use strict';

    var zapApp = angular.module('zapApp', ['ngRoute']);

    var configFunction = function ($routeProvider, $locationProvider) {

        $routeProvider
            .when('/home', { templateUrl: '/Views/Home/Home.html', controller: 'homeCtrl' })
            .when('/login', { templateUrl: '/Views/User/Login.html', controller: 'loginCtrl' })
            .when('/register', { templateUrl: '/Views/User/Register.html', controller: 'registerCtrl' })
            .otherwise({ redirectTo: '/home' });

        $locationProvider.hashPrefix('!');
        $locationProvider.html5Mode(true);
    }
    configFunction.$inject = ['$routeProvider', '$locationProvider'];

    zapApp.config(configFunction);

})();