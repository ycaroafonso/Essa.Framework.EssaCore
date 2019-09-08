using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Highcharts.Core.Events
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class PlotOptionEvents
    {
        public string click
        {
            get
            {
                if (!string.IsNullOrEmpty(_click))
                    return string.Format("function(event){{ {0} }}", _click);
                else
                    return null;
            }
            set
            {
                _click = value;
            }
        }
        public string hide
        {
            get
            {
                if (!string.IsNullOrEmpty(_hide))
                    return string.Format("function(event){{ {0} }}", _hide);
                else
                    return null;
            }
            set
            {
                _hide = value;
            }
        }
        public string legendItemClick
        {
            get
            {
                if (!string.IsNullOrEmpty(_legendItemClick))
                    return string.Format("function(event){{ {0} }}", _legendItemClick);
                else
                    return null;
            }
            set
            {
                _legendItemClick = value;
            }
        }
        public string mouseOver
        {
            get
            {
                if (!string.IsNullOrEmpty(_mouseOver))
                    return string.Format("function(event){{ {0} }}", _mouseOver);
                else
                    return null;
            }
            set
            {
                _mouseOver = value;
            }
        }
        public string mouseOut
        {
            get
            {
                if (!string.IsNullOrEmpty(_mouseOut))
                    return string.Format("function(event){{ {0} }}", _mouseOut);
                else
                    return null;
            }
            set
            {
                _mouseOut = value;
            }
        }
        public string show
        {
            get
            {
                if (!string.IsNullOrEmpty(_show))
                    return string.Format("function(event){{ {0} }}", _show);
                else
                    return null;
            }
            set
            {
                _show = value;
            }
        }

        [JsonIgnore]
        private string _click;
        [JsonIgnore]
        private string _hide;
        [JsonIgnore]
        private string _legendItemClick;
        [JsonIgnore]
        private string _mouseOver;
        [JsonIgnore]
        private string _mouseOut;
        [JsonIgnore]
        private string _show;

        public PlotOptionEvents()
        {
            click = String.Empty;
            hide = String.Empty;
            legendItemClick = String.Empty;
            mouseOver = String.Empty;
            mouseOut = String.Empty;
            show = String.Empty;
        }

        public override string ToString()
        {
            List<string> _list = new List<string>();

            if(!string.IsNullOrEmpty(click))
                _list.Add(click);
            
            if (!string.IsNullOrEmpty(hide))
                _list.Add(hide);
            
            if (!string.IsNullOrEmpty(legendItemClick))
                _list.Add(legendItemClick);

            if (!string.IsNullOrEmpty(mouseOver))
                _list.Add(mouseOver);

            if (!string.IsNullOrEmpty(mouseOut))
                _list.Add(mouseOut);

            if (!string.IsNullOrEmpty(show))
                _list.Add(show);
            

            return string.Join(",", _list.ToArray());
        }
    }   
}
