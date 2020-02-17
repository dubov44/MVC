using mvc_dz.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dz.WEB.App_Code
{
    public static class AnswersHelper
    {
        public static MvcHtmlString CreateAnswers(this HtmlHelper html,
               List<QuestionaryResult> answers)
        {
            var ol = new TagBuilder("ol"); //таблица для всех отзывов
            ol.AddCssClass("list-unstyled");
            for (int index = 0; index < answers.Count; index++) //создание индивидуального отзыва
            {
                var li = new TagBuilder("li");
                li.AddCssClass("card mb-4");
                var h2 = new TagBuilder("h2");
                h2.SetInnerText(answers[index].Name + " " + answers[index].Surname);
                h2.AddCssClass("card-header");
                var divBody = new TagBuilder("div");
                divBody.AddCssClass("card-body");
                var divGender = new TagBuilder("div");
                divGender.AddCssClass("");
                var bSex = new TagBuilder("b");
                bSex.SetInnerText("Sex: ");
                divGender.InnerHtml += bSex.ToString() + answers[index].Sex;

                var divTemp = new TagBuilder("div");
                divTemp.AddCssClass("");
                var b = new TagBuilder("b");
                b.SetInnerText("Languages:");
                divTemp.InnerHtml += b;
                var divLanguages = new TagBuilder("div");
                var ul = new TagBuilder("ul");
                var lang = answers[index].Languages.Split(',');
                foreach(var t in lang)
                {
                    var liLang = new TagBuilder("li");
                    liLang.SetInnerText(t);
                    ul.InnerHtml += liLang;
                }
                divLanguages.InnerHtml += ul;
                divBody.InnerHtml += divGender.ToString() + divTemp.ToString() + divLanguages.ToString();
                li.InnerHtml += h2.ToString() + divBody.ToString();
                ol.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ol.ToString());
        }
    }
}