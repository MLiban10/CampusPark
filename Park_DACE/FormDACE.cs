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
using Excel = Microsoft.Office.Interop.Excel;


namespace Park_DACE
{
    public partial class FormDACE : Form
    {
        private String strConfigurations;
        private ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;
        private BackgroundWorker bw = new BackgroundWorker();
        //private Spot spot;

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            dll.Initialize(NewSensorValueFunction, 2000);
        }
        
        public void NewSensorValueFunction(string str)
        {
            //To have access to the listbox that is in other thread (Form)
            this.BeginInvoke((MethodInvoker)delegate
            {
                richTextBoxLog.Text += "Receiving spot from DLL..." +"\n";
                //Thread.Sleep(1500);
                richTextBox1.Text += str + "\n"/* + getGeolocationForGivenIDParkA()*/;
                //Thread.Sleep(1500);
                richTextBoxLog.Text += "Spot received Successfully!!" + "\n";
                richTextBox1.Text += "-----------------------------------------------------------" + "\n";
                richTextBoxLog.Text += "-----------------------------------------------------------" +
                "----------------------" + "\n";

            });
        }

        public FormDACE()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(DoWork);
            //variable declaration and console.Write for testing
            String geolocation = getGeolocationForGivenIDParkA("A-30");
            Console.WriteLine(geolocation);
            getConfiguration();
        }

        public static string getGeolocationForGivenIDParkA(string ID)
        {

            var excelApp = new Excel.Application();
            excelApp.Visible = false;

            string filename = @"C:\Campus_2_A_Park1.xlsx";

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
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                }
            }

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
    }
}
