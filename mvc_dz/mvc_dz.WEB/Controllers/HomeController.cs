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
using System.Data.Entity;
using mvc_dz.Bll.BusinessModels;

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

            var viewModel = new IndexViewModel<Post, Post>
            {
                Posts = unitOfWork.Posts.GetItemList().Where(p => p.isVisible == true).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
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

            var viewModel = new IndexViewModel<QuestionaryResult, QuestionaryResult>
            {
                Posts = unitOfWork.QuestionaryResults.GetItemList().OrderByDescending(x => x.QuestionaryResultId).ToList().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager,
                Model = new QuestionaryResult()
            };

            return View(viewModel);
        }
        public ActionResult Tags(string item, int page = 1)
        {
            Tag temp = unitOfWork.Tags.GetItemList().ToList().Where(t => t.Name == item).SingleOrDefault();

            if (temp == null)
            {
                temp = new Tag()
                {
                    Name = "Default",
                    Posts = unitOfWork.Posts.GetItemList().ToList()
                };
            }


            var pager = new Pager(temp.Posts.ToList().Count(), page, 1, 3);

            var viewModel = new IndexViewModel<Post, Tag>
            {
                Posts = temp.Posts.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager,
                Additionary = temp
            };

            return View(viewModel);
        }

        public ActionResult AddPost()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddPost(Post post, string newTags)
        {
            if (string.IsNullOrEmpty(post.Title) || string.IsNullOrEmpty(post.Content))
                return RedirectToAction("AddPost");
            Post newPost = new Post()
            {
                Title = post.Title,
                Content = post.Content,
                Date = DateTime.Now,
                AuthorId = 1,
                isVisible = true
            };

            string[] stringTags = newTags.Split(',');
            for (int i = 0; i < stringTags.Length; i++)
            {
                stringTags[i] = stringTags[i].Replace(" ", "");
                stringTags[i] = stringTags[i].ToLower();
            }

            if (!string.IsNullOrEmpty(newTags))
            {
                List<Tag> tags;
                Tag temp;
                foreach (string s in stringTags)
                {
                    temp = unitOfWork.Tags.GetItemList().SingleOrDefault(t => t.Name == s);
                    if (temp == null)
                    {
                        temp = new Tag()
                        {
                            Name = s
                        };
                        unitOfWork.Tags.Create(temp);
                    }
                    newPost.Tags.Add(temp);
                }
            }

            unitOfWork.Posts.Create(newPost);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id = 1)
        {
            if (unitOfWork.Posts.GetItem(id) == null)
                return HttpNotFound();

            Post post = unitOfWork.Posts.GetItem(id);
            string temp = "";
            if (post.Tags.Count > 0)
            {
                foreach (var t in post.Tags)
                {
                    temp += t.Name + ", ";
                }
                temp = temp.Remove((temp.Length - 2));
            }
            ViewBag.Tags = temp;
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post post, string newTags)
        {
            if (string.IsNullOrEmpty(post.Title) || string.IsNullOrEmpty(post.Content))
                return RedirectToAction("Edit", new { id = post.AuthorId});

            Post newPost = unitOfWork.Posts.GetItem(post.PostId);

            newPost.Title = post.Title;
            newPost.Content = post.Content;
            newPost.Date = DateTime.Now;

            string[] stringTags = newTags.Split(',');
            for (int i = 0; i < stringTags.Length; i++)
            {
                stringTags[i] = stringTags[i].Replace(" ", "");
                stringTags[i] = stringTags[i].ToLower();
            }

            if (!string.IsNullOrEmpty(newTags))
            {
                newPost.Tags.Clear();
                List<Tag> tags = new List<Tag>();
                Tag temp;
                foreach (string s in stringTags)
                {
                    temp = unitOfWork.Tags.GetItemList().SingleOrDefault(t => t.Name == s);
                    if (temp == null)
                    {
                        temp = new Tag()
                        {
                            Name = s
                        };
                        unitOfWork.Tags.Create(temp);
                    }
                    newPost.Tags.Add(temp);
                }
            }
            else
            {
                newPost.Tags.Clear();
            }

            unitOfWork.Posts.Update(newPost);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult DeletePost(int id = 1)
        {
            Post post = unitOfWork.Posts.GetItem(id);
            post.isVisible = false;

            unitOfWork.Posts.Update(post);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}