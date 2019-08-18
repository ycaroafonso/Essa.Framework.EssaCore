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
    public class ChartEvents
    {
        public string addSeries
        {
            get
            {
                if (!string.IsNullOrEmpty(_addSeries))
                    return string.Format("function(event){{ {0} }}", _addSeries);
                else
                    return null;
            }
            set
            {
                _addSeries = value;
            }
        }
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
        public string load
        {
            get
            {
                if (!string.IsNullOrEmpty(_load))
                    return string.Format("function(event){{ {0} }}", _load);
                else
                    return null;
            }
            set
            {
                _load = value;
            }
        }
        public string redraw
        {
            get
            {
                if (!string.IsNullOrEmpty(_redraw))
                    return string.Format("function(event){{ {0} }}", _redraw);
                else
                    return null;
            }
            set
            {
                _redraw = value;
            }
        }
        public string selection
        {
            get
            {
                if (!string.IsNullOrEmpty(_selection))
                    return string.Format("function(event){{ {0} }}", _selection);
                else
                    return null;
            }
            set
            {
                _selection = value;
            }
        }

        [JsonIgnore]
        private string _addSeries;
        [JsonIgnore]
        private string _click;
        [JsonIgnore]
        private string _load;
        [JsonIgnore]
        private string _redraw;
        [JsonIgnore]
        private string _selection;
        
        public ChartEvents()
        {
            addSeries = String.Empty;
            click = String.Empty;
            load = String.Empty;
            redraw = String.Empty;
            selection = String.Empty;
        }

        public override string ToString()
        {
            List<string> _list = new List<string>();

            if (!string.IsNullOrEmpty(addSeries))
                _list.Add(addSeries);

            if(!string.IsNullOrEmpty(click))
                _list.Add(click);
            
            if (!string.IsNullOrEmpty(load))
                _list.Add(load);
            
            if (!string.IsNullOrEmpty(redraw))
                _list.Add(redraw);
            
            if (!string.IsNullOrEmpty(selection))
                _list.Add(selection);
            
            return string.Join(",", _list.ToArray());
        }
    }   
}
