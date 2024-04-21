namespace Essa.Framework.WebCore.JqGrid
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Text;


    #region Enums

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrder
    {
        asc,
        desc
    }

    public enum RequestType
    {
        get,
        post
    }

    public enum DataType
    {
        json,
        xml,
        local
    }

    public enum LoadUi
    {
        enable,
        disable,
        block
    }

    public enum MultiKey
    {
        altKey,
        ctrlKey,
        shiftKey
    }

    public enum PagerPos
    {
        center,
        left,
        right
    }

    public enum RecordPos
    {
        center,
        left,
        right
    }

    public enum ToolbarPosition
    {
        top,
        bottom,
        both
    }

    public enum Direction
    {
        vertical,
        horizontal
    }

    public enum Searchtype
    {
        text,
        select,
        datepicker
    }

    #endregion


    public class GroupingView
    {
        public string[] groupField;
        public string[] groupOrder;
        public string[] groupText;
        public bool[] groupColumnShow;
        public bool[] groupSummary;
        public string[] groupSummaryPos;
        public bool? showSummaryOnHide;
        public bool? groupCollapse;
        public string plusicon;
        public string minusicon;

        public bool groupDataSorted { get; set; }

        public GroupingView setGroupField(params string[] groupField)
        {
            this.groupField = groupField;
            return this;
        }

        public GroupingView setGroupOrder(params string[] groupOrder)
        {
            this.groupOrder = groupOrder;
            return this;
        }


        public GroupingView setGroupText(params string[] groupTexts)
        {
            this.groupText = groupTexts;
            return this;
        }

        //public GroupingView setGroupText(params string[] groupTexts)
        //{
        //    groupTexts.ToList().ForEach(c => groupText.Add(new JRaw("\"" + c + "\"")));
        //    return this;
        //}

        //public GroupingView setGroupText(params JRaw[] groupText)
        //{
        //    this.groupText = groupText.ToList();
        //    return this;
        //}

        public GroupingView setGroupColumnShow(params bool[] groupColumnShow)
        {
            this.groupColumnShow = groupColumnShow;
            return this;
        }

        public GroupingView setGroupSummary(params bool[] groupSummary)
        {
            this.groupSummary = groupSummary;
            return this;
        }

        public GroupingView setGroupSummaryPos(params string[] groupSummaryPos)
        {
            this.groupSummaryPos = groupSummaryPos;
            return this;
        }

        public GroupingView setGroupDataSorted(bool groupDataSorted)
        {
            this.groupDataSorted = groupDataSorted;
            return this;
        }

        public GroupingView setShowSummaryOnHide(bool showSummaryOnHide)
        {
            this.showSummaryOnHide = showSummaryOnHide;
            return this;
        }

        public GroupingView setGroupCollapse(bool groupCollapse)
        {
            this.groupCollapse = groupCollapse;
            return this;
        }

        public GroupingView setPlusicon(string plusicon)
        {
            this.plusicon = plusicon;
            return this;
        }

        public GroupingView setMinusicon(string minusicon)
        {
            this.minusicon = minusicon;
            return this;
        }

        public override string ToString()
        {
            var script = new StringBuilder();

            //if (string.IsNullOrWhiteSpace(this.groupField)) throw new Exception("GroupField tem que ser preenchido!");

            // Start GroupingView
            script.Append("{ ");

            script.AppendFormat("groupField: [{0}]", this.groupField);

            //if (!string.IsNullOrWhiteSpace(this.groupOrder)) script.AppendFormat(", groupOrder: [{0}] ", this.groupOrder);

            //if (!string.IsNullOrWhiteSpace(this.groupText)) script.AppendFormat(", groupText: [{0}] ", this.groupText);

            //if (!string.IsNullOrWhiteSpace(this.groupColumnShow)) script.AppendFormat(", groupColumnShow: [{0}] ", this.groupColumnShow);

            //if (!string.IsNullOrWhiteSpace(this.groupSummary)) script.AppendFormat(", groupSummary: [{0}] ", this.groupSummary);

            if (this.showSummaryOnHide.HasValue) script.AppendFormat(", showSummaryOnHide: {0} ", this.showSummaryOnHide.ToString().ToLower());

            if (this.groupCollapse.HasValue) script.AppendFormat(", groupCollapse: {0} ", this.groupCollapse.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(this.plusicon)) script.AppendFormat(", plusicon: '{0}' ", this.plusicon);

            if (!string.IsNullOrWhiteSpace(this.minusicon)) script.AppendFormat(", minusicon: '{0}' ", this.minusicon);

            // End GroupingView
            script.Append(" } ").AppendLine();

            return script.ToString();
        }

    }
}