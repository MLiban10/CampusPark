using Park_DACE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ParkSS_SS
{
    public partial class FormParkSS : Form
    {
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkSS_SS.Properties.Settings.ConnStr"].ConnectionString;

        MqttClient client = null;
        string receivedData = "";
        string[] topics = { "ParkSS", "ParkDACE", "ParkTU" };

        private ParkingSpot spot = new ParkingSpot();
        private List<ParkingSpot> listSpots = new List<ParkingSpot>();

        public FormParkSS()
        {
            InitializeComponent();
        }


        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            client.Connect(Guid.NewGuid().ToString());
            if (!client.IsConnected)
            {
                richTextBoxSS.AppendText("Unnable to connect with Broker");
            }
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            byte[] qos = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
            client.Subscribe(topics, qos);
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                receivedData = Encoding.UTF8.GetString(e.Message);
                richTextBoxSS.AppendText($"{e.Topic}: {receivedData}");

                convertStringToParkingSpot(receivedData);
            });
        }

        private void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Unsubscribe(topics);
            }
        }

        private void ParkSS_Load(object sender, EventArgs e)
        {
            client = new MqttClient(textBoxIP.Text);
            btnSubscribe_Click(sender, e);
            // btn_storeDatabase_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }

        public void convertStringToParkingSpot(string stringSpots)
        {

            Console.WriteLine("Receiving spot from ParkDACE... ");

            string[] stringSeparators = new string[] { "\r\n" };
            string[] spotsList = stringSpots.Split(stringSeparators, StringSplitOptions.None);

            if (spotsList.Length > 0)
            {

                String[] partes = spotsList[0].Split(',');

                spot = new ParkingSpot
                {
                    Id = partes[0],
                    Name = partes[2],
                    Timestamp = partes[7],
                    Location = partes[3] + "," + partes[4],
                    BateryStatus = Int32.Parse(partes[5]),
                    Type = partes[1],
                    Value = bool.Parse(partes[6])
                };

                listSpots.Add(spot);



            }
            else
            {
                Console.WriteLine("No Spots Received from DACE...");
            }
        }

        private void btn_storeDatabase_Click(object sender, EventArgs e)
        {
            richTextBoxSS.Clear();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                foreach (ParkingSpot s in listSpots)
                {
                    SqlCommand test = new SqlCommand();// verificar se o spot já existe --- SERGIO

                    //if (test == null)
                    //{
                    SqlCommand cmd = new SqlCommand("INSERT INTO Spots OUTPUT INSERTED.ID VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.Parameters.AddWithValue("@Type", s.Type);
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Location", s.Location);
                    cmd.Parameters.AddWithValue("@BateryStatus", s.BateryStatus);
                    cmd.Parameters.AddWithValue("@Value", s.Value.ToString());
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Parse(s.Timestamp));

                    //listSpots.Remove(s);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Spot stored successfully!");
                    /*}
                    else
                    {


                        SqlCommand cmd = new SqlCommand("UPDATE Spots SET OUTPUT INSERTED.ID VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                        cmd.Parameters.AddWithValue("@Id", s.Id);
                        cmd.Parameters.AddWithValue("@Type", s.Type);
                        cmd.Parameters.AddWithValue("@Name", s.Name);
                        cmd.Parameters.AddWithValue("@Location", s.Location);
                        cmd.Parameters.AddWithValue("@BateryStatus", s.BateryStatus);
                        cmd.Parameters.AddWithValue("@Value", s.Value);
                        cmd.Parameters.AddWithValue("@Timestamp", s.Timestamp);


                        listSpots.Remove(s);
                        conn.Close();

                        Console.WriteLine("Spot updated successfully!");
                    }*/

                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.Error.WriteLine("ERROR: data not stored.");
            }
        }
    }
}
