$(function () {
    window.pageIndex = $("#index").text() - 0;//全局变量，页索引
    window.tolPage = $("#tolPage").text() - 0;//全局变量，总页数
});
//删除判断
function btn_delete() {
    return confirm("确认删除该用户？");
};
//添加分类非空判断
function isNullOrEmpty() {
    var name = $("#txtName").val();
    if (name == "") {
        alert("请输入要添加的书籍分类名！");
        return false;
    }
    else
        return true;
};
//首页
function FirstPage() {
    window.location.href = "/Home/CategoryList/1";
};
//上一页
function PageUp() {
    if (pageIndex > 1)
        pageIndex = pageIndex - 1;
    window.location.href = "/Home/CategoryList/" + pageIndex;
};
//下一页
function PageDown() {
    if (pageIndex < tolPage)
        pageIndex = pageIndex + 1;
    window.location.href = "/Home/CategoryList/" + pageIndex;
};
//尾页
function LastPage() {
    window.location.href = "/Home/CategoryList/" + tolPage;
};
