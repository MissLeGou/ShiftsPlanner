app.controller('scheduleCtrl', function ($scope, ajaxService, $http, $location) {

    $scope.selectedMonth = false;
    $scope.year = "2018";
    $scope.month = "";
    $scope.today = new Date();

       
    $scope.getDays = function (data) {
        $scope.selectedMonth = data;
                   
        var successGet = function (response) {
            $scope.days = response.result;
            $scope.highlightToday = response.today;
            console.log(response);

        };

        var failedGet = function (response) {

        };

        ajaxService.AjaxGet("api/calendar/get/calendar?Year=" + $scope.year + "&Month=" + $scope.selectedMonth, successGet, failedGet);
        
    }
    
    $scope.isActive = function (data) {
        return $scope.selectedMonth === data;
    };

    //add event modal

    
    
});