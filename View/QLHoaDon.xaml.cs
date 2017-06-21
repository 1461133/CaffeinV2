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
        public QLHoaDon()
        {
            InitializeComponent();
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
                        dgvHoaDonBan.DataContext = hdb.LayHDB(txtMaHDB.Text);
                        
                    }
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
                    dgvHoaDonNhap.DataContext = hdn.LayHDN(txtMaHDN.Text);

                }
            }
        }
    }
}
