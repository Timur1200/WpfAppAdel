using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    partial class Baskets
    {
        public string DateD
        {
            get
            {
                return OrderDate.Value.ToString("d"); 
            }
        }
    }
}
