namespace Essa.Framework.Web.Helpers.Select2
{
    using Essa.Framework.Util.Models.Helpers.Select2;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public static class Select2Extensions
    {
        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, string url, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes)
                .Config(new Select2Options().SetAjax(url))
                .Montar();
        }
        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, string url, string dataValueField, string dataTextField, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes)
                .Config(new Select2Options().SetAjax(new Select2Ajax(url, dataValueField, dataTextField)))
                .Montar();

        }

        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, SelectList itens, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes).SetSelectList(itens).Montar();
        }

        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, SelectList itens, Select2Options select2Options, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes).Config(select2Options).SetSelectList(itens).Montar();
        }

        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, SelectList itens, Action<Select2Options> select2Options, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes).Config(c => select2Options(c)).SetSelectList(itens).Montar();
        }


        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, List<Select2Item> itens, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes).Config(c => c.data = itens).Montar();
        }
        public static IHtmlContent Select2(this HtmlHelper htmlHelper, string id, List<Select2Item> itens, Action<Select2Options> select2Options, object htmlAttributes = null)
        {
            return new Select2Builder(id, htmlAttributes).Config(c => select2Options(c)).SetSelectList(itens).Montar();
        }
        
        public static IHtmlContent Select2<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
        {
            string name = ExpressionHelper.GetExpressionText(expression);

            var x = new Select2Builder(name, htmlAttributes).SetSelectList(selectList);

            //x.Val("");

            return x.Montar();
        }

    }
}
