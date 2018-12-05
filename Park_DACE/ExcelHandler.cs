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
        public static string getGeolocationForGivenIDParkA(string ID)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            string currentDir = Environment.CurrentDirectory;
            String filename = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\Utils\Campus_2_A_Park1.xlsx"))).ToString();

            Excel.Workbook excellWorkbook = excelApp.Workbooks.Open(filename);
            Excel.Worksheet excellWorksheet = (Excel.Worksheet)excellWorkbook.ActiveSheet;

            int indicePrimeiraLinha = 6;
            int numberOfSpots = (int)excellWorksheet.Cells[2, 2].Value;

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

                        ReleaseCOMObjects(excellWorkbook);
                        ReleaseCOMObjects(excelApp);
                        return geoLocation;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            excellWorkbook.Close();
            excelApp.Quit();

            ReleaseCOMObjects(excellWorkbook);
            ReleaseCOMObjects(excelApp);

            return "There is no id with that value";
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
