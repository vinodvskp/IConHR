(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('changePasswordController', changePasswordController);

    changePasswordController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function changePasswordController($scope, $window, iconHrService, helper) {


        $scope.onChangePassword = changePassword;
        //$scope.ResetPassword = onResetPassword();

        onInit();

        function onInit() {

        }

        function changePassword() {

            var key = CryptoJS.enc.Utf8.parse('8080808080808080');
            var iv = CryptoJS.enc.Utf8.parse('8080808080808080');
            var encryptedOldpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse($scope.txtOldPassword), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });
            var encryptedNewpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse($scope.txtPassword), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });

            var model = {

                //oldPassword: $scope.txtOldPassword,
                //newPassword: $scope.txtPassword
                oldPassword: encryptedOldpassword.toString(),
                newPassword: encryptedNewpassword.toString()

            };

            iconHrService.invokeService('').changePassword(model).$promise.then(function (response) {
                jQuery('#errorMsgChangePwd').text('');
                   $scope.CloseChangePwdModalPop();
                jQuery('#modal-changepwd').modal('hide');
            })
                .catch(function (error) {
                    jQuery('#errorMsgChangePwd').text('Entered old password is incorrect.');
                });
        };

        $scope.ResetPassword = function onResetPassword() {

            var key = CryptoJS.enc.Utf8.parse('8080808080808080');
            var iv = CryptoJS.enc.Utf8.parse('8080808080808080');
            var encryptedresetpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(jQuery('#txtPassword').val()), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });

            iconHrService.invokeService('').resetPassword({
                password: encryptedresetpassword.toString(),
                passwordToken: GetParameterValues('T'),
                canResetPassword: true
            })
                .$promise.then(function (result) {
                    if (result.data.toLowerCase() == "success") {
                        jQuery('#errorMsgResetPwd').text('');
                        helper.ShowModalPop('Password has been reset successfully', function () {
                            $window.location.href = '/Login';
                        });
                    }
                    else {
                        jQuery('#errorMsgResetPwd').text('Failed to reset password.');
                    }
                });
        };
        $scope.NewPassword = function onResetPassword() {
            var model = {
                password: jQuery('#txtPassword').val(),
                Email: GetParameterValues('T')
            };
            iconHrService.invokeService('').resetPassword(
                model
            )
                .$promise.then(function (result) {
                    if (result[0].toLowerCase() == "s") {
                        jQuery('#errorMsgResetPwd').text('');
                        helper.ShowModalPop('Password has been reset successfully', function () {
                            $window.location.href = '/Login';
                        });
                    }
                    else {
                        jQuery('#errorMsgResetPwd').text('Failed to reset password.');
                    }
                });
        };
        function GetParameterValues(param) {
            debugger;
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0] == param) {
                    return urlparam[1];
                }
            }
            return '';
        }

        $scope.CloseChangePwdModalPop = function () {
            $scope.ChangePwdForm.$setPristine();
            jQuery('#txtOldPassword').val("");
            jQuery('#txtPassword').val("");
            jQuery('#txtConfirmPassword').val("");
            jQuery('#errorMsgChangePwd').text('');
            jQuery('#modal-changepwd').modal('hide');
        }

        $scope.ShowChangePwdModalPop = function () {
            jQuery('#modal-changepwd').modal('show');
            jQuery('#modal-changepwd').on('shown.bs.modal', function (e) {
                jQuery('#btn-changepwd-save').focus();
                e.preventDefault();
            });
        }

    }

})();