// Theme color settings
$(document).ready(function() {
    var store = function(name, val) {
        if (typeof(Storage) !== "undefined") {
            if(localStorage) localStorage.setItem(name, val);
        } else {
            window.alert('Please use a modern browser to properly view this template!');
        }
    }

    function get(name) {
        if (typeof(Storage) !== "undefined") {
            return localStorage ? localStorage.getItem(name) : "";
        }
        return null;
    }
    
    // color selector
    $("#themecolors").on("click", "a[data-theme]", function(e) {
        e.preventDefault();

        // store color
        var currentStyle = $(this).attr('data-theme');
        store('theme', currentStyle);

        // apply color
        $('#theme').attr({ href: 'assets/css/colors/' + currentStyle + '.css' })

        // set check
        $('#themecolors li a').removeClass('working');
        $(this).addClass('working')
    });

    // set initial theme
    var currentTheme = get('theme');
    if (currentTheme) {
        $("#themecolors a[data-theme='" + currentTheme + "']").trigger("click");
    }
});
