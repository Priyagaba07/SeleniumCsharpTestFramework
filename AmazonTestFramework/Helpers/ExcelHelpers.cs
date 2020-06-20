using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace AmazonTestFramework.Helpers
{
    public class ExcelHelpers
    {

        
        public static List<string> GetCellDataList(string sheetName, string colName)
        {
          
            string path = @"D:\SeleniumCsharp\AmazonTestFramework\AmazonTest\Data\AmazonExcelData.xlsx";
            Console.WriteLine(Path.GetFullPath(path)); 

            XSSFWorkbook wb;
            List<string> data = new List<string>();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            wb = new XSSFWorkbook(fs);
            int index = wb.GetSheetIndex(sheetName);
            ISheet sh = wb.GetSheetAt(index);
            int totalRow = sh.LastRowNum;
            for (int i = 0; i <= totalRow; i++)
            {
                IRow row = sh.GetRow(i);
                ICell cell1 = row.GetCell(0);
                string cell1Value = cell1.StringCellValue;
                if (cell1.StringCellValue.Equals(colName))
                {
                    int totalColumn = row.LastCellNum;
                    for (int j = 1; j < totalColumn; j++)
                    {
                        ICell cell = row.GetCell(j);
                        data.Add(cell.StringCellValue);
                    }
                    break;
                }
            }
            wb.Close();
            fs.Close();
            return data;
        }
    }
}
