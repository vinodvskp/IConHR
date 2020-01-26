(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('employeeBulkUploadController', employeeBulkUploadController);

    employeeBulkUploadController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function employeeBulkUploadController($scope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';

        onInit();

        function onInit() {
            iconHrService.invokeService().getEmployees().$promise.then(function (response) {
                $scope.Employees = response;
            });
        }

        $scope.SelectFile = function (file) {
            $scope.SelectedFile = file;
        };
        $scope.Upload = function () {
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
            if (regex.test($scope.SelectedFile.name.toLowerCase())) {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    //For Browsers other than IE.
                    if (reader.readAsBinaryString) {
                        reader.onload = function (e) {
                            $scope.ProcessExcel(e.target.result);
                        };
                        reader.readAsBinaryString($scope.SelectedFile);
                    } else {
                        //For IE Browser.
                        reader.onload = function (e) {
                            var data = "";
                            var bytes = new Uint8Array(e.target.result);
                            for (var i = 0; i < bytes.byteLength; i++) {
                                data += String.fromCharCode(bytes[i]);
                            }
                            $scope.ProcessExcel(data);
                        };
                        reader.readAsArrayBuffer($scope.SelectedFile);
                    }
                } else {
                    $window.alert("This browser does not support HTML5.");
                }
            } else {
                $window.alert("Please upload a valid Excel file.");
            }
        };

        $scope.ProcessExcel = function (data) {
            //Read the Excel File data.
            var workbook = XLSX.read(data, {
                type: 'binary'
            });

            //Fetch the name of First Sheet.
            var firstSheet = workbook.SheetNames[0];

            //Read all rows from First Sheet into an JSON array.
            var excelRows = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[firstSheet]);
            //Display the data from Excel file in Table.
            var jobDetails = [];
            angular.forEach(excelRows, function (value, key) {
                value.DateofJoin = stringToDate(value.DateofJoin, "dd/MM/yyyy", "/");
                value.DateofBirth = stringToDate(value.DateofBirth, "dd/MM/yyyy", "/");

                if (value.PhoneNumber === undefined) {
                    alert("Please enter phone number in excel sheet at row  " + key + 1);
                    throw Error();
                }

                else if (value.EmpRoleID === undefined) {
                    alert("Please enter Role in excel sheet at row  " + key + 1);
                    throw Error();
                }

                else if (value.EmpName === undefined) {
                    alert("Please enter Name in excel sheet at row  " + key + 1);
                    throw Error();
                }

                else if (value.CompanyID === undefined) {
                    alert("Please enter Company Id in excel sheet at row  " + key + 1);
                    throw Error();
                }
                else if (value.EmailID === undefined) {
                    alert("Please enter Email Id in excel sheet at row  " + key + 1);
                    throw Error();
                }
                else if (value.Gender === undefined) {
                    alert("Please enter Gender in excel sheet at row  " + (key + 1));
                    throw Error();
                }

                else if (isNaN(value.EmpRoleID)) {
                    alert("Please enter digits in Employee Role in excel sheet at row  " + (key + 1));
                    throw Error();
                }

                else if(isNaN(value.CompanyID)) {
                    alert("Please enter digits in Company in excel sheet at row  " + (key + 1));
                    throw Error();
                }

                else if (validateEmail(value.EmailID)){
                    alert("Please enter valid email id in excel sheet at row  " + (key + 1));
                    throw Error();
                }


                jobDetails.push({
                    DeptID: value.DepartmentId,
                    JobRoleID: value.JobRoleID ,
                    RepMgrID: value.ReportManagerId,
                    EmpStartDate: value.DateofJoin,
                    JobTypeID: value.JobTypeID,
                    ContractedHours: value.ContractHours
                });
            });
            return;
            angular.forEach(excelRows, function (value, key) {
                value.tblEmployeeJobDetails = jobDetails[key];
            });
            return;
            $scope.$apply(function () {
              
                 $scope.UploadEmployees = excelRows;
                $scope.IsVisible = true;
                iconHrService.invokeService('').saveBulkUploadEmployees($scope.UploadEmployees).$promise.then(function (response) {
                    
                    iconHrService.invokeService().getEmployees().$promise.then(function (response) {
                        $scope.Employees = response;
                        $scope.modalShown = true;
                        $scope.Message = 'Upload Successfully';
                    });
                })
                    .catch(function (error) {
                        $scope.modalShown = true;
                        $scope.Message = error.data.ExceptionMessage;
                    });
            });
        };

        //$scope.onEmployeeBulkUpload = function () {

        //    iconHrService.invokeService('').saveBulkUploadEmployees(model).$promise.then(function (response) {

        //    })
        //        .catch(function (error) {

        //        });

        //}


        function stringToDate(_date, _format, _delimiter) {
            if (_date === undefined) {
                return;
            }
            var formatLowerCase = _format.toLowerCase();
            var formatItems = formatLowerCase.split(_delimiter);
            var dateItems = _date.split(_delimiter);
            var monthIndex = formatItems.indexOf("mm");
            var dayIndex = formatItems.indexOf("dd");
            var yearIndex = formatItems.indexOf("yyyy");
            var month = parseInt(dateItems[monthIndex]);
            month -= 1;
            var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
            return formatedDate;
        };

        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        };

        $scope.onDownload = function () {
            //window.open(filePathurl);
            //window.location.assign(filePathurl);
            alert("You need a web server url to download file can't download");
            window.open(filePathurl, '_blank');
        };
    }

})();