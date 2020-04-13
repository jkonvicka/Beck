using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Beck.Models
{
    public class CsvReader
    {

        private static WebClient client = new WebClient();
        private static string jsonData;
        public static List<CovidData> CovidTestList { get; private set; }
        public static List<CovidData> Get(string url)
        {
            char[] dataDivisors = new char[] { ',', '\r' };
            string[] tempCsvData = GetCSV(url).Split(dataDivisors);
            string[] data = new string[3];
            int iterator = 0;
            bool skipFirstRow = false;
            CovidTestList = new List<CovidData>();
            foreach (string item in tempCsvData)
            {

                if (!string.IsNullOrWhiteSpace(item))
                {
                    data[iterator++] = item;
                }
                if(skipFirstRow == false && iterator == 3)
                {
                    skipFirstRow = true;
                    iterator = 0;
                }
                else if (iterator == 3)
                {
                    CovidTestList.Add(new CovidData(data[0].Substring(1,data[0].Length-1), Convert.ToDouble(data[1]), Convert.ToDouble(data[2])));
                    iterator = 0;
                }
            }
            
            return CovidTestList;
        }


        private static string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }
    }

    
}