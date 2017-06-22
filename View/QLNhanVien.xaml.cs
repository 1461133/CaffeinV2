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
        TaiKhoan tk = new TaiKhoan();

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
                string mess = nv.ThemNhanVien(txtID.Text, txtTenNV.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text, "Nhân viên bán hàng");
                int mess1 = tk.ThemTaiKhoan(txtID.Text, txtCMND.Text);
                if (mess1 == 1)
                {
                    MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Chưa thêm được, buồn quá đi TT.TT", "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
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
                string mess = nv.SuaNhanVien(txtID.Text, txtTenNV.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text, "Nhân viên bán hàng");
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
                int mess1 = tk.XoaTaiKhoan(txtID.Text);
                if (mess1 == 1)
                {
                    MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Chưa xóa được, buồn quá đi TT.TT", "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                dataGrid.DataContext = nv.LayAllNV();
            }

        }
        private void btnnext_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            int totalPage;
            if (db.TotalPage != 0)
            {
                if (db.CurPage < db.TotalPage)
                {
                    //db.CurPage = db.CurPage + 1;
                    //if (cmbdskh.SelectedIndex == 0)
                    //{
                    //    db.ViewKhachHang = kh.LayViewKH(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHang;
                    //}
                    //if (cmbdskh.SelectedIndex == 1)
                    //{
                    //    db.ViewKhachHangXoa = kh.LayViewKHXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangXoa;
                    //}
                    //if (cmbdskh.SelectedIndex == 2)
                    //{
                    //    db.ViewKhachHangAll = kh.LayViewKHAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangAll;
                    //}
                }
                else
                {
                    MessageBox.Show("Đã là trang cuối!");
                }
            }
            else
            {
                MessageBox.Show("Không có trang để thay đổi!");
            }
        }

        private void btnlast_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            int totalPage;
            if (db.TotalPage != 0)
            {
                if (db.CurPage < db.TotalPage)
                {
                    //db.CurPage = db.TotalPage;
                    //if (cmbdskh.SelectedIndex == 0)
                    //{
                    //    db.ViewKhachHang = kh.LayViewKH(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHang;
                    //}
                    //if (cmbdskh.SelectedIndex == 1)
                    //{
                    //    db.ViewKhachHangXoa = kh.LayViewKHXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangXoa;
                    //}
                    //if (cmbdskh.SelectedIndex == 2)
                    //{
                    //    db.ViewKhachHangAll = kh.LayViewKHAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangAll;
                    //}
                }
                else
                {
                    MessageBox.Show("Đã là trang cuối!");
                }
            }
            else
            {
                MessageBox.Show("Không có trang để thay đổi!");
            }
        }

        private void btnpre_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            int totalPage;
            if (db.TotalPage != 0)
            {
                if (db.CurPage > 1)
                {
                    //db.CurPage = db.CurPage - 1;
                    //if (cmbdskh.SelectedIndex == 0)
                    //{
                    //    db.ViewKhachHang = kh.LayViewKH(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHang;
                    //}
                    //if (cmbdskh.SelectedIndex == 1)
                    //{
                    //    db.ViewKhachHangXoa = kh.LayViewKHXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangXoa;
                    //}
                    //if (cmbdskh.SelectedIndex == 2)
                    //{
                    //    db.ViewKhachHangAll = kh.LayViewKHAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangAll;
                    //}
                }
                else
                {
                    MessageBox.Show("Đã là trang đầu!");
                }
            }
            else
            {
                MessageBox.Show("Không có trang để thay đổi!");
            }
        }

        private void btnfirst_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            int totalPage;
            if (db.TotalPage != 0)
            {
                if (db.CurPage > 1)
                {
                    db.CurPage = 1;
                    //if (cmbdskh.SelectedIndex == 0)
                    //{
                    //    db.ViewKhachHang = kh.LayViewKH(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHang;
                    //}
                    //if (cmbdskh.SelectedIndex == 1)
                    //{
                    //    db.ViewKhachHangXoa = kh.LayViewKHXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangXoa;
                    //}
                    //if (cmbdskh.SelectedIndex == 2)
                    //{
                    //    db.ViewKhachHangAll = kh.LayViewKHAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                    //    dataGrid.DataContext = db.ViewKhachHangAll;
                    //}
                }
                else
                {
                    MessageBox.Show("Đã là trang đầu!");
                }
            }
            else
            {
                MessageBox.Show("Không có trang để thay đổi!");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.CurPage = 1;
            //cmbdskh.SelectedIndex = 0;
            //dataGrid.DataContext = kh.LayViewKH();
            int totalPage ;
            //db.ViewKhachHang = kh.LayViewKH(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewKhachHang;
            //db.TotalPage = totalPage;
            txtID.Text = "";
            txtNgSinh.Text = "";
            txtSDT.Text = "";
            //txtHT.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            cmbGT.SelectedIndex = -1;
        }

        private void btnPhucHoi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = nv.PhucHoiNhanVien(txtID.Text);
                int mess1 = tk.PhucHoiTaiKhoan(txtID.Text);
                if (mess1 == 1)
                {
                    MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Chưa phục hồi được, buồn quá đi TT.TT", "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
               
                int totalPage;
                //db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = nv.LayAllNV();
                //db.TotalPage = totalPage;
            }
        }
    }
}
