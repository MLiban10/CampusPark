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
    public partial class ParkSSForm : Form
    {
        //string connectionStr =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkSS.Properties.Settings.ConnString"].ConnectionString;

        MqttClient client = null;
        string[] topics = { "ParkSS", "ParkDACE", "ParkTU" };

        private ParkingSpot spot = null;

        private List<ParkingSpot> listSpots = null;

        public ParkSSForm()
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
                richTextBoxSS.AppendText($"{e.Topic}: {(Encoding.UTF8.GetString(e.Message)).ToString()}");
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
            richTextBoxSS.Text += "Receiving spot from ParkDACE... " + "\n";

            string[] stringSeparators = new string[] { "\r\n" };
            string[] spotsList = stringSpots.Split(stringSeparators, StringSplitOptions.None);

            if (spotsList.Length > 0)
            {
                foreach (string line in spotsList.Take(spotsList.Length - 1))
                {
                    String[] partes = line.Split(';');

                    spot = new ParkingSpot
                    {
                        Id = partes[0],
                        Name = partes[2],
                        Timestamp = partes[5],
                        Location = partes[3],
                        BateryStatus = Int32.Parse(partes[6]),
                        Type = partes[1],
                        Value = bool.Parse(partes[4])
                    };

                    listSpots.Add(spot);

                }
            }
            else
            {
                richTextBoxSS.Text += "No Spots Received from DACE..." + "\n";
                richTextBoxSS.Text += "--------------------------------------------------------------------------------------------------\n";
            }
        }

        private void btn_storeDatabase_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand test = new SqlCommand("Select * From Spots", conn);

                if (test == null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Spots OUTPUT INSERTED.ID VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                    cmd.Parameters.AddWithValue("@Id", spot.Id);
                    cmd.Parameters.AddWithValue("@Type", spot.Type);
                    cmd.Parameters.AddWithValue("@Name", spot.Name);
                    cmd.Parameters.AddWithValue("@Location", spot.Location);
                    cmd.Parameters.AddWithValue("@BateryStatus", spot.BateryStatus);
                    cmd.Parameters.AddWithValue("@Value", spot.Value);
                    cmd.Parameters.AddWithValue("@Timestamp", spot.Timestamp);


                    int id = (int)cmd.ExecuteScalar();
                    spot.Id = Convert.ToString(id);
                    conn.Close();

                    Console.WriteLine("Data stored successfully!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Spots SET OUTPUT INSERTED.ID VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                    cmd.Parameters.AddWithValue("@Id", spot.Id);
                    cmd.Parameters.AddWithValue("@Type", spot.Type);
                    cmd.Parameters.AddWithValue("@Name", spot.Name);
                    cmd.Parameters.AddWithValue("@Location", spot.Location);
                    cmd.Parameters.AddWithValue("@BateryStatus", spot.BateryStatus);
                    cmd.Parameters.AddWithValue("@Value", spot.Value);
                    cmd.Parameters.AddWithValue("@Timestamp", spot.Timestamp);


                    int id = (int)cmd.ExecuteScalar();
                    spot.Id = Convert.ToString(id);
                    conn.Close();

                    Console.WriteLine("Data updated successfully!");
                }
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
