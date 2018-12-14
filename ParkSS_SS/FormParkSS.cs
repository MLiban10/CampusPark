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
                    try
                    {

                        //SqlCommand cmd = new SqlCommand("SELECT * FROM Spots WHERE Id LIKE @id", conn);
                        //cmd.Parameters.AddWithValue("@id", s.Id);

                        SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Spots WHERE (Id = @Id)", conn);
                        cmdCheck.Parameters.AddWithValue("@Id", s.Id);
                        int spotExist = (int)cmdCheck.ExecuteScalar();

                        //SqlDataReader reader = cmd.ExecuteReader();
                        //reader.Read();

                        if (spotExist > 0)
                        {
                            Console.WriteLine("Existe");

                            SqlCommand cmdUpdate = new SqlCommand("UPDATE Spots SET Id = @Id, Type = @Type, Name = @Name," +
                                " Location = @Location, BateryStatus = @BateryStatus, Value = @Value, Timestamp = @Timestamp WHERE Id LIKE @Id", conn);
                            cmdUpdate.Parameters.AddWithValue("@Id", s.Id);
                            cmdUpdate.Parameters.AddWithValue("@Type", s.Type);
                            cmdUpdate.Parameters.AddWithValue("@Name", s.Name);
                            cmdUpdate.Parameters.AddWithValue("@Location", s.Location);
                            cmdUpdate.Parameters.AddWithValue("@BateryStatus", s.BateryStatus);
                            cmdUpdate.Parameters.AddWithValue("@Value", s.Value.ToString());
                            cmdUpdate.Parameters.AddWithValue("@Timestamp", DateTime.Parse(s.Timestamp));


                            //listSpots.Remove(s);
                            cmdUpdate.ExecuteNonQuery();

                            Console.WriteLine("Spot updated successfully!");

                            SqlCommand logInsert = new SqlCommand("INSERT INTO LogSpots VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                            logInsert.Parameters.AddWithValue("@Id", s.Id);
                            logInsert.Parameters.AddWithValue("@Type", s.Type);
                            logInsert.Parameters.AddWithValue("@Name", s.Name);
                            logInsert.Parameters.AddWithValue("@Location", s.Location);
                            logInsert.Parameters.AddWithValue("@BateryStatus", s.BateryStatus);
                            logInsert.Parameters.AddWithValue("@Value", s.Value.ToString());
                            logInsert.Parameters.AddWithValue("@Timestamp", DateTime.Parse(s.Timestamp));

                            //listSpots.Remove(s);
                            logInsert.ExecuteNonQuery();
                            Console.WriteLine("Spot logged successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Não Existe");

                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Spots VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                            cmdInsert.Parameters.AddWithValue("@Id", s.Id);
                            cmdInsert.Parameters.AddWithValue("@Type", s.Type);
                            cmdInsert.Parameters.AddWithValue("@Name", s.Name);
                            cmdInsert.Parameters.AddWithValue("@Location", s.Location);
                            cmdInsert.Parameters.AddWithValue("@BateryStatus", s.BateryStatus);
                            cmdInsert.Parameters.AddWithValue("@Value", s.Value.ToString());
                            cmdInsert.Parameters.AddWithValue("@Timestamp", DateTime.Parse(s.Timestamp));

                            //listSpots.Remove(s);
                            cmdInsert.ExecuteNonQuery();
                            Console.WriteLine("Spot stored successfully!");

                            SqlCommand logInsert = new SqlCommand("INSERT INTO LogSpots VALUES (@Id, @Type, @Name, @Location, @BateryStatus, @Value, @Timestamp)", conn);
                            logInsert.Parameters.AddWithValue("@Id", s.Id);
                            logInsert.Parameters.AddWithValue("@Type", s.Type);
                            logInsert.Parameters.AddWithValue("@Name", s.Name);
                            logInsert.Parameters.AddWithValue("@Location", s.Location);
                            logInsert.Parameters.AddWithValue("@BateryStatus", s.BateryStatus);
                            logInsert.Parameters.AddWithValue("@Value", s.Value.ToString());
                            logInsert.Parameters.AddWithValue("@Timestamp", DateTime.Parse(s.Timestamp));

                            //listSpots.Remove(s);
                            logInsert.ExecuteNonQuery();
                            Console.WriteLine("Spot logged successfully!");

                        }



                        //reader.Close();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error!");
                    }
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
