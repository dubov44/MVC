using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dz1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guest(string Name, string Text)
        {
            ViewBag.AddText = false;
            if(!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Text))
            {
                ViewBag.AddText = true;
                ViewBag.Name = Name;
                ViewBag.Text = Text;
            }

            return View();
        }


        [HttpGet]
        public ActionResult Form()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Form(FormCollection form)
        {
            ViewBag.Person = form["Name"] + " " + form["Surname"];
            ViewBag.Sex = form["gender"];
            ViewBag.Languages = form["check"];


            return View("~/Views/Home/Result.cshtml");
        }
    }
}