(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('layoutDashboardController', layoutDashboardController);

    layoutDashboardController.$inject = ['$scope', '$rootScope', '$window', '$filter', 'iconHrService', 'helper', 'Upload'];


    function layoutDashboardController($scope, $rootScope, $window, $filter, iconHrService, helper, Upload) {

        $scope.notificationList = [];
        $scope.empId = 0;
        onInit();
        clearNotificaiton();
        function clearNotificaiton() {
            $scope.notificationDetail = {
                NotificationID: '',
                ModifiedPropertyName: '',
                OldPropertyName: '',
                NewPropertyValue: null,
                NotificationShownStatus: null,
                CreatedBy: null,
                CreatedDate: null
            };
        }
        function onInit() {
            //var obj = {
            //    NotificationID: 1,
            //    ModifiedPropertyName: 'dfdf',
            //    OldPropertyName: 'dfds',
            //    NewPropertyValue: 'gfdgf',
            //    NotificationShownStatus: 0,
            //    CreatedBy: 'khaja',
            //    CreatedDate: null
            //};
            //$scope.notificationList.push(obj);
            iconHrService.invokeService('').getNotificaitons().$promise
                .then(function (response) {
                    $scope.notificationList = response;
                });
        }
        var el = angular.element(document.querySelector('.notification'));
        // el.toggleClass('notify');   
   
            setInterval(function () {
            
                iconHrService.invokeService('').getNotificaitons().$promise
                    .then(function (response) {
                        if (response.length > $scope.notificationList.length) {
                            el.toggleClass('notify');
                        }
                        $scope.notificationList = response;
                       // $scope.$apply();
                        
                    });
              
                //poll();
        }, 90000);
        $scope.openNotificaitonPopUp = function (notificaiton) {
            iconHrService.invokeService('').updateNotificaitonStatus(notificaiton).$promise
                .then(function (response) {
                    iconHrService.invokeService('').getNotificaitons().$promise
                        .then(function (response) {
                            onInit();

                        });
                });
            clearNotificaiton();
            jQuery('#notification-modal').modal('show');
            $scope.notificationDetail = notificaiton;

        };
    }

})();