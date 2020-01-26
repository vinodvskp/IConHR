(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('paymentController', paymentController);

    paymentController.$inject = ['$scope', '$window', 'iconHrService', 'helper'];

    function paymentController($scope, $window, iconHrService, helper) {

        $scope.txtNameOnCard = '';
        $scope.ddlCardType = null;
        $scope.txtCardNumber = '';
        $scope.txtCVV = '';
        $scope.ddlMonth = null;
        $scope.ddlYear = null;
        $scope.txtFirstName = '';
        $scope.txtLastName = '';
        $scope.txtAddress = '';
        $scope.ddlCountry = null;
        $scope.txtPostalCode = '';
        $scope.txtPhone = '';
        $scope.txtEmail = '';
        $scope.modalShown = false;
        $scope.Message = 'Your registration has been successfully completed.';
        onInit();

        function onInit() {

            iconHrService.invokeService().getCountryAndCardDetails().$promise.then(function(response) {
                $scope.CountryList = response.Countries;
                $scope.MonthList = response.CardExpireMonths;
                $scope.YearList = response.CardExpireYears;
                $scope.CardTypeList = response.CardTypes;
            });
        }

        $scope.onPaymentBillClick = function () {

            var ccDetailsmodel = {

                cardHolderName: $scope.txtNameOnCard,
                cardType: $scope.ddlCardType,
                cardNumber: $scope.txtCardNumber,
                CVV: $scope.txtCVV,
                cardExpMonth: $scope.ddlMonth,
                cardExpYear: $scope.ddlYear,
                Name: $scope.txtFirstName,
                address: $scope.txtAddress,
                country: $scope.ddlCountry,
                postalCode: $scope.txtPostalCode,
                phoneNumber: $scope.txtPhone,
                email: $scope.txtEmail

            };

            iconHrService.invokeService('').savePaymentAndBillingDetails(ccDetailsmodel).$promise.then(function (response) {
                $scope.modalShown = true;
                $window.location.href = '/Login';
                // TODO
                //helper.ShowModalPop('Your registration has been successfully completed.', function () {
                //    $window.location.href = '/Login';
                //});
            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = "Registration Fail";
                });

        }

    }

})();