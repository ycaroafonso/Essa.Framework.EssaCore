using System;
using System.Collections.Generic;
using System.Text;

namespace Essa.Framework.Util.Util
{
    public static class ConvertUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="formato">"yyyy-MM-dd HH:mm:ss,fff"</param>
        /// <returns></returns>
        public static DateTime ToDateTime(string valor, string formato = "dd/MM/yyyy")
        {
            return DateTime.ParseExact(valor, formato, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
