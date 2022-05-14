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

namespace WpfApp1.Pages.MainWindowPage.Admin
{
    
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
           
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Frames.f2.Navigate(new AddEditProduct());
        }

          private void DelClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbModel db = new DbModel())
                {
                    if (DGridProd.SelectedItem == null)
                    {
                        MessageBox.Show("Выделите запись!");
                        return;
                    }
                    var p = (Products)DGridProd.SelectedItem;
                    db.Products.Attach(p);
                    db.Products.Remove(p);
                    db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Удалено!");
                }
            }
            catch
            {
                MessageBox.Show("Удаление невозможно, запись используется");
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridProd.SelectedItem == null)
            {
                MessageBox.Show("Выделите запись!");
                return;
            }
            var p = (Products)DGridProd.SelectedItem;
            Frames.f2.Navigate(new AddEditProduct(p));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridProd.ItemsSource = Data.SelectProduct();
        }
    }
}
