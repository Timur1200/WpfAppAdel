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
using WpfApp1.Pages.MainWindowPage;
using System.Diagnostics;

namespace WpfApp1.Pages.MainWindowPage.Client
{
  
    public partial class ClientPage : Page
    {
        public ClientPage()
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

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Back2();
        }

        private void ProdListClick(object sender, RoutedEventArgs e)
        {
            Go(new Admin.ProdListPage());
        }

        private void OrderPageClick(object sender, RoutedEventArgs e)
        {
            Go(new OrderPage());
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            Process.Start(System.IO.Path.GetFullPath(@"help.chm"));
        }
        
    }
}
