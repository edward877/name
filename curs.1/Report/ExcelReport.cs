using System;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;

namespace Report
{
     public class ExcelReport
    {
        Application excelapp;
        Workbooks excelappworkbooks;
        Workbook excelappworkbook;
        Chart excelchart;
        public void NewReport(string path)
        {
            excelapp = new Application();
            excelapp.SheetsInNewWorkbook = 1;
            excelapp.Workbooks.Add(Type.Missing);
            excelchart = (Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            FileStream fs = new FileStream(path + ".png", FileMode.Open);
            excelchart.Shapes.AddPicture(fs.Name, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, 2000, 2000);
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelappworkbooks[1];
            fs.Close();
        }


        public void Save(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            excelappworkbook.SaveAs(path, XlFileFormat.xlExcel8);
            excelappworkbooks.Close();
            excelchart = null;
            excelapp.Quit();
        }

    
    }
}
