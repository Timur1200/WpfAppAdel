//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.ProductList = new HashSet<ProductList>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public string Desc { get; set; }
        public Nullable<bool> IsActual { get; set; }
        public byte[] Img { get; set; }

        public BitmapSource Img1
        {
            get
            {
                if (Img != null) try { return (BitmapSource)new ImageSourceConverter().ConvertFrom(Img); }
                    catch { return null; }
                return null;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductList> ProductList { get; set; }
    }
}
