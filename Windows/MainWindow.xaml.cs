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
using WpfApp1.Pages.MainWindowPage.Client;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public static Window win { get; set; }
        public MainWindow()
        {
            win = this;
            InitializeComponent();
            Frames.f1 = FrameMainWindow;
            if (Session.user.IsAdmin.Value) Frames.f1.Navigate(new AdminPage());
            else Frames.f1.Navigate(new ClientPage());

        }
    }
}
