using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WpfApp1
{
    public static class Data
    {
        #region Users
        
        public static void InsertUser(string mFio,string mNumber,string mPass,bool admin)
        {
            using (DbModel db = new DbModel())
            {
                Users user = new Users
                {
                    Fio = mFio,
                    Phone = mNumber,
                    Pass = mPass,
                    IsAdmin = admin,
                    
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }



        #endregion

        #region Products
        public static List<Products> SelectProduct()
        { 
        using (DbModel db = new DbModel())
            {
                return db.Products.ToList();

            }
        }


        #endregion

        #region ProductList

        public static List<ProductList> SelectProdList(Baskets b)
        {
            using (DbModel db = new DbModel())
            {
               return db.ProductList.Include(q => q.Products).Where(q => q.IdBasket == b.Id).ToList();
            }
        }

        public static int SumProdList(Baskets b)
        {
            using (DbModel db = new DbModel())
            {
                int sum = 0;
                foreach (var a in SelectProdList(b))
                {
                    sum += a.Amount.Value * a.Products.Price.Value;
                }

                return sum;

            }
        }

        #endregion
    }
}
