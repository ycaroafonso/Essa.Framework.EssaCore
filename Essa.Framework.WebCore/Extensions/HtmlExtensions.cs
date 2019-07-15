namespace Essa.Framework.WebCore.Extensions
{
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlExtensions
    {
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<RouteValueDictionary> customHtmlAttributes)
        {
            RouteValueDictionary htmlAttributes = new RouteValueDictionary();
            customHtmlAttributes(htmlAttributes);
            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }
    }
}
