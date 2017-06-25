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
    /// Interaction logic for QLKhachHangNV.xaml
    /// </summary>
    public partial class QLKhachHangNV : Window
    {
        public string TENDN;
        public QLKhachHangNV()
        {
            InitializeComponent();

        }
        public QLKhachHangNV(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
        }

        private void btnQL_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TCNhanVien tc = new TCNhanVien(TENDN);
            tc.Show();
            this.Close();
        }

        private void btnHome_MouseUp(object sender, MouseButtonEventArgs e)
        {

            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }
    }
}
