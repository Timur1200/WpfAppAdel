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
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp1.Pages.MainWindowPage.Admin
{
  
    public partial class OrderListPage : Page
    {
       
        public OrderListPage()
        {
            InitializeComponent();
            IsArh = false;
        }
        bool IsArh;
        public OrderListPage(bool b)
        {
            IsArh = true;
            InitializeComponent();
            AddBtn.Visibility = Visibility.Collapsed;
            DelBtn.Visibility = Visibility.Collapsed;
            Btn3.Visibility = Visibility.Visible;
          

        }
        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/WordFile.docx");

        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DbModel db = new DbModel())
            {
                if (IsArh)
                {
                    var a = db.Baskets.Include(q => q.Users).Where(q => q.Confirm == true).ToList();
                    DGridOrder.ItemsSource = a;
                }
                else
                {
                    //  var a = db.Baskets.Include(q => q.Users).Where(q => q.Confirm == false).ToList();
                    DGridOrder.ItemsSource = DbModel.GetContext().Baskets.Include(q => q.Users).Where(q => q.Confirm == false).ToList();
                }
                
            }
        }

        private void DGridOrder_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (DGridOrder.SelectedItem == null)
            {
                return;
            }
           // try
            {
                var basket = (Baskets)DGridOrder.SelectedItem;
                string ListProd = "";
                using (DbModel db = new DbModel())
                {
                    var textIn = Data.SelectProdList(basket);
                    //db.ProductList.Include(q => q.Products).Where(q => q.Id == basket.Id).ToList();
                    int i = 1;
                    foreach (var text in textIn)
                    {
                        ListProd += $" {i}) {text.Products.Name} X {text.Amount} ШТ, цена за штуку: {text.Products.Price}; ";
                        i++;
                        //\n
                    }
                }
                


                var wordApp = new Word.Application();

                wordApp.Visible = false;
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{Id}", Convert.ToString(basket.Id), wordDocument);
                ReplaceWordStub("{Date}", basket.OrderDate.ToString(), wordDocument);
                ReplaceWordStub("{AllSum}", basket.Price.ToString()+ " РУБ", wordDocument);
                ReplaceWordStub("{Fio}", basket.Users.Fio, wordDocument);
                ReplaceWordStub("{ListProd}", ListProd, wordDocument);
                wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/{Guid.NewGuid()}.docx"));

                wordApp.Visible = true;

                
                  
                    basket.Confirm = true;
                    DbModel.GetContext().SaveChanges();
                    Page_Loaded(null,null);
                
            }
         //   catch(Exception ex)
            {
           //     MessageBox.Show(ex.ToString());
            }

        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridOrder.SelectedItem == null)
            {
                return;
            }

            //try
            {

                var q = (Baskets)DGridOrder.SelectedItem;
                var listProd = DbModel.GetContext().ProductList.Where(a=>a.IdBasket==q.Id).ToList();
                DbModel.GetContext().ProductList.RemoveRange(listProd);
                DbModel.GetContext().Baskets.Remove(q);
                DbModel.GetContext().SaveChanges();
                MessageBox.Show("Заказ был отклонен!");
                Page_Loaded(null, null);
            }
            //catch
            //{
            //    MessageBox.Show("Произошла ошибка!");
            //}
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridOrder.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }

            Frames.f2.Navigate(new EditOrderPage(DGridOrder.SelectedItem as Baskets));
        }

        
    }
}
