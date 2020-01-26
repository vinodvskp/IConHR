(function () {
    "use strict";
    angular.module("IconHRModule")

        .factory("helper", helper);
    helper.$inject = [];

    function helper() {

        var obj =
            {
                ShowModalPop: onShowModalPop
            };

        function onShowModalPop(msg, okFn) {
            jQuery('#AlertMsg').html(msg);
            jQuery('#AlertModal').modal({ backdrop: 'static' });
            jQuery('#btnOk').unbind().click(function () {
                jQuery('#AlertModal').modal('hide');
            });
            jQuery('#btnOk').click(okFn);
            jQuery('#AlertModal').modal('show');
        }
        return obj;
         
    }


})();