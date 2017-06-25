using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class SanPhamvLoaiSP
    {
        // Sử dụng Eager loading 
        public void LaySPLoai1()
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                var spl = qlcf.tb_Sanpham.Include("tb_Loai").Where(m=> m.maloai=="001").ToList();
            }
        }
        // Extension method
        public static string GetName(tb_Sanpham sp, tb_Loai lsp)
        {
            return sp.tensp + " - " + lsp.tenloai;
        }
        //class Category
        //{
        //    public string tenloai { get; set; }
        //    public ObservableCollection<Product> Products { get; set; }

        //    public Category(string name, params Product[] products)
        //    {
        //        this.tenloai = name;
        //        Products = new ObservableCollection<Product>();
        //        foreach (Product p in products)
        //        {
        //            Products.Add(p);
        //        }
        //    }

        //}
        //class Product
        //{
        //    public string masp { get; set; }
        //    public string tensp { get; set; }
        //    public Nullable<double> gianhap { get; set; }
        //    public Nullable<double> giaban { get; set; }
        //    public Nullable<int> soluong { get; set; }
        //}
        //public void TaoMd()
        //{
        //    ObservableCollection<Category> categories = new ObservableCollection<Category>();
        //    foreach(var itemlsp in tb_Loai)
        //    {
        //        categories.Add(new Category(",
        //    }

        //}
    }
}
