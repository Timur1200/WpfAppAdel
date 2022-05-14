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
   
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            if (TBoxFio.Text.Length == 0 || TBoxPass.Password.Length == 0 || TBoxNumber.Text.Length == 0)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

            if (TBoxPass.Password != TBoxPass1.Password)
            {
                MessageBox.Show("Введенные пароли не совпадают!");
                return;
            }          

            Data.InsertUser(TBoxFio.Text,TBoxNumber.Text,TBoxPass.Password,false);
            MessageBox.Show("Регистрация прошла усшпено!");
            Windows.AuthWindow.FrameAuthWindow.NavigationService.GoBack();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Windows.AuthWindow.FrameAuthWindow.NavigationService.GoBack();
        }
    }
}
