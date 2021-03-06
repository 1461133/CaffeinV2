﻿using System;
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
    /// Interaction logic for QLBanHangNV.xaml
    /// </summary>
    public partial class QLBanHangNV : Window
    {
        SanPham sp = new SanPham();
        public string TENDN;
        public QLBanHangNV(string tendn)
        {
            InitializeComponent();
            txtIDKH.Text = "KH000";
            txtCMNDKH.Text = "000";
            txtTenKH.Text = "Anonymous";
            TENDN = tendn;
            lbSanPham.DataContext = sp.LayAllSP();
            CTHDB cthdb = new CTHDB();
            // dataGrid.DataContext = cthdb.LayViewCTHDN(txtIDHD.Text);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtIDKH.Text = "KH000";
            txtCMNDKH.Text = "000";
            txtTenKH.Text = "Anonymous";
            txtIDNV.Text = "";
            txtIDHD.Text = "";
            txtTongTien.Text = "";
            dataGrid.DataContext = null;
        }

        private void btnXoaSp_Click(object sender, RoutedEventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            if (string.IsNullOrEmpty(txtIDHD.Text) || lbSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdb.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    CTHDB cthdb = new CTHDB();
                    string mess = cthdb.XoaSanPham(txtIDHD.Text, lbSanPham.SelectedItem);
                    MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    //dataGrid.DataContext = cthdb.LayViewCTHDN(txtIDHD.Text);
                    lbSanPham.DataContext = sp.LayAllSP();
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnSuaSp_Click(object sender, RoutedEventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            if (string.IsNullOrEmpty(txtIDHD.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || lbSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdb.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    int sl = 1;
                    if (int.TryParse(txtSoLuong.Text, out sl) == false)
                    {
                        txtSoLuong.Text = "1";
                    }
                    CTHDB cthdb = new CTHDB();
                    string mess = cthdb.SuaSanPham(txtIDHD.Text, lbSanPham.SelectedItem, int.Parse(txtSoLuong.Text));
                    MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    //dataGrid.DataContext = cthdb.LayViewCTHDN(txtIDHD.Text);
                    lbSanPham.DataContext = sp.LayAllSP();
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnThemSp_Click(object sender, RoutedEventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            if (string.IsNullOrEmpty(txtIDHD.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || lbSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdb.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    int sl = 1;
                    if (int.TryParse(txtSoLuong.Text, out sl) == false)
                    {
                        txtSoLuong.Text = "1";
                    }
                    CTHDB cthdb = new CTHDB();
                    string mess = cthdb.ThemSanPham(txtIDHD.Text, lbSanPham.SelectedItem, int.Parse(txtSoLuong.Text));
                    //dataGrid.DataContext = cthdb.LayViewCTHDN(txtIDHD.Text);
                    MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    lbSanPham.DataContext = sp.LayAllSP();
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnSearchHD_Click(object sender, RoutedEventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            if (string.IsNullOrEmpty(txtIDHD.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdb.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    CTHDB cthdb = new CTHDB();
                    MessageBox.Show("Đã tìm thấy", "Tộc phèo caffein vui vẻ nói: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dataGrid.DataContext = cthdb.LayViewCTHDB(txtIDHD.Text);
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                    var hdb1 = hdb.LayHDB(txtIDHD.Text);
                    txtIDKH.Text = hdb1.makh;
                    txtIDNV.Text = hdb1.manv;
                }
            }
        }

        private void btnLapHD_Click(object sender, RoutedEventArgs e)
        {
            int ngay = DateTime.Now.Day;
            string ngay1 = ngay.ToString();
            if (ngay < 10)
            {
                ngay1 = "0" + ngay.ToString();
            }
            int thang = DateTime.Now.Month;
            string thang1 = thang.ToString();
            if (thang < 10)
            {
                thang1 = "0" + thang1.ToString();
            }
            string tam = DateTime.Now.TimeOfDay.ToString();
            string times = tam.Substring(0, 8);
            string fn = ngay1 + thang1;
            fn = fn + tam.Substring(0, 2) + tam.Substring(3, 2) + tam.Substring(6, 2);
            KhachHang kh = new KhachHang();
            NhanVien nv = new NhanVien();

            if (string.IsNullOrEmpty(txtIDKH.Text) || string.IsNullOrEmpty(txtIDNV.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (nv.KTNhanVien(txtIDNV.Text) == false)
                {
                    MessageBox.Show("Sai mã nhân viên rồi -_-");
                    return;
                }
                if (kh.KTKhachHang(txtIDKH.Text) == false)
                {
                    MessageBox.Show("Sai mã khách hàng rồi -_-");
                    return;
                }
                HoaDonBan hdb = new HoaDonBan();
                string mess = hdb.ThemHoaDon(fn, txtIDNV.Text, txtIDKH.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (mess == "Đã có thêm thức uống mới rồi ^^")
                {
                    txtIDHD.Text = fn;
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnDKKh_Click(object sender, RoutedEventArgs e)
        {
            QLKhachHang kh = new QLKhachHang(TENDN);
            kh.ShowDialog();
        }

        private void btnCheckKH_Click(object sender, RoutedEventArgs e)
        {
            KhachHang kh = new KhachHang();
            var kh1 = kh.LayKH(txtIDKH.Text, txtCMNDKH.Text, "");
            if (kh1 != null)
            {
                txtTenKH.Text = kh1.tenkh;
                txtCMNDKH.Text = kh1.cmnd;
                txtIDKH.Text = kh1.makh;
            }
            else
            {
                MessageBox.Show("Không có khách hàng này!!! Có thể đăng ký hoặc chọn mã KH000 dành cho khách hàng không đăng ký");
                txtIDKH.Text = "KH000";
                txtCMNDKH.Text = "000";
                txtTenKH.Text = "Anonymous";
            }
        }

        private void btnTQL_Click(object sender, RoutedEventArgs e)
        {
            TCNhanVien tc = new TCNhanVien(TENDN);
            tc.Show();
            Close();
        }
    }
}
