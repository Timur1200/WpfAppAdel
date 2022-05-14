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

namespace WpfApp1.Pages.MainWindowPage.Admin
{
   
    public partial class ProdListPage : Page
    {
        public static Products SelectedProduct { get; set; }

        public ProdListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LViewProd.ItemsSource = Data.SelectProduct();
            CboxType.Items.Add("Название");
            CboxType.Items.Add("Описание");
            CboxType.SelectedIndex = 0;
        }

        private void Search()
        {
            if (TBoxSearch.Text.Length == 0) { LViewProd.ItemsSource = Data.SelectProduct(); return; }

            using (DbModel db = new DbModel())
            {
                if (CboxType.SelectedIndex == 0)
                {
                    LViewProd.ItemsSource = db.Products.Where(q => q.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
                }
                else
                {
                    LViewProd.ItemsSource = db.Products.Where(q => q.Desc.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
                }
                
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void LViewMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedProduct = (Products)LViewProd.SelectedItem;
            }
            catch { }
        }

        private void CboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
    }
}
