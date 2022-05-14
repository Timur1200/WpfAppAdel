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

namespace WpfApp1.Pages.AuthWindow
{
  
    public partial class AuthPage : Page
    {
        private Window win;
        public AuthPage(Window w)
        {
            InitializeComponent();
            win = w;
        }

        private void AuthClick(object sender, RoutedEventArgs e)
        {
            using (DbModel db = new DbModel())
            {
               var UsersList= db.Users.ToList();
                foreach (var user in UsersList)
                { 
                    if (user.Phone == TBoxNumber.Text && user.Pass == TBoxPass.Password )
                    {
                        Session.user = user;
                        MainWindow w = new MainWindow();
                        w.Show();
                        win.Close();
                        return;
                    }
                }
                MessageBox.Show("Неправильно введен логин или пароль");
            }
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            Windows.AuthWindow.FrameAuthWindow.Navigate(new RegisterPage());
        }

        private void userClick(object sender, RoutedEventArgs e)
        {
            TBoxNumber.Text = "1";
            TBoxPass.Password = "1";
            AuthClick(null,null);
        }

        private void adminClick(object sender, RoutedEventArgs e)
        {
            TBoxNumber.Text = "123";
            TBoxPass.Password = "123";
            AuthClick(null, null);
        }
    }
}
