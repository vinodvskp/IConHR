(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('holidayAbsenceSettingController', holidayAbsenceSettingController);

    holidayAbsenceSettingController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function holidayAbsenceSettingController($scope, $window, iconHrService, helper) {
        $scope.workPattern = null;
        $scope.holidayYear = null;
        $scope.publicHolidayTemplate = null;
        $scope.location = null;
        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.WorkPatterns = [];
        $scope.canLocationAdd = false;
        $scope.canWorkPatternAdd = false;
        $scope.locationName = '';

        $scope.holidayAbsenceSetting =
            {
                Holidays_AbsenceSettingID: 0,
                CompanyID: null,
                LocationID: null,
                NormalWorkingHours: null,
                DefaultWorkPatternID: null,
                FullTimeHours: null,
                MaximumDurationofConsecutiveAnnualLeave: null,
                MaxHolidayCarryOverDays: null,
                MaxHolidayCarryOverHours: null,
                HolidayYearID: null,
                DefaultPublicHolidayTemplateID: null,
                TotalHolidayEntitlementIncludePUblicHolidays: false,
                HolidayReturnToWorkForm: null,
                AuthoriseHolidaysFromEmail: null,
                LOSRuleID: null
            };

        onInit();

        function onInit() {

            iconHrService.invokeService().getLocations().$promise.then(function (response) {
                $scope.Locations = response;
                $scope.Locations.push({ id: -1, text: '+ Add Locations' });

            });

            iconHrService.invokeService().getWorkPatternOptions().$promise.then(function (response) {
                $scope.WorkPatterns = response;
                $scope.WorkPatterns.push({ id: -1, text: '+ Add Work Patterns' });

            });
            // TODO do we have only one time setting to upsert on single screen? then where need to display data
            // TODO if yes then how we manage different location on single page?
            iconHrService.invokeService().getHolidayAbsenceSetting().$promise.then(function (response) {
                $scope.holidayAbsenceSetting = response;
                $scope.location = $scope.Locations[response.LocationID - 1];
                $scope.workPattern = $scope.WorkPatterns[response.DefaultWorkPatternID - 1];
            });

        };

        $scope.onLocationChange = function (loc) {
            if (loc.id == -1) {
                $scope.canLocationAdd = true;
            }
        };

        $scope.onLocationSave = function () {
            if ($scope.holidayAbsenceSetting.locationName === '') {
                return;
            }

            var model = {

                Location: $scope.holidayAbsenceSetting.locationName
            };
            iconHrService.invokeService('').SaveLocations(model).$promise.then(function (response) {
                $scope.modalShown = true;
                iconHrService.invokeService().getLocations().$promise.then(function (response) {
                    $scope.Locations = response;
                    $scope.Locations.push({ id: -1, text: '+ Add Locations' });
                    $scope.canLocationAdd = false;
                });
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });
        };


        $scope.onWorkPatternChange = function (pattern) {
            if (pattern.id == -1) {
                $scope.canWorkPatternAdd = true;
            }
        };

        $scope.onWorkPatternSave = function () {
            if ($scope.holidayAbsenceSetting.workPatternName === '') {
                return;
            }
            var model = {
                WorkPatternName: $scope.holidayAbsenceSetting.workPatternName
            };
            iconHrService.invokeService('').SaveWorkPattern(model).$promise.then(function (response) {
                $scope.modalShown = true;
                iconHrService.invokeService().getWorkPatternOptions().$promise.then(function (response) {
                    $scope.WorkPatterns = response;
                    $scope.WorkPatterns.push({ id: -1, text: '+ Add Work Patterns' });
                    $scope.canWorkPatternAdd = false;
                });
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });
        };

        $scope.onHolidayAbsenceClick = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            if ($scope.location != undefined || $scope.location != null)
                $scope.holidayAbsenceSetting.LocationID = $scope.location.id;
            if ($scope.workPattern != undefined || $scope.workPattern != null)
                $scope.holidayAbsenceSetting.DefaultWorkPatternID = $scope.workPattern.id;
            $scope.holidayAbsenceSetting.HolidayYearID = $scope.holidayYear;
            $scope.holidayAbsenceSetting.DefaultPublicHolidayTemplateID = $scope.publicHolidayTemplate;
            iconHrService.invokeService('').saveHolidayAbsenceSetting($scope.holidayAbsenceSetting).$promise.then(function (response) {
                $scope.modalShown = true;
                $scope.Message = "Saved Successfully";
                $window.location.href = '/Settings';
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });
        }

    }

})();