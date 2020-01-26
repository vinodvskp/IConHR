(function () {
    "use strict";
    angular.module("IconHRModule")
        //.factory('optionParser', ['$parse', function ($parse) {

        //    //                      00000111000000000000022200000000000000003333333333333330000000000044000
        //    var TYPEAHEAD_REGEXP = /^\s*(.*?)(?:\s+as\s+(.*?))?\s+for\s+(?:([\$\w][\$\w\d]*))\s+in\s+(.*)$/;

        //    return {
        //        parse: function (input) {

        //            var match = input.match(TYPEAHEAD_REGEXP), modelMapper, viewMapper, source;
        //            if (!match) {
        //                throw new Error(
        //                    "Expected typeahead specification in form of '_modelValue_ (as _label_)? for _item_ in _collection_'" +
        //                    " but got '" + input + "'.");
        //            }

        //            return {
        //                itemName: match[3],
        //                source: $parse(match[4]),
        //                viewMapper: $parse(match[2] || match[1]),
        //                modelMapper: $parse(match[1])
        //            };
        //        }
        //    };
        //}])
        .directive('dropdownMultiselect', function () {
            return {
                restrict: 'E',
                scope: {
                    model: '=',
                    options: '=',
                    open: '='
                },
                template:
                    "<div class='btn-group' ng-class='{open: open}'> \
                    <button class='btn btn-success save-event waves-effect waves-light' style='width:150px;color:black;'>Select</button> \
                    <button class='btn btn-success save-event waves-effect waves-light' ng-click='openDropdown()'>\
                        <span style='color:white' class='caret'></span></button> <ul class='dropdown-menu' style='width:200px;' aria-labelledby='dropdownMenu'><li><a ng-click='selectAll()'>\
                        <span class= 'glyphicon glyphicon-ok green'  \
                        aria-hidden='true'></span> Check All</a></li><li><a ng-click='deselectAll();'>\
                        <span class= 'glyphicon glyphicon-remove red' aria-hidden='true'></span> Uncheck All</a></li> \
                        <li class='divider'></li> \
                        <li ng-repeat='option in options'> \
                        <a ng-click='toggleSelectItem(option)'> \
                        <span ng-class='getClassName(option)' aria-hidden='true'></span> {{option.text}} </a></li></ul></div>",
                controller:
                    function ($scope) {
                        $scope.openDropdown = function () {
                            $scope.open = !$scope.open;
                        };

                        $scope.selectAll = function () {
                            $scope.model = [];
                            angular.forEach($scope.options,
                                function (item, index) {
                                    $scope.model.push(item.id);
                                });
                        };

                        $scope.deselectAll = function () {
                            $scope.model = [];
                        };

                        $scope.toggleSelectItem = function (option) {
                            var intIndex = -1;
                            angular.forEach($scope.model,
                                function (item, index) {
                                    if (item == option.id) {
                                        intIndex = index;
                                    }
                                });

                            if (intIndex >= 0) {
                                $scope.model.splice(intIndex, 1);
                            } else {
                                $scope.model.push(option.id);
                            }
                        };

                        $scope.getClassName = function (option) {
                            var varClassName = 'glyphicon glyphicon-remove red';
                            angular.forEach($scope.model,
                                function (item, index) {
                                    if (item == option.id) {
                                        varClassName = 'glyphicon glyphicon-ok green';
                                    }
                                });
                            return (varClassName);
                        };
                    }
            }
        });
})();





