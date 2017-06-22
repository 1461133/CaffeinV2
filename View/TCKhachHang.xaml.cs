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
    /// Interaction logic for TCKhachHang.xaml
    /// </summary>
    public partial class TCKhachHang : Window
    {
        public string TENDN;
        public TCKhachHang(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
        }
        private void TKSanPham_Click(object sender, RoutedEventArgs e)
        {
            TKSanPham f = new TKSanPham();
            f.Show();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }
    }
}
