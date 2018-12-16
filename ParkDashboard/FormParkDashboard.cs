using ParkDashboard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkDashboard
{
    public partial class FormParkDashboard : Form
    {
        string baseURI = @"http://localhost:52566/";
        HttpClient client = null;
        List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
        List<Configuration> configurations = new List<Configuration>();

        public FormParkDashboard()
        {
            InitializeComponent();
        }

        public String ShowParkingSpotsAll(ParkingSpot p)
        {
            return $"{p.Id} \n";
        }

        private void btnAllSpots_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/spots").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                //converter a resposta que esta em JSON para uma List<ParkingSpot>
                string json = response.Content.ReadAsStringAsync().Result;
                parkingSpots = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingSpot>>(json);

                foreach (ParkingSpot parkingSpot in parkingSpots)
                {
                    richTextBoxSpots.AppendText(ShowParkingSpotsAll(parkingSpot));
                }
                btnReplaceSensors.Enabled = true;
                this.comboBoxSpots.DataSource = parkingSpots;
                this.comboBoxSpots.DisplayMember = "Id";
                this.comboBoxSpots.ValueMember = "Id";
                btnSpotInfo.Enabled = true;

                var dataSource = new List<Park>();
                dataSource.Add(new Park() { name = "Campus_2_A_Park1" });
                dataSource.Add(new Park() { name = "Campus_2_B_Park1" });

                this.comboBoxParks.DataSource = dataSource;
                this.comboBoxParks.DisplayMember = "Name";
                this.comboBoxParks.ValueMember = "Name";
                
                var day  = new List<int>();
                for(int i = 1; i <= 31; i++)
                {
                    day.Add(i);
                }

                this.comboBoxDay.DataSource = day;
                this.comboBoxDay.DisplayMember = "Day";
                this.comboBoxDay.DisplayMember = "Day";

                var month = new List<int>();
                for (int i = 0; i <= 12; i++)
                {
                    month.Add(i);
                }
                this.comboBoxMonth.DataSource = month;
                this.comboBoxMonth.DisplayMember = "Month";
                this.comboBoxMonth.DisplayMember = "Month";

                var year = new List<int>();
                for (int i = 2017; i <= 2019; i++)
                {
                    year.Add(i);
                }
                this.comboBoxYear.DataSource = year;
                this.comboBoxYear.DisplayMember = "Year";
                this.comboBoxYear.DisplayMember = "Year";

                var hour = new List<int>();
                for (int i = 0; i <= 23; i++)
                {
                    hour.Add(i);
                }
                this.comboBoxHours.DataSource = hour;
                this.comboBoxHours.DisplayMember = "Hour";
                this.comboBoxHours.DisplayMember = "Hour";

                var minute = new List<int>();
                for (int i = 0; i <= 59; i++)
                {
                    minute.Add(i);
                }
                this.comboBoxMinutes.DataSource = minute;
                this.comboBoxMinutes.DisplayMember = "Minute";
                this.comboBoxMinutes.DisplayMember = "Minute";
                
                btnParkPercentage.Enabled = true;
                btnParkSpots.Enabled = true;
                btnParkSensors.Enabled = true;
                comboBoxHours.Enabled = true;
                comboBoxMinutes.Enabled = true;
                btnFreeSpotsForPark.Enabled = true;
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }
        }

        public String ShowParkingSpotsBatteryReplacement(ParkingSpot p)
        {
            return $"{p.Id}\nBattery Status: Critical!!\n---------------------------------------------------------";
        }

        private void btnReplaceSensors_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/spots/critical").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                parkingSpots = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingSpot>>(json);

                foreach (ParkingSpot parkingSpot in parkingSpots)
                {
                    richTextBoxSpots.AppendText(ShowParkingSpotsBatteryReplacement(parkingSpot));
                }
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }
        }

        public String ShowFullParkingSpot(ParkingSpot p)
        {
            return $"ID :{p.Id}\nValue: {p.Value}\nName: {p.Name}\nLocation: {p.Location}\nType: {p.Type}\nBattery Status: {p.BateryStatus}\nTime: {p.Timestamp}\n---------------------------------------------------------\n";
        }

        private void btnSpotInfo_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string id = comboBoxSpots.SelectedValue.ToString();

            HttpResponseMessage response = client.GetAsync($"api/spots/{id}").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                ParkingSpot result = Newtonsoft.Json.JsonConvert.DeserializeObject<ParkingSpot>(json);
                richTextBoxSpots.AppendText(ShowFullParkingSpot(result));
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }
        }

        private void btnParkPercentage_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string id = comboBoxParks.SelectedValue.ToString();

            HttpResponseMessage response = client.GetAsync($"api/spots/parks/{id}/ocupation").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                
                richTextBoxSpots.AppendText(json);
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }

        }

        private void btnParkSpots_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string id = comboBoxParks.SelectedValue.ToString();

            HttpResponseMessage response = client.GetAsync($"api/spots/parks/{id}").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                parkingSpots = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingSpot>>(json);

                foreach (ParkingSpot parkingSpot in parkingSpots)
                {
                    richTextBoxSpots.AppendText(ShowFullParkingSpot(parkingSpot));
                }
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }
        }

        private void btnParkSensors_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string id = comboBoxParks.SelectedValue.ToString();

            HttpResponseMessage response = client.GetAsync($"api/spots/critical/parks/{id}").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                parkingSpots = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingSpot>>(json);

                if (!parkingSpots.Any())
                {
                    richTextBoxSpots.AppendText("There are no sensors in need to be replaced");
                }
                else
                {
                    foreach (ParkingSpot parkingSpot in parkingSpots)
                    {
                        richTextBoxSpots.AppendText(ShowParkingSpotsBatteryReplacement(parkingSpot));
                    }
                }
                
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }
        }

        private void btnFreeSpotsForPark_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string id = comboBoxParks.SelectedValue.ToString();
            string timestamp = comboBoxDay.SelectedValue.ToString() + "-"+comboBoxMonth.SelectedValue.ToString()+ "-"+
                comboBoxYear.SelectedValue.ToString()+"_"+comboBoxHours.SelectedValue.ToString()+","+comboBoxMinutes.SelectedValue.ToString()+",00";

            HttpResponseMessage response = client.GetAsync($"api/logspots/free/{id}/{timestamp}").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                parkingSpots = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingSpot>>(json);

                foreach (ParkingSpot parkingSpot in parkingSpots)
                {
                    richTextBoxSpots.AppendText(ShowFullParkingSpot(parkingSpot));
                }
            }
            else
            {
                richTextBoxSpots.AppendText($"Error connecting to API {response.StatusCode} with message {response.ReasonPhrase}.");
            }
        }

        private void btnSpotParkStatus_Click(object sender, EventArgs e)
        {

        }

        private void FormParkDashboard_Load(object sender, EventArgs e)
        {
            btnAllSpots_Click(sender, e);
        }

        public String ShowFullConfiguration(Configuration c)
        {
            return $"Connection Type: {c.connectionType}\nEndpoint: {c.endpoint}\nID: {c.id}\n" +
                $"Description:{c.description}\nNumber of spots: {c.numberOfSpots}\nOperating Hours: {c.operatingHours}\n" +
                $"Number of Special Spots: {c.numberOfSpecialSpots}\n Geolocation File: {c.geoLocationFile}\n---------------------------------------------------------\n";
        }

        private void btnDLLConfig_Click(object sender, EventArgs e)
        {
            richTextBoxConfs.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/confs").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                configurations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Configuration>>(json);
                richTextBoxConfs.AppendText(ShowFullConfiguration(configurations[0]));

            }
        }

        private void btnSoapConfig_Click(object sender, EventArgs e)
        {
            richTextBoxConfs.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/confs").Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                configurations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Configuration>>(json);

                richTextBoxConfs.AppendText(ShowFullConfiguration(configurations[1]));
            }
        }

        /*
         timestamp.Replace("-", "/");
            timestamp.Replace("_", " ");
            timestamp.Replace(".", ":");
            */
    }
}
