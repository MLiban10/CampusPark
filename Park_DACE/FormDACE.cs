using Smart_Park.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        
        private ParkingSpot spot =null;

        public FormDACE()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            getConfiguration();
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            dll.Initialize(NewSensorValueFunction, 2000);
        }
        
        public void NewSensorValueFunction(string str)
        {
            //To have access to the listbox that is in other thread (Form)
            this.BeginInvoke((MethodInvoker)delegate
            {
                
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
                }
                      
                richTextBoxLog.Text += "Receiving spot from DLL..." +"\n";
                richTextBox1.Text += str + ExcelHandler.getGeolocationForGivenIDParkA(partes[1]) +"\n";
                richTextBoxLog.Text += "Spot received Successfully!!" + "\n";
                richTextBox1.Text += "-----------------------------------------------------------" + "\n";
                richTextBoxLog.Text += "-----------------------------------------------------------" +
                "----------------------" + "\n";
            });
    
        }
           
        private void buttonPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                getConfiguration();
                MessageBox.Show(fbd.SelectedPath);
            }
        }

        private void getConfiguration()
        {

        }
        
        private void buttonDLL_Click(object sender, EventArgs e)
        {
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            bw.RunWorkerAsync();
        }
    }
}
