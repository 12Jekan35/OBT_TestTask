using OBT_TestTask.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBT_TestTask
{
    public static class FileExporter
    {
        public static bool GenerateXLSXForm(List<BudgetAccount> accounts)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets
                        .Add("Market Report");
            string path = $@"C:\Users\makus\Desktop\Report{DateTime.Now}.xlsx";
            File.WriteAllBytes(path, package.GetAsByteArray());
            return File.Exists(path);
        }
    }
}
