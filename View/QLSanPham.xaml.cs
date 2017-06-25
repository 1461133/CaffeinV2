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
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.IO;

namespace View
{
    /// <summary>
    /// Interaction logic for QLSanPham.xaml
    /// </summary>
    public partial class QLSanPham : Window
    {
        public string TENDN;
        SanPham sp = new SanPham();
        LoaiSP lsp = new LoaiSP();
        public QLSanPham()
        {
            InitializeComponent();
            btnpre.Content = "<";
            btnfirst.Content = "<<";
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.CurPage = 1;
            cmbdssp.SelectedIndex = 0;

            int totalPage;
            db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewSanPham;
            db.TotalPage = totalPage;
            cmbLoai.DataContext = lsp.LayLoaiSP();

        }
        public QLSanPham(string tendn)
        {
            InitializeComponent();
            btnpre.Content = "<";
            btnfirst.Content = "<<";
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.CurPage = 1;
            cmbdssp.SelectedIndex = 0;

            int totalPage;
            db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewSanPham;
            db.TotalPage = totalPage;
            cmbLoai.DataContext = lsp.LayLoaiSP();
            TENDN = tendn;
        }
        public void getString(string s)
        {
            MessageBox.Show(s);
        }
        private void btnQL_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TCQuanLy tc = new TCQuanLy(TENDN);
            tc.Show();
            this.Close();

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void btnThem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTenSP.Text)|| cmbLoai.SelectedIndex == -1 )
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if(txtID.Text.Substring(0,2) !="SP")
                {
                    MessageBox.Show("Nhập mã sp sai, phải bắt đầu = SP", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                if (txtID.Text.Length != 5)
                {
                    MessageBox.Show("Nhập sai mã sản phẩm!!! Vui lòng nhập lại, mã có 5 ký tự");
                    return;
                }
                int tam;
                if (int.TryParse(txtID.Text.Substring(2), out tam)==false)
                {
                    MessageBox.Show("Nhập mã sp sai sau SP phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                if(int.TryParse(txtGiaBan.Text, out tam) == false)
                {
                    
                     MessageBox.Show("Giá bán phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (int.TryParse(txtGiaNhap.Text, out tam) == false)
                {

                    MessageBox.Show("Giá nhập phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (int.TryParse(txtSL.Text, out tam) == false)
                {

                    MessageBox.Show("Số lượng phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                string mlsp ="";
                
                {
                    
                    mlsp = lsp.LayMaLoaiSP(cmbLoai.SelectedItem);
                    
                }
            
                string mess = sp.ThemSanPham(txtID.Text, txtTenSP.Text,mlsp, txtGiaNhap.Text, txtGiaBan.Text, txtSL.Text,txtHA.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 0;

                int totalPage;
                db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPham;
                db.TotalPage = totalPage;
                cmbLoai.DataContext = lsp.LayLoaiSP();
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
                string mlsp;
                if (cmbLoai.SelectedIndex == -1)
                {
                    mlsp = "";
                }
                else
                {
                   // var lsp = cmbLoai.SelectedItem as LoaiSP;
                    mlsp = lsp.LayMaLoaiSP(cmbLoai.SelectedItem);

                }
                string mess = sp.SuaSanPham(txtID.Text, txtTenSP.Text, mlsp, txtGiaNhap.Text, txtGiaBan.Text, txtSL.Text, txtHA.Text);
                MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 0;

                int totalPage;
                db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPham;
                db.TotalPage = totalPage;
                cmbLoai.DataContext = lsp.LayLoaiSP();

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
                string mess = sp.XoaSanPham(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 1;

                int totalPage;
                db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPhamXoa;
                db.TotalPage = totalPage;
                cmbLoai.DataContext = lsp.LayLoaiSP();
            }
        }

        private void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QL_QuancapheEntities DB = new QL_QuancapheEntities();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Filter = "Image files (*.bmp, *.jpg)|*.bmp;*.jpg|All files (*.*)|*.*";
                openFileDialog1.DefaultExt = ".jpg";
                txtHA.Text = openFileDialog1.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(txtHA.Text));
                image1.Source = imageSource;
            }
            catch
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
            }

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
                string mess = sp.PhucHoiSanPham(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 1;

                int totalPage;
                db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPhamXoa;
                db.TotalPage = totalPage;
                cmbLoai.DataContext = lsp.LayLoaiSP();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = "";
            txtHA.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtSL.Text = "";
            txtTenSP.Text = "";
            cmbLoai.SelectedIndex = -1;
            dataGrid.DataContext = null;
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.CurPage = 1;
            cmbdssp.SelectedIndex = 0;
          
            int totalPage;
            db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
            dataGrid.DataContext = db.ViewSanPham;
            db.TotalPage = totalPage;
        }

        private void Search_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtTenSP.Text) && cmbLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ! Để tìm kiếm vui lòng nhập một trong thông tin: mã, tên, loại!!!");
                return;
            }
            dataGrid.DataContext = null;
            cmbdssp.SelectedIndex = 2;
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            int totalPage;
            db.CurPage = 1;

            var dssp = sp.TKSanPham(txtID.Text,cmbLoai.SelectedItem,txtTenSP.Text);
            if (dssp.Count() == 0)
            {
                MessageBox.Show("Không có sản phẩm này!!!");
            }
            else
            {
                if (dssp.Count() == 1)
                {
                    db.TotalPage = 1;
                    foreach (var item in dssp)
                    {
                        SanPham sp = new SanPham();
                        if (sp.KTKSanPhamTT(item.masp) == true)
                            cmbdssp.SelectedIndex = 0;
                        else
                        {
                            cmbdssp.SelectedIndex = 1;
                        }
                    }
                    dataGrid.DataContext = dssp;
                   
                }
                else
                {
                    dataGrid.DataContext = dssp;
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
                    if (cmbdssp.SelectedIndex == 0)
                    {
                        db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPham;
                    }
                    if (cmbdssp.SelectedIndex == 1)
                    {
                        db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamXoa;
                    }
                    if (cmbdssp.SelectedIndex == 2)
                    {
                        db.ViewSanPhamAll = sp.LayViewSPAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamAll;
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
                    if (cmbdssp.SelectedIndex == 0)
                    {
                        db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPham;
                    }
                    if (cmbdssp.SelectedIndex == 1)
                    {
                        db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamXoa;
                    }
                    if (cmbdssp.SelectedIndex == 2)
                    {
                        db.ViewSanPhamAll = sp.LayViewSPAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamAll;
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
                    if (cmbdssp.SelectedIndex == 0)
                    {
                        db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPham;
                    }
                    if (cmbdssp.SelectedIndex == 1)
                    {
                        db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamXoa;
                    }
                    if (cmbdssp.SelectedIndex == 2)
                    {
                        db.ViewSanPhamAll = sp.LayViewSPAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamAll;
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
                    if (cmbdssp.SelectedIndex == 0)
                    {
                        db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPham;
                    }
                    if (cmbdssp.SelectedIndex == 1)
                    {
                        db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamXoa;
                    }
                    if (cmbdssp.SelectedIndex == 2)
                    {
                        db.ViewSanPhamAll = sp.LayViewSPAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                        dataGrid.DataContext = db.ViewSanPhamAll;
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

        private void cmbdssp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbdssp.SelectedIndex == -1)
            {
                dataGrid.DataContext = null;
            }
                if (cmbdssp.SelectedIndex == 0)
            {
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 0;
                //dataGrid.DataContext = kh.LayViewKH();
                int totalPage;
                db.ViewSanPham = sp.LayViewSP(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPham;
                db.TotalPage = totalPage;
            }
            if (cmbdssp.SelectedIndex == 1)
            {
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 1;
                int totalPage;
                db.ViewSanPhamXoa = sp.LayViewSPXoa(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPhamXoa;
                db.TotalPage = totalPage;
            }
            if (cmbdssp.SelectedIndex == 2)
            {
                var db = this.FindResource("Caffein") as ViewModel.Caffein;
                db.CurPage = 1;
                cmbdssp.SelectedIndex = 2;
                int totalPage;
                db.ViewSanPhamAll = sp.LayViewSPAll(db.CurPage, ViewModel.Caffein.PageSize, out totalPage);
                dataGrid.DataContext = db.ViewSanPhamAll;
                db.TotalPage = totalPage;
            }
        }

        private void btnThemLsp_Click(object sender, RoutedEventArgs e)
        {
            QLLoaiSP lsp = new QLLoaiSP();
            lsp.Show();
            this.Close();

        }

        //private void btnOutImage_Click(object sender, RoutedEventArgs e)
        //{

        //    var result = File.ReadAllBytes(txtHA.Text);
        //    Stream StreamObj = new MemoryStream(result);
        //    BitmapImage BitObj = new BitmapImage();
        //    BitObj.BeginInit();
        //    BitObj.StreamSource = StreamObj;
        //    BitObj.EndInit();
        //    this.image1.Source = BitObj;

        //}



    }
}
