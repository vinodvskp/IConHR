(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('employeePerformanceController', employeePerformanceController);

    employeePerformanceController.$inject = ['$scope', '$rootScope', '$window', 'iconHrService', 'helper'];

    function employeePerformanceController($scope, $rootScope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.collapsed = false;
        $scope.showDefaultReview = true;
        $scope.isEdit = false;
        $scope.EmpReviewID = 0;
        $scope.isMgrEdit = false;
        $scope.step = 0;
        $scope.onNext = function (val) {
            $scope.step = val + 1;
        };

        $scope.isManagerPerformanceTabVisible = false;

        $scope.EmployeeSegments = [];
        $scope.ManagerSegments = [];
        $scope.totalRatings = 0;

        angular.element(document).ready(function () {
            $scope.$broadcast('rzSliderForceRender');
        });

        $scope.employeePerformanceReview = {
            EmpReviewID: 0,
            RepMgrID: 0,
            EmpID: $rootScope.selectedEmployee != null ? $rootScope.selectedEmployee.EmpID : 0,
            PerformanceReviewID: 0,
            Status: true,
            tblEmpPerReviewSegments: []
        };

        $scope.managerPerformanceReview = {
            MgrReviewID: 0,
            RepMgrID: 0,
            EmpID: 0,
            PerformanceReviewID: 0,
            Status: true,
            tblMgrPerReviewSegments: []
        };

        onInit();

        function onInit() {

            var fromScreen = angular.element.find('#hdnScreen')[0].value;

            if ($rootScope.selectedEmployee != undefined && $rootScope.selectedEmployee.EmpID != null) {

                if (fromScreen == 'employee') {
                    $scope.isManagerPerformanceTabVisible = false;
                } else {
                    $scope.isManagerPerformanceTabVisible = true;
                    iconHrService.invokeService().getManagerPerformanceById({ id: $rootScope.selectedEmployee.EmpID }).$promise.then(
                        function (response) {
                            if (response.EmployeeName != '') {
                                $scope.showDefaultReview = false;
                            }
                            $scope.MgrPerformanceReview = response;
                        });
                };

                iconHrService.invokeService().getReviewNames().$promise.then(function (response) {
                    $scope.ReviewNames = response;
                    //$scope.ReviewNames.push({ id: -1, text: 'Select Review' });
                    if ($scope.ReviewNames.length > 0) {
                        $scope.selectedReview = $scope.ReviewNames[$scope.ReviewNames.length - 1];
                        getEmployeePerformanceApi($scope.ReviewNames[$scope.ReviewNames.length - 1].id);
                    }
                });

                iconHrService.invokeService().getEmployeePerformanceById({ id: $rootScope.selectedEmployee.EmpID }).$promise.then(function (response) {
                    if (response.EmployeeName != '') {
                        $scope.showDefaultReview = false;
                    }
                    $scope.EmpMgrPerformanceReview = response;
                    console.log(response);
                });

            } else {
                //if (fromScreen == 'employeeScreen' && $rootScope.selectedEmployee != null) {
                if (fromScreen == 'employee') {
                    //employeeId = $rootScope.selectedEmployee.EmpID;
                    $scope.isManagerPerformanceTabVisible = false;
                } else {
                    $scope.isManagerPerformanceTabVisible = true;
                    iconHrService.invokeService().getManagerPerformanceById({ id: 0 }).$promise.then(
                        function(response) {
                            if (response.EmployeeName != '') {
                                $scope.showDefaultReview = false;
                            }
                            $scope.MgrPerformanceReview = response;
                        });
                };

                iconHrService.invokeService().getReviewNames().$promise.then(function(response) {
                    $scope.ReviewNames = response;
                    //$scope.ReviewNames.push({ id: -1, text: 'Select Review' });
                    if ($scope.ReviewNames.length > 0) {
                        $scope.selectedReview = $scope.ReviewNames[$scope.ReviewNames.length - 1];
                        getEmployeePerformanceApi($scope.ReviewNames[$scope.ReviewNames.length - 1].id);
                    }
                });

                iconHrService.invokeService().getEmployeePerformanceById({ id: 0 }).$promise.then(function(response) {
                    if (response.EmployeeName != '') {
                        $scope.showDefaultReview = false;
                    }
                    $scope.EmpMgrPerformanceReview = response;
                    console.log(response);
                });
            }
        }

        $scope.onEmployeePerformanceSave = function () {

            $scope.employeePerformanceReview.tblEmpPerReviewSegments = [];
            //$scope.employeePerformanceReview = {
            //    EmpMgrReviewID: 0,
            //    RepMgrID: 0,
            //    EmpID: 0,
            //    PerformanceReviewID: 4,
            //    Status: true,
            //    tblEmpPerReviewSegments: []
            //};
            //$scope.employeePerformanceReview.PerformanceReviewID = 4;
            if ($scope.selectedReview != null && $scope.selectedReview.id != undefined) {
                //getEmployeePerformanceApi(selectedReview.id);
                $scope.employeePerformanceReview.PerformanceReviewID = $scope.selectedReview.id;
            }
            $scope.employeePerformanceReview.Status = true;
            $scope.employeePerformanceReview.CreatedBy = angular.element('#loggedUser').val();
            var fromScreen = angular.element.find('#hdnScreen')[0].value;
            if (fromScreen == 'employee' && $rootScope.selectedEmployee != null) {
                $scope.employeePerformanceReview.EmpID = $rootScope.selectedEmployee.EmpID;
            } else {
                $scope.employeePerformanceReview.EmpID = parseInt(angular.element('#EmpID').val());
            }

            for (var i = 0; i < $scope.EmployeeSegments.length; i++) {
                $scope.employeePerformanceReview.tblEmpPerReviewSegments.push(
                    {
                        EmpReviewSegmentID: 0,
                        SegmentID: $scope.EmployeeSegments[i].PerformanceSegmentID,
                        EmpReviewID: null,
                        CreatedBy: angular.element('#loggedUser').val(),
                        CreatedDate: new Date(),
                        Status: true,
                        tblEmpPerReviewRatings: []
                    }
                );
                for (var j = 0; j < $scope.EmployeeSegments[i].tblPerformaceSegmentQuestions.length; j++) {
                    $scope.employeePerformanceReview.tblEmpPerReviewSegments[i].tblEmpPerReviewRatings.push(
                        {
                            EmpPerReviewRatingID: 0,
                            EmpReviewSegmentID: 0,
                            QuestionID: $scope.EmployeeSegments[i].tblPerformaceSegmentQuestions[j].PerformanceQuestionID,
                            ScoreID: $scope.EmployeeSegments[i].tblPerformaceSegmentQuestions[j].employeeRating,
                            Answer: $scope.EmployeeSegments[i].tblPerformaceSegmentQuestions[j].Answer,
                            CreatedBy: angular.element('#loggedUser').val(),
                            CreatedDate: new Date(),
                            Status: true
                        }
                    );

                }
            }
            $scope.employeePerformanceReview.EmpReviewID = $scope.EmpReviewID > 0 ? $scope.EmpReviewID : 0;
            iconHrService.invokeService('').saveEmployeePerformance($scope.employeePerformanceReview).$promise.then(function (response) {
                iconHrService.invokeService().getEmployeePerformanceById().$promise.then(function (response) {
                    if (response.EmployeeName != '') {
                        $scope.showDefaultReview = false;
                    }
                    $scope.EmpMgrPerformanceReview = response;
                    $scope.modalShown = true;
                });
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });

        };

        $scope.expandEmployee = function (obj) {
            angular.forEach($scope.EmployeeSegments,
                function (value, key) {
                    value.isCollapsed = false;
                });
            obj.isCollapsed = true;
            //if (obj.isCollapsed)
            //    obj.isCollapsed = false;
            //else {
            //    obj.isCollapsed = true;
            //}
        };

        $scope.expandManager = function (obj) {
            angular.forEach($scope.ManagerSegments,
                function (value, key) {
                    value.isCollapsed = false;
                });
            obj.isCollapsed = true;
        };

        $scope.onReviewChange = function (selectedReview) {
            if (selectedReview != null && selectedReview.id != undefined) {
                getEmployeePerformanceApi(selectedReview.id);
            }
        };

        function getEmployeePerformanceApi(id) {
            iconHrService.invokeService('').getReviewSettingsById({ id: id }).$promise.then(function (response) {
                $scope.performance = response;
                $scope.EmployeeSegments = angular.copy(response.tblPerformanceSegments);
                $scope.ManagerSegments = angular.copy(response.tblPerformanceSegments);
                //if (response.tblPerformanceSegments != null && response.tblPerformanceSegments.length > 0)
                //    $scope.Questions = response.tblPerformanceSegments[0].tblPerformaceSegmentQuestions;
                if (response.tblPerformanceScores != null && response.tblPerformanceScores.length > 0) {
                    $scope.totalRatings = response.tblPerformanceScores.length;
                }

                //Slider with ticks and values and tooltip
                $scope.slider_ticks_values_tooltip = {
                    value: 0,
                    options: {
                        ceil: $scope.totalRatings,
                        floor: 1,
                        showTicksValues: true,
                        //stepsArray: ["Fair", "Good", "Very Good", "Excellent"],
                        translate: function (value) {
                            // return value +' ' + '<i style="color: orange" class="fa fa-star"></i>';
                            return value;
                        },
                        ticksValuesTooltip: function (v) {
                            if (v == 1) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[0].RatingDescription : '';
                            }
                            if (v == 2) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[1].RatingDescription : '';
                            }
                            if (v == 3) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[2].RatingDescription : '';
                            }
                            if (v == 4) {
                                return response.tblPerformanceScores[3] > null ? response.tblPerformanceScores[3].RatingDescription : '';
                            }
                            if (v == 5) {
                                return response.tblPerformanceScores[4] > null ? response.tblPerformanceScores[4].RatingDescription : '';
                            }
                            return 'Ratings ' + v;
                        }
                    }
                };
                $scope.slider_ticks_values_tooltip1 = $scope.slider_ticks_values_tooltip;
                setTimeout(function () { $scope.slider_ticks_values_tooltip.value = 1; $scope.slider_ticks_values_tooltip1.value = 1 }, 3);
            });
        }

        $scope.OnEditEmpMgrReviewById = function (PerformanceReviewID, empReviewID) {
            iconHrService.invokeService().getSPEmployeePerformanceByEmpMgrReviewId({
                empid: angular.element('#EmpID').val(),
                rptMgrId: 0,
                empMgrReviewId: PerformanceReviewID
            }).$promise.then(function (response) {
                //$scope.EmpMgrPerformanceReview = response;
                console.log(response);
                $scope.EmpReviewID = empReviewID;
                // iconHrService.invokeService('').getReviewSettingsById({ id: PerformanceReviewID }).$promise.then(function (response) {
                $scope.performance = response;
                $scope.EmployeeSegments = angular.copy(response.tblPerformanceSegments);
                //$scope.ManagerSegments = angular.copy(response.tblPerformanceSegments);
                $scope.showDefaultReview = true;
                if (response.tblPerformanceScores != null && response.tblPerformanceScores.length > 0) {
                    $scope.totalRatings = response.tblPerformanceScores.length;
                }
                $scope.isEdit = true;
                //Slider with ticks and values and tooltip
                $scope.slider_ticks_values_tooltip = {
                    value: 0,
                    options: {
                        ceil: $scope.totalRatings,
                        floor: 1,
                        showTicksValues: true,
                        //stepsArray: ["Fair", "Good", "Very Good", "Excellent"],
                        translate: function (value) {
                            // return value +' ' + '<i style="color: orange" class="fa fa-star"></i>';
                            return value;
                        },
                        ticksValuesTooltip: function (v) {
                            if (v == 1) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[0].RatingDescription : '';
                            }
                            if (v == 2) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[1].RatingDescription : '';
                            }
                            if (v == 3) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[2].RatingDescription : '';
                            }
                            if (v == 4) {
                                return response.tblPerformanceScores[3] > null ? response.tblPerformanceScores[3].RatingDescription : '';
                            }
                            if (v == 5) {
                                return response.tblPerformanceScores[4] > null ? response.tblPerformanceScores[4].RatingDescription : '';
                            }
                            return 'Ratings ' + v;
                        }
                    }
                };
                setTimeout(function () { $scope.slider_ticks_values_tooltip.value = 1 }, 3);
            });
            // });

        };

        $scope.onManagerPerformanceSave = function () {

            $scope.managerPerformanceReview.tblMgrPerReviewSegments = [];
            
            if ($scope.selectedReview != null && $scope.selectedReview.id != undefined) {
                //getEmployeePerformanceApi(selectedReview.id);
                $scope.managerPerformanceReview.PerformanceReviewID = $scope.selectedReview.id;
            }
            $scope.managerPerformanceReview.Status = true;
            $scope.managerPerformanceReview.CreatedBy = angular.element('#loggedUser').val();
           // $scope.managerPerformanceReview.EmpID = parseInt(angular.element('#EmpID').val());
            var fromScreen = angular.element.find('#hdnScreen')[0].value;
            if (fromScreen == 'employee' && $rootScope.selectedEmployee != null) {
                $scope.managerPerformanceReview.EmpID = $rootScope.selectedEmployee.EmpID;
            } else {
                $scope.managerPerformanceReview.EmpID = parseInt(angular.element('#EmpID').val());
            }
            $scope.managerPerformanceReview.RepMgrID = parseInt(angular.element('#EmpID').val());
            for (var i = 0; i < $scope.ManagerSegments.length; i++) {
                $scope.managerPerformanceReview.tblMgrPerReviewSegments.push(
                    {
                        MgrReviewSegmentID: 0,
                        PerformanceSegmentID: $scope.ManagerSegments[i].PerformanceSegmentID,
                        MgrReviewID: null,
                        CreatedBy: angular.element('#loggedUser').val(),
                        CreatedDate: new Date(),
                        Status: true,
                        tblMgrPerReviewRatings: []
                    }
                );
                for (var j = 0; j < $scope.ManagerSegments[i].tblPerformaceSegmentQuestions.length; j++) {
                    $scope.managerPerformanceReview.tblMgrPerReviewSegments[i].tblMgrPerReviewRatings.push(
                        {
                            MgrPerReviewRatingID: 0,
                            MgrReviewSegmentID: 0,
                            PerformanceQuestionID: $scope.ManagerSegments[i].tblPerformaceSegmentQuestions[j].PerformanceQuestionID,
                            ScoreID: $scope.ManagerSegments[i].tblPerformaceSegmentQuestions[j].managerRating,
                            Answer: $scope.ManagerSegments[i].tblPerformaceSegmentQuestions[j].Answer,
                            CreatedBy: angular.element('#loggedUser').val(),
                            CreatedDate: new Date(),
                            Status: true
                        }
                    );

                }
            }
            $scope.managerPerformanceReview.MgrReviewID = $scope.MgrReviewID > 0 ? $scope.MgrReviewID : 0;
            iconHrService.invokeService('').saveManagerPerformance($scope.managerPerformanceReview).$promise.then(function (response) {
                iconHrService.invokeService().getManagerPerformanceById().$promise.then(function (response) {
                    if (response.EmployeeName != '') {
                        $scope.showDefaultReview = false;
                    }
                    $scope.MgrPerformanceReview = response;
                    $scope.modalShown = true;
                });
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Insert Fail";
                });

        };

        $scope.OnEmployeePerformanceCancel = function() {
            $scope.isEdit = false;
            $scope.EmpReviewID = 0;
        };

        $scope.onManagerPerformanceCancel = function () {
            $scope.isMgrEdit = false;
        };


        $scope.OnEditMgrReviewById = function(performanceReviewID, mgrReviewID) {

            iconHrService.invokeService().getSPManagerPerformanceByReviewId({
                empid: 0, //angular.element('#EmpID').val(),
                rptMgrId: angular.element('#EmpID').val(),
                empMgrReviewId: performanceReviewID
            }).$promise.then(function (response) {
                $scope.MgrReviewID = mgrReviewID;
                $scope.mgrPerformance = response;
               // $scope.ManagerSegments = angular.copy(response.tblPerformanceSegments);
                $scope.ManagerSegments = angular.copy(response.tblPerformanceSegments);
                $scope.showDefaultReview = true;
                debugger;
                if (response.tblPerformanceScores != null && response.tblPerformanceScores.length > 0) {
                    $scope.totalRatings = response.tblPerformanceScores.length;
                }
                $scope.isEdit = true;
                //Slider with ticks and values and tooltip
                $scope.slider_ticks_values_tooltip1 = {
                    value: 0,
                    options: {
                        ceil: $scope.totalRatings,
                        floor: 1,
                        showTicksValues: true,
                        //stepsArray: ["Fair", "Good", "Very Good", "Excellent"],
                        translate: function (value) {
                            // return value +' ' + '<i style="color: orange" class="fa fa-star"></i>';
                            return value;
                        },
                        ticksValuesTooltip: function (v) {
                            if (v == 1) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[0].RatingDescription : '';
                            }
                            if (v == 2) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[1].RatingDescription : '';
                            }
                            if (v == 3) {
                                return response.tblPerformanceScores.length > 0 ? response.tblPerformanceScores[2].RatingDescription : '';
                            }
                            if (v == 4) {
                                return response.tblPerformanceScores[3] > null ? response.tblPerformanceScores[3].RatingDescription : '';
                            }
                            if (v == 5) {
                                return response.tblPerformanceScores[4] > null ? response.tblPerformanceScores[4].RatingDescription : '';
                            }
                            return 'Ratings ' + v;
                        }
                    }
                };
                setTimeout(function () { $scope.slider_ticks_values_tooltip1.value = 1 }, 3);
            });
        };

    }

})();