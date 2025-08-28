using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BudgetApp.UserControls
{
    public partial class CustomTable : UserControl
    {
        public CustomTable()
        {
            InitializeComponent();
            LoadFakeData();
        }

        private void MyDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // نأخذ الستايلات من موارد الـ DataGrid
            var tbStyle = (Style)MyDataGrid.Resources["CellTextBlockStyle"];
            var tbxStyle = (Style)MyDataGrid.Resources["CellTextBoxStyle"];

            if (e.Column is DataGridTextColumn textCol)
            {
                textCol.ElementStyle = tbStyle;           // عرض الخلية (عرض الوضع العادي)
                textCol.EditingElementStyle = tbxStyle;  // محرر الخلية عند التعديل (TextBox)
            }
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // تحقق من أن هناك سطراً محدداً
            if (MyDataGrid.SelectedItem != null)
            {
                // احصل على السطر المحدد
                DataGridRow row = (DataGridRow)MyDataGrid.ItemContainerGenerator.ContainerFromItem(MyDataGrid.SelectedItem);

                // إذا كان السطر موجوداً، قم بتغيير لونه
                if (row != null)
                {
                    row.Background = new SolidColorBrush(Color.FromRgb(255, 192, 203)); // اللون الزهري
                }
            }
        }

        private void LoadFakeData()
        {
            var data = new List<FakeData>
            {
                new() { Name = "راتب شهري", Amount = "5000", Date = "01/08/2025" },
                new() { Name = "مصاريف إيجار", Amount = "1500", Date = "05/08/2025" },
                new() { Name = "تسوق", Amount = "800", Date = "10/08/2025" }
            };

            MyDataGrid.ItemsSource = data;
        }
    }

    public class FakeData
    {
        public required string Name { get; set; }
        public required string Amount { get; set; }
        public required string Date { get; set; }
    }
}
