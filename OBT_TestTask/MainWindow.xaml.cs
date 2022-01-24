using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OBT_TestTask.Models;
using OBT_TestTask.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for MainWindow.xaml
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
            context = new AppDBContext();
            context.Database.Migrate();
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
            if ( !saveFile.ShowDialog() ?? true)
                return; 
            try
            {
                FileExporter.GenerateXLSXForm(dataGrid.ItemsSource as List<BudgetAccount>, saveFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenImportFile(object sender, RoutedEventArgs e)
        {
            if (!openFile.ShowDialog() ?? true)
                return;
            try
            {
              var list = FileImporter.ParseImportFile(openFile.FileName);
              if (budgets != null)
              {
                  FileImporter.SplitExistingAccounts(budgets, list);
                  foreach (var item in budgets)
                  {
                      context.Entry(item).State = EntityState.Modified;

                  }
              }
              context.Accounts.AddRange(list);
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
            budgets = context.Accounts.Include(a => a.StartYearDebt)
                                       .Include(a => a.ChangeUpDebt)
                                       .Include(a => a.ChangeDownDebt)
                                       .Include(a => a.EndReportPeriodDebt)
                                       .Include(a => a.EndSamePastPeriod)
                                       .ToList();
            var list = budgets;
            if (!string.IsNullOrEmpty(searchBox.Text))
            {
                list = (from acc in budgets
                       where acc.Code.Contains(searchBox.Text)
                       || acc.KOSGU.Contains(searchBox.Text)
                       || acc.SintAccount.Contains(searchBox.Text)
                       select acc).ToList();
            }

            dataGrid.ItemsSource = list;
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы хотите удалить выбранный элемент?", "Удаление строки", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No || result == MessageBoxResult.None || result == MessageBoxResult.Cancel)
                return;

            context.Entry(dataGrid.SelectedItem as BudgetAccount).State = EntityState.Deleted;
            context.SaveChanges();
            UpdateData();
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            context.Entry(e.Row.Item as BudgetAccount).State = EntityState.Modified;
            context.SaveChanges();
            UpdateData();
        }
    }
}
