using Beck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Beck.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HomeDataBag homeData = new HomeDataBag();
            homeData.CovidTestList = CsvReader.Get("https://onemocneni-aktualne.mzcr.cz/api/v1/covid-19/testy.csv"); 
            homeData.CovidInfectionList = CsvReader.Get("https://onemocneni-aktualne.mzcr.cz/api/v1/covid-19/nakaza.csv");
            homeData.RssNewsList = RssReader.GetNews("https://www.novinky.cz/rss/stalo-se", 3);
            return View(homeData);
        }


    }
}