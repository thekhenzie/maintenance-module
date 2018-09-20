/*
Template Name: Material Pro Admin
Author: Themedesigner
Email: niravjoshi87@gmail.com
File: js
*/
$(function () {
    "use strict";
  
    var win = $(window);
    var doc = $(document);
    var jBody = $("body");
  
    $(".preloader").fadeOut();
  
    // ============================================================== 
    // This is for the top header part and sidebar part
    // ==============================================================  
    win.on("resize", function () {
      var width = (window.innerWidth > 0) ? window.innerWidth : this.screen.width;
      var topOffset = 59;
      if (width < 1170) {
        $("body").addClass("mini-sidebar");
        $('.navbar-brand span').hide();
        $(".scroll-sidebar, .slimScrollDiv").css("overflow-x", "visible").parent().css("overflow", "visible");
        $(".sidebartoggler i").addClass("ti-menu");
      } else {
        $("body").removeClass("mini-sidebar");
        $('.navbar-brand span').show();
        //$(".sidebartoggler i").removeClass("ti-menu");
      }
  
      var height = ((window.innerHeight > 0) ? window.innerHeight : this.screen.height) - 1;
      height = height - topOffset;
      if (height < 1) height = 1;
      if (height > topOffset) {
        $(".page-wrapper").css("min-height", (height) + "px");
      }
    });

    win.trigger("resize");
  
    // ============================================================== 
    // Theme options
    // ==============================================================     
    doc.on('click', ".sidebartoggler", function () {
      if (jBody.hasClass("mini-sidebar")) {
        jBody.trigger("resize");
        $(".scroll-sidebar, .slimScrollDiv").css("overflow", "hidden").parent().css("overflow", "visible");
        jBody.removeClass("mini-sidebar");
        $('.navbar-brand span').show();
        //$(".sidebartoggler i").addClass("ti-menu");
      } else {
        jBody.trigger("resize");
        $(".scroll-sidebar, .slimScrollDiv").css("overflow-x", "visible").parent().css("overflow", "visible");
        jBody.addClass("mini-sidebar");
        $('.navbar-brand span').hide();
        //$(".sidebartoggler i").removeClass("ti-menu");
      }
    });
    // topbar stickey on scroll
  
    // this is for close icon when navigation open in mobile view
    doc.on("click", ".nav-toggler", function () {
      jBody.toggleClass("show-sidebar");
      $("i", this).toggleClass("ti-menu").addClass("ti-close");
    }).on("click", ".sidebartoggler", function () {
      //$(".sidebartoggler i").toggleClass("ti-menu");      
    }).on("click", ".search-box a, .search-box .app-search .srh-btn", function () {
      $(".app-search").toggle(200);
    });
  
    // ============================================================== 
    // Right sidebar options
    // ============================================================== 
    doc.on("click", ".sidebar-footer .sidebar-settings, .right-side-toggle, .topbar .topbar-toggle-settings", function (e) {
      e.preventDefault();
      $(".right-sidebar").slideDown(50).toggleClass("shw-rside");
    });
  
    // ============================================================== 
    // Sidebarmenu
    // ============================================================== 
    function initiateSideBar(sidebarnav) {
      sidebarnav.metisMenu({});
    
      // ============================================================== 
      // Auto select left navbar
      // ============================================================== 
      var url = window.location.toString();
      var element = $('ul#sidebarnav li a').filter(function () {
        return url.startsWith(this.href);
      }).map(function() {
        var li = $(this).closest("li");
        // li.addClass('active');
        li.closest("ul").addClass('active');

        return li[0];
      });

      while (true) {
        if (element.prop("tagName") != "LI") break;

        element = element.parent().addClass('in').parent().addClass('active');
      }
    }

    var sidebarIntervalCtr = 0;
    var sidebarInterval = setInterval(function() {
      var sidebarnav = $('#sidebarnav');
      if(sidebarnav.length) {
        window.clearInterval(sidebarInterval);
        initiateSideBar(sidebarnav);
      } else if(sidebarIntervalCtr === 20) {
        window.clearInterval(sidebarInterval);
      }
      sidebarIntervalCtr++;
    }, 200)
    
    // ============================================================== 
    //tooltip
    // ============================================================== 
    $('[data-toggle="tooltip"]').tooltip()
  
    // ============================================================== 
    //Popover
    // ============================================================== 
    $('[data-toggle="popover"]').popover()
  
    // ============================================================== 
    // Slimscrollbars
    // ============================================================== 
    $('.scroll-sidebar').slimScroll({
      position: 'left',
      size: "5px",
      height: '100%',
      color: '#dcdcdc'
    });
    $('.message-center').slimScroll({
      position: 'right',
      size: "5px",
      color: '#dcdcdc'
    });
  
    $('.aboutscroll').slimScroll({
      position: 'right',
      size: "5px",
      height: '80',
      color: '#dcdcdc'
    });
    $('.message-scroll').slimScroll({
      position: 'right',
      size: "5px",
      height: '570',
      color: '#dcdcdc'
    });
    $('.chat-box').slimScroll({
      position: 'right',
      size: "5px",
      height: '470',
      color: '#dcdcdc'
    });
  
    $('.slimscrollright').slimScroll({
      height: '100%',
      position: 'right',
      size: "5px",
      color: '#dcdcdc'
    });
  
    // ============================================================== 
    // Resize all elements
    // ============================================================== 
    jBody.trigger("resize");
  
    // ============================================================== 
    // To do list
    // ============================================================== 
    doc.on("click", ".list-task li label", function () {
      $(this).toggleClass("task-done");
    });
  
    // ============================================================== 
    // Login and Recover Password 
    // ============================================================== 
    doc.on("click", "#to-recover", function () {
      $("#loginform").slideUp();
      $("#recoverform").fadeIn();
    });
  
    // ============================================================== 
    // Collapsable cards
    // ==============================================================
    doc.on("click", 'a[data-action="collapse"]', function (e) {
      e.preventDefault();
      var card = $(this).closest('.card');
      card.find('[data-action="collapse"] i').toggleClass('ti-minus ti-plus');
      card.children('.card-body').collapse('toggle');
    });
  
    // Toggle fullscreen
    doc.on("click", 'a[data-action="expand"]', function (e) {
      e.preventDefault();
      var card = $(this).closest('.card');
      card.find('[data-action="expand"] i').toggleClass('mdi-arrow-expand mdi-arrow-compress');
      card.toggleClass('card-fullscreen');
    });
  
    // Close Card
    doc.on('click', 'a[data-action="close"]', function () {
      $(this).closest('.card').removeClass().slideUp('fast');
    });
  });