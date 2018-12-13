using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Park_DACE
{
    class ExcelHandler
    {
        public static List<string> getGeolocationForGivenIDPark(string filename)
        {
            Excel.Application excelApp = new Excel.Application();

            string currentDir = Environment.CurrentDirectory;
            string filen = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, filename))).ToString();
            List<string> geoLocations = new List<string>();

            Excel.Workbook excellWorkbook = excelApp.Workbooks.Open(filen);
            Excel.Worksheet excellWorksheet = (Excel.Worksheet)excellWorkbook.ActiveSheet;

            int indicePrimeiraLinha = 6;
            int numberOfSpots = (int)excellWorksheet.Cells[2, 2].Value;

            List<string> idsFromExcel = new List<string>();

            Excel.Range namedRangeFirstCollumn = excellWorksheet.get_Range("A" + indicePrimeiraLinha, "A" + ((indicePrimeiraLinha + numberOfSpots) - 1));

            foreach (Excel.Range cell in namedRangeFirstCollumn.Cells)
            {
                //A1,A2,A3 or B1,B2,B3
                idsFromExcel.Add(cell.Value);
            }

            foreach (string id in idsFromExcel)
            {
                string[] parts = id.Split('-');
                int index1 = Int32.Parse(parts[1]);
                try
                {
                    string geoLocation = excellWorksheet.Cells[index1 + 5, 2].Value;
                    geoLocations.Add(geoLocation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            excellWorkbook.Close();
            excelApp.Quit();

            ReleaseCOMObjects(excellWorkbook);
            ReleaseCOMObjects(excelApp);

            return geoLocations;
        }

        public static void ReleaseCOMObjects(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                obj = null;
                System.Diagnostics.Debug.WriteLine("Erro: " + ex.ToString());
            }
        }
    }
}
