
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
        private string spotsFromBOT = string.Empty;

        private Models.ParkingSpot spot = null;

        public FormDACE()
        {

            InitializeComponent();
            spotsToSend = new List<ParkingSpot>();
            spots = new List<ParkingSpot>();
            spotsDLL = new List<ParkingSpot>();
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
                        Location = "0", // ExcelHandler.getGeolocationForGivenIDParkA(partes[1]),
                        BateryStatus = Int32.Parse(partes[3]),
                        Type = "ParkingSpot",
                        Value = partes[4]
                    };

                    spotsDLL.Add(spot);

                    richTextBoxConfig.AppendText(string.Format("Spot: {0} {1} {2} {3} {4} {5} {6} \n", spot.Id, spot.Name, spot.Timestamp,
                            spot.BateryStatus, spot.Type, spot.Value, spot.Location));

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
            richTextBoxLog.Text += "Receiving spot from BOTSpotSensor... ";

            string[] stringSeparators = new string[] { "\r\n" };
            string[] spotsList = stringSpots.Split(stringSeparators, StringSplitOptions.None);

                String[] partes = spotsList[0].Split(';');
                spot = new ParkingSpot
                {
                    Id = partes[0],
                    Name = partes[2],
                    Timestamp = partes[4],
                    Location = partes[3], // ExcelHandler.getGeolocationForGivenIDParkA(partes[1]),
                    BateryStatus = partes[5].Equals("free") ? 1 : 0,
                    Type = partes[1],
                    Value = partes[4]
                };

                Console.WriteLine(spot.BateryStatus);

                //spotsDLL.Add(spot);

            
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
            richTextBoxConfig.AppendText("BOT \n");
        }

        private void buttonReadSOAP_Click(object sender, EventArgs e)
        {
            ServiceBOTSpotSensorsClient service = new ServiceBOTSpotSensorsClient();

            spotsFromBOT = service.GetParkingSpotsXpath();

            convertStringToParkingSpot(spotsFromBOT);

            service.Close();
        }
    }
}
