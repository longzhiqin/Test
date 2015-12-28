using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace test.Models
{
    public static class HtmlTagHelper
    {
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="tolRecord"></param>
        /// <param name="pageSize"></param>
        /// <param name="showPage"></param>
        /// <returns></returns>
        public static MvcHtmlString MyPager(this HtmlHelper helper, int tolRecord, int pageSize, int showPage)
        {
            int tolPage = (int)Math.Ceiling(tolRecord * 1.0 / pageSize);//总页数
            string controller = helper.ViewContext.RouteData.Values["controller"].ToString();//获取控制器
            string action = helper.ViewContext.RouteData.Values["action"].ToString();//获取action
            int pageIndex = 1;//页索引
            object obj = helper.ViewContext.RouteData.Values["id"];
            if (obj != null)
                pageIndex = Convert.ToInt32(obj);
            int pageStart;
            int num = showPage % 2 == 0 ? showPage / 2 : showPage / 2 + 1;
            bool sl_1=false;//判断前省略号有无
            bool sl_2=false;//判断后省略号有无
            //首页索引判断
            if (tolPage <= showPage)
            {
                pageStart = 1;
                sl_1=false;
                sl_2=false;
            }
            else
            {
                if (pageIndex <= num)
                {
                    pageStart = 1;
                    sl_1=false;
                    sl_2=true;
                }
                else if (pageIndex <= tolPage && pageIndex > tolPage - num)
                {
                    pageStart = tolPage - showPage+1;
                    sl_1=true;
                    sl_2=false;
                }
                else
                {
                    pageStart = pageIndex - num + 1;
                    sl_1=true;
                    sl_2=true;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='dv'>");
            //首页
            if (pageIndex == 1)
                sb.Append("<a class='firstShow' >首页</a>");
            else
                sb.AppendFormat("<a href='/{0}/{1}/{2}'>首页</a>", controller, action, 1);
            //前省略号
            if (sl_1)
                sb.Append("<a style='border:0px;'>...</a>");
            //页索引
            for (int i = pageStart; i < (pageStart + showPage) && (pageStart + showPage-1) <= tolPage; i++)
            {
                if (i == pageIndex)
                    sb.AppendFormat("<a class='selected' href='/{0}/{1}/{2}'>{3}</a>", controller, action, i, i);
                else
                    sb.AppendFormat("<a href='/{0}/{1}/{2}'>{3}</a>", controller, action, i, i);
            }
            //后省略号
            if (sl_2)
                sb.Append("<a style='border:0px;'>...</a>");
            //尾页
            if (pageIndex == tolPage)
                sb.Append("<a class='lastShow'>尾页</a>");
            else
                sb.AppendFormat("<a href='/{0}/{1}/{2}'>尾页</a>", controller, action, tolPage);
            sb.Append("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}