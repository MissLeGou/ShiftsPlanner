app.controller('scheduleCtrl', function ($scope, ajaxService, toastr, $http, $location) {

    $scope.selectedMonth = false;
    $scope.selectedTab = false;
    $scope.year = "2018";
    $scope.month = "";
    $scope.today = new Date();
    $scope.selectedDataSet = null;
    $scope.events = [];
    $scope.booking = [];

           
    $scope.getDays = function (data) {

        if (data == null) {
            $scope.selectedMonth = new Date().getMonth() + 1;
            //angular.element('#activeMonth').addClass("active");
            console.log($scope.selectedMonth);
        } else {
            $scope.selectedMonth = data;
        }
                           
        var successGet = function (response) {
            $scope.days = response.result;
            $scope.highlightToday = response.today;
            console.log(response);

        };

        var failedGet = function (response) {

        };

        ajaxService.AjaxGet("api/calendar/get/calendar?Year=" + $scope.year + "&Month=" + $scope.selectedMonth, successGet, failedGet);

        var successGetShifts = function (response) {
            $scope.shifts = response;
            console.log(response);
        };

        var failedGetShifts = function (response) {

        };

        ajaxService.AjaxGet("api/shifts/get/addShifts", successGetShifts, failedGetShifts);
    }
    
    $scope.isActive = function (data) {
                        
        return $scope.selectedMonth === data;
       
    };

    //add event modal

    $scope.getAllEvents = function (day) {
        var events = $scope.shifts;
        var allEvents = false;
        angular.forEach(events, function (value, index) {
           
            if (value.ShiftDate === day.TimeStamp) {
                allEvents = true;
            }
        });
        return allEvents;
    };

    $scope.submitAddEvent = function (datum) {
        var dto = {
            ShiftID: null,
            ShiftDate: $scope.newEvent.ShiftDate,
            Location : $scope.newEvent.Location,
            FirstShift : $scope.newEvent.FirstShift,
            SecondShift: $scope.newEvent.SecondShift,
            ThirdShift: $scope.newEvent.ThirdShift

        };
        console.log(dto);

        var addDatumSucceeded = function (response) {
            $scope.events.push(response.data);
            toastr.success("Calendar Updated", "Update Succeeded", { timeOut: 1500, positionClass: 'toast-bottom-right' });
            $scope.newEvent.ShiftDate = '';
            $scope.newEvent.Location = '';
            $scope.newEvent.FirstShift = '';
            $scope.newEvent.SecondShift = '';
            $scope.newEvent.ThirdShift = '';
        }

        var addDatumFailed = function (response) {
            toastr.error("" + response.data, "Failed to Update ");
        }

        ajaxService.AjaxPost(dto, "api/shifts/add/addShifts", addDatumSucceeded, addDatumFailed);
    }

    $scope.cancel = function () {
        $scope.newEvent.ShiftDate = '';
        $scope.newEvent.Location = '';
        $scope.newEvent.FirstShift = '';
        $scope.newEvent.SecondShift = '';
        $scope.newEvent.ThirdShift = '';
    }

    //Book Event 

    $scope.displayShifts = function (TimeStamp) {

        var successGet = function (response) {
            $scope.shiftOnDay = response[0];
            console.log(response);

        };

        var failedGet = function (response) {

        };

        ajaxService.AjaxGet("api/shifts/get/bookedShifts?TimeStamp=" + TimeStamp, successGet, failedGet);
        console.log(TimeStamp);

    }

    $scope.bookShifts = function (datum) {
        var booking = {
            BookingID: null,
            BookingDate: $scope.newBooking.BookingDate,
            BookingLocation: $scope.newBooking.BookingLocation,
            BookingTime: $scope.newBooking.BookingTime,

        };
        console.log(booking);

        var addDatumSucceeded = function (response) {
            $scope.bookings.push(response.data);
            toastr.success("Shifts Booked", "Update Succeeded", { timeOut: 1500, positionClass: 'toast-bottom-right' });
            
            $scope.newBooking.BookingTime = '';
            
        }

        var addDatumFailed = function (response) {
            toastr.error("" + response.data, "Failed to Update ");
        }

        ajaxService.AjaxPost(booking, "api/shifts/add/addBookingShift", addDatumSucceeded, addDatumFailed);
    }

    $scope.cancelShift = function () {
        $scope.newBooking.BookingDate = '';
        $scope.newBooking.BookingLocation = '';
        $scope.newBooking.BookingTime = '';
       
    }
});