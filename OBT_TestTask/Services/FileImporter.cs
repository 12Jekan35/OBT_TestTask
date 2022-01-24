using OBT_TestTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBT_TestTask.Services
{
    public static class FileImporter
    {
        public static List<BudgetAccount> ParseImportFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            var list = new List<BudgetAccount>();
            using (var reader = new StreamReader(filePath))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line[0] == '#' || line.Contains("ТБ=01") || line[0] == '*')
                    {
                        continue;
                    }
                    var data = line.Split('|');
                    var acc = new BudgetAccount
                    {
                        Code = data[0],
                        FormNumber = int.Parse(data[1]),
                        SintAccount = data[2],
                        KOSGU = data[3]
                    };
                    var start = new Debt
                    {
                        AllSum = decimal.Parse(data[4]),
                        LongTerm = decimal.Parse(data[5]),
                        Overdue = decimal.Parse(data[6])
                    };
                    var changeUp = new ChangeDebt
                    {
                        AllSum = decimal.Parse(data[7]),
                        NonmonetaryPart = decimal.Parse(data[8])
                    };
                    var changeDown = new ChangeDebt
                    {
                        AllSum = decimal.Parse(data[9]),
                        NonmonetaryPart = decimal.Parse(data[10])
                    };
                    var endPeriod = new Debt
                    {
                        AllSum = decimal.Parse(data[11]),
                        LongTerm = decimal.Parse(data[12]),
                        Overdue = decimal.Parse(data[13])
                    };
                    var endSamePeriod = new Debt
                    {
                        AllSum = decimal.Parse(data[11]),
                        LongTerm = decimal.Parse(data[12]),
                        Overdue = decimal.Parse(data[13])
                    };
                    acc.StartYearDebt = start;
                    acc.ChangeUpDebt = changeUp;
                    acc.ChangeDownDebt = changeDown;
                    acc.EndReportPeriodDebt = endPeriod;
                    acc.EndSamePastPeriod = endSamePeriod;
                    list.Add(acc);
                }
            }
            return list;
        }
        public static List<BudgetAccount> SplitExistingAccounts(List<BudgetAccount> oldAccounts, List<BudgetAccount> newAccounts)
        {
            if (oldAccounts.Count < 1)
                return newAccounts;

            var list = new List<BudgetAccount>();

            for (int i = 0; i < oldAccounts.Count; i++)
            {
                for (int j = 0; j < newAccounts.Count; j++)
                {
                    if (oldAccounts[i].Code == newAccounts[j].Code
                        && oldAccounts[i].FormNumber == newAccounts[j].FormNumber
                        && oldAccounts[i].SintAccount == newAccounts[j].SintAccount
                        && oldAccounts[i].KOSGU == newAccounts[j].KOSGU)
                    {
                        oldAccounts[i].StartYearDebt = newAccounts[j].StartYearDebt;
                        oldAccounts[i].ChangeUpDebt = newAccounts[j].ChangeUpDebt;
                        oldAccounts[i].ChangeDownDebt = newAccounts[j].ChangeDownDebt;
                        oldAccounts[i].EndReportPeriodDebt = newAccounts[j].EndReportPeriodDebt;
                        oldAccounts[i].EndSamePastPeriod = newAccounts[j].EndSamePastPeriod;
                        newAccounts.Remove(newAccounts[j]);
                        j--;
                    }
                }
            }

            return list;
        }
    }
}
