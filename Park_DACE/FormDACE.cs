using Park_DACE.Models;
using Park_DACE.ServiceBotSpotSensor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace Park_DACE
{
    public partial class FormDACE : Form
    {
        private ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;
        private BackgroundWorker bw = new BackgroundWorker();
        private List<ParkingSpot> spotsToSend = null;
        private List<ParkingSpot> spots = null;
        private List<ParkingSpot> spotsDLL = null;
        private List<ParkingSpot> spotsBOT = null;
        private string spotsFromBOT = string.Empty;
        int count = 0;
        private List<string> geolocationsFromParkA = null;
        private List<string> geolocationsFromParkB = null;

        private ParkingSpot spot = null;

        MqttClient client = null;
        string[] topics = { "Spots", "Configurations", "Debug" };

        public FormDACE()
        {
            InitializeComponent();
            spotsToSend = new List<ParkingSpot>();
            spots = new List<ParkingSpot>();
            spotsDLL = new List<ParkingSpot>();
            spotsBOT = new List<ParkingSpot>();
            geolocationsFromParkA = ExcelHandler.getGeolocationForGivenIDPark(Application.StartupPath + @"\Utils\Campus_2_A_Park1.xlsx");
            geolocationsFromParkB = ExcelHandler.getGeolocationForGivenIDPark(Application.StartupPath + @"\Utils\Campus_2_B_Park1.xlsx");
            bw.DoWork += new DoWorkEventHandler(DoWork);
            getConfiguration();
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            client = new MqttClient("127.0.0.1");
            sendConfigurations();
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            dll.Initialize(NewSensorValueFunction, 5000);
        }

        public void NewSensorValueFunction(string str)
        {
            //To have access to the listbox that is in other thread (Form)
            this.BeginInvoke((MethodInvoker)delegate
            {
                richTextBoxLog.Text += "Receiving spot from DLL... ";

                String[] partes = str.Split(';');

                if (partes.Length > 0)
                {
                    if (partes[0] != HandlerXML.configurations.Find(c => c.connectionType.Equals("DLL")).id)
                    {
                        richTextBoxLog.Text += "Error: Different Parks!" + "\n";
                        richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                    }
                    else
                    {

                        string[] parts = partes[1].Split('-');
                        int index = Int32.Parse(parts[1]);

                        try
                        {
                            spot = new ParkingSpot
                            {
                                Id = partes[0] + "_" + partes[1],
                                Name = partes[1],
                                //Timestamp = (DateTime.Parse(partes[2]).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second)).ToString(),
                                Timestamp = partes[2],
                                Location = geolocationsFromParkA[index - 1],
                                BateryStatus = Int32.Parse(partes[3]),
                                Type = "ParkingSpot",
                                Value = partes[4].Equals("free") ? true : false
                            };

                            spotsDLL.Add(spot);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ui, Ui!");
                        }

                        //richTextBoxConfig.AppendText(string.Format("Spot: {0} {1} {2} {3} {4} {5} {6} \n", spot.Id, spot.Name, spot.Timestamp,
                        //spot.BateryStatus, spot.Type, spot.Value, spot.Location));

                        richTextBoxLog.Text += "Successfull" + "\n";
                        richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";

                    }
                }
                else
                {
                    richTextBoxLog.Text += "No Spots Received from DLL..." + "\n";
                    richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                }
            });
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            new FormConfig().Show();
        }

        private void getConfiguration()
        {
            string currentDir = Environment.CurrentDirectory;
            String filename = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, Application.StartupPath + @"\Utils\ParkingNodesConfig.xml"))).ToString();

            HandlerXML handler = new HandlerXML(filename);
            handler.LoadConfigurations();
        }

        private void buttonDLL_Click(object sender, EventArgs e)
        {
            richTextBoxConfig.Text = HandlerXML.getDLLConfiguration().ToString();
        }

        private void buttonSOAP_Click(object sender, EventArgs e)
        {
            richTextBoxConfig.Text = HandlerXML.getSOAPConfiguration().ToString();
        }

        private void readSpot(int index)
        {
            ServiceBOTSpotSensorsClient service = new ServiceBOTSpotSensorsClient();

            richTextBoxLog.Text += "Receiving spot from SOAP... ";

            spotsFromBOT = service.GetParkingSpotsXpath();

            string[] stringSeparators = new string[] { "\r\n" };
            string[] spotsList = spotsFromBOT.Split(stringSeparators, StringSplitOptions.None);
            if (index < spotsList.Length - 1)
            {
                String[] partes = spotsList[index].Split(';');
                if (partes[0] != HandlerXML.configurations.Find(c => c.connectionType.Equals("SOAP")).id)
                {
                    richTextBoxLog.Text += "Error: Different Parks!" + "\n";
                    richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                }
                else
                {
                    string[] parts = partes[2].Split('-');
                    int index1 = Int32.Parse(parts[1]);

                    try
                    {
                        spot = new ParkingSpot
                        {
                            Id = partes[0] + "_" + partes[2],
                            Name = partes[2],
                            Timestamp = partes[5],
                            Location = geolocationsFromParkB[index1 - 1],
                            BateryStatus = Int32.Parse(partes[6]),
                            Type = partes[1],
                            Value = partes[4].Equals("free") ? true : false
                        };
                        spotsBOT.Add(spot);


                        richTextBoxLog.Text += "Successfull" + "\n";

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ai, Ai!");
                    }
                }

                Console.WriteLine(spot.ToString());
            }
            else
            {
                count = 0;
            }

            service.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            readSpot(count);
            count++;

            btnPublish_Click(sender, e);

        }

        private void buttonReadSOAP_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void readSpots(List<ParkingSpot> spotsAux)
        {
            foreach (ParkingSpot spot in spotsAux)
            {
                if (spots.Contains(spot))
                {
                    ParkingSpot spotOld = spots.Find(s => s == spot);

                    spots[spots.FindIndex(ind => ind.Equals(spotOld))] = spot;
                }
                else
                {
                    spots.Add(spot);
                }
            }
        }

        private void ButtonBroker_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect(Guid.NewGuid().ToString());
                btnPublish.Enabled = true; //botao do publish

            }
            catch (Exception)
            {
                richTextBoxLog.Text += "Unnable to connect to Broker" + "\n";
                richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
            }

        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            readSpots(spotsDLL);
            readSpots(spotsBOT);

            //Alterar spotsToSend.ToString() para mandar em formato string
            foreach (ParkingSpot spot in spots)
            {
                byte[] msg = Encoding.UTF8.GetBytes(spot.ToString());
                client.Publish(topics[0], msg);
            }
            spots.Clear();

        }

        public void sendConfigurations()
        {
            byte[] msgConfigurationDLL = Encoding.UTF8.GetBytes(HandlerXML.getDLLConfigurationToSend());
            byte[] msgConfigurationSOAP = Encoding.UTF8.GetBytes(HandlerXML.getSOAPConfigurationToSend());
            client.Publish(topics[1], msgConfigurationDLL);
            richTextBoxLog.AppendText("Sending DLL configuration" + Environment.NewLine);
            client.Publish(topics[1], msgConfigurationSOAP);
            richTextBoxLog.AppendText("Sending SOAP configuration" + Environment.NewLine);
        }

        private void FormDACE_Load(object sender, EventArgs e)
        {
            bw.RunWorkerAsync();
            timer1.Enabled = true;

            buttonReadSOAP_Click(sender, e);
            ButtonBroker_Click(sender, e);
        }

        private void FormDACE_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }
    }
}
