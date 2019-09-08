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
    public class PlotEvents
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
        public string mouseMove
        {
            get
            {
                if (!string.IsNullOrEmpty(_mouseMove))
                    return string.Format("function(event){{ {0} }}", _mouseMove);
                else
                    return null;
            }
            set
            {
                _mouseMove = value;
            }
        }

        [JsonIgnore]
        private string _click;
        [JsonIgnore]
        private string _mouseOver;
        [JsonIgnore]
        private string _mouseOut;
        [JsonIgnore]
        private string _mouseMove;

        public PlotEvents()
        {
            click = String.Empty;
            mouseOver = String.Empty;
            mouseOut = String.Empty;
        }

        public override string ToString()
        {
            List<string> _list = new List<string>();

            if(!string.IsNullOrEmpty(click))
                _list.Add(click);
            
            if (!string.IsNullOrEmpty(mouseOver))
                _list.Add(mouseOver);

            if (!string.IsNullOrEmpty(mouseOut))
                _list.Add(mouseOut);

            if (!string.IsNullOrEmpty(mouseMove))
                _list.Add(mouseMove);

            return string.Join(",", _list.ToArray());
        }
    }   
}
