(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('documentController', documentController);

    documentController.$inject = ['$scope', '$rootScope', '$window', 'iconHrService', 'helper', 'Upload', '$filter'];

    function documentController($scope, $rootScope, $window, iconHrService, helper, Upload, $filter) {
        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.DocumentTypes = [];
        $scope.getDocuments = [];
        $scope.SelectedFiles = null;
        $scope.selectedDocumentType = null;
        $scope.IsCompanyAccessOnly = false;

        $scope.document = {
            Description: '',
            Title: '',
            DocumentName: '',
            EmpID: '',
            IsCompanyAccessOnly: false
        };

        onInit();

        function onInit() {
            //iconHrService.invokeService().getDocumentTypeOptions().$promise.then(function (response) {
            //    $scope.DocumentTypes = response;
            //    $scope.DocumentTypes.push({ id: -1, text: 'Select Type' });
            //});
            var employeeId = 0;
            var fromScreen = angular.element.find('#hdnScreenName')[0].value;
            if (fromScreen == 'employeeScreen' && $rootScope.selectedEmployee != null) {
                employeeId = $rootScope.selectedEmployee.EmpID;
            }
            iconHrService.invokeService().getDocumentsById({ fromScreen: fromScreen, employeeId: employeeId }).$promise.then(function (response) {
                $scope.getDocuments = response;
            });
        };

        $scope.UploadFiles = function (files) {
            $scope.SelectedFiles = files;
            if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            }
        };

        $scope.onDocumentSave = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
                // $scope.SelectedFiles[0].name = $filter('date')(new Date(), 'MM/dd/yyyy HH:mm:ss') + '_' + $scope.SelectedFiles[0].name 
                Upload.upload({
                    url: "/api/documentapi/UploadFiles",
                    headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] },
                    data: {
                        files: $scope.SelectedFiles
                    }
                }).then(function (response) {
                   
                    
                    var model = {
                        // Attachment: $scope.SelectedFiles,
                        // DocumentCategoryTypeID: $scope.selectedDocumentType.id,
                        DocumentName: $scope.SelectedFiles[0].name
                    };
                    $scope.document.fromScreen = angular.element.find('#hdnScreenName')[0].value;
                    //if ($scope.document.fromScreen == "companyScreen") {
                    //    $scope.document.IsCompanyAccessOnly = true;
                    //} else {
                    //    $scope.document.IsCompanyAccessOnly = false;
                    //}
                    if ($rootScope.selectedEmployee != null) {
                        $scope.document.EmpID = $rootScope.selectedEmployee.EmpID;
                    }
                    $scope.document.DocumentName = $scope.SelectedFiles[0].name;
                    iconHrService.invokeService('').saveDocuments($scope.document).$promise.then(function (response) {
                        var employeeId = 0;
                        var fromScreen = angular.element.find('#hdnScreenName')[0].value;
                        if (fromScreen == 'employeeScreen' && $rootScope.selectedEmployee != null) {
                            employeeId = $rootScope.selectedEmployee.EmpID;
                        }
                        iconHrService.invokeService().getDocumentsById({ fromScreen: fromScreen, employeeId: employeeId }).$promise.then(function (response) {
                            $scope.getDocuments = response;
                            $scope.getDocuments = response;
                            $scope.modalShown = true;
                            $scope.document = {
                                Description: '',
                                Title: '',
                                DocumentName: '',
                                EmpID: '',
                                IsCompanyAccessOnly: false
                            };
                            $scope.SelectedFiles = [];

                            angular.element("input[type='file']").val(null);
                        });
                    })
                        .catch(function (error) {
                            $scope.modalShown = true;
                            $scope.Message = 'Upload Fail';
                        });

                }, function (response) {

                });
            }

        }

        $scope.onCategoryFilterChange = function (selectedDocumentType) {

        };

        $scope.onDownload = function (filePathurl) {
            //window.open(filePathurl);
            //window.location.assign(filePathurl);
            alert("You need a web server url to download file can't download" + filePathurl);
            window.open(filePathurl, '_blank');
        };

        $scope.onDeleteDocument = function (id) {

            var x = confirm("Are you sure you want to delete?");
            if (x) {
                iconHrService.invokeService('').DeleteDocument({ id: id }).$promise.then(function (response) {
                    iconHrService.invokeService().getDocuments().$promise.then(function (response) {
                        $scope.getDocuments = response;
                        $scope.modalShown = true;
                    });

                })
                    .catch(function (error) {
                        $scope.modalShown = true;
                        $scope.Message = 'Upload Fail';
                    });
                return true;

            } else
                return false;
        };
    }

})();