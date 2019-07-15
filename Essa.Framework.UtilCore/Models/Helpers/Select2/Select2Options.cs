namespace Essa.Framework.UtilCore.Models.Helpers.Select2
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;


    public class Select2Options
    {
        public JRaw dropdownParent { get; set; }
        public Select2Options SetDropDownParent(string str)
        {
            dropdownParent = new JRaw(str);
            return this;
        }





        public Select2Options SetAjax(Select2Ajax select2Ajax)
        {
            ajax = select2Ajax;
            minimumInputLength = 3;
            return this;
        }
        public Select2Options SetAjax(string url)
        {
            ajax = new Select2Ajax(url);
            minimumInputLength = 3;
            return this;
        }
        public Select2Options SetAjax(string url, string idItem, string tituloItem)
        {
            ajax = new Select2Ajax(url, idItem, tituloItem);
            minimumInputLength = 3;
            return this;
        }

        public Select2Options SetMinimumInputLength(int minimumInputLength)
        {
            this.minimumInputLength = minimumInputLength;
            return this;
        }

        public Select2Ajax ajax { get; set; }
        public int minimumInputLength { get; set; }
        public bool multiple { get; set; }
        public string placeholder { get; set; } = "Selecione...";
        public bool allowClear { get; set; } = true;

        [DefaultValue(true)]
        public bool closeOnSelect { get; set; } = true;

        public string theme { get; set; } = "bootstrap";
        public Select2Options SetTheme(string stheme)
        {
            theme = stheme;
            return this;
        }


        public object data { get; set; }
        public string language { get; set; } = "pt-BR";

        /// <summary>
        /// function (params)
        /// </summary>
        public JRaw createTag { get; set; }
        public Select2Options SetCreateTag(string valor)
        {
            this.createTag = new JRaw(valor);
            return this;
        }

        public bool tags { get; set; }

        public JRaw templateResult { get; set; }
        public Select2Options SetTemplateResult(string templateResult)
        {
            this.templateResult = new JRaw(templateResult);

            return this;
        }

        public JRaw templateSelection { get; set; }
        public Select2Options SetTemplateSelection(string templateSelection)
        {
            this.templateSelection = new JRaw(templateSelection);

            return this;
        }

        public JRaw createSearchChoice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="js">function(term, data)</param>
        /// <returns></returns>
        public Select2Options SetCreateSearchChoice(string js)
        {
            createSearchChoice = new JRaw(js);
            return this;
        }





        public Select2Options SetAllowClear(bool allowClear = true)
        {
            this.allowClear = allowClear;
            return this;
        }
        public Select2Options SetCloseOnSelect(bool closeOnSelect)
        {
            this.closeOnSelect = closeOnSelect;
            return this;
        }
        
        public int minimumResultsForSearch { get; set; }
        public Select2Options SetMinimumResultsForSearch(int valor)
        {
            minimumResultsForSearch = valor;
            return this;
        }
        public Select2Options SetMultiple(bool isMultiple = true)
        {
            multiple = isMultiple;
            return this;
        }
        public int quietMillis { get; set; }
        public Select2Options SetQuietMillis(int valor)
        {
            quietMillis = valor;
            return this;
        }


        public Select2Options SetTags(bool isTags = true)
        {
            tags = isTags;
            return this;
        }
        public Select2Options SetPlaceholder(string placeholder)
        {
            this.placeholder = placeholder;
            return this;
        }






    }

    public class Select2Ajax
    {
        public Select2Ajax(string url)
        {
            this.url = url;
            processResults = new JRaw(@"function (data, params) {
                                            params.page = params.page || 1;
                                            return {
                                                results: data
                                            };
                                        }");
        }

        public Select2Ajax(string url, string idItem, string tituloItem)
        {
            this.url = url;
            processResults = new JRaw(string.Format(@"function (data, params) {{
                                                                                    params.page = params.page || 1;
                                                                                    return {{
                                                                                    results: $.map(data, function (item) {{
                                                                                        return {{
                                                                                            text: item.{0},
                                                                                            id: item.{1}
                                                                                        }}
                                                                                    }})
                                                                                    }};
                                                                                }}", tituloItem, idItem));
        }

        public Select2Ajax SetData(string data)
        {
            this.data = new JRaw(data);
            return this;
        }

        public string url { get; set; }

        public string dataType { get; set; } = "json";

        public int? delay { get; set; } = 250;

        public JRaw data { get; set; } = new JRaw("function (params) {return {q: params.term,page: params.page};}");

        public JRaw processResults { get; set; }

        public bool cache { get; set; }
        public string type { get; set; } = "POST";
    }


    public class Select2Item
    {
        public string id { get; set; }
        public string text { get; set; }

        public object parameters { get; set; }
        public IEnumerable<Select2Item> children { get; set; }
    }
}
