using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для DiagramWindow.xaml
    /// </summary>
    public partial class DiagramWindow : Window
    {
        public DiagramWindow()
        {
            InitializeComponent();
            MyChart.ChartAreas.Add(new ChartArea("Main"));


            var currentSeries = new Series("Test2")
            {
                IsValueShownAsLabel = true
            };
            MyChart.Series.Add(currentSeries);

            ChartTypesComboBox.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ChartTypesComboBox.SelectedItem = SeriesChartType.Column;
            
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if (ChartTypesComboBox.SelectedItem
                is SeriesChartType SelectedType)
            {
                Series currentSeries = MyChart.Series.FirstOrDefault();
                currentSeries.ChartType = SelectedType;
                currentSeries.Points.Clear();

                var a = DbModel.GetContext().Baskets.Where(q => q.Confirm == true).OrderBy(q=>q.OrderDate).ToList();
                string Month = a[0].OrderDate.Value.ToString("MMMM");
                Dictionary<string, int> OrdersDict = new Dictionary<string, int>();
                OrdersDict.Add(Month, 0);
                foreach (var item in a)
                {
                   string ThisMonth = item.OrderDate.Value.ToString("MMMM");
                    if (Month != ThisMonth)
                    {
                        Month = ThisMonth;
                        OrdersDict.Add(Month, 0);
                    }
                    OrdersDict[Month] = OrdersDict[Month] + item.Price.Value;
                }

                

                foreach (var item in OrdersDict)
                {
                    
                    currentSeries.Points.AddXY(item.Key, item.Value);
                    

                }

            }
        }
    }
}
