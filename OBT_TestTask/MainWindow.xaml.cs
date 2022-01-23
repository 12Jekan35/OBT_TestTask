using Microsoft.Win32;
using OBT_TestTask.DatabaseServices;
using OBT_TestTask.Migrations;
using OBT_TestTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OBT_TestTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppDBContext context;
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
        private List<BudgetAccount> budgets;
        public MainWindow()
        {
            InitializeComponent();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDBContext, Configuration>());

            context = new AppDBContext();
            openFile = new OpenFileDialog();
            openFile.Filter = "Текстовый документ|*.txt";
            saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel file|*.xlsx";

            UpdateData();

            importButton.Click += OpenImportFile;
            exportExcelButton.Click += ExportDataToXLSX;
        }

        private void ExportDataToXLSX(object sender, RoutedEventArgs e)
        {
            try
            {
                saveFile.ShowDialog();
                FileExporter.GenerateXLSXForm(budgets, saveFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenImportFile(object sender, RoutedEventArgs e)
        {
            openFile.ShowDialog();
            try
            {
                var list = FileImporter.ParseImportFile(openFile.FileName);
                if (budgets != null || budgets.Count > 1)
                {
                    FileImporter.SplitExistingAccounts(budgets, list);
                    context.Accounts.AddRange(list);
                    foreach (var item in budgets)
                    {
                        context.Entry(item).State = EntityState.Modified;

                    }
                }
                context.SaveChanges();
                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось импортировать данные из файла: " + ex.Message + "\n" + ex.InnerException);
            }

        }
        private void UpdateData()
        {
            var budgets = context.Accounts.Include(a => a.StartYearDebt)
                                       .Include(a => a.ChangeUpDebt)
                                       .Include(a => a.ChangeDownDebt)
                                       .Include(a => a.EndReportPeriodDebt)
                                       .Include(a => a.EndSamePastPeriod)
                                       .ToList();
            dataGrid.ItemsSource = budgets;
        }
    }
}
