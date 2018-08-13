using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Weather_dashboard_challenge.Data
{
    /// <summary>
    /// Class used to call the weather api with http request
    /// </summary>
    public class WeatherRequester
    {
        private static WeatherRequester instance = null;

        private WeatherRequester() { }

        /// <summary>
        /// Method called to get the instance of the class, uses singleton
        /// because we don't want extra instances
        /// </summary>
        public static WeatherRequester Instance
        {
            get
            {
                if (instance == null)
                    instance = new WeatherRequester();
                return instance;
            }
        }

        /// <summary>
        /// Method that calls the Weather api and gets the json content, calls
        /// another method to build correctly the weather data
        /// </summary>
        /// <param name="rp">The parameters used to get the correct weather data</param>
        /// <returns>An array of the weather data, usable by the view layer</returns>
        public WeatherData[] CallWeatherAPI(RequestParameters rp)
        {
            string url = "https://api.weatherbit.io/v2.0/forecast/daily?city=" + rp.city + "&country=" + rp.country + "&state=" + rp.state + "&days=" + rp.days + "&units=" + rp.units + "&key=d611ed53deb54849ad77f966b2083ea3";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return BuildWeatherData(reader.ReadToEnd(), rp.days);
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    Console.WriteLine(ex.ToString());
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Method called by CallWeatherAPI to build correctly the weather data
        /// with the json text
        /// </summary>
        /// <param name="jsonContent">The json text</param>
        /// <param name="days">Number of iterations for the for, just for convenience</param>
        /// <returns>Return the array of weather data, so the callWeatherAPI can return it to the view layer</returns>
        public WeatherData[] BuildWeatherData(string jsonContent, int days)
        {
            try
            {
                RequestParameters requestResult = new RequestParameters();
                WeatherData[] wd = new WeatherData[days];

                JObject jObject = JObject.Parse(jsonContent);
                JToken jToken = jObject["data"];

                for (int i = 0; i < days; i++)
                    wd[i] = new WeatherData((float)jToken[i]["temp"], Convert.ToDateTime(jToken[i]["datetime"]));

                return wd;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}