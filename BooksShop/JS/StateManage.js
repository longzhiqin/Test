/// <reference path="jquery-1.8.0.min.js" />
$(function () {
    //加载显示用户状态
    var tr = $(".state");
    tr.each(function (index, item) {
        var text = $(item).text();
        if (text == 1)
            $(item).text("正常");
        else
            $(item).text("无效");
    });
    //全选
    $("#ckb_Limits").click(function () {
        var isChenked = $(this).attr("checked") == "checked" ? true : false;
         $("input[type='checkbox']").attr("checked",isChenked);
    });

    window.pageIndex = $("#index").text() - 0;//全局变量，页索引
    window.tolPage = $("#tolPage").text() - 0;//全局变量，总页数
});

//启用用户
var QiYong = function () {
    var hasCheck = false;
    $("input[type='checkbox']").each(function (index,item) {
        if ($(item).attr("checked") == "checked") {
            hasCheck = true;
            return;
        }
    });
    if (hasCheck) {
        $("input[type='checkbox']").not("#ckb_Limits").each(function (index, item) {
            if ($(item).attr("checked") == "checked") {
                var userName = $(item).parent().parent().find(".LoginId").text();
                //window.location.href = "";
                var userState = $(item).parent().parent().find(".state").text();
                if (userState=="无效") {
                    $.post("/User/UpdeteState", "userName=" + userName, function (msg) {
                        $(item).parent().parent().find(".state").text("正常");
                    });
                }
            }
        });
    }
    else
        alert("请选择要启用的用户！");
};
//禁用用户
function JinYong() {
    var hasCheck = false;
    $("input[type='checkbox']").each(function (index, item) {
        if ($(item).attr("checked") == "checked") {
            hasCheck = true;
            return;
        }
    });
    if (hasCheck) {
        $("input[type='checkbox']").not("#ckb_Limits").each(function (index, item) {
            if ($(item).attr("checked") == "checked") {
                var userName = $(item).parent().parent().find(".LoginId").text();
                //window.location.href = "";
                var userState = $(item).parent().parent().find(".state").text();
                if (userState == "正常") {
                    $.post("/User/UpdeteState", "userName=" + userName, function (msg) {
                        $(item).parent().parent().find(".state").text("无效");
                    });
                }
            }
        });
    } else {
        alert("请选择要禁用的用户！");
    }
};
//首页
function FirstPage() {
    window.location.href = "/Home/StateManage/1";
};
//上一页
function PageUp() {
    if (pageIndex > 1)
        pageIndex = pageIndex - 1;
    window.location.href = "/Home/StateManage/" + pageIndex;
};
//下一页
function PageDown() {
    if (pageIndex < tolPage)
        pageIndex = pageIndex + 1;
    window.location.href = "/Home/StateManage/" + pageIndex;
};
//尾页
function LastPage() {
    window.location.href = "/Home/StateManage/" + tolPage;
};