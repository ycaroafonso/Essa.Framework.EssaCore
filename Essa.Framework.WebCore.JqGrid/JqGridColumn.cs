namespace Essa.Framework.WebCore.JqGrid
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Text;


    public class JqGridColumn
    {
        public enum FormatterEnum
        {
            checkbox,
            currency,
            email,
            integer,
            link,
            number,
            date,
            showlink,
            select
        }

        public enum Align
        {
            center,
            left,
            right
        }

        public enum SummaryType
        {
            sum,
            count,
            avg,
            min,
            max
        }


        public string align { get; set; }

        public string label { get; set; }
        public string name { get; set; }
        public bool key { get; set; }

        public string index { get; set; }

        public JRaw width { get; set; }

        public bool hidden { get; set; }

        /// <summary>
        /// OBSERVAÇÃO: Utilize o método SetFormatter() dessa classe;
        /// 
        /// Informe o tipo entre aspas, exemplo: new JRaw("\"checkbox\"")
        /// ou
        /// Informe o método javascript com 3 parâmetros. Exemplo: new JRaw("function (value, row, item) { ... }")
        /// </summary> 
        public JRaw formatter { get; set; }

        public bool frozen { get; set; }
        public JqGridFormatOptions formatoptions { get; set; }


        public JqGridColumn SetFormatter(FormatterEnum valor)
        {
            formatter = new JRaw("\"" + valor.ToString() + "\"");

            return this;
        }


        /// <summary>
        /// Informe o método javascript
        /// </summary>
        /// <param name="valor">Exemplo: function (cellValue, options, rowObject) { return ...; }</param>
        /// <returns></returns>
        public JqGridColumn SetFormatter(string metodoJavascript)
        {
            formatter = new JRaw(metodoJavascript);

            return this;
        }

        public JqGridColumn SetFormaterOptions(JqGridFormatOptions formatoptions)
        {
            this.formatoptions = formatoptions;
            return this;
        }











        public string classes;
        public bool? editable;
        public SortOrder? firstsortorder;
        public bool? @fixed;
        public bool? resizable;
        public bool? search;
        public Searchtype? _searchType;
        public string[] _searchTerms;
        public string _searchDateFormat;
        public bool? sortable;
        public bool? title;
        public JRaw summaryType;
        public string summaryTpl;
        public string _customSummaryType;

        public JqGridColumn()
        {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName">Name of column, cannot be blank or set to 'subgrid', 'cb', and 'rn'</param>
        public JqGridColumn(string columnName, string label = "")
        {
            // Make sure columnname is not left blank
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("No columnname specified");

            // Make sure columnname is not part of the reserved names collection
            var reservedNames = new string[] { "subgrid", "cb", "rn" };

            if (reservedNames.Contains(columnName))
                throw new ArgumentException("Columnname '" + columnName + "' is reserved");

            // Set columnname
            this.name = columnName;

            // Set index equal to columnname by default, can be overriden by setter
            this.index = columnName;

            this.label = label;
        }

        /// <summary>
        /// This option allow to add a class to to every cell on that column. In the grid css 
        /// there is a predefined class ui-ellipsis which allow to attach ellipsis to a 
        /// particular row. Also this will work in FireFox too.
        /// Multiple calls to this function are allowed to set multiple classes
        /// </summary>
        /// <param name="className">Classname</param>
        public JqGridColumn addClass(string className)
        {
            //this._classes.Add(className);
            classes += " " + className;
            return this;
        }

        public JqGridColumn setSummaryType(SummaryType valor)
        {
            summaryType = new JRaw("\"" + valor.ToString() + "\"");
            return this;
        }

        public JqGridColumn setSummaryTpl(string summaryTpl)
        {
            this.summaryTpl = summaryTpl;
            return this;
        }

        public JqGridColumn setCustomSummaryType(string customSummary)
        {
            if (this.summaryType != null)
                throw new Exception("You cannot set a formatter and a customformatter at the same time, please choose one.");

            this._customSummaryType = customSummary;
            return this;
        }

        public JqGridColumn setEditable(bool editable)
        {
            this.editable = editable;
            return this;
        }

        /// <summary>
        /// Set dateformat of datepicker when searchtype is set to datepicker (default: dd-mm-yy)
        /// </summary>
        /// <param name="searchDateFormat">Dateformat</param>
        public JqGridColumn setSearchDateFormat(string searchDateFormat)
        {
            this._searchDateFormat = searchDateFormat;
            return this;
        }

        /// <summary>
        /// Set searchterms if search type of this JqGridColumn is set to type select
        /// </summary>
        /// <param name="searchTerms">Searchterm to add to dropdownlist</param>
        public JqGridColumn setSearchTerms(string[] searchTerms)
        {
            this._searchTerms = searchTerms;
            return this;
        }

        /// <summary>
        /// Defines the alignment of the cell in the Body layer, not in header cell. 
        /// Possible values: left, center, right. (default: left)
        /// </summary>
        /// <param name="align">Alignment of JqGridColumn (center, right, left</param>
        public JqGridColumn setAlign(Align align)
        {
            this.align = align.ToString();
            return this;
        }

        /// <summary>
        /// If set to asc or desc, the JqGridColumn will be sorted in that direction on first 
        /// sort.Subsequent sorts of the JqGridColumn will toggle as usual (default: null)
        /// </summary>
        /// <param name="firstSortOrder">First sort order</param>
        public JqGridColumn setFirstSortOrder(SortOrder firstSortOrder)
        {
            this.firstsortorder = firstSortOrder;
            return this;
        }

        /// <summary>
        /// If set to true this option does not allow recalculation of the width of the 
        /// JqGridColumn if shrinkToFit option is set to true. Also the width does not change 
        /// if a setGridWidth method is used to change the grid width. (default: false)
        /// </summary>
        /// <param name="fixedWidth">Indicates if width of JqGridColumn is fixed</param>
        public JqGridColumn setFixed(bool fixedWidth)
        {
            this.@fixed = fixedWidth;
            return this;
        }

        ///// <summary>
        ///// Sets formatter with default formatoptions (as set in language file)
        ///// </summary>
        ///// <param name="formatter">Formatter</param>
        //public JqGridColumn setFormatter(Formatters formatter)
        //{
        //    if (!string.IsNullOrWhiteSpace(this._customFormatter))
        //    {
        //        throw new Exception("You cannot set a formatter and a customformatter at the same time, please choose one.");
        //    }
        //    this._formatter = new KeyValuePair<Formatters, string>(formatter, "");
        //    return this;
        //}

        ///// <summary>
        ///// Sets formatter with formatoptions (see jqGrid documentation for more info on formatoptions)
        ///// </summary>
        ///// <param name="formatter">Formatter</param>
        ///// <param name="formatOptions">Formatoptions</param>
        //public JqGridColumn setFormatter(Formatters formatter, string formatOptions)
        //{
        //    if (!string.IsNullOrWhiteSpace(this._customFormatter))
        //    {
        //        throw new Exception("You cannot set a formatter and a customformatter at the same time, please choose one.");
        //    }
        //    this._formatter = new KeyValuePair<Formatters, string>(formatter, formatOptions);
        //    return this;
        //}

        /// <summary>
        /// Sets custom formatter. Usually this is a function. When set in the formatter option 
        /// this should not be enclosed in quotes and not entered with () - 
        /// just specify the name of the function
        /// The following variables are passed to the function:
        /// 'cellvalue': The value to be formated (pure text).
        /// 'options': Object { rowId: rid, colModel: cm} where rowId - is the id of the row colModel is 
        /// the object of the properties for this JqGridColumn getted from colModel array of jqGrid
        /// 'rowobject': Row data represented in the format determined from datatype option. 
        /// If we have datatype: xml/xmlstring - the rowObject is xml node,provided according to the rules 
        /// from xmlReader If we have datatype: json/jsonstring - the rowObject is array, provided according to 
        /// the rules from jsonReader
        /// </summary>
        /// <param name="customFormatter"></param>
        /// <returns></returns>
        //public JqGridColumn setCustomFormatter(string customFormatter)
        //{
        //    if (this._formatter.HasValue)
        //    {
        //        throw new Exception("You cannot set a formatter and a customformatter at the same time, please choose one.");
        //    }
        //    this._customFormatter = customFormatter;
        //    return this;
        //}

        /// <summary>
        /// Defines if this JqGridColumn is hidden at initialization. (default: false)
        /// </summary>
        /// <param name="hidden">Boolean indicating if JqGridColumn is hidden</param>
        public JqGridColumn setHidden(bool hidden = true)
        {
            this.hidden = hidden;
            return this;
        }

        /// <summary>
        /// Set the index name when sorting. Passed as sidx parameter. (default: Same as columnname)
        /// </summary>
        /// <param name="index">Name of index</param>
        public JqGridColumn setIndex(string index)
        {
            this.index = index;
            return this;
        }

        /// <summary>
        /// In case if there is no id from server, this can be set as as id for the unique row id. 
        /// Only one JqGridColumn can have this property. If there are more than one key the grid finds 
        /// the first one and the second is ignored. (default: false)
        /// </summary>
        /// <param name="key">Indicates if key is set</param>
        public JqGridColumn setKey(bool key = true)
        {
            this.key = key;
            return this;
        }

        /// <summary>
        /// Defines the heading for this column. If empty, the heading for this JqGridColumn comes from the name property.
        /// </summary>
        /// <param name="label">Label name of column</param>
        public JqGridColumn setLabel(string label)
        {
            this.label = label;
            return this;
        }

        /// <summary>
        /// Defines if the JqGridColumn can be resized (default: true)
        /// </summary>
        /// <param name="resizeable">Indicates if the JqGridColumn is resizable</param>
        public JqGridColumn setResizeable(bool resizeable)
        {
            this.resizable = resizeable;
            return this;
        }

        /// <summary>
        /// When used in search modules, disables or enables searching on that column. (default: true)
        /// </summary>
        /// <param name="search">Indicates if searching for this JqGridColumn is enabled</param>
        public JqGridColumn setSearch(bool search)
        {
            this.search = search;
            return this;
        }

        /// <summary>
        /// Sets the searchtype of this JqGridColumn (text, select or datepicker) (default: text)
        /// Note: To use datepicker jQueryUI javascript should be included
        /// </summary>
        /// <param name="searchType">Search type</param>
        public JqGridColumn setSearchType(Searchtype searchType)
        {
            this._searchType = searchType;
            return this;
        }

        /// <summary>
        /// Indicates if JqGridColumn is sortable (default: true)
        /// </summary>
        /// <param name="sortable">Indicates if JqGridColumn is sortable</param>
        public JqGridColumn setSortable(bool sortable)
        {
            this.sortable = sortable;
            return this;
        }

        /// <summary>
        /// If this option is false the title is not displayed in that JqGridColumn when we hover over a cell (default: true)
        /// </summary>
        /// <param name="title">Indicates if title is displayed when hovering over cell</param>
        public JqGridColumn setTitle(bool title)
        {
            this.title = title;
            return this;
        }

        /// <summary>
        /// Set the initial width of the column, in pixels. This value currently can not be set as percentage (default: 150)
        /// </summary>
        /// <param name="width">Width in pixels</param>
        public JqGridColumn setWidth(int width)
        {
            this.width = new JRaw(width);
            return this;
        }
        public JqGridColumn setWidth(string width)
        {
            this.width = new JRaw("\"" + width + "\"");
            return this;
        }



        public JRaw cellattr { get; set; }

        /// <summary>
        /// rowId - the id of the row 
        /// val - the value which will be added in the cell 
        /// rawObject - the raw object of the data row - i.e if datatype is json - array, if datatype is xml xml node. 
        /// cm - all the properties of this column listed in the colModel 
        /// rdata - the data row which will be inserted in the row. This parameter is array of type name:value, where name is the name in colModel
        /// </summary>
        /// <param name="js">function(rowId, val, rawObject, cm, rdata)</param>
        /// <returns></returns>
        public JqGridColumn setCellAttr(string js)
        {
            cellattr = new JRaw(js);

            return this;
        }





        public new string ToString()
        {
            var script = new StringBuilder();

            // Start column
            script.Append("{").AppendLine();

            // SearchType
            if (this._searchType.HasValue)
            {
                if (this._searchType.Value == Searchtype.text) script.AppendLine("stype:'text',");
                if (this._searchType.Value == Searchtype.select) script.AppendLine("stype:'select',");
            }

            // Searchoptions
            if (this._searchType == Searchtype.select || this._searchType == Searchtype.datepicker)
            {
                script.Append("searchoptions: {");

                // Searchtype select
                if (this._searchType == Searchtype.select)
                {
                    if (this._searchTerms != null)
                    {
                        string emtpyOption = (this._searchTerms.Count() > 0) ? ":;" : ":";
                        script.AppendFormat("value: \"{0}{1}\"", emtpyOption, string.Join(";", from s in this._searchTerms select s + ":" + s));
                    }
                    else
                    {
                        script.Append("value: ':'");
                    }
                }

                // Searchtype datepicker
                if (this._searchType == Searchtype.datepicker)
                {
                    if (string.IsNullOrWhiteSpace(this._searchDateFormat))
                        script.Append("dataInit:function(el){jQuery(el).datepicker({changeYear:true, onSelect: function() {var sgrid = jQuery('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'dd-mm-yy'});}");
                    else
                        script.Append("dataInit:function(el){jQuery(el).datepicker({changeYear:true, onSelect: function() {var sgrid = jQuery('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'" + this._searchDateFormat + "'});}");
                }
                script.AppendLine("},");
            }

            return script.ToString();
        }


    }


    public class SetGroupHeaders
    {
        public bool useColSpanStyle { get; set; }
        public GroupHeaders[] groupHeaders { get; set; }
    }

    public class GroupHeaders
    {
        public string startColumnName { get; set; }
        public int numberOfColumns { get; set; }
        public string titleText { get; set; }
    }

}
