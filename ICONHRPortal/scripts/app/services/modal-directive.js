(function () {
    "use strict";
    angular.module("IconHRModule")
        .directive('modalDialog',
            function() {
                return {
                    restrict: 'EA',
                    scope: {
                        show: '=',
                        message: '='
                    },
                    template: '\
                <div class="ng-modal" ng-show="show"> \
                    <div class="ng-modal-overlay" ng-click="hideModal()"></div> \
                  <div class="ng-modal-dialog" ng-style="dialogStyle"> \
                    <div class="ng-modal-close" ng-click="hideModal()">X</div> \
                    <div class="ng-modal-dialog-content" ng-transclude> \
                </div>\
                <div style="float:right;margin-right:15px">\
                    <button ng-click="hideModal()" class="btn btn-primary" > Ok</button>\
                </div>\
                    </div></div></div>',


                    //template: '<div class="modal fade modal-pop" id="AlertModal" ng-show="show" role="dialog">  \
                    //<div class="modal-dialog modal-sm">\
                    //<div class="modal-content">\
                    //<div class="modal-header">\
                    //<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>\
                    //<h4 class="modal-title">Alert</h4>\
                    //</div>\
                    //<div class="modal-body">\
                    //<p id="AlertMsg" ng-bind="message"></p>\
                    //</div>\
                    //<div class="modal-footer">\
                    //<button type="button" class="round-button waves-effect" ng-click="hideModal()" id="btnOk">OK</button>\
                    //</div>\
                    //</div>\
                    //</div>\
                    //</div>',
                    //replace: true,
                    transclude: true,
                    link: function(scope, elem, attrs) {
                        scope.dialogStyle = {};
                        if (attrs.width) {
                            scope.dialogStyle.width = attrs.width;
                        }
                        if (attrs.height) {
                            scope.dialogStyle.height = attrs.height;
                        }
                        scope.hideModal = function() {
                            scope.show = false;
                            jQuery('.modal').modal('hide');
                        };
                    }
                }
            });
        //.directive("datepicker",
        //    function() {
        //        return {
        //            restrict: "A",
        //            require: "ngModel",
        //            link: function(scope, elem, attrs, ngModelCtrl) {
        //                var updateModel = function(dateText) {
        //                    scope.$apply(function() {
        //                        ngModelCtrl.$setViewValue(dateText);
        //                    });
        //                };
        //                var options = {
        //                    dateFormat: "dd/mm/yy",
        //                    onSelect: function(dateText) {
        //                        updateModel(dateText);
        //                    }
        //                };
        //                elem.datepicker(options);
        //            }
        //        }
        //    });
})();