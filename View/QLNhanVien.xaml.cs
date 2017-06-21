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
using Model;
namespace View
{
    /// <summary>
    /// Interaction logic for QLNhanVien.xaml
    /// </summary>
    public partial class QLNhanVien : Window
    {
        NhanVien nv = new NhanVien();
        public QLNhanVien()
        {
            InitializeComponent();
            dataGrid.DataContext = nv.LayAllNV();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnThem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtCMND.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (txtID.Text.Substring(0, 2) != "KH")
                {
                    MessageBox.Show("Nhập sai mã khách hàng!!! Vui lòng nhập lại. Mã bắt đầu = KH");
                    return;
                }
                string tam = txtID.Text.Substring(2);
                int tam1;
                if (int.TryParse(tam, out tam1) == false)
                {
                    MessageBox.Show("Nhập sai mã khách hàng!!! Vui lòng nhập lại, phần sau mã KH là số");
                    return;
                }

                DateTime ngaysinh;
                if (DateTime.TryParse(txtNgSinh.Text, out ngaysinh) == false)
                {
                    MessageBox.Show("Nhập sai ngày sinh!!! Vui lòng nhập lại.");
                    return;
                }
                if (DateTime.Parse(txtNgSinh.Text) > DateTime.Now)
                {
                    MessageBox.Show("Nhập sai ngày sinh!!! Vui lòng nhập lại.");
                    return;
                }
                string mess = nv.ThemNhanVien(txtID.Text, txtTenNV.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text, cmbLoaiNV.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = nv.LayAllNV();
            }
        }

        private void btnSua_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = nv.SuaNhanVien(txtID.Text, txtTenNV.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text, cmbLoaiNV.Text);
                MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = nv.LayAllNV();
            }

        }

        private void btnXoa_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = nv.XoaNhanVien(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = nv.LayAllNV();
            }

        }
    }
}
