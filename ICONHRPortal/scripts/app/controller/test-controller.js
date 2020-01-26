(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('companySettingsController', companySettingsController);

    companySettingsController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function companySettingsController($scope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.onCompanySettingSave = onCompanySettingSave;

        onInit();

        function onInit() {

        }

        function onCompanySettingSave() {
           
            iconHrService.invokeService('').forgotPassword(model).$promise.then(function (response) {
                   
                })
                .catch(function (error) {
                   
                });

        }

    }

})();