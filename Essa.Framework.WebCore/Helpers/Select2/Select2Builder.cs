namespace Essa.Framework.WebCore.Helpers.Select2
{
    using Essa.Framework.UtilCore.Extensions;
    using Essa.Framework.UtilCore.Models.Helpers.Select2;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Select2Builder
    {
        private readonly string _idControle;
        private Select2Options _select2Options;
        private HtmlAttributes _htmlAttributes;
        private string _complementoScript = string.Empty;


        public Select2Builder(string id)
        {
            _idControle = id;
            Inicializate(new { });
        }

        public Select2Builder(string id, object htmlAttributes)
        {
            _idControle = id;
            Inicializate(htmlAttributes);
        }

        public Select2Builder(string id, string url, object htmlAttributes = null)
        {
            _idControle = id;
            Inicializate(htmlAttributes ?? new { });

            _select2Options.SetAjax(url);
        }

        public Select2Builder SetHtmlAttributes(string chave, string valor)
        {
            _htmlAttributes[chave] = valor;

            return this;
        }

        public Select2Builder SetHtmlAttributes(bool condicao, string chave, string valor)
        {
            if (condicao)
                _htmlAttributes[chave] = valor;

            return this;
        }

        public Select2Builder SetHtmlAttributesIfNull(string chave, string valor)
        {
            _htmlAttributes[chave] = _htmlAttributes[chave] ?? valor;

            return this;
        }


        void Inicializate(object htmlAttributes)
        {
            _select2Options = new Select2Options();

            _htmlAttributes = new HtmlAttributes(htmlAttributes);

            SetHtmlAttributesIfNull("style", "width: 100%");
            SetHtmlAttributesIfNull("class", "form-control");
            SetHtmlAttributesIfNull("name", _idControle + (_select2Options.multiple ? "[]" : string.Empty));
        }


        public Select2Builder Config(Select2Options select2Options)
        {
            _select2Options = select2Options;
            return this;
        }
        public Select2Builder Config(Action<Select2Options> select2Options)
        {
            select2Options(_select2Options);
            return this;
        }

        public Select2Builder Config(string key, string value)
        {
            _complementoScript += string.Concat(".select2(\"", key, "\", \"", value, "\")");
            return this;
        }

        public Select2Builder SetSelectList(List<Select2Item> lista)
        {
            _select2Options.data = lista;
            return this;
        }

        public Select2Builder SetSelectList(IEnumerable<SelectListItem> lista)
        {
            if (lista != null)
            {
                _select2Options.data = lista.Select(c => new Select2Item { id = c.Value ?? c.Text, text = c.Text }).ToList();

                var itemSelecionado = lista.Where(c => c.Selected);
                if (itemSelecionado.Any())
                    Val(itemSelecionado.Select(c => c.Value ?? c.Text).Single());
            }
            return this;
        }


        public Select2Builder AddItem(string value, string text, bool selected = false)
        {
            _select2Options.data = new List<Select2Item>() { new Select2Item() { text = text, id = value } };

            if (selected)
                Val(value);

            return this;
        }

        [Obsolete("Usar o método AddItem(bool condicaoParaAdicionar, string value, string text, bool selected = false);")]
        public Select2Builder AddItem(Func<bool> se, string value, string text, bool selected = false)
        {
            if (se())
                AddItem(value, text, selected);

            return this;
        }

        public Select2Builder AddItem(bool condicaoParaAdicionar, string value, string text, bool selected = false)
        {
            if (condicaoParaAdicionar)
                AddItem(value, text, selected);

            return this;
        }




        public Select2Builder On(string key, string js)
        {
            _complementoScript += string.Concat(".on(\"", key, "\", ", js, ")");
            return this;
        }


        public Select2Builder Enable(bool valor = true)
        {
            _complementoScript += string.Concat(".select2(\"enable\",", valor.ToString(), ")");
            return this;
        }


        public Select2Builder Val<T>(List<T> selectedValue)
        {
            _complementoScript = string.Concat(".val(", selectedValue.ToJson(), ").change()");
            return this;
        }

        public Select2Builder Val(object selectedValue)
        {
            _complementoScript = string.Concat(".val('", selectedValue, "').change()");
            return this;
        }

        public Select2Builder Val(object selectedValue, string text)
        {
            if (selectedValue != null)
                AddItem(selectedValue.ToString(), text, true);
            return this;
        }


        public MvcHtmlString Montar()
        {
            string
                script = JsonConvert.SerializeObject(_select2Options ?? new Select2Options(), new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                }),
                id = _idControle.Replace(".", "_"),
                js = string.Format("function {0}_ToSelect2(pConfig){{ var config = $.extend({1}, pConfig == undefined ? {{}} : pConfig); $(\"#{0}\").select2(config){2}; }}jQuery(document).ready(function () {{ {0}_ToSelect2(); }});"
                                , id, script, _complementoScript);

            return new MvcHtmlString(string.Format(@"
                <script>
                    {0}
                </script>
                <select id=""{1}"" {2}></select>"
                , js, id, _htmlAttributes.ToString()));
        }

    }
}
