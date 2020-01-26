(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('performanceReviewSettingController', performanceReviewSettingController);

    performanceReviewSettingController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function performanceReviewSettingController($scope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.PerformanceDetails = [];
        $scope.Ratings = [];
        $scope.showRating = false;
        $scope.selectedEmploymentType = {};
        $scope.Questions = [];
        $scope.questionActiveTab = false;
        $scope.segmentsActiveTab = true;
        $scope.Segments = [];
        $scope.segment = { SegmentName: '', SegmentDescription: '', tblPerformaceSegmentQuestions: $scope.Questions };
        $scope.ReviewSettingCopy = [];
        $scope.hasEdit = false;

        $scope.EmploymentTypes = [
            //{ id: 1, text: 'Casual' },
            //{ id: 2, text: 'Contractor' },
            //{ id: 3, text: 'Fixed Term' },
            //{ id: 4, text: 'Full Time' },
            //{ id: 5, text: 'Part Time' },
            //{ id: 6, text: 'Temporary' }
        ];

        $scope.performance = {
            PerformanceReviewID: 0,
            ReviewTitle: '',
            ReviewCompletionDate: null,
            CompanyID: null,
            LocationID: null,
            DepartmentID: null,
            JobRoleID: null,
            EmploymentTypeID: null,
            LengthOfService: null,
            OverallScoreID: null,
            SegmentID: null,
            tblPerformanceSegments: $scope.Segments,
            tblPerformanceScores: []
        };

        $scope.question = {
            Question: '',
            HelpText: ''
        }

        onInit();

        function onInit() {

            iconHrService.invokeService().getLocations().$promise.then(function (response) {
                $scope.Locations = response;
                $scope.Locations.push({ id: -1, text: 'Select Location' });
            });
            iconHrService.invokeService().getDepartmentNames().$promise.then(function (response) {
                $scope.Departments = response;
                $scope.Departments.push({ id: -1, text: 'Select Department' });
            });
            iconHrService.invokeService().getJobRolesOption().$promise.then(function (response) {
                $scope.JobRoles = response;
                $scope.JobRoles.push({ id: -1, text: 'Select Job Role' });
            });

            iconHrService.invokeService().getEmployementTypes().$promise.then(function (response) {
                $scope.EmploymentTypes = response;
                $scope.EmploymentTypes.push({ id: -1, text: 'Select Employement Type' });
            });

            for (var i = 0; i < 3; i++) {
                $scope.Ratings.push({ RatingValue: '', RatingDescription: '' });
            };
            iconHrService.invokeService('').getReviewSettings().$promise.then(function (response) {
                $scope.PerformanceDetails = response;

                angular.forEach($scope.PerformanceDetails,
                    function (value, key) {
                        $scope.ReviewSettingCopy.push({ id: value.PerformanceReviewID, text: value.ReviewTitle });
                    });
            });
        };

        $scope.getReviewSettingByid = function (id, newCopyData) {
            $scope.hasEdit = true;
            iconHrService.invokeService('').getReviewSettingsById({ id: id }).$promise.then(function (response) {
                $scope.performance = response;
                if (newCopyData) {
                    $scope.performance.PerformanceReviewID = 0;
                    $scope.hasEdit = false;
                }
                $scope.Segments = response.tblPerformanceSegments;
                if (response.tblPerformanceSegments != null && response.tblPerformanceSegments.length > 0)
                    $scope.Questions = response.tblPerformanceSegments[0].tblPerformaceSegmentQuestions;
                $scope.Ratings = response.tblPerformanceScores;
                if ($scope.Locations.filter(function (x) { return x.id == response.LocationID }).length > 0) {
                    $scope.selectedLocation = $scope.Locations.filter(function (x) { return x.id == response.LocationID })[0];
                }
                if ($scope.Departments.filter(function (x) { return x.id == response.DepartmentID }).length > 0) {
                    $scope.selectedDepartment = $scope.Departments.filter(function (x) { return x.id == response.DepartmentID })[0];
                }
                if ($scope.JobRoles.filter(function (x) { return x.id == response.JobRoleID }).length > 0) {
                    $scope.selectedJobRole = $scope.JobRoles.filter(function (x) { return x.id == response.JobRoleID })[0];
                }
                if ($scope.EmploymentTypes.filter(function (x) { return x.id == response.EmploymentTypeID }).length > 0) {
                    $scope.selectedEmploymentType = $scope.EmploymentTypes.filter(function (x) { return x.id == response.EmploymentTypeID })[0];
                }
            });
        }

        $scope.addRatings = function () {
            $scope.Ratings.push({ RatingValue: '', RatingDescription: '' });
        }


        $scope.onChangeOverAllRating = function () {
            if ($scope.performance.OverallScoreID)
                $scope.showRating = true;
            else
                $scope.showRating = false;

        }

        $scope.onSavePerformanceSetting = function () {

            if ($scope.selectedCompany != undefined && $scope.selectedCompany != null) {
                $scope.performance.CompanyID = $scope.selectedCompany.id;
            }
            if ($scope.selectedLocation != undefined && $scope.selectedLocation != null) {
                $scope.performance.LocationID = $scope.selectedLocation.id;
            }
            if ($scope.selectedDepartment != undefined && $scope.selectedDepartment != null) {
                $scope.performance.DepartmentID = $scope.selectedDepartment.id;
            }
            if ($scope.selectedJobRole != undefined && $scope.selectedJobRole != null) {
                $scope.performance.JobRoleID = $scope.selectedJobRole.id;
            }
            if ($scope.selectedEmploymentType != undefined && $scope.selectedEmploymentType != null) {
                $scope.performance.EmploymentTypeID = $scope.selectedEmploymentType.id;
            }
            // validation for Ratings
            $scope.performance.tblPerformanceScores = [];
            angular.forEach($scope.Ratings, function (value, key) {

                if (value.RatingDescription !== "") {
                    value.RatingValue = key + 1;
                    $scope.performance.tblPerformanceScores.push(value);
                }

            });

            if ($scope.performance.tblPerformanceScores.length === 0) {
                alert('Please give at least 3 ratings');
                return;
            }
            iconHrService.invokeService('').saveReviewSettings($scope.performance).$promise.then(function (response) {
                iconHrService.invokeService('').getReviewSettings().$promise.then(function (response) {
                    $scope.PerformanceDetails = response;
                });

            })
                .catch(function (error) {
                    alert(error);
                });
        };


        $scope.onSegmentEdit = function (segment) {
            segment.divedit = true;
            $scope.segment = segment;
            $scope.Questions = segment.tblPerformaceSegmentQuestions;
        };

        $scope.onSegmentDelete = function (segment) {
            $scope.Segments.pop(segment);
        };

        $scope.onQuestionEdit = function (question) {
            $scope.question = question;
            //$scope.Questions
        };

        $scope.onQuestionDelete = function(question) {
            $scope.Questions.pop(question);
        };

        $scope.onQuestionAdd = function () {
            $scope.Questions.push({ Question: $scope.question.Question, HelpText: $scope.question.HelpText });
            $scope.question.Question = '';
            $scope.question.HelpText = '';
        }

        $scope.onTabChange = function () {
            $scope.questionActiveTab = true;
            $scope.segmentsActiveTab = false;
        }

        $scope.onQuestionTabChange = function () {
            $scope.questionActiveTab = false;
            $scope.segmentsActiveTab = true;
        }

        $scope.onSegmentAdd = function () {
            // $scope.Segments = [{ SegmentName: '', SegmentDescription: '', tblPerformaceSegmentQuestions: $scope.Questions }];
            $scope.Segments.push({
                SegmentName: $scope.segment.SegmentName,
                SegmentDescription: $scope.segment.SegmentDescription,
                tblPerformaceSegmentQuestions: $scope.Questions
            });
            $scope.segment.SegmentName = '';
            $scope.segment.SegmentDescription = '';
            $scope.Questions = [];
            $scope.questionActiveTab = false;
            $scope.segmentsActiveTab = true;
            if (angular.element.find('#segmentArrow').length > 0)
            angular.element.find('#segmentArrow')[0].click();
        };

        $scope.clearModel = function () {
            $scope.hasEdit = false;
            $scope.Ratings = [];
            $scope.showRating = false;
            $scope.selectedEmploymentType = {};
            $scope.Questions = [];
            //$scope.questionActiveTab = false;
            //$scope.segmentsActiveTab = true;
            $scope.Segments = [];
            $scope.segment = {
                SegmentName: '',
                SegmentDescription: '',
                tblPerformaceSegmentQuestions: $scope.Questions
            };
            $scope.selectedCompany = {};
            $scope.selectedLocation = {};
            $scope.selectedJobRole = {};
            $scope.selectedDepartment = {};
            $scope.selectedEmploymentType = {};

            $scope.performance = {
                PerformanceReviewID: 0,
                ReviewTitle: '',
                ReviewCompletionDate: null,
                CompanyID: null,
                LocationID: null,
                DepartmentID: null,
                JobRoleID: null,
                EmploymentTypeID: null,
                LengthOfService: null,
                OverallScoreID: null,
                SegmentID: null,
                tblPerformanceSegments: $scope.Segments,
                tblPerformanceScores: []
            };

            $scope.question = {
                Question: '',
                HelpText: ''
            }

        };

        $scope.onCopyReviewChange = function (selectedCopyFrom) {
            if (selectedCopyFrom != null && selectedCopyFrom.id != undefined) {
                $scope.getReviewSettingByid(selectedCopyFrom.id, true);
                $scope.hasEdit = false;
            }
        }
    }
})();