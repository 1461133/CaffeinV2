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
    /// Interaction logic for QLThongTinNhanVien.xaml
    /// </summary>
    public partial class QLThongTinNhanVien : Window
    {
        public string TENDN;

        public QLThongTinNhanVien()
        {
            InitializeComponent();
        }
        public QLThongTinNhanVien(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
            txtIDNV.Text = TENDN;
            HoaDonBan hdb = new HoaDonBan();
            dgvDSHDBan.DataContext = hdb.LayHDBan_NV(txtIDNV.Text);
            HoaDonNhap hdn = new HoaDonNhap();
            dgvDSHDNhap.DataContext = hdn.LayHDNhap_NV(txtIDNV.Text);
        }

        private void btnCapNhatThongTinNV_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text != "")
            {
                TaiKhoan tk = new TaiKhoan();
                int mess = tk.SuaTaiKhoan(txtIDNV.Text, txtPass.Text);
                if (mess == 1)
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

        private void txtIDNV_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtIDNV.Text != "")
            {
                NhanVien nv = new NhanVien();
                var nv1 = nv.LayNV(txtIDNV.Text);
                if (nv1 != null)
                {
                    txtIDNV.Text = nv1.manv;
                    txtTenNV.Text = nv1.tennv;
                    txtCMNDNV.Text = nv1.cmnd;
                    txtDiaChi.Text = nv1.diachi;
                    txtGioiTinh.Text = nv1.gioitinh;
                    txtNgSinh.Text = nv1.ngaysinh.Value.Date.ToString("dd/MM/yyyy");
                    txtSDT.Text = nv1.sdt;
                }
            }
        }

        private void btnTQL_Click(object sender, RoutedEventArgs e)
        {
            TCNhanVien tc = new TCNhanVien(TENDN);
            tc.Show();
            this.Close();
        }
    }
}
