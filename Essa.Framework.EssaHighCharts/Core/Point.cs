using System;
using Newtonsoft.Json;

namespace Highcharts.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class Point
    {
        public string color { get; set; }
        public Data.Chart.Serie drilldown { get; set; }
        public Events.PointEvents events { get; set; }
        public string id { get; set; }
        public Marker marker { get; set; }
        public string name { get; set; }
        public bool? sliced { get; set; }
        public object x { get; set; }
        public object y { get; set; }
        
        public Point()
        { }

        public Point(object oY)
        {
            this.y = oY;
        }

        public Point(object oY, string symbol)
        {
            this.y = oY;
            this.marker = new Marker(symbol);
        }

        public Point(object oX, object oY)
        {
            this.x = oX;
            this.y = oY;
        }

        public Point(object oX, object oY, object id)
        {
            this.x = oX;
            this.y = oY;
            id = id.ToString();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });           
        }
    }
}
