using System.Collections.Generic;
using System.Windows.Controls;

namespace BudgetApp.UserControls
{
    public partial class CustomTable : UserControl
    {
        public CustomTable()
        {
            InitializeComponent();
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            var data = new List<FakeData>
            {
                new FakeData { name = "راتب شهري", amount = "5000", date = "01/08/2025" },
                new FakeData { name = "مصاريف إيجار", amount = "1500", date = "05/08/2025" },
                new FakeData { name = "تسوق", amount = "800", date = "10/08/2025" }
            };

            MyDataGrid.ItemsSource = data;
        }
    }

    public class FakeData
    {
        public string name { get; set; }
        public string amount { get; set; }
        public string date { get; set; }
    }
}
