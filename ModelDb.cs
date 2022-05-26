using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    partial class DbModel
    {
        private static DbModel Context { get; set; }

        public static DbModel GetContext()
        {
            if (Context == null) Context = new DbModel();
            return Context;
        }
    }
    partial class Products
    {
        public BitmapSource Img1
        {
            get
            {
                if (Img != null) try { return (BitmapSource)new ImageSourceConverter().ConvertFrom(Img); }
                    catch { return null; }
                return null;
            }
        }
    }

    public partial class ProductList
    {
        public override string ToString()
        {
            return $"{Products.Name} X {Amount} шт. Цена={Products.Price}";
        }
    }

    partial class Baskets
    {
        public string Status
        {
            get
            {
                if (Confirm == null) return "Не отправлен";
                else if (Confirm.Value == false) return "Обработка заказа";
                else
                    return "Готово";
            }
        }
        public string DateD
        {
            get
            {
                return OrderDate.Value.ToString("d"); 
            }
        }
    }
}
