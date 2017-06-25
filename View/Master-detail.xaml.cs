using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using ViewModel;
using Model;

namespace View
{
    /// <summary>
    /// Interaction logic for Master_detail.xaml
    /// </summary>
    public partial class Master_detail : Window
    {
        ObservableCollection<Category> listCat;
        LoaiSP lsp = new LoaiSP();
        public Master_detail()
        {
            InitializeComponent();
            listCat = new ObservableCollection<Category>();
            foreach (var item in lsp.LayAllLoaiSP())
            {
                SanPham sp = new SanPham();
                var Products = new ObservableCollection<Product>();

                foreach (var p in sp.LaySPTheoLoai(item))
                {
                    Product pro = new Product();
                    pro.masp = p.masp;
                    pro.tensp = p.tensp;
                    pro.soluong = p.soluong;
                    pro.giaban = p.giaban;
                    pro.gianhap = p.gianhap;
                    Products.Add(pro);
                }
                Category cat = new Category(item.maloai, item.tenloai, Products);
                listCat.Add(cat);
            }
            cbCat.DataContext = listCat;
        }
    }
}
