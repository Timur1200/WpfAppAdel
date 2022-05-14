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

namespace WpfApp1.Pages.MainWindowPage.Client
{
    
    public partial class SelectedOrderPage : Page
    {
        private static Baskets basket { get; set; }
        private static int sum { get; set; }
        public SelectedOrderPage(Baskets b)
        {
            InitializeComponent();
            basket= b;

            TBlockNum.Text = "№ заказа " + b.Id.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sum = Data.SumProdList(basket);
            var da = Data.SelectProdList(basket);
            LBoxProd.ItemsSource = da;
            TBlockAllSum.Text = "Сумма "+ sum.ToString() + " руб.";

            if (basket.Confirm != null)
            {
                TBlock1.Visibility = Visibility.Hidden;
                TBlock2.Visibility = Visibility.Hidden;
                Btn1.Visibility = Visibility.Hidden;
                Btn2.Visibility = Visibility.Hidden;
                TBoxAddress.Visibility = Visibility.Hidden;
                TBoxDesc.Visibility = Visibility.Hidden;
            }

        }

        private void SelectPridClick(object sender, RoutedEventArgs e)
        {
            Frames.f1.Navigate(new SelectProdListPage(basket));
        }

        private void CompleteClick(object sender, RoutedEventArgs e)
        {
            using (DbModel db = new DbModel())
            {
                db.Baskets.Attach(basket);
                basket.Price = sum;
                basket.OrderDate = DateTime.Now;
                basket.Address = TBoxAddress.Text;
                basket.Desc = TBoxDesc.Text;
                basket.Confirm = false;
                db.SaveChanges();
                MessageBox.Show("Заказ сделан!");
                Frames.Back2();
            }
        }
    }
}
