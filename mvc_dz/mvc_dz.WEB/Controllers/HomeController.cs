using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_dz.DAL.Tables;
using mvc_dz.DAL.Context;
using mvc_dz.DAL;
using mvc_dz.WEB.Models;
using PagedList.Mvc;
using PagedList;
using mvc_dz.DAL.Interfaces;
using mvc_dz.DAL.Repository;
using System.Web.UI;

namespace mvc_dz.WEB.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;

        //IRepository<Post> postRep;

        public HomeController() //(IRepository<Post> p)
        {
            unitOfWork = new UnitOfWork();
            //postRep = p;
        }
        public ActionResult Index(int page = 1) //главная страница
        {

            var pager = new Pager(unitOfWork.Posts.GetItemList().ToList().Count(), page, 3, 2);

            var viewModel = new IndexViewModel<Post>
            {
                Posts = unitOfWork.Posts.GetItemList().ToList().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
                Model = new Post()

            };

            return View(viewModel);
        }
        public ActionResult Post(int? id) //показ авторов
        {
            Post post = unitOfWork.Posts.GetItem(3);
            int postId = id.GetValueOrDefault();
            if (postId != 0) //если айди в строке есть
            {
                var selected = unitOfWork.Posts.GetItem(postId);

                if (selected == null) //если нету
                    post = unitOfWork.Posts.GetItem(3);
                else
                    post = selected;
                
                
            }
            return View(post);//возвращаем во view
        }

        [HttpPost]
        public ActionResult Index(FormCollection form) //форма с результатами опроса
        {
            if (string.IsNullOrEmpty(form["Name"]) ||
                string.IsNullOrEmpty(form["Surname"]) ||
                string.IsNullOrEmpty(form["gender"]) ||
                string.IsNullOrEmpty(form["check"]))
                {
                return RedirectToAction("Index");
                }
            unitOfWork.QuestionaryResults.Create(new QuestionaryResult()
            {
                Name = form["Name"],
                Surname = form["Surname"],
                Sex = form["gender"],
                Languages = form["check"]
            });
            unitOfWork.QuestionaryResults.Save(); //добавляем в бд


            return RedirectToAction("Index");
        }
        public ActionResult Answers(int page = 1)
        {
            var pager = new Pager(unitOfWork.QuestionaryResults.GetItemList().ToList().Count(), page, 100, 3);

            var viewModel = new IndexViewModel<QuestionaryResult>
            {
                Posts = unitOfWork.QuestionaryResults.GetItemList().OrderByDescending(x => x.QuestionaryResultId).ToList().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager,
                Model = new QuestionaryResult()
            };

            return View(viewModel);
        }
    }
}