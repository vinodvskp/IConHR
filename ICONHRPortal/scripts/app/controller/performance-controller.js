(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('performanceController', performanceController);

    performanceController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function performanceController($scope, $window, iconHrService, helper) {

        $scope.scoreDetails = {
            EmployeeScore: '',
            ManagerScore: ''
        };

        onInit();

        function onInit() {
            GetProfile();
            GetMagerProfilePhoto();
            iconHrService.invokeService().getReviewNames().$promise.then(function (response) {
                $scope.ReviewNames = response;
                //$scope.ReviewNames.push({ id: -1, text: 'Select Review' });
                if ($scope.ReviewNames.length > 0) {
                    $scope.selectedReview = $scope.ReviewNames[$scope.ReviewNames.length - 1];
                    getEmployeeScoreDetails($scope.ReviewNames[$scope.ReviewNames.length - 1].id);
                }
            });
          
        };
        $scope.onReviewChange = function (selectedReview) {
            if (selectedReview != null && selectedReview.id != undefined) {
                getEmployeeScoreDetails(selectedReview.id);
            }
        };
        function getEmployeeScoreDetails(id) {
            iconHrService.invokeService('').getEmployeeScoreDetails({ id: id }).$promise.then(function (response) {
                $scope.scoreDetails = response;
            });
        }
        function GetProfile() {
            jQuery.ajax({
                url: 'http://localhost:51704/api/userapi/GetProfilePhoto',
                method: 'Get',
                contentType: 'application/json',
                beforeSend: function (request) {
                    request.setRequestHeader('Authorization', 'bearer' + ' ' + sessionStorage["accessToken"]);
                },
                success: function (response) {
                    if (document.getElementById('EmpProfileImage') != null)
                        document.getElementById('EmpProfileImage').src = 'data:image/jpeg;base64,' + response;
                },
                error: function (jqXHR) {
                    alert('profile pic error');
                }
            });
        };
        function GetMagerProfilePhoto() {
            jQuery.ajax({
                url: 'http://localhost:51704/api/userapi/GetMagerProfilePhoto',
                method: 'Get',
                contentType: 'application/json',
                beforeSend: function (request) {
                    request.setRequestHeader('Authorization', 'bearer' + ' ' + sessionStorage["accessToken"]);
                },
                success: function (response) {
                    if (document.getElementById('MngProfileImage') != null)
                        document.getElementById('MngProfileImage').src = 'data:image/jpeg;base64,' + response;
                },
                error: function (jqXHR) {
                    alert('profile pic error');
                }
            });
        };
    }
})();