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
using System.Windows.Shapes;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void PasswordClick(object sender, RoutedEventArgs e)
        {
           bool IsFindedUser = DbModel.GetContext().Users.Any(q => q.Phone == TBoxNumber.Text);

            if (IsFindedUser)
            {
                if (TBoxPass.Password == TBoxPass1.Password)
                {
                    var usersList = DbModel.GetContext().Users.Where(q => q.Phone == TBoxNumber.Text).ToList();
                    var user = usersList[0];
                    user.Pass = TBoxPass1.Password;
                    DbModel.GetContext().SaveChanges();
                    MessageBox.Show("Пароль был успешно востоновлен");
                    Close();
                }
                else
                {
                    MessageBox.Show("Введенные пароли не совпадают");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Данный номер телефона зарегистрирован!");
                return;
            }
        }
    }
}
