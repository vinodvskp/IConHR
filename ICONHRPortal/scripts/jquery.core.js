var $con = jQuery.noConflict();

$con(document).on('change', '.btn-file :file', function () {
    var input = $con(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.trigger('fileselect', [numFiles, label]);
});

$con(document).ready(function () {
    $con('.btn-file :file').on('fileselect', function (event, numFiles, label) {

        var input = $con(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' files selected' : label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });
});


!function($con) {
    "use strict";

    var Components = function() {};

    //initializing tooltip
    Components.prototype.initTooltipPlugin = function() {
        $con.fn.tooltip && $con('[data-toggle="tooltip"]').tooltip()
    },

    //initializing popover
    Components.prototype.initPopoverPlugin = function() {
        $con.fn.popover && $con('[data-toggle="popover"]').popover()
    },

    //initializing custom modal
    Components.prototype.initCustomModalPlugin = function() {
        $con('[data-plugin="custommodal"]').on('click', function(e) {
        	Custombox.open({
                target: $con(this).attr("href"),
                effect: $con(this).attr("data-animation"),
                overlaySpeed: $con(this).attr("data-overlaySpeed"),
                overlayColor: $con(this).attr("data-overlayColor")
            });
        	e.preventDefault();
        });
    },

    //initializing Slimscroll
    Components.prototype.initSlimScrollPlugin = function() {
        //You can change the color of scroll bar here
        $con.fn.slimScroll &&  $con(".slimscroll-alt").slimScroll({ position: 'right',size: "5px", color: '#98a6ad',wheelStep: 10});
    },

    //range slider
    Components.prototype.initRangeSlider = function() {
        $con.fn.slider && $con('[data-plugin="range-slider"]').slider({});
    },

    /* -------------
     * Form related controls
     */
    //switch
    Components.prototype.initSwitchery = function() {
        $con('[data-plugin="switchery"]').each(function (idx, obj) {
            new Switchery($(this)[0], $con(this).data());
        });
    },

     Components.prototype.initKnob = function() {
         $con('[data-plugin="knob"]').each(function(idx, obj) {
            $con(this).knob();
         });
     },

    Components.prototype.initCounterUp = function() {
        var delay = $con(this).attr('data-delay')?$con(this).attr('data-delay'):100; //default is 100
        var time = $con(this).attr('data-time')?$con(this).attr('data-time'):1200; //default is 1200
         $con('[data-plugin="counterup"]').each(function(idx, obj) {
            $con(this).counterUp({
                delay: 100,
                time: 1200
            });
         });
     },


    //initilizing
    Components.prototype.init = function() {
        var $conthis = this;
        this.initTooltipPlugin(),
        this.initPopoverPlugin(),
        this.initSlimScrollPlugin(),
        this.initCustomModalPlugin(),
        this.initRangeSlider(),
        this.initSwitchery(),
        this.initKnob(),
        this.initCounterUp()
    },

    $con.Components = new Components, $con.Components.Constructor = Components

}(window.jQuery),
    //initializing main application module
function($con) {
    "use strict";
    $con.Components.init();
}(window.jQuery);




