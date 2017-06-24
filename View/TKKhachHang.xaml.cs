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
using ViewModel;
namespace View
{
    /// <summary>
    /// Interaction logic for TKKhachHang.xaml
    /// </summary>
    public partial class TKKhachHang : Window
    {
        public TKKhachHang()
        {
            KhachHang kh = new KhachHang();
            InitializeComponent();
            dataGrid.DataContext = kh.LayViewKH();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void btnSearch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtHT.Text) && string.IsNullOrEmpty(txtCMND.Text) && string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ! Để tìm kiếm vui lòng nhập một trong thông tin: mã, tên, CMND, SDT!!!");
                return;
            }
            KhachHang kh = new KhachHang();

            var dskh = kh.TKKhachHang(txtID.Text, txtHT.Text, txtCMND.Text, txtSDT.Text);
            if (dskh.Count() == 0)
            {
                MessageBox.Show("Không có khách hàng này!!!");
            }
            else
            {
                dataGrid.DataContext = dskh;
            }
        }
    }
}
