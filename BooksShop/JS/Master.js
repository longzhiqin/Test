/// <reference path="jquery-1.8.0.min.js" />
$(function () {
    //导航树图片点击事件
    $(".img1").toggle(function () {
        $(this)[0].src = "../../Images/Home/tree/expand.gif";
        $(this).parent().next().hide();
    }, function () {
        $(this)[0].src = "../../Images/Home/tree/collapse.gif";
        $(this).parent().next().show();
    });
});