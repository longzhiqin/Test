using BooksShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BooksShop.Controllers
{
    public class UserController : Controller
    {
        BookShopPlusEntities bsp = new BookShopPlusEntities();//上下文

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginPage()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            string userName = Request.Form["txtUserName"].ToString();
            string userPwd = Request.Form["txtUserPwd"].ToString();
            var user = bsp.Users.SingleOrDefault(x => x.LoginId == userName);
            if (user == null)
                return Content("<script>alert('用户名不存在！');window.location.href='/User/LoginPage';</script>");
            else if (user.LoginPwd == userPwd)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                return RedirectToAction("Index", "Home");
            }
            else
                return Content("<script>alert('密码错误！');window.location.href='/User/LoginPage'</script>");
        }
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [Authorize()]
        public ActionResult HomePage()
        {
            return View();
        }
        /// <summary>
        /// 未登录
        /// </summary>
        /// <returns></returns>
        public ActionResult NotLogin()
        {
            return View();
        }
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdeteState()
        {
            string userName = Request.Form["userName"].ToString();

            var user = bsp.Users.Single(x => x.LoginId == userName);
            if (user.UserStateId == 1)
                user.UserStateId = 2;
            else
                user.UserStateId = 1;
            DbEntityEntry dbe = bsp.Entry(user);
            dbe.State = EntityState.Modified;
            var i = bsp.SaveChanges();
            return Json(null);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(int Id)
        {
            Users user = new Users
            {
                Id = Id
            };
            DbEntityEntry dbe = bsp.Entry(user);
            dbe.State = EntityState.Deleted;
            if (bsp.SaveChanges() > 0)
                return RedirectToAction("UserList", "Home");
            else
                return Content("<script>alert('删除失败！');window.location.href='/Home/UserList'</script>");
        }
        public ActionResult SaveUser(Users user)
        {
            var us = bsp.Users.Single(x=>x.Id==user.Id);
            us.Mail = user.Mail;
            us.Name = user.Name;
            us.Phone = user.Phone;
            us.Address = user.Address;
            DbEntityEntry dbe = bsp.Entry(us);
            dbe.State = EntityState.Modified;
            string result = bsp.SaveChanges() > 0 ? "保存成功！" : "保存失败！";
            return Content("<script>alert('"+result+"');window.location.href='/Home/UserList';</script>");
        }
    }
}
