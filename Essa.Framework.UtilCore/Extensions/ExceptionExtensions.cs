using System;

namespace Essa.Framework.Util.Extensions
{
    public static class ExceptionExtensions
    {
        
        public static string ToMensagemErro(this Exception e, int nivel = 0)
        {
            if (e.InnerException == null) return e.Message;
            else return e.Message + "<br/>" + e.InnerException.ToMensagemErro(nivel++).PadRight(nivel, '-');
        }
    }
}
