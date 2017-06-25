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
    /// Interaction logic for QLHoaDon.xaml
    /// </summary>
    public partial class QLHoaDon : Window
    {
        public string TENDN;
        public QLHoaDon()
        {
            InitializeComponent();

            HoaDonBan hdb = new HoaDonBan();
            dgvHoaDonBan.DataContext = hdb.LayHDBan_QL();


            HoaDonNhap hdn = new HoaDonNhap();
            dgvHoaDonNhap.DataContext = hdn.LayHDNhap_QL();
        }
        public QLHoaDon(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;

            HoaDonBan hdb = new HoaDonBan();
            dgvHoaDonBan.DataContext = hdb.LayHDB();


            HoaDonNhap hdn = new HoaDonNhap();
            dgvHoaDonNhap.DataContext = hdn.LayHDN();
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Close();
        }

        private void btnTKHDB_Click(object sender, RoutedEventArgs e)
        {
            
            HoaDonBan hdb = new HoaDonBan();
            if (string.IsNullOrEmpty(txtMaHDB.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdb.KTHoaDon(txtMaHDB.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    MessageBox.Show("Đã tìm thấy", "Tộc phèo caffein vui vẻ nói: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dgvHoaDonBan.DataContext = hdb.LayHDB_QL(txtMaHDB.Text);

                }
            }
            
        }

        private void btnTKHDN_Click(object sender, RoutedEventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap();
            if (string.IsNullOrEmpty(txtMaHDN.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (hdn.KTHoaDon(txtMaHDN.Text) == false)
                {
                    MessageBox.Show("Sai mã hóa đơn hoặc chưa lập hóa đơn rồi -_-");
                    return;
                }
                else
                {
                    MessageBox.Show("Đã tìm thấy", "Tộc phèo caffein vui vẻ nói: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dgvHoaDonNhap.DataContext = hdn.LayHDN_QL(txtMaHDN.Text);

                }
            }
        }

        private void btnRefreshHDB_Click(object sender, RoutedEventArgs e)
        {
            txtMaHDB.Text = "";
            HoaDonBan hdb = new HoaDonBan();
            dgvHoaDonBan.DataContext = hdb.LayHDBan_QL();
        }

        private void btnRefreshHDN_Click(object sender, RoutedEventArgs e)
        {
            txtMaHDN.Text = "";
            HoaDonNhap hdn = new HoaDonNhap();
            dgvHoaDonNhap.DataContext = hdn.LayHDNhap_QL();
        }

        private void btnTQL_Click(object sender, RoutedEventArgs e)
        {
            TCQuanLy tc = new TCQuanLy(TENDN);
            tc.Show();
            this.Close();
        }
    }
}
