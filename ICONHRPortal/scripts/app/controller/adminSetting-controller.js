(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('adminSetting', adminSetting);

    adminSetting.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function adminSetting($scope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.AssignedEmployees = [];

        $scope.adminSetting = {
            AssignedEmployeeID: null
        };

        onInit();

        function onInit() {
            iconHrService.invokeService().getEmployeeOptions().$promise.then(function (response) {
                $scope.AssignedEmployees = response;
            });
            iconHrService.invokeService().getAdminSettings().$promise.then(function (response) {
                $scope.AdminDetails = response;
            });
        }

        $scope.onSaveAdminSetting = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            var model = {
                AssignedEmployeeID: $scope.selectedemployee.id
            }
            debugger;
            iconHrService.invokeService('').SaveAdminSetting(model).$promise.then(function (response) {
                iconHrService.invokeService().getAdminSettings().$promise.then(function (response) {
                    debugger;
                    $scope.AdminDetails = response;
                    $scope.modalShown = true;
                });
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    if (error.data.ExceptionMessage === "Already employee assigned as administrator")
                        $scope.Message = error.data.ExceptionMessage;
                    else
                        $scope.Message = error.data;

                });

        }

    }

})();