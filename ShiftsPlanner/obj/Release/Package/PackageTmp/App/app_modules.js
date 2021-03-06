﻿'use strict';
var app = angular.module('SchedulePlannerApp', ['ngRoute', 'satellizer', 'toastr', 'ui.bootstrap']);

app.config(['$routeProvider', '$locationProvider', '$authProvider', 'toastrConfig', function ($routeProvider, $locationProvider, $authProvider, toastrConfig) {

    $routeProvider.when('/schedule/',
        {
        templateUrl: 'App/Components/Schedule/schedule.html',
        controller: 'scheduleCtrl'
        
        });
    $routeProvider.when('/myShifts/',
        {
            templateUrl: 'App/Components/MyShifts/myShifts.html',
            controller: 'myShiftsCtrl'

        });
    $routeProvider.when('/contact/',
        {
            templateUrl: 'App/Components/Contact/contact.html',
            controller: 'contactCtrl'

        });
    $routeProvider.when('/login/',
        {
            templateUrl: 'App/Components/Login/login.html',
            controller: 'loginCtrl'

        });

    $locationProvider.hashPrefix('');

    angular.extend(toastrConfig,
        {
            positionClass: 'toast-top-right',
            newestOnTop: true,
            progressBar: true,
            allowHtml: true,
            closeButton: true,
            closeHtml: '<button><i class="fa fa-window-close" aria-hidden="true"></i></button>' 
        });

    $routeProvider.otherwise({ redirectTo: '/myShifts/' });
    $authProvider.google({
        clientId: '691632152904-atcn9vqtgt2hob288np3q61vurdam8nd.apps.googleusercontent.com',
        url: '/auth/google',
        authorizationEndpoint: 'https://accounts.google.com/o/oauth2/auth',
        redirectUri: 'http://localhost:49562/#/myShifts/',
        requiredUrlParams: ['scope'],
        optionalUrlParams: ['display'],
        scope: ['profile', 'email'],
        scopePrefix: 'openid',
        scopeDelimiter: ' ',
        display: 'popup',
        oauthType: '2.0',
        popupOptions: { width: 452, height: 633 }
    });

}]);
    //app.run(['authService', function (authService) {
    //    authService.fillAuthData();
    //}]);

    app.controller('mainCtrl', function ($rootScope, $scope, ajaxService, $http) {
        $rootScope.applicationName = "Shifts Planner";
        $rootScope.footerHidden = false;
    });

