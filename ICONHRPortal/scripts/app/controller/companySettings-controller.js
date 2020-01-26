(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('companySettingsController', companySettingsController);

    companySettingsController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function companySettingsController($scope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.canIndustryAdd = false;
        $scope.industries = [
            //{ id: '1', text: 'IT' },
            //{ id: '2', text: 'Infrastructure' },
            //{ id: '3', text: 'Medical' }
        ];

        $scope.dateFormates = [
            { id: '1', text: 'dd/mm/yyyy' },
            { id: '2', text: 'mm/dd/yyyy' },
            { id: '3', text: 'yyyy/mm/dd' }
        ];
        $scope.currencys = [
            { id: '1', text: '$' },
            { id: '2', text: 'Rs' },
            { id: '3', text: 'Pound' }
        ];

        $scope.employeesAccess = [{ id: '1', text: 'View Team Event' }];

        $scope.companySetting =
            {
                CompanySettingID: 0,
                CompanyID: null,
                UploadLogo: null,
                ApplyThemeColour: null,
                CompanyStatement: null,
                Industry: null,
                DateFormat: null,
                BaseCurrency: null,
                NI_SSNValidation: null,
                Resetpassword: null,
                ProbationPeriod: null,
                PasswordExpiryDuration: null,
                SessionTimeOutPeriod: null,
                EmployeeAccessID: null,
                ManagerAccessID: null,
                CreatedDate: null,
                UpdateDate: null
            };
        var base64 = '';

        onInit();

        function onInit() {

            iconHrService.invokeService().getDepartmentNames().$promise.then(function (response) {
                $scope.industries = response;
                $scope.industries.push({ id: -1, text: '+ Add Industries' });
            });
            iconHrService.invokeService().getCompanyById().$promise.then(function (response) {

                $scope.companySetting = response;
                $scope.selectedIndustry = $scope.industries[0];
                if ($scope.dateFormates.filter(function (x) { return x.text == response.DateFormat }).length > 0)
                    $scope.selectedDateFormat = $scope.dateFormates.filter(function (x) { return x.text == response.DateFormat })[0];
                if ($scope.currencys.filter(function (x) { return x.text == response.BaseCurrency }).length > 0)
                    $scope.selectedCurrency = $scope.currencys.filter(function (x) { return x.text == response.BaseCurrency })[0];

                //setTimeout(function() {
                //    if ($scope.industries.filter(function(x) { return x.text == response.Industry }).length > 0)
                //        var industryCount = $scope.industries.filter(function(x) { return x.text == response.Industry }).length;
                //    $scope.selectedIndustry = $scope.industries[0];
                //}, 2000);
            });
        }

        $scope.onCompanySettingSave = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            $scope.companySetting.Industry = $scope.selectedIndustry !== undefined ? $scope.selectedIndustry.text : '';
            $scope.companySetting.DateFormat =
                $scope.selectedDateFormat !== undefined ? $scope.selectedDateFormat.text : '';
            $scope.companySetting.BaseCurrency =
                $scope.selectedCurrency !== undefined ? $scope.selectedCurrency.text : '';
            if ($scope.companySetting.Month == true) {
                $scope.companySetting.MonthOrWeek = "Months";
            }
            if ($scope.companySetting.Week == true) {
                $scope.companySetting.MonthOrWeek = "Weeks";
            }

            var reader = new FileReader();
            var selectedFile = document.querySelector('#txtCompanyLogo').files[0];
            if (selectedFile !== undefined) {
                reader.readAsDataURL(selectedFile);
                reader.onload = function () {
                    base64 = reader.result;
                    $scope.companySetting.UploadLogoBase64 = base64.replace('data:image/jpeg;base64,', '');
                    iconHrService.invokeService('').saveCompanySettings($scope.companySetting).$promise.then(
                        function (response) {
                            $scope.modalShown = true;
                            //clear fields
                        })
                        .catch(function (error) {
                            $scope.modalShown = true;
                            $scope.Message = "Insert Fail";
                        });

                };
                reader.onerror = function (error) {
                    console.log('Error: ', error);
                };
            } else {
                iconHrService.invokeService('').saveCompanySettings($scope.companySetting).$promise.then(
                    function (response) {
                        $scope.modalShown = true;
                    })
                    .catch(function (error) {
                        $scope.modalShown = true;
                        $scope.Message = "Insert Fail";
                    });

            }
        }

        $scope.onIndustryTypeChange = function (industryType) {
            if (industryType.id == -1) {
                $scope.canIndustryAdd = true;
            }
        };

        $scope.onIndustryTypeSave = function () {
            if ($scope.companySetting.industryType === '') {
                return;
            }
            var model = {
                DeptName: $scope.companySetting.industryType
            };
            iconHrService.invokeService('').SaveDepartment(model).$promise.then(function (response) {
                $scope.modalShown = true;
                iconHrService.invokeService().getDepartmentNames().$promise.then(function (response) {
                    $scope.industries = response;
                    $scope.industries.push({ id: -1, text: '+ Add Industries' });
                    $scope.canIndustryAdd = false;
                });
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });
        };

    }

})();