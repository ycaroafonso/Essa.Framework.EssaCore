using Essa.Framework.Util.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Essa.Framework.WebCore.JqGrid
{
    /// <summary>
    /// JqGridOptions class, used to render JqGrid
    /// </summary>
    public class JqGridOptions
    {
        public string url { get; set; }
        public string mtype { get; set; } = "POST";
        public string styleUI { get; set; } = "Bootstrap";
        public string datatype { get; set; } = DataType.json.ToString();
        public List<JqGridColumn> colModel { get; set; }
        public bool viewrecords { get; set; }
        public int width { get; set; }
        public int? height { get; set; }
        public int rowNum { get; set; } = 20;
        public string pager { get; set; }
        public string sortname { get; set; }
        [DefaultValue(false)]
        public bool autowidth { get; set; } = true;
        public bool multiselect { get; set; }
        public bool shrinkToFit { get; set; } = true;
        public JRaw data { get; set; }
        public JqGridOptions setData(string data)
        {
            this.data = new JRaw(data);
            return this;
        }

        public bool? loadonce { get; set; }

        public JRaw loadComplete { get; set; }
        public bool? footerrow { get; set; }


        public JRaw onClickGroup { get; set; }

        public JqGridOptions setOnClickGroup(string onClickGroup)
        {
            this.onClickGroup = new JRaw(onClickGroup);
            return this;
        }



        [JsonProperty(PropertyName = "fixed")]
        public bool Fixed { get; set; }
        public JqGridOptions setFixed(bool fix)
        {
            Fixed = fix;

            return this;
        }




        /// <summary>
        /// TODO: Testar
        /// </summary>
        public bool? userDataOnFooter { get; set; }
        /// <summary>
        /// TODO: Testar
        /// </summary>
        public JRaw userdata { get; set; }



        public new string ToString()
        {
            return this.ToJson(Formatting.Indented);
        }


        private string _id;
        private string altclass;
        private bool? altRows;
        private bool? autoencode;
        //private bool? autowidth;
        public string caption;
        //private List<JqGridColumn> _columns = new List<JqGridColumn>();
        public GroupingView groupingView;
        //private DataType datatype = DataType.json;
        public string emptyrecords;
        private bool? forceFit;
        public bool? grouping;
        private bool? _groupDataSorted;
        private bool? gridview;
        private bool? headertitles;
        //private int? height;
        private bool? hiddengrid;
        private bool? hidegrid;
        private bool? hoverrows;
        //private bool? loadonce;
        private string loadtext;
        private LoadUi? loadui;
        private MultiKey? multikey;
        private bool? multiboxonly;
        //private bool? _multiSelect;
        private int? _multiSelectWidth;
        public JRaw onAfterInsertRow;
        private string _onBeforeRequest;
        public JRaw beforeSelectRow;
        public JRaw gridComplete;
        private string _onLoadBeforeSend;
        //private string _onLoadComplete;
        private string _onLoadError;
        private string _onCellSelect;
        public JRaw ondblClickRow;
        private string _onHeaderClick;
        private string _onPaging;
        private string _onRightClickRow;
        public JRaw onSelectAll;
        public JRaw onSelectRow;
        private string _onSortCol;
        private string _onResizeStart;
        private string _onResizeStop;
        private string _onSerializeGridData;
        private int? _page;
        //private string pager;
        private PagerPos? _pagerPos;
        private bool? _pgButtons;
        private bool? _pgInput;
        private string _pgText;
        private RecordPos? _recordPos;
        private string _recordText;
        private RequestType? _requestType;
        private string _resizeClass;
        public int[] rowList;
        //private int? _rowNum;
        public bool? rownumbers;
        public int? rownumWidth;
        private bool? _scroll;
        private int? _scrollInt;
        private int? _scrollOffset;
        private bool? _scrollRows;
        private int? _scrollTimeout;
        //private bool? shrinkToFit;
        private string _sortName;
        public SortOrder? sortorder;
        private bool? _topPager;
        private bool? _toolbar;
        private ToolbarPosition _toolbarPosition = ToolbarPosition.top;
        private bool? _searchToolbar;
        private bool? _searchOnEnter;
        private bool? _searchClearButton;
        private bool? _searchToggleButton;
        private string _url;
        //private bool? _viewRecords;
        private bool? _showAllSortIcons;
        private Direction? _sortIconDirection;
        private bool? _sortOnHeaderClick;
        //private int? width;

        public JRaw rowattr;


        public bool subGrid;
        public JqGridOptions setSubGrid(bool subgrid)
        {
            this.subGrid = subgrid;
            return this;
        }

        public JRaw subGridRowExpanded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="js">function (subgridDivId, rowId)</param>
        /// <returns></returns>
        public JqGridOptions setSubGridRowExpanded(string js)
        {
            subGridRowExpanded = new JRaw(js);
            return this;
        }
        public JqGridOptions setSubGridRowExpanded(JqGridOptions js)
        {
            subGridRowExpanded = new JRaw(js);
            return this;
        }
        public JqGridOptions setSubGridRowExpanded(JqGridBuilder js)
        {
            subGridRowExpanded = new JRaw(string.Concat(
@"
function (sub_grid_id, row_id) {
        var tbl_id = sub_grid_id + '_t';
        $('#' + sub_grid_id).html('<table id=""' + tbl_id + '""></table>');
    ", js.ToJs("'#' + tbl_id"),
"}"));
            return this;
        }


        public JqGridOptions setStyleUIBootstrap()
        {
            styleUI = "Bootstrap";
            return this;
        }


        public JqGridOptions()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of grid</param>
        public JqGridOptions(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id must contain a value to identify the grid");
            }
            this._id = id;
        }

        ///// <summary>
        ///// Adds columns to grid
        ///// </summary>
        ///// <param name="column">Colomn object</param>
        //public JqGridOptions addColumn(JqGridColumn column)
        //{
        //    this._columns.Add(column);
        //    return this;
        //}

        public JqGridOptions setGroupingView(GroupingView groupingView)
        {
            this.groupingView = groupingView;
            return this;
        }

        /// <summary>
        /// The class that is used for alternate rows. You can construct your own class and replace this value. 
        /// This option is valid only if altRows options is set to true (default: ui-priority-secondary)
        /// </summary>
        /// <param name="altClass">Classname for alternate rows</param>
        public JqGridOptions setAltClass(string altClass)
        {
            this.altclass = altClass;
            return this;
        }

        /// <summary>
        /// Set a zebra-striped JqGridOptions (default: false)
        /// </summary>
        /// <param name="altRows">Boolean indicating if zebra-striped JqGridOptions is used</param>
        public JqGridOptions setAltRows(Boolean altRows)
        {
            this.altRows = altRows;
            return this;
        }

        /// <summary>
        /// When set to true encodes (html encode) the incoming (from server) and posted 
        /// data (from editing modules). For example < will be converted to &lt (default: false)
        /// </summary>
        /// <param name="autoEncode">Boolean indicating if autoencode is used</param>
        public JqGridOptions setAutoEncode(bool autoEncode)
        {
            this.autoencode = autoEncode;
            return this;
        }

        /// <summary>
        /// When set to true, the JqGridOptions width is recalculated automatically to the width of the 
        /// parent element. This is done only initially when the JqGridOptions is created. In order to 
        /// resize the JqGridOptions when the parent element changes width you should apply custom code 
        /// and use a setGridWidth method for this purpose. (default: false)
        /// </summary>
        /// <param name="autoWidth">Boolean indicating if autowidth is used</param>
        public JqGridOptions setAutoWidth(bool autoWidth = true)
        {
            this.autowidth = autoWidth;
            return this;
        }

        /// <summary>
        /// Defines the caption layer for the grid. This caption appears above the header layer. 
        /// If the string is empty the caption does not appear. (default: empty)
        /// </summary>
        /// <param name="caption">Caption of grid</param>
        public JqGridOptions setCaption(string caption)
        {
            this.caption = caption;
            return this;
        }

        /// <summary>
        /// Defines what type of information to expect to represent data in the grid. Valid 
        /// options are json (default) and xml
        /// </summary>
        /// <param name="dataType">Data type</param>
        public JqGridOptions setDataType(DataType dataType)
        {
            this.datatype = dataType.ToString();
            return this;
        }



        /// <summary>
        /// Displayed when the returned (or the current) number of records is zero. 
        /// This option is valid only if viewrecords option is set to true. (default value is 
        /// set in language file)
        /// </summary>
        /// <param name="emptyRecords">Display string</param>
        public JqGridOptions setEmptyRecords(string emptyRecords)
        {
            this.emptyrecords = emptyRecords;
            return this;
        }

        /// <summary>
        /// If set to true this will place a footer table with one row below the JqGridOptions records 
        /// and above the pager. The number of columns equal to the number of columns in the colModel 
        /// (default: false)
        /// </summary>
        /// <param name="footerRow">Boolean indicating whether footerrow is displayed</param>
        public JqGridOptions setFooterRow(bool footerRow)
        {
            footerrow = footerRow;
            return this;
        }
        public JqGridOptions setUserDataOnFooter(bool userDataOnFooter)
        {
            this.userDataOnFooter = userDataOnFooter;
            return this;
        }
        public JqGridOptions setUserData(string userdata)
        {
            this.userdata = new JRaw(userdata);
            return this;
        }

        /// <summary>
        /// If set to true, when resizing the width of a column, the adjacent column (to the right) 
        /// will resize so that the overall JqGridOptions width is maintained (e.g., reducing the width of 
        /// column 2 by 30px will increase the size of column 3 by 30px). 
        /// In this case there is no horizontal scrolbar. 
        /// Note: this option is not compatible with shrinkToFit option - i.e if 
        /// shrinkToFit is set to false, forceFit is ignored.
        /// </summary>
        /// <param name="forceFit">Boolean indicating if forcefit is enforced</param>
        public JqGridOptions setForceFit(bool forceFit)
        {
            this.forceFit = forceFit;
            return this;
        }

        /// <summary>
        /// In the previous versions of jqGrid including 3.4.X,reading relatively big data sets 
        /// (Rows >=100 ) caused speed problems. The reason for this was that as every cell was 
        /// inserted into the JqGridOptions we applied about 5-6 jQuery calls to it. Now this problem has 
        /// been resolved; we now insert the entry row at once with a jQuery append. The result is 
        /// impressive - about 3-5 times faster. What will be the result if we insert all the 
        /// data at once? Yes, this can be done with help of the gridview option. When set to true, 
        /// the result is a JqGridOptions that is 5 to 10 times faster. Of course when this option is set 
        /// to true we have some limitations. If set to true we can not use treeGrid, subGrid, 
        /// or afterInsertRow event. If you do not use these three options in the JqGridOptions you can 
        /// set this option to true and enjoy the speed. (default: false)
        /// </summary>
        /// <param name="gridView">Boolean indicating gridview is enabled</param>
        public JqGridOptions setGridView(bool gridView)
        {
            this.gridview = gridView;
            return this;
        }

        public JqGridOptions setGrouping(bool grouping)
        {
            this.grouping = grouping;
            return this;
        }

        public JqGridOptions setGroupDataSorted(bool groupDataSorted)
        {
            this._groupDataSorted = groupDataSorted;
            return this;
        }

        /// <summary>
        /// If the option is set to true the title attribute is added to the column headers (default: false)
        /// </summary>
        /// <param name="headerTitles">Boolean indicating if headertitles are enabled</param>
        public JqGridOptions setHeaderTitles(bool headerTitles)
        {
            this.headertitles = headerTitles;
            return this;
        }

        /// <summary>
        /// The height of the JqGridOptions in pixels (default: 100%, which is the only acceptable percentage for jqGrid)
        /// </summary>
        /// <param name="height">Height in pixels</param>
        public JqGridOptions setHeight(int height)
        {
            this.height = height;
            return this;
        }

        /// <summary>
        /// If set to true the JqGridOptions initially is hidden. The data is not loaded (no request is sent) and only the 
        /// caption layer is shown. When the show/hide button is clicked for the first time to show the grid, the request 
        /// is sent to the server, the data is loaded, and the JqGridOptions is shown. From this point on we have a regular grid. 
        /// This option has effect only if the caption property is not empty. (default: false)
        /// </summary>
        /// <param name="hiddenGrid">Boolean indicating if hiddengrid is enforced</param>
        public JqGridOptions setHiddenGrid(bool hiddenGrid)
        {
            this.hiddengrid = hiddenGrid;
            return this;
        }

        /// <summary>
        /// Enables or disables the show/hide JqGridOptions button, which appears on the right side of the caption layer. 
        /// Takes effect only if the caption property is not an empty string. (default: true) 
        /// </summary>
        /// <param name="hideGrid">Boolean indicating if show/hide button is enabled</param>
        public JqGridOptions setHideGrid(bool hideGrid)
        {
            this.hidegrid = hideGrid;
            return this;
        }

        /// <summary>
        /// When set to false the mouse hovering is disabled in the JqGridOptions data rows. (default: true)
        /// </summary>
        /// <param name="hoverRows">Indicates whether hoverrows is enabled</param>
        public JqGridOptions setHoverRows(bool hoverRows)
        {
            this.hoverrows = hoverRows;
            return this;
        }

        /// <summary>
        /// If this flag is set to true, the JqGridOptions loads the data from the server only once (using the 
        /// appropriate datatype). After the first request the datatype parameter is automatically 
        /// changed to local and all further manipulations are done on the client side. The functions 
        /// of the pager (if present) are disabled. (default: false)
        /// </summary>
        /// <param name="loadOnce">Boolean indicating if loadonce is enforced</param>
        public JqGridOptions setLoadOnce(bool loadOnce)
        {
            this.loadonce = loadOnce;
            return this;
        }

        /// <summary>
        /// The text which appears when requesting and sorting data. This parameter override the value located 
        /// in the language file
        /// </summary>
        /// <param name="loadText">Loadtext</param>
        public JqGridOptions setLoadText(string loadText)
        {
            this.loadtext = loadText;
            return this;
        }

        /// <summary>
        /// This option controls what to do when an ajax operation is in progress.
        /// 'disable' - disables the jqGrid progress indicator. This way you can use your own indicator.
        /// 'enable' (default) - enables “Loading” message in the center of the grid. 
        /// 'block' - enables the “Loading” message and blocks all actions in the JqGridOptions until the ajax request 
        /// is finished. Note that this disables paging, sorting and all actions on toolbar, if any.
        /// </summary>
        /// <param name="loadUi">Load ui mode</param>
        public JqGridOptions setLoadUi(LoadUi loadUi)
        {
            this.loadui = loadUi;
            return this;
        }

        /// <summary>
        /// This parameter makes sense only when multiselect option is set to true. 
        /// Defines the key which will be pressed 
        /// when we make a multiselection. The possible values are: 
        /// 'shiftKey' - the user should press Shift Key 
        /// 'altKey' - the user should press Alt Key 
        /// 'ctrlKey' - the user should press Ctrl Key
        /// </summary>
        /// <param name="multiKey">Key to multiselect</param>
        public JqGridOptions setMultiKey(MultiKey multiKey)
        {
            this.multikey = multiKey;
            return this;
        }

        /// <summary>
        /// This option works only when multiselect = true. When multiselect is set to true, clicking anywhere 
        /// on a row selects that row; when multiboxonly is also set to true, the multiselection is done only 
        /// when the checkbox is clicked (Yahoo style). Clicking in any other row (suppose the checkbox is 
        /// not clicked) deselects all rows and the current row is selected. (default: false)
        /// </summary>
        /// <param name="multiBoxOnly">Boolean indicating if multiboxonly is enforced</param>
        public JqGridOptions setMultiBoxOnly(bool multiBoxOnly)
        {
            this.multiboxonly = multiBoxOnly;
            return this;
        }

        /// <summary>
        /// If this flag is set to true a multi selection of rows is enabled. A new column 
        /// at the left side is added. Can be used with any datatype option. (default: false)
        /// </summary>
        /// <param name="multiSelect">Boolean indicating if multiselect is enabled</param>
        public JqGridOptions setMultiSelect(bool multiSelect = true)
        {
            this.multiselect = multiSelect;
            return this;
        }

        /// <summary>
        /// Determines the width of the multiselect column if multiselect is set to true. (default: 20)
        /// </summary>
        /// <param name="multiSelectWidth"></param>
        public JqGridOptions setMultiSelectWidth(int multiSelectWidth)
        {
            this._multiSelectWidth = multiSelectWidth;
            return this;
        }

        /// <summary>
        /// Set the initial number of selected page when we make the request.This parameter is passed to the url 
        /// for use by the server routine retrieving the data (default: 1)
        /// </summary>
        /// <param name="page">Number of page</param>
        public JqGridOptions setPage(int page)
        {
            this._page = page;
            return this;
        }

        /// <summary>
        /// If pagername is specified a pagerelement is automatically added to the JqGridOptions 
        /// </summary>
        /// <param name="pager">Id/name of pager</param>
        public JqGridOptions setPager(string pager)
        {
            this.pager = pager;
            return this;
        }

        /// <summary>
        /// Determines the position of the pager in the grid. By default the pager element
        /// when created is divided in 3 parts (one part for pager, one part for navigator 
        /// buttons and one part for record information) (default: center)
        /// </summary>
        /// <param name="pagerPos">Position of pager</param>
        public JqGridOptions setPagerPos(PagerPos pagerPos)
        {
            this._pagerPos = pagerPos;
            return this;
        }

        /// <summary>
        /// Determines if the pager buttons should be displayed if pager is available. Valid 
        /// only if pager is set correctly. The buttons are placed in the pager bar. (default: true)
        /// </summary>
        /// <param name="pgButtons">Boolean indicating if pager buttons are displayed</param>
        public JqGridOptions setPgButtons(bool pgButtons)
        {
            this._pgButtons = pgButtons;
            return this;
        }

        /// <summary>
        /// Determines if the input box, where the user can change the number of the requested page, 
        /// should be available. The input box appears in the pager bar. (default: false)
        /// </summary>
        /// <param name="pgInput">Boolean indicating if pager input is available</param>
        public JqGridOptions setPgInput(bool pgInput)
        {
            this._pgInput = pgInput;
            return this;
        }

        /// <summary>
        /// Show information about current page status. The first value is the current loaded page. 
        /// The second value is the total number of pages (default is set in language file)
        /// Example: "Page {0} of {1}"
        /// </summary>
        /// <param name="pgText">Current page status text</param>
        public JqGridOptions setPgText(string pgText)
        {
            this._pgText = pgText;
            return this;
        }

        /// <summary>
        /// Determines the position of the record information in the pager. Can be left, center, right 
        /// (default: right)
        /// Warning: When pagerpos en recordpos are equally set, pager is hidden.        
        /// </summary>
        /// <param name="recordPos">Position of record information</param>
        public JqGridOptions setRecordPos(RecordPos recordPos)
        {
            this._recordPos = recordPos;
            return this;
        }

        /// <summary>
        /// Represent information that can be shown in the pager. This option is valid if viewrecords 
        /// option is set to true. This text appears only if the total number of records is greater then 
        /// zero.
        /// In order to show or hide information the items between {} mean the following: {0} the 
        /// start position of the records depending on page number and number of requested records; 
        /// {1} - the end position {2} - total records returned from the data (default defined in language file)
        /// </summary>
        /// <param name="recordText">Record Text</param>
        public JqGridOptions setRecordText(string recordText)
        {
            this._recordText = recordText;
            return this;
        }

        /// <summary>
        /// Defines the type of request to make (“POST” or “GET”) (default: GET)
        /// </summary>
        /// <param name="requestType">Request type</param>
        public JqGridOptions setRequestType(RequestType requestType)
        {
            this._requestType = requestType;
            return this;
        }

        /// <summary>
        /// Assigns a class to columns that are resizable so that we can show a resize 
        /// handle (default: empty string)
        /// </summary>
        /// <param name="resizeClass"></param>
        /// <returns></returns>
        public JqGridOptions setResizeClass(string resizeClass)
        {
            this._resizeClass = resizeClass;
            return this;
        }

        /// <summary>
        /// An array to construct a select box element in the pager in which we can change the number 
        /// of the visible rows. When changed during the execution, this parameter replaces the rowNum 
        /// parameter that is passed to the url. If the array is empty the element does not appear 
        /// in the pager. Typical you can set this like [10,20,30]. If the rowNum parameter is set to 
        /// 30 then the selected value in the select box is 30.
        /// </summary>
        /// <example>
        /// setRowList(new int[]{10,20,50})
        /// </example>
        /// <param name="rowList">List of rows per page</param>
        public JqGridOptions setRowList(int[] rowList)
        {
            this.rowList = rowList;
            return this;
        }

        /// <summary>
        /// Sets how many records we want to view in the grid. This parameter is passed to the url 
        /// for use by the server routine retrieving the data. Note that if you set this parameter 
        /// to 10 (i.e. retrieve 10 records) and your server return 15 then only 10 records will be 
        /// loaded. Set this parameter to -1 (unlimited) to disable this checking. (default: 20)
        /// </summary>
        /// <param name="rowNum">Number of rows per page</param>
        public JqGridOptions setRowNum(int rowNum)
        {
            this.rowNum = rowNum;
            return this;
        }

        /// <summary>
        /// If this option is set to true, a new column at the leftside of the JqGridOptions is added. The purpose of 
        /// this column is to count the number of available rows, beginning from 1. In this case 
        /// colModel is extended automatically with a new element with name - 'rn'. Also, be careful 
        /// not to use the name 'rn' in colModel
        /// </summary>
        /// <param name="rowNumbers">Boolean indicating if rownumbers are enabled</param>
        public JqGridOptions setRowNumbers(bool rowNumbers)
        {
            this.rownumbers = rowNumbers;
            return this;
        }

        /// <summary>
        /// Determines the width of the row number column if rownumbers option is set to true. (default: 25)
        /// </summary>
        /// <param name="rowNumWidth">Width of rownumbers column</param>
        public JqGridOptions setRowNumWidth(int rowNumWidth)
        {
            this.rownumWidth = rowNumWidth;
            return this;
        }


        /// <summary>
        /// function (item)
        /// </summary>
        /// <param name="rowNumWidth"></param>
        /// <returns></returns>
        public JqGridOptions setRowAttr(string rowAttr)
        {
            this.rowattr = new JRaw(rowAttr);
            return this;
        }





        /// <summary>
        /// Creates dynamic scrolling grids. When enabled, the pager elements are disabled and we can use the 
        /// vertical scrollbar to load data. When set to true the JqGridOptions will always hold all the items from the 
        /// start through to the latest point ever visited. 
        /// When scroll is set to an integer value (eg 1), the JqGridOptions will just hold the visible lines. This allow us to 
        /// load the data at portions whitout to care about the memory leaks. (default: false)
        /// </summary>
        /// <param name="scroll">Boolean indicating if scroll is enforced</param>
        public JqGridOptions setScroll(bool scroll)
        {
            this._scroll = scroll;
            if (this._scrollInt.HasValue)
            {
                throw new InvalidOperationException("You can't set scroll to both a boolean and an integer at the same time, please choose one.");
            }
            return this;
        }

        /// <summary>
        /// Creates dynamic scrolling grids. When enabled, the pager elements are disabled and we can use the 
        /// vertical scrollbar to load data. When set to true the JqGridOptions will always hold all the items from the 
        /// start through to the latest point ever visited. 
        /// When scroll is set to an integer value (eg 1), the JqGridOptions will just hold the visible lines. This allow us to 
        /// load the data at portions whitout to care about the memory leaks. (default: false)
        /// </summary>
        /// <param name="scroll">When integer value is set (eg 1) scroll is enforced</param>
        public JqGridOptions setScroll(int scroll)
        {
            this._scrollInt = scroll;
            if (this._scroll.HasValue)
            {
                throw new InvalidOperationException("You can't set scroll to both a boolean and an integer at the same time, please choose one.");
            }
            return this;
        }

        /// <summary>
        /// Determines the width of the vertical scrollbar. Since different browsers interpret this width 
        /// differently (and it is difficult to calculate it in all browsers) this can be changed. (default: 18)
        /// </summary>
        /// <param name="scrollOffset">Scroll offset</param>
        public JqGridOptions setScrollOffset(int scrollOffset)
        {
            this._scrollOffset = scrollOffset;
            return this;
        }

        /// <summary>
        /// When enabled, selecting a row with setSelection scrolls the JqGridOptions so that the selected row is visible. 
        /// This is especially useful when we have a verticall scrolling JqGridOptions and we use form editing with 
        /// navigation buttons (next or previous row). On navigating to a hidden row, the JqGridOptions scrolls so the 
        /// selected row becomes visible. (default: false)
        /// </summary>
        /// <param name="scrollRows">Boolean indicating if scrollrows is enabled</param>
        public JqGridOptions setScrollRows(bool scrollRows)
        {
            this._scrollRows = scrollRows;
            return this;
        }

        /// <summary>
        /// This controls the timeout handler when scroll is set to 1. (default: 200 milliseconds)
        /// </summary>
        /// <param name="scrollTimeout">Scroll timeout in milliseconds</param>
        /// <returns></returns>
        public JqGridOptions setScrollTimeout(int scrollTimeout)
        {
            this._scrollTimeout = scrollTimeout;
            return this;
        }

        /// <summary>
        /// This option describes the type of calculation of the initial width of each column 
        /// against the width of the grid. If the value is true and the value in width option 
        /// is set then: Every column width is scaled according to the defined option width. 
        /// Example: if we define two columns with a width of 80 and 120 pixels, but want the 
        /// JqGridOptions to have a 300 pixels - then the columns are recalculated as follow: 
        /// 1- column = 300(new width)/200(sum of all width)*80(column width) = 120 and 2 column = 300/200*120 = 180. 
        /// The JqGridOptions width is 300px. If the value is false and the value in width option is set then: 
        /// The width of the JqGridOptions is the width set in option. 
        /// The column width are not recalculated and have the values defined in colModel. (default: true)
        /// </summary>
        /// <param name="shrinkToFit">Boolean indicating if shrink to fit is enforced</param>
        public JqGridOptions setShrinkToFit(bool shrinkToFit)
        {
            this.shrinkToFit = shrinkToFit;
            return this;
        }

        /// <summary>
        /// Determines how the search should be applied. If this option is set to true search is started when 
        /// the user hits the enter key. If the option is false then the search is performed immediately after 
        /// the user presses some character. (default: true
        /// </summary>
        /// <param name="searchOnEnter">Indicates if search is started on enter</param>
        public JqGridOptions setSearchOnEnter(bool searchOnEnter)
        {
            this._searchOnEnter = searchOnEnter;
            return this;
        }

        /// <summary>
        /// Enables toolbar searching / filtering
        /// </summary>
        /// <param name="searchToolbar">Indicates if toolbar searching is enabled</param>
        public JqGridOptions setSearchToolbar(bool searchToolbar)
        {
            this._searchToolbar = searchToolbar;
            return this;
        }

        /// <summary>
        /// When set to true adds clear button to clear all search entries (default: false)
        /// </summary>
        /// <param name="searchClearButton"></param>
        /// <returns></returns>
        public JqGridOptions setSearchClearButton(bool searchClearButton)
        {
            this._searchClearButton = searchClearButton;
            return this;
        }

        /// <summary>
        /// When set to true adds toggle button to toggle search toolbar (default: false)
        /// </summary>
        /// <param name="searchToggleButton">Indicates if toggle button is displayed</param>
        public JqGridOptions setSearchToggleButton(bool searchToggleButton)
        {
            this._searchToggleButton = searchToggleButton;
            return this;
        }

        /// <summary>
        /// If enabled all sort icons are visible for all columns which are sortable (default: false)
        /// </summary>
        /// <param name="showAllSortIcons">Boolean indicating if all sorting icons should be displayed</param>
        public JqGridOptions setShowAllSortIcons(bool showAllSortIcons)
        {
            this._showAllSortIcons = showAllSortIcons;
            return this;
        }

        /// <summary>
        /// Sets direction in which sort icons are displayed (default: vertical)
        /// </summary>
        /// <param name="sortIconDirection">Direction in which sort icons are displayed</param>
        public JqGridOptions setSortIconDirection(Direction sortIconDirection)
        {
            this._sortIconDirection = sortIconDirection;
            return this;
        }

        /// <summary>
        /// If enabled columns are sorted when header is clicked (default: true)
        /// Warning, if disabled and setShowAllSortIcons is set to false, sorting will
        /// be effectively disabled
        /// </summary>
        /// <param name="sortOnHeaderClick">Boolean indicating if columns will sort on headerclick</param>
        /// <returns></returns>
        public JqGridOptions setSortOnHeaderClick(bool sortOnHeaderClick)
        {
            this._sortOnHeaderClick = sortOnHeaderClick;
            return this;
        }

        /// <summary>
        /// The initial sorting name when we use datatypes xml or json (data returned from server). 
        /// This parameter is added to the url. If set and the index (name) matches the name from the
        /// colModel then by default an image sorting icon is added to the column, according to 
        /// the parameter sortorder.
        /// </summary>
        /// <param name="sortName"></param>
        public JqGridOptions setSortName(string sortName)
        {
            this._sortName = sortName;
            return this;
        }

        /// <summary>
        /// The initial sorting order when we use datatypes xml or json (data returned from server).
        /// This parameter is added to the url. Two possible values - asc or desc. (default: asc)
        /// </summary>
        /// <param name="sortOrder">Sortorder</param>
        public JqGridOptions setSortOrder(SortOrder sortOrder)
        {
            this.sortorder = sortOrder;
            return this;
        }

        /// <summary>
        /// This option enabled the toolbar of the grid.  When we have two toolbars (can be set using setToolbarPosition)
        /// then two elements (div) are automatically created. The id of the top bar is constructed like 
        /// “t_”+id of the JqGridOptions and the bottom toolbar the id is “tb_”+id of the grid. In case when 
        /// only one toolbar is created we have the id as “t_” + id of the grid, independent of where 
        /// this toolbar is created (top or bottom). You can use jquery to add elements to the toolbars.
        /// </summary>
        /// <param name="toolbar">Boolean indicating if toolbar is enabled</param>
        public JqGridOptions setToolbar(bool toolbar)
        {
            this._toolbar = toolbar;
            return this;
        }

        /// <summary>
        /// Sets toolbarposition (default: top)
        /// </summary>
        /// <param name="toolbarPosition">Position of toolbar</param>
        public JqGridOptions setToolbarPosition(ToolbarPosition toolbarPosition)
        {
            this._toolbarPosition = toolbarPosition;
            return this;
        }

        /// <summary>
        /// When enabled this option place a pager element at top of the JqGridOptions below the caption 
        /// (if available). If another pager is defined both can coexists and are refreshed in sync. 
        /// (default: false)
        /// </summary>
        /// <param name="topPager">Boolean indicating if toppager is enabled</param>
        public JqGridOptions setTopPager(bool topPager)
        {
            this._topPager = topPager;
            return this;
        }

        /// <summary>
        /// The url of the file that holds the request
        /// </summary>
        /// <param name="url">Data url</param>
        public JqGridOptions setUrl(string url)
        {
            this._url = url;
            return this;
        }

        /// <summary>
        /// If true, jqGrid displays the beginning and ending record number in the grid, 
        /// out of the total number of records in the query. 
        /// This information is shown in the pager bar (bottom right by default)in this format: 
        /// “View X to Y out of Z”. 
        /// If this value is true, there are other parameters that can be adjusted, 
        /// including 'emptyrecords' and 'recordtext'. (default: false)
        /// </summary>
        /// <param name="viewRecords">Boolean indicating if recordnumbers are shown in grid</param>
        public JqGridOptions setViewRecords(bool viewRecords)
        {
            this.viewrecords = viewRecords;
            return this;
        }

        /// <summary>
        /// If this option is not set, the width of the JqGridOptions is a sum of the widths of the columns 
        /// defined in the colModel (in pixels). If this option is set, the initial width of each 
        /// column is set according to the value of shrinkToFit option.
        /// </summary>
        /// <param name="width">Width in pixels</param>
        public JqGridOptions setWidth(int width)
        {
            this.width = width;
            return this;
        }

        //public JqGridOptions setWidth(string width)
        //{
        //    this.width = width;
        //    return this;
        //}

        /// <summary>
        /// afterInsertRow: function(rowid, rowdata, rowelem) 
        /// 
        /// This event fires after each inserted row.
        /// Variables available in call:
        /// 'rowid': Id of the inserted row 
        /// 'rowdata': An array of the data to be inserted into the row. This is array of type name-value, where the name is a name from colModel 
        /// 'rowelem': The element from the response. If the data is xml this is the xml element of the row; 
        /// if the data is json this is array containing all the data for the row 
        /// Note: this event does not fire if gridview option is set to true
        /// </summary>
        /// <param name="onAfterInsertRow">Script to be executed</param>
        public JqGridOptions setOnAfterInsertRow(string onAfterInsertRow)
        {
            this.onAfterInsertRow = new JRaw(onAfterInsertRow);
            return this;
        }

        /// <summary>
        /// This event fires before requesting any data. Does not fire if datatype is function
        /// Variables available in call: None
        /// </summary>
        /// <param name="onBeforeRequest">Script to be executed</param>
        public JqGridOptions onBeforeRequest(string onBeforeRequest)
        {
            this._onBeforeRequest = onBeforeRequest;
            return this;
        }

        /// <summary>
        /// This event fires when the user clicks on the row, but before selecting it.
        /// Variables available in call:
        /// 'rowid': The id of the row. 
        /// 'e': The event object 
        /// This event should return boolean true or false. If the event returns true the selection 
        /// is done. If the event returns false the row is not selected and any other action if defined 
        /// does not occur.
        /// </summary>
        /// <param name="onBeforeSelectRow">function(rowid, e)</param>
        public JqGridOptions setOnBeforeSelectRow(string onBeforeSelectRow)
        {
            this.beforeSelectRow = new JRaw(onBeforeSelectRow);
            return this;
        }

        /// <summary>
        /// This fires after all the data is loaded into the JqGridOptions and all the other processes are complete. 
        /// Also the event fires independent from the datatype parameter and after sorting paging and etc.
        /// Variables available in call: None
        /// </summary>
        /// <param name="onGridComplete">Script to be executed</param>
        public JqGridOptions setOnGridComplete(string onGridComplete)
        {
            this.gridComplete = new JRaw(onGridComplete);
            return this;
        }

        /// <summary>
        /// A pre-callback to modify the XMLHttpRequest object (xhr) before it is sent. Use this to set 
        /// custom headers etc. The XMLHttpRequest is passed as the only argument.
        /// Variables available in call:
        /// 'xhr': The XMLHttpRequest
        /// </summary>
        /// <param name="onLoadBeforeSend">Script to be executed</param>
        public JqGridOptions onLoadBeforeSend(string onLoadBeforeSend)
        {
            this._onLoadBeforeSend = onLoadBeforeSend;
            return this;
        }

        /// <summary>
        /// This event is executed immediately after every server request. 
        /// Variables available in call:
        /// 'xhr': The XMLHttpRequest
        /// </summary>
        /// <param name="onLoadComplete">Script to be executed</param>
        public JqGridOptions setLoadComplete(string onLoadComplete)
        {
            loadComplete = new JRaw(onLoadComplete);
            return this;
        }

        /// <summary>
        /// A function to be called if the request fails.
        ///  Variables available in call:
        ///  'xhr': The XMLHttpRequest
        ///  'status': String describing the type of error
        ///  'error': Optional exception object, if one occurred
        /// </summary>
        /// <param name="onLoadError">Script to be executed</param>
        public JqGridOptions onLoadError(string onLoadError)
        {
            this._onLoadError = onLoadError;
            return this;
        }

        /// <summary>
        /// Fires when we click on a particular cell in the grid.
        /// Variables available in call:
        /// 'rowid': The id of the row 
        /// 'iCol': The index of the cell,
        /// 'cellcontent': The content of the cell,
        /// 'e': The event object element where we click.
        /// (Note that this available when we are not using cell editing module 
        /// and is disabled when using cell editing).
        /// </summary>
        /// <param name="onCellSelect">Script to be executed</param>
        public JqGridOptions onCellSelect(string onCellSelect)
        {
            this._onCellSelect = onCellSelect;
            return this;
        }

        /// <summary>
        /// Raised immediately after row was double clicked. 
        /// Variables available in call:
        /// 'rowid': The id of the row, 
        /// 'iRow': The index of the row (do not mix this with the rowid),
        /// 'iCol': The index of the cell. 
        /// 'e': The event object
        /// </summary>
        /// <param name="onDblClickRow">Script to be executed</param>
        public JqGridOptions setOnDblClickRow(string onDblClickRow)
        {
            ondblClickRow = new JRaw(onDblClickRow);
            return this;
        }

        /// <summary>
        /// Fires after clicking hide or show JqGridOptions (hidegrid:true)
        /// Variables available in call:
        /// 'gridstate': The state of the JqGridOptions - can have two values - visible or hidden
        /// </summary>
        /// <param name="onHeaderClick">Script to be executed</param>
        public JqGridOptions onHeaderClick(string onHeaderClick)
        {
            this._onHeaderClick = onHeaderClick;
            return this;
        }

        /// <summary>
        /// This event fires after click on [page button] and before populating the data. 
        /// Also works when the user enters a new page number in the page input box 
        /// (and presses [Enter]) and when the number of requested records is changed via 
        /// the select box.
        /// If this event returns 'stop' the processing is stopped and you can define your 
        /// own custom paging
        /// Variables available in call:
        /// 'pgButton': first,last,prev,next in case of button click, records in case when 
        /// a number of requested rows is changed and user when the user change the number of the requested page
        /// </summary>
        /// <param name="onPaging">Script to be executed</param>
        public JqGridOptions onPaging(string onPaging)
        {
            this._onPaging = onPaging;
            return this;
        }

        /// <summary>
        /// Raised immediately after row was right clicked. 
        /// Variables available in call:
        /// 'rowid': The id of the row, 
        /// 'iRow': The index of the row (do not mix this with the rowid),
        /// 'iCol': The index of the cell. 
        /// 'e': The event object
        /// Note - this event does not work in Opera browsers, since Opera does not support oncontextmenu event
        /// </summary>
        /// <param name="onRightClickRow">Script to be executed</param>
        public JqGridOptions onRightClickRow(string onRightClickRow)
        {
            this._onRightClickRow = onRightClickRow;
            return this;
        }

        /// <summary>
        /// Ex.: function(rowIds, allChecked)
        /// </summary>
        /// <param name="onSelectAll"></param>
        /// <returns></returns>
        public JqGridOptions SetOnSelectAll(string onSelectAll)
        {
            this.onSelectAll = new JRaw(onSelectAll);
            return this;
        }


        /// <summary>
        /// Raised immediately when row is clicked. 
        /// Variables available in function call:
        /// 'rowid': The id of the row,
        /// 'status': Tthe status of the selection. Can be used when multiselect is set to true. 
        /// true if the row is selected, false if the row is deselected.
        /// <param name="onSelectRow">function(id)</param>
        /// </summary>
        public JqGridOptions setOnSelectRow(string onSelectRow)
        {
            this.onSelectRow = new JRaw(onSelectRow);
            return this;
        }


        /// <summary>
        /// Raised immediately after sortable column was clicked and before sorting the data.
        /// Variables available in call:
        /// 'index': The index name from colModel
        /// 'iCol': The index of column, 
        /// 'sortorder': The new sorting order - can be 'asc' or 'desc'. 
        /// If this event returns 'stop' the sort processing is stopped and you can define your own custom sorting
        /// </summary>
        /// <param name="onSortCol">Script to be executed</param>
        public JqGridOptions onSortCol(string onSortCol)
        {
            this._onSortCol = onSortCol;
            return this;
        }

        /// <summary>
        /// Event which is called when we start resizing a column. 
        /// Variables available in call:
        /// 'event':  The event object
        /// 'index': The index of the column in colModel.
        /// </summary>
        /// <param name="onResizeStart">Script to be executed</param>
        public JqGridOptions onResizeStart(string onResizeStart)
        {
            this._onResizeStart = onResizeStart;
            return this;
        }

        /// <summary>
        /// Event which is called after the column is resized.
        /// Variables available in call:
        /// 'newwidth': The new width of the column
        /// 'index': The index of the column in colModel.
        /// </summary>
        /// <param name="onResizeStop">Script to be executed</param>
        public JqGridOptions onResizeStop(string onResizeStop)
        {
            this._onResizeStop = onResizeStop;
            return this;
        }

        /// <summary>
        /// If this event is set it can serialize the data passed to the ajax request. 
        /// The function should return the serialized data. This event can be used when 
        /// custom data should be passed to the server - e.g - JSON string, XML string and etc. 
        /// Variables available in call:
        /// 'postData': Posted data
        /// </summary>
        /// <param name="onSerializeGridData">Script to be executed</param>
        public JqGridOptions onSerializeGridData(string onSerializeGridData)
        {
            this._onSerializeGridData = onSerializeGridData;
            return this;
        }
        /// <summary>
        /// Creates and returns javascript + required html elements to render grid
        /// </summary>
        /// <returns></returns>
        public String ToString2()
        {
            // Create javascript
            StringBuilder script = new StringBuilder();

            // Start script
            script.AppendLine("<script type=\"text/javascript\">");
            script.AppendLine("jQuery(document).ready(function () {");
            script.AppendLine("jQuery('#" + this._id + "').jqGrid({");

            // MultiSelect
            //if (this._multiSelect.HasValue) script.AppendFormat("multiselect: {0},", this._multiSelect.Value.ToString().ToLower()).AppendLine();

            // MultiSelectWidth
            if (this._multiSelectWidth.HasValue) script.AppendFormat("multiselectWidth: {0},", this._multiSelectWidth.Value.ToString()).AppendLine();

            // Page
            if (this._page.HasValue) script.AppendFormat("page:{0},", this._page.Value).AppendLine();

            //// Pager
            //if (!string.IsNullOrWhiteSpace(this.pager)) script.AppendFormat("pager:'#{0}',", this.pager).AppendLine();

            // PagerPos
            if (this._pagerPos.HasValue) script.AppendFormat("pagerpos: '{0}',", this._pagerPos.ToString()).AppendLine();

            // PgButtons
            if (this._pgButtons.HasValue) script.AppendFormat("pgbuttons:{0},", this._pgButtons.Value.ToString().ToLower()).AppendLine();

            // PgInput
            if (this._pgInput.HasValue)
            {
                script.AppendFormat("pginput: {0},", this._pgInput.Value.ToString().ToLower()).AppendLine();
            }
            else
            {
                this._pgInput = false;
                script.AppendFormat("pginput: {0},", this._pgInput.Value.ToString().ToLower()).AppendLine();
            }

            // PGText
            if (!string.IsNullOrWhiteSpace(this._pgText)) script.AppendFormat("pgtext: '{0}',", this._pgText).AppendLine();

            // RecordPos
            if (this._recordPos.HasValue) script.AppendFormat("recordpos: '{0}',", this._recordPos.Value).AppendLine();

            // RecordText
            if (!string.IsNullOrWhiteSpace(this._recordText)) script.AppendFormat("recordtext: '{0}',", this._recordText).AppendLine();

            // Request Type
            if (this._requestType.HasValue) script.AppendFormat("mtype: '{0}',", this._requestType.ToString()).AppendLine();

            // ResizeClass
            if (!string.IsNullOrWhiteSpace(this._resizeClass)) script.AppendFormat("resizeclass: '{0}',", this._resizeClass).AppendLine();

            // Rowlist
            if (this.rowList != null) script.AppendFormat("rowList: [{0}],", string.Join(",", ((from p in this.rowList select p.ToString()).ToArray()))).AppendLine();

            //// Rownum
            //if (this._rowNum.HasValue) script.AppendFormat("rowNum:{0},", this._rowNum.Value).AppendLine();

            // Rownumbers
            //if (this.rowNumbers.HasValue) script.AppendFormat("rownumbers: {0},", this.rowNumbers.Value.ToString().ToLower()).AppendLine();

            // RowNumWidth
            //if (this._rowNumWidth.HasValue) script.AppendFormat("rownumWidth: {0},", this._rowNumWidth.Value.ToString()).AppendLine();

            // Scroll (setters make sure either scroll or scrollint is set, never both)
            if (this._scroll.HasValue) script.AppendFormat("scroll:{0},", this._scroll.ToString().ToLower()).AppendLine();
            if (this._scrollInt.HasValue) script.AppendFormat("scroll:{0},", this._scrollInt.Value).AppendLine();

            // ScrollOffset
            if (this._scrollOffset.HasValue) script.AppendFormat("scrollOffset: {0},", this._scrollOffset.Value).AppendLine();

            // ScrollRows
            if (this._scrollRows.HasValue) script.AppendFormat("scrollrows: {0},", this._scrollRows.ToString().ToLower()).AppendLine();

            // ScrollTimeout
            if (this._scrollTimeout.HasValue) script.AppendFormat("scrollTimeout: {0},", this._scrollTimeout.Value).AppendLine();

            // Sortname
            if (!string.IsNullOrWhiteSpace(this._sortName)) script.AppendFormat("sortname: '{0}',", this._sortName).AppendLine();

            // Sorticons
            if (this._showAllSortIcons.HasValue || this._sortIconDirection.HasValue || this._sortOnHeaderClick.HasValue)
            {
                // Set defaults
                if (!this._showAllSortIcons.HasValue) this._showAllSortIcons = false;
                if (!this._sortIconDirection.HasValue) this._sortIconDirection = Direction.vertical;
                if (!this._sortOnHeaderClick.HasValue) this._sortOnHeaderClick = true;

                script.AppendFormat("viewsortcols: [{0},'{1}',{2}],", this._showAllSortIcons.Value.ToString().ToLower(), this._sortIconDirection.ToString(), this._sortOnHeaderClick.Value.ToString().ToLower()).AppendLine();
            }

            // Shrink to fit
            //if (this.shrinkToFit.HasValue) script.AppendFormat("shrinkToFit: {0},", this.shrinkToFit.Value.ToString().ToLower()).AppendLine();

            //// Sortorder
            //if (this.sortOrder.HasValue) script.AppendFormat("sortorder: '{0}',", this.sortOrder.Value.ToString()).AppendLine();

            // Toolbar
            if (_toolbar.HasValue) script.AppendFormat("toolbar: [{0},\"{1}\"],", this._toolbar.Value.ToString().ToLower(), this._toolbarPosition.ToString()).AppendLine();

            // Toppager
            if (this._topPager.HasValue) script.AppendFormat("toppager: {0},", this._topPager.Value.ToString().ToLower()).AppendLine();

            // Url
            if (!string.IsNullOrWhiteSpace(this._url)) script.AppendFormat("url:'{0}',", this._url).AppendLine();

            //// View records
            //if (this._viewRecords.HasValue) script.AppendFormat("viewrecords: {0},", this._viewRecords.Value.ToString().ToLower()).AppendLine();

            //// Width
            //if (this.width.HasValue) script.AppendFormat("width:'{0}',", this.width.Value).AppendLine();

            // onAfterInsertRow
            //if (!string.IsNullOrWhiteSpace(this.onAfterInsertRow)) script.AppendFormat("afterInsertRow: function(rowid, rowdata, rowelem) {{{0}}},", this.onAfterInsertRow).AppendLine();

            // onBeforeRequest
            if (!string.IsNullOrWhiteSpace(this._onBeforeRequest)) script.AppendFormat("beforeRequest: function() {{{0}}},", this._onBeforeRequest).AppendLine();

            // onBeforeSelectRow
            //if (!string.IsNullOrWhiteSpace(this.beforeSelectRow)) script.AppendFormat("beforeSelectRow: function(rowid, e) {{{0}}},", this.beforeSelectRow).AppendLine();

            // onGridComplete
            //if (!string.IsNullOrWhiteSpace(this.onGridComplete)) script.AppendFormat("gridComplete: function() {{{0}}},", this.onGridComplete).AppendLine();

            // onLoadBeforeSend
            if (!string.IsNullOrWhiteSpace(this._onLoadBeforeSend)) script.AppendFormat("loadBeforeSend: function(xhr) {{{0}}},", this._onLoadBeforeSend).AppendLine();

            // onLoadComplete
            //if (!string.IsNullOrWhiteSpace(this._onLoadComplete)) script.AppendFormat("loadComplete: function(xhr) {{{0}}},", this._onLoadComplete).AppendLine();

            // onLoadError
            if (!string.IsNullOrWhiteSpace(this._onLoadError)) script.AppendFormat("loadError: function(xhr, status, error) {{{0}}},", this._onLoadError).AppendLine();

            // onCellSelect
            if (!string.IsNullOrWhiteSpace(this._onCellSelect)) script.AppendFormat("onCellSelect: function(rowid, iCol, cellcontent, e) {{{0}}},", this._onCellSelect).AppendLine();

            // onDblClickRow
            //if (!string.IsNullOrWhiteSpace(this.ondblClickRow)) script.AppendFormat("ondblClickRow: function(rowid, iRow, iCol, e) {{{0}}},", this.ondblClickRow).AppendLine();

            // onHeaderClick
            if (!string.IsNullOrWhiteSpace(this._onHeaderClick)) script.AppendFormat("onHeaderClick: function(gridstate) {{{0}}},", this._onHeaderClick).AppendLine();

            // onPaging
            if (!string.IsNullOrWhiteSpace(this._onPaging)) script.AppendFormat("onPaging: function(pgButton) {{{0}}},", this._onPaging).AppendLine();

            // onRightClickRow
            if (!string.IsNullOrWhiteSpace(this._onRightClickRow)) script.AppendFormat("onRightClickRow: function(rowid, iRow, iCol, e) {{{0}}},", this._onRightClickRow).AppendLine();

            // onSelectAll
            //if (!string.IsNullOrWhiteSpace(this.onSelectAll)) script.AppendFormat("onSelectAll: function(aRowids, status) {{{0}}},", this.onSelectAll).AppendLine();

            // onSelectRow event
            //if (!string.IsNullOrWhiteSpace(this.onSelectRow)) script.AppendFormat("onSelectRow: function(rowid, status) {{{0}}},", this.onSelectRow).AppendLine();

            // onSortCol
            if (!string.IsNullOrWhiteSpace(this._onSortCol)) script.AppendFormat("onSortCol: function(index, iCol, sortorder) {{{0}}},", this._onSortCol).AppendLine();

            // onResizeStart
            if (!string.IsNullOrWhiteSpace(this._onResizeStart)) script.AppendFormat("resizeStart: function(event, index) {{{0}}},", this._onResizeStart).AppendLine();

            // onResizeStop
            if (!string.IsNullOrWhiteSpace(this._onResizeStop)) script.AppendFormat("resizeStop: function(newwidth, index) {{{0}}},", this._onResizeStop).AppendLine();

            // onSerializeGridData
            if (!string.IsNullOrWhiteSpace(this._onSerializeGridData)) script.AppendFormat("serializeGridData: function(postData) {{{0}}},", this._onSerializeGridData).AppendLine();


            // Colmodel
            script.AppendLine("colModel: [");
            //string colModel = string.Join(",", ((from c in this._columns select c.ToString()).ToArray()));
            //script.AppendLine(colModel);
            script.AppendLine("]");

            // End jqGrid call
            script.AppendLine("});");

            // Search clear button
            if (this._searchToolbar == true && this._searchClearButton.HasValue && !string.IsNullOrWhiteSpace(this.pager) && this._searchClearButton.Value == true)
            {
                script.AppendLine("jQuery('#" + this._id + "').jqGrid('navGrid',\"#" + this.pager + "\",{edit:false,add:false,del:false,search:false,refresh:false}); ");
                script.AppendLine("jQuery('#" + this._id + "').jqGrid('navButtonAdd',\"#" + this.pager + "\",{caption:\"Clear\",title:\"Clear Search\",buttonicon :'ui-icon-refresh', onClickButton:function(){mygrid[0].clearToolbar(); }}); ");
            }
            // Search toolbar
            if (this._searchToolbar == true)
            {
                script.Append("jQuery('#" + this._id + "').jqGrid('filterToolbar', {stringResult:true");
                if (this._searchOnEnter.HasValue) script.AppendFormat(", searchOnEnter:{0}", this._searchOnEnter.Value.ToString().ToLower());
                script.AppendLine("});");
            }

            // End script
            script.AppendLine("});");
            script.AppendLine("</script>");

            // Create table which is used to render grid
            var table = new StringBuilder();
            table.AppendFormat("<table id=\"{0}\"></table>", this._id);

            // Create pager element if is set
            var pager = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(this.pager))
            {
                pager.AppendFormat("<div id=\"{0}\"></div>", this.pager);
            }

            // Create toppager element if is set
            var topPager = new StringBuilder();
            if (this._topPager == true)
            {
                topPager.AppendFormat("<div id=\"{0}_toppager\"></div>", this._id);
            }

            // Insert JqGridOptions id where needed (in columns)
            script.Replace("##gridid##", this._id);

            // Return script + required elements
            return script.ToString() + table.ToString() + pager.ToString() + topPager.ToString();
        }
        //public Microsoft.AspNetCore.Html.HtmlString retornaGrid()
        //{
        //    return Microsoft.AspNetCore.Html.HtmlString.Create(this.ToString());
        //}
    }


    public class JqGridFormatOptions
    {
        public string defaultValue { get; set; }
        public char? thousandsSeparator { get; set; }
        public char? decimalSeparator { get; set; }
        public int decimalPlaces { get; set; }
        public string suffix { get; set; }
        public string prefix { get; set; }

        public string baseLinkUrl { get; set; }
        public string addParam { get; set; }
        public string showAction { get; set; }

        public string srcformat { get; set; }
        public string newformat { get; set; }

        [DefaultValue(true)]
        public bool disabled { get; set; } = true;
    }

    public class JqGridReturn
    {
        public int records { get; set; }
        public int page { get; set; }
        public int total { get; set; }
        public object rows { get; set; }
    }

}
