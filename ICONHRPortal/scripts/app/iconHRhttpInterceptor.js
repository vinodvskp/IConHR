(function () {
    "use strict";
    angular
        .module("IconHRModule")
        .factory("iconHRHttpInterceptor", iconHRHttpInterceptor);

    iconHRHttpInterceptor.$inject = ["$q", "$rootScope", "$log"];
    function iconHRHttpInterceptor($q, $rootScope, $log) {

        var numLoadings = 0;

        return {
            request: function (config) {
                numLoadings++;

                if (config.url.match('api/employeeApi/GetNotificaitons') != null && config.url.match('api/employeeApi/GetNotificaitons').length > 0) {
                    return config || $q.when(config);
                }

                // Show loader
                $rootScope.$broadcast("loader_show");
                return config || $q.when(config);


            },
            response: function (response) {

                if ((--numLoadings) === 0) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }

                return response || $q.when(response);

            },
            responseError: function (response) {

                if (!(--numLoadings)) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }

                return $q.reject(response);
            }

        };

    }
})();