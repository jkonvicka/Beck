using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Beck.Models
{
    [DataContract]
    public class CovidData
    {
        public string Date { get; set; }
        public double DailyCount { get; set; }
        public double TotalCount { get; set; }

        public CovidData(string date, double testsCount, double testsTotal)
        {
            Date = date;
            DailyCount = testsCount;
            TotalCount = testsTotal;
        }
    }
}