using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomLibrary;

namespace mvc_dz1.App_Code
{
    public static class ReviewDisplayer
    {
        //хелпер для отображения отзывов
        public static MvcHtmlString CreateReviews(this HtmlHelper html,
               List<Review> reviews)
        {
            var ol = new TagBuilder("ol"); //таблица для всех отзывов
            ol.AddCssClass("list-unstyled");
            for (int index = 0; index < reviews.Count; index++) //создание индивидуального отзыва
            {
                var li = new TagBuilder("li");
                li.AddCssClass("card mb-4");
                var h2 = new TagBuilder("h2");
                h2.SetInnerText(reviews[index].Name);
                h2.AddCssClass("card-header");
                var div = new TagBuilder("div");
                div.AddCssClass("card-body");
                var pText = new TagBuilder("p");
                pText.SetInnerText(reviews[index].ReviewText);
                pText.AddCssClass("card-text");
                var pDate = new TagBuilder("p");
                pDate.SetInnerText(reviews[index].Date.ToString());
                pDate.AddCssClass("card-footer text-muted");
                div.InnerHtml += pText.ToString();
                li.InnerHtml += h2.ToString() + div.ToString() + pDate.ToString();
                ol.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ol.ToString());
        }
    }
}