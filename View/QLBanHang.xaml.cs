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
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;
using System.Collections;
using System.Windows.Controls.Primitives;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace View
{
    /// <summary>
    /// Interaction logic for QLBanHang.xaml
    /// </summary>
    public partial class QLBanHang : Window
    {
        public string TENDN;
        SanPham sp = new SanPham();
        public QLBanHang()
        {
            InitializeComponent();
            txtIDKH.Text = "KH000";
            txtCMNDKH.Text = "000";
            txtTenKH.Text = "Anonymous";
            LoaiSP lsp = new LoaiSP();
            cmbLoaiSP.DataContext = lsp.LayAllLoaiSP();
            lbSanPham.DataContext = sp.LayAllSP();
            CTHDB cthdb = new CTHDB();
            dataGrid.DataContext = cthdb.LayViewCTHDB(txtIDHD.Text);
        }
        public QLBanHang(string tendn)
        {
            InitializeComponent();
            txtIDKH.Text = "KH000";
            txtCMNDKH.Text = "000";
            txtTenKH.Text = "Anonymous";
            LoaiSP lsp = new LoaiSP();
            cmbLoaiSP.DataContext = lsp.LayAllLoaiSP();
            TENDN = tendn;
            txtIDNV.Text = TENDN;
            lbSanPham.DataContext = sp.LayAllSP();
            CTHDB cthdb = new CTHDB();
            dataGrid.DataContext = cthdb.LayViewCTHDB(txtIDHD.Text);

        }

        private void btnCheckKH_Click(object sender, RoutedEventArgs e)
        {
            KhachHang kh = new KhachHang();
            var kh1 = kh.LayKH(txtIDKH.Text,txtCMNDKH.Text,"");
            if(kh1 != null)
            {
                txtTenKH.Text = kh1.tenkh;
                txtCMNDKH.Text = kh1.cmnd;
                txtIDKH.Text = kh1.makh;
                txtIDKH.IsReadOnly = true;
                txtCMNDKH.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("Không có khách hàng này!!! Có thể đăng ký hoặc chọn mã KH000 dành cho khách hàng không đăng ký");
                txtIDKH.Text = "KH000";
                txtCMNDKH.Text = "000";
                txtTenKH.Text = "Anonymous";
            }
        }

        //private void btnDKKh_Click(object sender, RoutedEventArgs e)
        //{
        //    QLKhachHangNV kh = new QLKhachHangNV(TENDN);
        //    kh.ShowDialog();
        //}

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
                if (nv.KTNhanVienTT(txtIDNV.Text) == false)
                {
                    MessageBox.Show("Sai mã nhân viên rồi -_-");
                    return;
                }
                if (kh.KTKhachHangTT(txtIDKH.Text) == false)
                {
                    MessageBox.Show("Sai mã khách hàng rồi -_-");
                    return;
                }
                HoaDonBan hdb = new HoaDonBan();
                string mess = hdb.ThemHoaDon(fn, txtIDNV.Text, txtIDKH.Text);
               
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if(mess== "Đã có thêm hóa đơn bán mới rồi ^^")
                {
                    txtIDHD.Text = fn;
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                    txtIDKH.IsReadOnly = true;
                    txtCMNDKH.IsReadOnly = true;
                    txtIDNV.IsReadOnly = true;
                    txtIDHD.IsReadOnly = true;
                }
            } 
        }

        private void btnThemSp_Click(object sender, RoutedEventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            if (string.IsNullOrEmpty(txtIDHD.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || lbSanPham.SelectedIndex==-1)
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
                    if(int.TryParse(txtSoLuong.Text,out sl) == false)
                    {
                        MessageBox.Show("Nhập sai số lượng rồi -_-");
                        return;
                    }
                    if(int.Parse(txtSoLuong.Text) == 0)
                    {
                        MessageBox.Show("Không được nhập là 0 -_-");
                        return;
                    }
                    CTHDB cthdb = new CTHDB();
                    string mess = cthdb.ThemSanPham(txtIDHD.Text, lbSanPham.SelectedItem, int.Parse(txtSoLuong.Text));
                    dataGrid.DataContext = cthdb.LayViewCTHDB(txtIDHD.Text);
                    MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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
                        MessageBox.Show("Nhập sai số lượng rồi -_-");
                        return;
                    }
                    if (int.Parse(txtSoLuong.Text) == 0)
                    {
                        MessageBox.Show("Không được nhập là 0 -_-");
                        return;
                    }
                    CTHDB cthdb = new CTHDB();
                    string mess = cthdb.SuaSanPham(txtIDHD.Text, lbSanPham.SelectedItem, int.Parse(txtSoLuong.Text));
                    MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dataGrid.DataContext = cthdb.LayViewCTHDB(txtIDHD.Text);
                    lbSanPham.DataContext = sp.LayAllSP();
                    txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
                }
            }
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
                    dataGrid.DataContext = cthdb.LayViewCTHDB(txtIDHD.Text);
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
                    var kh = new KhachHang();
                    var kh1 = kh.LayKH(hdb1.makh, "", "");
                    txtTenKH.Text = kh1.tenkh;
                    txtCMNDKH.Text = kh1.cmnd;
                    txtIDNV.Text = hdb1.manv;
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtIDKH.Text = "KH000";
            txtCMNDKH.Text = "000";
            txtTenKH.Text = "Anonymous";
            txtIDHD.Text = "";
            txtTongTien.Text = "";
            txtIDKH.IsReadOnly = false;
            txtCMNDKH.IsReadOnly = false;
            dataGrid.DataContext = null;
            cmbLoaiSP.SelectedIndex = -1;
            //lbSanPham.DataContext = sp.LayAllSP();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Close();
        }

        private void cmbLoaiSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbLoaiSP.SelectedIndex == -1)
            {
                lbSanPham.DataContext = sp.LayAllSP();
            }
            else
            {
                SanPham sp = new SanPham();
                lbSanPham.DataContext = sp.LaySPTheoLoai(cmbLoaiSP.SelectedItem);
            }
            
        }

        private void btnInHD_Click(object sender, RoutedEventArgs e)
        {

            RpInHD inhd = new RpInHD(txtIDHD.Text);
            inhd.Show();

            //try
            //{
            //    Excel.Application excel = new Excel.Application();
            //    excel.Visible = true;
            //    Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            //    Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            //    for (int i = 0; i < dataGrid.Columns.Count; i++)
            //    {
            //        for (int j = 0; j < dataGrid.Items.Count; j++)
            //        {
            //            TextBlock b = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
            //            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
            //            myRange.Value2 = b.Text;
            //        }
            //    }
            //    MessageBox.Show("Đã xác nhận in hóa đơn", "Tộc phèo caffein vui vẻ thông báo: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            //}
            //catch
            //{
            //    MessageBox.Show("Đã xác nhận in hó", "Tộc phèo caffein ngu ngơ lèm: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //}
        }
        private void btnTQL_Click(object sender, RoutedEventArgs e)
        {
            TCNhanVien tc = new TCNhanVien(TENDN);
            tc.Show();
            this.Close();
        }
    }
}
