(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('forgotPasswordController', forgotPasswordController);

    forgotPasswordController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function forgotPasswordController($scope, $window, iconHrService, helper) {


        $scope.onForgotPassword = forgotPassword;

        onInit();

        function onInit() {

        }

        function forgotPassword() {
            debugger;
            var model =
            {
                Email: $scope.txtEmail
            };
            iconHrService.invokeService('').forgotPassword(model).$promise.then(function (response) {
                    jQuery('#errorMsgForgotPwd').text('');
                    helper.ShowModalPop('Password reset link has been sent to your email address', function () {
                        $window.location.href = '/Login';
                    });
            })
                .catch(function (error) {
                    jQuery('#errorMsgForgotPwd').text('Invalid email address.');
                });

        }

    }

})();