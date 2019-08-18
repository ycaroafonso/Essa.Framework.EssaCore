using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Html;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Highcharts.Core.Events
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class PointEvents
    {
        public string click 
        {
            get{
                if (!string.IsNullOrEmpty(_click))
                    return string.Format("function(event){{ {0} }}", _click);
                else
                    return null;
            }
            set {
                _click = value;
            }
        }
        public string mouseOver
        {
            get
            {
                if (!string.IsNullOrEmpty(_mouseOver))
                    return string.Format("function(event){{ {{0}} }}", _mouseOver);
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
                    return string.Format("function(event){{ {{0}} }}", _mouseOut);
                else
                    return null;
            }
            set
            {
                _mouseOut = value;
            }
        }
        public string remove
        {
            get
            {
                if (!string.IsNullOrEmpty(_remove))
                    return string.Format("function(event){{ {{0}} }}", _remove);
                else
                    return null;
            }
            set
            {
                _remove = value;
            }
        }
        public string select
        {
            get
            {
                if (!string.IsNullOrEmpty(_select))
                    return string.Format("function(event){{ {{0}} }}", _select);
                else
                    return null;
            }
            set
            {
                _select = value;
            }
        }
        public string unselect
        {
            get
            {
                if (!string.IsNullOrEmpty(_unselect))
                    return string.Format("function(event){{ {{0}} }}", _unselect);
                else
                    return null;
            }
            set
            {
                _unselect = value;
            }
        }
        public string update
        {
            get
            {
                if (!string.IsNullOrEmpty(_update))
                    return string.Format("function(event){{ {{0}} }}", _update);
                else
                    return null;
            }
            set
            {
                _update = value;
            }
        }

        [JsonIgnore]
        private string _click;
        [JsonIgnore]
        private string _mouseOver;
        [JsonIgnore]
        private string _mouseOut;
        [JsonIgnore]
        private string _remove;
        [JsonIgnore]
        private string _select;
        [JsonIgnore]
        private string _unselect;
        [JsonIgnore]
        private string _update;

        public PointEvents()
        {
            click = String.Empty;
            mouseOver = String.Empty;
            mouseOut = String.Empty;
            remove = String.Empty;
            select = String.Empty;
            unselect = String.Empty;
            update = String.Empty;
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
            
            if (!string.IsNullOrEmpty(remove))
                _list.Add(remove);
            
            if (!string.IsNullOrEmpty(select))
                _list.Add(select);
            
            if (!string.IsNullOrEmpty(unselect))
                _list.Add(unselect);
            
            if (!string.IsNullOrEmpty(update))
                _list.Add(update);            

            return string.Join(",", _list.ToArray());
        }
    }
}
