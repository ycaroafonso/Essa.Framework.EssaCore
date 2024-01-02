namespace Essa.Framework.Web.Util
{
    using Essa.Framework.Util.Models.Helpers.Select2;
    using Extensions;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public static class Util
    {

        public static List<SelectListItem> SimNao()
        {
            return Framework.Util.Geral.SimNao().ToSelectList(x => x.Key, y => y.Value);
        }
        public static List<SelectListItem> SimNao(string valorSelecionado)
        {
            return Framework.Util.Geral.SimNao().ToSelectList(x => x.Key, y => y.Value, null, null, valorSelecionado);
        }
        public static List<SelectListItem> SimNaoBooleano()
        {
            return Framework.Util.Geral.SimNaoBooleano().ToSelectList(x => x.Key, y => y.Value);
        }
        public static List<SelectListItem> SimNaoBooleano(string valorSelecionado)
        {
            return Framework.Util.Geral.SimNaoBooleano().ToSelectList(x => x.Key, y => y.Value, null, null, valorSelecionado);
        }

        [Obsolete("Retirar este método e utilizar javascript.")]
        public static List<SelectListItem> SimNaoBooleanoWithLowerCaseInValue()
        {
            return Framework.Util.Geral.SimNaoBooleano().ToSelectList(x => x.Key.ToString().ToLower(), y => y.Value);
        }
    }
}
