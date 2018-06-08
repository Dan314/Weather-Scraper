using HtmlAgilityPack;
using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;

namespace WeatherApp
{
    public partial class weatherForm : Form
    {
        private string INVALID_STATE = "City/State not found.";
        private string INVALID_COUNTRY = "City/Country not found.";
        private Dictionary<string, string> country_abbrs = new Dictionary<string, string>(17);
        public weatherForm()
        {
            InitializeComponent();
        }


        private void weatherForm_Load(object sender, EventArgs e)
        {
            this.countriesTableAdapter.Fill(this.stateAndCountryNamesDataSet.Countries);
            this.statesTableAdapter.Fill(this.stateAndCountryNamesDataSet.States);
            foreach(string line in File.ReadLines("Countries.csv"))
            {
                int index = line.IndexOf(',');
                this.country_abbrs.Add(line.Substring(0, index), line.TrimEnd().Substring(index + 1));
            }
        }


        /// <summary>
        /// Lets user know the input they entered was invalid, by setting text fields to defaults.
        /// </summary>
        private void setFieldsToInvalid()
        {
            var stateOrCountry = this.internationalBox.Checked ? "Country" : "State";
            var invalid_str = this.internationalBox.Checked ? INVALID_COUNTRY : INVALID_STATE;
            this.Text = "Weather Application";        // title of form
            this.messageTextBox.Visible = true;
            this.messageTextBox.Text = invalid_str;
            this.messageTextBox.BackColor = Color.Yellow;
            this.currTemp.Text = invalid_str;
            this.condition.Text = invalid_str;
            this.feelsLikeTemp.Text = invalid_str;
            this.wind.Text = invalid_str;
        }


        /// <summary>
        /// Given a Wunderground page, scrapes the page to get temperature and other weather information.
        /// </summary>
        /// <param name="page">Web document.</param>
        /// <param name="location">User-entered location.</param>
        private void parseStats(HtmlAgilityPack.HtmlDocument page, string location) {
            // Get severe conditions, if applicable:
            try
            {
                var severe = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div[2]/" +
                    "section/div[1]/div/severe-alert/div/div/div/div/a").InnerHtml;
                this.messageTextBox.Visible = true;
                this.messageTextBox.Text = severe;
                this.messageTextBox.BackColor = Color.Red;
            }
            catch (System.Xml.XPath.XPathException) {}
            catch (NullReferenceException) {}

            var temp = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div//" +
                "section/div//div//div/div//div//div/city-current-conditions/div/div//div/div/div//display-unit/" +
                "span/span").InnerHtml;
            this.currTemp.Text = $"{temp}° F";                       // Temperature

