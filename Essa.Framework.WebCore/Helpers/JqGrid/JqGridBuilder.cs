namespace Essa.Framework.WebCore.Helpers.JqGrid
{
    using Framework.UtilCore.Extensions;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    


    //public class JqGridBuilder<T> : JqGridBuilder
    //{
    //    public JqGridBuilder(Func<T, bool> obj) : base(obj.Invoke(obj))
    //    {
    //    }
    //}

    public class JqGridBuilder
    {
        public string Id { get; private set; }
        JqGridOptions _jqGridOptions;
        string _complementoJqGrid;

        public JqGridBuilder(string id)
        {
            Id = id;

            _jqGridOptions = new JqGridOptions()
            {
                viewrecords = true,
                pager = Id + "_Pager",
                colModel = new List<JqGridColumn>(),
            };

            _complementoJqGrid = string.Empty;
        }

        public JqGridBuilder SetAjax(string url)
        {
            _jqGridOptions.url = url;

            return this;
        }

        public JqGridBuilder SetAjax(string url, string colunaOrdenacao)
        {
            _jqGridOptions.url = url;
            _jqGridOptions.sortname = colunaOrdenacao;

            return this;
        }

        public JqGridBuilder SetAjax(string url, string colunaOrdenacao, SortOrder sortOrder)
        {
            _jqGridOptions.sortorder = sortOrder;

            return SetAjax(url, colunaOrdenacao);
        }

        public JqGridBuilder Config(Action<JqGridOptions> jqGridOptions)
        {
            jqGridOptions(_jqGridOptions);

            return this;
        }

        public JqGridBuilder SetData<T>(List<T> valor)
        {
            _jqGridOptions.data = new JRaw(valor.ToJson());
            _jqGridOptions.datatype = DataType.local.ToString();

            return this;
        }

        public JqGridBuilder SetData<T>(IEnumerable<T> valor)
        {
            _jqGridOptions.data = new JRaw(valor.ToJson());
            _jqGridOptions.datatype = DataType.local.ToString();

            return this;
        }

        public JqGridBuilder SetId(string id)
        {
            Id = id;
            return this;
        }

        public JqGridBuilder AddColuna(JqGridColumn jqGridColumn)
        {
            _jqGridOptions.colModel.Add(jqGridColumn);

            return this;
        }


        public enum TipoEnum
        {
            ChavePrimária,
            Hidden
        }
        public JqGridBuilder AddColuna(string columnName, TipoEnum tipo)
        {
            switch (tipo)
            {
                case TipoEnum.Hidden:
                    _jqGridOptions.colModel.Add(new JqGridColumn(columnName).setHidden());

                    break;
                case TipoEnum.ChavePrimária:
                    _jqGridOptions.colModel.Add(new JqGridColumn(columnName).setHidden().setKey());

                    break;
                default:
                    _jqGridOptions.colModel.Add(new JqGridColumn(columnName));

                    break;
            }

            return this;
        }

        public JqGridBuilder AddColuna(string columnName, string label = "")
        {
            _jqGridOptions.colModel.Add(new JqGridColumn(columnName, label));

            return this;
        }

        public string ToJs(string id)
        {
            if (_jqGridOptions.height == null)
            {
                AddParam("setGridHeight", "\"auto\"");
            }

            return string.Concat(@"$(", id, ").jqGrid(", _jqGridOptions.ToString(), ")", _complementoJqGrid, @";");
        }
        public string ToJs()
        {
            return ToJs(string.Concat("'#", Id, "'"));
        }


        public MvcHtmlString Montar()
        {

            string str = string.Concat(@" <table id=""", Id, @"""></table>
                                        <div id=""", Id, @"_Pager""></div>
                                        <script>
                                            $(document).ready(function () {
    	                                        ", ToJs(), @"
                                            });
                                        </script>");

            return new MvcHtmlString(str.ToString());
        }

        public MvcHtmlString retornaGrid()
        {
            return Montar();
        }




        public JqGridBuilder AddParam(string nome, string valor)
        {
            _complementoJqGrid += string.Concat(".jqGrid(\"", nome, "\", ", valor, ")");
            return this;
        }
        public JqGridBuilder AddParam(SetGroupHeaders valor)
        {
            return AddParam("setGroupHeaders", valor.ToJson());
        }
    }
}
