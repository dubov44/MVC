using CustomLibrary;
using mvc_dz1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dz1.Controllers
{
    public class ReviewController : Controller
    {
        public ActionResult Index() //вывод всех отзывов
        {
            var list = new List<Review>();
            using (var context = new ProjectContext())
            {
                list = context.Reviews.OrderByDescending(a => a.ReviewId).ToList(); //первый комментарий будет снизу
            }
            return View(list);
        }

        public RedirectResult AddReview(string Name, string Text) //добавление комментария
        {
            using (var context = new ProjectContext())
            {
                context.Reviews.Add(new Review() //принимаем данные из формы
                {
                    Name = Name,
                    ReviewText = Text,
                    Date = DateTime.Now
                });
                
                context.SaveChanges(); //добавляем в бд
            }
            return Redirect("/Review/Index");
        }
    }
}