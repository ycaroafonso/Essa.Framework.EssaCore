namespace Essa.Framework.WebCore.Helpers.Bootstrap.Accordion
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    


    public class AccordionBuilder : IDisposable
    {
        private string _id;
        private ViewContext _html;
        int _index = 0;

        public AccordionBuilder(ViewContext html, string id)
        {
            _html = html;
            _id = id;

            _html.Writer.Write(string.Concat("<div class=\"panel-group\" id=\"", _id, "\" role=\"tablist\" aria-multiselectable=\"true\"><div class=\"panel panel-default\">"));
        }


        public AccordionItemBuilder Item(string titulo, bool isAberto = false)
        {
            return new AccordionItemBuilder(_html, _id, titulo, string.Concat(_id, "_item_", _index++), isAberto);
        }

        public void Dispose()
        {
            _html.Writer.Write("</div></div>");
        }
    }

    public class AccordionItemBuilder : IDisposable
    {
        ViewContext _html;

        public AccordionItemBuilder(ViewContext html, string idPai, string titulo, string idAba, bool isAberto)
        {
            _html = html;

            _html.Writer.Write(string.Format(@"<div class=""panel panel-default"">
		                            <div class=""panel-heading"">
			                            <h4 class=""panel-title"">
				                            <a class=""accordion-toggle"" data-toggle=""collapse"" data-parent=""#{0}"" href=""#{1}"" aria-expanded=""true"">{2}<span id=""span_{0}""></span></a>
			                            </h4>
		                            </div>
		                            <div id=""{1}"" class=""panel-collapse collapse {3}"" aria-expanded=""{4}"">
                                        <div class=""panel-body"">", idPai, idAba, titulo, isAberto ? "in" : string.Empty, isAberto.ToString().ToLower()));
        }

        public void Dispose()
        {
            _html.Writer.Write(@"</div></div></div>");
        }
    }
}
