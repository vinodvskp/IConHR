IconApp.controller('IconHRCtrl', ['$scope', '$window', 'IconHRService', function ($scope, $window, IconHRService, Upload, $timeout) {

    var $con = jQuery.noConflict();
    $scope.base64 = '';
    var base64 = '';
    //GetDeptJobRolesRpMgrDetails();



    $scope.init = function () {
        base64 = '';
        GetCountryAndCardDetails();
        GetProfile();

    }
    GetProfile();
    function GetProfile() {
        var data = IconHRService.getProfileImage();
        data.then(function (result) {
            
            if (document.getElementById('profileImage') != null)
                document.getElementById('profileImage').src = 'data:image/jpeg;base64,' + result.data;
        });
    };

    function GetCountryAndCardDetails() {
        var data = IconHRService.GetCountryAndCardDetails();
        data.then(function (result) {
            $scope.CountryList = result.data.Table;
            $scope.MonthList = result.data.Table1;
            $scope.YearList = result.data.Table2;
            $scope.CardTypeList = result.data.Table3;
        });
    }

    function GetDeptJobRolesRpMgrDetails() {
        var data = IconHRService.GetDeptJobRolesRpMgrDetails();
        data.then(function (result) {
            $scope.Departments = result.data.Table;
            $scope.JobRoles = result.data.Table1;
            $scope.ReportingManager = result.data.Table2;
        });
    }

    $scope.AddNewEmployee = function () {
        var firstName = $con('#txtFirstName').val();
        var lastName = $con('#txtLastName').val();
        var email = $con('#txtEmail').val();
        var phoneNumber = $con('#txtPhone').val();
        var password = $con('#txtPassword').val();
        var company = $con('#txtCompanyName').val();
        var companySize = $con("input[name='rblCompSize']:checked").val();

        var reader = new FileReader();
        var selectedFile = document.querySelector('#txtprofilePic').files[0];
        reader.readAsDataURL(selectedFile);
        reader.onload = function () {
            base64 = reader.result; 
            console.log(reader.result);
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
        debugger;
        var data = IconHRService.AddNewEmployee(firstName + " " + lastName, email, phoneNumber, password, company, companySize, base64.replace('data:image/jpeg;base64,', ''));

        data.then(function (result) {
            debugger;
            if (result.data.toLowerCase() == "success") {
                $window.location.href = '/Payment';
            }
            else {
                ShowModalPop('Email Id already exists.', function () {
                    // $window.location.href = '/Login';
                });
            }
        });
    }

    $scope.PaymentAndBillingDetails = function () {

        // Card Details
        var cardHolderName = $con('#txtNameOnCard').val();
        var cardType = $con('#ddlCardType option:selected').val();
        var cardNumber = $con('#txtCardNumber').val();
        var CVV = $con('#txtCVV').val();
        var cardExpMonth = $con('#ddlMonth option:selected').val();
        var cardExpYear = $con('#ddlYear option:selected').val();

        // Billing Details
        var firstName = $con('#txtFirstName').val();
        var lastName = $con('#txtLastName').val();
        var address = $con('#txtAddress').val();
        var country = $con('#ddlCountry option:selected').val();
        var postalCode = $con('#txtPostalCode').val();
        var phoneNumber = $con('#txtPhone').val();
        var email = $con('#txtEmail').val();

        var data = IconHRService.PaymentAndBillingDetails(cardHolderName, cardType, cardNumber, CVV, cardExpMonth, cardExpYear, firstName + " " + lastName, address, country, postalCode, phoneNumber, email);
        data.then(function (result) {
            if (result.data.toLowerCase() == "success") {
                ShowModalPop('Your registration has been successfully completed.', function () {
                    $window.location.href = '/Login';
                });
            }
            else {
            }
        });
    }




    $scope.Login = function () {
        var email = $con('#txtEmail').val();
        var password = $con('#txtPassword').val();
        var data = IconHRService.Login(email, password);
        data.then(function (result) {
            if (result.data.toLowerCase() == "true") {
                $con('#errorMsgLogin').text('');
                $window.location.href = '/Dashboard';
            }
            else {
                $con('#errorMsgLogin').text('user name or password is incorrect');
            }
        });
    }
    load();
    // document.querySelector('#txtUpload')
    function load() {
        if (document.querySelector('#txtUpload') != undefined) {
            document.querySelector('#txtUpload').addEventListener('change',
                function() {
                    debugger;
                    var reader = new FileReader();
                    var selectedFile = this.files[0];

                    reader.onload = function() {
                        var comma = this.result.indexOf(',');
                        base64 = this.result.substr(comma + 1);
                        //console.log(base64);
                    }
                    reader.readAsDataURL(selectedFile);
                },
                false);
        }
    }

    $scope.EditEmployee = function () {

        var reader = new FileReader();
        var selectedFile = document.querySelector('#txtUpload').files[0];
        reader.readAsDataURL(selectedFile);
        reader.onload = function () {
            debugger;
            base64 = reader.result;
            console.log(reader.result);
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
        debugger;
        var firstName = $con('#txtFirstName').val();
        var lastName = $con('#txtLastName').val();
        var email = $con('#txtEmail').val();
        var phone = $con('#txtPhone').val();
        var gender = $con('input[name=inlineRadioOptions]:checked').val();
        var upload = $con('#txtUpload').val();
        var address = $con('#txtAddress').val();
        var dob = $con('#txtDOB').val();
        var postalCode = $con('#txtPostalCode').val();
        var country = $con("#ddlCountries option:selected").val();
        var data = IconHRService.EditEmployee(firstName, lastName, email, phone, gender, base64.replace('data:image/jpeg;base64,', ''), address, dob, postalCode, country);
        data.then(function (result) {
            if (result.data.toLowerCase() == "success") {
                ShowModalPop('Employee Details Updated Successfully', function () {
                    $window.location.href = '/Login';
                });
            }
            else {
            }
        });
    }

    $scope.ForgotPassword = function () {
        var email = $con('#txtEmail').val();
        var data = IconHRService.ForgotPassword(email);
        data.then(function (result) {
            if (result.data.toLowerCase() == "success") {
                $con('#errorMsgForgotPwd').text('');
                ShowModalPop('Password reset link has been sent to your email address', function () {
                    $window.location.href = '/Login';
                });
            }
            else {
                $con('#errorMsgForgotPwd').text('Invalid email address.');
            }
        });
    }

    $scope.ResetPassword = function () {
        var password = $con('#txtPassword').val();
        var passwordToken = GetParameterValues('T');
        var data = IconHRService.ResetPassword(password, passwordToken);
        data.then(function (result) {
            if (result.data.toLowerCase() == "success") {
                $con('#errorMsgResetPwd').text('');
                ShowModalPop('Password has been reset successfully', function () {
                    $window.location.href = '/Login';
                });
            }
            else {
                $con('#errorMsgResetPwd').text('Failed to reset password.');
            }
        });
    }

    $scope.ChangePassword = function () {
        var oldPassword = $con('#txtOldPassword').val();
        var password = $con('#txtPassword').val();
        var data = IconHRService.ChangePassword(oldPassword, password);
        data.then(function (result) {
            if (result.data.toLowerCase() == "success") {
                $con('#errorMsgChangePwd').text('');
                $con('#modal-changepwd').modal('hide');
            }
            else {
                $con('#errorMsgChangePwd').text('Entered old password is incorrect.');
            }
        });
    }

    $scope.CloseChangePwdModalPop = function () {
        $scope.ChangePwdForm.$setPristine();
        $con('#txtOldPassword').val("");
        $con('#txtPassword').val("");
        $con('#txtConfirmPassword').val("");
        $con('#errorMsgChangePwd').text('');
        $con('#modal-changepwd').modal('hide');
    }

    $scope.ShowChangePwdModalPop = function () {
        $con('#modal-changepwd').modal('show');
        $con('#modal-changepwd').on('shown.bs.modal', function (e) {
            $con('#btn-changepwd-save').focus();
            e.preventDefault();
        });
    }

    function ShowModalPop(msg, okFn) {
        $con('#AlertMsg').html(msg);
        $con('#AlertModal').modal({ backdrop: 'static' });
        $con('#btnOk').unbind().click(function () {
            $con('#AlertModal').modal('hide');
        });
        $con('#btnOk').click(okFn);
        $con('#AlertModal').modal('show');
    }

    function GetParameterValues(param) {
        var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < url.length; i++) {
            var urlparam = url[i].split('=');
            if (urlparam[0] == param) {
                return urlparam[1];
            }
        }
    }

}]);

IconApp.directive("compareTo", function () {
    return {
        require: "ngModel",
        scope:
            {
                confirmPassword: "=compareTo"
            },
        link: function (scope, element, attributes, modelVal) {
            modelVal.$validators.compareTo = function (val) {
                return val == scope.confirmPassword;
            };
            scope.$watch("confirmPassword", function () {
                modelVal.$validate();
            });
        }
    };
});