using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace Beck.Models
{
    public class HomeDataBag
    {
        public List<CovidData> CovidTestList { get; set;}
        public List<CovidData> CovidInfectionList { get; set; }
        public List<SyndicationItem> RssNewsList { get; set; }
    }
}