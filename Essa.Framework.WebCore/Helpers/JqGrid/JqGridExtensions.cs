namespace Essa.Framework.Web.Helpers.JqGrid
{
    using Framework.Util.Extensions;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System.Collections.Generic;
    using System.Linq;


    public static class JqGridExtensions
    {
        public static JqGridBuilder JqGrid(this HtmlHelper htmlHelper, string id, string url, string colunaOrdenacao)
        {
            return new JqGridBuilder(id).SetAjax(url, colunaOrdenacao);
        }

        public static JqGridBuilder JqGrid(this HtmlHelper htmlHelper, string id)
        {
            return new JqGridBuilder(id);
        }

        public static JqGridBuilder JqGrid<T>(this HtmlHelper htmlHelper, string id, IEnumerable<T> valor)
        {
            return new JqGridBuilder(id).SetData(valor);
        }


        public static JqGridReturnBuilder<T> ToJqGrid<T>(this IQueryable<T> valor, GridSettings gridSettings)
        {
            return new JqGridReturnBuilder<T>(valor, gridSettings);
        }

        public static string ToJqGrid<T>(this List<T> lista, GridSettings gridSettings)
        {
            return new JqGridReturnBuilder<T>(lista, gridSettings).Retorna.ToJson();
        }

    }
}
