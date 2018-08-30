using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace Lab27.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {


            HttpWebRequest apiRequest =
                WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=42.6875323&lon=-83.2341028&FcstType=json "); // url

                       
            apiRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse(); // represents the response we get from API
            if (apiResponse.StatusCode == HttpStatusCode.OK) // if we got a status == 200
            {

                // get the data and then parse it
                StreamReader responsedata = new StreamReader(apiResponse.GetResponseStream());

                string weather = responsedata.ReadToEnd(); // reads the data from the response
                //TODo: parse the Json data
                JObject jsonweather = JObject.Parse(weather);
                //ViewBag.weather = jsonweather["data"]["iconLink"]; // I want icon or pic
                ViewBag.weather = jsonweather["data"]["text"]; //I want only text, text is under data block so data before text
               
                //ViewBag.weatherDate = jsonweather["date"]; // to get the date

                //ViewBag.weather = weather;

            }

            return View();

                      
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}