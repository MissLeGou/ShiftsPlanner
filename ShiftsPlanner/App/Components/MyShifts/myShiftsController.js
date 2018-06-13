app.controller('myShiftsCtrl', function ($scope, ajaxService, toastr, $http, $location) {


    $scope.showAllAddedShifts = function () {

        var successGetShifts = function (response) {
            $scope.shifts = response;
            console.log(response);
        };

        var failedGetShifts = function (response) {

        };

        ajaxService.AjaxGet("api/shifts/get/addShifts", successGetShifts, failedGetShifts);

    }

    $scope.submitDeleteShift = function (ShiftID) {
        var deleDatumSucceed = function (response) {
            $scope.showAllAddedShifts();
            toastr.success("Shift Deleted");
        }

        var deleteDatumFailed = function (response) {
            toastr.error("" + response.data, "Failed to Delete ");
        }

        
        ajaxService.AjaxPost(ShiftID, "api/shifts/delete/addShifts", deleDatumSucceed, deleteDatumFailed);
            
     
    }


});