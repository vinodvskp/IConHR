﻿(function () {
    "use strict";
    angular.module("IconHRModule")
        .directive("loader",
        function ($rootScope) {
            return function ($scope, element, attrs) {
                $scope.$on("loader_show",
                    function () {
                        return element.show();
                    });
                return $scope.$on("loader_hide",
                    function () {
                        return element.hide();
                    });
            };
        })
        .value('CALENDAR_DEFAULTS', {
            locale: 'en'
        })

    .directive('fc', ['CALENDAR_DEFAULTS', fcDirectiveFn]);

    function fcDirectiveFn(CALENDAR_DEFAULTS) {
        debugger;
        return {
            restrict: 'A',
            scope: {
                eventSource: '=ngModel', options: '=fcOptions'
            },
            link: function (scope, elm) {
                var calendar;
                init();
                scope.$watch('eventSource', watchDirective, true);
                scope.$watch('options', watchDirective, true);
                scope.$on('$destroy', function () { destroy(); });
                function init() {
                    if (!calendar) {
                        calendar = jQuery(elm).html('');
                    }
                    debugger;
                    calendar.fullCalendar(getOptions(scope.options));
                }
                function destroy() {
                    if (calendar && calendar.fullCalendar) {
                        calendar.fullCalendar('destroy');
                    }
                }
                function getOptions(options) {
                    debugger;
                    var event_source = scope.eventSource;
                    var isMultiSource = false;
                    Object.keys(event_source[0]).forEach(key => {
                        if (key === "events") {
                            isMultiSource = true;
                        }
                    })

                    if (isMultiSource) {
                        return angular.extend(CALENDAR_DEFAULTS, {
                            eventSources: event_source
                        }, options);
                    } else {
                        return angular.extend(CALENDAR_DEFAULTS, {
                            events: event_source
                        }, options);
                    }

                }
                function watchDirective(newOptions, oldOptions) {
                    if (newOptions !== oldOptions) {
                        destroy();
                        init();
                    } else if ((newOptions && angular.isUndefined(calendar))) {
                        init();
                    }
                }
            }
        };

    }
})();
 




