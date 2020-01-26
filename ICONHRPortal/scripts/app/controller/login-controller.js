(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('loginController', loginController);

    loginController.$inject = ['$scope', '$window', 'iconHrService'];

    function loginController($scope, $window, iconHrService) {

        $scope.emaidId = '';
        $scope.password = '';

        onInit();

        function onInit() {
            $scope.modalShown = true;
            $scope.message = 'Test';
        }

        $scope.onLogin = function () {
            var key = CryptoJS.enc.Utf8.parse('8080808080808080');
            var iv = CryptoJS.enc.Utf8.parse('8080808080808080');

            var encryptedlogin = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse($scope.emaidId), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });
            var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse($scope.password), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });
            $.ajax({
                url: 'http://localhost:51704/token',
                method: 'POST',
                contentType: 'application/x-www-form-urlencoded',
                data: {
                    username: encryptedlogin.toString(),
                    password: encryptedpassword.toString(),
                    grant_type: 'password'
                },
                success: function (response) {
                    sessionStorage.setItem("accessToken", response.access_token);
                    $window.location.href = '/Dashboard';
                },
                error: function (jqXHR,responseMsg, txt) {
                    if (jqXHR.responseJSON.error == 'PaymentRedirection') {
                        $window.location.href = '/Payment';
                        return;
                    }
                    $('#errorMsgLogin').text('user name or password is incorrect');
                }
            });
        }

    }

})();

