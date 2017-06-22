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
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for TCNhanVien.xaml
    /// </summary>
    public partial class TCNhanVien : Window
    {
        public string TENDN;
        public TCNhanVien(string tendn)
        {
            InitializeComponent();
            label.Content = tendn;
            TENDN = tendn;
        }
        
        private void QuanLySanPham_Click(object sender, RoutedEventArgs e)
        {
            QLSanPham f = new QLSanPham(TENDN);
            f.Show();
        }

        private void QuanLyKhachHang_Click(object sender, RoutedEventArgs e)
        {
            QLKhachHangNV f = new QLKhachHangNV(TENDN);
            f.Show();
        }

        private void ThongKe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThanhToan_Click(object sender, RoutedEventArgs e)
        {
            QLBanHang f = new QLBanHang(TENDN);
            f.Show();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Close();

        }


        //    private void ThanhToan_Click(object sender, RoutedEventArgs e)
        //    {
        //        QLBanHang f = new QLBanHang();
        //        f.Show();
        //        QLChoNV ql = new QLChoNV();
        //        DangNhap dn = new DangNhap();
        //        QLChoNV.GetWindow(dn);
        //        dn.ShowDialog();
        //        QLBanHang f = new QLBanHang();
        //        f.Show();

        //    }

        //    private void ThongKe_Click(object sender, RoutedEventArgs e)
        //    {

        //    }

        //    private void QuanLySanPham_Click(object sender, RoutedEventArgs e)
        //    {
        //        QLSanPham f = new QLSanPham();
        //        this.Hide();
        //        f.ShowDialog();
        //        this.Show();
        //        sender("Chào nhân viên");
        //        f.Show();
        //        QLChoNV ql = new QLChoNV();
        //        // QLSanPham sp = new QLSanPham();
        //        // ql.GetValue(sp);
        //        var tam = Window.GetWindow(sp);
        //        Panel panel = new Panel();
        //        UserControl sp = new UserControl();


        //    }

        //    private void QLKhachHang_Click(object sender, RoutedEventArgs e)
        //    {
        //        QLKhachHang f = new QLKhachHang();
        //        f.Show();
        //    }

        //    private void btnHome_Click(object sender, RoutedEventArgs e)
        //    {
        //        DangNhap dn = new DangNhap();
        //        dn.Show();
        //        this.Close();
        //    }

        //    private void Button_Click(object sender, RoutedEventArgs e)
        //    {

        //    }

        //    private void Button_Click_1(object sender, RoutedEventArgs e)
        //    {

        //    }

        //    private void Button_Click_2(object sender, RoutedEventArgs e)
        //    {

        //    }
        //}

    }
    }
