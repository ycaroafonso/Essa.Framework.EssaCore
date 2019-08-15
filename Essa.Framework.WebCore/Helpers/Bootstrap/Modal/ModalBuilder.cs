namespace Essa.Framework.WebCore.Helpers.Bootstrap.Modal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Routing;

    public interface IModalAddBotao : IDisposable
    {
        IModalAddBotao AddBotaoRodape(string id, string texto, object htmlAttributes = null);
    }

    public class ModalBuilder : IModalAddBotao
    {
        private string _id;
        private ViewContext _html;
        private Queue<string> _botoes;

        public ModalBuilder(string id)
        {
            _id = id;
        }

        public ModalBuilder(string id, ViewContext html)
        {
            _botoes = new Queue<string>();
            _id = id;
            _html = html;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tituloBotao"></param>
        /// <param name="url">URL ou Javascript que retorna a URL</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public MvcHtmlString BotaoComModalAjax(string tituloBotao, string url, Action<IModalAddBotao> config = null)
        {
            _botoes = new Queue<string>();
            string resolveUrl = ""; // VirtualPathUtility.ToAbsolute("~/");

            config?.Invoke(this);

            string html = string.Format(@"
<button class=""btn default"" onclick=""Modal('{0}').Ajax({5}).Abrir()"">{1}</button>
{2}
<img src=""{3}"" alt="""" class=""loading"" />
<span>
    &nbsp;&nbsp;Loading...
</span>
{4}
", _id, tituloBotao, Parte1(tituloBotao), "assets/global/img/loading-spinner-grey.gif", Parte2()
    , url.StartsWith("~/") ? "link.attr(\"href\")" : url);

            return new MvcHtmlString(html.ToString());
        }


        public IModalAddBotao BotaoComModalSimples(string tituloBotao, string tituloModal, object htmlAttributesBotao = null)
        {
            string parametros = string.Empty;

            if (htmlAttributesBotao != null)
                parametros = string.Join(" ", new RouteValueDictionary(htmlAttributesBotao).ParametrosParaString());

            string str = string.Format(@"<a data-toggle=""modal"" href=""#{0}"" {3}>{2}</a>
<div class=""modal fade"" id=""{0}"" tabindex=""-1"" role=""basic"" aria-hidden=""true"">
	<div class=""modal-dialog"">
		<div class=""modal-content"">
			<div class=""modal-header"">
				<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true""></button>
				<h4 class=""modal-title"">{1}</h4>
			</div>
			<div class=""modal-body"">", _id, tituloModal, tituloBotao, parametros);

            _html.Writer.Write(str);

            return this;
        }


        public IModalAddBotao Modal(string tituloModal)
        {
            _html.Writer.Write(Parte1(tituloModal));

            return this;
        }

        public IModalAddBotao ModalGrande(string tituloModal)
        {
            _html.Writer.Write(string.Format(@"
<div class=""modal fade"" id=""{0}"" tabindex=""-1"" role=""basic"" aria-hidden=""true"">
	<div class=""modal-dialog modal-lg"">
		<div class=""modal-content"">
			<div class=""modal-header"">
				<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true""></button>
				<h4 class=""modal-title"">{1}</h4>
			</div>
			<div class=""modal-body"">", _id, tituloModal));

            return this;
        }


        public IModalAddBotao AddBotaoRodape(string id, string texto, object htmlAttributes = null)
        {
            RouteValueDictionary attr;

            if (htmlAttributes == null)
                attr = new RouteValueDictionary();
            else
                attr = new RouteValueDictionary(htmlAttributes);


            attr["id"] = attr["id"] ?? id;
            attr["class"] = attr["class"] ?? "btn";
            attr["type"] = attr["type"] ?? "button";

            string parametros = attr.ParametrosParaString();

            _botoes.Enqueue(string.Concat("<button ", parametros, ">", texto, "</button>"));
            return this;
        }


        private string Parte1(string tituloModal)
        {
            return string.Format(@"
<div class=""modal fade"" id=""{0}"" tabindex=""-1"" role=""basic"" aria-hidden=""true"">
	<div class=""modal-dialog"">
		<div class=""modal-content"">
			<div class=""modal-header"">
				<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true""></button>
				<h4 class=""modal-title"">{1}</h4>
			</div>
			<div class=""modal-body"">", _id, tituloModal);
        }
         
        private string Parte2()
        {
            string html = @"</div><div class=""modal-footer"">";

            while (_botoes.Any())
                html += _botoes.Dequeue();

            html += "</div></div></div></div>";

            return html;
        }

        public void Dispose()
        {
            _html.Writer.Write(Parte2());
        }
    }
}
