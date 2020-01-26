(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('managerPerformanceController', managerPerformanceController);

    managerPerformanceController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function managerPerformanceController($scope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';

        onInit();

        function onInit() {

        }

        $scope.onManagerPerformanceSave = function () {
           
            iconHrService.invokeService('').forgotPassword(model).$promise.then(function (response) {
                   
                })
                .catch(function (error) {
                   
                });

        }

    }

})();