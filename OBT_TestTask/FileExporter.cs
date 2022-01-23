using OBT_TestTask.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OBT_TestTask
{
    public static class FileExporter
    {
        public static bool GenerateXMLReport(List<BudgetAccount> accounts, string path)
        {
            XDocument xdoc = new XDocument();


            return File.Exists(path);
        }

        public static bool GenerateXLSXForm(List<BudgetAccount> accounts, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets
                        .Add("Бюджет");
            for (int i = 1; i < 15; i++)
            {
                sheet.Columns[i].Style.Font.Name = "Arial";
                sheet.Columns[i].Style.Font.Size = 10;
            }
            sheet.Columns[1].Width = 38;
            sheet.Columns[2].Width = 22;
            sheet.Columns[3].Width = 6.57;
            sheet.Columns[4].Width = 15.57;
            sheet.Columns[5].Width = 18;
            sheet.Columns[6].Width = 21;
            sheet.Columns[7].Width = 18;
            sheet.Columns[8].Width = 21;
            sheet.Columns[9].Width = 22;
            sheet.Columns[10].Width = 6.57;
            sheet.Columns[11].Width = 15.57;
            sheet.Columns[12].Width = 18;
            sheet.Columns[13].Width = 6.57;
            sheet.Columns[14].Width = 15.57;

            sheet.Cells["A1:A4"].Merge = true;
            sheet.Cells["A1:A4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["A1:A4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["A1:A4"].Value = "Номер (код) счета бюджетного учета";
            sheet.Cells["B1:N1"].Merge = true;

            sheet.Cells["B1:N1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["B1:N1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["B1:N1"].Value = "Сумма задолженности, руб";
            sheet.Cells["B2:D2"].Merge = true;

            sheet.Cells["B2:D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["B2:D2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["B2:D2"].Value = "на начало года";
            sheet.Cells["E2:H2"].Merge = true;

            sheet.Cells["E2:H2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["E2:H2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["E2:H2"].Value = "изменение задолженности";
            sheet.Cells["E2:H2"].Merge = true;

            sheet.Cells["I2:K2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["I2:K2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["I2:K2"].Value = "на конец отчетного периода";
            sheet.Cells["I2:K2"].Merge = true;

            sheet.Cells["L2:N2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["L2:N2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["L2:N2"].Value = "на конец аналогичного периода прошлого финансового года";
            sheet.Cells["L2:N2"].Merge = true;

            sheet.Cells["B3:B4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["B3:B4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["B3:B4"].Value = "всего";
            sheet.Cells["B3:B4"].Merge = true;

            sheet.Cells["C3:D3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["C3:D3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["C3:D3"].Value = "из них";
            sheet.Cells["C3:D3"].Merge = true;

            sheet.Cells["E3:F3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["E3:F3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["E3:F3"].Value = "увеличение";
            sheet.Cells["E3:F3"].Merge = true;

            sheet.Cells["G3:H3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["G3:H3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["G3:H3"].Value = "уменьшение";
            sheet.Cells["G3:H3"].Merge = true;

            sheet.Cells["I3:I4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["I3:I4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["I3:I4"].Value = "всего";
            sheet.Cells["I3:I4"].Merge = true;

            sheet.Cells["J3:K3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["J3:K3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["J3:K3"].Value = "из них";
            sheet.Cells["J3:K3"].Merge = true;

            sheet.Cells["L3:L4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["L3:L4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["L3:L4"].Value = "всего";
            sheet.Cells["L3:L4"].Merge = true;

            sheet.Cells["M3:N3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["M3:N3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["M3:N3"].Value = "из них";
            sheet.Cells["M3:N3"].Merge = true;

            sheet.Cells["C4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["C4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["C4"].Style.WrapText = true;
            sheet.Cells["C4"].Value = "долгосрочная";

            sheet.Cells["D4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["D4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["D4"].Value = "просроченная";

            sheet.Cells["E4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["E4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["E4"].Value = "всего";

            sheet.Cells["F4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["F4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["F4"].Value = "в том числе неденежные";

            sheet.Cells["G4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["G4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["G4"].Value = "всего";

            sheet.Cells["H4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["H4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["H4"].Value = "в том числе неденежные";

            sheet.Cells["J4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["J4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["J4"].Style.WrapText = true;
            sheet.Cells["J4"].Value = "долгосрочная";

            sheet.Cells["K4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["K4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["K4"].Value = "просроченная";

            sheet.Cells["M4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["M4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["M4"].Style.WrapText = true;
            sheet.Cells["M4"].Value = "долгосрочная";

            sheet.Cells["N4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells["N4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells["N4"].Value = "просроченная";

            for (int i = 1; i < 15; i++)
            {
                sheet.Cells[5, i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells[5, i].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells[5, i].Value = i;
            }
            
            for (int i = 0; i < accounts.Count; i++)
            {
                sheet.Cells[6 + i, 1].Value = $"{accounts[i].Code} {accounts[i].FormNumber} {accounts[i].SintAccount} {accounts[i].KOSGU}";

                if (accounts[i].StartYearDebt.AllSum == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].StartYearDebt.AllSum;
                }

                if (accounts[i].StartYearDebt.LongTerm == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].StartYearDebt.LongTerm;
                }

                if (accounts[i].StartYearDebt.Overdue == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].StartYearDebt.Overdue;
                }

                if (accounts[i].ChangeUpDebt.AllSum == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].ChangeUpDebt.AllSum;
                }

                if (accounts[i].ChangeUpDebt.NonmonetaryPart == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].ChangeUpDebt.NonmonetaryPart;
                }

                if (accounts[i].ChangeDownDebt.AllSum == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].ChangeUpDebt.AllSum;
                }

                if (accounts[i].ChangeDownDebt.NonmonetaryPart == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].ChangeUpDebt.NonmonetaryPart;
                }

                if (accounts[i].EndReportPeriodDebt.AllSum == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].EndReportPeriodDebt.AllSum;
                }

                if (accounts[i].EndReportPeriodDebt.LongTerm == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].EndReportPeriodDebt.LongTerm;
                }

                if (accounts[i].EndReportPeriodDebt.Overdue == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].EndReportPeriodDebt.Overdue;
                }

                if (accounts[i].EndSamePastPeriod.AllSum == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].EndSamePastPeriod.AllSum;
                }

                if (accounts[i].EndSamePastPeriod.LongTerm == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].EndSamePastPeriod.LongTerm;
                }

                if (accounts[i].EndSamePastPeriod.Overdue == 0)
                {
                    sheet.Cells[6 + i, 2].Value = "-";
                }
                else
                {
                    sheet.Cells[6 + i, 2].Value = accounts[i].EndSamePastPeriod.Overdue;
                }
            }

            sheet.Cells[1, 1, 6 + accounts.Count, 14].AutoFitColumns();

            sheet.Cells[1,1, 6 + accounts.Count, 14].Style.Border.BorderAround(ExcelBorderStyle.Double);
            sheet.Cells[1, 1, 6 + accounts.Count, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 6 + accounts.Count, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            File.WriteAllBytes(path, package.GetAsByteArray());
            return File.Exists(path);
        }
    }
}
