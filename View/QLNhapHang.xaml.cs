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
    /// Interaction logic for QLNhapHang.xaml
    /// </summary>
    public partial class QLNhapHang : Window
    {
        public QLNhapHang()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThemNCC_Click(object sender, RoutedEventArgs e)
        {
            
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
                // string mess = hdn.ThemHoaDon(fn,txtIDNV.Text,)
               // MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
               // txtTongTien.Text = hdb.LayTongTien(txtIDHD.Text).ToString();
            }
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXoaSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
