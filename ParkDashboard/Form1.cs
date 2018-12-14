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
    public partial class Form1 : Form
    {
        string baseURI = @"http://localhost:52566/";
        HttpClient client = null;
        List<ParkingSpot> products = new List<ParkingSpot>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAllSpots_Click(object sender, EventArgs e)
        {
            richTextBoxSpots.Text = "";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/spots").Result;
        }
    }
}
