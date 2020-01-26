(function () {

    'use strict';
    
    angular.module('IconHRModule').controller('emailSettingController', emailSettingController);

    emailSettingController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function emailSettingController($scope, $window, iconHrService, helper) {
      
        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';

        $scope.emailSetting =
            {
                EmailSettingsID: 0,
                CompanyID: 0,
                DailyAdminEmail: null,
                WeeklyManagerEmail: null,
                HolidayEmailReminder: null,
                WeeklyEmployeeEmail: null,

            };

        onInit();

        function onInit() {

            iconHrService.invokeService('').getEmailSetting($scope.emailSetting.CompanyID).$promise
                .then(function (response) {
                    //$scope.emailSetting.EmailSettingsID = response.EmailSettingsID;
                    $scope.emailSetting.CompanyID = response.CompanyID;
                    $scope.emailSetting.DailyAdminEmail = response.DailyAdminEmail;
                    $scope.emailSetting.WeeklyManagerEmail = response.WeeklyManagerEmail;
                    $scope.emailSetting.WeeklyEmployeeEmail = response.WeeklyEmployeeEmail;
                    $scope.emailSetting.HolidayEmailReminder = response.HolidayEmailReminder;
                   

                });
        };

        $scope.emailSettingClick = function () {
            iconHrService.invokeService('').saveEmailSetting($scope.emailSetting).$promise.then(function (response) {
                $scope.modalShown = true;
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });
        }

    }

})();