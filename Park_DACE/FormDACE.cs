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
                richTextBoxConfig.Text += "-----------------------------------------------------------" + "\n";
                richTextBoxLog.Text += "-----------------------------------------------------------" +
                "----------------------" + "\n";

            });

        }

        public FormDACE()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            //variable declaration and console.Write for testing
            String geolocation = getGeolocationForGivenIDParkA("A-5");
            getConfiguration();
        }

        public static string getGeolocationForGivenIDParkA(string ID)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = false;

            string currentDir = Environment.CurrentDirectory;
            String filename = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\Utils\Campus_2_A_Park1.xlsx"))).ToString();

            //Open Excel file
            Excel.Workbook excellWorkbook = excelApp.Workbooks.Open(filename);
            Excel.Worksheet excellWorksheet = (Excel.Worksheet)excellWorkbook.ActiveSheet;

            int indicePrimeiraLinha = 6;
            int numberOfSpots = (int)excellWorksheet.Cells[2, 2].Value;

            //Here we need to read the cells of the ID's and check if anyone matches 
            //If match, read geolocation
            //If not, show error maybe?

            List<String> idsFromExcel = new List<string>();

            Excel.Range namedRangeFirstCollumn = excellWorksheet.get_Range("A" + indicePrimeiraLinha, "A" + ((indicePrimeiraLinha + numberOfSpots) - 1));

            foreach (Excel.Range cell in namedRangeFirstCollumn.Cells)
            {
                idsFromExcel.Add(cell.Value);
            }

            foreach (string id in idsFromExcel)
            {
                if (id.Equals(ID))
                {
                    string[] parts = id.Split('-');
                    int index1 = Int32.Parse(parts[1]);
                    try
                    {
                        string geoLocation = excellWorksheet.Cells[index1 + 5, 2].Value;
                        excellWorkbook.Close();
                        excelApp.Quit();
                        return geoLocation;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            //Check if it's closing properly
            excellWorkbook.Close();
            excelApp.Quit();

            return "There is no id with that value";
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

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
