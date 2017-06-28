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
            label.Content = "Xin chaøo, "+tendn;
            TENDN = tendn;
        }
        
        private void QuanLySanPham_Click(object sender, RoutedEventArgs e)
        {
            QLSanPhamNV f = new QLSanPhamNV(TENDN);
            f.Show();
            this.Close();
        }

        private void QuanLyKhachHang_Click(object sender, RoutedEventArgs e)
        {
            QLKhachHangNV f = new QLKhachHangNV(TENDN);
            f.Show();
            this.Close();
        }

        
        private void ThanhToan_Click(object sender, RoutedEventArgs e)
        {
            QLBanHang f = new QLBanHang(TENDN);
            f.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Close();

        }

        private void QLThongTinNhanVien_Click(object sender, RoutedEventArgs e)
        {
            QLThongTinNhanVien ttnv = new QLThongTinNhanVien(TENDN);
            ttnv.Show();
            this.Close();
        }



        }
    }
