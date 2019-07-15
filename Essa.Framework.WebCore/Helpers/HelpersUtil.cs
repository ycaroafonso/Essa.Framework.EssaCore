using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essa.Framework.WebCore.Helpers
{
    public static class HelpersUtil
    {
        public static string ParametrosParaString(this RouteValueDictionary valor)
        {
            return string.Join(" ", valor.Select(c => string.Concat(c.Key.Replace("_", "-"), "=\"", c.Value, "\"")).ToArray());
        }
    }
}
