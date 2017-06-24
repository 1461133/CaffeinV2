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
    /// Interaction logic for TKNhanVien.xaml
    /// </summary>
    public partial class TKNhanVien : Window
    {
        NhanVien nv = new NhanVien();
        public TKNhanVien()
        {
            InitializeComponent();
            dataGrid.DataContext = nv.LayViewNV();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }
        private void btnSearch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NhanVien nv1 = new NhanVien();
            dataGrid.DataContext = null;
            //cmbdsnv.SelectedIndex = 2;
            //var db = this.FindResource("Caffein") as ViewModel.Caffein;
            //int totalPage;
            //db.CurPage = 1;

            var dsnv = nv1.TKNhanVien(txtID.Text, txtTenNV.Text, txtCMND.Text, txtSDT.Text);
            if (dsnv.Count() == 0)
            {
                MessageBox.Show("Không có nhân viên này!!!");
            }
            else
            {
                dataGrid.DataContext = dsnv;
            }
        }
    }
}
