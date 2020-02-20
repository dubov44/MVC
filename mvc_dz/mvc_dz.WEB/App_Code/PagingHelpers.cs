using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using mvc_dz.WEB.Models;
using mvc_dz.Bll.BusinessModels;

namespace mvc_dz.WEB.App_Code
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
         Pager pager, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            
            if(pager.EndPage > 1)
            {
                TagBuilder u = new TagBuilder("u");
                u.AddCssClass("pagination");
                if (pager.CurrentPage > 1)
                {
                    TagBuilder liPrev = new TagBuilder("li");
                    TagBuilder aPrev = new TagBuilder("a");
                    aPrev.MergeAttribute("href", pageUrl(pager.CurrentPage - 1));
                    aPrev.SetInnerText("Previous");
                    liPrev.InnerHtml += aPrev;
                    u.InnerHtml += liPrev;
                }
                TagBuilder liFirst = new TagBuilder("li");
                liFirst.AddCssClass(pager.CurrentPage == 1 ? "active" : "");
                TagBuilder aFirst = new TagBuilder("a");
                aFirst.MergeAttribute("href", pageUrl(1));
                aFirst.SetInnerText("1");
                liFirst.InnerHtml += aFirst;
                u.InnerHtml += liFirst;

                if(pager.CurrentPage > 2 &&
                    pager.StartPage != 2 &&
                    pager.StartPage + 1 != 2 &&
                    pager.TotalItems != pager.PagerLength)
                {
                    TagBuilder liDots = new TagBuilder("li");
                    TagBuilder aDots = new TagBuilder("a");
                    aDots.SetInnerText("...");
                    liDots.InnerHtml += aDots;
                    u.InnerHtml += liDots;
                }

                for(var _page = pager.StartPage; _page <= pager.EndPage; _page++)
                {
                    if (_page != 1)
                    {
                        if (_page != pager.TotalPages)
                        {
                            TagBuilder liPage = new TagBuilder("li");
                            liPage.AddCssClass(_page == pager.CurrentPage ? "active" : "");
                            TagBuilder aPage = new TagBuilder("a");
                            aPage.MergeAttribute("href", pageUrl(_page));
                            aPage.SetInnerText(_page.ToString());
                            liPage.InnerHtml += aPage;
                            u.InnerHtml += liPage;
                        }
                    }
                }

                if (pager.CurrentPage < pager.TotalPages - 1 &&
                    pager.EndPage != pager.TotalPages - 1 &&
                    pager.EndPage != pager.TotalPages &&
                    pager.TotalItems != pager.PagerLength)
                {
                    TagBuilder liDots = new TagBuilder("li");
                    TagBuilder aDots = new TagBuilder("a");
                    aDots.SetInnerText("...");
                    liDots.InnerHtml += aDots;
                    u.InnerHtml += liDots;
                }

                TagBuilder liLast = new TagBuilder("li");
                liLast.AddCssClass(pager.CurrentPage == pager.TotalPages ? "active" : "");
                TagBuilder aLast = new TagBuilder("a");
                aLast.MergeAttribute("href", pageUrl(pager.TotalPages));
                aLast.SetInnerText(pager.TotalPages.ToString());
                liLast.InnerHtml += aLast;
                u.InnerHtml += liLast;

                if(pager.CurrentPage < pager.TotalPages)
                {
                    TagBuilder liNext = new TagBuilder("li");
                    TagBuilder aNext = new TagBuilder("a");
                    aNext.MergeAttribute("href", pageUrl(pager.CurrentPage + 1));
                    aNext.SetInnerText("Next");
                    liNext.InnerHtml += aNext;
                    u.InnerHtml += liNext;
                }

                result.Append(u);
            }
            
            return MvcHtmlString.Create(result.ToString());
        }
    }
}