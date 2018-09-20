/*jslint browser: true*/
/*global $, jQuery, alert*/

var consoleHolder = console;
function debug(bool){
    if(!bool){
        consoleHolder = console;
        console = {};
        Object.keys(consoleHolder).forEach(function(key){
            console[key] = function(){};
        })
    }else{
        console = consoleHolder;
    }
}
debug(false);

$(function () {
    var body = $("body");
    if(body.data("environmentName") !== "Production") {
        debug(true);
    }
    
    var fnValueHasOnlyOneDecimalPoint = function(value) {
        return (new RegExp(/^-?\d+\.?\d*$/).test(value));
    }
    
    var fnAllowOnlyNumeric = function(charsToAllow, e) {
        // -1 !== $.inArray(e.keyCode, [46, 8, 9, 27, 13 /*, 110, 190*/ ]) || /65|67|86|88/.test(e.keyCode) && (!0 === e.ctrlKey || !0 === e.metaKey) || 35 <= e.keyCode && 40 >= e.keyCode || (e.shiftKey || 48 > e.keyCode || 57 < e.keyCode) && (96 > e.keyCode || 105 < e.keyCode) && e.preventDefault()
        
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, charsToAllow) !== -1 ||
        // Allow: Ctrl+A, Command+A
        (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) || 
        // Allow: home, end, left, right, down, up
        (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
            return false;
        }
    }

    // restrict inputs to int only
    body.on('keydown', "input.int-only", function(e) {
        // Allow: backspace, delete, tab, escape, and enter
        fnAllowOnlyNumeric([46, 8, 9, 27, 13 /*, 110, 190*/ ], e);
    });
    
    body.on('paste blur', "input.int-only", function(e) {
        var that = this;
        setTimeout(function(e) {
            that.value = that.value.replace(/\D/g,'');
        }, 0);
    });

    // restrict inputs to decimal only
    body.on('keydown', "input.decimal-only", function(e) {
        var that = this;
        // Allow: backspace, delete, tab, escape, enter and .        
        if(fnAllowOnlyNumeric([46, 8, 9, 27, 13, 110, 190], e) !== false) {
            setTimeout(function() {
                if(!fnValueHasOnlyOneDecimalPoint(that.value)) {
                    that.value = that.value.slice(0, that.value.length - 1)
                }
            }, 0);
        }
    });

    body.on('paste blur', "input.decimal-only", function(e) {
        var that = this;
        setTimeout(function(e) {
            var value = that.value;
            if(!!!value) return true;

            value = value.replace(/[^\d.]/g,'');

            if(!fnValueHasOnlyOneDecimalPoint(value)) {
                if(isNaN(parseFloat(value)) || (value.match(/./g) || []).length > 1) {
                    value = "";
                }
            }

            that.value = value;
        }, 0);
    });
});
