using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Weather_dashboard_challenge.Data;
using Weather_dashboard_challenge.Model;

namespace Weather_dashboard_challenge
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Event that happens when the page is loaded.
        /// Calls the UpdateData with the default settings
        /// The maximum number of days is 16 due to the licence limitations of the weatherbit api
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateData(new RequestParameters("Cd.Obregon", "Sonora", "MX", 16, 'M'));
            calendar.SelectedDate = DateTime.Today;
        }

        /// <summary>
        /// Method called every time a control changes his value, so a new
        /// weather request can be made.
        /// Uses the parameter because when the page is loaded at the beginning, the dropdownlists are still not correctly loaded
        /// </summary>
        /// <param name="rp">The request parameters for the weather search</param>
        public void UpdateData(RequestParameters rp)
        {
            try
            {
                WeatherData[] wd = WeatherRequester.Instance.CallWeatherAPI(rp);
                if(wd == null)
                {
                    MessageBox.Show(this, "An error occurred while requesting the data, maybe the weather service is not available");
                    return;
                }
                float[] temperatures = new float[wd.Length];
                DateTime[] dates = new DateTime[wd.Length];

                for (int i = tblTemperatures.Rows.Count; i > 0; i--)
                    if(tblTemperatures.Rows.Count > 1)
                        tblTemperatures.Rows.RemoveAt(1);

                TableRow tr;
                TableCell tc;

                for (int i = 0; i < wd.Length; i++)
                {
                    temperatures[i] = wd[i].temp;
                    dates[i] = wd[i].date;
                    
                    tr = new TableRow();
                    tr.HorizontalAlign = HorizontalAlign.Center;
                    tr.VerticalAlign = VerticalAlign.Middle;
                    tc = new TableCell();
                    tc.Text = dates[i].Day + "/" + dates[i].Month + "/" + dates[i].Year;
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = "" + wd[i].temp;
                    tr.Cells.Add(tc);
                    tblTemperatures.Rows.Add(tr);
                }
                chartTemperatures.Series[0].Points.DataBindXY(dates, temperatures);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(this, "An error occurred while showing the data:" + ex.ToString());
            }
        }

        /// <summary>
        /// Event that happens when an element of the dropdownlist city changes
        /// </summary>
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData(new RequestParameters(ddlCity.Text, "Sonora", "MX", int.Parse(ddlDays.SelectedValue), ddlScale.SelectedValue[0]));
        }

        /// <summary>
        /// Event that happens when an element of the dropdownlist units changes
        /// </summary>
        protected void ddlScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData(new RequestParameters(ddlCity.Text, "Sonora", "MX", int.Parse(ddlDays.SelectedValue), ddlScale.SelectedValue[0]));
        }

        protected void ddlDays_TextChanged(object sender, EventArgs e)
        {
            UpdateData(new RequestParameters(ddlCity.Text, "Sonora", "MX", int.Parse(ddlDays.SelectedValue), ddlScale.SelectedValue[0]));
        }
    }
}
