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
    /// <summary>
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        public EditOrderPage(Baskets bask)
        {
            InitializeComponent();
            PaymentTypeComboBox.Items.Add("Наличными");
            PaymentTypeComboBox.Items.Add("Картой");
            _baskets = bask;
            TBlockId.Text = $"№ заказа {bask.Id}";
            TBlockPhone.Text = $"Телефон: {bask.Users.Phone}";
            DataContext = _baskets;

        }
        private Baskets _baskets { get; set; }
        private void CompleteClick(object sender, RoutedEventArgs e)
        {
            
            DbModel.GetContext().SaveChanges();
            Frames.Back2();
            MessageBox.Show("Информация сохранена!");
        }
    }
}
