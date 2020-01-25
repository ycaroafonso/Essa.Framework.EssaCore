namespace Essa.Framework.Web.Util
{
    using Extensions;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class Util
    {

        public static SelectList SimNao()
        {
            return Framework.Util.Geral.SimNao().ToSelectList(x => x.Key, y => y.Value);
        }
        public static SelectList SimNao(string valorSelecionado)
        {
            return Framework.Util.Geral.SimNao().ToSelectList(x => x.Key, y => y.Value, null, null, valorSelecionado);
        }
    }
}
