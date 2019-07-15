namespace Essa.Framework.WebCore.Helpers.Bootstrap.TreeView
{
    using Framework.UtilCore.Models.Helpers.TreeView;
    using System;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using System.Web.Mvc;

    public class TreeViewBuilder
    {
        private string _id;
        private TreeViewOptions _treeViewOptions;

        public TreeViewBuilder(string id)
        {
            _treeViewOptions = new TreeViewOptions();
            _id = id;
        }

        public TreeViewBuilder Config(Action<TreeViewOptions> treeViewOptions)
        {
            treeViewOptions(_treeViewOptions);
            return this;
        }

        public MvcHtmlString Montar()
        {
            StringBuilder str = new StringBuilder();

            int index = 0;
            foreach (var item in _treeViewOptions.data)
                str.Append(MontaHtmlRecursivo(item, 0, index++, _id));

            return new MvcHtmlString(string.Format(@"
<div id=""{1}"" style=""overflow-y: scroll; overflow-x: hidden; height: 500px;"">
    <ul class=""nav nav-list"">
	    {0}
	</ul>
</div>", str.ToString(), _id));
        }


        private string MontaHtmlRecursivo(TreeViewData item, int indexNivel, int index, string id)
        {
            StringBuilder str = new StringBuilder(string.Concat("<li id=\"", id, "_", indexNivel, "\">"));

            if (item.nodes == null)
                str.Append(string.Format("<a style=\"padding: 10px {1}px\" href=\"#\">{0}</a>", item.text, 20 * (indexNivel + 1)));
            else {
                str.Append(
                    string.Format(@"<label class=""tree-toggler nav-header"" style=""padding: 0px 0px 0px {1}px;""><i class=""glyphicon glyphicon-folder-open""></i> {0}</label>"
                            , item.text, 20 * indexNivel));

                str.Append("<ul class=\"nav nav-list tree\">");

                int indexDeIrmaos = 0;
                foreach (var item2 in item.nodes)
                    str.Append(MontaHtmlRecursivo(item2, indexNivel + 1, indexDeIrmaos++, string.Concat(id, "_", indexNivel + 1)));

                str.Append("</ul>");
            }

            str.Append("</li>");

            return str.ToString();
        }
    }

}
