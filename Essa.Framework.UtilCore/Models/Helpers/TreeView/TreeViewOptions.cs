namespace Essa.Framework.Util.Models.Helpers.TreeView
{
    public class TreeViewOptions
    {
        public TreeViewData[] data { get; set; }


        /// <summary>
        /// TreeViewTeste_OnSelected(obj, tipo);
        /// </summary>
        //public string OnSelected { get; set; }

        public TreeViewOptions SetData(TreeViewData[] data)
        {
            this.data = data;
            return this;
        }
    }

    public class TreeViewData
    {
        public string nodeId { get; set; }

        public string text { get; set; }
        public string href { get; set; }
        public string[] tags { get; set; }

        public string icon { get; set; }
        public bool selected { get; set; }

        public TreeViewData[] nodes { get; set; } = null;

        public object parameters { get; set; }


        public TreeViewState state { get; set; }

    }

    public class TreeViewState
    {
        public bool @checked { get; set; }
        public bool disabled { get; set; }
        public bool expanded { get; set; }
        public bool selected { get; set; }
    }
}
