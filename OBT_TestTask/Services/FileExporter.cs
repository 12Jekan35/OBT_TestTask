using OBT_TestTask.Models;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace OBT_TestTask.Services
{
    public static class FileExporter
    {
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
            int counter = 6;
            var total = new BudgetAccount();
            var start = new Debt
            {
                AllSum = 0,
                LongTerm = 0,
                Overdue = 0
            };
            var changeUp = new ChangeDebt
            {
                AllSum = 0,
                NonmonetaryPart = 0
            };
            var changeDown = new ChangeDebt
            {
                AllSum = 0,
                NonmonetaryPart = 0
            };
            var endPeriod = new Debt
            {
                AllSum = 0,
                LongTerm = 0,
                Overdue = 0
            };
            var endSamePeriod = new Debt
            {
                AllSum = 0,
                LongTerm = 0,
                Overdue = 0
            };
            total.StartYearDebt = start;
            total.ChangeUpDebt = changeUp;
            total.ChangeDownDebt = changeDown;
            total.EndReportPeriodDebt = endPeriod;
            total.EndSamePastPeriod = endSamePeriod;
            for (int i = 0; i < accounts.Count; i++)
            {
                sheet.Cells[6 + i, 1].Value = $"{accounts[i].Code} {accounts[i].FormNumber} {accounts[i].SintAccount} {accounts[i].KOSGU}";

                sheet.Cells[6 + i, 2].Value = accounts[i].StartYearDebt.AllSum == 0 ? "-" : accounts[i].StartYearDebt.AllSum;
                total.StartYearDebt.AllSum += accounts[i].StartYearDebt.AllSum;


                sheet.Cells[6 + i, 3].Value = accounts[i].StartYearDebt.LongTerm == 0? "-" : accounts[i].StartYearDebt.LongTerm;
                total.StartYearDebt.LongTerm += accounts[i].StartYearDebt.LongTerm;


                sheet.Cells[6 + i, 4].Value = accounts[i].StartYearDebt.Overdue == 0? "-" : accounts[i].StartYearDebt.Overdue;
                total.StartYearDebt.Overdue += accounts[i].StartYearDebt.Overdue;


                sheet.Cells[6 + i, 5].Value = accounts[i].ChangeUpDebt.AllSum == 0? "-" : accounts[i].ChangeUpDebt.AllSum;
                total.ChangeUpDebt.AllSum += accounts[i].ChangeUpDebt.AllSum;


                sheet.Cells[6 + i, 6].Value = accounts[i].ChangeUpDebt.NonmonetaryPart == 0? "-" : accounts[i].ChangeUpDebt.NonmonetaryPart;
                total.ChangeUpDebt.NonmonetaryPart += accounts[i].ChangeUpDebt.NonmonetaryPart;


                sheet.Cells[6 + i, 7].Value = accounts[i].ChangeDownDebt.AllSum == 0? "-" : accounts[i].ChangeDownDebt.AllSum;
                total.ChangeDownDebt.AllSum += accounts[i].ChangeDownDebt.AllSum;

                sheet.Cells[6 + i, 8].Value = accounts[i].ChangeDownDebt.NonmonetaryPart == 0? "-" : accounts[i].ChangeDownDebt.NonmonetaryPart;
                total.ChangeDownDebt.NonmonetaryPart += accounts[i].ChangeDownDebt.NonmonetaryPart;

                sheet.Cells[6 + i, 9].Value = accounts[i].EndReportPeriodDebt.AllSum == 0? "-" : accounts[i].EndReportPeriodDebt.AllSum;
                total.EndReportPeriodDebt.AllSum += accounts[i].EndReportPeriodDebt.AllSum;

                sheet.Cells[6 + i, 10].Value = accounts[i].EndReportPeriodDebt.LongTerm == 0? "-" : accounts[i].EndReportPeriodDebt.LongTerm;
                total.EndReportPeriodDebt.LongTerm += accounts[i].EndReportPeriodDebt.LongTerm;

                sheet.Cells[6 + i, 11].Value = accounts[i].EndReportPeriodDebt.Overdue == 0? "-" : accounts[i].EndReportPeriodDebt.Overdue;
                total.EndReportPeriodDebt.Overdue += accounts[i].EndReportPeriodDebt.Overdue;

                sheet.Cells[6 + i, 12].Value = accounts[i].EndSamePastPeriod.AllSum == 0? "-" : accounts[i].EndSamePastPeriod.AllSum;
                total.EndSamePastPeriod.AllSum += accounts[i].EndSamePastPeriod.AllSum;

                sheet.Cells[6 + i, 13].Value = accounts[i].EndSamePastPeriod.LongTerm == 0? "-" : accounts[i].EndSamePastPeriod.LongTerm;
                total.EndSamePastPeriod.LongTerm += accounts[i].EndSamePastPeriod.LongTerm;

                sheet.Cells[6 + i, 14].Value = accounts[i].EndSamePastPeriod.Overdue == 0? "-" : accounts[i].EndSamePastPeriod.Overdue;
                total.EndSamePastPeriod.Overdue += accounts[i].EndSamePastPeriod.Overdue;

                counter++;


            }

            sheet.Cells[counter, 1].Value = $"Всего задолжности:";
            sheet.Cells[counter, 2].Value =  total.StartYearDebt.AllSum == 0 ? "-" :            total.StartYearDebt.AllSum;
            sheet.Cells[counter, 3].Value =  total.StartYearDebt.LongTerm == 0? "-" :           total.StartYearDebt.LongTerm;
            sheet.Cells[counter, 4].Value =  total.StartYearDebt.Overdue == 0? "-" :            total.StartYearDebt.Overdue;
            sheet.Cells[counter, 5].Value =  total.ChangeUpDebt.AllSum == 0? "-" :              total.ChangeUpDebt.AllSum;
            sheet.Cells[counter, 6].Value =  total.ChangeUpDebt.NonmonetaryPart == 0? "-" :     total.ChangeUpDebt.NonmonetaryPart;
            sheet.Cells[counter, 7].Value =  total.ChangeDownDebt.AllSum == 0 ? "-" :           total.ChangeDownDebt.AllSum;
            sheet.Cells[counter, 8].Value =  total.ChangeDownDebt.NonmonetaryPart == 0 ? "-" :  total.ChangeDownDebt.NonmonetaryPart;
            sheet.Cells[counter, 9].Value =  total.EndReportPeriodDebt.AllSum == 0 ? "-" :      total.EndReportPeriodDebt.AllSum;
            sheet.Cells[counter, 10].Value = total.EndReportPeriodDebt.LongTerm == 0 ? "-" :    total.EndReportPeriodDebt.LongTerm;
            sheet.Cells[counter, 11].Value = total.EndReportPeriodDebt.Overdue == 0 ? "-" :     total.EndReportPeriodDebt.Overdue;
            sheet.Cells[counter, 12].Value = total.EndSamePastPeriod.AllSum == 0 ? "-" :        total.EndSamePastPeriod.AllSum;
            sheet.Cells[counter, 13].Value = total.EndSamePastPeriod.LongTerm == 0 ? "-" :      total.EndSamePastPeriod.LongTerm;
            sheet.Cells[counter, 14].Value = total.EndSamePastPeriod.Overdue == 0 ? "-" :       total.EndSamePastPeriod.Overdue;

            sheet.Cells[1, 1, 6 + accounts.Count, 14].AutoFitColumns();

            sheet.Cells[1, 1, 6 + accounts.Count, 14].Style.Border.BorderAround(ExcelBorderStyle.Double);
            sheet.Cells[1, 1, 6 + accounts.Count, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 6 + accounts.Count, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            File.WriteAllBytes(path, package.GetAsByteArray());
            return File.Exists(path);
        }

        public static bool GenerateXMLForm(List<BudgetAccount> accounts, string path)
        {
            var doc = new XDocument();

            XElement[] data = new XElement[accounts.Count + 1];
            var total = new BudgetAccount();
            var start = new Debt
            {
                AllSum = 0,
                LongTerm = 0,
                Overdue = 0
            };
            var changeUp = new ChangeDebt
            {
                AllSum = 0,
                NonmonetaryPart = 0
            };
            var changeDown = new ChangeDebt
            {
                AllSum = 0,
                NonmonetaryPart = 0
            };
            var endPeriod = new Debt
            {
                AllSum = 0,
                LongTerm = 0,
                Overdue = 0
            };
            var endSamePeriod = new Debt
            {
                AllSum = 0,
                LongTerm = 0,
                Overdue = 0
            };
            total.StartYearDebt = start;
            total.ChangeUpDebt = changeUp;
            total.ChangeDownDebt = changeDown;
            total.EndReportPeriodDebt = endPeriod;
            total.EndSamePastPeriod = endSamePeriod;

            for (int i = 0; i < accounts.Count; i++)
            {
                var item = new XElement("Data");
                var sintAccount = new XAttribute("СинтСчёт", accounts[i].SintAccount);
                var _KOSGU = new XAttribute("КОСГУ", accounts[i].KOSGU);
                item.Add(sintAccount);
                item.Add(_KOSGU);

                if (accounts[i].StartYearDebt.AllSum > 0)
                {
                    item.Add(new XAttribute("_x2", accounts[i].StartYearDebt.AllSum));
                    total.StartYearDebt.AllSum += accounts[i].StartYearDebt.AllSum;
                }
                if (accounts[i].StartYearDebt.LongTerm > 0)
                {
                    item.Add(new XAttribute("_x3", accounts[i].StartYearDebt.LongTerm));
                    total.StartYearDebt.LongTerm += accounts[i].StartYearDebt.LongTerm;
                }
                if (accounts[i].StartYearDebt.Overdue > 0)
                {
                    item.Add(new XAttribute("_x4", accounts[i].StartYearDebt.Overdue));
                    total.StartYearDebt.Overdue += accounts[i].StartYearDebt.Overdue;
                }
                if (accounts[i].ChangeUpDebt.AllSum > 0)
                {
                    item.Add(new XAttribute("_x5", accounts[i].ChangeUpDebt.AllSum));
                    total.ChangeUpDebt.AllSum += accounts[i].ChangeUpDebt.AllSum;
                }
                if (accounts[i].ChangeUpDebt.NonmonetaryPart > 0)
                {
                    item.Add(new XAttribute("_x6", accounts[i].ChangeUpDebt.NonmonetaryPart));
                    total.ChangeUpDebt.NonmonetaryPart += accounts[i].ChangeUpDebt.NonmonetaryPart;
                }
                if (accounts[i].ChangeDownDebt.AllSum > 0)
                {
                    item.Add(new XAttribute("_x7", accounts[i].ChangeDownDebt.AllSum));
                    total.ChangeDownDebt.AllSum += accounts[i].ChangeDownDebt.AllSum;
                }
                if (accounts[i].ChangeDownDebt.NonmonetaryPart > 0)
                {
                    item.Add(new XAttribute("_x8", accounts[i].ChangeDownDebt.NonmonetaryPart));
                    total.ChangeDownDebt.NonmonetaryPart += accounts[i].ChangeDownDebt.NonmonetaryPart;
                }
                if (accounts[i].EndReportPeriodDebt.AllSum > 0)
                {
                    item.Add(new XAttribute("_x9", accounts[i].EndReportPeriodDebt.AllSum));
                    total.EndReportPeriodDebt.AllSum += accounts[i].EndReportPeriodDebt.AllSum;
                }
                if (accounts[i].EndReportPeriodDebt.LongTerm > 0)
                {
                    item.Add(new XAttribute("_x10", accounts[i].EndReportPeriodDebt.LongTerm));
                    total.EndReportPeriodDebt.LongTerm += accounts[i].EndReportPeriodDebt.LongTerm;
                }
                if (accounts[i].EndReportPeriodDebt.Overdue > 0)
                {
                    item.Add(new XAttribute("_x11", accounts[i].EndReportPeriodDebt.Overdue));
                    total.EndReportPeriodDebt.Overdue += accounts[i].EndReportPeriodDebt.Overdue;
                }
                if (accounts[i].EndSamePastPeriod.AllSum > 0)
                {
                    item.Add(new XAttribute("_x12", accounts[i].EndSamePastPeriod.AllSum));
                    total.EndSamePastPeriod.AllSum += accounts[i].EndSamePastPeriod.AllSum;
                }
                if (accounts[i].EndSamePastPeriod.LongTerm > 0)
                {
                    item.Add(new XAttribute("_x13", accounts[i].EndSamePastPeriod.LongTerm));
                    total.EndSamePastPeriod.LongTerm += accounts[i].EndSamePastPeriod.LongTerm;
                }
                if (accounts[i].EndSamePastPeriod.Overdue > 0)
                {
                    item.Add(new XAttribute("_x14", accounts[i].EndSamePastPeriod.Overdue));
                    total.EndSamePastPeriod.Overdue += accounts[i].EndSamePastPeriod.Overdue;
                }
                data[i] = item;
            }
            var totalElement = new XElement("Data");
            totalElement.Add(new XAttribute("СинтСчёт", "88888"));
            totalElement.Add(new XAttribute("КОСГУ", "888"));

            if (total.StartYearDebt.AllSum > 0)
            {
                totalElement.Add(new XAttribute("_x2", total.StartYearDebt.AllSum));
            }
            if (total.StartYearDebt.LongTerm > 0)
            {
                totalElement.Add(new XAttribute("_x3", total.StartYearDebt.LongTerm));
            }
            if (total.StartYearDebt.Overdue > 0)
            {
                totalElement.Add(new XAttribute("_x4", total.StartYearDebt.Overdue));
            }
            if (total.ChangeUpDebt.AllSum > 0)
            {
                totalElement.Add(new XAttribute("_x5", total.ChangeUpDebt.AllSum));
            }
            if (total.ChangeUpDebt.NonmonetaryPart > 0)
            {
                totalElement.Add(new XAttribute("_x6", total.ChangeUpDebt.NonmonetaryPart));
            }
            if (total.ChangeDownDebt.AllSum > 0)
            {
                totalElement.Add(new XAttribute("_x7", total.ChangeDownDebt.AllSum));
            }
            if (total.ChangeDownDebt.NonmonetaryPart > 0)
            {
                totalElement.Add(new XAttribute("_x8", total.ChangeDownDebt.NonmonetaryPart));
            }
            if (total.EndReportPeriodDebt.AllSum > 0)
            {
                totalElement.Add(new XAttribute("_x9", total.EndReportPeriodDebt.AllSum));
            }
            if (total.EndReportPeriodDebt.LongTerm > 0)
            {
                totalElement.Add(new XAttribute("_x10", total.EndReportPeriodDebt.LongTerm));
            }
            if (total.EndReportPeriodDebt.Overdue > 0)
            {
                totalElement.Add(new XAttribute("_x11", total.EndReportPeriodDebt.Overdue));
            }
            if (total.EndSamePastPeriod.AllSum > 0)
            {
                totalElement.Add(new XAttribute("_x12", total.EndSamePastPeriod.AllSum));
            }
            if (total.EndSamePastPeriod.LongTerm > 0)
            {
                totalElement.Add(new XAttribute("_x13", total.EndSamePastPeriod.LongTerm));
            }
            if (total.EndSamePastPeriod.Overdue > 0)
            {
                totalElement.Add(new XAttribute("_x14", total.EndSamePastPeriod.Overdue));
            }
            data[accounts.Count] = totalElement;

            var report = new XElement("RootXml", 
                                      new XElement("Report",
                                                   new XAttribute("Code", "042"),
                                                   new XAttribute("AlbumCode", "МЕС_К"),
                                                   new XElement("FormVariant",
                                                                new XAttribute("Number", "1"),
                                                                new XAttribute("NsiVariantCode", "0000"),
                                                                new XElement("Table", new XAttribute("Code", "Строка"), data))));

            doc.Add(report);
            doc.Save(path);
            return File.Exists(path);
        }
    }
}
