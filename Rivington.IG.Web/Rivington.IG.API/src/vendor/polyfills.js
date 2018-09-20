/*jslint browser: true*/
/*global $, jQuery, alert*/

window.initializeConsole = function() {
    if(window.console === undefined) {
        window.console = {};
    }
    
    var methods = ["log", "debug", "warn", "info", "error"];
    for(var i=0;i<methods.length;i++){
        if(window.console[methods[i]] === undefined) {
            window.console[methods[i]] = function(){};
        }
    }
}

window.initializeLocalStorage = function() {
    if(window.localStorage === undefined) {
        window.localStorage = {
            setItem: function() {},
            getItem: function() {},
            removeItem: function() {}
        };
    
        var methods = ["setItem", "getItem", "removeItem"];
        for(var i=0;i<methods.length;i++){
            window.localStorage[methods[i]] = function(){};
        }
    }
}

window.initializeConsole();
window.initializeLocalStorage();