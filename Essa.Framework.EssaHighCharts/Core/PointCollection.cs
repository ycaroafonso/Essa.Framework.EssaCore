﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Html;

using Newtonsoft.Json;

namespace Highcharts.Core
{

    public class PointCollection : List<Point>
        {
    public override string ToString()
            {
                var keys = new List<string>();

                foreach (Point serie in this)
                {
                    string ignored = JsonConvert.SerializeObject(serie, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    keys.Add(ignored);
                }

                var serialize = string.Join(",", keys.ToArray());
                return serialize;
            }
        }  

}
