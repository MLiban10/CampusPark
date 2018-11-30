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

        public static string getGeolocationForGivenID(string ID)
        {
            
            var excelApp = new Excel.Application();
            excelApp.Visible = false;

            string filename = @"C:\Campus_2_A_Park1.xlsx";

            //Open Excel file
            Excel.Workbook excellWorkbook = excelApp.Workbooks.Open(filename);
            Excel.Worksheet excellWorksheet = (Excel.Worksheet)excellWorkbook.ActiveSheet;

            /*
            int primeiraColuna = 1;
            int segundaColuna = 2;
            int indicePrimeiraLinha = 6;

            //Here we need to read the cells of the ID's and check if anyone matches 
            //If match, read geolocation
            //If not, show error maybe?

            if(excellWorksheet.Cells[indicePrimeiraLinha, primeiraColuna].Value2 != null)
            {
               
                return excellWorksheet.Cells[indicePrimeiraLinha, primeiraColuna].Value2;
            }
            */

            List<String> idsFromExcel = new List<string>();



            return "";
        }
    }
}
