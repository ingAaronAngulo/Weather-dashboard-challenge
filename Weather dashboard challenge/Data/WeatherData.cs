using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather_dashboard_challenge.Data
{
    /// <summary>
    /// Data class that stores the temperature and 
    /// date for every day requested, used as an array
    /// </summary>
    public class WeatherData
    {
        public float temp { get; set; }
        public DateTime date { get; set; }

        /// <summary>
        /// Empty constructor for the WeatherData
        /// </summary>
        public WeatherData()
        {

        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="temp">Temperature of the day, in celcius or fahrenheit</param>
        /// <param name="date">Date where temperature was registered</param>
        public WeatherData(float temp, DateTime date)
        {
            this.temp = temp;
            this.date = date;
        }
    }
}