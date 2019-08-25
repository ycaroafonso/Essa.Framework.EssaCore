//
//  Copyright (c) 2010, 100loop
//  All rights reserved.
//
//  Authors: 
//           
//           * André Paulovich (paulovich@100loop.com)
//           Blog: http://www.100loop.com/          
//           Talk: andre.paulovich@gmail.com 
//

using System;
using System.Collections.Generic;
using Highcharts.Core.Data.Chart;
using Highcharts.Core;
using Microsoft.AspNetCore.Html;

using Newtonsoft.Json;
using Highcharts.Core.PlotOptions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Highcharts.Core
{
    [Serializable]
    public class SerieCollection : List<Serie>
    {

        public DataLabels dataLabels { get; set; }

        private bool _marked;
        public SerieCollection()
        {
            _marked = false;
        }

        public bool IsTrackingViewState
        {
            get { return _marked; }
        }

        public void LoadViewState(object state)
        {
            if (state != null)
            {

                var t = (Serie[])state;

                Clear();

                foreach (Serie item in t)
                {
                    Add(item);
                }

            }
        }

        public object SaveViewState()
        {

            return ToArray();

        }

        public void TrackViewState()
        {
            _marked = true;
        }

        public override string ToString()
        {
            
            var keys = new List<string>();

            foreach (Serie serie in this)
            {

                string ignored = JsonConvert.SerializeObject(serie, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                keys.Add(ignored);

            }

            var serialize = string.Format("series: [{0}[@DataLabels]]", string.Join(",", keys.ToArray()));

            if (dataLabels != null)
            {
                serialize = serialize.Replace("[@DataLabels]", ", " + dataLabels.ToString());
            }
            else
            {
                serialize = serialize.Replace("[@DataLabels]", string.Empty);
            }

            return serialize;            

        }

    }
}