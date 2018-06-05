app.controller('scheduleCtrl', function ($scope, ajaxService, toastr, $http, $location) {

    $scope.selectedMonth = false;
    $scope.selectedTab = false;
    $scope.year = "2018";
    $scope.month = "";
    $scope.today = new Date();
    $scope.selectedDataSet = null;
    $scope.events = [];

           
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

    $scope.getAllEvents = function () {
        var successGet = function (response) {
            console.log(response);
        };

        var failedGet = function (response) {

        };

        ajaxService.AjaxGet("api/shifts/get/addShifts", successGet, failedGet);
    }

    $scope.submitAddEvent = function (datum) {
        var dto = {
            ShiftID: $scope.newEvent.ShiftID,
            Location : $scope.newEvent.Location,
            FirstShift : $scope.newEvent.FirstShift,
            SecondShift : $scope.newEvent.SecondShift,  

        };

        var addDatumSucceeded = function (response) {
            $scope.events.push(response.data);
            toastr.success("Calendar Updated", "Update Succeeded", { timeOut: 1000, positionClass: 'toast-bottom-right' });
        }

        var addDatumFailed = function (response) {
            toastr.error("" + response.data, "Failed to Update ");
        }

        ajaxService.AjaxPost(dto, "api/shifts/add/addShifts", addDatumSucceeded, addDatumFailed);
    }

    $scope.submitDeleteEvent = function (datum, dataset) {
        var deleDatumSucceed = function (response) {

            toastr.success($scope.selectedDataSet + " Deleted", "Success");
        }

        var deleteDatumFailed = function (response) {
            toastr.error("" + response.data, "Failed to Delete ");
        }

        $scope.ok = function () {
            ajaxService.AjaxPost(datum, "api/shifts/delete/addShifts", deleDatumSucceed, deleteDatumFailed);
        }
    }

    $scope.cancel = function () {
        $scope.dt = '';
        $scope.newEvent.Location = '';
        $scope.newEvent.FirstShift = '';
        $scope.newEvent.SecondShift = '';
    }
});