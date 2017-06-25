using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

namespace View
{
    /// <summary>
    /// Interaction logic for QLNhapHang.xaml
    /// </summary>
    public partial class QLNhapHang : Window
    {
        public string TENDN;
        NhaCC ncc = new NhaCC();
        public QLNhapHang()
        {
            InitializeComponent();
            cmbNCC.DataContext = ncc.LayNCC();
        }
        public QLNhapHang(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
            cmbNCC.DataContext = ncc.LayNCC();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThemNCC_Click(object sender, RoutedEventArgs e)
        {
            QLNhaCC qlncc = new QLNhaCC();
            qlncc.Show();
            this.Close();
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
            
            NhanVien nv = new NhanVien();

            if (string.IsNullOrEmpty(txtIDNV.Text))
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
                //HoaDonBan hdb = new HoaDonBan();
                //string mess = hdb.ThemHoaDon(fn, txtIDNV.Text, txtIDKH.Text);
                //txtIDHD.Text = fn;
                HoaDonNhap hdn = new HoaDonNhap();
                string mess = hdn.ThemHoaDon(fn, txtIDNV.Text);
               MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (mess == "Đã có thêm hóa đơn nhập mới rồi ^^ ") ;
                {
                    txtIDHD.Text = fn;
                    txtTongTien.Text = hdn.LayTongTien(fn).ToString();
                }
               
            }
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap();
            if (string.IsNullOrEmpty(txtIDHD.Text) || string.IsNullOrEmpty(txtTenSP.Text) ||string.IsNullOrEmpty(txtSoLuong.Text) || cmbNCC.SelectedIndex == -1 || string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdn.KTHoaDon(txtIDHD.Text) == false)
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
                    float gia = 0;
                    if (float.TryParse(txtGia.Text, out gia) == false)
                    {
                        MessageBox.Show("Nhập sai đơn giá rồi -_-");
                        return;
                    }
                    if(int.Parse(txtSoLuong.Text) == 0)
                    {
                        MessageBox.Show("Không được nhập số lượng bằng 0 -_-");
                        return;
                    }
                    if(float.Parse(txtGia.Text) == 0)
                    {
                        MessageBox.Show("Không được nhập giá bằng 0 -_-");
                        return;
                    }
                    CTHDN cthdn = new CTHDN();
                    string mess = cthdn.ThemSanPham(txtIDHD.Text, txtTenSP.Text, int.Parse(txtSoLuong.Text), float.Parse(txtGia.Text), cmbNCC.SelectedItem);
                    dataGrid.DataContext = cthdn.LayViewCTHDN(txtIDHD.Text);
                    MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    txtTongTien.Text = hdn.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnSuaSP_Click(object sender, RoutedEventArgs e)
        {
            string mess = "";
            HoaDonNhap hdn = new HoaDonNhap();
            if (string.IsNullOrEmpty(txtIDHD.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdn.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    int sl = 1;
                    CTHDN cthdn = new CTHDN();
                    if(txtSoLuong.Text !="" || txtGia.Text !="")
                    {
                        if (int.TryParse(txtSoLuong.Text, out sl) == false)
                        {
                            MessageBox.Show("Nhập sai số lượng rồi -_-");
                            return;
                        }
                        float gia = 0;
                        if (float.TryParse(txtGia.Text, out gia) == false)
                        {
                            MessageBox.Show("Nhập sai đơn giá rồi -_-");
                            return;
                        }
                        mess = cthdn.SuaSanPham(txtIDHD.Text, txtTenSP.Text, txtSoLuong.Text ,txtGia.Text , cmbNCC.SelectedItem);
                        dataGrid.DataContext = cthdn.LayViewCTHDN(txtIDHD.Text);
                        MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        txtTongTien.Text = hdn.LayTongTien(txtIDHD.Text).ToString();
                    }
                    else
                    {
                        mess = cthdn.SuaSanPham(txtIDHD.Text, txtTenSP.Text, txtSoLuong.Text, txtGia.Text, cmbNCC.SelectedItem);
                        dataGrid.DataContext = cthdn.LayViewCTHDN(txtIDHD.Text);
                        MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        txtTongTien.Text = hdn.LayTongTien(txtIDHD.Text).ToString();
                    }
                    //dataGrid.DataContext = cthdn.LayViewCTHDN(txtIDHD.Text);
                    //MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    //txtTongTien.Text = hdn.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnXoaSP_Click(object sender, RoutedEventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap();
            if (string.IsNullOrEmpty(txtIDHD.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || cmbNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdn.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    CTHDN cthdn = new CTHDN();
                    string mess = cthdn.XoaSanPham(txtIDHD.Text,txtTenSP.Text);
                    dataGrid.DataContext = cthdn.LayViewCTHDN(txtIDHD.Text);
                    MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    txtTongTien.Text = hdn.LayTongTien(txtIDHD.Text).ToString();
                }
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap();
            if (string.IsNullOrEmpty(txtIDHD.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdn.KTHoaDon(txtIDHD.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    CTHDN cthdn = new CTHDN();
                    MessageBox.Show("Đã tìm thấy", "Tộc phèo caffein vui vẻ nói: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dataGrid.DataContext = cthdn.LayViewCTHDN(txtIDHD.Text);
                    txtTongTien.Text = hdn.LayTongTien(txtIDHD.Text).ToString();
                    var hdn1 = hdn.LayHDN(txtIDHD.Text);
                    txtIDNV.Text = hdn1.manv;
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtTenSP.Text = "";
            txtIDHD.Text = "";
            txtIDNV.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            txtTongTien.Text = "";
        }

        private void btnInHD_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dataGrid.Columns.Count; j++) 
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; 
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = dataGrid.Columns[j].Header;
            }
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            { 
                for (int j = 0; j < dataGrid.Items.Count; j++)
                {
                    TextBlock b = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
    }
}
