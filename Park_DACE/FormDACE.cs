using Park_DACE.Models;
using Park_DACE.ServiceBotSpotSensor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;



namespace Park_DACE
{
    public partial class FormDACE : Form
    {
        private String strConfigurations;
        private ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;
        private BackgroundWorker bw = new BackgroundWorker();
        private List<ParkingSpot> spotsToSend = null;
        private List<ParkingSpot> spots = null;
        private List<ParkingSpot> spotsDLL = null;
        private List<ParkingSpot> spotsBOT = null;
        private string spotsFromBOT = string.Empty;

        private ParkingSpot spot = null;

        private MqttClient client = null;
        String topic = "spot";

        public FormDACE()
        {

            InitializeComponent();
            spotsToSend = new List<ParkingSpot>();
            spots = new List<ParkingSpot>();
            spotsDLL = new List<ParkingSpot>();
            spotsBOT = new List<ParkingSpot>();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            getConfiguration();
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            bw.RunWorkerAsync();
            timer1.Enabled = true;
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

                    spot = new ParkingSpot
                    {
                        Id = partes[0],
                        Name = partes[1],
                        Timestamp = partes[2],
                        Location = ExcelHandler.getGeolocationForGivenIDParkA(partes[1]),
                        BateryStatus = Int32.Parse(partes[3]),
                        Type = "ParkingSpot",
                        Value = partes[4].Equals("free") ? true : false
                    };

                    spotsDLL.Add(spot);

                    //richTextBoxConfig.AppendText(string.Format("Spot: {0} {1} {2} {3} {4} {5} {6} \n", spot.Id, spot.Name, spot.Timestamp,
                    //spot.BateryStatus, spot.Type, spot.Value, spot.Location));

                    richTextBoxLog.Text += "Successfull" + "\n";
                    richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                }
                else
                {
                    richTextBoxLog.Text += "No Spots Received from DLL..." + "\n";
                    richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                }
            });
        }

        public void convertStringToParkingSpot(string stringSpots)
        {
            richTextBoxLog.Text += "Receiving spot from BOTSpotSensor... " + "\n";

            string[] stringSeparators = new string[] { "\r\n" };
            string[] spotsList = stringSpots.Split(stringSeparators, StringSplitOptions.None);

            if(spotsList.Length > 0)
            {
                foreach (string line in spotsList.Take(spotsList.Length - 1))
                {
                    String[] partes = line.Split(';');
                    if (partes[0] != HandlerXML.configurations.Find(c => c.connectionType.Equals("SOAP")).id)
                    {
                        richTextBoxLog.Text += "Error: Different Parks!" + "\n";
                        richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                    } else
                    {
                        spot = new ParkingSpot
                        {
                            Id = partes[0],
                            Name = partes[2],
                            Timestamp = partes[5],
                            Location = partes[3], // ExcelHandler.getGeolocationForGivenIDParkB(partes[3]),
                            BateryStatus = Int32.Parse(partes[6]),
                            Type = partes[1],
                            Value = partes[4].Equals("free") ? true : false
                        };

                        spotsBOT.Add(spot);
                    }
                }
            } else
            {
                richTextBoxLog.Text += "No Spots Received from BOT..." + "\n";
                richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
            }
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            new FormConfig().Show();
        }

        private void getConfiguration()
        {
            string currentDir = Environment.CurrentDirectory;
            String filename = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\Utils\ParkingNodesConfig.xml"))).ToString();

            HandlerXML handler = new HandlerXML(filename);
            handler.LoadConfigurations();
        }

        private void buttonDLL_Click(object sender, EventArgs e)
        {
            richTextBoxConfig.Text = HandlerXML.getDLLConfiguration().ToString();
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonSOAP_Click(object sender, EventArgs e)
        {
            richTextBoxConfig.Text = HandlerXML.getSOAPConfiguration().ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //richTextBoxConfig.AppendText("BOT \n");
        }

        private void buttonReadSOAP_Click(object sender, EventArgs e)
        {
            ServiceBOTSpotSensorsClient service = new ServiceBOTSpotSensorsClient();

            spotsFromBOT = service.GetParkingSpotsXpath();

            convertStringToParkingSpot(spotsFromBOT);

            service.Close();
        }

        private void readSpots(List<ParkingSpot> spotsAux)
        {
            foreach (ParkingSpot spot in spotsAux)
            {
                if (spots.Contains(spot))
                {
                    ParkingSpot spotOld = spots.Find(s => s == spot);
                    if (spotOld.BateryStatus != spot.BateryStatus || spotOld.Value != spot.Value)
                    {
                        spots[spots.FindIndex(ind => ind.Equals(spotOld))] = spot;
                        spotsToSend.Add(spot);
                    }
                }
                else
                {
                    spots.Add(spot);
                    spotsToSend.Add(spot);
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
            //Alterar spotsToSend.ToString() para mandar em formato string
            foreach (ParkingSpot spot in spotsDLL)
            {
                Console.WriteLine(spot.ToString());
            }
            byte[] msg = Encoding.UTF8.GetBytes(spotsToSend.ToString());
            client.Publish(topic, msg);
        }

        private void FormDACE_Load(object sender, EventArgs e)
        {
            client = new MqttClient("127.0.0.1");
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
