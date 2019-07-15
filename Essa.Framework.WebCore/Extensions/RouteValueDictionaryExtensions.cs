namespace Essa.Framework.WebCore.Extensions
{
    using Microsoft.AspNetCore.Routing;
    using System.Linq;


    public static class RouteValueDictionaryExtensions
    {
        public static RouteValueDictionary Concat(this RouteValueDictionary lista, RouteValueDictionary lista2)
        {
            lista2.ToList().ForEach(c => lista.Add(c.Key, c.Value));
            return lista;
        }

        public static RouteValueDictionary Add(this RouteValueDictionary lista, object objLista)
        {
            return lista;
        }
        public static RouteValueDictionary Add2(this RouteValueDictionary lista, string key, object value)
        {
            lista.Add(key, value);
            return lista;
        }

        public static RouteValueDictionary AddIfTrue(this RouteValueDictionary lista, bool isadd, string key, object value)
        {
            if (isadd)
                lista.Add(key, value);
            return lista;
        }
    }
}
