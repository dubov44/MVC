using mvc_dz.DAL.Tables;
using mvc_dz.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_dz.DAL;
using mvc_dz.WEB.Models;
using mvc_dz.Bll.BusinessModels;

namespace mvc_dz.WEB.Controllers
{
    public class ReviewController : Controller
    {
        UnitOfWork unitOfWork;
        public ReviewController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index(int page = 1) //вывод всех отзывов
        {

            var pager = new Pager(unitOfWork.Reviews.GetItemList().ToList().Count(), page, 1, 3);

            var viewModel = new IndexViewModel<Review, Review>
            {
                Posts = unitOfWork.Reviews.GetItemList().OrderByDescending(x => x.ReviewId).ToList().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager,
                Model = new Review()
            };

            return View(viewModel);
        }

        public RedirectResult AddReview(IndexViewModel<Review, Review> review) //добавление комментария
        {
            if (string.IsNullOrWhiteSpace(review.Model.Name))
            {
                ModelState.AddModelError
                    ("AuthorName", "Name must contain someting");
            }
            if (ModelState.IsValid)
            {
                ModelState.AddModelError
                    ("Name", "Name must contain someting");
                unitOfWork.Reviews.Create(review.Model);
                unitOfWork.Reviews.Save();
                return Redirect("/Review/Index");
            }
        //    unitOfWork.Reviews.Create(new Review() //принимаем данные из формы
        //    {
        //        Name = Name,
        //        ReviewText = Text,
        //        Date = DateTime.Now
        //    });
        //    unitOfWork.Reviews.Save(); //добавляем в бд
            return Redirect("/Review/Index");
        }
    }
}