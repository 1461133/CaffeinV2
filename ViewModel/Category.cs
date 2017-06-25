using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class Category
    {
        //private ObservableCollection<Product> products;

        public string maloai { get; set; }
        public string tenloai { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        //public Category(string maloai,string name, params Product[] products)
        //{
        //    this.maloai = maloai;
        //    this.tenloai = name;
        //    Products = new ObservableCollection<Product>();
        //    foreach (Product p in products)
        //    {
        //        Products.Add(p);
        //    }
        //}

        public Category(string maloai, string tenloai, ObservableCollection<Product> products)
        {
            try
            {
                this.maloai = maloai;
                this.tenloai = tenloai;
                //this.products = products;
                Products = new ObservableCollection<Product>();
                foreach (var item in products)
                {
                    Products.Add(item);
                }
            }
            catch
            {
                bool k = false;
            }
        }
    }
}
