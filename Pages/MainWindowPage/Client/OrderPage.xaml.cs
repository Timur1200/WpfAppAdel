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

namespace WpfApp1.Pages.MainWindowPage.Client
{
    
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           using (DbModel db = new DbModel())
            {
              DGridOrder.ItemsSource =  db.Baskets.Where(q => q.IdUser == Session.user.Id).ToList();
            }


        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            using (DbModel db = new DbModel())
            {
                Baskets basket = new Baskets
                {
                    IdUser = Session.user.Id,

                };

                db.Baskets.Add(basket);
                db.SaveChanges();

            }

                Page_Loaded(null, null);
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {

        }

        private void DGridOrder_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DGridOrder.SelectedItem == null)
            {
                return;
            }
            Baskets b = (Baskets)DGridOrder.SelectedItem;
            Frames.f2.Navigate(new SelectedOrderPage(b));
        }
    }
}
