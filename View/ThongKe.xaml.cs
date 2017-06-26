using CrystalDecisions.CrystalReports.Engine;
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
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        public string TENDN;
        public ThongKe(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
        }

        private void reportKH_Click(object sender, RoutedEventArgs e)
        {
            RpViewKhachHang rp = new RpViewKhachHang(TENDN);
            rp.Show();
            this.Close();
        }

        private void reportHDB_Click(object sender, RoutedEventArgs e)
        {
            RpHoaDonBan rp = new RpHoaDonBan(TENDN);
            rp.Show();
            this.Close();

        }

        private void reportHDN_Click(object sender, RoutedEventArgs e)
        {
            RpHoaDonNhap rp = new RpHoaDonNhap(TENDN);
            rp.Show();
            this.Close();

        }

        private void reportSP_Click(object sender, RoutedEventArgs e)
        {
            RpSanPham rp = new RpSanPham(TENDN);
            rp.Show();
            this.Close();

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Close();
        }
    }
}
