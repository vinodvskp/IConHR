(function () {

    'use strict';
    //angular.module('app', ['ngMaterial', 'ngResource', 'ngRoute', 'ngMessages', 'xtForm', 'ngMaterialDatePicker', "ngCookies", "chart.js"])
    angular.module('IconHRModule', ['ngResource', 'ngMessages', 'ui.bootstrap', 'ngFileUpload', 'ngTouch', 'ui.grid', 'xtForm', 'ngMessages', 'rzSlider'])

        .directive("compareTo", function () {
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
        })
        .config(aapConfiguration);
     aapConfiguration.$inject = ["$httpProvider", "$provide", "xtFormConfigProvider", "$resourceProvider"];
   // aapConfiguration.$inject = ["$httpProvider","xtFormConfigProvider"];
     function aapConfiguration($httpProvider, $provide, xtFormConfigProvider, $resourceProvider) {
    //function aapConfiguration($httpProvider,xtFormConfigProvider) {

        xtFormConfigProvider.addValidationStrategy('IconHRModule', function (form, ngModel) {
            return form.$invalid;
        });
        xtFormConfigProvider.setDefaultValidationStrategy('IconHRModule');

        $httpProvider.useApplyAsync(true);
        $httpProvider.interceptors.push('iconHRHttpInterceptor');

        // Override default error messages
        xtFormConfigProvider.setErrorMessages({
            server: 'serverError',
            required: 'The required field is empty',
            customErrorMessage: 'Here is a message for a custom validation directive',
            minlength: 'Needs to be at least {{ngMinlength}} characters long',
            maxlength: 'Can be no longer than {{ngMaxlength}} characters long',
            number: 'Must be a number',
            min: 'Must be at least {{ngMin}}',
            max: 'Must be no greater than {{ngMax}}',
            email: 'Must be a valid E-mail address',
            pattern: 'Illegal value',
            url: 'Must be a valid URL',
            date: 'Must be a valid date',
            datetimelocal: 'Must be a valid date',
            time: 'Must be a valid time',
            week: 'Must be a valid week',
            month: 'Must be a valid month'
        });

        $provide.decorator('$templateRequest', ['$delegate', function ($delegate) {
            var templateProvider = function(tpl, ignoreRequestError) {
                return $delegate(tpl, true);
            };
            return templateProvider;
        }]);
    }
})();
