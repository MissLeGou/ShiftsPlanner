app.factory('ajaxService', function ($http, $rootScope) {

    this.AjaxPost = function (data, route, successFunction, errorFunction) {
        
        return $http.post(route, data)
            .then(function (response, status, headers, config) {
                successFunction(response);
            },
            function (response) {
                errorFunction(response);
            });
    }


     this.AjaxGet = function (route, successFunction, errorFunction, headers) {
        return $http.get(route, {
            
        })
            .then(function (response, status, headers, config) {
                successFunction(response.data);
            },
            function (response) {
                errorFunction(response);
            });
    }


    this.AjaxGetWithPaging = function (route, successFunction, errorFunction, pageSize, index, searchTerm) {
        return $http.get(route, {
            params: {
                pageSize: pageSize,
                index: index,
                searchTerm: searchTerm
            }
        })
            .then(function (response, status, headers, config) {
                successFunction(response.data);

            },
            function (response) {
                errorFunction(response);
            });
    }

    return this;
})