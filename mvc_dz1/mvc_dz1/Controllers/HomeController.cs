using mvc_dz1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomLibrary;

namespace mvc_dz1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //главная страница
        {
            var list = new List<Post>(); //все посты
            using (var context = new ProjectContext())
            {
                list = context.Posts.ToList();
            }
            return View(list);
        }
    }
}