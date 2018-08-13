using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather_dashboard_challenge.Data
{
    /// <summary>
    /// Data class required to make requests to the weather api
    /// </summary>
    public class RequestParameters
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int days { get; set; }
        public char units { get; set; }

        /// <summary>
        /// Empty Constructor for the class
        /// </summary>
        public RequestParameters()
        {

        }

        /// <summary>
        /// Constructor for the class, all needed to make the request
        /// </summary>
        /// <param name="city">The city we want to get the data</param>
        /// <param name="state">State of the city</param>
        /// <param name="country">Code of the country. Example:MX,US</param>
        /// <param name="days">Number of days to get the weather data</param>
        /// <param name="units">Letter of the unit we want to search. M=Celcius, S=Fahrenheit</param>
        public RequestParameters(string city, string state, string country, int days, char units)
        {
            this.city = city;
            this.state = state;
            this.country = country;
            this.days = days;
            this.units = units;
        }
    }
}