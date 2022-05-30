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
using static WpfApp1.Frames;
using WpfApp1.Windows;
using System.Diagnostics;

namespace WpfApp1.Pages.MainWindowPage.Admin
{
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            f2 = FrameAdminPage;

        }
        private void Go(Page page)
        {
            f2.Navigate(page); 
        }

        private void OutClick(object sender, RoutedEventArgs e)
        {
            Session.user = null;
           
            Windows.AuthWindow a = new Windows.AuthWindow();
            a.Show(); 
            MainWindow.win.Close();

        }

        private void ProductClick(object sender, RoutedEventArgs e)
        {
            Go(new ProductPage());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Back1();
        }

        private void ProdListClick(object sender, RoutedEventArgs e)
        {
            Go(new ProdListPage());
        }

        private void OrderClick(object sender, RoutedEventArgs e)
        {
            Go(new OrderListPage());
        }

        private void ArhClick(object sender, RoutedEventArgs e)
        {
            Go(new OrderListPage(true));
        }

        private void ProceedsClick(object sender, RoutedEventArgs e)
        {
            Go(new ProceedsPage());
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            Process.Start(System.IO.Path.GetFullPath(@"help.chm"));
        }
    }
}