            var cond = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div[2]/" +
                "section/div[3]/div[1]/div/div[1]/div[1]/div/city-current-conditions/div/div[3]/div/div[1]/p").InnerHtml;
            this.condition.Text = cond;                              // Condition (Rain, Clouds...)

            var feelsLike = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div[2]/section/div[3]/div[1]/div/div[1]/div[1]/div/city-current-conditions/div/div[2]/div/div/div[3]/span").InnerHtml;
            this.feelsLikeTemp.Text = $"{feelsLike} F";              // Feels-like Temperature

            var windSpeed = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div[2]/section/div[3]/div[1]/div/div[1]/div[1]/div/city-current-conditions/div/div[3]/div/div[2]/wind-gauge/div/div[3]/strong").InnerHtml;
            var windDirection = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div[2]/section/div[3]/div[1]/div/div[1]/div[1]/div/city-current-conditions/div/div[3]/div/div[2]/p[1]/strong").InnerHtml;
            this.wind.Text = $"{windDirection} at {windSpeed} mph";  // Wind speed/direction

            this.Text = $"Weather in {location}";
        }


        /// <summary>
        /// Fills all relevant text fields with weather information from Wunderground
        /// based on user-entered city and user-selected US state.
        /// </summary>
        private void getResultsUS() {
            this.Text = "----- Getting Results... -----";
            this.messageTextBox.Visible = false;
            if (!Regex.IsMatch(cityInput.Text, "^[a-zA-Z\\s']+$")) // Regex: Letters, spaces, and apostrophes
            {
                setFieldsToInvalid();
                return;
            }
            var city = cityInput.Text.Replace(' ', '-');           // Spaces -> Dashes for URL
            var state = stateListBox.GetItemText(stateListBox.SelectedItem).TrimEnd();

            var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                    "\"C:\\Users\\{rest of path}\\Abbreviations.mdf\";" +
                    "Integrated Security=True;Connect Timeout=30;");

            var sqlCommand = new SqlDataAdapter($"SELECT Abbreviation FROM States WHERE State='{state}'", conn);
            // Get state abbreivation from SQL Table
            DataTable data = new DataTable();
            sqlCommand.Fill(data);
            state = data.Rows[0][0].ToString();


            HtmlWeb htmlWeb = new HtmlWeb();
            var page = htmlWeb.Load($"https://www.wunderground.com/weather/us/{state}/{city}");
            // Get web page and check the title
            var title = page.DocumentNode.SelectSingleNode("/html/head/title").InnerHtml;
            if (title.Equals("Error | Weather Underground"))
            {
                setFieldsToInvalid();
                return;
            }
            
            // Ensure Wunderground did not return a web page for a different state
            var pageCityAndState = page.DocumentNode.SelectSingleNode("/html/body/app/city-today/city-today-layout/div/div[2]/section/div[2]/div/div/city-header/div/h1").InnerHtml;
            pageCityAndState = pageCityAndState.Substring(0, pageCityAndState.IndexOf('\n'));
            var pageCityAndStateArray = pageCityAndState.Split(',');
            var pageState = pageCityAndStateArray[1].TrimStart().ToLower();
            if (!pageState.Equals(state.ToLower()))
            {
                setFieldsToInvalid();
                return;
            }

            parseStats(page, pageCityAndState);
        }


        /// <summary>
        /// Fills all relevant text fields with weather information from Wunderground
        /// based on user-entered city and user-selected country (not US).
        /// </summary>
        private void getResultsInternational() {
            this.Text = "----- Getting Results... -----";
            this.messageTextBox.Visible = false;
            if (!Regex.IsMatch(cityInput.Text, "^[a-zA-Z\\s']+$"))
            {
                setFieldsToInvalid();
                return;
            }
            var city = cityInput.Text.Replace(' ', '-');

            var country = stateListBox.GetItemText(stateListBox.SelectedItem).TrimEnd();

            // Get the abbreviation for the country -- for some countries, need to put abbreviation
            // in the URL or Wunderground will not recognize it
            string country_abbr = "";
            this.country_abbrs.TryGetValue(country, out country_abbr);
            
            if (country.Contains(","))  // For example: Micronesia, Federated States of
            {
                country = country.Substring(country.IndexOf(',') + 2) + " " + country.Substring(0, country.IndexOf(','));
                country = country.TrimEnd();
            }

            HtmlWeb htmlWeb = new HtmlWeb();
            var countryURL = country_abbr == null ? country.Replace(' ', '-') : country_abbr;
            // Get web page from Wunderground
            var page = htmlWeb.Load($"https://www.wunderground.com/weather/{countryURL}/{city}");
            var title = page.DocumentNode.SelectSingleNode("/html/head/title").InnerHtml;
            if (title.Equals("Error | Weather Underground"))
            {
                setFieldsToInvalid();
                return;
            }
            
            var pageCityAndCountry = title.Substring(0, title.IndexOf('|') - 10);
            var strlen = pageCityAndCountry.Length - (title.IndexOf(',') + 2);
            var pageCountry = pageCityAndCountry.Substring(title.IndexOf(',') + 2, strlen).ToLower();
            switch(country)
            {
                case "Guam":  // Results from Guam will show as {city}, GU in web page's title
                    country = "GU";
                    break;
                case "Marshall Islands":  // Et cetera for other countries listed here
                    country = "MH";
                    break;
                case "Moldova":
                    country = "Republic of Moldova";
                    break;
                case "Republic of the Congo":
                    country = "Congo";
                    break;
                case "Saint Lucia":
                    country = "St. Lucia";
                    break;
                case "Vietnam":
                    country = "Viet Nam";
                    break;
                default:
                    break;
            }
            if (!pageCountry.Equals(country.ToLower()))
            {
                setFieldsToInvalid();
                return;
            }

            parseStats(page, pageCityAndCountry);
        }


        /// <summary>
        /// Calls the appropriate method when user submits info in form.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (this.internationalBox.Checked)
                getResultsInternational();
            else
                getResultsUS();
        }


        /// <summary>
        /// Displays different information in form drop-down box depending on
        /// whether the 'International' box is checked or not.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void internationalBox_CheckedChanged(object sender, EventArgs e)
        {
            this.label2.Text = this.internationalBox.Checked ? "Select Country:" : "Select State:";
            if (this.internationalBox.Checked)
            {
                this.stateListBox.DataSource = countriesBindingSource;
                this.stateListBox.DisplayMember = "Country";
            }
            else
            {
                this.stateListBox.DataSource = statesBindingSource;
                this.stateListBox.DisplayMember = "State";
            }
        }
    }
}
