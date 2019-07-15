namespace Essa.Framework.WebCore.Helpers.Bootstrap.DropDown
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNetCore.Mvc;


    public class DropDownBuilder
    {
        private string _id
            , _texto;
        private ViewContext _html;
        private List<DropDownItem> _itens;

        public DropDownBuilder(string id, ViewContext html)
        {
            _id = id;
            _html = html;
            _itens = new List<DropDownItem>();
        }

        public DropDownBuilder AddItem(List<DropDownItem> itens)
        {
            _itens.AddRange(itens);
            return this;
        }

        public DropDownBuilder AddItem(DropDownItem item)
        {
            _itens.Add(item);
            return this;
        }

        public DropDownBuilder Texto(string texto)
        {
            _texto = texto;
            return this;
        }


        public MvcHtmlString Montar()
        {
            return new MvcHtmlString(string.Format(@"
<div class=""dropdown"" id=""{1}"">
	<button class=""btn btn-default dropdown-toggle"" type=""button"" id=""{1}_btn"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""true"">
		<span>{0}</span>
		<span class=""caret""></span>
	</button>
	<ul class=""dropdown-menu"" aria-labelledby=""dropdownMenu1"">
		{2}
	</ul>
</div>"
, _texto
, _id
, string.Join("", _itens.Select(c => c.ToString()))
));
        }
    }


    public class DropDownItem
    {
        public DropDownItem(string titulo)
        {
            Titulo = titulo;
        }
        public DropDownItem(string titulo, string onclick)
        {
            Titulo = titulo;
            OnClick = onclick;
        }

        public string Titulo { get; set; }
        public string OnClick { get; set; }

        public new string ToString()
        {
            return string.Concat("<li><a href=\"javascript:void(0)\" onclick=\"", OnClick, "\">", Titulo, "</a></li>");
        }
    }
}
