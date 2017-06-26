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
    /// Interaction logic for QLThongTinKhachHang.xaml
    /// </summary>
    public partial class QLThongTinKhachHang : Window
    {
        public string TENDN;
        public QLThongTinKhachHang()
        {
            InitializeComponent();
        }
        public QLThongTinKhachHang(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
            txtIDKH.Text = TENDN;
            HoaDonBan hdb = new HoaDonBan();
            dgvDSMua.DataContext = hdb.LayHDB_CTHDB_KH(txtIDKH.Text);
        }

        private void btnCapNhatThongTinKH_Click(object sender, RoutedEventArgs e)
        {
            if(txtPass.Text!="")
            {
                TaiKhoan tk = new TaiKhoan();
                int mess = tk.SuaTaiKhoan(txtIDKH.Text, txtPass.Text);
                if(mess == 1 )
                {
                    MessageBox.Show("Mật khẩu đã được cập nhật!!", "Tộc phèo caffein vui mừng thông báo: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thông tin không được cập nhật ~.~", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin cập nhật ~.~", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void txtIDKH_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtIDKH.Text != "")
            {
                KhachHang kh = new KhachHang();
                var kh1 = kh.LayKH(txtIDKH.Text);
                if (kh1 != null)
                {
                    txtIDKH.Text = kh1.makh;
                    txtTenKH.Text = kh1.tenkh;
                    txtCMNDKH.Text = kh1.cmnd;
                    txtDiaChi.Text = kh1.diachi;
                    txtGioiTinh.Text = kh1.gioitinh;
                    txtNgSinh.Text = kh1.ngaysinh.Value.Date.ToString("dd/MM/yyyy");
                    txtSDT.Text = kh1.sdt;
                }
            }
        }

        private void btnTQL_Click(object sender, RoutedEventArgs e)
        {
            TCKhachHang tc = new TCKhachHang(TENDN);
            tc.Show();
            this.Close();
        }
    }
}
