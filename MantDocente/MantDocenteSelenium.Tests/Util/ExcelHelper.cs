using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MantDocente.Tests.Util
{
    class ExcelHelper
    {

       private static String rutaOriginal = System.AppDomain.CurrentDomain.BaseDirectory;
        private static String rutaDataAdd = rutaOriginal+@"\Data\DataAgregar.xls";
        private static String rutaDataEdit = rutaOriginal + @"\Data\DataEditar.xls";
        private static String rutaDataDelete = rutaOriginal + @"\Data\DataEliminar.xls";
        private static String rutaDataListar = rutaOriginal + @"\Data\DataListar.xls";

        public static Dictionary<String, String> LeerExcelAdd(int row)
        {
           
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(rutaDataAdd);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            var data = new Dictionary<String, String>();
            data["Nombre"] = Convert.ToString(xlRange.Cells[row, 1].Value2) + "";
            data["Apellido"] = Convert.ToString(xlRange.Cells[row, 2].Value2) + "";
            data["FechaNacimiento"] = Convert.ToString(xlRange.Cells[row, 3].Value2) + "";
            data["NroDoc"] = Convert.ToString(xlRange.Cells[row, 4].Value2) + "";
            data["TipoDoc"] = Convert.ToString(xlRange.Cells[row, 5].Value2) + "";
            data["ValorEsperado"] = Convert.ToString(xlRange.Cells[row, 6].Value2) + "";

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return data;
        }

        public static Dictionary<String, String> LeerExcelEdit(int row)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(rutaDataEdit);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            var data = new Dictionary<String, String>();
            data["Nombre"] = Convert.ToString(xlRange.Cells[row, 1].Value2)+"";
            data["Apellido"] = Convert.ToString(xlRange.Cells[row, 2].Value2)+"";
            data["TipoDoc"] = Convert.ToString(xlRange.Cells[row, 3].Value2)+"";
            data["ValorEsperado"] = Convert.ToString(xlRange.Cells[row, 4].Value2) + "";

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return data;
        }

        public static Dictionary<String, String> LeerExcelEliminar(int row)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(rutaDataDelete);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            var data = new Dictionary<String, String>();
            data["Check"] = Convert.ToString(xlRange.Cells[row, 1].Value2) + "";
            data["ValorEsperado"] = Convert.ToString(xlRange.Cells[row, 2].Value2);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return data;
        }

        public static Dictionary<String, String> LeerExcelListar(int row)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(rutaDataListar);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            var data = new Dictionary<String, String>();
            data["ValorEsperado"] = Convert.ToString(xlRange.Cells[row, 1].Value2) + "";

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return data;
        }
    }
}
