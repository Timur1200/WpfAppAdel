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
using WpfApp1.Pages.MainWindowPage.Admin;

namespace WpfApp1.Pages.MainWindowPage.Client
{
    
    public partial class SelectProdListPage : Page
    {
        private static Baskets basket { get; set; }
        public SelectProdListPage(Baskets b)
        {
            InitializeComponent();
            basket = b;
            FrameInWindow.Navigate(new ProdListPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DbModel db = new DbModel())
            {
                ProductList pl = new ProductList
                {
                    IdBasket = basket.Id,
                    IdProduct = ProdListPage.SelectedProduct.Id,

                };
                try { 
                pl.Amount = Convert.ToInt32( TBoxAmount.Text);
                }
                catch { pl.Amount = 1; }
                db.ProductList.Add(pl);
                db.SaveChanges();


            }


            Frames.Back1();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Frames.Back1();
        }
    }
}
