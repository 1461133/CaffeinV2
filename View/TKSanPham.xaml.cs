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
    /// Interaction logic for TKSanPham.xaml
    /// </summary>
    public partial class TKSanPham : Window
    {
        LoaiSP lsp = new LoaiSP();
        public string TENDN;
        public TKSanPham()
        {
            SanPham sp = new SanPham();
            InitializeComponent();
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.ViewSanPham = sp.LayViewSP();
            lbSanPham.DataContext = sp.LayViewSP();
            cmbLoai.DataContext = lsp.LayAllLoaiSP();

        }
        public TKSanPham(string tendn)
        {
            SanPham sp = new SanPham();
            InitializeComponent();
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.ViewSanPham = sp.LayViewSP();
            lbSanPham.DataContext = sp.LayViewSP();
            cmbLoai.DataContext = lsp.LayAllLoaiSP();
            TENDN = tendn;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void btnSearch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtTenSP.Text) && cmbLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ! Để tìm kiếm vui lòng nhập một trong thông tin: mã, tên, loại!!!");
                return;
            }
            lbSanPham.DataContext = null;
            //cmbdssp.SelectedIndex = 2;
            //var db = this.FindResource("Caffein") as ViewModel.Caffein;
            //int totalPage;
            //db.CurPage = 1;
            SanPham sp = new SanPham();
            var dssp = sp.TKSanPham(txtID.Text, cmbLoai.SelectedItem, txtTenSP.Text);
            if (dssp.Count() == 0)
            {
                MessageBox.Show("Không có sản phẩm này!!!");
            }
            else
            {
                lbSanPham.DataContext = dssp;
                //if (dssp.Count() == 1)
                //{
                //    //db.TotalPage = 1;
                //    //foreach (var item in dssp)
                //    //{
                //    //    SanPham sp1 = new SanPham();
                //    //    if (sp.KTKSanPhamTT(item.masp) == true)
                //    //        cmbdssp.SelectedIndex = 0;
                //    //    else
                //    //    {
                //    //        cmbdssp.SelectedIndex = 1;
                //    //    }
                //    //}
                //    dataGrid.DataContext = dssp;

                //}
                //else
                //{

                //}
                //db.TotalPage = 1;

            }
        }

        private void btnRefreshTKSanPham_Click(object sender, RoutedEventArgs e)
        {

            txtID.Text = "";
            txtTenSP.Text = "";
            cmbLoai.Text = "";
            SanPham sp = new SanPham();
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.ViewSanPham = sp.LayViewSP();
            lbSanPham.DataContext = sp.LayViewSP();
        }

        private void btnTQL_Click(object sender, RoutedEventArgs e)
        {
            TCKhachHang tc = new TCKhachHang(TENDN);
            tc.Show();
            this.Close();
        }
    }
}
