using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Park_DACE
{
    public partial class FormDACE : Form
    {
        public FormDACE()
        {
            InitializeComponent();
        }

        public static string ReadFromXLSFile(string filename, string ID)
        {
            
            var excelApp = new Excel.Application();
            excelApp.Visible = false;


            //Open Excel file
            var excellWorkbook = excelApp.Workbooks.Open(filename);
            var excellWorksheet = (Excel.Worksheet)excellWorkbook.ActiveSheet;

            //Here we need to read the cells of the ID's and check if anyone matches 
            //If match, read geolocation
            //If not, show error maybe?
            
            return "";
        }
    }
}
