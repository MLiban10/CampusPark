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

                btnParkPercentage.Enabled = true;
                btnParkSpots.Enabled = true;
                btnParkSensors.Enabled = true;
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
    }
}
