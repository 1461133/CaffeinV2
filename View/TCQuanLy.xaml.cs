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
    /// Interaction logic for TCQuanLy.xaml
    /// </summary>
    public partial class TCQuanLy : Window
    {
        public string TENDN;
        public TCQuanLy(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
        }
        private void QuanLyKho_Click(object sender, RoutedEventArgs e)
        {
            QLSanPham f = new QLSanPham(TENDN);
            f.Show();
            this.Close();
        }
        private void ThongKe_Click(object sender, RoutedEventArgs e)
        {
            ThongKe f = new ThongKe(TENDN);
            f.Show();
            this.Close();

        }

        private void ThanhToan_Click(object sender, RoutedEventArgs e)
        {
            QLBanHang f = new QLBanHang(TENDN);
            f.Show();
            this.Close();
        }

        private void QuanLyNhanVien_Click(object sender, RoutedEventArgs e)
        {
            QLNhanVien f = new QLNhanVien(TENDN);
            f.Show();
            this.Close();
        }

        private void QuanLyKhachHang_Click(object sender, RoutedEventArgs e)
        {
            QLKhachHang f = new QLKhachHang(TENDN);
            f.Show();
            this.Close();
        }

        private void QuanLyHoaDonNhap_Click(object sender, RoutedEventArgs e)
        {
            QLNhapHang f = new QLNhapHang(TENDN);
            f.Show();
            this.Close();
        }

        

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void btnQLHoaDonBanNhap_Click(object sender, RoutedEventArgs e)
        {
            QLHoaDon qlhd = new QLHoaDon(TENDN);
            qlhd.Show();
            this.Close();
        }
    }
}
