(function () {

    'use strict';
    
    angular.module('IconHRModule').controller('employeeSettingController', employeeSettingController);

    employeeSettingController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function employeeSettingController($scope, $window, iconHrService, helper) {
        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';

        $scope.employeeSetting =
        {
            EmployeeSettingsID: 0,
            CompanyID: 0,
            ManagerCanSeeEmployeeSalary: 0,
            EmployeeCanSeeTheirOwnSalary: 0,
            AllowEmployeeToUploadPhoto: 0,
            ManagerCanSeeEmployeeContactDetail: 0,
            
        };

        onInit();

        function onInit() {
            iconHrService.invokeService('').getEmployeeSetting($scope.employeeSetting.CompanyID).$promise
                .then(function (response) {
                    $scope.employeeSetting.EmailSettingsID = response.EmailSettingsID;
                    $scope.employeeSetting.CompanyID = response.CompanyID;
                    $scope.employeeSetting.AllowEmployeeToUploadPhoto = response.AllowEmployeeToUploadPhoto;
                    $scope.employeeSetting.ManagerCanSeeEmployeeSalary = response.ManagerCanSeeEmployeeSalary;
                    $scope.employeeSetting.EmployeeCanSeeTheirOwnSalary = response.EmployeeCanSeeTheirOwnSalary;
                    $scope.employeeSetting.ManagerCanSeeEmployeeContactDetail = response.ManagerCanSeeEmployeeContactDetail;


                });
        }


        $scope.employeeSettingClick = function() {
            iconHrService.invokeService('').saveEmployeeSetting($scope.employeeSetting).$promise.then(
                    function(response) {
                        $scope.modalShown = true;
                    })
                .catch(function(error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });
        };
    }

})();