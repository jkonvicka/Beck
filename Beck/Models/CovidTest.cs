using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Beck.Models
{
    [DataContract]
    public class CovidTest
    {
        public string Date { get; set; }
        public double TestsCount { get; set; }
        public double TestsTotal { get; set; }

        public CovidTest(string date, double testsCount, double testsTotal)
        {
            Date = date;
            TestsCount = testsCount;
            TestsTotal = testsTotal;
        }
    }
}