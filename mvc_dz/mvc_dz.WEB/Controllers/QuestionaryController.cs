using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dz.WEB.Controllers
{
    public class QuestionaryController : Controller
    {        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form) //форма с результатами опроса
        {
            ViewBag.Person = form["Name"] + " " + form["Surname"];
            ViewBag.Sex = form["gender"];
            ViewBag.Languages = form["check"];


            return View("~/Views/Questionary/Result.cshtml");
        }
    }
}