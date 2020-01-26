(function () {
    "use strict";
    angular.module("IconHRModule")
        .directive("datepicker",
            function() {
                return {
                    restrict: "A",
                    require: "ngModel",
                    link: function (scope, elem, attrs, ngModelCtrl) {
                 
                        var updateModel = function(dateText) {
                            scope.$apply(function() {
                                ngModelCtrl.$setViewValue(dateText);
                            });
                        };
                        var options = {
                            //dateFormat: "dd/mm/yy",
                            //format: "dd/MM/yyyy",
                            //todayHighlight: true,
                           // autoclose: true,
                            //pickTime: false,
                            onSelect: function(dateText) {
                                updateModel(dateText);
                            }
                        };
                        elem.datepicker(options);
                    }
                }
            });
})();