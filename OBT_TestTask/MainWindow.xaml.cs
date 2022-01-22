using Microsoft.Win32;
using OBT_TestTask.DatabaseServices;
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
        private List<BudgetAccount> budgets;
        public MainWindow()
        {
            InitializeComponent();
            context = new AppDBContext();
            openFile = new OpenFileDialog();
            openFile.Filter = "Текстовый документ|*.txt";
            budgets = context.Accounts.Include(a => a.StartYearDebt)
                                      .Include(a => a.ChangeUpDebt)
                                      .Include(a => a.ChangeDownDebt)
                                      .Include(a => a.EndReportPeriodDebt)
                                      .Include(a => a.EndSamePastPeriod)
                                      .ToList();
            dataGrid.ItemsSource = budgets;
            importButton.Click += OpenImportFile;
        }

        private void OpenImportFile(object sender, RoutedEventArgs e)
        {
            openFile.ShowDialog();
            try
            {
                var list = FileImporter.ParseImportFile(openFile.FileName);
                FileImporter.SplitExistingAccounts(budgets, list);
                context.Accounts.AddRange(list);
                foreach (var item in budgets)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChanges();
                UpdateData();
            }
            catch
            {
                MessageBox.Show("Не удалось импортировать данные из файла");
            }

        }
        private void UpdateData()
        {
            var list = context.Accounts.Include(a => a.StartYearDebt)
                                       .Include(a => a.ChangeUpDebt)
                                       .Include(a => a.ChangeDownDebt)
                                       .Include(a => a.EndReportPeriodDebt)
                                       .Include(a => a.EndSamePastPeriod)
                                       .ToList();
            dataGrid.ItemsSource = list;
        }
    }
}
