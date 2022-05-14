using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using WpfApp1.Windows;

namespace WpfApp1.Pages.MainWindowPage.Admin
{
    /// <summary>
    /// Логика взаимодействия для ProceedsPage.xaml
    /// </summary>
    public partial class ProceedsPage : Page
    {
        public ProceedsPage()
        {
            InitializeComponent();
        }
        List <Baskets> _Baskets = new List<Baskets>();  

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            //var a = DbModel.GetContext().Baskets.Include(q => q.Users).Where(q => q.Confirm == true).ToList();
            //DGridOrder.ItemsSource = a;
            Calendar.SelectedDate = DateTime.Now;
        }

        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            //  var a = _Baskets.Where(q=>q.OrderDate==Calendar.SelectedDate).ToList();
            
            var a = DbModel.GetContext().Baskets.Include(q => q.Users).Where(q => q.Confirm == true).ToList();
           _Baskets.Clear();
            foreach (var item in a)
            {
                if (item.OrderDate.Value.ToString("d") == Calendar.SelectedDate.Value.ToString("d"))
                {
                    _Baskets.Add(item);
                }

            }

            int sum = 0;
            foreach (var item in _Baskets)
            {
                sum = sum + item.Price.Value;
            }

            DGridOrder.ItemsSource = _Baskets;
            SumTextBlock.Text = $"Сумма выручки за день: {sum} РУБ";
            DGridOrder.Items.Refresh();
        }

        private void DGridOrder_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void DiagramClick(object sender, RoutedEventArgs e)
        {
            DiagramWindow diagramWindow = new DiagramWindow();
            diagramWindow.Show();
        }
    }
}
