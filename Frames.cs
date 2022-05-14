using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
  public static class Frames
    {
        public static Frame f1 { get; set; }
       public static Frame f2 { get; set; }

       public static void Back1() 
        {
            if (f1.NavigationService.CanGoBack) f1.NavigationService.GoBack();    
        }

       public static void Back2()
        {
            if (f2.NavigationService.CanGoBack) f2.NavigationService.GoBack();
        }

    }
}
