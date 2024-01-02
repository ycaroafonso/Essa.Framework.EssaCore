namespace Essa.Framework.Web.Helpers.Bootstrap.Tabs
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;


    public class TabsBuilder : IDisposable
    {
        ViewContext _html;
        private string _id;
        Queue<TabConfig> _tabIds;
        int _index;
        int _indexAbaAtiva;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id">ID do componente</param>
        /// <param name="indexTabAtiva">Começando na posição 0</param>
        public TabsBuilder(ViewContext html, string id, int indexAbaAtiva)
        {
            _id = id;
            _tabIds = new Queue<TabConfig>();
            _html = html;
            _indexAbaAtiva = indexAbaAtiva;

            _html.Writer.Write(string.Concat("<ul class=\"nav nav-tabs\" id=\"", _id, "_head\">"));
        }



        public void Tab(string titulo, string onClick = "")
        {
            int index = _tabIds.Count;
            bool isAtivo = index == _indexAbaAtiva;

            _tabIds.Enqueue(new TabConfig(titulo, isAtivo, string.Concat(_id, "_tab_", index)));

            _html.Writer.Write(string.Format(@"<li class=""{3}"">
                                   <a href=""#{1}_tab_{2}"" data-toggle=""tab"" aria-expanded=""false"" {4}>
                                       {0}
                                   </a>
                               </li>", titulo, _id, index, isAtivo ? "active in" : "", onClick == "" ? "" : "onclick=\"" + onClick + "\""));
        }



        public TabsItem Tab()
        {
            _index++;
            if (_index == 1)
                _html.Writer.Write(string.Concat("</ul><div class=\"tab-content\" id=\"", _id, "_body\">"));

            return new TabsItem(_html, _tabIds.Dequeue());
        }

        public void Dispose()
        {
            _html.Writer.Write("</div>");
        }
    }


    public class TabsItem : IDisposable
    {
        ViewContext _html;

        public TabsItem(ViewContext html, TabConfig tabConfig)
        {
            _html = html;
            html.Writer.Write(string.Concat("<div class=\"tab-pane fade ", tabConfig.IsAtivo ? " active in" : "", "\" id=\"", tabConfig.IdAba, "\">"));
        }

        public void Dispose()
        {
            _html.Writer.Write("</div>");
        }
    }

    public class TabConfig
    {
        public string Titulo { get; set; }
        public bool IsAtivo { get; set; }
        public string IdAba { get; set; }

        public TabConfig(string titulo, bool isAtivo, string idAba)
        {
            Titulo = titulo;
            IsAtivo = isAtivo;
            IdAba = idAba;
        }
    }
}
