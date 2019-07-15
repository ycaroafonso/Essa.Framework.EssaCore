namespace Essa.Framework.WebCore.Helpers.TreeView
{
    using Framework.UtilCore.Models.Helpers.TreeView;
    using Newtonsoft.Json;
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

            string script = JsonConvert.SerializeObject(_treeViewOptions ?? new TreeViewOptions(), new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            return new MvcHtmlString(string.Format(@"
                <script>
                    jQuery(document).ready(function () {{ $('#{1}').treeview({0}) }});
                </script>
                <div id=""{1}""></div>"
                , script, _id));
        }
    }
}
