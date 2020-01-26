

    (function () {

        'use strict';

        angular.module('IconHRModule')
            .controller('authorisationrulesettingController', authorisationrulesettingController);

        authorisationrulesettingController.$inject = ['$scope', '$rootScope', '$window', '$filter', 'iconHrService', 'helper', 'Upload'];


        function authorisationrulesettingController($scope, $rootScope, $window, $filter, iconHrService, helper, Upload) {

            $scope.AuthorisationRuleSettingsList = [];
            $scope.empId = 0;
            $scope.Locations = [];
            $scope.ReportingMangers = [];
            $scope.EmployeeList = [];
            onInit();
            clear();
            getAuthorisationRuleDetails();
            function clear() {
                $scope.AuthorisationRuleSettingsDetail = {
                    AuthorisationRuleSettingsID: '',
                    CompanyID: '',
                    LocationID: '',
                    LocationName: '',
                    DepartmentID: '',
                    DepartmentName: '',
                    JobRoleID: '',
                    JobRoleName: '',
                    EmploymentTypeID: '',
                    EmploymentTypeName: '',
                    SpecificEmployeeID: '',
                    SpecificEmployeeName: '',
                    ExcludeEmployeeID: '',
                    ExcludeEmployeeName: '',
                    ApproverID: '',
                    ApproverName: ''
                };
            }
            function onInit() {

            iconHrService.invokeService('').getEmployees().$promise
                .then(function (response) {
                    $scope.EmployeeList = response;
                });
            iconHrService.invokeService('').getLocations().$promise
                .then(function (response) {
                    $scope.Locations = response;
                });
            iconHrService.invokeService('').getAdminManagerNames().$promise
                .then(function (response) {
                    $scope.ReportingMangers = response;
                });
        }
        $scope.updateRule = function (item) {
            clear();
            $scope.AuthorisationRuleSettingsDetail = item;
            jQuery('#ddlLocation').val('').trigger('chosen:updated');
            jQuery('#ddlDept').val($scope.AuthorisationRuleSettingsDetail.DepartmentID.split(",")).trigger('chosen:updated');
            jQuery('#ddlJobRole').val('').trigger('chosen:updated');
            jQuery('#ddlEmployeeType').val('').trigger('chosen:updated');
            jQuery('#ddlSpecificEmployee').val('').trigger('chosen:updated');
            jQuery('#ddlExcludedEmployee').val('').trigger('chosen:updated');
        };
        $scope.getRuleDetails = function () {
          //  onInit();
            clear();
            jQuery("#ddlLocation").chosen({
                no_results_text: "Oops, nothing found!"
            });
            jQuery("#ddlDept").chosen({
                no_results_text: "Oops, nothing found!"
            });
            jQuery("#ddlJobRole").chosen({
                no_results_text: "Oops, nothing found!"
            });
            jQuery("#ddlEmployeeType").chosen({
                no_results_text: "Oops, nothing found!"
            });
            jQuery("#ddlSpecificEmployee").chosen({
                no_results_text: "Oops, nothing found!"
            });
            jQuery("#ddlExcludedEmployee").chosen({
                no_results_text: "Oops, nothing found!"
            });
            jQuery('#ddlLocation').val('').trigger('chosen:updated');
            jQuery('#ddlDept').val('').trigger('chosen:updated');
            jQuery('#ddlJobRole').val('').trigger('chosen:updated');
            jQuery('#ddlEmployeeType').val('').trigger('chosen:updated');
            jQuery('#ddlSpecificEmployee').val('').trigger('chosen:updated');
            jQuery('#ddlExcludedEmployee').val('').trigger('chosen:updated');
            jQuery('#authorization-modal').modal('show');
            //jQuery("#ddlApproverEmployee").chosen({
            //    no_results_text: "Oops, nothing found!"
            //});
        };
        function getAuthorisationRuleDetails() {
            iconHrService.invokeService('').getAuthorisationRuleDetails().$promise
                .then(function (response) {
                    $scope.AuthorisationRuleSettingsList = response;
                });
           
        }
        function removeLastComma(str) {
            return str.replace(/,(\s+)?$/, '');
        }
        //jQuery('#ddlJobRole').on('change', function (e, params) {
        //    alert(e.target.value); // OR
        //    alert(this.value); // OR
        //    alert(params.selected); // also in Panagiotis Kousaris' answer
        //    //jQuery("#ddlJobRole").chosen().find("option:selected").text();
        //});
            $scope.saveRule = function (myForm) {
                if (!myForm.$valid) {
                    // alert('Enter valid data in all required fields');
                    return;
                }
            //jQuery("#ddlJobRole").chosen().val();
            jQuery('#ddlLocation option:selected').each(function (index, valor) {
                    $scope.AuthorisationRuleSettingsDetail.LocationID += valor.value+',';
                    $scope.AuthorisationRuleSettingsDetail.LocationName += valor.innerText+',';
            });
            $scope.AuthorisationRuleSettingsDetail.LocationID = removeLastComma($scope.AuthorisationRuleSettingsDetail.LocationID);
            $scope.AuthorisationRuleSettingsDetail.LocationName = removeLastComma($scope.AuthorisationRuleSettingsDetail.LocationName);
            jQuery('#ddlDept option:selected').each(function (index, valor) {
                $scope.AuthorisationRuleSettingsDetail.DepartmentID += valor.value + ',';
                $scope.AuthorisationRuleSettingsDetail.DepartmentName += valor.innerText + ',';
            });
            $scope.AuthorisationRuleSettingsDetail.DepartmentID = removeLastComma($scope.AuthorisationRuleSettingsDetail.DepartmentID);
            $scope.AuthorisationRuleSettingsDetail.DepartmentName = removeLastComma($scope.AuthorisationRuleSettingsDetail.DepartmentName);
            jQuery('#ddlJobRole option:selected').each(function (index, valor) {
                $scope.AuthorisationRuleSettingsDetail.JobRoleID += valor.value + ',';
                $scope.AuthorisationRuleSettingsDetail.JobRoleName += valor.innerText + ',';
            });
            $scope.AuthorisationRuleSettingsDetail.JobRoleID = removeLastComma($scope.AuthorisationRuleSettingsDetail.JobRoleID);
            $scope.AuthorisationRuleSettingsDetail.JobRoleName = removeLastComma($scope.AuthorisationRuleSettingsDetail.JobRoleName);

            jQuery('#ddlEmployeeType option:selected').each(function (index, valor) {
                $scope.AuthorisationRuleSettingsDetail.EmploymentTypeID += valor.value + ',';
                $scope.AuthorisationRuleSettingsDetail.EmploymentTypeName += valor.innerText + ',';
            });
            $scope.AuthorisationRuleSettingsDetail.EmploymentTypeID = removeLastComma($scope.AuthorisationRuleSettingsDetail.EmploymentTypeID);
            $scope.AuthorisationRuleSettingsDetail.EmploymentTypeName = removeLastComma($scope.AuthorisationRuleSettingsDetail.EmploymentTypeName);

            $scope.AuthorisationRuleSettingsDetail.SpecificEmployeeID = '';
            jQuery('#ddlSpecificEmployee option:selected').each(function (index, valor) {
                debugger;
                $scope.AuthorisationRuleSettingsDetail.SpecificEmployeeID += valor.value + ',';
                $scope.AuthorisationRuleSettingsDetail.SpecificEmployeeName += valor.innerText + ',';
            });
            $scope.AuthorisationRuleSettingsDetail.SpecificEmployeeID = removeLastComma($scope.AuthorisationRuleSettingsDetail.SpecificEmployeeID);
            $scope.AuthorisationRuleSettingsDetail.SpecificEmployeeName = removeLastComma($scope.AuthorisationRuleSettingsDetail.SpecificEmployeeName);

            $scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeID = '';
            jQuery('#ddlExcludedEmployee option:selected').each(function (index, valor) {
                $scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeID += valor.value + ',';
                $scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeName += valor.innerText + ',';
            });
            $scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeID = removeLastComma($scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeID);
            $scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeName = removeLastComma($scope.AuthorisationRuleSettingsDetail.ExcludeEmployeeName);
            if (jQuery('#ddlApproverEmployee').val() !== '') {
                $scope.AuthorisationRuleSettingsDetail.ApproverID = jQuery('#ddlApproverEmployee').val();
                $scope.AuthorisationRuleSettingsDetail.ApproverName = jQuery('#ddlApproverEmployee option:selected').text();
            }
            //jQuery('#ddlJobRole option:selected').each(function (index, valor) {
            //    $scope.AuthorisationRuleSettingsDetail.JobRoleID += valor.value + ',';
            //    $scope.AuthorisationRuleSettingsDetail.JobRoleName += valor.innerText + ',';
            //});

        //    alert($scope.AuthorisationRuleSettingsDetail.JobRoleID);
            iconHrService.invokeService('').saveRule($scope.AuthorisationRuleSettingsDetail).$promise
                .then(function (response) {
                    if ($scope.AuthorisationRuleSettingsDetail.AuthorisationRuleSettingsID == 0)
                        alert(jQuery("Record saved successfully"));
                    else
                        alert(jQuery("Record updated successfully"));
                    jQuery('#authorization-modal').modal('toggle');
                    getAuthorisationRuleDetails();
                });
        };
    }

    })();
