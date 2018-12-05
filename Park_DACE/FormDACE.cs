using Park_DACE.Models;
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

        private ParkingSpot spot = null;

        public FormDACE()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            getConfiguration();
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            bw.RunWorkerAsync();
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
                    spot = new ParkingSpot
                    {
                        Id = partes[0],
                        Name = partes[1],
                        Timestamp = partes[2],
                        Location = ExcelHandler.getGeolocationForGivenIDParkA(partes[1]),
                        BateryStatus = Int32.Parse(partes[3]),
                        Type = null,
                        Value = partes[4]
                    };
                    richTextBoxLog.Text += "Successfull" + "\n";
                    richTextBoxLog.Text += "--------------------------------------------------------------------------------------------------\n";
                }
                else
                {
                    richTextBoxLog.Text += "No Spots Received" + "\n";
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
    }
}
