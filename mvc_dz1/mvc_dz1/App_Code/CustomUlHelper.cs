using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dz1.App_Code
{
    public static class CustomUlHelper
    {
        //хелпер для создания опросника
		public static MvcHtmlString CreateUl(this HtmlHelper html, List<string> items, string name)
		{
            //создаем столбцы
			var ol = new TagBuilder("ol");
			ol.MergeAttribute("name", name);
            ol.AddCssClass("list-unstyled");

            //создаем строки
            foreach (string item in items)
			{
				var li = new TagBuilder("li");
                li.AddCssClass("d-flex flex-column");

                var div = new TagBuilder("div");
                var label = new TagBuilder("label");
                label.SetInnerText(item);
                var option = new TagBuilder("input");
                option.MergeAttribute("name", "check");
                option.MergeAttribute("value", item);
                option.MergeAttribute("type", "checkbox");
                var checkbox = new TagBuilder("input");
                checkbox.MergeAttribute("type", "checkbox");
                checkbox.MergeAttribute("style", "visibility: hidden;");
                div.InnerHtml += option.ToString() + label.ToString() + checkbox.ToString();
                ol.InnerHtml += div.ToString();
            }
			return new MvcHtmlString(ol.ToString());
		}

	}
}