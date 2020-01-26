(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('addEmployeeController', addEmployeeController);

    addEmployeeController.$inject = ['$scope', '$rootScope', '$window', '$filter', 'iconHrService', 'helper', 'Upload'];


    function addEmployeeController($scope, $rootScope, $window, $filter, iconHrService, helper, Upload) {
        $scope.employeeTableVisibility = true;
        $scope.EmployeeList = [];
        $scope.EmployeeTimeSheetList = [];
        $scope.AdminDetails = [];
        $scope.selectedEmployye = null;
        $scope.DocumentType = 'General';
        $scope.AddDocumentType = 'General';
        $scope.empId = 0;
        $scope.Locations = [];
        $scope.getDepartments = [];
        $scope.selectedDepartment;
      //  $scope.selectedDepartment.id = -1;
        $scope.getEmployementTypes = [];
        $scope.selectedEmployementType;
        $scope.getJobRoles = [];
        $scope.selectedJobRole;
        $scope.selectedLocations;
        $scope.selectedReportManager;
        $scope.eml_add = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
        onInit();


        $scope.employeeDetail = {
            FirstName: '',
            LastName: '',
            EmpName: '',
            CompanyID: null,
            CompanyName: '',
            PhoneNumber: null,
            EmailID: null,
            Password: null,
            Gender: null,
            DateOfBirth: null,
            ProfilePhoto: null,
            FileName:'',
            Address: null,
            CountryID: null,
            PostalCode: null,
            ContractedHours: null,
            JobRoleName: '',
            LocationName: '',
            EmpStartDate: '',
            DeptName: '',
            IsNewRecord:false,
            CompanyUrl: '',
            Location: '',
            ////added by chandra for job infromation on 28/06/19
            //LocationID: null,
            //DepartmentID: null,
            JobRoleID: null
            //ReportsToID: null,
            //StartDate: null,
            //EmploymentTypeID: null,
            //ContractedHours: null

        };

        $scope.jobDetails = {
            LocationID: null,
            DeptID: null,
            JobRoleID: null,
            ReportsToID: null,
            EmpStartDate: null,
            JobTypeID: null,
            ContractedHours: null

        };
        clearTimeSheet();

      

        $scope.gridOptions = {
            enableSorting: true,
            enableFiltering: true,
            paginationPageSizes: [10,25,50],
            paginationPageSize: 10,
            columnDefs: [
                {
                    name: 'ID', field: 'EmpID',
                    width: 70,
                    cellTemplate: //'<div><a ng-href="{{row.entity.hyperlink]}}">Click me</a></div>'
                        //' < a href="#" ng-click="OnEdit(emp)" style = "text-decoration:underline;" > {{ row.entity.EmpID }}</a >'
                        '<div  style="text-align:center" class="ngCellText" ng-class="col.colIndex()"><a href="#" ng-click="grid.appScope.OnEdit(row.entity)" style = "text-decoration:underline;">{{row.entity.EmpID}}</a></div>'
                },
                { name: 'Name', field: 'EmpName', width: 250 },
                { name: 'Email Id', field: 'EmailID', width: 250 },
                { name: 'JobRole', field: 'JobRoleName' },
                { name: 'Location', field: 'LocationName' },
                {
                    name: 'Action',
                    width: 100,
                    cellTemplate:
                        //'<div  style="text-align:center" class="ngCellText" ng-class="col.colIndex()"><a href="#" ng-click="grid.appScope.OnEdit(row.entity)" style = "text-decoration:underline;">{{row.entity.EmpID}}</a></div>'
                        '<div  style="text-align:center" class="ngCellText" ng-class="col.colIndex()"><a href="#" style = "text-decoration:underline;">Delete</a></div>'
                }
            ],
           // data: $scope.EmployeeList
        };

        $scope.timesheetGridOptions = {
            enableSorting: true,
            columnDefs: [
                {
                    name: 'Project', field: 'Project',
                    cellTemplate:
                        '<div  style="text-align:center" class="ngCellText" ng-class="col.colIndex()"><a href="#" ng-click="grid.appScope.getTimeSheet(row.entity)">{{row.entity.Project}}</a></div>'
                },
                { name: 'Task', field: 'Task' },
                { name: 'Details', field: 'Details' },
                { name: 'StartDate', field: 'StartDate', cellFilter: 'date:\'MM/dd/yyyy\'' },
                { name: 'EndDate', field: 'EndDate', cellFilter: 'date:\'MM/dd/yyyy\'' },
                { name: 'Quantity', field: 'Quantity' },
                { name: 'TotalHours', field: 'TotalHours' },
            ],
            data: $scope.EmployeeTimeSheetList
        };

        loadAdminDetails();
        jQuery('#divSteps').find('a[href="#previous"]').click(function () {
            jQuery('#btEmployeesubmit').hide();
        });
        jQuery('#divSteps').find('a[href="#next"]').click(function () {
            jQuery('#btEmployeesubmit').parent().show();
            jQuery('#btEmployeesubmit').show();
        });
        function getParameterValues() {
            debugger;
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            var urlparam = url[0].split('/');
            return urlparam[urlparam.length - 1];
        }
        function onInit() {
          
            var screenName = getParameterValues();
            if (screenName === "EmpDetails") {
                iconHrService.invokeService('').getEmployee().$promise
                    .then(function (response) {
                        debugger;
                        $scope.employeeDetail = response;

                    });
            }
            if (screenName === "Employees") {
                jQuery('#divSteps').find('a[href="#finish"]').remove();
                //append a submit type button
                jQuery('#divSteps .actions li:last-child').append('<button type="submit" id="btEmployeesubmit" class="btn btn-success pull-right"">Complete</button>');
                //jQuery('#divSteps .actions li:last-child').append('<button type="submit" id="submit" class="btn-large"><span class="fa fa-chevron-right"></span></button>');
               
                iconHrService.invokeService('').getEmployees().$promise
                    .then(function (response) {
                        debugger;
                        $scope.EmployeeList = response;
                        $scope.gridOptions.data = response;
                    });
                iconHrService.invokeService('').getLocations().$promise
                    .then(function (response) {
                        $scope.Locations = response;
                    });
                iconHrService.invokeService('').getAdminManagerNames().$promise
                    .then(function (response) {
                        $scope.ReportingMangers = response;
                    });
                iconHrService.invokeService().getDepartmentNames().$promise.then(function (response) {
                    $scope.getDepartments = response;
                });
                iconHrService.invokeService().getEmployementTypes().$promise.then(function (response) {
                    $scope.getEmployementTypes = response;
                });
                iconHrService.invokeService().getJobRolesOption().$promise.then(function (response) {
                    $scope.getJobRoles = response;
                });
            }
        };

        $scope.OnEdit = function (emp) {
            $scope.selectedEmployye = emp;
            $scope.empId = emp.EmpID;
            $scope.employeeTableVisibility = false;
            $rootScope.selectedEmployee = emp;
        };
        function clearTimeSheet() {
            $scope.timeSheetDetail = {
                TimesheetID: 0,
                EmpID: '',
                EmpName: '',
                Project: '',
                Task: '',
                Details: '',
                StartDate: null,
                EndDate: null,
                TotalHours: '',
                Quantity: '',
                Notes: '',
                Approver: '',
                isApproved: false,
                IsSubmited: false
            };
        }
        function clearEmployeeLogBook() {
            $scope.obj = {};
            jQuery('#Document').val(null);
            $scope.employeeLogBookDetail = {
                LogBookID: 0,
                EmpId: '',
                DocumentType: '',
                LogDate: '',
                Type: '',
                Summary: '',

                ApprisalReviewDate: '',
                ApprisalReviewerID: "",
                ApprisalReviewerName: '',
                ApprisalNotes: '',

                DrivingLicenceNumber: '',
                LicenceType: '',
                LicenceExpiryDate: '',
                Comments: '',


                Issue: '',
                IssueStatus: '',
                IssueCreatedDate: '',
                IssueClosedDate: '',
                IssueNotes: '',

                TrainingType: '',
                TrainingDescription: '',
                PriorityType: '',
                TrainingStatus: '',
                TrainingStartDate: '',
                TrainingEndDate: '',
                TrainingNotes: '',
                DocName: '',
                DocType: '',
                DocFile: [],
                Data: ''
            };
        }
        $scope.onEmployeeBack = function () {
            $scope.employeeTableVisibility = true;
        };
        //Function to load all Employee records

        function loadTimeSheetDetailsByRpetManger() {
            $scope.EmployeeTimeSheetList = [];
            iconHrService.invokeService('').getTimeSheetsByRptMng().$promise
                .then(function (response) {
                    $scope.EmployeeTimeSheetList = response;
                    $scope.timesheetGridOptions.data.push($scope.EmployeeTimeSheetList);
                    //$scope.timesheetGridOptions.data= response;
                });

        }
        function loadTimeSheetDetails() {
            //alert('hi');
            $scope.EmployeeTimeSheetList = [];
            iconHrService.invokeService('').getTimeSheets().$promise
                .then(function (response) {
                    $scope.EmployeeTimeSheetList = response;
                });
        }
        function loadAdminDetails() {
            $scope.AdminDetails = [];
            iconHrService.invokeService('').getAdminDetails().$promise
                .then(function (response) {
                    $scope.AdminDetails = response;
                });
        }
        $scope.tabClick = function (tab) {
            if (tab === 2) {
                loadTimeSheetDetails();
            }
            if (tab === 'reprtManager') {
                loadTimeSheetDetailsByRpetManger();
            }
            if (tab === 5) {
                loadEmployeeLogBookDetails();
            }

        };

        $scope.addNewTimeSheet = function () {
            clearTimeSheet();

        };
        //Add new log book
        $scope.upload = function (changeEvent) {
            var reader = new FileReader();
            reader.onload = function (loadEvent) {
                $scope.$apply(function () {

                    var fileName = changeEvent.target.files[0].name;
                    var filesize = changeEvent.target.files[0].size;
                    // var allowedFiles = [".jpeg", ".jpg", ".pdf", ".png", ".doc", ".docx"];

                    $scope.obj = {
                        lastModified: changeEvent.target.files[0].lastModified,
                        lastModifiedDate: changeEvent.target.files[0].lastModifiedDate,
                        name: changeEvent.target.files[0].name,
                        //  size: convertBytesToUnits(changeEvent.target.files[0].size),
                        type: changeEvent.target.files[0].type,
                        data: loadEvent.target.result
                    };



                });
            }
            reader.readAsDataURL(changeEvent.target.files[0]);

        };
        $scope.downLoadFile = function (employeeLogBook) {
            var form = jQuery('<form></form>').attr('action', '/api/EmployeeLogBookApi/DownLoadDoucument?id=' + employeeLogBook.LogBookID).attr('method', 'POST');
            form.appendTo('body').submit().remove();
        };
        $scope.addNewLogBook = function () {
            $scope.AddDocumentType = 'General';
            clearEmployeeLogBook();
            //   getDocumentDetailis();

        };
        $scope.addDocumentTypeChange = function (type) {
            clearEmployeeLogBook();
            $scope.AddDocumentType = type;
            $scope.employeeLogBookDetail.DocumentType = type;
            getDocumentDetailis();

        };
        $scope.documentTypeChange = function (type) {
            $scope.DocumentType = type;
            loadEmployeeLogBookDetails();

        };
        $scope.getEmployeeLogBook = function (employeeLogBook) {
            clearEmployeeLogBook();
            jQuery('#timesheet-addemployeelogbook-modal').modal('show');
            $scope.AddDocumentType = employeeLogBook.DocumentType;
            gelogBookDetailisById(employeeLogBook);
            //timeSheeet.StartDate = timeSheeet.StartDate != null ? $filter('date')(timeSheeet.StartDate, "MM/dd/yyyy") : '',
            //    timeSheeet.EndDate = timeSheeet.EndDate != null ? $filter('date')(timeSheeet.EndDate, "MM/dd/yyyy") : '',
            // $scope.employeeLogBookDetail = employeeLogBook;

        };
        $scope.deleteLogbook = function (employeeLogBook) {
            iconHrService.invokeService('').deleteLogbook({ id: employeeLogBook.LogBookID }).$promise
                .then(function (response) {
                    alert('Record deleted successfully');
                    loadEmployeeLogBookDetails();
                });

        };
        function gelogBookDetailisById(employeeLogBook) {

            iconHrService.invokeService('').getEmployeeLogBookById({ id: employeeLogBook.LogBookID }).$promise
                .then(function (response) {
                    if (response != null) {
                        $scope.employeeLogBookDetail = response;

                        $scope.employeeLogBookDetail.ApprisalReviewDate = $scope.employeeLogBookDetail.ApprisalReviewDate != null && $scope.employeeLogBookDetail.ApprisalReviewDate != '' ? $filter('date')($scope.employeeLogBookDetail.ApprisalReviewDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.LicenceExpiryDate = $scope.employeeLogBookDetail.LicenceExpiryDate != null && $scope.employeeLogBookDetail.LicenceExpiryDate != '' ? $filter('date')($scope.employeeLogBookDetail.LicenceExpiryDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.IssueCreatedDate = $scope.employeeLogBookDetail.IssueCreatedDate != null && $scope.employeeLogBookDetail.IssueCreatedDate != '' ? $filter('date')($scope.employeeLogBookDetail.IssueCreatedDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.IssueClosedDate = $scope.employeeLogBookDetail.IssueClosedDate != null && $scope.employeeLogBookDetail.IssueClosedDate != '' ? $filter('date')($scope.employeeLogBookDetail.IssueClosedDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.TrainingStartDate = $scope.employeeLogBookDetail.TrainingStartDate != null && $scope.employeeLogBookDetail.TrainingStartDate != '' ? $filter('date')($scope.employeeLogBookDetail.TrainingStartDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.TrainingEndDate = $scope.employeeLogBookDetail.TrainingEndDate != null && $scope.employeeLogBookDetail.TrainingEndDate != '' ? $filter('date')($scope.employeeLogBookDetail.TrainingEndDate, "MM/dd/yyyy") : '';
                        $scope.employeeLogBookDetail.LogDate = $scope.employeeLogBookDetail.LogDate != null && $scope.employeeLogBookDetail.LogDate != '' ? $filter('date')($scope.employeeLogBookDetail.LogDate, "MM/dd/yyyy") : '';
                    }
                });
        }
        $scope.saveEmployeeLogBook = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            if ($scope.obj != undefined && $scope.obj.name != undefined) {
                $scope.employeeLogBookDetail.DocType = $scope.obj.type;
                $scope.employeeLogBookDetail.DocName = $scope.obj.name;
                $scope.employeeLogBookDetail.Data = $scope.obj.data;
            }
            $scope.employeeLogBookDetail.EmpId = $scope.empId;
            $scope.employeeLogBookDetail.DocumentType = $scope.AddDocumentType;
            if ($scope.AddDocumentType == 'Appraisal')
                $scope.employeeLogBookDetail.ApprisalReviewerName = jQuery("#ddlApprisalReviewerID option:selected").text();
            iconHrService.invokeService('').addEmployeeLogBook($scope.employeeLogBookDetail).$promise
                .then(function (response) {
                    if ($scope.employeeLogBookDetail.LogBookID == 0)
                        alert(jQuery("#ddlTypeList option:selected").text() + " saved successfully");
                    else
                        alert(jQuery("#ddlTypeList option:selected").text() + " updated successfully");
                    jQuery('#timesheet-addemployeelogbook-modal').modal('toggle');
                    loadEmployeeLogBookDetails();
                });
        };
        function getDocumentDetailis() {

            iconHrService.invokeService('').getEmployeeLogBook({ empId: $scope.empId, type: $scope.AddDocumentType }).$promise
                .then(function (response) {
                    if (response != null && response.length > 0) {
                        $scope.employeeLogBookDetail = response[0];

                        $scope.employeeLogBookDetail.ApprisalReviewDate = $scope.employeeLogBookDetail.ApprisalReviewDate != null && $scope.employeeLogBookDetail.ApprisalReviewDate != '' ? $filter('date')($scope.employeeLogBookDetail.ApprisalReviewDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.LicenceExpiryDate = $scope.employeeLogBookDetail.LicenceExpiryDate != null && $scope.employeeLogBookDetail.LicenceExpiryDate != '' ? $filter('date')($scope.employeeLogBookDetail.LicenceExpiryDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.IssueCreatedDate = $scope.employeeLogBookDetail.IssueCreatedDate != null && $scope.employeeLogBookDetail.IssueCreatedDate != '' ? $filter('date')($scope.employeeLogBookDetail.IssueCreatedDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.IssueClosedDate = $scope.employeeLogBookDetail.IssueClosedDate != null && $scope.employeeLogBookDetail.IssueClosedDate != '' ? $filter('date')($scope.employeeLogBookDetail.IssueClosedDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.TrainingStartDate = $scope.employeeLogBookDetail.TrainingStartDate != null && $scope.employeeLogBookDetail.TrainingStartDate != '' ? $filter('date')($scope.employeeLogBookDetail.TrainingStartDate, "MM/dd/yyyy") : '';

                        $scope.employeeLogBookDetail.TrainingEndDate = $scope.employeeLogBookDetail.TrainingEndDate != null && $scope.employeeLogBookDetail.TrainingEndDate != '' ? $filter('date')($scope.employeeLogBookDetail.TrainingEndDate, "MM/dd/yyyy") : '';
                        $scope.employeeLogBookDetail.LogDate = $scope.employeeLogBookDetail.LogDate != null && $scope.employeeLogBookDetail.LogDate != '' ? $filter('date')($scope.employeeLogBookDetail.LogDate, "MM/dd/yyyy") : '';
                    }
                });
        }
        function loadEmployeeLogBookDetails() {
            //alert('hi');
            $scope.EmployeeLogBookList = [];
            //iconHrService.invokeService('').getEmployeeLogBook({ { empId: $scope.empId, type: $scope.DocumentType }).$promise.then(function (response) {
            //    iconHrService.invokeService().getEmployeeLogBook().$promise.then(function (response) {
            //        $scope.EmployeeLogBookList = response;
            //    });

            //})
            iconHrService.invokeService('').getEmployeeLogBook({ empId: $scope.empId, type: $scope.DocumentType }).$promise
                .then(function (response) {
                    $scope.EmployeeLogBookList = response;
                });
        }
        //end LogBook 

        $scope.clear = function (myForm) {
            myForm.$setPristine();
            //   myForm.$setValidity();
            // myForm.$setUntouched();
            // in my case I had to call $apply to refresh the page, you may also need this.
            jQuery('#timesheet-addnew-modal').modal('toggle');
        };
        $scope.timeSheetSubmit = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            iconHrService.invokeService('').addTimeSheet($scope.timeSheetDetail).$promise
                .then(function (response) {
                    alert("TimeSheet submitted successfully");
                    myForm.$setPristine();
                    //myForm.$setPristine();
                    //myForm.$setValidity();
                    //myForm.$setUntouched();
                    jQuery('#btEmployeesubmit').hide();
                    jQuery('#timesheet-addnew-modal').modal('toggle');
                    
                    loadTimeSheetDetails();


                });
        };
        function clear_form_elements() {
            debugger;

            jQuery("#divSteps").find(':input').each(function () {
                switch (this.type) {
                    case 'password':
                    case 'text':
                    case 'textarea':
                    case 'file':
                    case 'select-one':
                    case 'select-multiple':
                    case 'date':
                    case 'number':
                    case 'tel':
                    case 'email':
                        jQuery(this).val('');
                        break;
                    case 'checkbox':
                    case 'radio':
                        this.checked = false;
                        break;
                }
            });
        }
    $scope.submit = function (myForm) {
        if (!myForm.$valid) {
            // alert('Enter valid data in all required fields');
            return;
        }
        $scope.employeeDetail.tblEmployeeJobDetails = [];
        $scope.employeeDetail.IsNewRecord = true;
        $scope.employeeDetail.EmpName = $scope.employeeDetail.FirstName + ' ' + $scope.employeeDetail.LastName;
      

        if ($scope.selectedLocations != undefined && $scope.selectedLocations != null) {
            $scope.jobDetails.LocationID = $scope.selectedLocations;
        }
        if ($scope.selectedReportManager != undefined && $scope.selectedReportManager != null) {
            $scope.jobDetails.RepMgrID = $scope.selectedReportManager;
        }

        if ($scope.selectedDepartment != undefined && $scope.selectedDepartment != null) {
            $scope.jobDetails.DeptID = $scope.selectedDepartment;
        }
        if ($scope.selectedEmployementType != undefined && $scope.selectedEmployementType != null) {
            $scope.jobDetails.JobTypeID = $scope.selectedEmployementType;
        }
        if ($scope.selectedJobRole != undefined && $scope.selectedJobRole != null) {
            $scope.jobDetails.JobRoleID = $scope.selectedJobRole;
        }
        var key = CryptoJS.enc.Utf8.parse('8080808080808080');
        var iv = CryptoJS.enc.Utf8.parse('8080808080808080');
        var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse($scope.employeeDetail.Password), key,
            {
                keySize: 128 / 8,
                iv: iv,
                mode: CryptoJS.mode.CBC,
                padding: CryptoJS.pad.Pkcs7
            });
        $scope.employeeDetail.Password = encryptedpassword.toString();
        $scope.employeeDetail.tblEmployeeJobDetails.push($scope.jobDetails);
        iconHrService.invokeService('').addNewEmployee($scope.employeeDetail).$promise
            .then(function (response) {
                //if (response.Result.toLowerCase() === "success") {
                //    $window.location.href = '/Payment';
                //}
                //else {
                //    helper.ShowModalPop('Email Id already exists.', function () {
                //        $window.location.href = '/Login';
                //    });
                //}
                alert('Record saved successfully');
                jQuery('#useradd-modal').modal('hide');
                clear_form_elements();
                iconHrService.invokeService('').getEmployees().$promise
                    .then(function (response) {
                        debugger;
                        $scope.EmployeeList = response;
                        $scope.gridOptions.data = response;
                    });
               
            });
    };

        $scope.AddNewEmployee = function () {

            $scope.employeeDetail.EmpName = $scope.employeeDetail.FirstName + ' ' + $scope.employeeDetail.LastName;
            $scope.employeeDetail.tblEmployeeJobDetails = $scope.jobDetails;
            if ($scope.employeeDetail.CompanyUrl != null && $scope.employeeDetail.CompanyUrl != '') {
                $scope.employeeDetail.CompanyUrl = $scope.employeeDetail.CompanyUrl + 'amagos.com';
            };

        if ($scope.selectedLocations != undefined && $scope.selectedLocations != null) {
            $scope.jobDetails.LocationID = $scope.selectedLocations;
        }
        if ($scope.selectedReportManager != undefined && $scope.selectedReportManager != null) {
            $scope.jobDetails.RepMgrID = $scope.selectedReportManager;
        }

            if ($scope.selectedDepartment != undefined && $scope.selectedDepartment != null) {
                $scope.jobDetails.DepartmentID = $scope.selectedDepartment;
            }
            if ($scope.selectedEmployementType != undefined && $scope.selectedEmployementType != null) {
                $scope.jobDetails.EmploymentTypeID = $scope.selectedEmployementType;
            }
            if ($scope.selectedJobRole != undefined && $scope.selectedJobRole != null) {
                $scope.jobDetails.JobRoleID = $scope.selectedJobRole;
            }
            var key = CryptoJS.enc.Utf8.parse('8080808080808080');
            var iv = CryptoJS.enc.Utf8.parse('8080808080808080');
            var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse($scope.employeeDetail.Password), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });
            $scope.employeeDetail.Password = encryptedpassword.toString();

        iconHrService.invokeService('').addNewEmployee($scope.employeeDetail).$promise
            .then(function (response) {
                if (response.Result.toLowerCase() === "success") {
                    $window.location.href = '/Payment';
                }
                //else {
                //    helper.ShowModalPop('Email Id already exists.', function () {
                //         $window.location.href = '/Login';
                //    });
                //}
            })
            .catch(function (error) {
                if (error.data.Result === 'Email Id already exists!') {
                    helper.ShowModalPop('Email Id already exists.',
                        function () {
                            // $window.location.href = '/Login';
                        });
                }
                else if (error.data.Result === 'company already exists!') {
                    helper.ShowModalPop('Company already exists.',
                        function () {
                            $window.location.href = '/Registration';
                        });
                }

                    else if (error.data.Result === 'Company URL already exists!') {
                        helper.ShowModalPop('Company URL already exists.',
                            function () {
                                $window.location.href = '/Registration';
                            });
                    }

                    else {
                        jQuery('#errorMsgForgotPwd').text('Invalid email address.');
                    }
                });
        };

}

}) ();