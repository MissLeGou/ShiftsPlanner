﻿app.controller('loginCtrl', function ($scope, $auth) {

    $scope.authenticate = function (provider) {
        $auth.authenticate(provider);
    };

});