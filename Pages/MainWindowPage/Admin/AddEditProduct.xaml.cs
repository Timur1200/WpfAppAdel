using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

    public partial class AddEditProduct : Page
    {
        public AddEditProduct()
        {
            InitializeComponent();
            prod = null;
            
        }
        public AddEditProduct(Products mProd)
        {
            InitializeComponent();
            prod = mProd;
            TBoxDesc.Text = mProd.Desc;
            TBoxName.Text = mProd.Name;
            TBoxPrice.Text = mProd.Price.ToString();

        }
        private static string FileName { get; set; }
        private static Products prod {get;set;}

        private void LoadImgClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                MessageBox.Show("Изображение получено!");
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {try
            {
                if (prod == null)
                {
                    using (DbModel db = new DbModel())
                    {
                        Products p = new Products
                        {
                            Price = Convert.ToInt32(TBoxPrice.Text),
                            Name = TBoxName.Text,
                            Desc = TBoxDesc.Text,

                        };
                        if (FileName != null)
                        {
                            byte[] bData = File.ReadAllBytes(FileName);
                            p.Img = bData;
                            FileName = null;
                        }
                        db.Products.Add(p);
                        db.SaveChanges();
                        MessageBox.Show("Запись добавлена!");
                        Frames.Back2();

                    }


                }
                else
                {
                    using (DbModel db = new DbModel())
                    {
                        db.Products.Attach(prod);
                        prod.Price = Convert.ToInt32(TBoxPrice.Text);
                        prod.Name = TBoxName.Text;
                        prod.Desc = TBoxDesc.Text;
                        if (FileName != null)
                        {
                            byte[] bData = File.ReadAllBytes(FileName);
                            prod.Img = bData;
                            FileName = null;
                        }
                        db.SaveChanges();
                        MessageBox.Show("Обновлено!");
                        Frames.Back2();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
