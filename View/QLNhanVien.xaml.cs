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
        public string TENDN;
        public QLNhanVien()
        {
            InitializeComponent();
            //dataGrid.DataContext = nv.LayAllNV();
            cmbdsnv.SelectedIndex = 0;
            btnpre.Content = "<";
            btnfirst.Content = "<<";
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.CurPage = 1;
            int totalPage;
            db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewNhanVien;
            db.TotalPage = totalPage;
        }
        public QLNhanVien(string tendn)
        {
            InitializeComponent();
            //dataGrid.DataContext = nv.LayAllNV();
            TENDN = tendn;
            cmbdsnv.SelectedIndex = 0;
            btnpre.Content = "<";
            btnfirst.Content = "<<";
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.CurPage = 1;
            int totalPage;
            db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewNhanVien;
            db.TotalPage = totalPage;
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
                try
                {
                    if (txtID.Text.Substring(0, 2) != "NV")
                    {
                        MessageBox.Show("Nhập sai mã nhân viên!!! Vui lòng nhập lại. Mã bắt đầu = NV");
                        return;
                    }
                    string tam = txtID.Text.Substring(2);
                    int tam1;
                    if (int.TryParse(tam, out tam1) == false)
                    {
                        MessageBox.Show("Nhập sai mã nhân viên!!! Vui lòng nhập lại, phần sau mã NV là số");
                        return;
                    }
                    long sdt;
                    if (long.TryParse(txtSDT.Text, out sdt) == false)
                    {
                        MessageBox.Show("Nhập sai số điện thoại!!! Vui lòng nhập lại.");
                        return;
                    }
                    if (long.TryParse(txtCMND.Text, out sdt) == false)
                    {
                        MessageBox.Show("Nhập sai CMND!!! Vui lòng nhập lại.");
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
                        MessageBox.Show("Chưa thêm được, buồn quá đi TT.TT", "Tộc phèo caffein buồn bã thông báo: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                catch
                {
                    MessageBox.Show("Chưa thêm được, buồn quá đi TT.TT", "Tộc phèo caffein buồn bã thông báo: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                cmbdsnv.SelectedIndex = 0;
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                int totalPage;
                db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVien;
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
                try
                {
                    if (txtID.Text == "NV000")
                    {
                        MessageBox.Show("Không được phép sửa nhân viên này", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (txtCMND.Text != "")
                    {
                        long cmnd;
                        if (long.TryParse(txtCMND.Text, out cmnd) == false)
                        {
                            MessageBox.Show("Nhập sai CMND!!! Vui lòng nhập lại.");
                            return;
                        }
                    }
                    if (txtSDT.Text != "")
                    {
                        long sdt;
                        if (long.TryParse(txtSDT.Text, out sdt) == false)
                        {
                            MessageBox.Show("Nhập sai số điện thoại!!! Vui lòng nhập lại.");
                            return;
                        }
                    }
                    if (txtNgSinh.Text != "")
                    {
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
                    }

                    string mess = nv.SuaNhanVien(txtID.Text, txtTenNV.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text, "Nhân viên bán hàng ");
                    MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Chưa thêm được, buồn quá đi TT.TT", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                cmbdsnv.SelectedIndex = 0;
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                int totalPage;
                db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVien;
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
                try
                {
                    if (txtID.Text == "NV000")
                    {
                        MessageBox.Show("Không được phép sửa nhân viên này", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
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
                }
                catch
                {
                    MessageBox.Show("Chưa xóa được, buồn quá đi TT.TT", "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                cmbdsnv.SelectedIndex = 1;
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                int totalPage;
                db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVienXoa;
            }

        }
        private void Search_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NhanVien nv = new NhanVien();
            dataGrid.DataContext = null;
            cmbdsnv.SelectedIndex = 2;
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            int totalPage;
            db.CurPage = 1;

            var dsnv =nv.TKNhanVien(txtID.Text,txtTenNV.Text, txtCMND.Text, txtSDT.Text);
            if (dsnv.Count() == 0)
            {
                MessageBox.Show("Không có khách hàng này!!!");
            }
            else
            {
                if(dsnv.Count() == 1)
                {
                    foreach (var item in dsnv)
                    {
                        NhanVien nv1 = new NhanVien();
                        if (nv1.KTNhanVienTT(item.manv) == true)
                            cmbdsnv.SelectedIndex = 0;
                        else
                        {
                            cmbdsnv.SelectedIndex = 1;
                        }
                    }
                    dataGrid.DataContext = dsnv;
                }
                else
                {
                    dataGrid.DataContext = dsnv;
                }
                db.TotalPage = 1;
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
                    db.CurPage = db.CurPage + 1;
                    if (cmbdsnv.SelectedIndex == 0)
                    {
                        db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVien;
                    }
                    if (cmbdsnv.SelectedIndex == 1)
                    {
                        db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienXoa;
                    }
                    if (cmbdsnv.SelectedIndex == 2)
                    {
                        db.ViewNhanVienAll = nv.LayViewNVAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienAll;
                    }
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
                    db.CurPage = db.TotalPage;
                    if (cmbdsnv.SelectedIndex == 0)
                    {
                        db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVien;
                    }
                    if (cmbdsnv.SelectedIndex == 1)
                    {
                        db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienXoa;
                    }
                    if (cmbdsnv.SelectedIndex == 2)
                    {
                        db.ViewNhanVienAll = nv.LayViewNVAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienAll;
                    }
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
                    db.CurPage = db.CurPage - 1;
                    if (cmbdsnv.SelectedIndex == 0)
                    {
                        db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVien;
                    }
                    if (cmbdsnv.SelectedIndex == 1)
                    {
                        db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienXoa;
                    }
                    if (cmbdsnv.SelectedIndex == 2)
                    {
                        db.ViewNhanVienAll = nv.LayViewNVAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienAll;
                    }
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
                    if (cmbdsnv.SelectedIndex == 0)
                    {
                        db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVien;
                    }
                    if (cmbdsnv.SelectedIndex == 1)
                    {
                        db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienXoa;
                    }
                    if (cmbdsnv.SelectedIndex == 2)
                    {
                        db.ViewNhanVienAll = nv.LayViewNVAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewNhanVienAll;
                    }
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
            cmbdsnv.SelectedIndex = 0;
            int totalPage;
            db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewNhanVien;
            db.TotalPage = totalPage;
            txtID.Text = "";
            txtNgSinh.Text = "";
            txtSDT.Text = "";
            txtTenNV.Text = "";
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
                cmbdsnv.SelectedIndex = 1;
                db.CurPage = 1;
               
                int totalPage;
                db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVienXoa;
                db.TotalPage = totalPage;
            }
        }

        private void cmbdsnv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbdsnv.SelectedIndex == 0)
            {
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdsnv.SelectedIndex = 0;
                //dataGrid.DataContext = kh.LayViewKH();
                int totalPage;
                db.ViewNhanVien = nv.LayViewNV(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVien;
                db.TotalPage = totalPage;
            }
            if (cmbdsnv.SelectedIndex == 1)
            {
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdsnv.SelectedIndex = 1;
                int totalPage;
                db.ViewNhanVienXoa = nv.LayViewNVXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVienXoa;
                db.TotalPage = totalPage;
            }
            if (cmbdsnv.SelectedIndex == 2)
            {
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdsnv.SelectedIndex = 2;
                int totalPage;
                db.ViewNhanVienAll = nv.LayViewNVAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewNhanVienAll;
                db.TotalPage = totalPage;
            }
        }

       
    }
}
