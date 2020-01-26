(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('editEmployeeController', editEmployeeController);

    editEmployeeController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function editEmployeeController($scope, $window, iconHrService, helper) {
        var base64 = '';
        $scope.AdminDetails = [];
        $scope.modalShown = false;
        $scope.Message = 'Employee Details Updated Successfully';
        onInit();
        loadAdminDetails();
        $scope.employeeDetail = {
            EmpID: 0,
            EmpName: null,
            EmpRoleID: null,
            CompanyID: null,
            PhoneNumber: null,
            EmailID: null,
            Password: null,
            Gender: null,
            DateOfBirth: null,
            ProfilePhoto: null,
            FileName:'',
            Address: null,
            CountryID: { id: 0, text: '' },
            PostalCode: null,
            ProfilePhotoBase64: null
        };
        $scope.CountryList = [];
        $scope.selectedCountry = '';
       

        $scope.change = function (val) {
            $scope.selectedCountry = val;
        }
        function onInit() {

            iconHrService.invokeService('').getCountries().$promise
                .then(function (response) {
                    $scope.CountryList = response;
                });

            iconHrService.invokeService('').getEmployeeDetail().$promise
                .then(function (response) {
                    var nameSplit = response.EmpName.split(' ');
                    $scope.employeeDetail = response;
                    jQuery('#photo').val(response.FileName);
                    $scope.employeeDetail.FirstName = nameSplit[0];
                    $scope.employeeDetail.LastName = nameSplit[1];
                    $scope.selectedCountry = response.CountryID.toString();
                });

        }
        function loadAdminDetails() {
            $scope.AdminDetails = [];
            iconHrService.invokeService('').getAdminDetails().$promise
                .then(function (response) {
                    $scope.AdminDetails = response;
                });
        }
        $scope.EditEmployee = function () {
            $scope.employeeDetail.EmpName = $scope.employeeDetail.FirstName + ' ' + $scope.employeeDetail.LastName;
            $scope.employeeDetail.CountryID = parseInt($scope.selectedCountry);
            var reader = new FileReader();
            var selectedFile = document.querySelector('#txtUpload').files[0];
            if (selectedFile !== undefined) {
                reader.readAsDataURL(selectedFile);
                reader.onload = function () {
                    base64 = reader.result;
                    $scope.employeeDetail.ProfilePhotoBase64 = base64.replace('data:image/jpeg;base64,', '');
                    iconHrService.invokeService('').editEmployee($scope.employeeDetail).$promise
                        .then(function (response) {
                            if (document.getElementById('profileImage') != null)
                                document.getElementById('profileImage').src = base64;
                            $scope.modalShown = true;
                            //helper.ShowModalPop('Employee Details Updated Successfully', function () {
                            //    $window.location.href = '/Login';
                            //});
                        })
                        .catch(function (error) {
                            $scope.modalShown = true;
                            $scope.Message = "Update Fail";
                            helper.ShowModalPop('Update Fail', function () {
                            });

                        });

                };
                reader.onerror = function (error) {
                    console.log('Error: ', error);
                };
            } else {
                iconHrService.invokeService('').editEmployee($scope.employeeDetail).$promise
                    .then(function (response) {
                        $scope.modalShown = true;
                        //helper.ShowModalPop('Employee Details Updated Successfully', function () {
                        //    $window.location.href = '/Login';
                        //});
                    })
                    .catch(function (error) {
                        $scope.modalShown = true;
                        $scope.Message = "Update Fail";
                        helper.ShowModalPop('Update Fail', function () {
                        });

                    });
            }
        }

    }

})();