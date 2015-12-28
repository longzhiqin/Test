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
    public class HomeController : Controller
    {
        BookShopPlusEntities bsp = new BookShopPlusEntities();
        //
        // GET: /Home/
        [Authorize()]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Current()
        {
            string controllerName = RouteData.Values["controller"].ToString();
            string actionName = RouteData.Values["action"].ToString();
            return Content("<script>alert('" + controllerName + "," + actionName + "');</script>");
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginPage","User");
        }
        /// <summary>
        /// 状态管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult StateManage()
        {
            int index = 1;//页索引
            object obj = RouteData.Values["id"];
            if (obj != null)
                index = Convert.ToInt32(obj);
            var users = bsp.Users.OrderBy(x=>x.Id).Skip(index*5-5).Take(5).ToList();
            var TolRecord=bsp.Users.Count();
            var TolPage=(int)Math.Ceiling(TolRecord*1.0/5);
            ViewBag.index = index;
            ViewBag.TolRecord = TolRecord;
            ViewBag.TolPage = TolPage;
            return View(users);
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            int index = 1;//页索引
            object obj = RouteData.Values["id"];
            if (obj != null)
                index = Convert.ToInt32(obj);
            var users = bsp.Users.OrderBy(x => x.Id).Skip(index * 5 - 5).Take(5).ToList();
            var TolRecord = bsp.Users.Count();
            var TolPage = (int)Math.Ceiling(TolRecord * 1.0 / 5);
            ViewBag.index = index;
            ViewBag.TolRecord = TolRecord;
            ViewBag.TolPage = TolPage;
            return View(users);
        }
        /// <summary>
        /// 用户信息详情
        /// </summary>
        /// <returns></returns>
        public ActionResult UserDetailis(int Id)
        {
            var user = bsp.Users.Single(m=>m.Id==Id);
            return View(user);
        }
        /// <summary>
        /// 书籍分类列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CategoryList()
        {
            int index = 1;
            if (RouteData.Values["id"]!=null)
                index = Convert.ToInt32(RouteData.Values["id"]);
            int tolRecord = bsp.Categories.Count();
            int tolPage = (int)Math.Ceiling(tolRecord*1.0/5);
            var categories = bsp.Categories.OrderBy(x=>x.Id).Skip((index-1)*5).Take(5).ToList();
            ViewBag.index = index;
            ViewBag.TolRecord = tolRecord;
            ViewBag.TolPage = tolPage;
            return View(categories);
        }
        /// <summary>
        /// 删除书籍分类
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DeleteCategory(int Id)
        {
            var bks= bsp.Books.Where(x=>x.CategoryId==Id);//是否有使用该书籍分类的书籍
            if (bks.Count() > 0)
                return Content("<script>alert('该分类正被使用，请先删除相应书籍，再删除该分类！');window.location.href='/Home/CategoryList';</script>");
            else
            {
                Categories cate = new Categories
                {
                    Id = Id
                };
                DbEntityEntry dbe = bsp.Entry(cate);
                dbe.State = EntityState.Deleted;
                string result = bsp.SaveChanges() > 0 ? "删除成功！" : "删除失败！";
                return Content("<script>alert('"+result+"');window.location.href='/Home/CategoryList';</script>");
            }
        }
        /// <summary>
        /// 添加书籍分类
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCategory()
        {
            string name = Request["txtName"].ToString();
            var cate = bsp.Categories.SingleOrDefault(x=>x.Name==name);
            if (cate != null)
                return Content("<script>alert('该分类名已经存在！');window.location.href='/Home/CategoryList';</script>");
            else
            {
                Categories cg = new Categories { 
                 Name  =name
                };
                DbEntityEntry dbe = bsp.Entry(cg);
                dbe.State = EntityState.Added;
                string result = bsp.SaveChanges() > 0 ? "添加成功！" : "添加失败！";
                return Content("<script>alert('"+result+"');window.location.href='/Home/CategoryList';</script>");
            }
        }
    }
}
